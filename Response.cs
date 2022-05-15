using System;
using System.IO;
using System.Net;
using System.Text;

namespace jira_reporter
{
    public class Response
    {
        private byte[] byteArray;
        private HttpWebResponse successRes;
        private HttpWebResponse errorRes;
        private Exception error;
        private WebException webException;

        public Response()
        {
        }

        public HttpWebResponse SuccessRes { get => successRes; set { successRes = value; byteArray = value.GetResponseStream().toByte(); } }
        public HttpWebResponse ErrorRes { get => errorRes; set { errorRes = value; byteArray = value.GetResponseStream().toByte(); } }
        public Exception Error { get => error; set => error = value; }
        public WebException WebException { get => webException; set { webException = value; ErrorRes = (HttpWebResponse)webException.Response; } }
        public byte[] ByteArray { get => byteArray; set => byteArray = value; }
        public string SourceCode => byteArray == null ? "" : Encoding.UTF8.GetString(byteArray);
        public bool isError => SuccessRes == null;
        public Stream Stream => new MemoryStream(byteArray);
    }
}
