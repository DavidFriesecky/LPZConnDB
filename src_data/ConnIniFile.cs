using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;

namespace LPZConnDB.src_data
{
    class ConnIniFile
    {
        private string iniName;
        private string content = "";

        public ConnIniFile()
        {

        }

        public ConnIniFile(FileInfo file)
        {
            this.iniName = file.Name;
            try
            {
                StreamReader fileSR = new StreamReader(Constants.DATA_FOLDER + file.Name);
                bool isUsedWhiteSpace = false;
                string line;
                while ((line = fileSR.ReadLine()) != null)
                {
                    if (line.Equals("") || line.Equals("\n") || line.Equals("\r\n") || line.Equals(Environment.NewLine))
                    {
                        isUsedWhiteSpace = true;
                    }
                    else
                    {
                        isUsedWhiteSpace = false;
                    }

                    if (!isUsedWhiteSpace)
                    {
                        content += line + Environment.NewLine;
                    }
                }
                fileSR.Close();
            }
            catch
            {
                Console.WriteLine("Chyba načítání souboru <{0}>.", file.Name);
            }
        }

        public ConnIniFile(string iniName, string content)
        {
            this.iniName = iniName;
            this.content = content;
        }

        public string IniName
        {
            get { return iniName; }
            set {
                if (File.Exists(Constants.DATA_FOLDER + iniName))
                {
                    File.Delete(Constants.DATA_FOLDER + iniName);
                }

                this.iniName = value;
                GenFile(string.Format("Chyba vytváření souboru <{0}>.", Constants.DATA_FOLDER + iniName));
            }
        }

        public string Content
        {
            get { return content; }
            set { 
                this.content = value;
                GenFile(string.Format("Chyba zápisu do souboru <{0}>.", Constants.DATA_FOLDER + iniName));
            }
        }

        private void GenFile(string msg)
        {
            try
            {
                StreamWriter file = new StreamWriter(Constants.DATA_FOLDER + iniName);
                file.Write(content);
                file.Close();
            }
            catch
            {
                Console.WriteLine(msg);
            }
        }
    }
}
