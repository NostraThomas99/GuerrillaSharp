using System;
using GuerrillaSharp7;
using System.Linq;
using GuerrillaSharp7.Models;

namespace GuerrillaSharp7.Tests;

public class MailTest
{
    const string fromAddr = "no-reply@guerrillamail.com";
    private GuerrillaMail emailClient;
    public MailTest()
    {
        emailClient = new GuerrillaMail();
    }
    [Fact]
    public void TestGetEmailAddress()
    {
        Assert.NotNull(emailClient.MailData.EmailAddress);
    }

    [Fact]
    public void TestCheckEmail()
    {
        emailClient.CheckEmail();
        Assert.NotNull(emailClient.MailData.Emails);
    }

    [Fact]
    public void TestFetchEmail()
    {
        emailClient.CheckEmail();
        Assert.NotNull(emailClient.MailData.Emails);
        var mailId = emailClient.MailData.Emails?.FirstOrDefault()?.MailId;
        Assert.NotNull(mailId);
        Email? selectemail = emailClient.FetchEmail(mailId);
        Assert.NotNull(selectemail?.MailId);
    }

    [Fact]
    public void TestCheckAndGetEmails()
    {
        List<Email> emails = emailClient.CheckAndGetEmails();
        Assert.NotNull(emails);
    }

    [Fact]
    public void TestCheckAndWaitForMailFromAddr()
    {
        List<Email> emails = emailClient.CheckAndWaitForMailFromAddr(fromAddr, 5);
        Assert.NotEmpty(emails);
        Assert.All(emails, email => Assert.Contains(fromAddr, email.MailFrom));
    }

    [Fact]
    public void TestCheckAndGetEmailsFromAddr()
    {
        List<Email> emails = emailClient.CheckAndGetEmails(fromAddr);
        Assert.NotEmpty(emails);
        Assert.All(emails, email => Assert.Contains(fromAddr, email.MailFrom));
    }
}

