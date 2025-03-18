using System.Text;
using iSchool_Solution.Shared.Email;
using MailKit.Net.Smtp;
using MimeKit;

namespace iSchool_Solution.Services;

public class EmailService(EmailConfiguration emailConfig, ILogger<EmailService> logger)
{
    public async Task SendEmail(Message message)
    {
        var emailMessage = CreateEmailMessage(message);
        await SendAsync(emailMessage);
    }

    public async Task SendTwoFactorToken(string email, string token)
    {
        // Validate input parameters
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email address cannot be null or empty", nameof(email));

        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentException("Token cannot be null or empty", nameof(token));

        // Message specifically for 2FA token
        var message = new Message(
            [email],
            "Your Two-Factor Authentication Token",
            $"Your two-factor authentication token is: {token}\n\n" +
            "This token will expire in 10 minutes. " +
            "Do not share this token with anyone."
        );

        await SendEmail(message);
    }

    private MimeMessage CreateEmailMessage(Message message)
    {
        var emailMessage = new MimeMessage();

        // Use a fallback sender name and email if configuration is incomplete
        const string senderName = "Admin";
        var senderEmail = emailConfig.From;

        // Safely create sender MailboxAddress
        emailMessage.From.Add(new MailboxAddress(
            Encoding.UTF8,
            senderName,
            senderEmail
        ));

        // Validate and add recipients
        var validRecipients = message.To
            .Where(recipient => !string.IsNullOrWhiteSpace(recipient.Address))
            .ToList();

        if (validRecipients.Count == 0)
            throw new InvalidOperationException("No valid email recipients found");

        emailMessage.To.AddRange(validRecipients);

        emailMessage.Subject = message.Subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
        {
            Text = message.Content
        };

        return emailMessage;
    }

    private async Task SendAsync(MimeMessage mailMessage)
    {
        using var client = new SmtpClient();
        try
        {
            await client.ConnectAsync(emailConfig.SmtpServer, emailConfig.Port, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync(emailConfig.UserName, emailConfig.Password);

            client.Send(mailMessage);
        }
        catch
        {
            logger.LogWarning("Error sending email");
            throw;
        }
        finally
        {
            await client.DisconnectAsync(true);
            client.Dispose();
        }
    }
}