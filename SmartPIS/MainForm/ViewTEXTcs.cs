using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SmartPIS
{
    public partial class ViewTEXTcs : Form
    {
       
        public string PTNO;
        public string OGTP;

        public ViewTEXTcs()
        {
            InitializeComponent();
        }

        private void ViewTEXTcs_Load(object sender, EventArgs e)
        {
            try
            {

                textBox2.Text = PTNO;

                string sql = "select DITX from PISDIG001 where PTNO ='[PTNO]'and OGTP = '[OGTP]'";
                sql = sql.Replace("[PTNO]", PTNO);
                sql = sql.Replace("[OGTP]", OGTP);
                string strSQL = Ini.strDB;
                MySqlConnection conn = new MySqlConnection(strSQL);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader drc = cmd.ExecuteReader();
                while (drc.Read())
                {
                    textBox1.Text = drc.GetString(0).Replace("^", "'");
                }
                drc.Close();
            }
            catch (System.Exception ex)
            {
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Close();
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.A)
                {
                    textBox1.SelectAll();
                }
            }
        }

        
       }
    }
   

