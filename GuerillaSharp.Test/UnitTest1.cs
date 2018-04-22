using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuerrillaSharp;
using System.Linq;
using GuerrillaSharp.Models;

namespace GuerillaSharp.Test
{
    [TestClass]
    public class UnitTest1
    {
        GuerrillaMail email = new GuerrillaMail();

        [TestMethod]
        public void TestGetEmailAddress()
        {
            email.GetEmailAddress();
            Assert.IsNotNull(email.EmailAddress);
        }

        [TestMethod]
        public void TestCheckEmail()
        {
            email.GetEmailAddress();
            email.CheckEmail();
            Assert.IsNotNull(email.Emails);
        }

        [TestMethod]
        public void TestFetchEmail()
        {
            email.GetEmailAddress();
            email.CheckEmail();
            Email selectemail = email.FetchEmail(email.Emails.FirstOrDefault().MailId);
            Assert.IsNotNull(selectemail.MailId);
        }
    }
}
