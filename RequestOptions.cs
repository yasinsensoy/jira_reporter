using System.Net;

namespace jira_reporter
{
    public class RequestOptions
    {
        private string method = WebRequestMethods.Http.Get;
        private string post = "";
        private string postType = "application/x-www-form-urlencoded; charset=UTF-8";
        private CookieCollection cookie = null;
        private WebHeaderCollection header = null;

        public RequestOptions()
        {
        }

        public RequestOptions(string method)
        {
            this.method = method;
        }

        public RequestOptions(string post, string postType, string method)
        {
            this.post = post;
            this.postType = postType ?? "application/x-www-form-urlencoded; charset=UTF-8";
            this.method = method ?? WebRequestMethods.Http.Post;
        }

        public RequestOptions(CookieCollection cookie, WebHeaderCollection header)
        {
            this.cookie = cookie;
            this.header = header;
        }

        public RequestOptions(string cookie, string header)
        {
            this.cookie = stringToCookie(cookie);
            this.header = stringToHeader(header);
        }

        public RequestOptions(string method, string post, string postType, CookieCollection cookie, WebHeaderCollection header)
        {
            this.method = method;
            this.post = post;
            this.postType = postType;
            this.cookie = cookie;
            this.header = header;
        }

        public RequestOptions(string method, string post, string postType, string cookie, string header)
        {
            this.method = method;
            this.post = post;
            this.postType = postType;
            this.cookie = stringToCookie(cookie);
            this.header = stringToHeader(header);
        }

        private CookieCollection stringToCookie(string cookie)
        {
            if (cookie == null)
                return null;
            CookieCollection c = new CookieCollection();
            foreach (var i in cookie.Split(new string[] { ";" }, System.StringSplitOptions.RemoveEmptyEntries))
            {
                string[] a = i.Split(new string[] { "=" }, 2, System.StringSplitOptions.RemoveEmptyEntries);
                if (a.Length == 2)
                    c.Add(new Cookie(a[0].TrimStart(), a[1]));
            }
            return c;
        }

        private WebHeaderCollection stringToHeader(string header)
        {
            if (header == null)
                return null;
            WebHeaderCollection h = new WebHeaderCollection();
            foreach (var i in header.Split(new string[] { "\r\n" }, System.StringSplitOptions.RemoveEmptyEntries))
            {
                string[] a = i.Split(new string[] { ":" }, 2, System.StringSplitOptions.RemoveEmptyEntries);
                if (a.Length == 2)
                    h.Add(a[0], a[1].TrimStart());
            }
            return h;
        }

        public void setCookie(string cookie)
        {
            Cookie = stringToCookie(cookie);
        }

        public void setHeader(string header)
        {
            Header = stringToHeader(header);
        }

        public string Method { get => method; set => method = value; }
        public string Post { get => post; set => post = value; }
        public string PostType { get => postType; set => postType = value; }
        public CookieCollection Cookie { get => cookie; set => cookie = value; }
        public WebHeaderCollection Header { get => header; set => header = value; }
    }
}
