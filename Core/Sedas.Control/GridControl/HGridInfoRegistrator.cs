using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;


namespace Sedas.Control.GridControl
{
    public partial class HGridInfoRegistrator : GridInfoRegistrator
    {
        public HGridInfoRegistrator()
        {
            InitializeComponent();
        }

        public HGridInfoRegistrator(IContainer container)
        {
            //container.Add(this);

            InitializeComponent();
        }

        public override string ViewName
        {
            get
            {
                return "GridView";
            }
        }

        public override BaseView CreateView(DevExpress.XtraGrid.GridControl gridControl)
        {
            return new HGridView(gridControl);
        }

    }
}
