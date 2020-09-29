using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;


namespace Sedas.Control.GridControl
{
    public partial class HGridColumnCollection : GridColumnCollection
    {
        public HGridColumnCollection(ColumnView view) : base(view)
        {

        }

        private ControlType sedasControlType = ControlType.Null;
        public ControlType SedasControlType
        {
            get
            {
                return sedasControlType;
            }

            set
            {
                sedasControlType = value;
            }
        }


        public HGridColumnCollection(ColumnView view, ControlType sedasControlType) : base(view)
        {
            this.sedasControlType = sedasControlType;
        }



        protected override GridColumn CreateColumn()
        {
            return new HGridColumn();
        }

    }
}
