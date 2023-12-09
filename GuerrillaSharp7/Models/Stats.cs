using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuerrillaSharp7;


public class Stats
{
    [JsonProperty("sequence_mail")]
    public string SequenceMail { get; set; }

    [JsonProperty("created_addresses")]
    public int CreatedAddresses { get; set; }

    [JsonProperty("received_emails")]
    public string ReceivedEmails { get; set; }

    [JsonProperty("total")]
    public string Total { get; set; }

    [JsonProperty("total_per_hour")]
    public string TotalPerHour { get; set; }
}
