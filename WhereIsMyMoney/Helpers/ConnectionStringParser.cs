using System;

namespace WhereIsMyMoney.Helpers
{
    //source https://www.elephantsql.com/docs/dotnet.html
    public class ConnectionStringParser
    {
        public static string Get(string uriString = null)
        {
            var uri = new Uri(uriString ?? "postgres://localhost/mydb");
            var db = uri.AbsolutePath.Trim('/');
            var user = uri.UserInfo.Split(':')[0];
            var password = uri.UserInfo.Split(':')[1];
            var port = uri.Port > 0 ? uri.Port : 5432;
            var connStr = $"Server={uri.Host};Database={db};User Id={user};Password={password};Port={port}";
            return connStr;
        }
    }
}