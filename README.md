[![Deploy NuGet Package to GitHub Releases](https://github.com/reubinoff/GuerrillaSharp/actions/workflows/package.yml/badge.svg?branch=master)](https://github.com/reubinoff/GuerrillaSharp/actions/workflows/package.yml)
![Nuget](https://img.shields.io/nuget/dt/GuerrillaSharp7)


# GuerrillaMail API

This class provides an interface to interact with the Guerrilla Mail API. Guerrilla Mail is a service that provides disposable email addresses.

https://www.nuget.org/packages/GuerrillaSharp7/


## Methods

- **GetEmailAddress()**: Fetches a new email address from the Guerrilla Mail API and stores it in the `MailData` property.

- **CheckEmail()**: Checks for new emails in the current email session and updates the `MailData` property.

- **CheckAndGetEmails()**: Checks for new emails and returns a list of all emails in the current email session.

- **CheckAndGetEmails(string fromAddr)**: Checks for new emails and returns a list of all emails from the specified address.

- **CheckAndWaitForMailFromAddr(string fromAddr, int timeout = 60)**: Checks for new emails from the specified address and waits until an email is received or the timeout is reached.

- **FetchEmail(string id)**: Fetches a specific email by its ID.

## Usage

To use this class, create a new `GuerrillaMail` object and call its methods. For example:

```csharp
var guerrillaMail = new GuerrillaMail();
var emails = guerrillaMail.CheckAndGetEmails();