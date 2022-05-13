using Newtonsoft.Json;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace jira_reporter
{
    public class Config
    {
        public static Config instance = new Config();
        private readonly DESCryptoServiceProvider crypto = new DESCryptoServiceProvider();
        private readonly byte[] key = Encoding.ASCII.GetBytes("ys939604");
        private readonly string path = Path.Combine(Application.StartupPath, "config.json");
        private string user;
        private string pass;

        public Config()
        {
        }

        [JsonProperty("user")]
        public string User { get => user; set => user = value; }
        [JsonProperty("pass")]
        public string Pass { get => pass; set => pass = value; }

        public void save()
        {
            try
            {
                string json = JsonConvert.SerializeObject(this);
                using (FileStream fs = File.Open(path, FileMode.Create))
                using (CryptoStream cs = new CryptoStream(fs, crypto.CreateEncryptor(key, key), CryptoStreamMode.Write))
                using (StreamWriter sw = new StreamWriter(cs))
                {
                    sw.Write(json);
                }
            }
            catch (Exception)
            {
            }
        }

        public void load()
        {
            if (File.Exists(path))
            {
                try
                {
                    using (FileStream fs = File.Open(path, FileMode.Open))
                    using (CryptoStream cs = new CryptoStream(fs, crypto.CreateDecryptor(key, key), CryptoStreamMode.Read))
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        string json = sr.ReadToEnd();
                        Config config = json.jsonDeserialize<Config>();
                        JiraApi.instance.login(config.User, config.Pass);
                        instance = config;
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        public void clear()
        {
            user = "";
            pass = "";
            save();
        }
    }
}
