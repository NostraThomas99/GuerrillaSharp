using Newtonsoft.Json;

namespace GuerrillaSharp;


public class Email
{
    [JsonProperty("mail_id")]
    public string MailId { get; set; }

    [JsonProperty("mail_from")]
    public string MailFrom { get; set; }

    [JsonProperty("mail_subject")]
    public string MailSubject { get; set; }

    [JsonProperty("mail_excerpt")]
    public string MailExcerpt { get; set; }

    [JsonProperty("mail_timestamp")]
    public string MailTimestamp { get; set; }

    [JsonProperty("mail_read")]
    public string MailRead { get; set; }

    [JsonProperty("mail_date")]
    public string MailDate { get; set; }

    [JsonProperty("att")]
    public string Att { get; set; }

    [JsonProperty("mail_size")]
    public string MailSize { get; set; }

    [JsonProperty("reply_to")]
    public string ReplyTo { get; set; }

    [JsonProperty("content_type")]
    public string ContentType { get; set; }

    [JsonProperty("mail_recipient")]
    public string MailRecipient { get; set; }

    [JsonProperty("source_id")]
    public int? SourceId { get; set; }

    [JsonProperty("source_mail_id")]
    public int? SourceMailId { get; set; }

    [JsonProperty("mail_body")]
    public string MailBody { get; set; }

    [JsonProperty("size")]
    public int? Size { get; set; }
}

