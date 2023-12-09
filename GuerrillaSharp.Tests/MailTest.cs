using System;
using GuerrillaSharp7;
using System.Linq;
namespace GuerrillaSharp7;

public class UnitTest1
{
    GuerrillaMail email = new GuerrillaMail();

    [Fact]
    public void TestGetEmailAddress()
    {
        email.GetEmailAddress();
        Assert.NotNull(email.EmailAddress);
    }

    [Fact]
    public void TestCheckEmail()
    {
        email.GetEmailAddress();
        email.CheckEmail();
        Assert.NotNull(email.Emails);
    }

    [Fact]
    public void TestFetchEmail()
    {
        email.GetEmailAddress();
        email.CheckEmail();
        Email selectemail = email.FetchEmail(email.Emails.FirstOrDefault().MailId);
        Assert.NotNull(selectemail.MailId);
    }
}

