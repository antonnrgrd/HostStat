
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
            /*We use Mimekit SPECIFICALLY because Microsoft reccomends to use over its default built-in mail 
             capabilities since it does not support many modern protocols*/
            MimeMessage mailMessage = new MimeMessage();
            foreach (string recipient in recipients) {
                mailMessage.From.Add(new MailboxAddress(recipient, recipient));
            }
            mailMessage.To.Add(new MailboxAddress("to name", userMail));
            mailMessage.Subject = "Results of network host scan";
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "A scan of the given hosts has been completed. See the attached PDF for details";
            bodyBuilder.Attachments.Add(reportPath);
            mailMessage.Body = bodyBuilder.ToMessageBody();
          
            using (SmtpClient smtpClient = new SmtpClient()) {
                smtpClient.Connect(emailProvider, 587);
                smtpClient.Authenticate(userMail, password);
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);
            }
           
        }
        
    }
}