using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void hSimpleButton1_Click(object sender, EventArgs e)
        {
            Sedas.Control.HSimpleButton button = new Sedas.Control.HSimpleButton();
            hFlowLayoutPanel1.Controls.Add(button);
        }
    }
}
