using System.Drawing;
using System.Windows.Forms;

namespace jira_reporter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            Response res = Help.instance.getResponse("http://31.223.16.89:7523/rest/api/2/search?jql=filter=11001&fields=*all&maxResults=10000", new RequestOptions(null, "Authorization: Basic eXNlbnNveTo5Mzk2MDQ1Mg=="));
            JiraJql jql = res.SourceCode.jsonDeserialize<JiraJql>();
            var rect = Screen.GetWorkingArea(this);
            Size = new Size((int)(rect.Width *0.8),(int)(rect.Height*0.8));
            CenterToScreen();
        }
    }
}
