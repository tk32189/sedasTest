using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration_Viewer.DTO
{
    public class TreeDTO : INotifyPropertyChanged
    {
        public int ParentID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public int DtoId { get; set; } = -1;
        bool? checkedCore;
        public bool? Checked
        {
            get { return checkedCore; }
            set
            {
                if (checkedCore == value)
                    return;
                checkedCore = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Checked"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
