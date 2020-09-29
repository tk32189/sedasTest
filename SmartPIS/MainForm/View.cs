using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartPIS
{
    public partial class View : Form
    {
        public string strMSG;
        public string strPTNO;
        public View()
        {
            InitializeComponent();
        }

        private void View_Load(object sender, EventArgs e)
        {
            label1.Text = "병리번호 : " + strPTNO;
            textBox1.Text = strMSG;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
