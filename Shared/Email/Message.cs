using System.Text;
using MimeKit;

namespace iSchool_Solution.Shared.Email;

public class Message
{
    public List<MailboxAddress> To { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }

    public Message(IEnumerable<string> to, string subject, string content)
    {
        To = new List<MailboxAddress>();

        // Safely create MailboxAddress instances
        To.AddRange(to
            .Where(email => !string.IsNullOrWhiteSpace(email))
            .Select(email => new MailboxAddress(Encoding.UTF8, "", email)));
        
        Subject = subject;
        Content = content;        
    }
}