using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedas.Control
{
    public partial class HLabelControl : DevExpress.XtraEditors.LabelControl
    {
        public HLabelControl()
        {
            InitializeComponent();
        }

        public HLabelControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
