using DDD.Common.Email;
using NUnit.Framework;

namespace DDD.Common.Test;

[TestFixture]
public class EmailTests
{
    [TestCase("foo@bar.com", ExpectedResult = true)]
    [TestCase("foobar.com", ExpectedResult = false)]
    public bool TestIsValid(string email)
    {
        var address = new EmailAddress(email);
        return address.IsValid;
    }

    [TestCase("foo@bar.com;baz@bar.com", ExpectedResult = "foo@bar.com;baz@bar.com")]
    [TestCase("foo@bar.com;bazbar.com", ExpectedResult = "foo@bar.com")]
    public string TestAddressList(string emails)
    {
        var addresses = new EmailAddressList(emails);
        return addresses.ToString();
    }
}
