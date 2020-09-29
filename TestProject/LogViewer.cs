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

namespace TestProject
{
    public partial class LogViewer : DevExpress.XtraEditors.XtraForm
    {
        public LogViewer()
        {
            InitializeComponent();
        }

        private void hSimpleButton1_Click(object sender, EventArgs e)
        {
            string path = @"C:\BASE\SedasSolutions\TestProject\bin\Debug\logs";
            string logCode = "LOGTE";

            DataTable dt = new DataTable();

            //LogHelper logHelper = new LogHelper();
            LogDTO logDTO = new LogDTO();
            PropertyInfo[] targetProperties = typeof(LogDTO).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            //프로퍼티의 내용을 모두 차례대로 찍는다.
            foreach (PropertyInfo targetProperty in targetProperties)
            {
                if (targetProperty.CanWrite && targetProperty.GetSetMethod() != null)
                {
                    dt.Columns.Add(targetProperty.Name, typeof(string));
                }
            }


            DirectoryInfo di = new DirectoryInfo(path);
            if (di.Exists == false) return;

            FileInfo[] files = di.GetFiles();
            if (files != null && files.Count() > 0)
            {
                foreach (FileInfo file in files)
                {
                    bool isFind = false;
                    if (file.Name.Substring(0, 5) == "LOGTE")
                    {
                        isFind = true;
                    }

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
                        catch(Exception ex)
                        {

                        }
                        

                        dt.Rows.Add(row);
                        //DataRow row = dt.NewRow();
                    }
                }
            }


        }

    }
}