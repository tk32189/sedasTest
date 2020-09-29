using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;

namespace SmartPIS
{
    public partial class Breast : DevExpress.XtraEditors.XtraForm
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public static MySqlConnection Myconn;
        MySqlDataAdapter adp = new MySqlDataAdapter();
        public string HMTP = "brs";
        public string PTNO;
        public string block1;
        public string block2;
        public string totalAdd;
        public string totalAdd2, totalAdd3, totalAdd4;

        public Breast()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String sql = "select * from PISBRS001 where PTNO = '[PTNO]'";
                sql = sql.Replace("[PTNO]", PTNO);
                string strSQL = Ini.strDB;
                MySqlConnection conn = new MySqlConnection(strSQL);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader drc = cmd.ExecuteReader();

                bool bRet = false;

                while (drc.Read())
                {
                    bRet = true;
                }

                if (bRet)
                {
                    UpdateDB();
                }
                else
                {
                    InsertDB();

                }


                reset();
                selectBRS();
                selectAddgrid1();
                selectAddgrid2();
                selectAddgrid5();
                Selectblock();
                drc.Close();
                conn.Close();
            }
            catch (System.Exception ex)
            {
            }
        }

        private void reset()
        {
            //161005
            cbt00001.Text = " ";

            cb00101.Text = " ";
            cb00102.Text = " ";
            cb00103.Text = " ";
            tb00104.Text = "";


            cb00201.Text = " ";
            tb00202.Text = "";
            tb00203.Text = "";

            cb00301.Text = " ";

            cb00401.Text = " ";
            cb00402.Text = " ";
            cb00403.Text = " ";
            cb00404.Text = " ";

            cb00501.Text = " ";
            tb00502.Text = "";

            cb00601.Text = " ";
            tb00602.Text = "";


            cb00701.Text = " ";
            tb00702.Text = "";

            cb00801.Text = " ";
            tb00802.Text = "";

            cb00901.Text = " ";
            tb00902.Text = "";

            cb01001.Text = " ";


            cb01101.Text = " ";
            cb01102.Text = " ";
            cb01103.Text = " ";
            cb01104.Text = " ";
            cb01105.Text = " ";
            cb01106.Text = " ";
            cb01107.Text = " ";

            tb01201.Text = "- DUCTAL";
            tb01202.Text = "";
            tb01203.Text = "admixed with and adjacent to invasive component.";

            tb01301.Text = "";
            tb01302.Text = "";
            tb01303.Text = "";
            tb01304.Text = "";
            tb01305.Text = "";
            tb01306.Text = "";
            tb01307.Text = "";



            cb01401.Text = " ";
            tb01402.Text = "";

            cb01501.Text = " ";
            cb01601.Text = " ";

            cb01701.Text = " ";
            cb01702.Text = " ";
            cb01703.Text = " ";
            cb01704.Text = " ";
            cb01705.Text = " ";
            cb01706.Text = " ";
            cb01707.Text = " ";

            cb01801.Text = " ";
            tb01802.Text = "";
            tb01803.Text = "";

            tb01901.Text = "";
            tb01902.Text = "";
            tb01903.Text = "";
            cb01904.Text = " ";
            chb019031.Checked = false;
            chb019032.Checked = false;
            chb019033.Checked = false;
            chb02001.Checked = false;
            cb02002.Text = " ";
            tb02003.Text = "";
            chb02004.Checked = false;

            tbECTX.Text = "";
            tbNOTE.Text = "";

            tbblock01.Text = "";
            tbblock03.Text = "";
            tbATX1.Text = "";
            tbATX2.Text = "";
            dataGridView3.Rows.Clear();
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView5.Rows.Clear();
            cbt00001.Select();
        }

        private void selectBRS()
        {


            String sql = "select TIT1, n0101, n0102, n0103, n0104, n0201, n0202, n0203, n0301, n0401, n0402, n0403, n0404, n0501, n0502, n0601, n0602, n0701, n0702, n0801, n0802,n0901,n0902, n1001, n1101, n1102, n1103, n1104, n1105, n1106, n1107, n1201,n1202,n1203,n1301,n1302,n1303,n1304,n1305,n1306,n1307,n1401,n1402,n1501,n1601,n1701,n1702,n1703,n1704,n1705,n1706,n1707,n1801,n1802,n1803,n1901,n1902,n1903,n1904,n1905,n1906,n1907,n2001,n2002,n2003,n2004,ECTX,NOTE,ATX1,ATX2 from PISBRS001 where PTNO ='[PTNO]'";

            sql = sql.Replace("[PTNO]", PTNO);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                cbt00001.SelectedIndex = selectData00001(dr[0].ToString());
                tb00101.Text = dr[1].ToString().Replace("^", "'");
                //cb00101.SelectedIndex = selectData00101(dr[1].ToString());
                cb00102.SelectedIndex = selectData00102(dr[2].ToString());
                cb00103.SelectedIndex = selectData00103(dr[3].ToString());
                tb00104.Text = dr[4].ToString().Replace("^", "'");

                cb00201.SelectedIndex = selectData00201(dr[5].ToString());
                tb00202.Text = dr[6].ToString().Replace("^", "'");
                tb00203.Text = dr[7].ToString().Replace("^", "'");


                cb00301.SelectedIndex = selectData00301(dr[8].ToString());

                cb00401.SelectedIndex = selectData00401(dr[9].ToString());
                cb00402.SelectedIndex = selectData00402(dr[10].ToString());
                cb00403.SelectedIndex = selectData00403(dr[11].ToString());
                cb00404.SelectedIndex = selectData00404(dr[12].ToString());

                cb00501.SelectedIndex = selectData00501(dr[13].ToString());
                tb00502.Text = dr[14].ToString().Replace("^", "'");

                cb00601.SelectedIndex = selectData00601(dr[15].ToString());
                tb00602.Text = dr[16].ToString().Replace("^", "'");

                cb00701.SelectedIndex = selectData00701(dr[17].ToString());
                tb00702.Text = dr[18].ToString().Replace("^", "'");

                cb00801.SelectedIndex = selectData00801(dr[19].ToString());
                tb00802.Text = dr[20].ToString().Replace("^", "'");

                cb00901.SelectedIndex = selectData00901(dr[21].ToString());
                tb00902.Text = dr[22].ToString().Replace("^", "'");

                cb01001.SelectedIndex = selectData01001(dr[23].ToString());

                cb01101.SelectedIndex = selectData01101(dr[24].ToString());
                cb01102.SelectedIndex = selectData01102(dr[25].ToString());
                cb01103.SelectedIndex = selectData01103(dr[26].ToString());
                cb01104.SelectedIndex = selectData01104(dr[27].ToString());
                cb01105.SelectedIndex = selectData01105(dr[28].ToString());
                cb01106.SelectedIndex = selectData01106(dr[29].ToString());
                cb01107.SelectedIndex = selectData01107(dr[30].ToString());

                tb01201.Text = dr[31].ToString().Replace("^", "'");
                tb01202.Text = dr[32].ToString().Replace("^", "'");
                tb01203.Text = dr[33].ToString().Replace("^", "'");

                tb01301.Text = dr[34].ToString().Replace("^", "'");
                tb01302.Text = dr[35].ToString().Replace("^", "'");
                tb01303.Text = dr[36].ToString().Replace("^", "'");
                tb01304.Text = dr[37].ToString().Replace("^", "'");
                tb01305.Text = dr[38].ToString().Replace("^", "'");
                tb01306.Text = dr[39].ToString().Replace("^", "'");
                tb01307.Text = dr[40].ToString().Replace("^", "'");

                cb01401.SelectedIndex = selectData01401(dr[41].ToString());
                tb01402.Text = dr[42].ToString().Replace("^", "'");

                cb01501.SelectedIndex = selectData01501(dr[43].ToString());

                cb01601.SelectedIndex = selectData01601(dr[44].ToString());

                cb01701.SelectedIndex = selectData01701(dr[45].ToString());
                cb01702.SelectedIndex = selectData01702(dr[46].ToString());
                cb01703.SelectedIndex = selectData01703(dr[47].ToString());
                cb01704.SelectedIndex = selectData01704(dr[48].ToString());
                cb01705.SelectedIndex = selectData01705(dr[49].ToString());
                cb01706.SelectedIndex = selectData01706(dr[50].ToString());
                cb01707.SelectedIndex = selectData01707(dr[51].ToString());

                cb01801.SelectedIndex = selectData01801(dr[52].ToString());
                tb01802.Text = dr[53].ToString().Replace("^", "'");
                tb01803.Text = dr[54].ToString().Replace("^", "'");


                tb01901.Text = dr[55].ToString().Replace("^", "'");
                tb01902.Text = dr[56].ToString().Replace("^", "'");

                //MessageBox.Show(dr[57].ToString().Replace("^", "'"));
                //essageBox.Show(dr[58].ToString().Replace("^", "'"));
                //MessageBox.Show(dr[59].ToString().Replace("^", "'"));
                //MessageBox.Show(dr[60].ToString().Replace("^", "'"));
                //MessageBox.Show(dr[61].ToString().Replace("^", "'"));
                if (dr[57].ToString() == "Macrometastasis")
                {
                    chb019031.Checked = true;
                }
                if (dr[58].ToString() == "Micrometastasis")
                {
                    chb019032.Checked = true;
                }
                if (dr[59].ToString() == "isolated tumor cells")
                {
                    chb019033.Checked = true;
                }
                if (chb019033.Checked == true)
                {
                    tb01903.Text = dr[60].ToString().Replace("^", "'");
                }

                //tb01903.Text = dr[57].ToString().Replace("^", "'");

                cb01904.SelectedIndex = selectData01904(dr[61].ToString());

                if (dr[63].ToString() == "" || dr[62].ToString() == " ")
                {
                    chb02001.Checked = false;
                }
                else
                {
                    chb02001.Checked = true;
                }

                if (dr[65].ToString() == "")
                {
                    chb02004.Checked = false;
                }
                else
                {
                    chb02004.Checked = true;
                }


                cb02002.SelectedIndex = selectData02002(dr[63].ToString());
                tb02003.Text = dr[64].ToString().Replace("^", "'");

                tbECTX.Text = dr[66].ToString().Replace("^", "'");
                tbNOTE.Text = dr[67].ToString().Replace("^", "'");
                tbATX1.Text = dr[68].ToString().Replace("^", "'");
                tbATX2.Text = dr[69].ToString().Replace("^", "'");
                selectAdd();
                selectAddgrid1();
                selectAddgrid2();
                selectAddgrid5();
            }
            dr.Close();
        }

        private void UpdateDB()
        {

            string Titlestr0001 = cbt00001.Text;
            Titlestr0001 = Titlestr0001.Replace("'", "^");

            string str0101 = tb00101.Text;
            str0101 = str0101.Replace("'", "^");

            string str0102 = cb00102.Text;
            str0102 = str0102.Replace("'", "^");

            string str0103 = cb00103.Text;
            str0103 = str0103.Replace("'", "^");

            string str0104 = tb00104.Text;
            str0104 = str0104.Replace("'", "^");

            string str0201 = cb00201.Text;
            str0201 = str0201.Replace("'", "^");

            string str0202 = tb00202.Text;
            str0202 = str0202.Replace("'", "^");

            string str0203 = tb00203.Text;
            str0203 = str0203.Replace("'", "^");

            string str0301 = cb00301.Text;
            str0301 = str0301.Replace("'", "^");

            string str0401 = cb00401.Text;
            str0401 = str0401.Replace("'", "^");

            string str0402 = cb00402.Text;
            str0402 = str0402.Replace("'", "^");

            string str0403 = cb00403.Text;
            str0403 = str0403.Replace("'", "^");

            string str0404 = cb00404.Text;
            str0404 = str0404.Replace("'", "^");

            string str0501 = cb00501.Text;
            str0501 = str0501.Replace("'", "^");

            string str0502 = tb00502.Text;
            str0502 = str0502.Replace("'", "^");

            string str0601 = cb00601.Text;
            str0601 = str0601.Replace("'", "^");

            string str0602 = tb00602.Text;
            str0602 = str0602.Replace("'", "^");


            string str0701 = cb00701.Text;
            str0701 = str0701.Replace("'", "^");

            string str0702 = tb00702.Text;
            str0702 = str0702.Replace("'", "^");


            string str0801 = cb00801.Text;
            str0801 = str0801.Replace("'", "^");

            string str0802 = tb00802.Text;
            str0802 = str0802.Replace("'", "^");


            string str0901 = cb00901.Text;
            str0901 = str0901.Replace("'", "^");

            string str0902 = tb00902.Text;
            str0902 = str0902.Replace("'", "^");





            string str1001 = cb01001.Text;
            str1001 = str1001.Replace("'", "^");



            string str1101 = cb01101.Text;
            str1101 = str1101.Replace("'", "^");

            string str1102 = cb01102.Text;
            str1102 = str1102.Replace("'", "^");

            string str1103 = cb01103.Text;
            str1103 = str1103.Replace("'", "^");

            string str1104 = cb01104.Text;
            str1104 = str1104.Replace("'", "^");

            string str1105 = cb01105.Text;
            str1105 = str1105.Replace("'", "^");

            string str1106 = cb01106.Text;
            str1106 = str1106.Replace("'", "^");

            string str1107 = cb01107.Text;
            str1107 = str1107.Replace("'", "^");



            string str1201 = tb01201.Text;
            str1201 = str1201.Replace("'", "^");

            string str1202 = tb01202.Text;
            str1202 = str1202.Replace("'", "^");

            string str1203 = tb01203.Text;
            str1203 = str1203.Replace("'", "^");

            string str1301 = tb01301.Text;
            str1301 = str1301.Replace("'", "^");

            string str1302 = tb01302.Text;
            str1302 = str1302.Replace("'", "^");

            string str1303 = tb01303.Text;
            str1303 = str1303.Replace("'", "^");

            string str1304 = tb01304.Text;
            str1304 = str1304.Replace("'", "^");

            string str1305 = tb01305.Text;
            str1305 = str1305.Replace("'", "^");

            string str1306 = tb01306.Text;
            str1306 = str1306.Replace("'", "^");

            string str1307 = tb01307.Text;
            str1307 = str1307.Replace("'", "^");

            string str1401 = cb01401.Text;
            str1401 = str1401.Replace("'", "^");

            string str1402 = tb01402.Text;
            str1402 = str1402.Replace("'", "^");

            string str1501 = cb01501.Text;
            str1501 = str1501.Replace("'", "^");

            string str1601 = cb01601.Text;
            str1601 = str1601.Replace("'", "^");


            string str1701 = cb01701.Text;
            str1701 = str1701.Replace("'", "^");

            string str1702 = cb01702.Text;
            str1702 = str1702.Replace("'", "^");

            string str1703 = cb01703.Text;
            str1703 = str1703.Replace("'", "^");

            string str1704 = cb01704.Text;
            str1704 = str1704.Replace("'", "^");

            string str1705 = cb01705.Text;
            str1705 = str1705.Replace("'", "^");

            string str1706 = cb01706.Text;
            str1706 = str1706.Replace("'", "^");

            string str1707 = cb01707.Text;
            str1707 = str1707.Replace("'", "^");

            string str1801 = cb01801.Text;
            str1801 = str1801.Replace("'", "^");

            string str1802 = tb01802.Text;
            str1802 = str1802.Replace("'", "^");

            string str1803 = tb01803.Text;
            str1803 = str1803.Replace("'", "^");

            string str1901 = tb01901.Text;
            str1901 = str1901.Replace("'", "^");

            string str1902 = tb01902.Text;
            str1902 = str1902.Replace("'", "^");

            string str1903 = "";
            if (chb019031.Checked == true)
            {
                str1903 = chb019031.Text;
                str1903 = str1903.Replace("'", "^");
            }
            string str1904 = "";
            if (chb019032.Checked == true)
            {
                str1904 = chb019032.Text;
                str1904 = str1904.Replace("'", "^");
            }
            string str1905 = "";
            if (chb019033.Checked == true)
            {
                str1905 = chb019033.Text;
                str1905 = str1905.Replace("'", "^");
            }

            string str1906 = tb01903.Text;
            str1906 = str1906.Replace("'", "^");

            string str1907 = cb01904.Text;
            str1907 = str1907.Replace("'", "^");

            string str2001, str2002, str2003, str2004;
            if (chb02001.Checked == true)
            {
                str2001 = lb02001.Text + " " + cb02002.Text + " " + lb02002.Text + " " + tb02003.Text;
                str2002 = cb02002.Text;
                str2003 = tb02003.Text;
            }
            else
            {
                str2001 = "";
                str2002 = "";
                str2003 = "";
            }

            if (chb02004.Checked == true)
            {
                str2004 = chb02004.Text;

            }
            else
            {
                str2004 = "";
            }


            string ectb = tbECTX.Text;
            ectb = ectb.Replace("'", "^");

            string note = tbNOTE.Text;
            note = note.Replace("'", "^");

            string strATX1 = tbATX1.Text;
            strATX1.Replace("'", "^");
            string strATX2 = tbATX2.Text;
            strATX2.Replace("'", "^");
            string strblock001 = tbblock01.Text;
            strblock001.Replace("'", "^");
            string strblock002 = tbblock03.Text;
            strblock002.Replace("'", "^");

            string sql = "Update pisBRS001 SET SYDT = '[SYDT]', UPDT = '[UPDT]', UPID = '[UPID]', OGTP = '[OGTP]', DITP='[DITP]', TRYN ='[TRYN]', TIT1 = '[TIT1]', n0101 = '[n0101]', n0102 = '[n0102]', n0103 = '[n0103]', n0104 = '[n0104]', n0201 = '[n0201]', n0202 = '[n0202]', n0203 = '[n0203]', n0301='[n0301]', n0401 = '[n0401]',n0402 = '[n0402]',n0403 = '[n0403]',n0404 = '[n0404]', n0501 = '[n0501]', n0502 = '[n0502]', n0601='[n0601]',n0602='[n0602]', n0701='[n0701]', n0702='[n0702]', n0801='[n0801]', n0802='[n0802]', n0901='[n0901]', n0902='[n0902]',n1001='[n1001]',n1101='[n1101]',n1102='[n1102]',n1103='[n1103]',n1104='[n1104]',n1105='[n1105]',n1106='[n1106]',n1107='[n1107]',n1201='[n1201]',n1202='[n1202]',n1203='[n1203]',n1301='[n1301]',n1302='[n1302]',n1303='[n1303]',n1304='[n1304]',n1305='[n1305]',n1306='[n1306]',n1307='[n1307]',n1401='[n1401]',n1402='[n1402]',n1501='[n1501]',n1601='[n1601]',n1701='[n1701]',n1702='[n1702]',n1703='[n1703]',n1704='[n1704]',n1705='[n1705]',n1706='[n1706]',n1707='[n1707]',n1801='[n1801]',n1802='[n1802]',n1803='[n1803]',n1901='[n1901]',n1902='[n1902]',n1903='[n1903]',n1904='[n1904]',n1905='[n1905]',n1906='[n1906]',n1907='[n1907]',n2001='[n2001]',n2002='[n2002]',n2003='[n2003]',n2004='[n2004]',ECTX='[ECTX]', NOTE='[NOTE]' , ATX1='[ATX1]',ATX2 ='[ATX2]' where PTNO ='[PTNO]'";
            //20161005
            sql = sql.Replace("[SYDT]", DateTime.Now.ToString("yyyyMMdd"));
            sql = sql.Replace("[UPDT]", DateTime.Now.ToString("yyyyMMdd"));
            sql = sql.Replace("[UPID]", "");
            sql = sql.Replace("[PTNO]", PTNO);
            sql = sql.Replace("[OGTP]", HMTP);
            sql = sql.Replace("[DITP]", "");
            sql = sql.Replace("[TRYN]", "N");

            sql = sql.Replace("[TIT1]", Titlestr0001);

            sql = sql.Replace("[n0101]", str0101);
            sql = sql.Replace("[n0102]", str0102);
            sql = sql.Replace("[n0103]", str0103);
            sql = sql.Replace("[n0104]", str0104);

            sql = sql.Replace("[n0201]", str0201);
            sql = sql.Replace("[n0202]", str0202);
            sql = sql.Replace("[n0203]", str0203);

            sql = sql.Replace("[n0301]", str0301);

            sql = sql.Replace("[n0401]", str0401);
            sql = sql.Replace("[n0402]", str0402);
            sql = sql.Replace("[n0403]", str0403);
            sql = sql.Replace("[n0404]", str0404);

            sql = sql.Replace("[n0501]", str0501);
            sql = sql.Replace("[n0502]", str0502);

            sql = sql.Replace("[n0601]", str0601);
            sql = sql.Replace("[n0602]", str0602);

            sql = sql.Replace("[n0701]", str0701);
            sql = sql.Replace("[n0702]", str0702);

            sql = sql.Replace("[n0801]", str0801);
            sql = sql.Replace("[n0802]", str0802);

            sql = sql.Replace("[n0901]", str0901);
            sql = sql.Replace("[n0902]", str0902);

            sql = sql.Replace("[n1001]", str1001);

            sql = sql.Replace("[n1101]", str1101);
            sql = sql.Replace("[n1102]", str1102);
            sql = sql.Replace("[n1103]", str1103);
            sql = sql.Replace("[n1104]", str1104);
            sql = sql.Replace("[n1105]", str1105);
            sql = sql.Replace("[n1106]", str1106);
            sql = sql.Replace("[n1107]", str1107);

            sql = sql.Replace("[n1201]", str1201);
            sql = sql.Replace("[n1202]", str1202);
            sql = sql.Replace("[n1203]", str1203);

            sql = sql.Replace("[n1301]", str1301);
            sql = sql.Replace("[n1302]", str1302);
            sql = sql.Replace("[n1303]", str1303);
            sql = sql.Replace("[n1304]", str1304);
            sql = sql.Replace("[n1305]", str1305);
            sql = sql.Replace("[n1306]", str1306);
            sql = sql.Replace("[n1307]", str1307);

            sql = sql.Replace("[n1401]", str1401);
            sql = sql.Replace("[n1402]", str1402);

            sql = sql.Replace("[n1501]", str1501);

            sql = sql.Replace("[n1601]", str1601);

            sql = sql.Replace("[n1701]", str1701);
            sql = sql.Replace("[n1702]", str1702);
            sql = sql.Replace("[n1703]", str1703);
            sql = sql.Replace("[n1704]", str1704);
            sql = sql.Replace("[n1705]", str1705);
            sql = sql.Replace("[n1706]", str1706);
            sql = sql.Replace("[n1707]", str1707);

            sql = sql.Replace("[n1801]", str1801);
            sql = sql.Replace("[n1802]", str1802);
            sql = sql.Replace("[n1803]", str1803);

            sql = sql.Replace("[n1901]", str1901);
            sql = sql.Replace("[n1902]", str1902);
            sql = sql.Replace("[n1903]", str1903);
            sql = sql.Replace("[n1904]", str1904);
            sql = sql.Replace("[n1905]", str1905);
            sql = sql.Replace("[n1906]", str1906);
            sql = sql.Replace("[n1907]", str1907);

            sql = sql.Replace("[n2001]", str2001);
            sql = sql.Replace("[n2002]", str2002);
            sql = sql.Replace("[n2003]", str2003);
            sql = sql.Replace("[n2004]", str2004);

            sql = sql.Replace("[ECTX]", ectb);
            sql = sql.Replace("[NOTE]", note);
            sql = sql.Replace("[ATX1]", strATX1);
            sql = sql.Replace("[ATX2]", strATX2);


            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            cmd.ExecuteNonQuery();
            addupdateDB();
            datagrid1addupdateDB();
            datagrid2addupdateDB();
            datagrid5addupdateDB();
            MainDBUpdate();
            DevExpress.XtraEditors.XtraMessageBox.Show("업데이트 되었습니다");

        }

        private void InsertDB()
        {
            string Titlestr0001 = cbt00001.Text;
            Titlestr0001 = Titlestr0001.Replace("'", "^");

            string str0101 = tb00101.Text;
            str0101 = str0101.Replace("'", "^");

            string str0102 = cb00102.Text;
            str0102 = str0102.Replace("'", "^");

            string str0103 = cb00103.Text;
            str0103 = str0103.Replace("'", "^");

            string str0104 = tb00104.Text;
            str0104 = str0104.Replace("'", "^");

            string str0201 = cb00201.Text;
            str0201 = str0201.Replace("'", "^");

            string str0202 = tb00202.Text;
            str0202 = str0202.Replace("'", "^");

            string str0203 = tb00203.Text;
            str0203 = str0203.Replace("'", "^");

            string str0301 = cb00301.Text;
            str0301 = str0301.Replace("'", "^");

            string str0401 = cb00401.Text;
            str0401 = str0401.Replace("'", "^");

            string str0402 = cb00402.Text;
            str0402 = str0402.Replace("'", "^");

            string str0403 = cb00403.Text;
            str0403 = str0403.Replace("'", "^");

            string str0404 = cb00404.Text;
            str0404 = str0404.Replace("'", "^");

            string str0501 = cb00501.Text;
            str0501 = str0501.Replace("'", "^");

            string str0502 = tb00502.Text;
            str0502 = str0502.Replace("'", "^");

            string str0601 = cb00601.Text;
            str0601 = str0601.Replace("'", "^");

            string str0602 = tb00602.Text;
            str0602 = str0602.Replace("'", "^");


            string str0701 = cb00701.Text;
            str0701 = str0701.Replace("'", "^");

            string str0702 = tb00702.Text;
            str0702 = str0702.Replace("'", "^");


            string str0801 = cb00801.Text;
            str0801 = str0801.Replace("'", "^");

            string str0802 = tb00802.Text;
            str0802 = str0802.Replace("'", "^");


            string str0901 = cb00901.Text;
            str0901 = str0901.Replace("'", "^");

            string str0902 = tb00902.Text;
            str0902 = str0902.Replace("'", "^");





            string str1001 = cb01001.Text;
            str1001 = str1001.Replace("'", "^");



            string str1101 = cb01101.Text;
            str1101 = str1101.Replace("'", "^");

            string str1102 = cb01102.Text;
            str1102 = str1102.Replace("'", "^");

            string str1103 = cb01103.Text;
            str1103 = str1103.Replace("'", "^");

            string str1104 = cb01104.Text;
            str1104 = str1104.Replace("'", "^");

            string str1105 = cb01105.Text;
            str1105 = str1105.Replace("'", "^");

            string str1106 = cb01106.Text;
            str1106 = str1106.Replace("'", "^");

            string str1107 = cb01107.Text;
            str1107 = str1107.Replace("'", "^");



            string str1201 = tb01201.Text;
            str1201 = str1201.Replace("'", "^");

            string str1202 = tb01202.Text;
            str1202 = str1202.Replace("'", "^");

            string str1203 = tb01203.Text;
            str1203 = str1203.Replace("'", "^");

            string str1301 = tb01301.Text;
            str1301 = str1301.Replace("'", "^");

            string str1302 = tb01302.Text;
            str1302 = str1302.Replace("'", "^");

            string str1303 = tb01303.Text;
            str1303 = str1303.Replace("'", "^");

            string str1304 = tb01304.Text;
            str1304 = str1304.Replace("'", "^");

            string str1305 = tb01305.Text;
            str1305 = str1305.Replace("'", "^");

            string str1306 = tb01306.Text;
            str1306 = str1306.Replace("'", "^");

            string str1307 = tb01307.Text;
            str1307 = str1307.Replace("'", "^");

            string str1401 = cb01401.Text;
            str1401 = str1401.Replace("'", "^");

            string str1402 = tb01402.Text;
            str1402 = str1402.Replace("'", "^");

            string str1501 = cb01501.Text;
            str1501 = str1501.Replace("'", "^");

            string str1601 = cb01601.Text;
            str1601 = str1601.Replace("'", "^");


            string str1701 = cb01701.Text;
            str1701 = str1701.Replace("'", "^");

            string str1702 = cb01702.Text;
            str1702 = str1702.Replace("'", "^");

            string str1703 = cb01703.Text;
            str1703 = str1703.Replace("'", "^");

            string str1704 = cb01704.Text;
            str1704 = str1704.Replace("'", "^");

            string str1705 = cb01705.Text;
            str1705 = str1705.Replace("'", "^");

            string str1706 = cb01706.Text;
            str1706 = str1706.Replace("'", "^");

            string str1707 = cb01707.Text;
            str1707 = str1707.Replace("'", "^");

            string str1801 = cb01801.Text;
            str1801 = str1801.Replace("'", "^");

            string str1802 = tb01802.Text;
            str1802 = str1802.Replace("'", "^");

            string str1803 = tb01803.Text;
            str1803 = str1803.Replace("'", "^");

            string str1901 = tb01901.Text;
            str1901 = str1901.Replace("'", "^");

            string str1902 = tb01902.Text;
            str1902 = str1902.Replace("'", "^");

            string str1903 = "";
            if (chb019031.Checked == true)
            {
                str1903 = chb019031.Text;
                str1903 = str1903.Replace("'", "^");
            }
            string str1904 = "";
            if (chb019032.Checked == true)
            {
                str1904 = chb019032.Text;
                str1904 = str1904.Replace("'", "^");
            }
            string str1905 = "";
            if (chb019033.Checked == true)
            {
                str1905 = chb019033.Text;
                str1905 = str1905.Replace("'", "^");
            }

            string str1906 = tb01903.Text;
            str1906 = str1906.Replace("'", "^");

            string str1907 = cb01904.Text;
            str1907 = str1907.Replace("'", "^");

            string str2001, str2002, str2003, str2004;
            if (chb02001.Checked == true)
            {
                str2001 = lb02001.Text + " " + cb02002.Text + " " + lb02002.Text + " " + tb02003.Text;
                str2002 = cb02002.Text;
                str2003 = tb02003.Text;
            }
            else
            {
                str2001 = "";
                str2002 = "";
                str2003 = "";
            }

            if (chb02004.Checked == true)
            {
                str2004 = chb02004.Text;

            }
            else
            {
                str2004 = "";
            }


            string ectb = tbECTX.Text;
            ectb = ectb.Replace("'", "^");

            string note = tbNOTE.Text;
            note = note.Replace("'", "^");

            string strATX1 = tbATX1.Text;
            strATX1.Replace("'", "^");
            string strATX2 = tbATX2.Text;
            strATX2.Replace("'", "^");
            string strblock001 = tbblock01.Text;
            strblock001.Replace("'", "^");
            string strblock002 = tbblock03.Text;
            strblock002.Replace("'", "^");

            string sql = "INSERT INTO pisBRS001 ( SYDT, UPDT, UPID, PTNO, OGTP, DITP, TRYN, TIT1, n0101, n0102, n0103, n0104, n0201, n0202, n0203, n0301, n0401, n0402, n0403, n0404, n0501,n0502, n0601, n0602, n0701, n0702, n0801, n0802, n0901, n0902, n1001,n1101,n1102,n1103,n1104,n1105,n1106,n1107, n1201, n1202, n1203, n1301, n1302, n1303, n1304, n1305, n1306, n1307, n1401, n1402,n1501,n1601, n1701, n1702, n1703, n1704, n1705, n1706, n1707, n1801, n1802, n1803, n1901, n1902, n1903, n1904, n1905, n1906, n1907, n2001, n2002, n2003, n2004, ECTX, NOTE,ATX1,ATX2) VALUES ( '[SYDT]', '[UPDT]', '[UPID]', '[PTNO]', '[OGTP]', '[DITP]', '[TRYN]','[TIT1]', '[n0101]', '[n0102]', '[n0103]', '[n0104]', '[n0201]', '[n0202]', '[n0203]', '[n0301]', '[n0401]', '[n0402]', '[n0403]', '[n0404]', '[n0501]','[n0502]', '[n0601]', '[n0602]', '[n0701]', '[n0702]', '[n0801]', '[n0802]', '[n0901]', '[n0902]', '[n1001]','[n1101]','[n1102]','[n1103]','[n1104]','[n1105]','[n1106]','[n1107]', '[n1201]', '[n1202]', '[n1203]', '[n1301]', '[n1302]', '[n1303]', '[n1304]', '[n1305]', '[n1306]', '[n1307]', '[n1401]', '[n1402]','[n1501]','[n1601]', '[n1701]', '[n1702]', '[n1703]', '[n1704]', '[n1705]', '[n1706]', '[n1707]', '[n1801]', '[n1802]', '[n1803]', '[n1901]', '[n1902]', '[n1903]', '[n1904]', '[n1905]', '[n1906]', '[n1907]', '[n2001]', '[n2002]', '[n2003]', '[n2004]', '[ECTX]','[NOTE]','[ATX1]','[ATX2]')";
            sql = sql.Replace("[SYDT]", DateTime.Now.ToString("yyyyMMdd"));
            sql = sql.Replace("[UPDT]", DateTime.Now.ToString("yyyyMMdd"));
            sql = sql.Replace("[UPID]", "");
            sql = sql.Replace("[PTNO]", PTNO);
            sql = sql.Replace("[OGTP]", HMTP);
            sql = sql.Replace("[DITP]", "");
            sql = sql.Replace("[TRYN]", "N");

            sql = sql.Replace("[TIT1]", Titlestr0001);

            sql = sql.Replace("[n0101]", str0101);
            sql = sql.Replace("[n0102]", str0102);
            sql = sql.Replace("[n0103]", str0103);
            sql = sql.Replace("[n0104]", str0104);

            sql = sql.Replace("[n0201]", str0201);
            sql = sql.Replace("[n0202]", str0202);
            sql = sql.Replace("[n0203]", str0203);

            sql = sql.Replace("[n0301]", str0301);

            sql = sql.Replace("[n0401]", str0401);
            sql = sql.Replace("[n0402]", str0402);
            sql = sql.Replace("[n0403]", str0403);
            sql = sql.Replace("[n0404]", str0404);

            sql = sql.Replace("[n0501]", str0501);
            sql = sql.Replace("[n0502]", str0502);

            sql = sql.Replace("[n0601]", str0601);
            sql = sql.Replace("[n0602]", str0602);

            sql = sql.Replace("[n0701]", str0701);
            sql = sql.Replace("[n0702]", str0702);

            sql = sql.Replace("[n0801]", str0801);
            sql = sql.Replace("[n0802]", str0802);

            sql = sql.Replace("[n0901]", str0901);
            sql = sql.Replace("[n0902]", str0902);

            sql = sql.Replace("[n1001]", str1001);

            sql = sql.Replace("[n1101]", str1101);
            sql = sql.Replace("[n1102]", str1102);
            sql = sql.Replace("[n1103]", str1103);
            sql = sql.Replace("[n1104]", str1104);
            sql = sql.Replace("[n1105]", str1105);
            sql = sql.Replace("[n1106]", str1106);
            sql = sql.Replace("[n1107]", str1107);

            sql = sql.Replace("[n1201]", str1201);
            sql = sql.Replace("[n1202]", str1202);
            sql = sql.Replace("[n1203]", str1203);

            sql = sql.Replace("[n1301]", str1301);
            sql = sql.Replace("[n1302]", str1302);
            sql = sql.Replace("[n1303]", str1303);
            sql = sql.Replace("[n1304]", str1304);
            sql = sql.Replace("[n1305]", str1305);
            sql = sql.Replace("[n1306]", str1306);
            sql = sql.Replace("[n1307]", str1307);

            sql = sql.Replace("[n1401]", str1401);
            sql = sql.Replace("[n1402]", str1402);

            sql = sql.Replace("[n1501]", str1501);

            sql = sql.Replace("[n1601]", str1601);

            sql = sql.Replace("[n1701]", str1701);
            sql = sql.Replace("[n1702]", str1702);
            sql = sql.Replace("[n1703]", str1703);
            sql = sql.Replace("[n1704]", str1704);
            sql = sql.Replace("[n1705]", str1705);
            sql = sql.Replace("[n1706]", str1706);
            sql = sql.Replace("[n1707]", str1707);

            sql = sql.Replace("[n1801]", str1801);
            sql = sql.Replace("[n1802]", str1802);
            sql = sql.Replace("[n1803]", str1803);

            sql = sql.Replace("[n1901]", str1901);
            sql = sql.Replace("[n1902]", str1902);
            sql = sql.Replace("[n1903]", str1903);
            sql = sql.Replace("[n1904]", str1904);
            sql = sql.Replace("[n1905]", str1905);
            sql = sql.Replace("[n1906]", str1906);
            sql = sql.Replace("[n1907]", str1907);

            sql = sql.Replace("[n2001]", str2001);
            sql = sql.Replace("[n2002]", str2002);
            sql = sql.Replace("[n2003]", str2003);
            sql = sql.Replace("[n2004]", str2004);

            sql = sql.Replace("[ECTX]", ectb);
            sql = sql.Replace("[NOTE]", note);
            sql = sql.Replace("[ATX1]", strATX1);
            sql = sql.Replace("[ATX2]", strATX2);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            cmd.ExecuteNonQuery();

            addupdateDB();
            datagrid1addupdateDB();
            datagrid2addupdateDB();
            datagrid5addupdateDB();
            MainDBUpdate();
            DevExpress.XtraEditors.XtraMessageBox.Show("저장되었습니다");
        }

        private void addupdateDB()
        {
            int n = 0;
            string str1 = "", str2 = "", str3 = "";

            for (int i = 0; i < Convert.ToUInt32(dataGridView3.Rows.Count - 1); i++)
            {
                str1 = dataGridView3.Rows[i].Cells[0].FormattedValue.ToString();
                str2 = dataGridView3.Rows[i].Cells[1].FormattedValue.ToString();
                str3 = dataGridView3.Rows[i].Cells[2].FormattedValue.ToString();
                str1 = str1.Replace("'", "^");
                str2 = str2.Replace("'", "^");
                str3 = str3.Replace("'", "^");
                n = i + 1;
                string ADD1 = "A" + n + "01";
                string ADD2 = "A" + n + "02";
                string ADD3 = "A" + n + "03";

                string sql = String.Format("Update PISBRS001 set {0}='{1}', {2} = '{3}',{4}='{5}' where PTNO = '{6}'", ADD1, str1, ADD2, str2, ADD3, str3, PTNO);

                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                cmd.ExecuteNonQuery();
            }


        }

        private void datagrid2addupdateDB()
        {
            int n = 0;
            string str1 = "", str2 = "", str3 = "";
            string ADD1 = "", ADD2 = "", ADD3 = "";

            string sql;
            if (Convert.ToUInt32(dataGridView2.Rows.Count) == 1)
            {
                sql = String.Format("Update PISBRS001 set M101 ='', M102 ='' , M103='', M201 ='', M202 ='' , M203='', M301 ='', M302 ='' , M303='', M401 ='', M402 ='' , M403='', M501 ='', M502 ='' , M503='', M601 ='', M602 ='' , M603=''  where PTNO = '{0}'", PTNO);
                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                cmd.ExecuteNonQuery();
            }
            else
            {
                for (int i = 0; i < Convert.ToUInt32(dataGridView2.Rows.Count - 1); i++)
                {


                    str1 = dataGridView2.Rows[i].Cells[0].FormattedValue.ToString();
                    str2 = dataGridView2.Rows[i].Cells[1].FormattedValue.ToString();
                    str3 = dataGridView2.Rows[i].Cells[2].FormattedValue.ToString();
                    str1 = str1.Replace("'", "^");
                    str2 = str2.Replace("'", "^");
                    str3 = str3.Replace("'", "^");
                    n = i + 1;
                    ADD1 = "M" + n + "01";
                    ADD2 = "M" + n + "02";
                    ADD3 = "M" + n + "03";

                    sql = String.Format("Update PISBRS001 set {0}='{1}', {2} = '{3}',{4}='{5}' where PTNO = '{6}'", ADD1, str1, ADD2, str2, ADD3, str3, PTNO);

                    MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                    cmd.ExecuteNonQuery();
                }

            }


        }

        private void datagrid5addupdateDB()
        {
            int n = 0;
            string str1 = "", str2 = "", str3 = "";
            string ADD1 = "", ADD2 = "", ADD3 = "";

            string sql;
            if (Convert.ToUInt32(dataGridView5.Rows.Count) == 1)
            {
                sql = String.Format("Update PISBRS001 set G101 ='', G102 ='' , G103='', G201 ='', G202 ='' , G203='', G301 ='', G302 ='' , G303='', G401 ='', G402 ='' , G403='', G501 ='', G502 ='' , G503='', G601 ='', M602 ='' , M603=''  where PTNO = '{0}'", PTNO);
                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                cmd.ExecuteNonQuery();
            }
            else
            {
                for (int i = 0; i < Convert.ToUInt32(dataGridView5.Rows.Count - 1); i++)
                {
                    str1 = dataGridView5.Rows[i].Cells[0].FormattedValue.ToString();
                    str2 = dataGridView5.Rows[i].Cells[1].FormattedValue.ToString();
                    str3 = dataGridView5.Rows[i].Cells[2].FormattedValue.ToString();
                    str1 = str1.Replace("'", "^");
                    str2 = str2.Replace("'", "^");
                    str3 = str3.Replace("'", "^");
                    n = i + 1;
                    ADD1 = "G" + n + "01";
                    ADD2 = "G" + n + "02";
                    ADD3 = "G" + n + "03";

                    sql = String.Format("Update PISBRS001 set {0}='{1}', {2} = '{3}',{4}='{5}' where PTNO = '{6}'", ADD1, str1, ADD2, str2, ADD3, str3, PTNO);

                    MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                    cmd.ExecuteNonQuery();
                }
            }


        }

        private void datagrid1addupdateDB()
        {
            int n = 0;
            string str1 = "", str2 = "", str3 = "", str4 = "", str5 = "", str6 = "", str7 = "";
            string ADD1 = "", ADD2 = "", ADD3 = "", ADD4 = "", ADD5 = "", ADD6 = "", ADD7 = "";

            for (int i = 0; i < Convert.ToUInt32(dataGridView1.Rows.Count - 1); i++)
            {
                str1 = dataGridView1.Rows[i].Cells[0].FormattedValue.ToString();
                str2 = dataGridView1.Rows[i].Cells[1].FormattedValue.ToString();
                str3 = dataGridView1.Rows[i].Cells[2].FormattedValue.ToString();
                str4 = dataGridView1.Rows[i].Cells[3].FormattedValue.ToString();
                str5 = dataGridView1.Rows[i].Cells[4].FormattedValue.ToString();
                str6 = dataGridView1.Rows[i].Cells[5].FormattedValue.ToString();
                str7 = dataGridView1.Rows[i].Cells[6].FormattedValue.ToString();
                str1 = str1.Replace("'", "^");
                str2 = str2.Replace("'", "^");
                str3 = str3.Replace("'", "^");
                str4 = str4.Replace("'", "^");
                str5 = str5.Replace("'", "^");
                str6 = str6.Replace("'", "^");
                str7 = str7.Replace("'", "^");

                n = i + 1;
                ADD1 = "S" + i + "01";
                ADD2 = "S" + i + "02";
                ADD3 = "S" + i + "03";
                ADD4 = "S" + i + "04";
                ADD5 = "S" + i + "05";
                ADD6 = "S" + i + "06";
                ADD7 = "S" + i + "07";

                string sql = String.Format("Update PISBRS001 set {0}='{1}', {2} = '{3}',{4}='{5}',{6}='{7}',{8}='{9}',{10}='{11}',{12}='{13}' where PTNO = '{14}'", ADD1, str1, ADD2, str2, ADD3, str3, ADD4, str4, ADD5, str5, ADD6, str6, ADD7, str7, PTNO);

                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                cmd.ExecuteNonQuery();
            }


        }

        private void MainDBUpdate()
        {

            string sql = "Update PISDIG001 set  DITX = '[DITX]', ABLK = '[ABLK]',NBLK = '[NBLK]',OGTP = '[OGTP]' where PTNO = '[PTNO]'";
            //string DITX = lbt00001.Text + Environment.NewLine + lbt00002.Text + cbt00001.Text + cbt00002.Text + cbt00003.Text + Environment.NewLine + " " + tbt00004.Text + Environment.NewLine + Environment.NewLine + "  " + lb00101.Text + Environment.NewLine + "    " + cb00101.Text + Environment.NewLine + Environment.NewLine + "  " + lb00201.Text + Environment.NewLine + "    " + cb00201.Text + Environment.NewLine + Environment.NewLine + "  " + lb00301.Text + Environment.NewLine + "    " + cb00301.Text + Environment.NewLine + Environment.NewLine + "  " + lb00401.Text + tb00401.Text + lb00402.Text + tb00402.Text + lb00403.Text + tb00403.Text + lb00404.Text + Environment.NewLine + Environment.NewLine + "  " + lb00501.Text + Environment.NewLine + "    " + cb00501.Text + Environment.NewLine + Environment.NewLine + "  " + lb00601.Text + Environment.NewLine + "    " + cb00601.Text + Environment.NewLine + Environment.NewLine + "  " + lb00701.Text + Environment.NewLine + "    " + cb00701.Text + Environment.NewLine + "    " + tb00702.Text + Environment.NewLine + Environment.NewLine + "  " + lb00801.Text + Environment.NewLine + "    " + lb00802.Text + Environment.NewLine + "     " + cb00801.Text + Environment.NewLine + "      " + lb00803.Text + tb00802.Text + lb00804.Text + Environment.NewLine + "    " + lb00805.Text + Environment.NewLine + "     " + cb00803.Text + Environment.NewLine + "    " + lb00806.Text + Environment.NewLine + "     " + cb00804.Text + Environment.NewLine + "      " + lb00807.Text + tb00805.Text + lb00808.Text + Environment.NewLine + "    " + lb00809.Text + Environment.NewLine + "     " + cb00806.Text + Environment.NewLine + Environment.NewLine + "  " + lb00901.Text + Environment.NewLine + "    " + cb00901.Text + Environment.NewLine + Environment.NewLine + "  " + lb01001.Text + cb01001.Text + Environment.NewLine + Environment.NewLine + "  " + lb01101.Text + cb01101.Text + Environment.NewLine + Environment.NewLine + "  " + lb01201.Text + cb01201.Text + Environment.NewLine + Environment.NewLine + "  " + lb01301.Text + Environment.NewLine + "     " + tb01301.Text + Environment.NewLine + Environment.NewLine + "  " + lb01401.Text + lb01402.Text + tb01401.Text + lb01403.Text + tb01402.Text + lb01404.Text + tb01403.Text + Environment.NewLine + Environment.NewLine + "  " + ectb001.Text + Environment.NewLine + Environment.NewLine + "  " + ntlb001.Text + Environment.NewLine + "  " + nttb001.Text;

            string str000 = " " + cbt00001.Text;

            string str00101 = tb00101.Text;
            if (cb00101.Text == " ")
            {
                str00101 = "";
            }
            string str00102 = " " + cb00102.Text;
            if (cb00102.Text == " ")
            {
                str00102 = "";
            }
            string str00103 = " " + cb00103.Text;
            if (cb00103.Text == " ")
            {
                str00103 = "";
            }
            string str00104 = " " + tb00104.Text;
            if (tb00104.Text == "")
            {
                str00104 = "";
            }
            str00101 = str00101.Replace("'", "^");
            str00102 = str00102.Replace("'", "^");
            str00103 = str00103.Replace("'", "^");
            str00104 = str00104.Replace("'", "^");


            string str001 = Environment.NewLine + " " + lb00101.Text + str00101 + str00102 + str00103 + str00104;

            if (cb00101.Text == " " && cb00102.Text == " " && cb00103.Text == " " && tb00104.Text == "")
            {
                str001 = "";
            }

            string str00201 = cb00201.Text;
            if (cb00201.Text == " ")
            {
                str00201 = "";
            }
            string str00202 = " " + tb00202.Text;
            if (tb00202.Text == "")
            {
                str00202 = "";
            }
            string str00203 = Environment.NewLine + "   " + lb00202.Text + tb00203.Text;
            if (tb00203.Text == "")
            {
                str00203 = "";
            }
            string str002 = Environment.NewLine + " " + lb00201.Text + str00201 + str00202 + str00203;
            str002 = str002.Replace("'", "^");
            if (cb00201.Text == " " && tb00202.Text == "" && tb00203.Text == "")
            {
                str002 = "";
            }



            string str003 = Environment.NewLine + " " + lb00301.Text + " " + cb00301.Text + " " + lb00302.Text;
            str003 = str003.Replace("'", "^");
            if (cb00301.Text == " ")
            {
                str003 = "";
            }
            string str00401 = lb00401.Text + cb00401.Text;
            if (cb00401.Text == " ")
            {
                str00401 = "";
            }
            string str00402 = lb00402.Text + cb00402.Text;
            if (cb00402.Text == " ")
            {
                str00402 = "";
            }
            string str00403 = lb00403.Text + cb00403.Text;
            if (cb00403.Text == " ")
            {
                str00403 = "";
            }
            string str00404 = lb00404.Text + cb00404.Text;
            if (cb00404.Text == " ")
            {
                str00404 = "";
            }
            string str004 = Environment.NewLine + "            " + str00401 + ", " + str00402 + ", " + str00403 + ", " + str00404;
            str004 = str004.Replace("'", "^");
            if (cb00401.Text == " " && cb00402.Text == " " && cb00403.Text == " " && cb00404.Text == " ")
            {
                str004 = "";
            }

            int a = 0;
            string[] ADD1 = new string[10];
            totalAdd2 = "";
            string strADD1 = "", strADD2 = "", strADD3 = "", strADD4 = "", strADD5 = "", strADD6 = "", strADD7 = "";
            for (int b = 0; b < Convert.ToUInt32(dataGridView1.Rows.Count - 1); b++)
            {
                strADD1 = dataGridView1.Rows[b].Cells[0].FormattedValue.ToString();
                if (dataGridView1.Rows[b].Cells[0].FormattedValue.ToString() == "")
                {
                    strADD1 = "";
                }
                strADD2 = dataGridView1.Rows[b].Cells[1].FormattedValue.ToString();
                if (dataGridView1.Rows[b].Cells[1].FormattedValue.ToString() == "")
                {
                    strADD2 = "";
                }
                strADD3 = dataGridView1.Rows[b].Cells[2].FormattedValue.ToString();
                if (dataGridView1.Rows[b].Cells[2].FormattedValue.ToString() == "")
                {
                    strADD3 = "";
                }
                strADD4 = dataGridView1.Rows[b].Cells[3].FormattedValue.ToString();
                if (dataGridView1.Rows[b].Cells[3].FormattedValue.ToString() == "")
                {
                    strADD4 = "";
                }
                strADD5 = dataGridView1.Rows[b].Cells[4].FormattedValue.ToString();
                if (dataGridView1.Rows[b].Cells[4].FormattedValue.ToString() == "")
                {
                    strADD5 = "";
                }
                strADD6 = dataGridView1.Rows[b].Cells[5].FormattedValue.ToString();
                if (dataGridView1.Rows[b].Cells[5].FormattedValue.ToString() == "")
                {
                    strADD6 = "";
                }
                strADD7 = dataGridView1.Rows[b].Cells[6].FormattedValue.ToString();
                if (dataGridView1.Rows[b].Cells[6].FormattedValue.ToString() == "")
                {
                    strADD7 = "";
                }
                strADD1 = strADD1.Replace("'", "^");
                strADD2 = strADD2.Replace("'", "^");
                strADD3 = strADD3.Replace("'", "^");
                strADD4 = strADD4.Replace("'", "^");
                strADD5 = strADD6.Replace("'", "^");
                strADD6 = strADD6.Replace("'", "^");
                strADD7 = strADD7.Replace("'", "^");
                a = b + 1;
                ADD1[a] = Environment.NewLine + "   Size of Mass#" + a + " : " + strADD2 + " X " + strADD3 + " X " + strADD6 + " cm" + Environment.NewLine + "     Maximum dimension on one slice: " + strADD1 + " cm" + Environment.NewLine + "     Numbers of involving slices : " + strADD7 + " " + strADD4 + " " + "Slices";
                //1027 수정
                if (strADD1 == "" && strADD2 == "" && strADD3 == "" && strADD4 == "" && strADD5 == "" && strADD6 == "" && strADD7 == "")
                {
                    ADD1[a] = "";
                }

                totalAdd2 = ADD1[1] + ADD1[2] + ADD1[3] + ADD1[4] + ADD1[5] + ADD1[6] + ADD1[7];
                totalAdd2 = totalAdd2.Replace("'", "^");
            }

            string str00501 = cb00501.Text;
            string str00502 = " " + tb00502.Text;
            if (cb00501.Text == " ")
            {
                str00501 = "";
            }
            if (tb00502.Text == "")
            {
                str00502 = "";
            }
            string str005 = Environment.NewLine + " " + lb00501.Text + str00501 + str00502;
            str005 = str005.Replace("'", "^");

            if (cb00501.Text == " " && tb00502.Text == "")
            {
                str005 = "";
            }

            string str00601 = cb00601.Text;
            string str00602 = " " + tb00602.Text;
            if (cb00601.Text == " ")
            {
                str00601 = "";
            }
            if (tb00602.Text == "")
            {
                str00602 = "";
            }
            string str006 = Environment.NewLine + " " + lb00601.Text + str00601 + str00602;
            str006 = str006.Replace("'", "^");

            if (cb00601.Text == " " && tb00602.Text == "")
            {
                str006 = "";
            }
            //
            string str00701 = cb00701.Text;
            string str00702 = " " + tb00702.Text;
            if (cb00701.Text == " ")
            {
                str00701 = "";
            }
            if (tb00702.Text == "")
            {
                str00702 = "";
            }
            string str007 = Environment.NewLine + " " + lb00701.Text + str00701 + str00702;
            str007 = str007.Replace("'", "^");

            if (cb00701.Text == " " && tb00702.Text == "")
            {
                str007 = "";
            }

            string str00801 = cb00801.Text;
            string str00802 = " " + tb00802.Text;
            if (cb00801.Text == " ")
            {
                str00801 = "";
            }
            if (tb00802.Text == "")
            {
                str00802 = "";
            }
            string str008 = Environment.NewLine + " " + lb00801.Text + str00801 + str00802;
            str008 = str008.Replace("'", "^");

            if (cb00801.Text == " " && tb00802.Text == "")
            {
                str008 = "";
            }

            string str00901 = cb00901.Text;
            string str00902 = " " + tb00902.Text;
            if (cb00901.Text == " ")
            {
                str00901 = "";
            }
            if (tb00902.Text == "")
            {
                str00902 = "";
            }
            string str009 = Environment.NewLine + " " + lb00901.Text + str00901 + str00902;
            str009 = str009.Replace("'", "^");

            if (cb00901.Text == " " && tb00902.Text == "")
            {
                str009 = "";
            }

            int c = 0;
            string[] ADD2 = new string[10];

            for (int d = 0; d < Convert.ToUInt32(dataGridView2.Rows.Count - 1); d++)
            {

                string str2ADD1 = dataGridView2.Rows[d].Cells[0].FormattedValue.ToString();
                if (dataGridView2.Rows[d].Cells[0].FormattedValue.ToString() == "")
                {
                    str2ADD1 = "";
                }
                string str2ADD2 = dataGridView2.Rows[d].Cells[1].FormattedValue.ToString();
                if (dataGridView2.Rows[d].Cells[1].FormattedValue.ToString() == "")
                {
                    str2ADD2 = "";
                }
                string str2ADD3 = dataGridView2.Rows[d].Cells[2].FormattedValue.ToString();
                if (dataGridView2.Rows[d].Cells[2].FormattedValue.ToString() == "")
                {
                    str2ADD3 = "";
                }

                str2ADD1 = str2ADD1.Replace("'", "^");
                str2ADD2 = str2ADD2.Replace("'", "^");
                str2ADD3 = str2ADD3.Replace("'", "^");

                c = d + 1;
                ADD2[c] = Environment.NewLine + "  " + str2ADD1 + " : " + str2ADD2 + ", " + str2ADD3;
                //1027 수정

                if (str2ADD1 != "" && str2ADD2 != "" && str2ADD3 != "")
                {

                    ADD2[c] = Environment.NewLine + "  " + str2ADD1 + " : " + str2ADD2 + ", " + str2ADD3;
                }
                else if (str2ADD1 == "" && str2ADD2 == "" && str2ADD3 == "")
                {
                    ADD2[c] = "";
                }

                else if (str2ADD1 != "" && str2ADD2 == "" && str2ADD3 == "")
                {
                    ADD2[c] = Environment.NewLine + "  " + str2ADD1;
                }
                else if (str2ADD1 != "" && str2ADD2 != "" && str2ADD3 == "")
                {
                    ADD2[c] = Environment.NewLine + "  " + str2ADD1 + " : " + str2ADD2;
                }



                totalAdd3 = Environment.NewLine + " Margins :" + ADD2[1] + ADD2[2] + ADD2[3] + ADD2[4] + ADD2[5] + ADD2[6] + ADD2[7] + ADD2[8];
                totalAdd3 = totalAdd3.Replace("'", "^");
            }


            string str010 = Environment.NewLine + " " + lb01001.Text + cb01001.Text;
            str010 = str010.Replace("'", "^");

            if (cb01001.Text == " ")
            {
                str010 = "";
            }

            string str01101 = " " + cb01101.Text;
            if (cb01101.Text == " ")
            {
                str01101 = "";
            }
            string str01102 = cb01102.Text;
            if (cb01102.Text == " ")
            {
                str01102 = "";
            }
            string str01103 = " " + cb01103.Text;
            if (cb01103.Text == " ")
            {
                str01103 = "";
            }
            string str01104 = cb01104.Text;
            if (cb01104.Text == " ")
            {
                str01104 = "";
            }
            string str01105 = " " + cb01105.Text;
            if (cb01105.Text == " ")
            {
                str01105 = "";
            }
            string str01106 = " " + cb01106.Text;
            if (cb01106.Text == " ")
            {
                str01106 = "";
            }
            string str01107 = cb01107.Text;
            if (cb01107.Text == " ")
            {
                str01107 = "";
            }
            string str01108, str01109, str01110;
            str01108 = str01101 + lb01102.Text + str01102;
            if (str01101 == "" && str01102 == "")
            {
                str01108 = "";
            }

            str01109 = str01103 + lb01103.Text + str01104;
            if (str01103 == "" && str01104 == "")
            {
                str01109 = "";
            }

            str01110 = str01105 + str01106 + lb01104.Text + str01107;
            if (str01105 == "" && str01106 == "" && str01107 == "")
            {
                str01110 = "";
            }

            string str011 = Environment.NewLine + " " + lb01101.Text + str01108 + str01109 + str01110;
            str011 = str011.Replace("'", "^");
            if (str01108 == "" && str01109 == "" && str01110 == "")
            {
                str011 = "";
            }

            string str01201 = tb01201.Text + " " + lb01201.Text;
            if (tb01201.Text == "")
            {
                str01201 = "";
            }
            string str01202 = " " + tb01202.Text;
            if (tb01202.Text == "")
            {
                str01202 = "";
            }
            string str01203 = Environment.NewLine + "   " + tb01203.Text;
            if (tb01203.Text == "")
            {
                str01203 = "";
            }
            string str012 = Environment.NewLine + " " + str01201 + str01202 + str01203;
            str012 = str012.Replace("'", "^");
            if (tb01201.Text == "" && tb01202.Text == "" && tb01203.Text == "")
            {
                str012 = "";
            }

            string str01301, str01302, str01303, str01304, str01305, str01306, str01307, str01308, str01309, str01310;
            str01301 = lb01301.Text + tb01301.Text + lb01302.Text;
            if (tb01301.Text == "")
            {
                str01301 = "";
            }
            str01302 = tb01302.Text + lb01304.Text;
            if (tb01302.Text == "")
            {
                str01302 = "";
            }
            str01303 = lb01305.Text + tb01303.Text;
            if (tb01303.Text == "")
            {
                str01303 = "";
            }
            str01304 = lb01306.Text + tb01304.Text + lb01307.Text;
            if (tb01304.Text == "")
            {
                str01304 = "";
            }
            str01305 = " " + lb01308.Text + tb01305.Text + lb01309.Text;
            if (tb01305.Text == "")
            {
                str01305 = "";
            }
            str01306 = tb01306.Text + lb01310.Text;
            if (tb01306.Text == "")
            {
                str01306 = "";
            }
            str01307 = tb01307.Text + lb01311.Text;
            if (tb01307.Text == "")
            {
                str01307 = "";
            }

            str01308 = "  " + str01301 + lb01303.Text + str01302;
            if (tb01301.Text == "" && tb01302.Text != "")
            {
                str01308 = "  " + lb01301.Text + tb01302.Text + lb01304.Text;
            }
            else if (tb01301.Text != "" && tb01302.Text == "")
            {
                str01308 = "  " + str01301;
            }
            else if (str01301 == "" && str01302 == "")
            {
                str01308 = "";
            }
            str01309 = Environment.NewLine + "   " + str01303;
            if (str01303 == "")
            {
                str01309 = "";
            }
            str01310 = Environment.NewLine + "   " + str01304 + str01305 + str01306 + str01307;


            if (str01304 == "" && str01305 == "" && str01306 == "" && str01307 == "")
            {
                str01310 = "";
            }
            if (str01308 == "" && str01309 == "" && str01310 == "")
            {
                str01310 = "";
            }
            string str013 = Environment.NewLine + " " + str01308 + str01309 + str01310;
            str013 = str013.Replace("'", "^");
            if (str01308 == "" && str01309 == "" && str01310 == "")
            {
                str013 = "";
            }

            string str01401 = cb01401.Text;
            if (cb01401.Text == " ")
            {
                str01401 = "";
            }
            string str01402 = " " + tb01402.Text;
            if (tb01402.Text == "")
            {
                str01402 = "";
            }
            string str014 = Environment.NewLine + " " + lb01401.Text + str01401 + str01402;
            str014 = str014.Replace("'", "^");
            if (cb01401.Text == " " && tb01402.Text == "")
            {
                str014 = "";
            }

            string str015 = Environment.NewLine + " " + lb01501.Text + cb01501.Text;
            str015 = str015.Replace("'", "^");
            if (cb01501.Text == " ")
            {
                str015 = "";
            }

            string str016 = Environment.NewLine + " " + lb01601.Text + cb01601.Text;
            str016 = str016.Replace("'", "^");
            if (cb01601.Text == " ")
            {
                str016 = "";
            }


            int f = 0;
            string[] ADD3 = new string[10];

            for (int g = 0; g < Convert.ToUInt32(dataGridView5.Rows.Count - 1); g++)
            {
                string str3ADD1 = dataGridView5.Rows[g].Cells[0].FormattedValue.ToString();
                if (dataGridView5.Rows[g].Cells[0].FormattedValue.ToString() == "")
                {
                    str3ADD1 = "";
                }
                string str3ADD2 = dataGridView5.Rows[g].Cells[1].FormattedValue.ToString();
                if (dataGridView5.Rows[g].Cells[1].FormattedValue.ToString() == "")
                {
                    str3ADD2 = "";
                }
                string str3ADD3 = dataGridView5.Rows[g].Cells[2].FormattedValue.ToString();
                if (dataGridView5.Rows[g].Cells[2].FormattedValue.ToString() == "")
                {
                    str3ADD3 = "";
                }

                str3ADD1 = str3ADD1.Replace("'", "^");
                str3ADD2 = str3ADD2.Replace("'", "^");
                str3ADD3 = str3ADD3.Replace("'", "^");

                f = g + 1;
                ADD3[f] = Environment.NewLine + " " + str3ADD1 + " : " + str3ADD2 + ", " + str3ADD3;
                //1027 수정


                if (str3ADD1 != "" && str3ADD2 != "" && str3ADD3 != "")
                {

                    ADD3[f] = Environment.NewLine + "  " + str3ADD1 + " : " + str3ADD2 + ", " + str3ADD3;
                }
                else if (str3ADD1 == "" && str3ADD2 == "" && str3ADD3 == "")
                {
                    ADD3[f] = "";
                }

                else if (str3ADD1 != "" && str3ADD2 == "" && str3ADD3 == "")
                {
                    ADD3[f] = Environment.NewLine + "  " + str3ADD1;
                }
                else if (str3ADD1 != "" && str3ADD2 != "" && str3ADD3 == "")
                {
                    ADD3[f] = Environment.NewLine + "  " + str3ADD1 + " : " + str3ADD2;
                }


                totalAdd4 = Environment.NewLine + " Margins :" + ADD3[1] + ADD3[2] + ADD3[3] + ADD3[4] + ADD3[5] + ADD3[6];
                totalAdd4 = totalAdd4.Replace("'", "^");
            }


            string str01701 = " " + cb01701.Text;
            if (cb01701.Text == " ")
            {
                str01701 = "";
            }
            string str01702 = cb01702.Text;
            if (cb01702.Text == " ")
            {
                str01702 = "";
            }
            string str01703 = " " + cb01703.Text;
            if (cb01703.Text == " ")
            {
                str01703 = "";
            }
            string str01704 = cb01704.Text;
            if (cb01704.Text == " ")
            {
                str01704 = "";
            }
            string str01705 = " " + cb01705.Text;
            if (cb01705.Text == " ")
            {
                str01705 = "";
            }
            string str01706 = " " + cb01706.Text;
            if (cb01706.Text == " ")
            {
                str01706 = "";
            }
            string str01707 = cb01707.Text;
            if (cb01707.Text == " ")
            {
                str01707 = "";
            }
            string str01708, str01709, str01710;
            str01708 = str01701 + lb01702.Text + str01702;
            if (str01701 == "" && str01702 == "")
            {
                str01708 = "";
            }

            str01709 = str01703 + lb01703.Text + str01704;
            if (str01703 == "" && str01704 == "")
            {
                str01709 = "";
            }

            str01710 = str01705 + str01706 + lb01704.Text + str01707;
            if (str01705 == "" && str01706 == "" && str01707 == "")
            {
                str01710 = "";
            }

            string str017 = Environment.NewLine + " " + lb01701.Text + str01708 + str01709 + str01710;
            str017 = str017.Replace("'", "^");
            if (str01708 == "" && str01709 == "" && str01710 == "")
            {
                str017 = "";
            }
            //

            string str01801 = lb01801.Text + " " + cb01801.Text + " " + lb01802.Text;
            if (cb01801.Text == " ")
            {
                str01801 = "";
            }

            string str01802 = Environment.NewLine + lb01803.Text + tb01802.Text;

            string str01803 = lb01804.Text + tb01803.Text + lb01805.Text;
            if (tb01802.Text == "")
            {
                str01802 = "";
                str01803 = Environment.NewLine + lb01803.Text + tb01803.Text + lb01805.Text;
            }
            if (tb01803.Text == "")
            {
                str01803 = "";
                str01802 = lb01803.Text + tb01802.Text + lb01805.Text;
            }
            if (tb01802.Text == "" && tb01803.Text == "")
            {
                str01802 = "";
                str01803 = "";
            }

            string str018 = Environment.NewLine + " " + str01801 + str01802 + str01803;
            str018 = str018.Replace("'", "^");
            if (cb01801.Text == " " && tb01802.Text == "" && tb01803.Text == "")
            {
                str018 = "";
            }

            string str01901 = lb01901.Text + tb01901.Text;
            string str01902 = lb01902.Text + tb01902.Text + lb01903.Text;
            if (tb01901.Text == "")
            {
                str01901 = "";
                str01902 = lb01901.Text + tb01902.Text + lb01903.Text;
            }
            if (tb01902.Text == "")
            {
                str01902 = "";
                str01901 = lb01901.Text + tb01901.Text + lb01903.Text;
            }
            string str01903 = "";
            if (chb019031.Checked == true)
            {
                str01903 = Environment.NewLine + " " + chb019031.Text + lb01905.Text;
            }

            string str01904 = "";
            if (chb019032.Checked == true)
            {
                str01904 = Environment.NewLine + " " + chb019032.Text;
            }

            string str01905 = "";
            if (chb019033.Checked == true)
            {
                str01905 = Environment.NewLine + " " + chb019033.Text;
            }
            string str01906 = "";
            if (chb019033.Checked == true)
            {
                str01906 = " " + tb01903.Text;
            }
            string str01907 = Environment.NewLine + lb01906.Text + cb01904.Text;
            if (cb01904.Text == " ")
            {
                str01907 = "";
            }



            string str019 = Environment.NewLine + " " + str01901 + str01902 + str01903 + str01904 + str01905 + str01906 + str01907;
            str019 = str019.Replace("'", "^");
            if (tb01901.Text == "" && tb01902.Text == "" && tb01903.Text == "" && cb01904.Text == " ")
            {
                str019 = "";
            }

            string str02001, str02002, str02003;

            if (chb02001.Checked == true)
            {
                str02001 = lb02001.Text + " " + cb02002.Text;
                str02002 = " " + lb02002.Text + " " + tb02003.Text;
            }
            else
            {
                str02001 = "";
                str02002 = "";
            }

            if (chb02004.Checked == true)
            {
                str02003 = Environment.NewLine + chb02004.Text;
            }
            else
            {
                str02003 = "";
            }
            string str020 = Environment.NewLine + " " + str02001 + str02002 + " " + str02003;
            str020 = str020.Replace("'", "^");
            if (chb02001.Checked == false && chb02004.Checked == false)
            {
                str020 = "";
            }




            string strTBECTX = tbECTX.Text.Replace("\r\n", "\r\n ");
            string strECTX = Environment.NewLine + " " + strTBECTX;
            strECTX = strECTX.Replace("'", "^");
            string strTBNOTE = "     " + tbNOTE.Text.Replace("\r\n", "\r\n     ");
            string strNOTE = Environment.NewLine + " " + lbNOTE.Text + Environment.NewLine + strTBNOTE;
            strNOTE = strNOTE.Replace("'", "^");
            string strTBATX1 = " " + tbATX1.Text.Replace("\r\n", "\r\n     ");
            string strATX1 = Environment.NewLine + tbATX1.Text;
            strATX1 = strATX1.Replace("'", "^");

            string strTBATX2 = " " + tbATX2.Text.Replace("\r\n", "\r\n   ");
            strTBATX2 = strTBATX2.Replace("#. Histochemistry", "#. Histochemistry");
            string strATX2 = Environment.NewLine + strTBATX2;
            strATX2 = strATX2.Replace("'", "^");



            if (tbECTX.Text == "")
            {
                strECTX = "";
            }
            if (tbNOTE.Text == "")
            {
                strNOTE = "";
            }

            if (tbATX1.Text == "")
            {
                strATX1 = "";
            }
            if (tbATX2.Text == "")
            {
                strATX2 = "";
            }


            int n = 0;
            string[] ADD = new string[10];

            for (int i = 0; i < Convert.ToUInt32(dataGridView3.Rows.Count - 1); i++)
            {
                string str1 = dataGridView3.Rows[i].Cells[0].FormattedValue.ToString();
                string str2 = dataGridView3.Rows[i].Cells[1].FormattedValue.ToString();
                string str3 = dataGridView3.Rows[i].Cells[2].FormattedValue.ToString();
                str1 = str1.Replace("'", "^");
                str2 = str2.Replace("'", "^");
                str3 = str3.Replace("'", "^");
                n = i + 1;

                if (str1 != "" && str2 != "" && str3 != "")
                {

                    ADD[n] = Environment.NewLine + "  " + str1 + " : " + str2 + " , " + str3;
                }
                else if (str1 == "" && str2 == "" && str3 == "")
                {
                    ADD[n] = "";
                }
                else if (str1 != "" && str2 == "" && str3 == "")
                {
                    ADD[n] = Environment.NewLine + "  " + str1;
                }
                else if (str1 != "" && str2 != "" && str3 == "")
                {
                    ADD[n] = Environment.NewLine + "  " + str1 + " : " + str2;
                }

                totalAdd = ADD[1] + ADD[2] + ADD[3] + ADD[4] + ADD[5] + ADD[6] + ADD[7] + ADD[8];
                totalAdd = totalAdd.Replace("'", "^");
            }
            string DITX = lbt00001.Text + str001 + str002 + str003 + str004 + totalAdd2 + str005 + str006 + str007 + str008 + str009 + totalAdd3 + str010 + str011 + str012 + str013 + str014 + str015 + str016 + totalAdd4 + str017 + str018 + str019 + str020 + strECTX + strNOTE + strATX1 + totalAdd + strATX2;
            string NBLK = tbblock03.Text;
            NBLK = NBLK.Replace("'", "^");
            string ABLK = tbblock01.Text;
            ABLK = ABLK.Replace("'", "^");
            sql = sql.Replace("[PTNO]", PTNO);
            sql = sql.Replace("[OGTP]", HMTP);
            sql = sql.Replace("[DITX]", DITX);
            sql = sql.Replace("[ABLK]", ABLK);
            sql = sql.Replace("[NBLK]", NBLK);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            cmd.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DevExpress.XtraEditors.XtraMessageBox.Show("종료 하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
            else
            {
                return;
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.CurrentCell.EditType == typeof(DataGridViewComboBoxEditingControl))
            {
                SendKeys.Send("{F4}");
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentCell.EditType == typeof(DataGridViewComboBoxEditingControl))
            {
                SendKeys.Send("{F4}");
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView5.CurrentCell.EditType == typeof(DataGridViewComboBoxEditingControl))
            {
                SendKeys.Send("{F4}");
            }
        }


        //Color cellColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
        //Color headerColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
        //Color emptyColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
        //Color borderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
        //Color comboBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
        //private void InitGridStyle(System.Windows.Forms.DataGridView gv)
        //{
        //    //셀 색 지정
        //    gv.DefaultCellStyle.BackColor = cellColor;

        //    //해더색 지정
        //    gv.ColumnHeadersDefaultCellStyle.BackColor = headerColor;

        //    gv.EnableHeadersVisualStyles = false;
        //    gv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        //    gv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        //    gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        //    //비어있는 공간 색
        //    gv.BackgroundColor = emptyColor;

        //    //보더 색
        //    gv.GridColor = borderColor;

        //    //indicator 색
        //    gv.RowHeadersDefaultCellStyle.BackColor = cellColor;


        //    foreach (object column in gv.Columns)
        //    {
        //        if (column is System.Windows.Forms.DataGridViewComboBoxColumn)
        //        {
        //            System.Windows.Forms.DataGridViewComboBoxColumn comboColumn = column as System.Windows.Forms.DataGridViewComboBoxColumn;
        //            comboColumn.DefaultCellStyle.BackColor = comboBackColor;
        //            comboColumn.FlatStyle = FlatStyle.Flat;
        //        }
        //    }
        //}


        private void Breast_Load(object sender, EventArgs e)
        {
            try
            {
                CoreLibrary core = new CoreLibrary();
                core.InitGridStyle(dataGridView1);
                core.InitGridStyle(dataGridView2);
                core.InitGridStyle(dataGridView3);
                core.InitGridStyle(dataGridView5);

                dataGridView1.RowCount = 10;
                dataGridView2.RowCount = 6;
                dataGridView5.RowCount = 6;

                cbt00001.Items.Add(" ");
                cb00101.Items.Add(" ");
                cb00102.Items.Add(" ");
                cb00103.Items.Add(" ");

                cb00201.Items.Add(" ");
                cb00301.Items.Add(" ");
                cb00401.Items.Add(" ");
                cb00402.Items.Add(" ");
                cb00403.Items.Add(" ");
                cb00404.Items.Add(" ");

                cb00501.Items.Add(" ");
                cb00601.Items.Add(" ");
                cb00701.Items.Add(" ");
                cb00801.Items.Add(" ");
                cb00901.Items.Add(" ");

                cb01001.Items.Add(" ");

                cb01101.Items.Add(" ");
                cb01102.Items.Add(" ");
                cb01103.Items.Add(" ");
                cb01104.Items.Add(" ");
                cb01105.Items.Add(" ");
                cb01106.Items.Add(" ");
                cb01107.Items.Add(" ");

                cb01401.Items.Add(" ");
                cb01501.Items.Add(" ");
                cb01601.Items.Add(" ");

                cb01701.Items.Add(" ");
                cb01702.Items.Add(" ");
                cb01703.Items.Add(" ");
                cb01704.Items.Add(" ");
                cb01705.Items.Add(" ");
                cb01706.Items.Add(" ");
                cb01707.Items.Add(" ");

                cb01801.Items.Add(" ");

                cb01904.Items.Add(" ");
                cb02002.Items.Add(" ");

                string strSQL = Ini.strDB;

                Myconn = new MySqlConnection(strSQL);
                Myconn.Open();



                Insertcombo00001();
                //Insertcombo00101();
                Insertcombo00102();
                Insertcombo00103();

                Insertcombo00201();
                Insertcombo00301();
                Insertcombo00401();
                Insertcombo00402();
                Insertcombo00403();
                Insertcombo00404();
                Insertcombo00501();
                Insertcombo00601();
                Insertcombo00701();
                Insertcombo00801();
                Insertcombo00901();
                Insertcombo01001();
                Insertcombo01101();
                Insertcombo01102();
                Insertcombo01103();
                Insertcombo01104();
                Insertcombo01105();
                Insertcombo01106();
                Insertcombo01107();

                Insertcombo01401();
                Insertcombo01501();
                Insertcombo01601();

                Insertcombo01701();
                Insertcombo01702();
                Insertcombo01703();
                Insertcombo01704();
                Insertcombo01705();
                Insertcombo01706();
                Insertcombo01707();

                Insertcombo01801();
                Insertcombo01904();

                Insertcombo02002();

                String sql = "select TIT1, n0101, n0102, n0103, n0104, n0201, n0202, n0203, n0301, n0401, n0402, n0403, n0404, n0501, n0502, n0601, n0602, n0701, n0702, n0801, n0802,n0901,n0902, n1001, n1101, n1102, n1103, n1104, n1105, n1106, n1107, n1201,n1202,n1203,n1301,n1302,n1303,n1304,n1305,n1306,n1307,n1401,n1402,n1501,n1601,n1701,n1702,n1703,n1704,n1705,n1706,n1707,n1801,n1802,n1803,n1901,n1902,n1903,n1904,n1905,n1906,n1907,n2001,n2002,n2003,n2004,ECTX,NOTE,ATX1,ATX2 from PISBRS001 where PTNO ='[PTNO]'";

                sql = sql.Replace("[PTNO]", PTNO);

                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    cbt00001.SelectedIndex = selectData00001(dr[0].ToString());
                    tb00101.Text = dr[1].ToString().Replace("^", "'");
                    //cb00101.SelectedIndex = selectData00101(dr[1].ToString());
                    cb00102.SelectedIndex = selectData00102(dr[2].ToString());
                    cb00103.SelectedIndex = selectData00103(dr[3].ToString());
                    tb00104.Text = dr[4].ToString().Replace("^", "'");

                    cb00201.SelectedIndex = selectData00201(dr[5].ToString());
                    tb00202.Text = dr[6].ToString().Replace("^", "'");
                    tb00203.Text = dr[7].ToString().Replace("^", "'");


                    cb00301.SelectedIndex = selectData00301(dr[8].ToString());

                    cb00401.SelectedIndex = selectData00401(dr[9].ToString());
                    cb00402.SelectedIndex = selectData00402(dr[10].ToString());
                    cb00403.SelectedIndex = selectData00403(dr[11].ToString());
                    cb00404.SelectedIndex = selectData00404(dr[12].ToString());

                    cb00501.SelectedIndex = selectData00501(dr[13].ToString());
                    tb00502.Text = dr[14].ToString().Replace("^", "'");

                    cb00601.SelectedIndex = selectData00601(dr[15].ToString());
                    tb00602.Text = dr[16].ToString().Replace("^", "'");

                    cb00701.SelectedIndex = selectData00701(dr[17].ToString());
                    tb00702.Text = dr[18].ToString().Replace("^", "'");

                    cb00801.SelectedIndex = selectData00801(dr[19].ToString());
                    tb00802.Text = dr[20].ToString().Replace("^", "'");

                    cb00901.SelectedIndex = selectData00901(dr[21].ToString());
                    tb00902.Text = dr[22].ToString().Replace("^", "'");

                    cb01001.SelectedIndex = selectData01001(dr[23].ToString());

                    cb01101.SelectedIndex = selectData01101(dr[24].ToString());
                    cb01102.SelectedIndex = selectData01102(dr[25].ToString());
                    cb01103.SelectedIndex = selectData01103(dr[26].ToString());
                    cb01104.SelectedIndex = selectData01104(dr[27].ToString());
                    cb01105.SelectedIndex = selectData01105(dr[28].ToString());
                    cb01106.SelectedIndex = selectData01106(dr[29].ToString());
                    cb01107.SelectedIndex = selectData01107(dr[30].ToString());

                    tb01201.Text = dr[31].ToString().Replace("^", "'");
                    tb01202.Text = dr[32].ToString().Replace("^", "'");
                    tb01203.Text = dr[33].ToString().Replace("^", "'");

                    tb01301.Text = dr[34].ToString().Replace("^", "'");
                    tb01302.Text = dr[35].ToString().Replace("^", "'");
                    tb01303.Text = dr[36].ToString().Replace("^", "'");
                    tb01304.Text = dr[37].ToString().Replace("^", "'");
                    tb01305.Text = dr[38].ToString().Replace("^", "'");
                    tb01306.Text = dr[39].ToString().Replace("^", "'");
                    tb01307.Text = dr[40].ToString().Replace("^", "'");

                    cb01401.SelectedIndex = selectData01401(dr[41].ToString());
                    tb01402.Text = dr[42].ToString().Replace("^", "'");

                    cb01501.SelectedIndex = selectData01501(dr[43].ToString());

                    cb01601.SelectedIndex = selectData01601(dr[44].ToString());

                    cb01701.SelectedIndex = selectData01701(dr[45].ToString());
                    cb01702.SelectedIndex = selectData01702(dr[46].ToString());
                    cb01703.SelectedIndex = selectData01703(dr[47].ToString());
                    cb01704.SelectedIndex = selectData01704(dr[48].ToString());
                    cb01705.SelectedIndex = selectData01705(dr[49].ToString());
                    cb01706.SelectedIndex = selectData01706(dr[50].ToString());
                    cb01707.SelectedIndex = selectData01707(dr[51].ToString());

                    cb01801.SelectedIndex = selectData01801(dr[52].ToString());
                    tb01802.Text = dr[53].ToString().Replace("^", "'");
                    tb01803.Text = dr[54].ToString().Replace("^", "'");


                    tb01901.Text = dr[55].ToString().Replace("^", "'");
                    tb01902.Text = dr[56].ToString().Replace("^", "'");

                    //MessageBox.Show(dr[57].ToString().Replace("^", "'"));
                    //essageBox.Show(dr[58].ToString().Replace("^", "'"));
                    //MessageBox.Show(dr[59].ToString().Replace("^", "'"));
                    //MessageBox.Show(dr[60].ToString().Replace("^", "'"));
                    //MessageBox.Show(dr[61].ToString().Replace("^", "'"));
                    if (dr[57].ToString() == "Macrometastasis")
                    {
                        chb019031.Checked = true;
                    }
                    if (dr[58].ToString() == "Micrometastasis")
                    {
                        chb019032.Checked = true;
                    }
                    if (dr[59].ToString() == "isolated tumor cells")
                    {
                        chb019033.Checked = true;
                    }
                    if (chb019033.Checked == true)
                    {
                        tb01903.Text = dr[60].ToString().Replace("^", "'");
                    }

                    //tb01903.Text = dr[57].ToString().Replace("^", "'");

                    cb01904.SelectedIndex = selectData01904(dr[61].ToString());

                    if (dr[63].ToString() == "" || dr[62].ToString() == " ")
                    {
                        chb02001.Checked = false;
                    }
                    else
                    {
                        chb02001.Checked = true;
                    }

                    if (dr[65].ToString() == "")
                    {
                        chb02004.Checked = false;
                    }
                    else
                    {
                        chb02004.Checked = true;
                    }


                    cb02002.SelectedIndex = selectData02002(dr[63].ToString());
                    tb02003.Text = dr[64].ToString().Replace("^", "'");

                    tbECTX.Text = dr[66].ToString().Replace("^", "'");
                    tbNOTE.Text = dr[67].ToString().Replace("^", "'");
                    tbATX1.Text = dr[68].ToString().Replace("^", "'");
                    tbATX2.Text = dr[69].ToString().Replace("^", "'");
                    selectAdd();
                    selectAddgrid1();
                    selectAddgrid2();
                    selectAddgrid5();
                }
                dr.Close();

                Selectblock();
                //1025
                if (cbt00001.Text == "IDC")
                {

                    lb00201.Enabled = true;
                    lb00202.Enabled = true;
                    cb00201.Enabled = true;
                    tb00202.Enabled = true;
                    tb00203.Enabled = true;

                    lb00301.Enabled = true;
                    lb00302.Enabled = true;
                    cb00301.Enabled = true;


                    lb00401.Enabled = true;
                    lb00402.Enabled = true;
                    lb00403.Enabled = true;
                    lb00404.Enabled = true;
                    cb00401.Enabled = true;
                    cb00402.Enabled = true;
                    cb00403.Enabled = true;
                    cb00404.Enabled = true;

                    lb00501.Enabled = true;
                    cb00501.Enabled = true;
                    tb00502.Enabled = true;

                    lb00601.Enabled = true;
                    cb00601.Enabled = true;
                    tb00602.Enabled = true;

                    lb00701.Enabled = true;
                    cb00701.Enabled = true;
                    tb00702.Enabled = true;

                    lb00801.Enabled = true;
                    cb00801.Enabled = true;
                    tb00802.Enabled = true;

                    lb00901.Enabled = true;
                    cb00901.Enabled = true;
                    tb00902.Enabled = true;

                    lb01001.Enabled = true;
                    cb01001.Enabled = true;

                    lb01101.Enabled = true;
                    lb01102.Enabled = true;
                    lb01103.Enabled = true;
                    lb01104.Enabled = true;
                    cb01101.Enabled = true;
                    cb01102.Enabled = true;
                    cb01103.Enabled = true;
                    cb01104.Enabled = true;
                    cb01105.Enabled = true;
                    cb01106.Enabled = true;
                    cb01107.Enabled = true;

                    dataGridView1.Enabled = true;
                    dataGridView2.Enabled = true;

                    lb01201.Enabled = false;
                    tb01201.Enabled = false;
                    tb01202.Enabled = false;
                    tb01203.Enabled = false;
                    tb01201.Text = "";
                    tb01202.Text = "";
                    tb01203.Text = "";

                    lb01301.Enabled = false;
                    lb01302.Enabled = false;
                    lb01303.Enabled = false;
                    lb01304.Enabled = false;
                    lb01305.Enabled = false;
                    lb01306.Enabled = false;
                    lb01307.Enabled = false;
                    lb01308.Enabled = false;
                    lb01309.Enabled = false;
                    lb01310.Enabled = false;
                    lb01311.Enabled = false;
                    tb01301.Enabled = false;
                    tb01302.Enabled = false;
                    tb01303.Enabled = false;
                    tb01304.Enabled = false;
                    tb01305.Enabled = false;
                    tb01306.Enabled = false;
                    tb01307.Enabled = false;
                    tb01301.Text = "";
                    tb01302.Text = "";
                    tb01303.Text = "";
                    tb01304.Text = "";
                    tb01305.Text = "";
                    tb01306.Text = "";
                    tb01307.Text = "";


                    lb01401.Enabled = false;
                    cb01401.Enabled = false;
                    tb01402.Enabled = false;
                    cb01401.Text = " ";
                    tb01402.Text = "";

                    lb01501.Enabled = false;
                    cb01501.Enabled = false;
                    cb01501.Text = " ";

                    lb01601.Enabled = false;
                    cb01601.Enabled = false;
                    cb01601.Text = " ";

                    dataGridView5.Enabled = false;
                    dataGridView5.Rows.Clear();

                    lb01701.Enabled = false;
                    lb01702.Enabled = false;
                    lb01703.Enabled = false;
                    lb01704.Enabled = false;
                    cb01701.Enabled = false;
                    cb01702.Enabled = false;
                    cb01703.Enabled = false;
                    cb01704.Enabled = false;
                    cb01705.Enabled = false;
                    cb01706.Enabled = false;
                    cb01707.Enabled = false;
                    cb01701.Text = " ";
                    cb01702.Text = " ";
                    cb01703.Text = " ";
                    cb01704.Text = " ";
                    cb01705.Text = " ";
                    cb01706.Text = " ";
                    cb01707.Text = " ";




                }

                else if (cbt00001.Text == "DCIS")
                {
                    lb01201.Enabled = true;
                    tb01201.Enabled = true;
                    tb01202.Enabled = true;
                    tb01203.Enabled = true;


                    lb01301.Enabled = true;
                    lb01302.Enabled = true;
                    lb01303.Enabled = true;
                    lb01304.Enabled = true;
                    lb01305.Enabled = true;
                    lb01306.Enabled = true;
                    lb01307.Enabled = true;
                    lb01308.Enabled = true;
                    lb01309.Enabled = true;
                    lb01310.Enabled = true;
                    lb01311.Enabled = true;
                    tb01301.Enabled = true;
                    tb01302.Enabled = true;
                    tb01303.Enabled = true;
                    tb01304.Enabled = true;
                    tb01305.Enabled = true;
                    tb01306.Enabled = true;
                    tb01307.Enabled = true;



                    lb01401.Enabled = true;
                    cb01401.Enabled = true;
                    tb01402.Enabled = true;


                    lb01501.Enabled = true;
                    cb01501.Enabled = true;


                    lb01601.Enabled = true;
                    cb01601.Enabled = true;


                    dataGridView5.Enabled = true;

                    lb01701.Enabled = true;
                    lb01702.Enabled = true;
                    lb01703.Enabled = true;
                    lb01704.Enabled = true;
                    cb01701.Enabled = true;
                    cb01702.Enabled = true;
                    cb01703.Enabled = true;
                    cb01704.Enabled = true;
                    cb01705.Enabled = true;
                    cb01706.Enabled = true;
                    cb01707.Enabled = true;

                    lb00201.Enabled = false;
                    lb00202.Enabled = false;
                    cb00201.Enabled = false;
                    tb00202.Enabled = false;
                    tb00203.Enabled = false;
                    cb00201.Text = " ";
                    tb00202.Text = "";
                    tb00203.Text = "";

                    lb00301.Enabled = false;
                    lb00302.Enabled = false;
                    cb00301.Enabled = false;
                    cb00301.Text = " ";


                    lb00401.Enabled = false;
                    lb00402.Enabled = false;
                    lb00403.Enabled = false;
                    lb00404.Enabled = false;
                    cb00401.Enabled = false;
                    cb00402.Enabled = false;
                    cb00403.Enabled = false;
                    cb00404.Enabled = false;
                    cb00401.Text = " ";
                    cb00402.Text = " ";
                    cb00403.Text = " ";
                    cb00404.Text = " ";

                    lb00501.Enabled = false;
                    cb00501.Enabled = false;
                    tb00502.Enabled = false;
                    cb00501.Text = " ";
                    tb00502.Text = "";

                    lb00601.Enabled = false;
                    cb00601.Enabled = false;
                    tb00602.Enabled = false;
                    cb00601.Text = " ";
                    tb00602.Text = "";

                    lb00701.Enabled = false;
                    cb00701.Enabled = false;
                    tb00702.Enabled = false;
                    cb00701.Text = " ";
                    tb00702.Text = "";

                    lb00801.Enabled = false;
                    cb00801.Enabled = false;
                    tb00802.Enabled = false;
                    cb00801.Text = " ";
                    tb00802.Text = "";

                    lb00901.Enabled = false;
                    cb00901.Enabled = false;
                    tb00902.Enabled = false;
                    cb00901.Text = " ";
                    tb00902.Text = "";

                    lb01001.Enabled = false;
                    cb01001.Enabled = false;
                    cb01001.Text = " ";

                    lb01101.Enabled = false;
                    lb01102.Enabled = false;
                    lb01103.Enabled = false;
                    lb01104.Enabled = false;
                    cb01101.Enabled = false;
                    cb01102.Enabled = false;
                    cb01103.Enabled = false;
                    cb01104.Enabled = false;
                    cb01105.Enabled = false;
                    cb01106.Enabled = false;
                    cb01107.Enabled = false;
                    cb01101.Text = " ";
                    cb01102.Text = " ";
                    cb01103.Text = " ";
                    cb01104.Text = " ";
                    cb01105.Text = " ";
                    cb01106.Text = " ";
                    cb01107.Text = " ";

                    dataGridView1.Enabled = false;
                    dataGridView2.Enabled = false;

                    dataGridView1.Rows.Clear();
                    dataGridView2.Rows.Clear();

                }
                else
                {
                    lb01201.Enabled = true;
                    tb01201.Enabled = true;
                    tb01202.Enabled = true;
                    tb01203.Enabled = true;


                    lb01301.Enabled = true;
                    lb01302.Enabled = true;
                    lb01303.Enabled = true;
                    lb01304.Enabled = true;
                    lb01305.Enabled = true;
                    lb01306.Enabled = true;
                    lb01307.Enabled = true;
                    lb01308.Enabled = true;
                    lb01309.Enabled = true;
                    lb01310.Enabled = true;
                    lb01311.Enabled = true;
                    tb01301.Enabled = true;
                    tb01302.Enabled = true;
                    tb01303.Enabled = true;
                    tb01304.Enabled = true;
                    tb01305.Enabled = true;
                    tb01306.Enabled = true;
                    tb01307.Enabled = true;

                    lb01401.Enabled = true;
                    cb01401.Enabled = true;
                    tb01402.Enabled = true;

                    lb01501.Enabled = true;
                    cb01501.Enabled = true;

                    lb01601.Enabled = true;
                    cb01601.Enabled = true;

                    dataGridView5.Enabled = true;

                    lb01701.Enabled = true;
                    lb01702.Enabled = true;
                    lb01703.Enabled = true;
                    lb01704.Enabled = true;
                    cb01701.Enabled = true;
                    cb01702.Enabled = true;
                    cb01703.Enabled = true;
                    cb01704.Enabled = true;
                    cb01705.Enabled = true;
                    cb01706.Enabled = true;
                    cb01707.Enabled = true;

                    lb00201.Enabled = true;
                    lb00202.Enabled = true;
                    cb00201.Enabled = true;
                    tb00202.Enabled = true;
                    tb00203.Enabled = true;

                    lb00301.Enabled = true;
                    lb00302.Enabled = true;
                    cb00301.Enabled = true;


                    lb00401.Enabled = true;
                    lb00402.Enabled = true;
                    lb00403.Enabled = true;
                    lb00404.Enabled = true;
                    cb00401.Enabled = true;
                    cb00402.Enabled = true;
                    cb00403.Enabled = true;
                    cb00404.Enabled = true;

                    lb00501.Enabled = true;
                    cb00501.Enabled = true;
                    tb00502.Enabled = true;

                    lb00601.Enabled = true;
                    cb00601.Enabled = true;
                    tb00602.Enabled = true;

                    lb00701.Enabled = true;
                    cb00701.Enabled = true;
                    tb00702.Enabled = true;

                    lb00801.Enabled = true;
                    cb00801.Enabled = true;
                    tb00802.Enabled = true;

                    lb00901.Enabled = true;
                    cb00901.Enabled = true;
                    tb00902.Enabled = true;

                    lb01001.Enabled = true;
                    cb01001.Enabled = true;

                    lb01101.Enabled = true;
                    lb01102.Enabled = true;
                    lb01103.Enabled = true;
                    lb01104.Enabled = true;
                    cb01101.Enabled = true;
                    cb01102.Enabled = true;
                    cb01103.Enabled = true;
                    cb01104.Enabled = true;
                    cb01105.Enabled = true;
                    cb01106.Enabled = true;
                    cb01107.Enabled = true;

                    dataGridView1.Enabled = true;
                    dataGridView2.Enabled = true;


                }
            }
            catch (System.Exception ex)
            {
            }
        }



        private void Selectblock()
        {

            string sql = "select ABLK, NBLK from PISDIG001 where PTNO ='[PTNO]' and OGTP ='BRS'";
            sql = sql.Replace("[PTNO]", PTNO);
            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                tbblock01.Text = drc[0].ToString().Replace("^", "'");
                tbblock03.Text = drc[1].ToString().Replace("^", "'");

            }
            drc.Close();

        }

        private void selectAdd()
        {

            string sql = "select A101,A102,A103,A201,A202,A203,A301,A302,A303,A401,A402,A403,A501,A502,A503,A601,A602,A603,A701,A702,A703,A801,A802,A803,A901,A902,A903 from PISBRS001 where PTNO ='[PTNO]'";
            sql = sql.Replace("[PTNO]", PTNO);
            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();

            while (drc.Read())
            {

                if (drc[0].ToString() != "" || drc[1].ToString() != "" || drc[2].ToString() != "")
                {
                    dataGridView3.Rows.Add(drc[0].ToString(), drc[1].ToString(), drc[2].ToString());
                }
                if (drc[3].ToString() != "" || drc[4].ToString() != "" || drc[5].ToString() != "")
                {
                    dataGridView3.Rows.Add(drc[3].ToString(), drc[4].ToString(), drc[5].ToString());
                }
                if (drc[6].ToString() != "" || drc[7].ToString() != "" || drc[8].ToString() != "")
                {
                    dataGridView3.Rows.Add(drc[6].ToString(), drc[7].ToString(), drc[8].ToString());
                }
                if (drc[9].ToString() != "" || drc[10].ToString() != "" || drc[11].ToString() != "")
                {
                    dataGridView3.Rows.Add(drc[9].ToString(), drc[10].ToString(), drc[11].ToString());
                }
                if (drc[12].ToString() != "" || drc[13].ToString() != "" || drc[14].ToString() != "")
                {
                    dataGridView3.Rows.Add(drc[12].ToString(), drc[13].ToString(), drc[14].ToString());
                }
                if (drc[15].ToString() != "" || drc[16].ToString() != "" || drc[17].ToString() != "")
                {
                    dataGridView3.Rows.Add(drc[15].ToString(), drc[16].ToString(), drc[17].ToString());
                }
                if (drc[18].ToString() != "" || drc[19].ToString() != "" || drc[20].ToString() != "")
                {
                    dataGridView3.Rows.Add(drc[18].ToString(), drc[19].ToString(), drc[20].ToString());
                }
                if (drc[21].ToString() != "" || drc[22].ToString() != "" || drc[23].ToString() != "")
                {
                    dataGridView3.Rows.Add(drc[21].ToString(), drc[22].ToString(), drc[23].ToString());
                }
                if (drc[24].ToString() != "" || drc[25].ToString() != "" || drc[26].ToString() != "")
                {
                    dataGridView3.Rows.Add(drc[24].ToString(), drc[25].ToString(), drc[26].ToString());
                }

            }
            drc.Close();


        }

        private void selectAddgrid1()
        {
            dataGridView1.Rows.Clear();
            string sql = "select  S001,S002,S003,S004,S005,S006,S007,S101,S102,S103,S104,S105,S106,S107, S201,S202,S203,S204,S205,S206,S207,S301,S302,S303,S304,S305,S306,S307,S401,S402,S403,S404,S405,S406,S407,S501,S502,S503,S504,S505,S506,S507,S601,S602,S603,S604,S605,S606,S607,S701,S702,S703,S704,S705,S706,S707,S801,S802,S803,S804,S805,S806,S807,S901,S902,S903,S904,S905,S906,S907 from PISBRS001 where PTNO ='[PTNO]'";
            sql = sql.Replace("[PTNO]", PTNO);
            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();

            while (drc.Read())
            {

                if (drc[0].ToString() != "" || drc[1].ToString() != "" || drc[2].ToString() != "" || drc[3].ToString() != "" || drc[4].ToString() != "" || drc[5].ToString() != "" || drc[6].ToString() != "")
                {
                    dataGridView1.Rows.Add(drc[0].ToString(), drc[1].ToString(), drc[2].ToString(), drc[3].ToString(), drc[4].ToString(), drc[5].ToString(), drc[6].ToString());
                }
                if (drc[7].ToString() != "" || drc[8].ToString() != "" || drc[9].ToString() != "" || drc[10].ToString() != "" || drc[11].ToString() != "" || drc[12].ToString() != "" || drc[13].ToString() != "")
                {
                    dataGridView1.Rows.Add(drc[7].ToString(), drc[8].ToString(), drc[9].ToString(), drc[10].ToString(), drc[11].ToString(), drc[12].ToString(), drc[13].ToString());
                }
                if (drc[14].ToString() != "" || drc[15].ToString() != "" || drc[16].ToString() != "" || drc[17].ToString() != "" || drc[18].ToString() != "" || drc[19].ToString() != "" || drc[20].ToString() != "")
                {
                    dataGridView1.Rows.Add(drc[14].ToString(), drc[15].ToString(), drc[16].ToString(), drc[17].ToString(), drc[18].ToString(), drc[19].ToString(), drc[20].ToString());
                }
                if (drc[21].ToString() != "" || drc[22].ToString() != "" || drc[23].ToString() != "" || drc[24].ToString() != "" || drc[25].ToString() != "" || drc[26].ToString() != "" || drc[27].ToString() != "")
                {
                    dataGridView1.Rows.Add(drc[21].ToString(), drc[22].ToString(), drc[23].ToString(), drc[24].ToString(), drc[25].ToString(), drc[26].ToString(), drc[27].ToString());
                }
                if (drc[28].ToString() != "" || drc[29].ToString() != "" || drc[30].ToString() != "" || drc[31].ToString() != "" || drc[32].ToString() != "" || drc[33].ToString() != "" || drc[34].ToString() != "")
                {
                    dataGridView1.Rows.Add(drc[28].ToString(), drc[29].ToString(), drc[30].ToString(), drc[31].ToString(), drc[32].ToString(), drc[33].ToString(), drc[34].ToString());
                }
                if (drc[35].ToString() != "" || drc[36].ToString() != "" || drc[37].ToString() != "" || drc[38].ToString() != "" || drc[39].ToString() != "" || drc[40].ToString() != "" || drc[41].ToString() != "")
                {
                    dataGridView1.Rows.Add(drc[35].ToString(), drc[36].ToString(), drc[37].ToString(), drc[38].ToString(), drc[39].ToString(), drc[40].ToString(), drc[41].ToString());
                }
                if (drc[42].ToString() != "" || drc[43].ToString() != "" || drc[44].ToString() != "" || drc[45].ToString() != "" || drc[46].ToString() != "" || drc[47].ToString() != "" || drc[48].ToString() != "")
                {
                    dataGridView1.Rows.Add(drc[42].ToString(), drc[43].ToString(), drc[44].ToString(), drc[45].ToString(), drc[46].ToString(), drc[47].ToString(), drc[48].ToString());
                }
                if (drc[49].ToString() != "" || drc[50].ToString() != "" || drc[51].ToString() != "" || drc[52].ToString() != "" || drc[53].ToString() != "" || drc[54].ToString() != "" || drc[55].ToString() != "")
                {
                    dataGridView1.Rows.Add(drc[49].ToString(), drc[50].ToString(), drc[51].ToString(), drc[52].ToString(), drc[53].ToString(), drc[54].ToString(), drc[55].ToString());
                }
                if (drc[56].ToString() != "" || drc[57].ToString() != "" || drc[58].ToString() != "" || drc[59].ToString() != "" || drc[60].ToString() != "" || drc[61].ToString() != "" || drc[62].ToString() != "")
                {
                    dataGridView1.Rows.Add(drc[56].ToString(), drc[57].ToString(), drc[58].ToString(), drc[59].ToString(), drc[60].ToString(), drc[61].ToString(), drc[62].ToString());
                }
                if (drc[63].ToString() != "" || drc[64].ToString() != "" || drc[65].ToString() != "" || drc[66].ToString() != "" || drc[67].ToString() != "" || drc[68].ToString() != "" || drc[69].ToString() != "")
                {
                    dataGridView1.Rows.Add(drc[63].ToString(), drc[64].ToString(), drc[65].ToString(), drc[66].ToString(), drc[67].ToString(), drc[68].ToString(), drc[69].ToString());
                }

            }
            drc.Close();


        }

        private void selectAddgrid2()
        {
            dataGridView2.Rows.Clear();
            string sql = "select M101,M102,M103, M201,M202,M203,M301,M302,M303,M401,M402,M403,M501,M502,M503,M601,M602,M603 from PISBRS001 where PTNO ='[PTNO]'";
            sql = sql.Replace("[PTNO]", PTNO);
            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();

            while (drc.Read())
            {

                if (drc[0].ToString() != "" || drc[1].ToString() != "" || drc[2].ToString() != "")
                {
                    dataGridView2.Rows.Add(drc[0].ToString(), drc[1].ToString(), drc[2].ToString());
                }
                if (drc[3].ToString() != "" || drc[4].ToString() != "" || drc[5].ToString() != "")
                {
                    dataGridView2.Rows.Add(drc[3].ToString(), drc[4].ToString(), drc[5].ToString());
                }
                if (drc[6].ToString() != "" || drc[7].ToString() != "" || drc[8].ToString() != "")
                {
                    dataGridView2.Rows.Add(drc[6].ToString(), drc[7].ToString(), drc[8].ToString());
                }
                if (drc[9].ToString() != "" || drc[10].ToString() != "" || drc[11].ToString() != "")
                {
                    dataGridView2.Rows.Add(drc[9].ToString(), drc[10].ToString(), drc[11].ToString());
                }
                if (drc[12].ToString() != "" || drc[13].ToString() != "" || drc[14].ToString() != "")
                {
                    dataGridView2.Rows.Add(drc[12].ToString(), drc[13].ToString(), drc[14].ToString());
                }
                if (drc[15].ToString() != "" || drc[16].ToString() != "" || drc[17].ToString() != "")
                {
                    dataGridView2.Rows.Add(drc[15].ToString(), drc[16].ToString(), drc[17].ToString());
                }


            }
            drc.Close();


        }

        private void selectAddgrid5()
        {
            dataGridView5.Rows.Clear();
            string sql = "select G101,G102,G103, G201,G202,G203,G301,G302,G303,G401,G402,G403,G501,G502,G503,G601,G602,G603 from PISBRS001 where PTNO ='[PTNO]'";
            sql = sql.Replace("[PTNO]", PTNO);
            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();

            while (drc.Read())
            {

                if (drc[0].ToString() != "" || drc[1].ToString() != "" || drc[2].ToString() != "")
                {
                    dataGridView5.Rows.Add(drc[0].ToString(), drc[1].ToString(), drc[2].ToString());
                }
                if (drc[3].ToString() != "" || drc[4].ToString() != "" || drc[5].ToString() != "")
                {
                    dataGridView5.Rows.Add(drc[3].ToString(), drc[4].ToString(), drc[5].ToString());
                }
                if (drc[6].ToString() != "" || drc[7].ToString() != "" || drc[8].ToString() != "")
                {
                    dataGridView5.Rows.Add(drc[6].ToString(), drc[7].ToString(), drc[8].ToString());
                }
                if (drc[9].ToString() != "" || drc[10].ToString() != "" || drc[11].ToString() != "")
                {
                    dataGridView5.Rows.Add(drc[9].ToString(), drc[10].ToString(), drc[11].ToString());
                }
                if (drc[12].ToString() != "" || drc[13].ToString() != "" || drc[14].ToString() != "")
                {
                    dataGridView5.Rows.Add(drc[12].ToString(), drc[13].ToString(), drc[14].ToString());
                }
                if (drc[15].ToString() != "" || drc[16].ToString() != "" || drc[17].ToString() != "")
                {
                    dataGridView5.Rows.Add(drc[15].ToString(), drc[16].ToString(), drc[17].ToString());
                }


            }
            drc.Close();


        }




        private int selectData00001(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '00001'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00101(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '00101'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00102(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '00102'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00103(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '00103'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00201(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '00104'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00301(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '00301'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00401(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '00401'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00402(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '00402'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00403(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '00403'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00404(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '00404'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00501(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '00501'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00601(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '00601'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00701(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '00701'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00801(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '00801'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00901(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '00901'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData01001(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '01001'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData01101(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '01101'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData01102(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '01102'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData01103(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '01103'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData01104(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '01104'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData01105(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '01105'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData01106(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '01106'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData01107(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '01107'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData01401(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '01401'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData01501(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '01501'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData01601(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '01601'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData01701(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '01701'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData01702(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '01702'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData01703(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '01703'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData01704(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '01704'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData01705(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '01705'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData01706(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '01706'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData01707(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '01707'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData01801(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '01801'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData01904(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '01901'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData02002(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'BRS'and  SQNO = '02001'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private void Insertcombo00001()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00001";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbt00001.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00101()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00101";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00101.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }
        private void Insertcombo00102()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00102";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00102.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }
        private void Insertcombo00103()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00103";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00103.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00201()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00104";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00201.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }


        private void Insertcombo00301()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00301";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00301.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00401()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00401";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00401.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }


        private void Insertcombo00402()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00402";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00402.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }


        private void Insertcombo00403()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00403";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00403.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }


        private void Insertcombo00404()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00404";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00404.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00501()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00501";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00501.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00601()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00601";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00601.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00701()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00701";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00701.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00801()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00801";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00801.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00901()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00901";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00901.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01001()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01001";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01001.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01101()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01101";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01101.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01102()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01102";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01102.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01103()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01103";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01103.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01104()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01104";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01104.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01105()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01105";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01105.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01106()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01106";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01106.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01107()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01107";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01107.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01401()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01401";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01401.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01501()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01501";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01501.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01601()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01601";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01601.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01701()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01701";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01701.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01702()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01702";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01702.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01703()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01703";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01703.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01704()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01704";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01704.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01705()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01705";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01705.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01706()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01706";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01706.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01707()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01707";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01707.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01801()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01801";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01801.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01904()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01901";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01904.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo02002()
        {
            String sql = Ini.DBSelect;
            string SQNO = "02001";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb02002.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }



        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string NumberingText = (e.RowIndex + 1).ToString();

                // 글자 사이즈 구하기.
                SizeF stringSize = e.Graphics.MeasureString(NumberingText, Font);
                // 글자에 맞춰 좌표계산. 
                PointF StringPoint = new PointF
                (
                    Convert.ToSingle(dataGridView1.RowHeadersWidth - 3 - stringSize.Width),
                    Convert.ToSingle(e.RowBounds.Y) + dataGridView1[0, e.RowIndex].ContentBounds.Height * 0.3f
                );
                // 문자열 그리기.
                e.Graphics.DrawString
                (
                    NumberingText,
                    Font,
                    Brushes.Black,
                    StringPoint.X,
                    StringPoint.Y
                );
            }
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string NumberingText = (e.RowIndex + 1).ToString();

                // 글자 사이즈 구하기.
                SizeF stringSize = e.Graphics.MeasureString(NumberingText, Font);
                // 글자에 맞춰 좌표계산. 
                PointF StringPoint = new PointF
                (
                    Convert.ToSingle(dataGridView2.RowHeadersWidth - 3 - stringSize.Width),
                    Convert.ToSingle(e.RowBounds.Y) + dataGridView2[0, e.RowIndex].ContentBounds.Height * 0.3f
                );
                // 문자열 그리기.
                e.Graphics.DrawString
                (
                    NumberingText,
                    Font,
                    Brushes.Black,
                    StringPoint.X,
                    StringPoint.Y
                );
            }
        }


        private void dataGridView5_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string NumberingText = (e.RowIndex + 1).ToString();

                // 글자 사이즈 구하기.
                SizeF stringSize = e.Graphics.MeasureString(NumberingText, Font);
                // 글자에 맞춰 좌표계산. 
                PointF StringPoint = new PointF
                (
                    Convert.ToSingle(dataGridView1.RowHeadersWidth - 3 - stringSize.Width),
                    Convert.ToSingle(e.RowBounds.Y) + dataGridView1[0, e.RowIndex].ContentBounds.Height * 0.3f
                );
                // 문자열 그리기.
                e.Graphics.DrawString
                (
                    NumberingText,
                    Font,
                    Brushes.Black,
                    StringPoint.X,
                    StringPoint.Y
                );
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*
            dataGridView3.Rows.Clear();
            tbATX1.Text = "#. Immunohistochemistry";
            tbATX2.Text = "#. Histochemistry\r\nVanGieson elastic fiber\r\nMucicarmine\r\nMasson Trichrome";

            dataGridView3.Rows.Add("TIF-1", "", "");
            dataGridView3.Rows.Add("CK7", "", "");
            dataGridView3.Rows.Add("p63", "", "");
            dataGridView3.Rows.Add("CK5/6", "", "");
            dataGridView3.Rows.Add("ALK", "", "");
            dataGridView3.Rows.Add("p53", "", "");
          */
        }

        private void comboBox21_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.EditType == typeof(DataGridViewComboBoxEditingControl))
            {
                SendKeys.Send("{F4}");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select DITX from PISDIG001 where PTNO ='[PTNO]' and OGTP ='BRS'";
                sql = sql.Replace("[PTNO]", PTNO);
                string strSQL = Ini.strDB;
                MySqlConnection conn = new MySqlConnection(strSQL);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader drc = cmd.ExecuteReader();

                bool bRet = false;

                while (drc.Read())
                {
                    bRet = true;
                }

                if (bRet)
                {

                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("해당하는 병리번호에 저장된 텍스트가 존재하지 않습니다");
                    return;

                }


                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm.Name == "ViewTEXTcs")
                    {
                        openForm.WindowState = FormWindowState.Normal;

                        return;
                    }
                    openForm.Activate();

                }
                ViewTEXTcs dlg = new ViewTEXTcs();

                dlg.PTNO = PTNO;

                dlg.OGTP = HMTP;
                dlg.ShowDialog();
            }
            catch (System.Exception ex)
            {
            }
        }

        private void cbt00001_TextChanged(object sender, EventArgs e)
        {
            if (cbt00001.Text == "IDC")
            {

                lb00201.Enabled = true;
                lb00202.Enabled = true;
                cb00201.Enabled = true;
                tb00202.Enabled = true;
                tb00203.Enabled = true;

                lb00301.Enabled = true;
                lb00302.Enabled = true;
                cb00301.Enabled = true;


                lb00401.Enabled = true;
                lb00402.Enabled = true;
                lb00403.Enabled = true;
                lb00404.Enabled = true;
                cb00401.Enabled = true;
                cb00402.Enabled = true;
                cb00403.Enabled = true;
                cb00404.Enabled = true;

                lb00501.Enabled = true;
                cb00501.Enabled = true;
                tb00502.Enabled = true;

                lb00601.Enabled = true;
                cb00601.Enabled = true;
                tb00602.Enabled = true;

                lb00701.Enabled = true;
                cb00701.Enabled = true;
                tb00702.Enabled = true;

                lb00801.Enabled = true;
                cb00801.Enabled = true;
                tb00802.Enabled = true;

                lb00901.Enabled = true;
                cb00901.Enabled = true;
                tb00902.Enabled = true;

                lb01001.Enabled = true;
                cb01001.Enabled = true;

                lb01101.Enabled = true;
                lb01102.Enabled = true;
                lb01103.Enabled = true;
                lb01104.Enabled = true;
                cb01101.Enabled = true;
                cb01102.Enabled = true;
                cb01103.Enabled = true;
                cb01104.Enabled = true;
                cb01105.Enabled = true;
                cb01106.Enabled = true;
                cb01107.Enabled = true;

                dataGridView1.Enabled = true;
                dataGridView2.Enabled = true;

                lb01201.Enabled = false;
                tb01201.Enabled = false;
                tb01202.Enabled = false;
                tb01203.Enabled = false;
                tb01201.Text = "";
                tb01202.Text = "";
                tb01203.Text = "";

                lb01301.Enabled = false;
                lb01302.Enabled = false;
                lb01303.Enabled = false;
                lb01304.Enabled = false;
                lb01305.Enabled = false;
                lb01306.Enabled = false;
                lb01307.Enabled = false;
                lb01308.Enabled = false;
                lb01309.Enabled = false;
                lb01310.Enabled = false;
                lb01311.Enabled = false;
                tb01301.Enabled = false;
                tb01302.Enabled = false;
                tb01303.Enabled = false;
                tb01304.Enabled = false;
                tb01305.Enabled = false;
                tb01306.Enabled = false;
                tb01307.Enabled = false;
                tb01301.Text = "";
                tb01302.Text = "";
                tb01303.Text = "";
                tb01304.Text = "";
                tb01305.Text = "";
                tb01306.Text = "";
                tb01307.Text = "";


                lb01401.Enabled = false;
                cb01401.Enabled = false;
                tb01402.Enabled = false;
                cb01401.Text = " ";
                tb01402.Text = "";

                lb01501.Enabled = false;
                cb01501.Enabled = false;
                cb01501.Text = " ";

                lb01601.Enabled = false;
                cb01601.Enabled = false;
                cb01601.Text = " ";

                dataGridView5.Enabled = false;
                dataGridView5.Rows.Clear();

                lb01701.Enabled = false;
                lb01702.Enabled = false;
                lb01703.Enabled = false;
                lb01704.Enabled = false;
                cb01701.Enabled = false;
                cb01702.Enabled = false;
                cb01703.Enabled = false;
                cb01704.Enabled = false;
                cb01705.Enabled = false;
                cb01706.Enabled = false;
                cb01707.Enabled = false;
                cb01701.Text = " ";
                cb01702.Text = " ";
                cb01703.Text = " ";
                cb01704.Text = " ";
                cb01705.Text = " ";
                cb01706.Text = " ";
                cb01707.Text = " ";




            }

            else if (cbt00001.Text == "DCIS")
            {
                lb01201.Enabled = true;
                tb01201.Enabled = true;
                tb01202.Enabled = true;
                tb01203.Enabled = true;


                lb01301.Enabled = true;
                lb01302.Enabled = true;
                lb01303.Enabled = true;
                lb01304.Enabled = true;
                lb01305.Enabled = true;
                lb01306.Enabled = true;
                lb01307.Enabled = true;
                lb01308.Enabled = true;
                lb01309.Enabled = true;
                lb01310.Enabled = true;
                lb01311.Enabled = true;
                tb01301.Enabled = true;
                tb01302.Enabled = true;
                tb01303.Enabled = true;
                tb01304.Enabled = true;
                tb01305.Enabled = true;
                tb01306.Enabled = true;
                tb01307.Enabled = true;



                lb01401.Enabled = true;
                cb01401.Enabled = true;
                tb01402.Enabled = true;


                lb01501.Enabled = true;
                cb01501.Enabled = true;


                lb01601.Enabled = true;
                cb01601.Enabled = true;


                dataGridView5.Enabled = true;

                lb01701.Enabled = true;
                lb01702.Enabled = true;
                lb01703.Enabled = true;
                lb01704.Enabled = true;
                cb01701.Enabled = true;
                cb01702.Enabled = true;
                cb01703.Enabled = true;
                cb01704.Enabled = true;
                cb01705.Enabled = true;
                cb01706.Enabled = true;
                cb01707.Enabled = true;

                lb00201.Enabled = false;
                lb00202.Enabled = false;
                cb00201.Enabled = false;
                tb00202.Enabled = false;
                tb00203.Enabled = false;
                cb00201.Text = " ";
                tb00202.Text = "";
                tb00203.Text = "";

                lb00301.Enabled = false;
                lb00302.Enabled = false;
                cb00301.Enabled = false;
                cb00301.Text = " ";


                lb00401.Enabled = false;
                lb00402.Enabled = false;
                lb00403.Enabled = false;
                lb00404.Enabled = false;
                cb00401.Enabled = false;
                cb00402.Enabled = false;
                cb00403.Enabled = false;
                cb00404.Enabled = false;
                cb00401.Text = " ";
                cb00402.Text = " ";
                cb00403.Text = " ";
                cb00404.Text = " ";

                lb00501.Enabled = false;
                cb00501.Enabled = false;
                tb00502.Enabled = false;
                cb00501.Text = " ";
                tb00502.Text = "";

                lb00601.Enabled = false;
                cb00601.Enabled = false;
                tb00602.Enabled = false;
                cb00601.Text = " ";
                tb00602.Text = "";

                lb00701.Enabled = false;
                cb00701.Enabled = false;
                tb00702.Enabled = false;
                cb00701.Text = " ";
                tb00702.Text = "";

                lb00801.Enabled = false;
                cb00801.Enabled = false;
                tb00802.Enabled = false;
                cb00801.Text = " ";
                tb00802.Text = "";

                lb00901.Enabled = false;
                cb00901.Enabled = false;
                tb00902.Enabled = false;
                cb00901.Text = " ";
                tb00902.Text = "";

                lb01001.Enabled = false;
                cb01001.Enabled = false;
                cb01001.Text = " ";

                lb01101.Enabled = false;
                lb01102.Enabled = false;
                lb01103.Enabled = false;
                lb01104.Enabled = false;
                cb01101.Enabled = false;
                cb01102.Enabled = false;
                cb01103.Enabled = false;
                cb01104.Enabled = false;
                cb01105.Enabled = false;
                cb01106.Enabled = false;
                cb01107.Enabled = false;
                cb01101.Text = " ";
                cb01102.Text = " ";
                cb01103.Text = " ";
                cb01104.Text = " ";
                cb01105.Text = " ";
                cb01106.Text = " ";
                cb01107.Text = " ";

                dataGridView1.Enabled = false;
                dataGridView2.Enabled = false;

                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();

            }
            else
            {
                lb01201.Enabled = true;
                tb01201.Enabled = true;
                tb01202.Enabled = true;
                tb01203.Enabled = true;


                lb01301.Enabled = true;
                lb01302.Enabled = true;
                lb01303.Enabled = true;
                lb01304.Enabled = true;
                lb01305.Enabled = true;
                lb01306.Enabled = true;
                lb01307.Enabled = true;
                lb01308.Enabled = true;
                lb01309.Enabled = true;
                lb01310.Enabled = true;
                lb01311.Enabled = true;
                tb01301.Enabled = true;
                tb01302.Enabled = true;
                tb01303.Enabled = true;
                tb01304.Enabled = true;
                tb01305.Enabled = true;
                tb01306.Enabled = true;
                tb01307.Enabled = true;

                lb01401.Enabled = true;
                cb01401.Enabled = true;
                tb01402.Enabled = true;

                lb01501.Enabled = true;
                cb01501.Enabled = true;

                lb01601.Enabled = true;
                cb01601.Enabled = true;

                dataGridView5.Enabled = true;

                lb01701.Enabled = true;
                lb01702.Enabled = true;
                lb01703.Enabled = true;
                lb01704.Enabled = true;
                cb01701.Enabled = true;
                cb01702.Enabled = true;
                cb01703.Enabled = true;
                cb01704.Enabled = true;
                cb01705.Enabled = true;
                cb01706.Enabled = true;
                cb01707.Enabled = true;

                lb00201.Enabled = true;
                lb00202.Enabled = true;
                cb00201.Enabled = true;
                tb00202.Enabled = true;
                tb00203.Enabled = true;

                lb00301.Enabled = true;
                lb00302.Enabled = true;
                cb00301.Enabled = true;


                lb00401.Enabled = true;
                lb00402.Enabled = true;
                lb00403.Enabled = true;
                lb00404.Enabled = true;
                cb00401.Enabled = true;
                cb00402.Enabled = true;
                cb00403.Enabled = true;
                cb00404.Enabled = true;

                lb00501.Enabled = true;
                cb00501.Enabled = true;
                tb00502.Enabled = true;

                lb00601.Enabled = true;
                cb00601.Enabled = true;
                tb00602.Enabled = true;

                lb00701.Enabled = true;
                cb00701.Enabled = true;
                tb00702.Enabled = true;

                lb00801.Enabled = true;
                cb00801.Enabled = true;
                tb00802.Enabled = true;

                lb00901.Enabled = true;
                cb00901.Enabled = true;
                tb00902.Enabled = true;

                lb01001.Enabled = true;
                cb01001.Enabled = true;

                lb01101.Enabled = true;
                lb01102.Enabled = true;
                lb01103.Enabled = true;
                lb01104.Enabled = true;
                cb01101.Enabled = true;
                cb01102.Enabled = true;
                cb01103.Enabled = true;
                cb01104.Enabled = true;
                cb01105.Enabled = true;
                cb01106.Enabled = true;
                cb01107.Enabled = true;

                dataGridView1.Enabled = true;
                dataGridView2.Enabled = true;


            }
        }

        private void tb01301_KeyPress(object sender, KeyPressEventArgs e)
        {
            int nPreLen = 3;
            int nPostLen = 1;

            if (e.KeyChar == '\b')
                return;

            //sender 로부터 텍스트 박스 구함
            TextBox editor = sender as TextBox;

            //소숫점의 점(dot)이 포함되어 있는지 여부.
            //단, 현재 selection 상태인 텍스트에 점이 포함되어 있으면 비포함으로 간주
            bool bDotContains = editor.Text.Contains(".") && !editor.SelectedText.Contains(".");

            //전체 길이 체크를 위한 변수(selection 길이는 뺀다)
            int nTextLen = editor.Text.Length - editor.SelectedText.Length;
            //현재 커서 위치
            int nCursor = editor.SelectionStart;

            //점과 숫자 이외의 값은 받아들이지 않음.
            if (e.KeyChar != '.' && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            //소숫점 이하 값이 없는 경우 - 2010.12.29 추가
            else if (e.KeyChar == '.' && nPostLen < 1)
                e.Handled = true;
            //점이 포함되어 있을 경우
            else if (bDotContains)
            {
                //전체 길이 체크 정수부와 소수부의 길이 더하기 점의 길이보다 같거나 크면 받아들이지 않음.
                //또한, 이미 점이 포함되어 있으므로, 점이 들어오면 받아들이지 않음.
                if (nTextLen >= nPreLen + nPostLen + 1 || e.KeyChar == '.')
                    e.Handled = true;
                else
                {
                    //점의 위치를 구한다.
                    int nDotPos = editor.Text.IndexOf('.');
                    //텍스트를 정수부와 소수부로 나눈다.
                    string[] sSep = editor.Text.Split('.');

                    //현재 커서가 점 앞에 있고, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
                    if (nDotPos > nCursor && sSep[0].Length >= nPreLen)
                        e.Handled = true;
                    //현재 커서가 점 뒤에 있고, 소수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
                    else if (nDotPos < nCursor && sSep[1].Length >= nPostLen)
                        e.Handled = true;
                }
            }
            //들어온 값이 점이 아니고, 현재 텍스트가 점을 포함하지 않으면
            //현재 값은 정수인데, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
            else if (e.KeyChar != '.' && !bDotContains && nTextLen >= nPreLen)
                e.Handled = true;
        }

        private void tb01302_KeyPress(object sender, KeyPressEventArgs e)
        {
            int nPreLen = 3;
            int nPostLen = 1;

            if (e.KeyChar == '\b')
                return;

            //sender 로부터 텍스트 박스 구함
            TextBox editor = sender as TextBox;

            //소숫점의 점(dot)이 포함되어 있는지 여부.
            //단, 현재 selection 상태인 텍스트에 점이 포함되어 있으면 비포함으로 간주
            bool bDotContains = editor.Text.Contains(".") && !editor.SelectedText.Contains(".");

            //전체 길이 체크를 위한 변수(selection 길이는 뺀다)
            int nTextLen = editor.Text.Length - editor.SelectedText.Length;
            //현재 커서 위치
            int nCursor = editor.SelectionStart;

            //점과 숫자 이외의 값은 받아들이지 않음.
            if (e.KeyChar != '.' && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            //소숫점 이하 값이 없는 경우 - 2010.12.29 추가
            else if (e.KeyChar == '.' && nPostLen < 1)
                e.Handled = true;
            //점이 포함되어 있을 경우
            else if (bDotContains)
            {
                //전체 길이 체크 정수부와 소수부의 길이 더하기 점의 길이보다 같거나 크면 받아들이지 않음.
                //또한, 이미 점이 포함되어 있으므로, 점이 들어오면 받아들이지 않음.
                if (nTextLen >= nPreLen + nPostLen + 1 || e.KeyChar == '.')
                    e.Handled = true;
                else
                {
                    //점의 위치를 구한다.
                    int nDotPos = editor.Text.IndexOf('.');
                    //텍스트를 정수부와 소수부로 나눈다.
                    string[] sSep = editor.Text.Split('.');

                    //현재 커서가 점 앞에 있고, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
                    if (nDotPos > nCursor && sSep[0].Length >= nPreLen)
                        e.Handled = true;
                    //현재 커서가 점 뒤에 있고, 소수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
                    else if (nDotPos < nCursor && sSep[1].Length >= nPostLen)
                        e.Handled = true;
                }
            }
            //들어온 값이 점이 아니고, 현재 텍스트가 점을 포함하지 않으면
            //현재 값은 정수인데, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
            else if (e.KeyChar != '.' && !bDotContains && nTextLen >= nPreLen)
                e.Handled = true;
        }

        private void tb01305_KeyPress(object sender, KeyPressEventArgs e)
        {
            int nPreLen = 3;
            int nPostLen = 1;

            if (e.KeyChar == '\b')
                return;

            //sender 로부터 텍스트 박스 구함
            TextBox editor = sender as TextBox;

            //소숫점의 점(dot)이 포함되어 있는지 여부.
            //단, 현재 selection 상태인 텍스트에 점이 포함되어 있으면 비포함으로 간주
            bool bDotContains = editor.Text.Contains(".") && !editor.SelectedText.Contains(".");

            //전체 길이 체크를 위한 변수(selection 길이는 뺀다)
            int nTextLen = editor.Text.Length - editor.SelectedText.Length;
            //현재 커서 위치
            int nCursor = editor.SelectionStart;

            //점과 숫자 이외의 값은 받아들이지 않음.
            if (e.KeyChar != '.' && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            //소숫점 이하 값이 없는 경우 - 2010.12.29 추가
            else if (e.KeyChar == '.' && nPostLen < 1)
                e.Handled = true;
            //점이 포함되어 있을 경우
            else if (bDotContains)
            {
                //전체 길이 체크 정수부와 소수부의 길이 더하기 점의 길이보다 같거나 크면 받아들이지 않음.
                //또한, 이미 점이 포함되어 있으므로, 점이 들어오면 받아들이지 않음.
                if (nTextLen >= nPreLen + nPostLen + 1 || e.KeyChar == '.')
                    e.Handled = true;
                else
                {
                    //점의 위치를 구한다.
                    int nDotPos = editor.Text.IndexOf('.');
                    //텍스트를 정수부와 소수부로 나눈다.
                    string[] sSep = editor.Text.Split('.');

                    //현재 커서가 점 앞에 있고, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
                    if (nDotPos > nCursor && sSep[0].Length >= nPreLen)
                        e.Handled = true;
                    //현재 커서가 점 뒤에 있고, 소수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
                    else if (nDotPos < nCursor && sSep[1].Length >= nPostLen)
                        e.Handled = true;
                }
            }
            //들어온 값이 점이 아니고, 현재 텍스트가 점을 포함하지 않으면
            //현재 값은 정수인데, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
            else if (e.KeyChar != '.' && !bDotContains && nTextLen >= nPreLen)
                e.Handled = true;
        }

        private void dataGridView5_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView5.CurrentCell.EditType == typeof(DataGridViewComboBoxEditingControl))
            {
                SendKeys.Send("{F4}");
            }
        }

        private void cbt00001_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lb01305_Click(object sender, EventArgs e)
        {

        }

        private void tb01303_TextChanged(object sender, EventArgs e)
        {

        }

        private void lb01306_Click(object sender, EventArgs e)
        {

        }

        private void tb01304_TextChanged(object sender, EventArgs e)
        {

        }

        private void lb01308_Click(object sender, EventArgs e)
        {

        }

        private void lb01307_Click(object sender, EventArgs e)
        {

        }

        private void tb01305_TextChanged(object sender, EventArgs e)
        {

        }

        private void lb01309_Click(object sender, EventArgs e)
        {

        }

        private void lb01308_Click_1(object sender, EventArgs e)
        {

        }

        private void tb01305_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void lb01309_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string[] strData = null;
            dataGridView3.Rows.Clear();

            string strCode = "";
            if (MainForm.EMROpen())
            {
                strCode = MainForm.EMRPIASearch(PTNO);
                if (strCode != "")
                {
                    strData = MainForm.GetPIACode(strCode);
                }
            }

            if (strData != null)
            {
                for (int i = 0; i < strData.Length; i++)
                {
                    if (strData[i] != null)
                        dataGridView3.Rows.Add(strData[i], "", "");
                }
                tbATX1.Text = "#. Immunohistochemistry";
                tbATX2.Text = "#. Histochemistry\r\nVanGieson elastic fiber\r\nMucicarmine\r\nMasson Trichrome";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("정보를 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sql = "delete from pisBRS001 where ptno = '[PTNO]'";
                    sql = sql.Replace("[PTNO]", PTNO);
                    MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                    cmd.ExecuteNonQuery();
                    DevExpress.XtraEditors.XtraMessageBox.Show("삭제되었습니다");
                    reset();
                    DeleteMain();
                }
                else
                {
                    return;
                }
            }
            catch (System.Exception ex)
            {
            }
        }

        private void DeleteMain()
        {
            string sql = "Update PISDIG001 set  DITX = '', ABLK = '',NBLK = '',OGTP ='',GRTX ='' where PTNO = '[PTNO]'";
            sql = sql.Replace("[PTNO]", PTNO);
            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            cmd.ExecuteNonQuery();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.EditType == typeof(DataGridViewComboBoxEditingControl))
            {
                SendKeys.Send("{F4}");
            }
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentCell.EditType == typeof(DataGridViewComboBoxEditingControl))
            {
                SendKeys.Send("{F4}");
            }
        }

        private void dataGridView5_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView5.CurrentCell.EditType == typeof(DataGridViewComboBoxEditingControl))
            {
                SendKeys.Send("{F4}");
            }
        }

        private void dataGridView3_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.CurrentCell.EditType == typeof(DataGridViewComboBoxEditingControl))
            {
                SendKeys.Send("{F4}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stage dlg = new Stage();
            dlg.Show();
        }



        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Ini.G_IniWriteValue("Info", "PTNO", PTNO, Ini.strPath);
            string path = System.Environment.CurrentDirectory + "\\Library.exe";
            string serverpath = Ini.LibraryPath;
            try
            {
                FileInfo file = new FileInfo(serverpath); //프로그램 업데이트
                file.CopyTo(path, true);
            }
            catch (SystemException ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("파일복사 실패");
            }
            Process.Start(path);
        }

    }
}
