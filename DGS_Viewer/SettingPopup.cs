using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab.Registrator;
using Sedas.Control;
using Sedas.Core;

namespace DGS_Viewer
{



    public partial class SettingPopup : DevExpress.XtraEditors.XtraForm
    {


        /// <summary>
        /// name         : 
        /// desc         : 
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public SettingPopup()
        {

            //var exists = File.Exists("C:\\Temp\\Notes.txt");



            InitializeComponent();



        }


        /// <summary>
        /// name         : SettingPopup_Load
        /// desc         : 화면 로드시
        /// author       : 심우종
        /// create date  : 2020-03-26 17:27
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SettingPopup_Load(object sender, EventArgs e)
        {
            this.InitControl();
            this.InitData();
        }


        /// <summary>
        /// name         : InitControl
        /// desc         : 컨트롤 초기화
        /// author       : 심우종
        /// create date  : 2020-08-04 10:10
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitControl()
        {
            PaintStyleCollection.DefaultPaintStyles.Add(new SedasTabControlSkinViewInfoRegistrator());
            xtraTabControl1.PaintStyleName = "Sedas";
        }


        /// <summary>
        /// name         : InitData
        /// desc         : 데이터 초기화
        /// author       : 심우종
        /// create date  : 2020-03-26 17:28
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitData()
        {
            //[DB설정]
            this.txtDgsdsn.Text = g_DBconnectData.strDGSDsn;
            this.txtDgsUser.Text = g_DBconnectData.strDGSUser;
            this.txtDgsPasswd.Text = g_DBconnectData.strDGSPasswd;
            this.txtOcsDsn.Text = g_DBconnectData.strOCSDsn;
            this.txtOcsUser.Text = g_DBconnectData.strOCSUser;
            this.txtOcsPasswd.Text = g_DBconnectData.strOCSPasswd;

            this.chkOcsYn.Checked = g_DBconnectData.bOCS; //OCSDB 접속 사용
            this.OcsDbEnableCheck(); //OCSDB 영역의 컨트롤 활성화 여부 체크

            //[리스트 환경설정]
            this.txtListCount.Text = g_ListData.strCount;

            if (g_ListData.strCount.ToIntOrNull() != null)
            {
                for (int i = 0; i < g_ListData.strCount.ToInt(); i++)
                {
                    this.listGridName.Items.Add(g_ListData.strarrayListName[i].ToString());

                    this.listGridLength.Items.Add(g_ListData.strarrayListLength[i].ToString());
                }
            }

            listGridName.SelectedIndex = this.listGridName.Items.Count - 1;
            listGridLength.SelectedIndex = this.listGridLength.Items.Count - 1;

            //FieldInfo fi = typeof(BaseListBoxControl).GetField("handler", BindingFlags.NonPublic | BindingFlags.Instance);
            //ListBoxControlHandler handler = fi.GetValue(listGridName) as ListBoxControlHandler;
            //handler.OnKeyDown(new KeyEventArgs(Keys.PageDown));


            //[디렉토리설정]
            this.txtImageSavePath.Text = g_PathData.strImagePath;
            this.txtProgramSavePath.Text = g_PathData.strPhotoshopPath;

            //[기타설정]
            if (g_OthersSetupData.nUIMode == 0)
            {
                this.rdoUiModeLeft.Checked = true;
            }
            else if (g_OthersSetupData.nUIMode == 1)
            {
                this.rdoUiModeRight.Checked = true;
            }
            else if (g_OthersSetupData.nUIMode == 2)
            {
                this.rdoUiModeTop.Checked = true;
            }
            else if (g_OthersSetupData.nUIMode == 3)
            {
                this.rdoUiModeBottom.Checked = true;
            }

            if (g_OthersSetupData.nCipher == 0)
            {
                this.rdoCipher1.Checked = true;
            }
            else if (g_OthersSetupData.nCipher == 1)
            {
                this.rdoCipher2.Checked = true;
            }

            this.chkHypen.Checked = g_OthersSetupData.bAddHypen;

            if (g_OthersSetupData.nImageSize == 0)
            {
                this.rdoImageSizeBig.Checked = true;
            }
            else if (g_OthersSetupData.nImageSize == 1)
            {
                this.rdoImageSizeSmall.Checked = true;
            }

            //Sort
            if (g_OthersSetupData.sortOption == "studyDt" || string.IsNullOrEmpty(g_OthersSetupData.sortOption))
            {
                this.rdoSortStudyDt.Checked = true;
            }
            else if (g_OthersSetupData.sortOption == "insertDt")
            {
                this.rdoSortInsertDt.Checked = true;
            }
            else if (g_OthersSetupData.sortOption == "lastDt")
            {
                this.rdoSortLastDt.Checked = true;
            }


            //조회기간
            if (g_OthersSetupData.nPeriod == 0)
            {
                this.rdoPeriodToday.Checked = true;
            }
            else
            {
                this.rdoPeriodOther.Checked = true;
                this.txtPeriod.Text = g_OthersSetupData.nPeriod.ToString();
            }

            //검색기간 마지막수정일자로..
            if ( g_OthersSetupData.periodType == "last")
            {
                this.chkLastUpDt.Checked = true;
            }

            //매핑이미지만 조회
            if (g_OthersSetupData.onlyMapping == "Y")
            {
                this.chkOnlyMapping.Checked = true;
            }




            if (g_ComboData.strCharCount.ToIntOrNull() != null)
            {
                int charCount = g_ComboData.strCharCount.ToInt();
                for (int i = 0; i < charCount; i++)
                {
                    this.listChar.Items.Add(g_ComboData.strarrayChar[i].ToString());
                }
            }
            if (g_ComboData.strWeekCount.ToIntOrNull() != null)
            {
                int weekCount = g_ComboData.strWeekCount.ToInt();
                for (int i = 0; i < weekCount; i++)
                {
                    this.listWeek.Items.Add(g_ComboData.strarrayWeek[i].ToString());
                }
            }

            listChar.SelectedIndex = this.listChar.Items.Count - 1;
            listWeek.SelectedIndex = this.listWeek.Items.Count - 1;




        }




        /// <summary>
        /// name         : chkOcsYn_CheckedChanged
        /// desc         : OCSDB 접속 사용 체크박스 체크변경시
        /// author       : 심우종
        /// create date  : 2020-03-27 09:53
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void chkOcsYn_CheckedChanged(object sender, EventArgs e)
        {
            this.OcsDbEnableCheck();
        }


        /// <summary>
        /// name         : OcsDbEnableCheck
        /// desc         : OCSDB 영역의 컨트롤 활성화 여부 체크
        /// author       : 심우종
        /// create date  : 2020-03-27 09:52
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void OcsDbEnableCheck()
        {
            if (chkOcsYn.Checked == true)
            {
                txtOcsDsn.ReadOnly = false;
                txtOcsUser.ReadOnly = false;
                txtOcsPasswd.ReadOnly = false;
            }
            else
            {
                txtOcsDsn.ReadOnly = true;
                txtOcsUser.ReadOnly = true;
                txtOcsPasswd.ReadOnly = true;
            }
        }


        /// <summary>
        /// name         : btnGridNameAdd_Click
        /// desc         : 리스트이름 영역 추가 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-27 09:59
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnGridNameAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGridName.Text.ToString()))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("이름을 입력하세요", "확인");
                return;
            }

            this.listGridName.Items.Add(txtGridName.Text.ToString());
            this.listGridName.SelectedIndex = this.listGridName.Items.Count - 1;
        }


        /// <summary>
        /// name         : btnGridNameDelete_Click
        /// desc         : 리스트이름 영역 삭제 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-27 09:59
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnGridNameDelete_Click(object sender, EventArgs e)
        {
            if (this.listGridName.SelectedIndex >= 0)
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("정말로 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.listGridName.Items.RemoveAt(this.listGridName.SelectedIndex);
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("삭제할 아이템을 선택해 주세요", "확인");
                return;
            }
        }


        /// <summary>
        /// name         : btnGridLengthAdd_Click
        /// desc         : 리스트길이 영역 추가 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-27 09:59
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnGridLengthAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGridLength.Text.ToString()))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("길이를 입력하세요", "확인");
                return;
            }

            this.listGridLength.Items.Add(txtGridLength.Text.ToString());
            this.listGridLength.SelectedIndex = this.listGridLength.Items.Count - 1;
        }


        /// <summary>
        /// name         : btnGridLengthDelete_Click
        /// desc         : 리스트길이 영역 삭제 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-27 09:59
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnGridLengthDelete_Click(object sender, EventArgs e)
        {
            if (this.listGridLength.SelectedIndex >= 0)
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("정말로 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.listGridLength.Items.RemoveAt(this.listGridLength.SelectedIndex);
                }

            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("삭제할 아이템을 선택해 주세요", "확인");
                return;
            }
        }


        /// <summary>
        /// name         : btnComboCharAdd_Click
        /// desc         : Char콤보영역 추가 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-30 09:18
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnComboCharAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtComboChar.Text.ToString()))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("문자를 적어 주십시오", "확인");
                return;
            }

            this.listChar.Items.Add(txtComboChar.Text.ToString());
            this.listChar.SelectedIndex = this.listChar.Items.Count - 1;
        }


        /// <summary>
        /// name         : btnComboCharEdit_Click
        /// desc         : Char콤보영역 수정 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-30 09:19
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnComboCharEdit_Click(object sender, EventArgs e)
        {
            if (this.listChar.SelectedIndex < 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("수정할 아이템을 선택해 주세요", "확인");
                return;
            }

            if (string.IsNullOrEmpty(this.txtComboChar.Text.ToString()))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("수정할 내용을 입력해 주세요", "확인");
                return;
            }


            if (this.listChar.SelectedIndex >= 0)
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("정말로 수정하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.listChar.Items[this.listChar.SelectedIndex] = this.txtComboChar.Text;
                }

            }
        }


        /// <summary>
        /// name         : btnComboCharDelete_Click
        /// desc         : Char콤보영역 삭제 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-30 09:19
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnComboCharDelete_Click(object sender, EventArgs e)
        {
            if (this.listChar.SelectedIndex >= 0)
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("정말로 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.listChar.Items.RemoveAt(this.listChar.SelectedIndex);
                }

            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("삭제할 아이템을 선택해 주세요", "확인");
                return;
            }
        }


        /// <summary>
        /// name         : btnComboWeekAdd_Click
        /// desc         : Week콤보영역 추가 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-30 09:19
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnComboWeekAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtComboWeek.Text.ToString()))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("문자를 적어 주십시오", "확인");
                return;
            }

            this.listWeek.Items.Add(this.txtComboWeek.Text.ToString());
            this.listWeek.SelectedIndex = this.listWeek.Items.Count - 1;
        }


        /// <summary>
        /// name         : btnComboWeekEdit_Click
        /// desc         : Week콤보영역 수정 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-30 09:19
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnComboWeekEdit_Click(object sender, EventArgs e)
        {
            if (this.listWeek.SelectedIndex < 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("수정할 아이템을 선택해 주세요", "확인");
                return;
            }

            if (string.IsNullOrEmpty(this.txtComboWeek.Text.ToString()))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("수정할 내용을 입력해 주세요", "확인");
                return;
            }


            if (this.listWeek.SelectedIndex >= 0)
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("정말로 수정하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.listWeek.Items[this.listWeek.SelectedIndex] = this.txtComboWeek.Text;
                }

            }
        }


        /// <summary>
        /// name         : btnComboWeekDelete_Click
        /// desc         : Week콤보영역 삭제 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-30 09:19
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnComboWeekDelete_Click(object sender, EventArgs e)
        {
            if (this.listWeek.SelectedIndex >= 0)
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("정말로 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.listWeek.Items.RemoveAt(this.listWeek.SelectedIndex);
                }

            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("삭제할 아이템을 선택해 주세요", "확인");
                return;
            }
        }


        /// <summary>
        /// name         : btnConfirm_Click
        /// desc         : 확인버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-30 14:00
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //[DB설정]
            g_DBconnectData.bOCS = chkOcsYn.Checked;
            g_DBconnectData.strDGSDsn = txtDgsdsn.Text;
            g_DBconnectData.strDGSUser = txtDgsUser.Text;
            g_DBconnectData.strDGSPasswd = txtDgsPasswd.Text;
            g_DBconnectData.strOCSDsn = txtOcsDsn.Text;
            g_DBconnectData.strOCSUser = txtOcsUser.Text;
            g_DBconnectData.strOCSPasswd = txtOcsPasswd.Text;

            Global.G_IniWriteValue("DB", "OCS", g_DBconnectData.bOCS == true ? "1" : "0", g_PathData.strIniPath);
            Global.G_IniWriteValue("DB", "DGSDSN", g_DBconnectData.strDGSDsn, g_PathData.strIniPath);
            Global.G_IniWriteValue("DB", "DGSUSER", g_DBconnectData.strDGSUser, g_PathData.strIniPath);
            Global.G_IniWriteValue("DB", "DGSPASSWD", g_DBconnectData.strDGSPasswd, g_PathData.strIniPath);
            Global.G_IniWriteValue("DB", "OCSDSN", g_DBconnectData.strOCSDsn, g_PathData.strIniPath);
            Global.G_IniWriteValue("DB", "OCSUSER", g_DBconnectData.strOCSUser, g_PathData.strIniPath);
            Global.G_IniWriteValue("DB", "OCSPASSWD", g_DBconnectData.strOCSPasswd, g_PathData.strIniPath);

            //[리스트설정]
            g_ListData.strCount = txtListCount.Text;
            Global.G_IniWriteValue("LIST", "COUNT", g_ListData.strCount, g_PathData.strIniPath);

            for (int i = 0; i < g_ListData.strCount.ToInt(); i++)
            {
                string name = string.Format("NAME{0}", (i + 1).ToString());
                string length = string.Format("LENGTH{0}", (i + 1).ToString());

                if (this.listGridName.Items.Count <= i)
                {
                    Global.G_IniWriteValue("LIST", name, "TEMP", g_PathData.strIniPath);
                }
                else
                {
                    Global.G_IniWriteValue("LIST", name, this.listGridName.Items[i].ToString(), g_PathData.strIniPath);
                }

                if (this.listGridLength.Items.Count <= i)
                {
                    Global.G_IniWriteValue("LIST", length, "100", g_PathData.strIniPath);
                }
                else
                {
                    Global.G_IniWriteValue("LIST", length, this.listGridLength.Items[i].ToString(), g_PathData.strIniPath);
                }
            }


            //[디렉토리설정]
            Global.G_IniWriteValue("PATH", "IMAGE", txtImageSavePath.Text, g_PathData.strIniPath);
            Global.G_IniWriteValue("PATH", "PROGRAM", txtProgramSavePath.Text, g_PathData.strIniPath);


            //[기타설정]
            string uiMode = "0";
            if (rdoUiModeLeft.Checked == true)
            {
                uiMode = "0";
            }
            else if (this.rdoUiModeRight.Checked == true)
            {
                uiMode = "1";
            }
            else if (this.rdoUiModeTop.Checked == true)
            {
                uiMode = "2";
            }
            else if (this.rdoUiModeBottom.Checked == true)
            {
                uiMode = "3";
            }

            Global.G_IniWriteValue("OTHERS", "UIMODE", uiMode, g_PathData.strIniPath);

            //병리번호 세팅
            string cipher = "0";
            if (rdoCipher1.Checked == true)
            {
                cipher = "0";
            }
            else if (rdoCipher2.Checked == true)
            {
                cipher = "1";
            }

            Global.G_IniWriteValue("OTHERS", "CIPHER", cipher, g_PathData.strIniPath);

            Global.G_IniWriteValue("OTHERS", "ADDHYPEN", chkHypen.Checked == true ? "1" : "0", g_PathData.strIniPath);

            string imageSize = "0";
            if (rdoImageSizeBig.Checked == true)
            {
                imageSize = "0";
            }
            else if (rdoImageSizeSmall.Checked == true)
            {
                imageSize = "1";
            }

            Global.G_IniWriteValue("OTHERS", "IMAGESIZE", imageSize, g_PathData.strIniPath);

            string sortSetting = "studyDt";
            //정렬 setting
            if (this.rdoSortStudyDt.Checked == true)
            {
                sortSetting = "studyDt";
            }
            else if (this.rdoSortInsertDt.Checked == true)
            {
                sortSetting = "insertDt";
            }
            else if (this.rdoSortLastDt.Checked == true)
            {
                sortSetting = "lastDt";
            }

            Global.G_IniWriteValue("OTHERS", "SORT", sortSetting, g_PathData.strIniPath);


            int period = 7;
            //조회기간 setting
            if (this.rdoPeriodToday.Checked == true)
            {
                period = 0;
            }
            else if ( this.rdoPeriodOther.Checked == true)
            {
                string strPeriod = txtPeriod.Text;

                if (strPeriod.ToIntOrNull() != null)
                {
                    period = strPeriod.ToInt();
                }
            }

            Global.G_IniWriteValue("OTHERS", "PERIOD", period.ToString(), g_PathData.strIniPath);

            string periodType = "";
            if (chkLastUpDt.Checked == true)
            {
                periodType = "last";
            }

            Global.G_IniWriteValue("OTHERS", "PERIOD_TYPE", periodType, g_PathData.strIniPath);

            Global.G_IniWriteValue("CHAR", "COUNT", listChar.Items.Count.ToString(), g_PathData.strIniCombo);

            for (int i = 0; i < listChar.Items.Count; i++)
            {
                string count = string.Format("COUNT{0}", (i + 1).ToString());

                Global.G_IniWriteValue("CHAR", count, this.listChar.Items[i].ToString(), g_PathData.strIniCombo);
            }

            Global.G_IniWriteValue("WEEK", "COUNT", listWeek.Items.Count.ToString(), g_PathData.strIniCombo);

            for (int i = 0; i < listWeek.Items.Count; i++)
            {
                string count = string.Format("COUNT{0}", (i + 1).ToString());

                Global.G_IniWriteValue("WEEK", count, this.listWeek.Items[i].ToString(), g_PathData.strIniCombo);
            }

            string onlyMapping = "N";
            if (chkOnlyMapping.Checked == true)
            {
                onlyMapping = "Y";
            }

            Global.G_IniWriteValue("OTHERS", "ONLY_MAPPING", onlyMapping, g_PathData.strIniPath);


            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        /// <summary>
        /// name         : btnCancel_Click
        /// desc         : 취소버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-30 14:00
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// name         : btnImageSavePath_Click
        /// desc         : 이미지 경로 설정 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-30 14:45
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnImageSavePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();

            string selectedPath = dialog.SelectedPath;

            if (string.IsNullOrEmpty(selectedPath)) return;

            if (selectedPath[selectedPath.Length - 1].ToString() != "\\")
            {
                selectedPath = selectedPath + "\\";
            }

            this.txtImageSavePath.Text = selectedPath;
        }


        /// <summary>
        /// name         : btnProgramSavePath_Click
        /// desc         : 응용프로그램 경로 설정 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-30 14:45
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary>  
        private void btnProgramSavePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            //ofd.Filter = "jpg(*.*)|*.jpg*";
            DialogResult drs = ofd.ShowDialog();
            if (drs == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(ofd.FileName))
                {
                    this.txtProgramSavePath.Text = ofd.FileName;
                }
            }
        }

        Color borderColor = Color.Red; // Color.FromArgb(36, 84, 136);
        private void xtraTabControl1_CustomDrawTabHeader(object sender, DevExpress.XtraTab.TabHeaderCustomDrawEventArgs e)
        {
            var rectangle = e.Bounds;
            ControlPaint.DrawBorder(e.Graphics, rectangle, borderColor, 1, ButtonBorderStyle.Solid
                                                                  , borderColor, 1, ButtonBorderStyle.Solid
                                                                  , borderColor, 1, ButtonBorderStyle.Solid
                                                                  , borderColor, 1, ButtonBorderStyle.Solid);
        }

        private void xtraTabControl1_CustomDrawHeaderButton(object sender, DevExpress.XtraTab.HeaderButtonCustomDrawEventArgs e)
        {
            var rectangle = e.Bounds;
            ControlPaint.DrawBorder(e.Graphics, rectangle, borderColor, 1, ButtonBorderStyle.Solid
                                                                  , borderColor, 1, ButtonBorderStyle.Solid
                                                                  , borderColor, 1, ButtonBorderStyle.Solid
                                                                  , borderColor, 1, ButtonBorderStyle.Solid);
        }


        /// <summary>
        /// name         : btnGridNameUp_Click
        /// desc         : 리스트 이름 위로 올리기
        /// author       : 심우종
        /// create date  : 2020-09-28 14:19
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnGridNameUp_Click(object sender, EventArgs e)
        {
            string value = this.listGridName.SelectedValue.ToString();
            int index = this.listGridName.SelectedIndex;
            if (index > 0)
            {
                this.listGridName.Items.Insert(index - 1, value);
                this.listGridName.Items.RemoveAt(index + 1);

                this.listGridName.SelectedIndex = index - 1;
            }
        }


        /// <summary>
        /// name         : btnGridNameDown_Click
        /// desc         : 리스트 이름 아래로 내리기
        /// author       : 심우종
        /// create date  : 2020-09-28 14:19
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnGridNameDown_Click(object sender, EventArgs e)
        {
            string value = this.listGridName.SelectedValue.ToString();
            int index = this.listGridName.SelectedIndex;
            if (index <= listGridName.Items.Count -2)
            {
                this.listGridName.Items.Insert(index + 2, value);
                this.listGridName.Items.RemoveAt(index);

                this.listGridName.SelectedIndex = index + 1;
            }
        }

        private void btnGridLengthUp_Click(object sender, EventArgs e)
        {
            string value = this.listGridLength.SelectedValue.ToString();
            int index = this.listGridLength.SelectedIndex;
            if (index > 0)
            {
                this.listGridLength.Items.Insert(index - 1, value);
                this.listGridLength.Items.RemoveAt(index + 1);

                this.listGridLength.SelectedIndex = index - 1;
            }
        }

        private void btnGridLengthDown_Click(object sender, EventArgs e)
        {
            string value = this.listGridLength.SelectedValue.ToString();
            int index = this.listGridLength.SelectedIndex;
            if (index <= listGridLength.Items.Count - 2)
            {
                this.listGridLength.Items.Insert(index + 2, value);
                this.listGridLength.Items.RemoveAt(index);

                this.listGridLength.SelectedIndex = index + 1;
            }
        }


        /// <summary>
        /// name         : rdoPeriodOther_CheckedChanged
        /// desc         : 조회기간 기타일자 체크 선택시
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void rdoPeriodOther_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPeriodOther.Checked == true)
            {
                txtPeriod.Enabled = true;
            }
            else
            {
                txtPeriod.Enabled = false;
            }
        }
    }
}
