using System;
using System.Threading;
using System.Windows.Forms;

namespace jira_reporter
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Mutex mutex = new Mutex(true, "jira_reporter", out bool kontrol);
            if (!kontrol)
            {
                MessageBox.Show("Program zaten çalışıyor.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Config.instance.load();
            if (string.IsNullOrEmpty(JiraApi.auth))
            {
                Application.Run(new LoginForm());
                if (!string.IsNullOrEmpty(JiraApi.auth))
                    Application.Run(new MainForm());
            }
            else
                Application.Run(new MainForm());
            GC.KeepAlive(mutex);
        }
    }
}
