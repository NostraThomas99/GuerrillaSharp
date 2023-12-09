using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GuerrillaSharp7.Models;

namespace GuerrillaSharp7.Utils;
internal class HttpUtil
{
    internal static Response Get(string url, CookieContainer cookies)
    {
        HttpClientHandler handler = new HttpClientHandler();
        handler.CookieContainer = cookies;
        HttpClient client = new HttpClient(handler);
        var res = client.GetAsync(url);
        Response response = new Response()
        {
            Json = res.Result.Content.ReadAsStringAsync().Result,
            Cookies = cookies
        };
        return response;
    }
}


