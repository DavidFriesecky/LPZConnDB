using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;
using System.Linq;

namespace LPZConnDB.src_data
{
    public class ConnDB
    {
        private BindingList<ConnProperty> properties;
        private BindingList<ConnModule> modules;

        public ConnDB()
        {
            properties = new BindingList<ConnProperty>();
            modules = new BindingList<ConnModule>();

            AddProperty("id", "");
            AddProperty("name", "");
        }

        public ConnDB(ConnDB connDB)
        {
            properties = new BindingList<ConnProperty>();
            foreach (ConnProperty property in connDB.Properties)
            {
                properties.Add(new ConnProperty(property));
            }

            modules = new BindingList<ConnModule>();
            foreach (ConnModule module in connDB.Modules)
            {
                modules.Add(new ConnModule(module));
            }
        }

        public ConnDB(FileInfo file)
        {
            properties = new BindingList<ConnProperty>();
            modules = new BindingList<ConnModule>();
            try
            {
                XmlTextReader xml = new XmlTextReader(file.FullName);
                ParseFile(xml);
                xml.Close();
            }
            catch
            {
                Console.WriteLine("Chyba načítání souboru <{0}>.", file.Name);
            }
        }

        private void ParseFile(XmlTextReader file)
        {
            bool bHeader = false;
            bool bHeaderItem = false;
            bool bBodyItem = false;
            bool bBodyItemCreated = false;
            bool bBodyPropItem = false;
            
            string lastKey = "";

            while (file.Read())
            {
                switch (file.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (file.Name)
                        {
                            case Constants.XML_HEADER: bHeader = true; break;
                            case Constants.XML_BODY_ITEM: bBodyItem = true; break;
                            case Constants.XML_BODY_PROP_ITEM: bBodyPropItem = true; break;
                        }

                        if (bHeader && !file.Name.Equals(Constants.XML_HEADER))
                        {
                            bHeaderItem = true;
                            AddProperty(file.Name, "");
                            lastKey = file.Name;
                        }
                        break;

                    case XmlNodeType.Text:
                        if (bHeaderItem)
                        {
                            ReplaceProperty(lastKey, file.Value.Trim());
                        }

                        if (bBodyItem && !bBodyItemCreated)
                        {
                            bBodyItemCreated = true;
                            AddModule(new ConnModule(file.Value.Trim()));
                        }

                        if (bBodyPropItem)
                        {
                            Module(modules.Count - 1).Properties.Add(new ConnModuleProperty(file.Value.Trim()));
                        }
                        break;

                    case XmlNodeType.EndElement:
                        switch (file.Name)
                        {
                            case Constants.XML_HEADER:
                                bHeader = false;
                                break;
                            case Constants.XML_BODY_ITEM:
                                bBodyItem = false;
                                bBodyItemCreated = false;
                                break;
                            case Constants.XML_BODY_PROP_ITEM:
                                bBodyPropItem = false;
                                break;
                        }

                        bHeaderItem = false;
                        break;
                }
            }
        }

        public void CreateFileConfig()
        {
            try
            {
                StreamWriter file = new StreamWriter(Constants.OUTPUT_FILE);

                file.Write(this.ToString());
                file.WriteLine();
                file.Flush();

                try
                {
                    Process.Start(Constants.RUN_FILE);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error");
                }
                Application.Exit();
            } 
            catch (Exception)
            {
                Console.WriteLine("Do souboru se nepovedlo zapsat.");
            }
        }

        public void CreateFileXML()
        {
            try
            {
                StreamWriter file = new StreamWriter(Constants.DATA_FOLDER + Property("id") + ".xml");

                file.Write(this.ToStringXML());
                file.WriteLine();
                file.Flush();
                file.Close();
                Console.WriteLine("Soubor byl vytvořen [" + Property("id") + ".xml]");
            } catch (Exception)
            {
                Console.WriteLine("Do souboru se nepovedlo zapsat.");
            }
        }

        public bool DeleteFileXML()
        {
            File.Delete(Constants.DATA_FOLDER + Property("id") + ".xml");
            if (!File.Exists(Constants.DATA_FOLDER + Property("id") + ".xml"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public BindingList<ConnProperty> Properties
        {
            get { return properties; }
            set { properties = value; }
        }

        public string Property(string key)
        {
            foreach (ConnProperty property in properties)
            {
                if (property.Key.Equals(key))
                {
                    return property.Value;
                }
            }

            return null;
        }

        public bool ContainsProperty(string key)
        {
            foreach (ConnProperty property in properties)
            {
                if (property.Key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        public void AddProperty(string key, string value)
        {
            if (!ContainsProperty(key))
            {
                properties.Add(new ConnProperty(key, value));
            }
        }

        public void ReplaceProperty(string key, string value)
        {
            for (int i = 0; i < properties.Count; i++)
            {
                if (properties[i].Key.Equals(key))
                {
                    properties[i] = new ConnProperty(key, value);
                }
            }
        }

        public BindingList<ConnModule> Modules
        {
            get { return modules; }
            set { modules = value; }
        }

        public ConnModule Module(int index)
        {
            if (index < modules.Count)
            {
                return modules[index];
            }
            
            return null;
        }

        public void AddModule(ConnModule connModule)
        {
            modules.Add(connModule);
        }

        public override string ToString()
        {
            string result = "";

            foreach (ConnModule module in modules)
            {
                if (module.ModuleName.StartsWith("#"))
                {
                    try
                    {
                        StreamReader file = new StreamReader(Constants.DATA_FOLDER + module.ModuleName.Substring(1));

                        string str;
                        bool doubleEnter = false;

                        while ((str = file.ReadLine()) != null)
                        {
                            if (str.Length >= 1)
                            {
                                result += str + "\n";
                                doubleEnter = false;
                            }
                            else if (!doubleEnter)
                            {
                                doubleEnter = true;
                                result += "\n";
                            }
                        }

                        result += "\n";

                        file.Close();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Chyba při čtení ze souboru.");
                    }
                } 
                else 
                {
				    result += module.ModuleName + "\n";
				
				    foreach (ConnModuleProperty property in module.Properties) {
					    result += property.ModuleProperty + "\n";
				    }

                    result += "\n";
			    }
		    }
		
		    return result;
	    }
	
	    private string ToStringXML()
        {
            string result = "";

            result += "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n";
            result += "<department>\n";
            result += "\t<header>\n";

            foreach (ConnProperty property in properties)
            {
                result += "\t\t<" + property.Key + ">" + property.Value + "</" + property.Key + ">\n";
            }

            result += "\t</header>\n";
            result += "\t<modules>\n";

            foreach (ConnModule module in modules)
            {
                result += "\t\t<module>\n";
                result += "\t\t\t" + module.ModuleName + "\n";
                result += "\t\t\t<properties>\n";

                foreach (ConnModuleProperty property in module.Properties)
                {
                    result += "\t\t\t\t<property>" + property.ModuleProperty + "</property>\n";
                }

                result += "\t\t\t</properties>\n";
                result += "\t\t</module>\n";
            }

            result += "\t</modules>\n";
            result += "</department>\n";

            return result;
        }
    }
}
