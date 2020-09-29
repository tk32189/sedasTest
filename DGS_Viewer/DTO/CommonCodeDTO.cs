using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS_Viewer.DTO
{
    public class CommonCodeDTO
    {
        private string cdVal;
        private string cdValNm;

        public string CdVal
        {
            get
            {
                return cdVal;
            }

            set
            {
                cdVal = value;
            }
        }

        public string CdValNm
        {
            get
            {
                return cdValNm;
            }

            set
            {
                cdValNm = value;
            }
        }
    }
}
