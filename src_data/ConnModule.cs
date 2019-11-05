using System.ComponentModel;
using System;

namespace LPZConnDB.src_data
{
    public class ConnModule
    {
        private string moduleName = "";
        private BindingList<ConnModuleProperty> properties;

        public ConnModule()
        {
            properties = new BindingList<ConnModuleProperty>();
        }

        public ConnModule(string name)
        {
            this.moduleName = name;
            properties = new BindingList<ConnModuleProperty>();
        }

        public ConnModule(ConnModule module)
        {
            moduleName = module.moduleName;
            properties = new BindingList<ConnModuleProperty>();
            foreach (ConnModuleProperty property in module.Properties)
            {
                properties.Add(new ConnModuleProperty(property.ModuleProperty));
            }
        }

        public BindingList<ConnModuleProperty> Properties
        {
            get { return properties; }
            set { properties = value; }
        }

        public string ModuleName
        {
            get { return moduleName; }
            set { moduleName = value; }
        }
    }
}
