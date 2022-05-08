using System.Net;

namespace jira_reporter
{
    public class Help
    {
        public static Help instance => new Help();

        public Response getResponse(string url)
        {
            return new Response();
        }

        public Response getResponse(string url, string method = WebRequestMethods.Http.Get)
        {
            return new Response();
        }

        public static string KaynakKoduAl(string url, string method = WebRequestMethods.Http.Get, string postdegeri = "", string posttype = "", CookieCollection cookie = null, WebHeaderCollection header = null, bool otoyonlendir = true)
        {
            lock (kitle)
            {
                try
                {
                    HttpWebRequest request = WebRequest.CreateHttp(url);
                    request.CookieContainer = new CookieContainer();
                    if (!(cookie is null))
                        request.CookieContainer.Add(cookie);
                    request.Accept = "*/*";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.117 Safari/537.36";
                    request.Referer = url;
                    request.Method = method;
                    if (Proxy != "")
                        request.Proxy = new WebProxy(Proxy, true);
                    request.AllowAutoRedirect = false;
                    if (!(header is null))
                        request.Headers.Add(header);
                    if (method == WebRequestMethods.Http.Post && postdegeri != "")
                    {
                        byte[] p = Encoding.UTF8.GetBytes(postdegeri);
                        if (posttype == "")
                            posttype = "application/x-www-form-urlencoded; charset=UTF-8";
                        request.ContentType = posttype;
                        request.ContentLength = p.Length;
                        Stream stream = request.GetRequestStream();
                        stream.Write(p, 0, p.Length);
                        stream.Close();
                    }
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (!(cookie is null))
                        cookie.Add(response.Cookies);
                    string source = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    response.Close();
                    return source;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }
}
