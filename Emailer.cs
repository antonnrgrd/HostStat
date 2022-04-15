
using System.Net;
using System.Collections.Generic;
using System;
using InfoRetrieval;
using MimeKit;
using MailKit.Net.Smtp;

namespace Emailer{
    class EmailSender{
        public EmailSender(){
            
        }

        public void emailRecipients(List<string> recipients,string userMail, string password, string reportPath, string emailProvider){
            MimeMessage mailMessage = new MimeMessage();
            foreach (string recipient in recipients) {
                mailMessage.From.Add(new MailboxAddress(recipient, recipient));
            }
            mailMessage.To.Add(new MailboxAddress("to name", userMail));
            mailMessage.Subject = "Results of network host scan";
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "blah";
            bodyBuilder.Attachments.Add(reportPath);
            mailMessage.Body = bodyBuilder.ToMessageBody();
           // mailMessage.Body = new TextPart("plain") {
          //      Text = "A scan of the hosts has been performed. See attached PDF for a summary"
          //  };

            using (SmtpClient smtpClient = new SmtpClient()) {
                smtpClient.Connect(emailProvider, 587);
                smtpClient.Authenticate(userMail, password);
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);
            }
            /*
            SmtpClient mySmtpClient = new SmtpClient(emailProvider);
            //standard secure SMTP port Modern email servers use port 587 for the secure submission of email for delivery.
            mySmtpClient.Port = 587;
            mySmtpClient.Credentials = new System.Net.NetworkCredential(userMail,password);
            mySmtpClient.EnableSsl = true;
            MailMessage reportMessage = new MailMessage();
            //Unsure why, but for some reason, using the add method for assigning the
            // sender is not an option and so we have to do it manually
            reportMessage.From = new MailAddress(userMail, "");
            reportMessage.Attachments.Add(new Attachment(reportPath));
            reportMessage.Subject = reportPath;
            foreach(string recipient in recipients){
                reportMessage.To.Add(recipient);
            }
            mySmtpClient.Send(reportMessage);
            */
        }
        
    }
}