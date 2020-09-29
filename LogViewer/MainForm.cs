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
using System.IO;
using Sedas.Core;
using System.Reflection;
using System.Xml;

namespace LogViewer
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void InitGlobal()
        {
            string iniPath = Global.strSettingPath;
            FileInfo file = new FileInfo(iniPath);
            if (file.Exists == false)
            {
                DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory + "\\Setting");
                if (di.Exists == false)
                {
                    di.Create();
                }

                file.Create();

                //INI 파일 초기값 설정
                Global.G_IniWriteValue("LOG", "PATH", @"L:\", Global.strSettingPath);
               
            }
            //Global.G_IniWriteValue("LOG", "PATH", @"L:\", Global.strSettingPath);
            this.txtRoot.Text = Global.G_IniReadValue("LOG", "PATH", Global.strSettingPath);

        }

        private void hSimpleButton1_Click(object sender, EventArgs e)
        {
            this.grdOrder.DataSource = null;
            this.grvOrder.Columns.Clear();

            //string path = this.txtRoot.Text;
            string path = @"D:\ServerData\log\";

            if (string.IsNullOrEmpty(path)) return;

            //string logCode = "LOGTE";

            DataTable dt = new DataTable();

            //LogHelper logHelper = new LogHelper();
            LogDTO logDTO = new LogDTO();
            PropertyInfo[] targetProperties = typeof(LogDTO).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            string[] firstColumns = { "sysdate", "systime", "microTime", "logCode", "ptoNo", "ptno"};

            //우선순위에 둘 컬럼 먼저 추가
            for (int i = 0; i < firstColumns.Length; i++)
            {
                dt.Columns.Add(firstColumns.ElementAt(i), typeof(string));
            }


            //프로퍼티의 내용을 모두 차례대로 찍는다.
            foreach (PropertyInfo targetProperty in targetProperties)
            {
                if (targetProperty.CanWrite && targetProperty.GetSetMethod() != null)
                {
                    if ( dt.Columns.Contains(targetProperty.Name) == false)
                    {
                        dt.Columns.Add(targetProperty.Name, typeof(string));
                    }
                }
            }

            //dt.Columns.Add("microTime", typeof(string)); //마이크로초 추가

            //검색
            string f_code = txtCode.Text;
            string f_ptoNo = txtPtoNo.Text;
            string f_ptNo = txtPtno.Text;
            string f_date = dtpDate.DateTime.ToString("yyyyMMdd");
            string f_time_start = txtStTm.Text;
            string f_time_End = txtEndTm.Text;

            if (string.IsNullOrEmpty(f_date))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("날짜를 입력해 주세요");
                return;
            }
            path = path + f_date.Substring(0, 4) + "\\" + f_date.Substring(4, 2) + "\\" + f_date.Substring(6, 2);

            DirectoryInfo di = new DirectoryInfo(path);
            if (di.Exists == false)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("해당일자에 로그정보가 존재하지 않습니다.");
                return;
            }

            FileInfo[] files = di.GetFiles();
            if (files != null && files.Count() > 0)
            {
                foreach (FileInfo file in files)
                {
                    bool isFind = true;
                    string microTime = "";
                    string[] splitName = file.Name.Split('$');

                    if (splitName != null && splitName.Count() > 5)
                    {
                        string code = splitName.ElementAt(3);
                        string ptoNo = splitName.ElementAt(4);
                        string ptNo = splitName.ElementAt(5);

                        string date = splitName.ElementAt(0);
                        string time = splitName.ElementAt(1);
                        microTime = splitName.ElementAt(2);

                        //로그코드
                        if (!string.IsNullOrEmpty(f_code))
                        {
                            if (f_code != code)
                            {
                                isFind = false;
                            }
                        }

                        if (!string.IsNullOrEmpty(f_ptoNo))
                        {
                            if (f_ptoNo != ptoNo)
                            {
                                isFind = false;
                            }
                        }

                        if (!string.IsNullOrEmpty(f_ptNo))
                        {
                            if (f_ptNo != ptNo)
                            {
                                isFind = false;
                            }
                        }

                        if (!string.IsNullOrEmpty(f_time_start))
                        {
                            try
                            {
                                if (time.ToDouble() < f_time_start.ToDouble())
                                {
                                    isFind = false;
                                }
                            }
                            catch
                            { 
                                
                            }
                            
                        }

                        if (!string.IsNullOrEmpty(f_time_End))
                        {
                            try
                            {
                                if (time.ToDouble() > f_time_End.ToDouble())
                                {
                                    isFind = false;
                                }
                            }
                            catch
                            {

                            }
                        }
                    }


                    //if (file.Name.Substring(0, 5) == "LOGTE")
                    //{
                    //    isFind = true;
                    //}

                    string columnName = "";
                    if (isFind == true)
                    {
                        DataRow row = dt.NewRow();
                        XmlTextReader reader = new XmlTextReader(file.FullName);
                        try
                        {
                            while (reader.Read())
                            {
                                switch (reader.NodeType)
                                {
                                    case XmlNodeType.Element: // The node is an element.
                                                              //Console.Write("<" + reader.Name);
                                                              //Console.WriteLine(">");
                                        columnName = reader.Name;
                                        break;
                                    case XmlNodeType.Text: //Display the text in each element.
                                                           //Console.WriteLine(reader.Value);
                                        if (!string.IsNullOrEmpty(columnName))
                                        {
                                            if (dt.Columns.Contains(columnName))
                                            {
                                                row[columnName] = reader.Value;
                                            }
                                        }
                                        break;
                                    case XmlNodeType.EndElement: //Display the end of the element.
                                                                 //Console.Write("</" + reader.Name);
                                                                 //Console.WriteLine(">");
                                        columnName = "";
                                        break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }


                        row["microTime"] = microTime;


                        dt.Rows.Add(row);
                        //DataRow row = dt.NewRow();
                    }
                }
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                InitGridControl(dt);
            }
        }


        /// <summary>
        /// name         : InitGridControl
        /// desc         : 그리드컨트롤 초기값 설정
        /// author       : 심우종
        /// create date  : 2020-03-30 15:48
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitGridControl(DataTable dt)
        {
            this.grvOrder.Columns.Clear();
            //this.grvOrder.Columns

            if (dt != null && dt.Columns.Count > 0)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    DataColumn column = dt.Columns[i];

                    Sedas.Control.GridControl.HGridColumn gridColumn = new Sedas.Control.GridControl.HGridColumn();
                    gridColumn.AppearanceCell.Options.UseTextOptions = true;
                    gridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridColumn.AppearanceHeader.Options.UseTextOptions = true;
                    gridColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridColumn.Caption = column.ColumnName;
                    gridColumn.FieldName = column.ColumnName;
                    gridColumn.Name = "grdColumn" + (i + 1).ToString();
                    //gridColumn.OptionsColumn.AllowEdit = false;
                    gridColumn.Visible = true;
                    gridColumn.VisibleIndex = i;
                    gridColumn.Width = 64;
                    gridColumn.OptionsColumn.FixedWidth = true;
                    gridColumn.MinWidth = 0;
                    gridColumn.OptionsColumn.ReadOnly = true;
                    gridColumn.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
                    gridColumn.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
                    gridColumn.AppearanceHeader.Options.UseBackColor = true;
                    gridColumn.AppearanceHeader.Options.UseForeColor = true;

                    int width = 100;
                    //if (g_ListData.strarrayListLength[i].ToIntOrNull() != null)
                    //{
                    //    width = g_ListData.strarrayListLength[i].ToInt();
                    //}

                    gridColumn.Width = width;



                    grvOrder.Columns.Add(gridColumn);


                }
            }

            

            grdOrder.Dock = DockStyle.None;
            grdOrder.Dock = DockStyle.Fill;

            this.grdOrder.DataSource = dt;
            this.grvOrder.OptionsView.ColumnAutoWidth = false;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.InitGlobal();
            this.InitControl();
        }

        private void InitControl()
        {
            this.dtpDate.DateTime = DateTime.Now;
        }
    }
}