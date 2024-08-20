namespace DDD.Common.Email;

public record EmailAddressList
{
    public EmailAddressList(string emailAddresses, string separator = ";")
    {
        Addresses = emailAddresses
            .Split(separator)
            .Select(x => new EmailAddress(x))
            .Where(x => x.IsValid)
            .ToList();
    }

    public EmailAddressList(IEnumerable<EmailAddress> emailAddresses)
    {
        Addresses = emailAddresses.ToList();
    }

    public IReadOnlyCollection<EmailAddress> Addresses { get; }

    public string ToString(string separator = ";") => string.Join(separator, Addresses.Select(x => x.Address));
}
