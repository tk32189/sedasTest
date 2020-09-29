using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Integration_Viewer.DTO
{
    public class FileInfoDTO
    {
        public int DtoId { get; set; }
        public string LocalFilePath { get; set; }

        public string FileName { get; set; }




        //---아래는 DB에서 받아오는 자료--------------
        public string RootPath { get; set; }
        public string FilePath { get; set; }
        public string SendStat { get; set; }

        public string SerialNo { get; set; }
        public string StudyId { get; set; }
        public string Type { get; set; }
        public string Seq { get; set; }

        public string RecordResult { get; set; }

        
    }
}
