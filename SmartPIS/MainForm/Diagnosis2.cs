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
    public partial class Diagnosis2 : Form
    {
        public int nRow;
        public string strDis;
        public Diagnosis2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strImmuno = "", strTxt="";
            for (int j = 0; j < dataGridView2.Rows.Count; j++)
            {
                if (dataGridView2.Rows[j].Cells[0].FormattedValue.ToString() != "")
                    strTxt += "   " + (j + 2).ToString() + ". " + dataGridView2.Rows[j].Cells[0].Value.ToString() + ":\r\n     " + dataGridView2.Rows[j].Cells[1].Value.ToString() + "\r\n";
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].FormattedValue.ToString() != "")
                {
                    strImmuno += "  " + dataGridView1.Rows[i].Cells[0].FormattedValue.ToString() + " : " + dataGridView1.Rows[i].Cells[1].FormattedValue.ToString();
                    if (dataGridView1.Rows[i].Cells[2].FormattedValue.ToString() != "")
                        strImmuno += " (" + dataGridView1.Rows[i].Cells[2].FormattedValue.ToString() + ")\r\n";
                    else
                        strImmuno += "\r\n";
                }
            }

            strDis = tb1.Text + "\r\n" + tb2.Text + "\r\n" + tb3.Text + "\r\n   1. Histologic type :\r\n    " + tb4.Text + "\r\n" + strTxt + "\r\n\r\n" + 
                     textBox7.Text + "\r\n" + strImmuno + "\r\n" + textBox8.Text;
            Close();            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb1.Text = comboBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb2.Text = comboBox2.Text;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb3.Text = comboBox3.Text;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb4.Text = comboBox4.Text;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            if (comboBox5.SelectedIndex == 0)
            {                
                dataGridView2.Rows.Add("Tumor Focality");
                dataGridView2.Rows.Add("Tumor Site");
                dataGridView2.Rows.Add("Tumor Size");
                dataGridView2.Rows.Add("Histologic grade");
                dataGridView2.Rows.Add("Visceral Pleura Invasion");
                dataGridView2.Rows.Add("Microscopic Tumor Extension");
                dataGridView2.Rows.Add("Margins");
                dataGridView2.Rows.Add("Tumor Associated Atelectasis or Obstuctive Pneumonitis");
                dataGridView2.Rows.Add("Lymphatic invasion");
                dataGridView2.Rows.Add("Vascular invasion");
                dataGridView2.Rows.Add("Perineural invasion");
                dataGridView2.Rows.Add("Additional Pathologic Findings");
                dataGridView2.Rows.Add("Pathologic Staging");
            }
            else if (comboBox5.SelectedIndex == 1)
            {
                dataGridView2.Rows.Add("Breast");
                dataGridView2.Rows.Add("Lymph node");
            }
            else if (comboBox5.SelectedIndex == 2)
            {
                dataGridView2.Rows.Add("tumor size");
                dataGridView2.Rows.Add("mitosis");
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {            
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    textBox2.Text = "    Unifocal\r\n    Separate tumor nodules in same lobe\r\n    separate tumor nodules in different lobes\r\n    Synchronous carcinomas\r\n    Cannot be determined";
                    break;
                case 1:
                    textBox2.Text = "    Upper lobe / Middle lobe / Lower lobe\r\n    Other(s) (specify): \r\n    Not specified";
                    break;
                case 2:
                    textBox2.Text = "        cm";
                    break;
                case 3:
                    textBox2.Text = "    ( Well / moderately / poorly ) differentiated\r\n    Undifferentiated";
                    break;
                case 4:
                    textBox2.Text = "    Not identified / Indeterminate\r\n    Present, Tumor penetrates beyoun the elastic layer of visceral pleura on elastic-Van Gieson stain.";
                    break;
                case 5:
                    textBox2.Text = "    Not applicable\r\n    Not identified\r\n    Superficial spreading tumor with invasive component limited to bronchial wall Tumor is surrounded by "+
                                    "lung or visceral pleura, without evidence of invasion more\r\n     proximal than the lobar bronchus (ie, not in the main bronchus).\r\n    "+
                                    "Tumor involves main bronchus 2 cm or more distal to the carina.\r\n    Tumor in the main bronchus less than 2 cm distal to the carina but does not involve\r\n    the carina.";
                    break;
                case 6:
                    textBox2.Text = "    Bronchial Margin\r\n  Not applicable / Cannot be assessed\r\n  Uninvolved by invasive carcinoma\r\n   Distance from tumor :    cm"+
                                    "Parietal Pleural Margin\r\n  Uninvolved by invasive carcinoma";
                    break;
                case 7:
                    textBox2.Text = "    Focally present.";
                    break;
                case 8:
                    textBox2.Text = "    Not identified";
                    break;
                case 9:
                    textBox2.Text = "    PRESENT, MUTIFOCAL.";
                    break;
                case 10:
                    textBox2.Text = "    Not identified";
                    break;
                case 11:
                    textBox2.Text = "    Emphysema\r\n    Metastasis in one peribronchial lymph node (1/1).";
                    break;
                case 12:
                    textBox2.Text = " pT4 N1";
                    break;
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    textBox1.Text = "    Unifocal\r\n    Separate tumor nodules in same lobe\r\n    separate tumor nodules in different lobes\r\n    Synchronous carcinomas\r\n    Cannot be determined";
                    break;
                case 1:
                    textBox1.Text = "    Upper lobe / Middle lobe / Lower lobe\r\n    Other(s) (specify): \r\n    Not specified";
                    break;
                case 2:
                    textBox1.Text = "        cm";
                    break;
                case 3:
                    textBox1.Text = "    ( Well / moderately / poorly ) differentiated\r\n    Undifferentiated";
                    break;
                case 4:
                    textBox1.Text = "    Not identified / Indeterminate\r\n    Present, Tumor penetrates beyoun the elastic layer of visceral pleura on elastic-Van Gieson stain.";
                    break;
                case 5:
                    textBox1.Text = "    Not applicable\r\n    Not identified\r\n    Superficial spreading tumor with invasive component limited to bronchial wall Tumor is surrounded by " +
                                    "lung or visceral pleura, without evidence of invasion more\r\n     proximal than the lobar bronchus (ie, not in the main bronchus).\r\n    " +
                                    "Tumor involves main bronchus 2 cm or more distal to the carina.\r\n    Tumor in the main bronchus less than 2 cm distal to the carina but does not involve\r\n    the carina.";
                    break;
                case 6:
                    textBox1.Text = "    Bronchial Margin\r\n  Not applicable / Cannot be assessed\r\n  Uninvolved by invasive carcinoma\r\n   Distance from tumor :    cm" +
                                    "Parietal Pleural Margin\r\n  Uninvolved by invasive carcinoma";
                    break;
                case 7:
                    textBox1.Text = "    Focally present.";
                    break;
                case 8:
                    textBox1.Text = "    Not identified";
                    break;
                case 9:
                    textBox1.Text = "    PRESENT, MUTIFOCAL.";
                    break;
                case 10:
                    textBox1.Text = "    Not identified";
                    break;
                case 11:
                    textBox1.Text = "    Emphysema\r\n    Metastasis in one peribronchial lymph node (1/1).";
                    break;
                case 12:
                    textBox1.Text = " pT4 N1";
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox7.Text = "#. Immunohistochemistry";
            textBox8.Text = "#. Histochemistry\r\nVanGieson elastic fiber\r\nMucicarmine\r\nMasson Trichrome";

            dataGridView1.Rows.Add("TIF-1", "", "");
            dataGridView1.Rows.Add("CK7", "", "");
            dataGridView1.Rows.Add("p63", "", "");
            dataGridView1.Rows.Add("CK5/6", "", "");
            dataGridView1.Rows.Add("ALK", "", "");
            dataGridView1.Rows.Add("p53", "", "");
        }

        private void Diagnosis2_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.Rows[nRow].Cells[1].Value = textBox1.Text;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                nRow = e.RowIndex;
                if (comboBox5.SelectedIndex == 0)
                {
                    switch (e.RowIndex)
                    {
                        case 0:
                            textBox2.Text = "    Unifocal\r\n    Separate tumor nodules in same lobe\r\n    separate tumor nodules in different lobes\r\n    Synchronous carcinomas\r\n    Cannot be determined";
                            break;
                        case 1:
                            textBox2.Text = "    Upper lobe / Middle lobe / Lower lobe\r\n    Other(s) (specify): \r\n    Not specified";
                            break;
                        case 2:
                            textBox2.Text = "        cm";
                            break;
                        case 3:
                            textBox2.Text = "    ( Well / moderately / poorly ) differentiated\r\n    Undifferentiated";
                            break;
                        case 4:
                            textBox2.Text = "    Not identified / Indeterminate\r\n    Present, Tumor penetrates beyoun the elastic layer of visceral pleura on elastic-Van Gieson stain.";
                            break;
                        case 5:
                            textBox2.Text = "    Not applicable\r\n    Not identified\r\n    Superficial spreading tumor with invasive component limited to bronchial wall Tumor is surrounded by " +
                                            "lung or visceral pleura, without evidence of invasion more\r\n     proximal than the lobar bronchus (ie, not in the main bronchus).\r\n    " +
                                            "Tumor involves main bronchus 2 cm or more distal to the carina.\r\n    Tumor in the main bronchus less than 2 cm distal to the carina but does not involve\r\n    the carina.";
                            break;
                        case 6:
                            textBox2.Text = "    Bronchial Margin\r\n  Not applicable / Cannot be assessed\r\n  Uninvolved by invasive carcinoma\r\n   Distance from tumor :    cm" +
                                            "Parietal Pleural Margin\r\n  Uninvolved by invasive carcinoma";
                            break;
                        case 7:
                            textBox2.Text = "    Focally present.";
                            break;
                        case 8:
                            textBox2.Text = "    Not identified";
                            break;
                        case 9:
                            textBox2.Text = "    PRESENT, MUTIFOCAL.";
                            break;
                        case 10:
                            textBox2.Text = "    Not identified";
                            break;
                        case 11:
                            textBox2.Text = "    Emphysema\r\n    Metastasis in one peribronchial lymph node (1/1).";
                            break;
                        case 12:
                            textBox2.Text = " pT4 N1";
                            break;
                    }
                }
                else if (comboBox5.SelectedIndex == 1)
                {
                    switch (e.RowIndex)
                    {
                        case 0:
                            textBox2.Text = "  - INVASIVE DUCTAL CARCINOMA, NOS, with\r\n" +
                                            "    Other type: \r\n" +
                                            "    Grade: (well/moderately/poorly) differentiated by Nottingham's combined histologic grade\r\n" +
                                            "    (total score = ; tubule formation= , nuclear grade= , mitosis= )\r\n" +
                                            "  Size:  x  x  cm\r\n" +
                                            "        Maximum dimension on one slice:  (slice # )\r\n" +
                                            "        Numbers of involving slices : (  ) consecutive slices ( , slice #  to #  )\r\n" +
                                            "    Lymphovascular invasion: present/absent\r\n" +
                                            "    Necrosis: present/absent\r\n" +
                                            "    Microcalcifications in tumor: present/absent\r\n" +
                                            "    Dermal lymphatic involvement: present/absent\r\n" +
                                            "    Nipple involvement (Paget's): present/absent\r\n" +
                                            "    Margins: negative\r\n" +
                                            "       Distance to closest margin:  cm to deep margin\r\n" +
                                            "    Additional foci of invasive carcinoma: present/absent\r\n" +
                                            "    TNM staging: pT   pN (see NOTE 1)  M.\r\n" +
                                            "- DUCTAL CARCINOMA IN SITU, grade 2, \r\n" +
                                            "     admixed with and adjacent to invasive component.\r\n" +
                                            "     Size/Extent: cm x cm\r\n" +
                                            "         Dimension (1): maximum extent on one slice:  cm\r\n" +
                                            "         Dimension (2): involving  (  ) slices ( cm, slice #  to #  )\r\n" +
                                            "        Type: solid, cribriform, micropapillary, comedo type\r\n" +
                                            "        Necrosis: present\r\n" +
                                            "        Microcalcifications in tumor: present\r\n" +
                                            "        Margins: negative \r\n" +
                                            "           Distance to closest margin: cm to deep margin.\r\n";
                            break;
                        case 1:
                            textBox2.Text = "    - No tumor (0/2).\r\n" +
                                            "        Two of five lymph nodes positive for metastatic carcinoma (2/5)\r\n" +
                                            "           Macrometastasis (>2mm)\r\n" +
                                            "           Extracapsular extension: present\r\n" +
                                            "\r\n" +
                                            "NOTE 1: History of (positive/negative) sentinel lymph nodes,   /   (S16-          ).\r\n" +
                                            "    \r\n" +
                                            "NOTE 2: The result of immunostaining for ER, PR, Her/2, p53 and Ki67 will be followed. ";
                            break;                        
                    }
                }
                else if (comboBox5.SelectedIndex == 2)
                {
                    switch (e.RowIndex)
                    {
                        case 0:
                            textBox2.Text = "     cm";
                            break;
                        case 1:
                            textBox2.Text = "     %";
                            break;
                    }
                }

                //listBox1.SelectedIndex = e.RowIndex;
                textBox1.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (System.Exception ex)
            {
            	
            }            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text;
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.EditType == typeof(DataGridViewComboBoxEditingControl))
            {
                SendKeys.Send("{F4}");
            }
        }


    }
}
