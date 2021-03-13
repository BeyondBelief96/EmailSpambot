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
            client.Credentials = new System.Net.NetworkCredential("brandonberisford@gmail.com", "Mtsuphysics96+");

            MailMessage email = new MailMessage();
            email.IsBodyHtml = true;
            email.AlternateViews.Add(GetEmbeddedImage(@"C:\Users\brand\Desktop\peepo.png"));
            email.From = new MailAddress("brandonberisford@gmail.com");
            email.To.Add("brandonberisford@gmail.com");
            email.Subject = "NUCLEAR MISSILE HEADED TO US. TAKE COVER";
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
