using System;
using System.Net.Mail;
using System.Net.Mime;
namespace EmailSpambot
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("your gmail email", "your gmail password");

            MailMessage email = new MailMessage();
            email.IsBodyHtml = true;
<<<<<<< HEAD
            email.AlternateViews.Add(GetEmbeddedImage(@"file path to image file to send."));
            email.From = new MailAddress("your email address");
            email.To.Add("email address of recipient.");
            email.Subject = "Subject of the email.";
=======
            email.AlternateViews.Add(GetEmbeddedImage(@"file path to a image file.));
            email.From = new MailAddress("your email address");
            email.To.Add("email address of person your trying to spam");
            email.Subject = "replace with email subject title";
>>>>>>> 211e7fadba5a0821bca6f3e89e17a4187d0d64f2
            email.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;


            AlternateView GetEmbeddedImage(String filePath)
            {
                LinkedResource res = new LinkedResource(filePath);
                res.ContentId = Guid.NewGuid().ToString();
                string htmlBody = @"<img src='cid:" + res.ContentId + @"'/>";
                AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
                alternateView.LinkedResources.Add(res);
                return alternateView;
            }

            for(int i = 0; i < 100; i++)
            {
                client.Send(email);
                Console.WriteLine("Sending...");
            }
            

            Console.ReadLine();
            
        }
    }
}
