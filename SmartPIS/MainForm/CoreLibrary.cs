using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPIS
{
    public class CoreLibrary
    {
        Color grid_cellColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
        Color grid_headerColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
        Color grid_emptyColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
        Color grid_borderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
        Color grid_comboBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));

        public void InitGridStyle(System.Windows.Forms.DataGridView gv)
        {
            //셀 색 지정
            gv.DefaultCellStyle.BackColor = grid_cellColor;

            //해더색 지정
            gv.ColumnHeadersDefaultCellStyle.BackColor = grid_headerColor;

            gv.EnableHeadersVisualStyles = false;
            gv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            gv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //비어있는 공간 색
            gv.BackgroundColor = grid_emptyColor;

            //보더 색
            gv.GridColor = grid_borderColor;

            //indicator 색
            gv.RowHeadersDefaultCellStyle.BackColor = grid_cellColor;


            foreach (object column in gv.Columns)
            {
                if (column is System.Windows.Forms.DataGridViewComboBoxColumn)
                {
                    System.Windows.Forms.DataGridViewComboBoxColumn comboColumn = column as System.Windows.Forms.DataGridViewComboBoxColumn;
                    comboColumn.DefaultCellStyle.BackColor = grid_comboBackColor;
                    comboColumn.FlatStyle = FlatStyle.Flat;
                }
            }
        }
    }
}
