using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            //Assembly asm = typeof(DevExpress.UserSkins.Seda20200611).Assembly;
            //DevExpress.Skins.SkinManager.Default.RegisterAssembly(asm);
            InitializeComponent();
        }

        private void hSimpleButton2_Click(object sender, EventArgs e)
        {
            //hFlowLayoutPanel1.WrapContents = false;
            //hFlowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;

            Sedas.Control.HSimpleButton button = new Sedas.Control.HSimpleButton();
            //stackPanel1.Controls.Add(button);
            //stackPanel1.AutoScroll = true;


            this.hFlowLayoutPanel1.Controls.Add(button);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //hSimpleButton3.LookAndFeel.SkinName = "My Basic";
            //hSimpleButton3.LookAndFeel.UseDefaultLookAndFeel = false;
            //hSimpleButton3.LookAndFeel.SkinMaskColor = ""

            this.InitGroupControl();
            this.initMemoContro();
        }

        private void initMemoContro()
        {


            hMemoEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            hMemoEdit2.Properties.Appearance.Options.UseBackColor = true;
            hMemoEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            hMemoEdit2.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            hMemoEdit2.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            hMemoEdit2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            hMemoEdit2.LookAndFeel.SkinName = "My Basic";
            hMemoEdit2.LookAndFeel.UseDefaultLookAndFeel = false;
            hMemoEdit2.Paint += HMemoEdit2_Paint;
            
        }

        private void HMemoEdit2_Paint1(object sender, PaintEventArgs e)
        {
            //throw new NotImplementedException();
            //graphics.FillRectangle(Brushes.Red, edit.ClientRectangle);
        }

        Color borderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
        private void HMemoEdit2_Paint(object sender, PaintEventArgs e)
        {
            //throw new NotImplementedException();
            Color color = borderColor;
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, color, 2, ButtonBorderStyle.Solid
                                                           , color, 2, ButtonBorderStyle.Solid
                                                           , color, 2, ButtonBorderStyle.Solid
                                                           , color, 2, ButtonBorderStyle.Solid);
        }

        private void InitGroupControl()
        {
            //hGroupControl2.BackColor = Color.Red;
            //hGroupControl2.Appearance.BorderColor = Color.Green;
            //hGroupControl2.Appearance.BackColor = Color.Red;
            //hGroupControl2.Appearance.Options.UseBackColor = true;



            StyleController styleController1 = new StyleController();
            // Set the background color.
            styleController1.Appearance.BackColor = Color.LightYellow;
            // Customize the LookAndFeel settings.
            styleController1.LookAndFeel.UseDefaultLookAndFeel = false;
            styleController1.LookAndFeel.SkinName = "My Basic";
            // Assign the StyleController to editors.
            //buttonEdit1.StyleController = styleController1;
            //lookUpEdit1.StyleController = styleController1;

            




        }

        private void hPanelControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFlyPanelTest_Click(object sender, EventArgs e)
        {
            flyoutPanel1.ShowPopup();
        }
    }
}
