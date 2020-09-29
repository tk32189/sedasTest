using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedas.Control
{
    public partial class HFlowLayoutPanel : System.Windows.Forms.FlowLayoutPanel
    {
        public HFlowLayoutPanel()
        {
            InitializeComponent();
        }

        public HFlowLayoutPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
