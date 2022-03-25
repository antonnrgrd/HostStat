
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Collections.Generic;
using System;
using InfoRetrieval;
using iText.Layout;
namespace Emailer{
    class EmailSender{
        public EmailSender(){

        }

        void emailRecipients(List<string> recipients, Document report ){
            SmtpClient mySmtpClient = new SmtpClient("my.smtp.exampleserver.net");
            MailMessage statusMessage =  new MailMessage(
        "jane@contoso.com",
        "ben@contoso.com",
        "Quarterly data report.",
       DateTime.Now.ToString(@"dd\/MM\/yyyy h\:mm tt") + "See the attached spreadsheet.");
            foreach(string recipient in recipients){
                mySmtpClient.Send(statusMessage);
            }
        }
    }
}