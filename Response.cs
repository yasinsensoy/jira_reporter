using System;
using System.IO;
using System.Net;

namespace jira_reporter
{
    public class Response
    {
        private string sourceCode;
        private HttpWebResponse successRes;
        private HttpWebResponse errorRes;
        private Exception error;
        private WebException webException;

        public Response()
        {

        }

        public HttpWebResponse SuccessRes { get => successRes; set { successRes = value; sourceCode = value == null ? "" : new StreamReader(value.GetResponseStream()).ReadToEnd(); } }
        public HttpWebResponse ErrorRes { get => errorRes; set { errorRes = value; sourceCode = value == null ? "" : new StreamReader(value.GetResponseStream()).ReadToEnd(); } }
        public Exception Error { get => error; set => error = value; }
        public WebException WebException { get => webException; set { webException = value; ErrorRes = (HttpWebResponse)webException.Response; } }
        public string SourceCode { get => sourceCode; }

        public bool isError { get => SuccessRes == null; }
    }
}
