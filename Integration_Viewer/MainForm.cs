using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.Utils.Drawing;
using DevExpress.XtraTab.Registrator;
using DevExpress.XtraTab.Drawing;
using System.Diagnostics;
using Sedas.UserControl;

namespace Integration_Viewer
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        TabPage1 tabPage1;
        TabPage2 tabPage2;
        TabPage3 tabPage3;


        /// <summary>
        /// name         : MainForm_Load
        /// desc         : 화면 로드시
        /// author       : 심우종
        /// create date  : 2020-06-23 09:25
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void MainForm_Load(object sender, EventArgs e)
        {

            //Skin currentSkin = TabSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel);
            //SkinElement element = currentSkin[TabSkins.SkinTabPane];
            //element.Image.ImageCount = 0;
            ////element.Color.BackColor = this.tabControl.BackColor;  
            //LookAndFeelHelper.ForceDefaultLookAndFeelChanged();

            this.SelectionTabPage(this.tabControl.SelectedTabPage);

            PaintStyleCollection.DefaultPaintStyles.Add(new MySkinViewInfoRegistrator());
            hTabControl1.PaintStyleName = "MyStyle";


            //DevExpress.XtraTab.Registrator.PaintStyleCollection.DefaultPaintStyles.Add(new MyOffice2003ViewInfoRegistrator());
            //hTabControl1.PaintStyleName = "MyOffice2003";
        }

        public class MyOffice2003ViewInfoRegistrator : Office2003ViewInfoRegistrator
        {
            public override string ViewName { get { return "MyOffice2003"; } }
            public override BorderPainter CreateTabControlBorderPainter()
            {
                return new MyOffice2003BorderPainter();
            }
        }

        public class MyOffice2003BorderPainter : DevExpress.Utils.Drawing.Office2003BorderPainter
        {
            public override void DrawObject(ObjectInfoArgs e)
            {
                Brush brush = e.Cache.GetSolidBrush(Color.Red);
                e.Cache.Paint.DrawRectangle(e.Graphics, brush, e.Bounds);
            }
        }


        /// <summary>
        /// name         : tabControl_SelectedPageChanged
        /// desc         : 탭 선택 변경시
        /// author       : 심우종
        /// create date  : 2020-06-23 08:47
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void tabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            this.SelectionTabPage(e.Page);
        }


        /// <summary>
        /// name         : SelctionTabPage
        /// desc         : 탭 페이지 선택 변경시
        /// author       : 심우종
        /// create date  : 2020-06-23 09:26
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SelectionTabPage(XtraTabPage page)
        {
            if (page != null)
            {
                if (page.Name == "tab1")
                {
                    if (tabPage1 == null)
                    {
                        tabPage1 = new TabPage1();
                        page.Controls.Add(tabPage1);
                        tabPage1.Dock = DockStyle.Fill;
                    }
                }
                else if (page.Name == "tab2")
                {
                    if (tabPage2 == null)
                    {
                        tabPage2 = new TabPage2();
                        page.Controls.Add(tabPage2);
                        tabPage2.Dock = DockStyle.Fill;
                    }
                }
                else if (page.Name == "tab3")
                {
                    if (tabPage3 == null)
                    {
                        tabPage3 = new TabPage3();
                        page.Controls.Add(tabPage3);
                        tabPage3.Dock = DockStyle.Fill;
                        //tabPage3.Update();
                        //page.Update();
                    }
                }
                else if (page.Name == "tab4")
                {

                }

            }
        }


        Color borderColor = Color.FromArgb(36, 84, 136);
        private void tlpCenter_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {

            var rectangle = e.CellBounds;

            if (e.Row == 1)
            {
                
                ControlPaint.DrawBorder(e.Graphics, rectangle, borderColor, 1, ButtonBorderStyle.Solid
                                                                  , borderColor, 0, ButtonBorderStyle.Solid
                                                                  , borderColor, 1, ButtonBorderStyle.Solid
                                                                  , borderColor, 1, ButtonBorderStyle.Solid);
            }

            
        }

        private void hTabControl1_CustomDrawTabHeader(object sender, TabHeaderCustomDrawEventArgs e)
        {
            var rectangle = e.Bounds;
            ControlPaint.DrawBorder(e.Graphics, rectangle, borderColor, 1, ButtonBorderStyle.Solid
                                                                  , borderColor, 1, ButtonBorderStyle.Solid
                                                                  , borderColor, 1, ButtonBorderStyle.Solid
                                                                  , borderColor, 1, ButtonBorderStyle.Solid);

        }

        private void hTabControl1_CustomDrawHeaderButton(object sender, HeaderButtonCustomDrawEventArgs e)
        {
            var rectangle = e.Bounds;
            ControlPaint.DrawBorder(e.Graphics, rectangle, borderColor, 1, ButtonBorderStyle.Solid
                                                                  , borderColor, 1, ButtonBorderStyle.Solid
                                                                  , borderColor, 1, ButtonBorderStyle.Solid
                                                                  , borderColor, 1, ButtonBorderStyle.Solid);
        }

        private void hTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            this.tabControl.SelectedTabPageIndex = hTabControl1.SelectedTabPageIndex;
        }


        /// <summary>
        /// name         : btnDock_MouseEnter
        /// desc         : 오른쪽 dock 버튼 마우스Enter이벤트
        /// author       : 심우종
        /// create date  : 2020-07-06 09:31
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnDock_MouseEnter(object sender, EventArgs e)
        {
            //if (sender is Sedas.Control.HSimpleButton)
            //{
            //    Sedas.Control.HSimpleButton button = sender as Sedas.Control.HSimpleButton;
            //    SetDockButtonImage(button, true);
            //}
        }


        /// <summary>
        /// name         : btnDock_MouseLeave
        /// desc         : 오른쪽 dock 버튼 마우스Leave이벤트
        /// author       : 심우종
        /// create date  : 2020-07-06 09:32
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnDock_MouseLeave(object sender, EventArgs e)
        {
            //if (sender is Sedas.Control.HSimpleButton)
            //{
            //    Sedas.Control.HSimpleButton button = sender as Sedas.Control.HSimpleButton;
            //    SetDockButtonImage(button, false);
            //}
        }


        /// <summary>
        /// name         : SetDockButtonImage
        /// desc         : 오른쪽 dock 버튼에 이미지 설정
        /// author       : 심우종
        /// create date  : 2020-07-06 09:32
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SetDockButtonImage(Sedas.Control.HPictureEdit pic, bool isEnter)
        {
            switch (pic.Tag.ToString())
            {
                case "01":
                    if (isEnter == true)
                    {
                        pic.Image = global::Integration_Viewer.Properties.Resources.dock_01_on;
                    }
                    else
                    {
                        pic.Image = global::Integration_Viewer.Properties.Resources.dock_01;
                    }
                    break;
                case "02":
                    if (isEnter == true)
                    {
                        pic.Image = global::Integration_Viewer.Properties.Resources.dock_02_on;
                    }
                    else
                    {
                        pic.Image = global::Integration_Viewer.Properties.Resources.dock_02;
                    }
                    break;
                case "03":
                    if (isEnter == true)
                    {
                        pic.Image = global::Integration_Viewer.Properties.Resources.dock_03_on;
                    }
                    else
                    {
                        pic.Image = global::Integration_Viewer.Properties.Resources.dock_03;
                    }
                    break;
                case "04":
                    if (isEnter == true)
                    {
                        pic.Image = global::Integration_Viewer.Properties.Resources.dock_04_on;
                    }
                    else
                    {
                        pic.Image = global::Integration_Viewer.Properties.Resources.dock_04;
                    }
                    break;
                case "05":
                    if (isEnter == true)
                    {
                        pic.Image = global::Integration_Viewer.Properties.Resources.dock_05_on;
                    }
                    else
                    {
                        pic.Image = global::Integration_Viewer.Properties.Resources.dock_05;
                    }
                    break;
                case "06":
                    if (isEnter == true)
                    {
                        pic.Image = global::Integration_Viewer.Properties.Resources.dock_06_on;
                    }
                    else
                    {
                        pic.Image = global::Integration_Viewer.Properties.Resources.dock_06;
                    }
                    break;
                case "07":
                    if (isEnter == true)
                    {
                        pic.Image = global::Integration_Viewer.Properties.Resources.dock_07_on;
                    }
                    else
                    {
                        pic.Image = global::Integration_Viewer.Properties.Resources.dock_07;
                    }
                    break;
                case "08":
                    if (isEnter == true)
                    {
                        pic.Image = global::Integration_Viewer.Properties.Resources.dock_08_on;
                    }
                    else
                    {
                        pic.Image = global::Integration_Viewer.Properties.Resources.dock_08;
                    }
                    break;
                case "VideoPlayer":
                    if (isEnter == true)
                    {
                        pic.Image = global::Integration_Viewer.Properties.Resources.dock_09_on;
                    }
                    else
                    {
                        pic.Image = global::Integration_Viewer.Properties.Resources.dock_09;
                    }
                    break;

            }
        }

        private void picDock_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Sedas.Control.HPictureEdit)
            {
                Sedas.Control.HPictureEdit pic = sender as Sedas.Control.HPictureEdit;
                SetDockButtonImage(pic, true);
            }
        }

        private void picDock_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Sedas.Control.HPictureEdit)
            {
                Sedas.Control.HPictureEdit pic = sender as Sedas.Control.HPictureEdit;
                SetDockButtonImage(pic, false);
            }
        }


        /// <summary>
        /// name         : picLink_MouseDown
        /// desc         : 링크버튼 마우스 클릭시
        /// author       : 심우종
        /// create date  : 2020-07-24 14:11
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void picLink_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Sedas.Control.HPictureEdit)
            {
                Sedas.Control.HPictureEdit pic = sender as Sedas.Control.HPictureEdit;

                if (pic != null)
                {
                    if (pic.Tag.ToString() == "VideoPlayer")
                    {
                        using (Process compiler = new Process())
                        {

                            compiler.StartInfo.FileName = "C:\\BASE\\SedasSolutions\\VideoPlayerForServer\\bin\\Debug\\VideoPlayerForServer.exe";
                            //string arg = string.Format("\"{0}\" {1} {2} {3} {4} {5} {6}", filePath, strImagePath, strPathologyNum, imageType, ptNo, ptNm, imageNum);
                            //compiler.StartInfo.Arguments = arg;
                            //compiler.StartInfo.Arguments = "\"" + jsonValue + "\"" ;

                            compiler.StartInfo.UseShellExecute = false;
                            compiler.StartInfo.RedirectStandardOutput = true;
                            compiler.Start();

                            Console.WriteLine(compiler.StandardOutput.ReadToEnd());

                            compiler.WaitForExit();
                        }
                    }
                    else if (pic.Name == "picLinkKuh") // 01. 건국대 홈페이지 링크
                    {
                        //System.Diagnostics.Process.Start("https://www.kuh.ac.kr/main.do");
                        using (Process compiler = new Process())
                        {
                            compiler.StartInfo.FileName = @"C:\Program Files (x86)\Internet Explorer\iexplore.exe";
                            string arg = string.Format("\"{0}\"", "https://www.kuh.ac.kr/main.do");
                            compiler.StartInfo.Arguments = arg;

                            compiler.StartInfo.UseShellExecute = false;
                            compiler.StartInfo.RedirectStandardOutput = true;
                            compiler.Start();

                            Console.WriteLine(compiler.StandardOutput.ReadToEnd());

                            compiler.WaitForExit();
                        }
                    }
                    else if (pic.Name == "picLinkGw") //02. 그룹웨어
                    {
                        using (Process compiler = new Process())
                        {
                            compiler.StartInfo.FileName = @"C:\Program Files (x86)\Internet Explorer\iexplore.exe";
                            string arg = string.Format("\"{0}\"", "https://gw.kuh.ac.kr/login.aspx");
                            compiler.StartInfo.Arguments = arg;

                            compiler.StartInfo.UseShellExecute = false;
                            compiler.StartInfo.RedirectStandardOutput = true;
                            compiler.Start();

                            Console.WriteLine(compiler.StandardOutput.ReadToEnd());

                            compiler.WaitForExit();
                        }
                    }
                    else if (pic.Name == "picLinkKis") // 03. KIS3.0
                    {
                        using (Process compiler = new Process())
                        {
                            compiler.StartInfo.FileName = @"C:\Program Files (x86)\Internet Explorer\iexplore.exe";
                            string arg = string.Format("\"{0}\"", "http://kis.kuh.ac.kr/kisframe.jsp");
                            compiler.StartInfo.Arguments = arg;

                            compiler.StartInfo.UseShellExecute = false;
                            compiler.StartInfo.RedirectStandardOutput = true;
                            compiler.Start();

                            Console.WriteLine(compiler.StandardOutput.ReadToEnd());

                            compiler.WaitForExit();
                        }
                    }
                    else if (pic.Name == "picLinkTalk") //04.병원 메신저
                    {

                    }
                    else if (pic.Name == "picLinkSms") //05. SMS 보내기
                    {
                        this.flyoutPanel1.ShowPopup();
                    }
                }
                
            }
        }


        /// <summary>
        /// name         : btnSMS01_Click
        /// desc         : 직원검색 SMS 보내기 클릭시
        /// author       : 심우종
        /// create date  : 2020-08-24 10:47
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnSMS01_Click(object sender, EventArgs e)
        {
            flyoutPanel1.Options.CloseOnOuterClick = false;
            SmsPopupForTotal smsPopupForTotal = new SmsPopupForTotal();
            smsPopupForTotal.ShowDialog();
            flyoutPanel1.Options.CloseOnOuterClick = true;
            flyoutPanel1.HidePopup();


            
        }


        /// <summary>
        /// name         : btnSMS02_Click
        /// desc         : 직접입력 SMS 보내기 클릭시
        /// author       : 심우종
        /// create date  : 2020-08-24 10:47
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnSMS02_Click(object sender, EventArgs e)
        {
            flyoutPanel1.Options.CloseOnOuterClick = false;
            SmsPopup smsPopup = new SmsPopup();
            smsPopup.ShowDialog();
            flyoutPanel1.Options.CloseOnOuterClick = true;
            flyoutPanel1.HidePopup();
        }
    }

    public class MySkinTapPainter : SkinTabPainter
    {
        public MySkinTapPainter(IXtraTab tabControl)
            : base(tabControl)
        {

        }



        protected override void DrawHeaderBackground(TabDrawArgs e)
        {
            base.DrawHeaderBackground(e);
            ControlPaint.DrawBorder(e.Graphics, e.Bounds, borderColor, 0, ButtonBorderStyle.Solid
                                                                       , borderColor, 0, ButtonBorderStyle.Solid
                                                                       , borderColor, 0, ButtonBorderStyle.Solid
                                                                       , borderColor, 1, ButtonBorderStyle.Solid);
        }

        //Color red = Color.Red;
        Color borderColor = Color.FromArgb(36, 84, 136);
        Color selectedBackColor = Color.FromArgb(17, 17, 22);
        protected override void DrawHeaderPage(TabDrawArgs e, DevExpress.XtraTab.ViewInfo.BaseTabRowViewInfo row, DevExpress.XtraTab.ViewInfo.BaseTabPageViewInfo pInfo)
        {
            base.DrawHeaderPage(e, row, pInfo);
            Rectangle rect = pInfo.Bounds;
            if (pInfo.PageState == ObjectState.Selected)
            {
                var rectangle = e.Bounds;
                

                Brush brush = new SolidBrush(selectedBackColor);
                e.Graphics.FillRectangle(brush, row.SelectedPage.Bounds);

                ControlPaint.DrawBorder(e.Graphics, rect, borderColor, 1, ButtonBorderStyle.Solid
                                                                      , borderColor, 1, ButtonBorderStyle.Solid
                                                                      , borderColor, 1, ButtonBorderStyle.Solid
                                                                      , borderColor, 0, ButtonBorderStyle.Solid);
                DrawHeaderPageImageText(e, pInfo);
                DrawHeaderFocus(e, pInfo);
            }
            else
            {
                //var rectangle = e.Bounds;
                //ControlPaint.DrawBorder(e.Graphics, rect, borderColor, 0, ButtonBorderStyle.Solid
                //                                                      , borderColor, 0, ButtonBorderStyle.Solid
                //                                                      , borderColor, 0, ButtonBorderStyle.Solid
                //                                                      , borderColor, 1, ButtonBorderStyle.Solid);
            }

        }
    }

    public class MySkinViewInfoRegistrator : SkinViewInfoRegistrator
    {
        public MySkinViewInfoRegistrator()
            : base()
        {

        }
        public override string ViewName
        {
            get
            {
                return "MyStyle";
            }
        }
        public override DevExpress.XtraTab.Drawing.BaseTabPainter CreatePainter(DevExpress.XtraTab.IXtraTab tabControl)
        {
            return new MySkinTapPainter(tabControl);
        }
    }
}