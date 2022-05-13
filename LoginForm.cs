using System;
using System.Windows.Forms;

namespace jira_reporter
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUser.Text))
                {
                    MessageBox.Show("Kullanıcı adı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUser.Focus();
                }
                else if (string.IsNullOrEmpty(txtPass.Text))
                {
                    MessageBox.Show("Şifre boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPass.Focus();
                }
                else
                {
                    JiraApi.instance.login(txtUser.Text, txtPass.Text);
                    if (cbRemember.Checked)
                    {
                        Config.instance.User = txtUser.Text;
                        Config.instance.Pass = txtPass.Text;
                        Config.instance.save();
                        Close();
                    }
                    else
                        Config.instance.clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
