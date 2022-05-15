using System;
using System.Collections.Generic;

namespace jira_reporter
{
    public class JiraApi
    {
        private const string apiBase = "http://31.223.16.89:7523/rest/api/2/";
        public static string auth = "";
        public static JiraUser user = null;
        public static JiraApi instance => new JiraApi();

        public void login(string userName, string pass)
        {
            if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(pass))
            {
                auth = "";
                user = null;
                throw new Exception("Kullanıcı adı ve şifre boş olamaz.");
            }
            string str = $"{userName}:{pass}";
            string authorization = $"Authorization: Basic {str.toBase64()}";
            Response res = Help.instance.getResponse($"{apiBase}myself", new RequestOptions(null, authorization));
            checkError(res);
            auth = authorization;
            user = res.SourceCode.jsonDeserialize<JiraUser>();
        }

        public List<JiraFilter> getFilters()
        {
            checkLogin();
            Response res = Help.instance.getResponse($"{apiBase}filter/favourite", new RequestOptions(null, auth));
            checkError(res);
            return new List<JiraFilter>(res.SourceCode.jsonDeserialize<JiraFilter[]>());
        }

        public JiraJql getJql(string jql)
        {
            checkLogin();
            Response res = Help.instance.getResponse($"{apiBase}search?jql={jql}&fields=*all&maxResults=10000", new RequestOptions(null, auth));
            checkError(res);
            return res.SourceCode.jsonDeserialize<JiraJql>();
        }

        private void checkLogin()
        {
            if (string.IsNullOrEmpty(auth))
                throw new Exception("Giriş yapılmadı.");
        }

        private void checkError(Response res)
        {
            if (res.isError)
            {
                auth = "";
                user = null;
                JiraError error = res.SourceCode?.jsonDeserialize<JiraError>();
                throw error != null ? new Exception(error.Errors) : res.Error ?? res.WebException;
            }
        }
    }
}
