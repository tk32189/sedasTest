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
    public partial class Diagnosis1 : Form
    {
        public string strDis;
        public Diagnosis1()
        {
            InitializeComponent();
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

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tb4.Text = "";
            tb3.Text = "";
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
            listBox1.Items.Clear();
            if (comboBox5.SelectedIndex == 0)
            {
                listBox1.Items.Add("Lung");
                listBox1.Items.Add("Breast");
                listBox1.Items.Add("Stomach");
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
            if (listBox1.SelectedIndex == 0)
            {
                textBox6.Text = "  2. Tumor Focality \r\n" +
                                "     Unifocal \r\n" +
                                "     Separate tumor nodules in same lobe \r\n" +
                                "     Separate tumor nodules in different lobes\r\n" +
                                "     Synchronous carcinomas \r\n" +
                                "     Cannot be determined\r\n" +
                                "  3. Tumor Site \r\n" +
                                "     Upper lobe / Middle lobe / Lower lobe \r\n" +
                                "     Other(s) (specify): \r\n" +
                                "     Not specified\r\n" +
                                "  4. Tumor size :          cm\r\n" +
                                "  5. Histologic grade :\r\n" +
                                "   ( Well / moderately / poorly ) differentiated  \r\n" +
                                "   Undifferentiated\r\n" +
                                "  6. Visceral Pleura Invasion \r\n" +
                                "    Not identified / Indeterminate \r\n" +
                                "    Present, Tumor penetrates beyond the elastic layer of visceral pleura on elastic-Van Gieson stain.\r\n" +
                                "  7. Microscopic Tumor Extension \r\n" +
                                "    Not applicable \r\n" +
                                "    Not identified \r\n" +
                                "    Superficial spreading tumor with invasive component limited to bronchial wall \r\n" +
                                "    Tumor is  surrounded by lung or visceral pleura, without evidence of invasion more\r\n" +
                                "    proximal than the lobar bronchus (ie, not in the main bronchus).\r\n" +
                                "    Tumor involves main bronchus 2 cm or more distal to the carina. \r\n" +
                                "    Tumor in the main bronchus less than 2 cm distal to the carina but does not involve \r\n" +
                                "    the carina.\r\n" +
                                "  8. Margins\r\n" +
                                "    Bronchial Margin \r\n" +
                                "     Not applicable / Cannot be assessed \r\n" +
                                "     Uninvolved by invasive carcinoma \r\n" +
                                "      Distance from tumor :  cm\r\n" +
                                "     Involved by invasive carcinoma \r\n" +
                                "      Squamous cell carcinoma in situ (CIS) present at bronchial margin \r\n" +
                                "      Squamous cell carcinoma in situ (CIS) not identified at bronchial margin\r\n" +
                                "     Vascular Margin \r\n" +
                                "       Not applicable / Cannot be assessed \r\n" +
                                "       Uninvolved by invasive carcinoma \r\n" +
                                "       Involved by invasive carcinoma\r\n" +
                                "     Parenchymal Margin \r\n" +
                                "       Uninvolved by invasive carcinoma \r\n" +
                                "       Involved by invasive carcinoma\r\n" +
                                "     Parietal Pleural Margin \r\n" +
                                "      Uninvolved by invasive carcinoma\r\n" +
                                "      Involved by invasive carcinoma\r\n" +
                                "  9. Tumor Associated Atelectasis or Obstructive Pneumonitis \r\n" +
                                "     Not identified\r\n" +
                                "     Extends to the hilar region but does not involve entire lung\r\n" +
                                "     Involves entire lung\r\n" +
                                "  10. Lymphatic invasion : Not identified / Present / Indeterminate\r\n" +
                                "  11. Vascular invasion : Not identified / Present / Indeterminate\r\n" +
                                "  12. Perineural invasion : Not identified / Present / Indeterminate\r\n" +
                                "  13. Additional Pathologic Findings \r\n" +
                                "      None identified \r\n" +
                                "      Atypical adenomatous hyperplasia \r\n" +
                                "      Squamous dysplasia / Metaplasia (specify type)\r\n" +
                                "      Diffuse neuroendocrine hyperplasia \r\n" +
                                "      Inflammation (specify type)\r\n" +
                                "      Emphysema\r\n" +
                                "  14. Pathologic Staging :";
            }
            else if (listBox1.SelectedIndex == 1)
            {
                textBox6.Text = //"1) Breast, (upper outer), (right/left), (quadrantectomy/modified radical mastectomy) :\r\n"+
                                "  - INVASIVE DUCTAL CARCINOMA, NOS, with\r\n"+
                                "    Other type: \r\n"+
                                "    Grade: (well/moderately/poorly) differentiated by Nottingham's combined histologic grade\r\n"+
                                "    (total score = ; tubule formation= , nuclear grade= , mitosis= )\r\n"+
                                "  Size:  x  x  cm\r\n"+
                                "        Maximum dimension on one slice:  (slice # )\r\n"+
                                "        Numbers of involving slices : (  ) consecutive slices ( , slice #  to #  )\r\n"+
                                "    Lymphovascular invasion: present/absent\r\n"+
                                "    Necrosis: present/absent\r\n"+
                                "    Microcalcifications in tumor: present/absent\r\n"+
                                "    Dermal lymphatic involvement: present/absent\r\n"+
                                "    Nipple involvement (Paget's): present/absent\r\n"+
                                "    Margins: negative\r\n"+
                                "       Distance to closest margin:  cm to deep margin\r\n"+
                                "    Additional foci of invasive carcinoma: present/absent\r\n"+
                                "    TNM staging: pT   pN (see NOTE 1)  M.\r\n"+
                                "- DUCTAL CARCINOMA IN SITU, grade 2, \r\n"+
                                "     admixed with and adjacent to invasive component.\r\n"+
                                "     Size/Extent: cm x cm\r\n"+
                                "         Dimension (1): maximum extent on one slice:  cm\r\n"+
                                "         Dimension (2): involving  (  ) slices ( cm, slice #  to #  )\r\n"+
                                "        Type: solid, cribriform, micropapillary, comedo type\r\n"+
                                "        Necrosis: present\r\n"+
                                "        Microcalcifications in tumor: present\r\n"+
                                "        Margins: negative \r\n"+
                                "           Distance to closest margin: cm to deep margin.\r\n"+
                                "2) Lymph node, axillary, (right/left), lymphadenectomy :\r\n"+
                                "    - No tumor (0/2).\r\n"+
                                "        Two of five lymph nodes positive for metastatic carcinoma (2/5)\r\n"+
                                "           Macrometastasis (>2mm)\r\n"+
                                "           Extracapsular extension: present\r\n"+
                                "\r\n"+
                                "NOTE 1: History of (positive/negative) sentinel lymph nodes,   /   (S16-          ).\r\n"+
                                "    \r\n"+
                                "NOTE 2: The result of immunostaining for ER, PR, Her/2, p53 and Ki67 will be followed. ";
            }
            else if (listBox1.SelectedIndex == 2)
            {
                textBox6.Text = "  Gastrointestinal stromal tumor, moderate risk of malignant potential (NIH 2001),\r\n" +
                                "    Stage II (T2/high mitosis)(AJCC 7th edition)\r\n" +
                                "     1) tumor size : 4.2x4.0x3.3cm\r\n" +
                                "     2) mitosis: 49/50HPFs, Ki-67 proliferation index: 10%\r\n" +
                                "     3) C-kit(+)/CD34(+)/SMA(focal+)/desmin(-)/S-100 protein(-)\r\n" +
                                "     4) submucosa to subserosa\r\n" +
                                "     5) spindle cell type with mild nuclear atypia/moderate increased cellularity\r\n" +
                                "     6) no definite lymphovascular tumor emboli\r\n" +
                                "     7) presence of hemorrhage and necrosis\r\n" +
                                "     8) resection margins, free of tumor.";
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox5.Text = "";
            if (listBox1.SelectedIndex == 0)
            {
                textBox5.Text = "  2. Tumor Focality \r\n" +
                                "     Unifocal \r\n" +
                                "     Separate tumor nodules in same lobe \r\n" +
                                "     Separate tumor nodules in different lobes\r\n" +
                                "     Synchronous carcinomas \r\n" +
                                "     Cannot be determined\r\n" +
                                "  3. Tumor Site \r\n" +
                                "     Upper lobe / Middle lobe / Lower lobe \r\n" +
                                "     Other(s) (specify): \r\n" +
                                "     Not specified\r\n" +
                                "  4. Tumor size :          cm\r\n" +
                                "  5. Histologic grade :\r\n" +
                                "   ( Well / moderately / poorly ) differentiated  \r\n" +
                                "   Undifferentiated\r\n" +
                                "  6. Visceral Pleura Invasion \r\n" +
                                "    Not identified / Indeterminate \r\n" +
                                "    Present, Tumor penetrates beyond the elastic layer of visceral pleura on elastic-Van Gieson stain.\r\n" +
                                "  7. Microscopic Tumor Extension \r\n" +
                                "    Not applicable \r\n" +
                                "    Not identified \r\n" +
                                "    Superficial spreading tumor with invasive component limited to bronchial wall \r\n" +
                                "    Tumor is  surrounded by lung or visceral pleura, without evidence of invasion more\r\n" +
                                "    proximal than the lobar bronchus (ie, not in the main bronchus).\r\n" +
                                "    Tumor involves main bronchus 2 cm or more distal to the carina. \r\n" +
                                "    Tumor in the main bronchus less than 2 cm distal to the carina but does not involve \r\n" +
                                "    the carina.\r\n" +
                                "  8. Margins\r\n" +
                                "    Bronchial Margin \r\n" +
                                "     Not applicable / Cannot be assessed \r\n" +
                                "     Uninvolved by invasive carcinoma \r\n" +
                                "      Distance from tumor :  cm\r\n" +
                                "     Involved by invasive carcinoma \r\n" +
                                "      Squamous cell carcinoma in situ (CIS) present at bronchial margin \r\n" +
                                "      Squamous cell carcinoma in situ (CIS) not identified at bronchial margin\r\n" +
                                "     Vascular Margin \r\n" +
                                "       Not applicable / Cannot be assessed \r\n" +
                                "       Uninvolved by invasive carcinoma \r\n" +
                                "       Involved by invasive carcinoma\r\n" +
                                "     Parenchymal Margin \r\n" +
                                "       Uninvolved by invasive carcinoma \r\n" +
                                "       Involved by invasive carcinoma\r\n" +
                                "     Parietal Pleural Margin \r\n" +
                                "      Uninvolved by invasive carcinoma\r\n" +
                                "      Involved by invasive carcinoma\r\n" +
                                "  9. Tumor Associated Atelectasis or Obstructive Pneumonitis \r\n" +
                                "     Not identified\r\n" +
                                "     Extends to the hilar region but does not involve entire lung\r\n" +
                                "     Involves entire lung\r\n" +
                                "  10. Lymphatic invasion : Not identified / Present / Indeterminate\r\n" +
                                "  11. Vascular invasion : Not identified / Present / Indeterminate\r\n" +
                                "  12. Perineural invasion : Not identified / Present / Indeterminate\r\n" +
                                "  13. Additional Pathologic Findings \r\n" +
                                "      None identified \r\n" +
                                "      Atypical adenomatous hyperplasia \r\n" +
                                "      Squamous dysplasia / Metaplasia (specify type)\r\n" +
                                "      Diffuse neuroendocrine hyperplasia \r\n" +
                                "      Inflammation (specify type)\r\n" +
                                "      Emphysema\r\n" +
                                "  14. Pathologic Staging :";
            }
            else if (listBox1.SelectedIndex == 1)
            {
                textBox5.Text = //"1) Breast, (upper outer), (right/left), (quadrantectomy/modified radical mastectomy) :\r\n" +
                                "  - INVASIVE DUCTAL CARCINOMA, NOS, with\r\n" +
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
                                "           Distance to closest margin: cm to deep margin.\r\n" +
                                "2) Lymph node, axillary, (right/left), lymphadenectomy :\r\n" +
                                "    - No tumor (0/2).\r\n" +
                                "        Two of five lymph nodes positive for metastatic carcinoma (2/5)\r\n" +
                                "           Macrometastasis (>2mm)\r\n" +
                                "           Extracapsular extension: present\r\n" +
                                "\r\n" +
                                "NOTE 1: History of (positive/negative) sentinel lymph nodes,   /   (S16-          ).\r\n" +
                                "    \r\n" +
                                "NOTE 2: The result of immunostaining for ER, PR, Her/2, p53 and Ki67 will be followed. ";
            }
            else if (listBox1.SelectedIndex == 2)
            {
                /*textBox5.Text = "   2. Location: upper/ middle/ lower third), Center at (antrum, body, cardia) and (anterior wall, posterior wall, lesser curvature, greater curvature)\r\n" +
                                "   3. Gross type: EGC type 0-(I / IIa /IIb / IIc / III + I / IIa / IIb / IIc / III)\r\n" +
                                "                 Borrmann type (I / II / III / IV)\r\n" +
                                "   4. Tumor size: cm\r\n" +
                                "   5. Histologic grade: Tubular, (well / moderately) differentitated\r\n" +
                                "        Poorly differentiated, (non-solid/solid)  \r\n" +
                                "   6. Histologic type by Lauren : Intestinal / Diffuse\r\n" +
                                "   7. Growth pattern: Not applicable / Mixed expanding and diffuse infiltrative growth / Expanding growth / Diffuse infiltrative growth \r\n" +
                                "   8. Microscopic Tumor Extension \r\n" +
                                "        Adenocarcinoma in situ without laminapropria invasion (pTis)\r\n" +
                                "        Tumor invades lamina propria (pT1a)\r\n" +
                                "        Tumor invades but not through muscularis mucosae (pT1a)\r\n" +
                                "        Tumor invades submucosa (sm1, 2, 3) (pT1b)\r\n" +
                                "          depth of sm invasion from mm: um/ total thickness of sm: um\r\n" +
                                "        Tumor invades but not through muscularis propria (pT2)\r\n" +
                                "        Tumor penetrates subserosal connective tissue (pT3)  \r\n" +
                                "        Tumor invades serosa (visceral peritoneum) (pT4a)\r\n" +
                                "        Tumor invades into the (esophageal / duodenal wall (specify depth))\r\n" +
                                "        Tumor invades adjacent structures (pT4b)\r\n" +
                                "   9. Margins (Proximal Margin, Distal margin) and Anvil ring\r\n" +
                                "        Uninvolved by invasive carcinoma / Involved by invasive carcinoma\r\n" +
                                "          Uninvolved by dysplasia / Involved by dysplasia/ Cannot be assessed \r\n" +
                                "           safety margin: proximal cm, distal cm\r\n" +
                                "  10. Lymph node metastasis : \r\n" +
                                "        No metastasis in ( ) regional lymph nodes (pN0)\r\n" +
                                "         [GC, 0/ ; LC, 0/]\r\n" +
                                "        Metastasis to   out of  regional lymph nodes (pN)\r\n" +
                                "         [GC, / ; LC, / ;  ]\r\n" +
                                "  11. Lymphatic invasion: Not identified / Present / Indeterminate\r\n" +
                                "  12. Venous invasion: Not identified / Present / Indeterminate\r\n" +
                                "  13. Perineural invasion: Not identified / Present / Indeterminate\r\n" +
                                "  14. Additional Pathologic Findings : Not identified.";*/
                textBox5.Text = "  Gastrointestinal stromal tumor, moderate risk of malignant potential (NIH 2001),\r\n"+
                                "    Stage II (T2/high mitosis)(AJCC 7th edition)\r\n"+
                                "     1) tumor size : 4.2x4.0x3.3cm\r\n"+
                                "     2) mitosis: 49/50HPFs, Ki-67 proliferation index: 10%\r\n"+
                                "     3) C-kit(+)/CD34(+)/SMA(focal+)/desmin(-)/S-100 protein(-)\r\n"+
                                "     4) submucosa to subserosa\r\n"+
                                "     5) spindle cell type with mild nuclear atypia/moderate increased cellularity\r\n"+
                                "     6) no definite lymphovascular tumor emboli\r\n"+
                                "     7) presence of hemorrhage and necrosis\r\n"+
                                "     8) resection margins, free of tumor.";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strImmuno = "";
            for (int i = 0; i < dataGridView1.Rows.Count; i++ )
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
            strDis = tb1.Text + "\r\n" + tb2.Text + "\r\n " + tb3.Text + "\r\n  1. Histologic type :\r\n    " + tb4.Text + "\r\n" + textBox5.Text +  "\r\n\r\n" + 
                     textBox7.Text + "\r\n" + strImmuno + "\r\n" + textBox8.Text;
            Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Diagnosis1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.EditType == typeof(DataGridViewComboBoxEditingControl))
            {
                SendKeys.Send("{F4}");
            }
        }

    }
}
