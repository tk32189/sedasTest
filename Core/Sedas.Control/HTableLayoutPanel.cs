using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedas.Control
{
    public partial class HTableLayoutPanel : System.Windows.Forms.TableLayoutPanel
    {
        public HTableLayoutPanel()
        {
            InitializeComponent();
        }

        public HTableLayoutPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
