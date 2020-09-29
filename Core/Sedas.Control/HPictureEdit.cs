using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedas.Control
{
    public partial class HPictureEdit : DevExpress.XtraEditors.PictureEdit
    {
        public HPictureEdit()
        {
            InitializeComponent();
        }

        public HPictureEdit(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
