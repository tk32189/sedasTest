using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedas.Control
{
    public partial class HTabControl : DevExpress.XtraTab.XtraTabControl
    {
        public HTabControl()
        {
            InitializeComponent();
        }

        public HTabControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
