using System;
using System.Threading;
using System.Windows.Forms;

namespace jira_reporter
{
    static class Program
    {
        static MainForm frm;

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
        exit:
            Config.instance.load();
            if (string.IsNullOrEmpty(JiraApi.auth))
            {
                Application.Run(new LoginForm());
                if (!string.IsNullOrEmpty(JiraApi.auth))
                    RunMainForm();
            }
            else
                RunMainForm();
            if (frm.exit)
            {
                Config.instance.clear();
                goto exit;
            }
            GC.KeepAlive(mutex);
        }

        static void RunMainForm()
        {
            frm = new MainForm();
            Application.Run(frm);
        }
    }
}
