using System.Collections.Generic;
using System.IO;
using System;
using System.Windows.Forms;
using System.ComponentModel;

using LPZConnDB.src_data;

namespace LPZConnDB
{
    class DataModel
    {
        private List<KeyValuePair<Button, ConnDB>> connections = new List<KeyValuePair<Button, ConnDB>>();
        private BindingList<ConnIniFile> iniFiles = new BindingList<ConnIniFile>();

        public DataModel()
        {
            LoadFiles();
        }

        private void LoadFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(Constants.DATA_FOLDER);
            Console.WriteLine(dir.FullName);
            foreach (FileInfo file in dir.GetFiles())
            {
                if (file.Name.EndsWith(".xml"))
                {
                    connections.Add(new KeyValuePair<Button, ConnDB>(new Button(), new ConnDB(file)));
                }
                else
                {
                    iniFiles.Add(new ConnIniFile(file));
                }
            }
        }

        public bool ContainsID(string id)
        {
            foreach (KeyValuePair<Button, ConnDB> connection in connections)
            {
                if (connection.Value.Property("id").Equals(id))
                {
                    return true;
                }
            }

            return false;
        }

        public void RemoveID(string id)
        {
            for (int i = 0; i < connections.Count; i++)
            {
                if (connections[i].Value.Property("id").Equals(id))
                {
                    connections.RemoveAt(i);
                    return;
                }
            }
        }

        public List<KeyValuePair<Button, ConnDB>> Connections
        {
            get { return connections; }
            set { this.connections = value; }
        }

        public BindingList<ConnIniFile> IniFiles
        {
            get { return iniFiles; }
            set { this.iniFiles = value; }
        }
    }
}
