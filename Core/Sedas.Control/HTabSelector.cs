using DevExpress.XtraTab;
using Sedas.Control.Animations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Sedas.Control
{
    public partial class HTabSelector : System.Windows.Forms.Control
    {
        //public HTabSelector()
        //{
        //    InitializeComponent();
        //}

        [Browsable(false)]
        public int Depth { get; set; }
        //[Browsable(false)]
        //public MaterialSkinManager SkinManager => MaterialSkinManager.Instance;
        //[Browsable(false)]
        //public MouseState MouseState { get; set; }

        private HTabControl _baseTabControl;
        public HTabControl BaseTabControl
        {
            get { return _baseTabControl; }
            set
            {
                _baseTabControl = value;
                if (_baseTabControl == null) return;
                _previousSelectedTabIndex = _baseTabControl.TabIndex;
                _baseTabControl.Deselected += (sender, args) =>
                {
                    _previousSelectedTabIndex = _baseTabControl.SelectedTabPageIndex;
                };
                _baseTabControl.SelectedPageChanged += (sender, args) =>
                {
                    _animationManager.SetProgress(0);
                    _animationManager.StartNewAnimation(AnimationDirection.In);
                };
                _baseTabControl.ControlAdded += delegate
                {
                    Invalidate();
                };
                _baseTabControl.ControlRemoved += delegate
                {
                    Invalidate();
                };
            }
        }

        private int _previousSelectedTabIndex;
        private Point _animationSource;
        private readonly AnimationManager _animationManager;

        private List<Rectangle> _tabRects;
        private const int TAB_HEADER_PADDING = 24;
        private const int TAB_INDICATOR_HEIGHT = 2;

        public HTabSelector()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
            Height = 48;

            _animationManager = new AnimationManager
            {
                AnimationType = AnimationType.EaseOut,
                Increment = 0.04
            };
            _animationManager.OnAnimationProgress += sender => Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            //g.TextRenderingHint = TextRenderingHint.AntiAlias;

            //g.Clear(SkinManager.ColorScheme.PrimaryColor);

            if (_baseTabControl == null) return;

            if (!_animationManager.IsAnimating() || _tabRects == null || _tabRects.Count != _baseTabControl.TabPages.Count)
                UpdateTabRects();

            var animationProgress = _animationManager.GetProgress();

            //Click feedback
            if (_animationManager.IsAnimating())
            {
                var rippleBrush = new SolidBrush(Color.FromArgb((int)(51 - (animationProgress * 50)), Color.White));
                var rippleSize = (int)(animationProgress * _tabRects[_baseTabControl.SelectedTabPageIndex].Width * 1.75);

                g.SetClip(_tabRects[_baseTabControl.SelectedTabPageIndex]);
                g.FillEllipse(rippleBrush, new Rectangle(_animationSource.X - rippleSize / 2, _animationSource.Y - rippleSize / 2, rippleSize, rippleSize));
                g.ResetClip();
                rippleBrush.Dispose();
            }


            //Color TextColor = Color.FromArgb(
            //    (0xFFFFFF & 0xff0000) >> 16,
            //    (0xFFFFFF & 0xff00) >> 8,
            //     0xFFFFFF & 0xff);

            Color TextColor = Color.Black;

            //Draw tab headers
            foreach (XtraTabPage tabPage in _baseTabControl.TabPages)
            {
                var currentTabIndex = _baseTabControl.TabPages.IndexOf(tabPage);
                Brush textBrush = new SolidBrush(Color.FromArgb(CalculateTextAlpha(currentTabIndex, animationProgress), TextColor));

                g.DrawString(tabPage.Text.ToUpper(), tabPage.Appearance.Header.Font, textBrush, _tabRects[currentTabIndex], new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                textBrush.Dispose();
            }

            //Animate tab indicator
            var previousSelectedTabIndexIfHasOne = _previousSelectedTabIndex == -1 ? _baseTabControl.SelectedTabPageIndex : _previousSelectedTabIndex;
            var previousActiveTabRect = _tabRects[previousSelectedTabIndexIfHasOne];
            var activeTabPageRect = _tabRects[_baseTabControl.SelectedTabPageIndex];

            var y = activeTabPageRect.Bottom - 2;
            var x = previousActiveTabRect.X + (int)((activeTabPageRect.X - previousActiveTabRect.X) * animationProgress);
            var width = previousActiveTabRect.Width + (int)((activeTabPageRect.Width - previousActiveTabRect.Width) * animationProgress);

            

            SolidBrush accentBrush = new System.Drawing.SolidBrush(Color.FromArgb(
                (0x607D8B & 0xff0000) >> 16,
                (0x607D8B & 0xff00) >> 8,
                 0x607D8B & 0xff));
            g.FillRectangle(accentBrush, x, y, width, TAB_INDICATOR_HEIGHT);
        }


        public readonly Color ACTION_BAR_TEXT = Color.FromArgb(255, 255, 255, 255);
        public readonly Color ACTION_BAR_TEXT_SECONDARY = Color.FromArgb(153, 255, 255, 255);

        private int CalculateTextAlpha(int tabIndex, double animationProgress)
        {
            int primaryA = ACTION_BAR_TEXT.A;
            int secondaryA = ACTION_BAR_TEXT_SECONDARY.A;

            if (tabIndex == _baseTabControl.SelectedTabPageIndex && !_animationManager.IsAnimating())
            {
                return primaryA;
            }
            if (tabIndex != _previousSelectedTabIndex && tabIndex != _baseTabControl.SelectedTabPageIndex)
            {
                return secondaryA;
            }
            if (tabIndex == _previousSelectedTabIndex)
            {
                return primaryA - (int)((primaryA - secondaryA) * animationProgress);
            }
            return secondaryA + (int)((primaryA - secondaryA) * animationProgress);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (_tabRects == null) UpdateTabRects();
            for (var i = 0; i < _tabRects.Count; i++)
            {
                if (_tabRects[i].Contains(e.Location))
                {
                    _baseTabControl.SelectedTabPageIndex = i;
                }
            }

            _animationSource = e.Location;
        }

        private void UpdateTabRects()
        {
            _tabRects = new List<Rectangle>();

            //If there isn't a base tab control, the rects shouldn't be calculated
            //If there aren't tab pages in the base tab control, the list should just be empty which has been set already; exit the void
            if (_baseTabControl == null || _baseTabControl.TabPages.Count == 0) return;

            //Calculate the bounds of each tab header specified in the base tab control
            using (var b = new Bitmap(1, 1))
            {
                using (var g = Graphics.FromImage(b))
                {
                    _tabRects.Add(new Rectangle(FORM_PADDING, 0, TAB_HEADER_PADDING * 2 + (int)g.MeasureString(_baseTabControl.TabPages[0].Text, _baseTabControl.TabPages[0].Appearance.Header.Font).Width, Height));
                    for (int i = 1; i < _baseTabControl.TabPages.Count; i++)
                    {
                        _tabRects.Add(new Rectangle(_tabRects[i - 1].Right, 0, TAB_HEADER_PADDING * 2 + (int)g.MeasureString(_baseTabControl.TabPages[i].Text, _baseTabControl.TabPages[i].Appearance.Header.Font).Width, Height));
                    }
                }
            }
        }

        public int FORM_PADDING = 14;
        //public Font ROBOTO_MEDIUM_12 = new Font(LoadFont(Resources.malgunbd), 12f);

        //private FontFamily LoadFont(byte[] fontResource)
        //{
        //    int dataLength = fontResource.Length;
        //    IntPtr fontPtr = Marshal.AllocCoTaskMem(dataLength);
        //    Marshal.Copy(fontResource, 0, fontPtr, dataLength);

        //    uint cFonts = 0;
        //    AddFontMemResourceEx(fontPtr, (uint)fontResource.Length, IntPtr.Zero, ref cFonts);
        //    privateFontCollection.AddMemoryFont(fontPtr, dataLength);

        //    return privateFontCollection.Families.Last();
        //}
    }

}
