using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace LPZConnDB.src_data
{
    public class ConnProperty
    {
        private string key;
        private string value;

        public ConnProperty()
        {

        }

        public ConnProperty(string key, string value)
        {
            this.key = key;
            this.value = value;
        }

        public ConnProperty(ConnProperty property)
        {
            this.key = property.Key;
            this.value = property.Value;
        }

        public string Key
        { 
            get { return key; }
            set { key = value; }
        }

        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}
