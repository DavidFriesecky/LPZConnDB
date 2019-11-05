using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPZConnDB.src_data
{
    public class ConnModuleProperty
    {
        private string moduleProperty;

        public ConnModuleProperty()
        {

        }

        public ConnModuleProperty(string moduleProperty)
        {
            this.moduleProperty = moduleProperty;
        }

        public string ModuleProperty
        {
            get { return moduleProperty; }
            set { moduleProperty = value; }
        }
    }
}
