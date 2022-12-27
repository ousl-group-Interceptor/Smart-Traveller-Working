using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class Email : MonoBehaviour
{
    //public InputField bodyMessage;
    public InputField recipientEmail;
    public InputField recipientMobile;
    private int rnum = 0;
    private string email = "planetd.interceptor@gmail.com";
    private string password = "gtjeaggsmqgbbixu";
    private string smpthost = "smtp.gmail.com";

    public void SendEmail()
    {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient(smpthost);
        SmtpServer.Timeout = 10000;
        SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        SmtpServer.UseDefaultCredentials = false;
        SmtpServer.Port = 587;

        mail.From = new MailAddress("no-reply@gmail.com");
        mail.To.Add(new MailAddress(recipientEmail.text));

        rnum = Random.Range(99999, 999998);
        rnum++;
        Debug.Log(rnum);
        mail.Subject = "SignUp confirm OTP";
        mail.Body = "Your sign in OTP is " + rnum + ". Do not shear this to anyone.";


        SmtpServer.Credentials = new System.Net.NetworkCredential(email, password) as ICredentialsByHost; SmtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };

        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpServer.Send(mail);
    }


    public void SendText()
    {
        string phoneNumber = recipientMobile.text;
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient(smpthost);
        SmtpServer.Timeout = 10000;
        SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        SmtpServer.UseDefaultCredentials = false;

        mail.From = new MailAddress(email);

        //mail.To.Add(new MailAddress(phoneNumber + "@txt.att.net"));//See carrier destinations below
        //mail.To.Add(new MailAddress(phoneNumber + "5551234568@txt.att.net"));
        mail.To.Add(new MailAddress(phoneNumber + "@vtext.com"));
        mail.To.Add(new MailAddress(phoneNumber + "@messaging.sprintpcs.com"));
        mail.To.Add(new MailAddress(phoneNumber + "@tmomail.net"));
        mail.To.Add(new MailAddress(phoneNumber + "@vmobl.com"));
        //mail.To.Add(new MailAddress(phoneNumber + "@messaging.nextel.com"));
        mail.To.Add(new MailAddress(phoneNumber + "@myboostmobile.com"));
        mail.To.Add(new MailAddress(phoneNumber + "@message.alltel.com"));
        mail.To.Add(new MailAddress(phoneNumber + "@mms.ee.co.uk"));



        mail.Subject = "Test";
        mail.Body = "Hello Developer";

        SmtpServer.Port = 587;

        SmtpServer.Credentials = new System.Net.NetworkCredential(email, password) as ICredentialsByHost; SmtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            Debug.Log("True");
            return true;
        };

        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpServer.Send(mail);
        Debug.Log("Ok");
    }
}





//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using MimeKit;
//using System.IO;
//using MailKit.Net.Smtp;
//using MailKit.Security;
//using System.Net.Mail;
//using System.Net.Mime;
//using UnityEngine.UI;
//using SmtpClient = MailKit.Net.Smtp.SmtpClient;

//public class Email : MonoBehaviour
//{
//    public InputField recipientEmail;
//    private int rnum = 0;
//    private string email = "planetd.interceptor@yahoo.com";
//    private string password = "interceptor@2022";
//    private string smpthost = "smtp.mail.yahoo.com";
//    public void SendEmail()
//    {
//        var message = new MimeMessage();
//        message.From.Add(new MailboxAddress("HH - Email Sender", "no-reply@planetD.com"));
//        message.To.Add(new MailboxAddress("HH - Email Receiver", recipientEmail.text.ToString()));
//        message.Subject = "HH Help Email Subject";

//        rnum = Random.Range(99999, 999998);
//        rnum++;
//        Debug.Log(rnum);

//        var multipartBody = new Multipart("mixed");
//        {
//            var textPart = new TextPart("plain")
//            {
//                Text = @"Your sign in OTP is " + rnum + ". Do not shear this to anyone."
//            };
//            multipartBody.Add(textPart);

//            //string attachmentPath = IMAGE_PATH;
//            //var attachmentPart = new MimePart("image/png")
//            //{
//            //    Content = new MimeContent(File.OpenRead(attachmentPath), ContentEncoding.Default),
//            //    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
//            //    ContentTransferEncoding = ContentEncoding.Base64,
//            //    FileName = Path.GetFileName(attachmentPath)
//            //};
//            //multipartBody.Add(attachmentPart);

//            //string logPath = LOG_PATH;
//            //var logPart = new MimePart("text/plain")
//            //{
//            //    Content = new MimeContent(File.OpenRead(logPath), ContentEncoding.Default),
//            //    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
//            //    ContentTransferEncoding = ContentEncoding.Base64,
//            //    FileName = Path.GetFileName(logPath)
//            //};
//            //multipartBody.Add(logPart);
//        }
//        message.Body = multipartBody;

//        using (var client = new SmtpClient())
//        {
//            // This section must be changed based on your sender's email host
//            // Do not use Gmail
//            client.Connect(smpthost, 587, false);

//            client.AuthenticationMechanisms.Remove("XOAUTH2");
//            client.Authenticate(email, password);
//            client.Send(message);
//            client.Disconnect(true);
//            Debug.Log("Sent email");
//        }
//    }
//}