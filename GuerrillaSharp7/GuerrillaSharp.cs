using GuerrillaSharp7.Models;
using GuerrillaSharp7.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GuerrillaSharp7;
public class GuerrillaMail
{
    private const string BaseUrl = "https://api.guerrillamail.com/ajax.php";

    private CookieContainer Cookies { get; set; }

    public GuerrillaMailData MailData { get; set; } = new GuerrillaMailData();

    public GuerrillaMail()
    {
        Cookies = new CookieContainer();
        GetEmailAddress();
    }

    ~GuerrillaMail()
    {
        ForgetMe();
    }
    private void GetEmailAddress()
    {
        var response = GetResponse($"{BaseUrl}?f=get_email_address", new CookieContainer());
        if (response.Json == null)
        {
            throw new Exception("Failed to get response");
        }
        var tempmail = JsonConvert.DeserializeObject<GuerrillaMailData>(response.Json);
        if (tempmail != null)
        {
            MailData = tempmail;
        }
    }

    public void CheckEmail()
    {
        var response = GetResponse($"{BaseUrl}?f=check_email&seq=0", Cookies);
        if (response.Json != null)
        {
            var tempmail = JsonConvert.DeserializeObject<GuerrillaMailData>(response.Json);
            if (tempmail != null)
            {
                this.MailData = tempmail;
            }
        }
    }

    public List<Email> CheckAndGetEmails()
    {
        CheckEmail();
        return MailData.Emails ?? new List<Email>();
    }
    public List<Email> CheckAndGetEmails(string fromAddr)
    {
        CheckEmail();
        return MailData.Emails?.Where(x => x.MailFrom == fromAddr).ToList() ?? new List<Email>();
    }

    public List<Email> CheckAndWaitForMailFromAddr(string fromAddr, int timeout = 60)
    {
        var emails = new List<Email>();
        var start = DateTime.Now;
        while (emails.Count == 0 && DateTime.Now.Subtract(start).TotalSeconds < timeout)
        {
            emails = CheckAndGetEmails(fromAddr);
            if (emails.Count == 0)
            {
                Task.Delay(1000).Wait();
            }
        }
        return emails;
    }
    public Email? FetchEmail(string id)
    {
        var response = GetResponse($"{BaseUrl}?f=fetch_email&email_id={id}", Cookies);
        if (response.Json != null)
        {
            return JsonConvert.DeserializeObject<Email?>(response.Json);
        }
        return null;
    }

    private Response GetResponse(string url, CookieContainer cookies)
    {
        var response = HttpUtil.Get(url, cookies);
        this.Cookies = response.Cookies ?? throw new Exception("Failed to get response");
        if (response.Json == null)
        {
            throw new Exception("Failed to get response");
        }
        return response;
    }

    private void ForgetMe()
    {
        var response = GetResponse($"{BaseUrl}?f=forget_me", Cookies);
        if (response.Json == null)
        {
            throw new Exception("Failed to get response");
        }
        var isSucceed = JsonConvert.DeserializeObject<bool>(response.Json);
        MailData = null!;
        
    }
}