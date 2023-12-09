using System;
using GuerrillaSharp7.Models;
using Newtonsoft.Json;

namespace GuerrillaSharp7.Models;

public class GuerrillaMailData
{
    [JsonProperty("sid_token")]
    public string? SidToken { get; set; }

    [JsonProperty("email_addr")]
    public string? EmailAddress { get; set; }

    [JsonProperty("email_timestamp")]
    public string? EmailTimestamp { get; set; }

    [JsonProperty("alias")]
    public string? EmailAlias { get; set; }

    [JsonProperty("list")]
    public List<Email>? Emails { get; set; }

    [JsonProperty("count")]
    public int EmailCount { get; set; }

    [JsonProperty("stats")]
    public Stats? Stats { get; set; }
}