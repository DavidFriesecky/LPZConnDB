using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace LPZConnDB.src_security
{
    public class AdminUtil
    {
        private string username = "";
        private string password = "";
        private bool isCorrectLogin = false;

        public AdminUtil()
        {
            LoadHash();
        }

        public string ComputeSha256Hash(string input, bool addNewPasswd)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                string password = builder.ToString();

                if (addNewPasswd)
                {
                    SetNewPasswd(password);
                }

                return password;
            }
        }

        private void LoadHash()
        {
            try
            {
                StreamReader file = new StreamReader(Constants.HASH_FILE);

                string[] hash;
                string str;

                while ((str = file.ReadLine()) != null)
                {
                    hash = str.Split('=');
                    if (hash[0].Equals("username"))
                    {
                        username = hash[1];
                    }
                    else if (hash[0].Equals("password"))
                    {
                        password = hash[1];
                    }
                }

                file.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Chyba při čtení ze souboru.");
            }
        }

        private void SetNewPasswd(string password)
        {
            this.password = password;

            try
            {
                StreamWriter file = new StreamWriter(Constants.HASH_FILE);
                file.WriteLine("username={0}", username);
                file.WriteLine("password={0}", this.password);

                file.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Chyba při zápisu do souboru.");
            }
}

        public bool IsCorrectLogin
        {
            get { return isCorrectLogin; }
            set { isCorrectLogin = value; }
        }

        public string Username
        {
            get { return username; }
        }

        public string Password
        {
            get { return password; }
        }
    }
}
