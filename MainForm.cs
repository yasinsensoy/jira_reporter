using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace jira_reporter
{
    public partial class MainForm : Form
    {
        public bool exit = false;
        private string filterSelValue;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            var rect = Screen.GetWorkingArea(this);
            Size = new Size((int)(rect.Width * 0.8), (int)(rect.Height * 0.8));
            CenterToScreen();
            if (JiraApi.user != null)
            {
                lblDisplayName.Text = JiraApi.user.DisplayName;
                lblName.Text = JiraApi.user.Name;
                pbAvatar.Image = JiraApi.user.AvatarUrls?.ImageX24;
            }
            backgroundWorker1.RunWorkerAsync();
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            exit = true;
            Close();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                List<JiraFilter> filters = JiraApi.instance.getFilters();
                Invoke((MethodInvoker)delegate { cbFilters.DataSource = filters; });
            }
            catch (Exception ex)
            {
                Invoke((MethodInvoker)delegate { MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); });
            }
        }

        private void cbFilters_SelectedValueChanged(object sender, EventArgs e)
        {
            filterSelValue = cbFilters.SelectedValue.ToString();
            if (!backgroundWorker2.IsBusy)
                backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                JiraJql jql = JiraApi.instance.getJql($"filter={filterSelValue}");
                Invoke((MethodInvoker)delegate { dgIssues.DataSource = jql.Issues; });
            }
            catch (Exception ex)
            {
                Invoke((MethodInvoker)delegate { MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); });
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }

        private void dgIssues_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            lblInfo.Text = $"Kayıt sayısı: {dgIssues.RowCount}";
        }
    }
}
