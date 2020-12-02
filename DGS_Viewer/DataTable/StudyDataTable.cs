using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS_Viewer
{
    public class StudyDataTable : DataTable
    {
        public StudyDataTable()
        {
            //
            this.Columns.Add("Data00", typeof(String));
            this.Columns.Add("Data01", typeof(String));
            this.Columns.Add("Data02", typeof(String));
            this.Columns.Add("Data03", typeof(String));
            this.Columns.Add("Data04", typeof(String));
            this.Columns.Add("Data05", typeof(String));
            this.Columns.Add("Data06", typeof(String));
            this.Columns.Add("Data07", typeof(String));
            this.Columns.Add("Data08", typeof(String));
            this.Columns.Add("Data09", typeof(String));
            this.Columns.Add("Data10", typeof(String));
            this.Columns.Add("Data11", typeof(String));
            this.Columns.Add("Data12", typeof(String));
            this.Columns.Add("Data13", typeof(String));
            this.Columns.Add("Data14", typeof(String));
            this.Columns.Add("Data15", typeof(String));
            this.Columns.Add("Data16", typeof(String));
            this.Columns.Add("Data17", typeof(String));
            this.Columns.Add("Data18", typeof(String));


            this.Columns.Add("studyId", typeof(String));
            this.Columns.Add("ptoNo", typeof(String));
            this.Columns.Add("gi", typeof(String));
            this.Columns.Add("mi", typeof(String));
            this.Columns.Add("oi", typeof(String));
            this.Columns.Add("sendStat", typeof(String));
            this.Columns.Add("ptNo", typeof(String));
            this.Columns.Add("ptNm", typeof(String));
            this.Columns.Add("birth", typeof(String));
            this.Columns.Add("age", typeof(String));
            this.Columns.Add("sex", typeof(String));
            this.Columns.Add("studyDt", typeof(String));
            this.Columns.Add("insertDt", typeof(String));
            this.Columns.Add("dstudy1", typeof(String));
            this.Columns.Add("dstudy2", typeof(String));
            this.Columns.Add("dstudy3", typeof(String));
            this.Columns.Add("accessId", typeof(String));
            this.Columns.Add("studyNm", typeof(String));
            this.Columns.Add("uuId", typeof(String));
            this.Columns.Add("lastUpdtDt", typeof(String));
            this.Columns.Add("lastUpdtDtDisplay", typeof(String));

            this.Columns.Add("mappingCount", typeof(String));

        }
    }
}
