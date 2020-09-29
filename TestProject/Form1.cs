using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sedas.UserControl;
using Sedas.Core;


using log4net;
using log4net.Config;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System.Xml;
using log4net.Core;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Sedas.DB;
using System.Diagnostics;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Net.Sockets;

namespace TestProject
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void hSimpleButton1_Click(object sender, EventArgs e)
        {
            string tempVal = hMemoEdit1.Text;

            string[] tempVal2 = tempVal.Split('\n');

            List<string> tempVal3 = new List<string>();
            for (int i = 0; i < tempVal2.Length; i++)
            {
                string temp = tempVal2.ElementAt(i).Replace("\r", "").Replace("\\", "").Replace("\"", "").Trim().ToUpper();

                if (!tempVal3.Contains(temp))
                {
                    tempVal3.Add(temp);
                }
            }

            for (int i = 0; i < tempVal3.Count; i++)
            {
                hMemoEdit2.Text = hMemoEdit2.Text + Environment.NewLine + tempVal3.ElementAt(i);
            }


        }

        private void hSimpleButton2_Click(object sender, EventArgs e)
        {
            StringBuilder compText = new StringBuilder();
            string text1 = hMemoEdit1.Text;
            string[] splite = text1.Split('\n');
            if (splite.Count() > 0)
            {

                for (int i = 0; i < splite.Count(); i++)
                {
                    string tempValue = splite.ElementAt(i);
                    tempValue = tempValue.TrimStart().Replace("\"", "").Replace("\r", "");
                    compText.Append(tempValue.ToString() + Environment.NewLine);
                }
            }
            this.hMemoEdit2.Text = compText.ToString();
        }

        private void hSimpleButton3_Click(object sender, EventArgs e)
        {

            //System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();

            string ip = "10.10.221.71";
            int port = 1111;
            using (TcpClient client = new TcpClient(ip, port))
            {
                if (client.Connected == true)
                { 
                    
                }
            }



            return;

            //String url = "http://www.there.net/img.png";
            string url = "http://10.10.221.71:1111/Receive/blue.jpg";
            String fileName = "d:/a.jpg";
            if (!DownloadRemoteImageFile(url, fileName))
            {
                MessageBox.Show("Download Failed: " + url);
            }
        }

        private bool DownloadRemoteImageFile(string uri, string fileName)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            bool bImage = response.ContentType.StartsWith("image",
                StringComparison.OrdinalIgnoreCase);
            if ((response.StatusCode == HttpStatusCode.OK ||
                response.StatusCode == HttpStatusCode.Moved ||
                response.StatusCode == HttpStatusCode.Redirect) &&
                bImage)
            {
                using (Stream inputStream = response.GetResponseStream())
                using (Stream outputStream = File.OpenWrite(fileName))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    do
                    {
                        bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                        outputStream.Write(buffer, 0, bytesRead);
                    } while (bytesRead != 0);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            Form2 designForm = new Form2();
            designForm.ShowDialog();
        }

        private void hSimpleButton4_Click(object sender, EventArgs e)
        {
            GdPicturePdfToImage test = new GdPicturePdfToImage();
            test.ShowDialog();
        }


        /// <summary>
        /// name         : hSimpleButton5_Click
        /// desc         : 새다스 파일선택 팝업
        /// author       : 심우종
        /// create date  : 2020-05-28 14:12
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void hSimpleButton5_Click(object sender, EventArgs e)
        {
            //sedasFileOpen.InitServerInfo("10.10.221.71", "1111");

            //생성자에 아무것도 안넘기면 로컬용
            //아이피와 포트를 넘기면 서버 접속용
            SedasFileOpenPopup sedasFileOpenPopup = new SedasFileOpenPopup();
            //SedasFileOpenPopup sedasFileOpenPopup = new SedasFileOpenPopup("10.10.221.71", "1111");
            sedasFileOpenPopup.ShowDialog();

            string result = "";
            if (sedasFileOpenPopup.ResultState == SedasFileOpenPopup.PopupResult.OK)
            {
                List<string> files = sedasFileOpenPopup.SelctedFiles;

                for (int i = 0; i < files.Count; i++)
                {
                    result = result + files.ElementAt(i) + "\r\n";
                }
            }

            MessageBox.Show(result);
        }


        /// <summary>
        /// name         : hSimpleButton6_Click
        /// desc         : 로그 테스트
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        LogHelper logHelper = new LogHelper("10.10.221.71", "1111");
        private void hSimpleButton6_Click(object sender, EventArgs e)
        {
            //LogDTO logDTO = new LogDTO();
            //logDTO.ptno = "16655329";
            //logDTO.ptoNo = "S2005767";
            //logDTO.data_val_01 = "test1";
            //logDTO.data_val_02 = "test2";
            //logDTO.data_val_03 = "test3";
            //logDTO.data_val_04 = "test4";
            //logDTO.data_val_05 = "test5";
            //logDTO.data_val_06 = "test6";

            ////----------------- 파라미터 -----------------------
            ////logCode : 해당 로그에 대한 구분값(특정 행위, 특정화면에 대해서 구분값이 겹치지 않도록 한다.)
            ////ptoNO : 병리번호
            ////ptNo : 환자번호
            ///Comment : 최대 6개 입력하고 싶은 내용
            //logHelper.WriteLog("LOGTTT", "testPtoNo", "testPtNo", new string[] { "1111", "2222", "3333", "4444", "5555", "6666" });
            //logHelper.WriteLogLocalOnly("LOG1", "testPtoNo", "testPtNo", new string[] { "1111", });
            //logHelper.WriteLogLocalOnly("LOG2", "testPtoNo", "testPtNo", new string[] { "2222", });
            //logHelper.WriteLogLocalOnly("LOG3", "testPtoNo", "testPtNo", new string[] { "3333", });
            //logHelper.WriteLogLocalOnly("LOG4", "testPtoNo", "testPtNo", new string[] { "4444", });

            //for (int i = 0; i < 30; i++)
            //{
            //    logHelper.WriteLog("LOG1", "testPtoNo", "testPtNo", new string[] { "1111", });
            //    logHelper.WriteLog("LOG2", "testPtoNo", "testPtNo", new string[] { "2222", });
            //    logHelper.WriteLog("LOG3", "testPtoNo", "testPtNo", new string[] { "3333", });
            //    logHelper.WriteLog("LOG4", "testPtoNo", "testPtNo", new string[] { "4444", });
            //}

            //logHelper.WriteLog("LOG1", "testPtoNo", "testPtNo", new string[] { "1111", });
            //logHelper.WriteLog("LOG2", "testPtoNo", "testPtNo", new string[] { "2222", });
            //logHelper.WriteLog("LOG3", "testPtoNo", "testPtNo", new string[] { "3333", });
            //logHelper.WriteLog("LOG4", "testPtoNo", "testPtNo", new string[] { "4444", });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetSkinElement();
            //Skin skin = GridSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel);
            //SkinElement elem = skin[GridSkins.SkinBorder];
            //elem.Border.All = Color.Blue;
            //elem.Properties["Indent"] = 1;
            //elem.Color.ForeColor = Color.Red;

            InitDataGrid();
            InitTextEdit();
            InitCombobox();
            InitImageCombobox();
            InithDateEdit();
            initButton();
            initMemoEdit();
            initflowlayoutPanel();
            initListBox();

            //hImageComboBoxEdit3.LookAndFeel.SetSkinStyle(SkinSvgPalette.DefaultSkin.BlueDark);


        }

        private void initListBox()
        {
            hListBoxControl1.Items.Add("test1");
            hListBoxControl1.Items.Add("test2");
        }

        private void initflowlayoutPanel()
        {

        }



        private void initMemoEdit()
        {

            this.hMemoEdit3.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.hMemoEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.hMemoEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hMemoEdit3.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.hMemoEdit3.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.hMemoEdit3.Properties.LookAndFeel.UseDefaultLookAndFeel = false;

        }






        private void initButton()
        {
            //hSimpleButton7.Appearance.BackColor = buttonColor1;
            //hSimpleButton7.Appearance.ForeColor = Color.White;
            //hSimpleButton7.Appearance.Options.UseBorderColor = false;

        }

        private void InithDateEdit()
        {
            //스타일적용 시작
            //this.hDateEdit1.Properties.Appearance.BackColor = backColor;
            //this.hDateEdit1.Properties.Appearance.Options.UseBackColor = true;
            //this.hDateEdit1.Properties.Appearance.ForeColor = textColor;
            ////this.hDateEdit1.Properties.AppearanceDropDown.BackColor = backColor;
            ////this.hDateEdit1.Properties.AppearanceDropDown.ForeColor = textColor;
            ////this.hDateEdit1.Properties.AppearanceDropDown.BorderColor = borderColor;
            ////this.hDateEdit1.Properties.AppearanceDropDown.Options.UseBorderColor = true;
            //this.hDateEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            //this.hDateEdit1.Properties.Appearance.Options.UseBorderColor = true;
            //this.hDateEdit1.Properties.Appearance.BorderColor = borderColor;
            //this.hDateEdit1.Properties.Buttons[0].Appearance.BackColor = buttonColor2;
            //this.hDateEdit1.Properties.Buttons[0].Appearance.BorderColor = buttonColor2;
            //this.hDateEdit1.Properties.Buttons[0].IsDefaultButton = true;
            //this.hDateEdit1.Properties.Buttons[0].AppearancePressed.BackColor = buttonColor2;
            //this.hDateEdit1.Properties.Buttons[0].AppearancePressed.BorderColor = buttonColor2;
            //this.hDateEdit1.Properties.Buttons[0].AppearanceHovered.BackColor = buttonColor2;
            //this.hDateEdit1.Properties.Buttons[0].AppearanceHovered.BorderColor = buttonColor2;
            //this.hDateEdit1.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            //this.hDateEdit1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            //this.hDateEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
        }


        private void InitImageCombobox()
        {
            //List<CommonCodeDTO> commonCodeList = new List<CommonCodeDTO>();

            string[] pathologyType = { "S", "C", "AC", "F", "M", "*" };


            DataTable dt = new DataTable();
            dt.Columns.Add("cdVal");
            dt.Columns.Add("cdValNm");


            for (int i = 0; i < pathologyType.Length; i++)
            {
                DataRow row = dt.NewRow();
                row["cdVal"] = pathologyType[i].ToString();
                row["cdValNm"] = pathologyType[i].ToString();
                dt.Rows.Add(row);
            }

            this.hImageComboBoxEdit1.DataBindingFromDataTable(dt, "cdVal", "cdValNm");


            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));

            //스타일적용 시작
            this.hImageComboBoxEdit1.Properties.Appearance.BackColor = backColor;
            this.hImageComboBoxEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.hImageComboBoxEdit1.Properties.Appearance.ForeColor = textColor;
            this.hImageComboBoxEdit1.Properties.AppearanceDropDown.BackColor = backColor;
            this.hImageComboBoxEdit1.Properties.AppearanceDropDown.ForeColor = textColor;
            this.hImageComboBoxEdit1.Properties.AppearanceItemSelected.BackColor = backColor;
            this.hImageComboBoxEdit1.Properties.AppearanceDropDown.BorderColor = borderColor;
            this.hImageComboBoxEdit1.Properties.AppearanceDropDown.Options.UseBorderColor = true;
            this.hImageComboBoxEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.hImageComboBoxEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.hImageComboBoxEdit1.Properties.Appearance.BorderColor = borderColor;

            //버튼 스타일..
            this.hImageComboBoxEdit1.Properties.Buttons[0].Appearance.BackColor = backColor;
            this.hImageComboBoxEdit1.Properties.Buttons[0].Appearance.BorderColor = buttonColor2;
            this.hImageComboBoxEdit1.Properties.Buttons[0].IsDefaultButton = true;
            //this.hImageComboBoxEdit1.Properties.Buttons[0].AppearancePressed.BackColor = backColor;
            //this.hImageComboBoxEdit1.Properties.Buttons[0].AppearancePressed.BorderColor = buttonColor2;
            this.hImageComboBoxEdit1.Properties.Buttons[0].AppearanceHovered.BackColor = backColor;
            this.hImageComboBoxEdit1.Properties.Buttons[0].AppearanceHovered.BorderColor = buttonColor2;
            this.hImageComboBoxEdit1.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.hImageComboBoxEdit1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.hImageComboBoxEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            //this.hImageComboBoxEdit1.LookAndFeel.SetSkinStyle(SkinSvgPalette.DefaultSkin.BlueDark);



        }

        Color backColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
        Color textColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
        Color buttonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(184)))), ((int)(((byte)(186)))));
        Color buttonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));



        private void InitCombobox()
        {


            //스타일적용 시작


        }

        private void InitTextEdit()
        {

            this.hTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.hTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.hTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hTextEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.hTextEdit1.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.hTextEdit1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;

        }

        Color borderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
        Color cellColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
        Color focusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(234)))), ((int)(((byte)(253)))));

        private void InitDataGrid()
        {
            DataTable dt = new DataTable();
            dt.Rows.Add(dt.NewRow());
            dt.Rows.Add(dt.NewRow());
            dt.Rows.Add(dt.NewRow());

            hGridControl1.DataSource = dt;

            //hGridControl2.DataSource = dt;

            //new hotTrackHelper(hGridView1);


            //스타일 시작

            //this.hGridControl1.LookAndFeel.Style = LookAndFeelStyle.Flat;
            //this.hGridControl1.LookAndFeel.UseDefaultLookAndFeel = false;

            hGridControl1.LookAndFeel.UseDefaultLookAndFeel = true;
            Skin skin = GridSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel);
            SkinElement elem = skin[GridSkins.SkinBorder];
            elem.Border.All = borderColor;






            //비어있는 공간
            this.hGridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.hGridView1.Appearance.Empty.Options.UseBackColor = true;

            //라인
            this.hGridView1.Appearance.HorzLine.BackColor = borderColor;
            this.hGridView1.Appearance.VertLine.BackColor = borderColor;

            //해더
            this.hGridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.hGridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.hGridView1.Appearance.HeaderPanel.BorderColor = borderColor;
            this.hGridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.hGridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.hGridView1.Appearance.HeaderPanel.Options.UseForeColor = true;

            this.hGridView1.Appearance.HideSelectionRow.BackColor = Color.Red;
            this.hGridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            //this.hGridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;

            //포커스된 영역에 대한 처리
            this.hGridView1.Appearance.SelectedRow.BackColor = buttonColor2;
            this.hGridView1.Appearance.FocusedRow.BackColor = buttonColor2;
            this.hGridView1.Appearance.FocusedCell.BackColor = buttonColor2;
            this.hGridView1.Appearance.HideSelectionRow.BackColor = buttonColor2;

            //로우 컬러 처리
            this.hGridView1.Appearance.Row.BackColor = cellColor;



            //this.hGridControl1.LookAndFeel.Style = LookAndFeelStyle.Flat;
            //this.hGridControl1.LookAndFeel.UseDefaultLookAndFeel = false;



            this.hGridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;

            //this.hGridControl1.Update();
        }

        private void hGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //e.Appearance.BackColor = cellColor;


            //if (hGridView1.IsRowSelected(e.RowHandle))
            //{
            //    Brush b = new SolidBrush(Color.FromArgb(255, 226, 234, 253));
            //    e.Graphics.FillRectangle(b, e.Bounds.Left, e.Bounds.Top, e.Bounds.Right, e.Bounds.Bottom);
            //}
        }

        private void hGridView1_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null)
            {
                e.Info.AllowColoring = true;
            }
            else if (e.Column.FieldName == "DX$CheckboxSelectorColumn")
            {

                //using (Pen pen = new Pen(borderColor, 1))
                //{
                //    Rectangle rec = e.Bounds;
                //    rec.X = rec.X - 1;
                //    rec.Y = rec.Y - 1;
                //    e.Graphics.DrawRectangle(pen, rec);
                //}

                //  e.Appearance.BackColor = Color.Red;


                //Brush b = new SolidBrush(Color.Red);
                //e.Graphics.FillRectangle(b, e.Bounds.Left, e.Bounds.Top, e.Bounds.Right, e.Bounds.Bottom);
                //e.Painter.DrawObject(e.Info.InnerElements);
                //e.Info.Appearance.BackColor = Color.Blue;
                //e.Info.Appearance.Options.UseBackColor = true;
                //e.Info.BackAppearance.BackColor = Color.Blue;
                //e.Info.BackAppearance.Options.UseBackColor = true;

                //e.DefaultDraw();



                e.Handled = true;



                //e.Info.Bounds
                //e.Info.BackAppearance.BackColor = Color.Red;
                //ColumnCheckboxSelectorInfoArgs columnCheckboxSelectorInfoArgs = e.Info.InnerElements[0].ElementInfo as ColumnCheckboxSelectorInfoArgs;
                //columnCheckboxSelectorInfoArgs.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
                ////columnCheckboxSelectorInfoArgs.ImageOptions.ImageChecked = imageCollection1.Images[2];
                ////columnCheckboxSelectorInfoArgs.ImageOptions.ImageUnchecked = imageCollection1.Images[1];
                ////columnCheckboxSelectorInfoArgs.ImageOptions.ImageGrayed = imageCollection1.Images[0];

                //columnCheckboxSelectorInfoArgs.BackAppearance.BackColor = Color.Red;
            }
            else
            {
                e.DefaultDraw();

                using (Pen pen = new Pen(borderColor, 1))
                {
                    Rectangle rec = e.Bounds;
                    rec.X = rec.X - 1;
                    rec.Y = rec.Y - 1;
                    e.Graphics.DrawRectangle(pen, rec);
                }

                e.Handled = true;
            }
        }

        private void SetSkinElement()
        {

            //DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            //defaultLookAndFeel1.LookAndFeel.SkinName = "My Basic";



            //var skin = CommonSkins.GetSkin(defaultLookAndFeel1.LookAndFeel);
            //var element = skin[CommonSkins.SkinTextBorder];
            //element.Info.Image = new SkinImage(TestProject.Properties.Resources.round, new SkinPaddingEdges(3), Color.Black);
            //element.Info.ContentMargins = new SkinPaddingEdges(3);
            //LookAndFeelHelper.ForceDefaultLookAndFeelChanged();

            //path.AddEllipse(0, 0, this.hTextEdit1.Width, this.hTextEdit1.Height);
            //hTextEdit1.Region = new Region(path);
            //hTextEdit1.BackColor = SystemColors.ControlDarkDark;

            //hTextEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            //hTextEdit1.Paint += HTextEdit1_Paint;
        }

        GraphicsPath path = new GraphicsPath();
        private void HTextEdit1_Paint(object sender, PaintEventArgs e)
        {



            //path.Reset();

            //if (hTextEdit1.Region != null)
            //{
            //    hTextEdit1.Region.Dispose();
            //    hTextEdit1.Region = null;
            //}

            //path.AddEllipse(0, 0, this.hTextEdit1.Width, this.hTextEdit1.Height);
            //this.Region = new Region(path);
        }

        private void hTextEdit1_Paint_1(object sender, PaintEventArgs e)
        {

            //Color color = System.Drawing.Color.FromArgb(64, 73, 91);
            Color color = borderColor;
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, color, 1, ButtonBorderStyle.Solid
                                                           , color, 1, ButtonBorderStyle.Solid
                                                           , color, 1, ButtonBorderStyle.Solid
                                                           , color, 1, ButtonBorderStyle.Solid);

        }

        private void hTextEdit2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hSimpleButton7_Click(object sender, EventArgs e)
        {
            Form3 fomr3 = new Form3();
            fomr3.ShowDialog();
        }

        List<string> testList = new List<string>();
        //FileTransfer ft = new FileTransfer("10.10.221.71", "1111");
        FileTransfer ft = new FileTransfer();
        private void hSimpleButton8_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    testMethod();
            //}

            CallService call = new CallService("10.10.221.72", "8180");
            //CallService call = new CallService();
            KeyValueData value = new KeyValueData();
            value["Data1"] = "1";
            call.SelectSql("reqGetDRSPathWorkers", value);

        }

        private async void testMethod()
        {
            string result = await Task.Run<string>(() =>
            {
                string path = "imagedata\\20191230\\S1926379\\20191230113953.JPG";
                //string path = "Imagedata\\20200521\\M0000001\\test111.jpg";
                string value = ft.ImageThumbnail(path);
                testList.Add(value);
                return value;
            });
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            //Process compiler = new Process();
            //compiler.StartInfo.FileName = "C:\\BASE\\SedasSolutions\\FileSendBatch\\bin\\Release\\FileSendBatch.exe";
            ////string arg = string.Format("\"{0}\" {1} {2} {3} {4} {5} {6}", filePath, strImagePath, strPathologyNum, imageType, ptNo, ptNm, imageNum);
            ////compiler.StartInfo.Arguments = arg;
            ////compiler.StartInfo.Arguments = "\"" + jsonValue + "\"" ;
            //compiler.StartInfo.UseShellExecute = false;
            //compiler.StartInfo.RedirectStandardOutput = true;
            //compiler.Start();
            ////Console.WriteLine(compiler.StandardOutput.ReadToEnd());
        }

        private void hGridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Handled = true;
            SolidBrush brush = new SolidBrush(Color.FromArgb(0xC6, 0x64, 0xFF));
            e.Graphics.FillRectangle(brush, e.Bounds);
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height));
            Size size = ImageCollection.GetImageListSize(e.Info.ImageCollection);
            Rectangle r = e.Bounds;
            ImageCollection.DrawImageListImage(e.Cache, e.Info.ImageCollection, e.Info.ImageIndex,
                    new Rectangle(r.X + (r.Width - size.Width) / 2, r.Y + (r.Height - size.Height) / 2, size.Width, size.Height));
            brush.Dispose();
        }

        private void hSimpleButton9_Click(object sender, EventArgs e)
        {
            WMI wmi = new WMI();
            wmi.ShowDialog();
        }

        private void hSedasSImpleButtonBlue1_Click(object sender, EventArgs e)
        {

        }

        private void hSimpleButton10_Click(object sender, EventArgs e)
        {
            LogViewer logViewer = new LogViewer();
            logViewer.ShowDialog();
        }

        private void hSimpleButton11_Click(object sender, EventArgs e)
        {
            WatcherTest watcher = new WatcherTest();
            watcher.ShowDialog();
        }

        private void hSimpleButton12_Click(object sender, EventArgs e)
        {
            SmsPopup smsPopup = new SmsPopup();
            smsPopup.ShowDialog();
        }

        private void hSimpleButton13_Click(object sender, EventArgs e)
        {
            SmsPopupForTotal smsPopupForTotal = new SmsPopupForTotal();
            smsPopupForTotal.ShowDialog();
        }

        private void hSimpleButton14_Click(object sender, EventArgs e)
        {
            UserSearchPopup userSearchPopup = new UserSearchPopup();
            userSearchPopup.ShowDialog();
        }

        private void hSimpleButton15_Click(object sender, EventArgs e)
        {
            //var process = new Process();

            //var startInfo = new ProcessStartInfo
            //{
            //    CreateNoWindow = true,
            //    FileName = "cmd.exe",
            //    Arguments = "/c \"\"" + batchFile + "\"\"",
            //    WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory,
            //    UseShellExecute = false,
            //    RedirectStandardError = true,
            //    RedirectStandardOutput = true
            //};

            //process.StartInfo = startInfo;
            //process.Start();
            //process.WaitForExit(30000);
        }

        private void hSimpleButton16_Click(object sender, EventArgs e)
        {
            EmailPopup emailPopup = new EmailPopup();
            emailPopup.ShowDialog();
        }

        private void hSimpleButton17_Click(object sender, EventArgs e)
        {
            //DevExpress.XtraEditors.XtraMessageBox.Show("test메시지", "확인");
            DevExpress.XtraEditors.XtraMessageBox.Show("연결할 IP주소를 입력하세요.", "IP주소 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void hSimpleButton18_Click(object sender, EventArgs e)
        {

            string linkPath = @"C:\SEDAS\DGS_Viewer\DGS_Viewer.exe";
            string path = @"C:\SEDAS\KuhLogin\kuhlogin.exe";

            using (Process compiler = new Process())
            {
                FileInfo file = new FileInfo(path);

                compiler.StartInfo.FileName = path;
                string arg = string.Format("\"{0}\"", linkPath);
                compiler.StartInfo.Arguments = arg;
                compiler.StartInfo.UseShellExecute = false;
                compiler.StartInfo.RedirectStandardOutput = true;
                compiler.StartInfo.WorkingDirectory = file.DirectoryName;
                compiler.Start();

                Console.WriteLine(compiler.StandardOutput.ReadToEnd());
            }


            //MainTest mainTest = new MainTest();
            //mainTest.ShowDialog();
        }

        private void hSimpleButton19_Click(object sender, EventArgs e)
        {
            tttForm test = new tttForm();
            test.ShowDialog();
        }
    }

    public class MyXmlLayout : XmlLayoutBase
    {
        protected override void FormatXml(XmlWriter writer, LoggingEvent loggingEvent)
        {
            if (loggingEvent.MessageObject is log4net.Util.SystemStringFormat)
            {
                log4net.Util.SystemStringFormat message = loggingEvent.MessageObject as log4net.Util.SystemStringFormat;
            }

            writer.WriteStartElement("LogEntry");

            writer.WriteString(loggingEvent.RenderedMessage);

            writer.WriteEndElement();
            writer.WriteString(Environment.NewLine);

            writer.WriteStartElement("Message");
            writer.WriteString(loggingEvent.RenderedMessage);
            writer.WriteEndElement();
        }
    }
}
