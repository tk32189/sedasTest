using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sedas.Core;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Integration_Viewer
{
    public partial class SimpleFileList : DevExpress.XtraEditors.XtraUserControl
    {
        public event Action onFileChecked; //체크박스 체크 변경시


        CoreLibrary core = new CoreLibrary();

        public SimpleFileList()
        {
            InitializeComponent();
        }

        DataTable dt;


        /// <summary>
        /// name         : GetDataTable
        /// desc         : 현재 바인딩된 데이터테이블을 리턴한다.
        /// author       : 심우종
        /// create date  : 2020-07-15 17:13
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public DataTable GetDataTable()
        {
            return this.dt;
        }


        /// <summary>
        /// name         : SimpleFileList_Load
        /// desc         : 화면로드시
        /// author       : 심우종
        /// create date  : 2020-07-15 14:42
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SimpleFileList_Load(object sender, EventArgs e)
        {
            if (dt == null)
            {
                dt = Global.InitFileDataTable();
                this.grdFileList.DataSource = dt;
            }
        }



        /// <summary>
        /// name         : InitDataTable
        /// desc         : 테이블 구조 생성
        /// author       : 심우종
        /// create date  : 2020-07-15 14:45
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private DataTable InitDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("rootPath", typeof(string));
            dt.Columns.Add("filePath", typeof(string));
            dt.Columns.Add("sendStat", typeof(string));
            dt.Columns.Add("serialNo", typeof(string));
            dt.Columns.Add("studyId", typeof(string));
            dt.Columns.Add("type", typeof(string));
            dt.Columns.Add("seq", typeof(string));

            dt.Columns.Add("fileName", typeof(string));
            dt.Columns.Add("isChecked", typeof(string));

            return dt;
    }


        private string title = "";

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
                lblName.Text = value;
            }
        }



        /// <summary>
        /// name         : Clear
        /// desc         : 데이터를 clear한다.
        /// author       : 심우종
        /// create date  : 2020-07-15 14:53
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void DataClear()
        {
            if (this.dt == null) return;
            this.dt.Clear();
        }

        /// <summary>
        /// name         : AddFiles
        /// desc         : 파일을 추가한다.
        /// author       : 심우종
        /// create date  : 2020-07-15 14:42
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void AddFiles(List<DataRow> files)
        {
            if (this.dt == null) return;

            if (files == null || files.Count == 0) return;

            for (int i = 0; i < files.Count; i++)
            {
                DataRow row = files[i];
                DataRow newRow = this.dt.NewRow();

                core.TableCopy(row, ref newRow);

                string filePath = newRow["filePath"].ToString();

                string lastValue = filePath.Split('\\').LastOrDefault();
                if (!string.IsNullOrEmpty(lastValue))
                {
                    newRow["fileName"] = lastValue;
                }

                newRow["isChecked"] = "N";

                this.dt.Rows.Add(newRow);
            }
        }

        private void grdFileList_MouseUp(object sender, MouseEventArgs e)
        {
            GridHitInfo hitInfo = grvFileList.CalcHitInfo(e.Location);

            if (hitInfo.InColumn)
            {
                if (hitInfo.Column.FieldName == "isChecked")
                {
                    if (this.dt.AsEnumerable().Where(o => o["isChecked"].ToString() == "Y").Count() == this.dt.Rows.Count)
                    {
                        //전체 체크되어있으면..체크해제
                        this.dt.AsEnumerable().ToList().ForEach(item => {
                            item["isChecked"] = "N";
                        });
                    }
                    else
                    {
                        //전체체크
                        this.dt.AsEnumerable().ToList().ForEach(item => {
                            item["isChecked"] = "Y";
                        });
                    }

                    if (this.onFileChecked != null)
                    {
                        this.onFileChecked();
                    }
                }
            }
        }


        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            this.grvFileList.PostEditor();
            this.grvFileList.UpdateCurrentRow();

            if (this.onFileChecked != null)
            {
                this.onFileChecked();
            }
        }
    }
}
