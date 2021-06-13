using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using BooksApi.Consumers.Model;


namespace BooksApi.Helpers
{
    public static class EmailHelper
    {
        public static void SendBookCreatedMessage(this BookCreatedMessage createdMessage)
        {
            try
            {
                // SmtpClient client = new SmtpClient("smtp.live.com");
                // client.Credentials = new NetworkCredential("enesdanyildiz94@hotmail.com", "semra85");
                // client.Port = 587;
                // client.EnableSsl = true;

                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.live.com";
                client.EnableSsl = true;
                client.Timeout = 50000;
                client.Credentials = new NetworkCredential("enesdanyildiz94@hotmail.com", "semra85");
                // Specify the email sender.
                // Create a mailing address that includes a UTF8 character
                // in the display name.
                MailAddress from = new MailAddress("enesdanyildiz94@hotmail.com", "BookApiRabbitMq", System.Text.Encoding.UTF8);
                // Set destinations for the email message.
                MailAddress to = new MailAddress(createdMessage.ToAddress);
                // Specify the message content.
                MailMessage message = new MailMessage(from, to);
                message.Body = $"Yazar {createdMessage.Author}'dan yeni  bir kitap.{Environment.NewLine}{createdMessage.Name} kitabı sadece {createdMessage.Price} ₺.";
                // Include some non-ASCII characters in body and subject.
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.Subject = "Yeni kitap Hakkında";
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                // Set the method that is called back when the send operation ends.

                // client.SendCompleted += new
                // SendCompletedEventHandler(SendCompletedCallback);

                // The userState can be any object that allows your callback
                // method to identify this send operation.
                // For this example, the userToken is a string constant.
                client.Send(message);
                client.Dispose();
                // Clean up.
                message.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}