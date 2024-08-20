using System.Net.Mail;

namespace DDD.Common.Email;

public record EmailAddress
{
    public EmailAddress(string address)
    {
        if (MailAddress.TryCreate(address, out MailAddress? result) && result is not null)
        {
            Address = result.Address;
            IsValid = true;
        }
    }

    public string Address { get; } = string.Empty;
    public bool IsValid { get; }
}
