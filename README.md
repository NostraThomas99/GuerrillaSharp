# GuerrillaSharp
C# Library for GuerrillaMail API

A tiny little library for using GuerrillaMail apis in your C# app. Receive any emails you need to with this!

Usage:

GuerrillaMail mail = new GuerrillaMail;



mail.GetEmailAddress();      Initializes mailbox

mail.CheckEmail();      Checks mailbox for email

mail.FetchEmail(emailId);       Gets specific email

