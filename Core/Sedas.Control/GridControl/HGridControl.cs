using DevExpress.XtraGrid.Registrator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedas.Control.GridControl
{
    public partial class HGridControl : DevExpress.XtraGrid.GridControl
    {
        public HGridControl()
        {
            InitializeComponent();
        }

        public HGridControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        protected override void RegisterAvailableViewsCore(InfoCollection infoCollection)
        {
            infoCollection.Clear();
            infoCollection.Add(new HGridInfoRegistrator());
            infoCollection.Add(new BandedGridInfoRegistrator());
            infoCollection.Add(new AdvBandedGridInfoRegistrator());

        }


        




    }
}
