using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageOCR.DTO
{
    public class ImageInfoDTO : INotifyPropertyChanged
    {
        private string strRowFilePath = "";
        private string fileName = "";
        private bool isDirectAdded = false;
        private string ocrResult = "";
        private bool isChecked = false;

        private string ptno;
        private string kornm;
        private string regno;
        private string tknm;
        private string tkdt;
        private string ptoNo;

        private string patbir;
        private string patsex;
        private string patage;

        public string StrRowFilePath
        {
            get
            {
                return strRowFilePath;
            }

            set
            {
                strRowFilePath = value;
                if ( value != null)
                {
                    OnPropertyChanged("StrRowFilePath");
                }
            }
        }

        public string OcrResult
        {
            get
            {
                return ocrResult;
            }

            set
            {
                ocrResult = value;
                if (value != null)
                {
                    OnPropertyChanged("OcrResult");
                }
            }
        }

        public bool IsChecked
        {
            get
            {
                return isChecked;
            }

            set
            {
                isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }

        public string Ptno
        {
            get
            {
                return ptno;
            }

            set
            {
                ptno = value;
                if (value != null)
                {
                    OnPropertyChanged("Ptno");
                }
            }
        }

        public string Kornm
        {
            get
            {
                return kornm;
            }

            set
            {
                kornm = value;
                if (value != null)
                {
                    OnPropertyChanged("Kornm");
                }
            }
        }

        public string Regno
        {
            get
            {
                return regno;
            }

            set
            {
                regno = value;
                if (value != null)
                {
                    OnPropertyChanged("Regno");
                }
            }
        }

        public string Tknm
        {
            get
            {
                return tknm;
            }

            set
            {
                tknm = value;
                if (value != null)
                {
                    OnPropertyChanged("Tknm");
                }
            }
        }

        public string Tkdt
        {
            get
            {
                return tkdt;
            }

            set
            {
                tkdt = value;
                if (value != null)
                {
                    OnPropertyChanged("Tkdt");
                }
            }
        }

        public string PtoNo
        {
            get
            {
                return ptoNo;
            }

            set
            {
                ptoNo = value;
                if (value != null)
                {
                    OnPropertyChanged("PtoNo");
                }
            }
        }

        public string Patbir
        {
            get
            {
                return patbir;
            }

            set
            {
                patbir = value;
                if (value != null)
                {
                    OnPropertyChanged("Patbir");
                }
            }
        }

        public string Patsex
        {
            get
            {
                return patsex;
            }

            set
            {
                patsex = value;
                if (value != null)
                {
                    OnPropertyChanged("Patsex");
                }
            }
        }

        public string Patage
        {
            get
            {
                return patage;
            }

            set
            {
                patage = value;
                if (value != null)
                {
                    OnPropertyChanged("Patage");
                }
            }
        }

        public bool IsDirectAdded
        {
            get
            {
                return isDirectAdded;
            }

            set
            {
                isDirectAdded = value;
            }
        }

        public string FileName
        {
            get
            {
                return fileName;
            }

            set
            {
                fileName = value;
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventArgs arg = new PropertyChangedEventArgs(propertyName);

            if (PropertyChanged != null)
            {
                PropertyChanged(this, arg);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
