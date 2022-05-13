using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace jira_reporter
{
    public class Help
    {
        public static Help instance => new Help();

        public Response getResponse(string url, RequestOptions options = default)
        {
            Response res = new Response();
            try
            {
                HttpWebRequest request = createRequest(url, options);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                res.SuccessRes = response;
                response.Close();
            }
            catch (WebException ex)
            {
                res.WebException = ex;
                ex.Response.Close();
            }
            catch (Exception ex)
            {
                res.Error = ex;
            }
            return res;
        }

        private HttpWebRequest createRequest(string url, RequestOptions options)
        {
            HttpWebRequest request = WebRequest.CreateHttp(url);
            request.CookieContainer = new CookieContainer();
            request.Accept = "*/*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.4951.64 Safari/537.36";
            request.Referer = url;
            request.Method = options.Method;
            if (options.Cookie != null)
                request.CookieContainer.Add(options.Cookie);
            if (options.Header != null)
                request.Headers.Add(options.Header);
            if (options.Method == WebRequestMethods.Http.Post && options.Post != "")
                setPost(request, options);
            return request;
        }

        private void setPost(HttpWebRequest request, RequestOptions options)
        {
            byte[] p = Encoding.UTF8.GetBytes(options.Post);
            request.ContentType = options.PostType;
            request.ContentLength = p.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(p, 0, p.Length);
            stream.Close();
        }

        public bool isJson(string value)
        {
            try
            {
                JToken.Parse(value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
