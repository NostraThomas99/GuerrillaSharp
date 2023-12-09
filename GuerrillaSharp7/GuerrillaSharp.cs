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
        private CookieContainer Cookies { get; set; }

        [JsonProperty("sid_token")]
        private string SidToken { get; set; }

        [JsonProperty("email_addr")]
        public string EmailAddress { get; set; }

        [JsonProperty("email_timestamp")]
        public string EmailTimestamp { get; set; }

        [JsonProperty("alias")]
        public string EmailAlias { get; set; }

        [JsonProperty("list")]
        public List<Email> Emails { get; set; }

        [JsonProperty("count")]
        public int EmailCount { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        public void GetEmailAddress()
        {
            CookieContainer cookies = new CookieContainer();
            string url = "https://api.guerrillamail.com/ajax.php?f=get_email_address";
            Response response = HttpUtil.Get(url, cookies);
            GuerrillaMail tempmail = JsonConvert.DeserializeObject<GuerrillaMail>(response.Json);
            this.EmailAddress = tempmail.EmailAddress;
            this.EmailAlias = tempmail.EmailAlias;
            this.EmailTimestamp = tempmail.EmailTimestamp;
            this.Cookies = response.Cookies;
            this.SidToken = tempmail.SidToken;
            tempmail = null;
        }

        public void CheckEmail()
        {
            string url = "https://api.guerrillamail.com/ajax.php?f=check_email&seq=0";
            Response response = HttpUtil.Get(url, Cookies);
            this.Cookies = response.Cookies;
            GuerrillaMail tempmail = JsonConvert.DeserializeObject<GuerrillaMail>(response.Json);
            this.EmailCount = tempmail.EmailCount;
            this.Emails = tempmail.Emails;
            this.Stats = tempmail.Stats;
            this.SidToken = tempmail.SidToken;
            tempmail = null;
        }
        public Email FetchEmail(string id)
        {
            string url = "https://api.guerrillamail.com/ajax.php?f=fetch_email&email_id=" + id;
            Response response = HttpUtil.Get(url, Cookies);
            this.Cookies = response.Cookies;
            Email email = JsonConvert.DeserializeObject<Email>(response.Json);
            return email;
        }



    }

