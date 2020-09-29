using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedas.Core
{
    public class KeyValueData : Dictionary<string, string>
    {
        //public KeyValueData();
        bool isChanged = false;
        public string this[string key]
        {
            get {

                KeyValuePair<string, string> selectedValue = this.Where(e => e.Key == key).FirstOrDefault();
                return selectedValue.Value;

                //return this[key]; 
            
            }
            set {
                if (isChanged == false)
                {
                    isChanged = true;

                    //this.Where(e => e.Key == key).ToList().ForEach(item =>
                    //{
                    //    item.Value = value;
                    //});


                    base[key] = value;
                    isChanged = false;
                }
                
            }
        }
    }
}
