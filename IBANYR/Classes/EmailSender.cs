using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace IBANYR
{
    static class EmailSender
    {
        #region Private fields
        static SmtpClient smtp = new SmtpClient();
        static AppConfiguration conf;
        #endregion
        #region Methods and Functions
        /// <summary>
        /// Email küldésére használt metódus
        /// </summary>
        /// <param name="subject">Az üzenet tárgya</param>
        /// <param name="message">Az üzenet szöveges tartalam</param>
        /// <param name="addressee">A címzett felhasználó <see cref="User"/> osztályú példánya</param>
        public static void SendEmail(string subject, string message, User addressee)
        {
            try
            {
                string messageStart = $"<HTML><BODY><h1 style=\"font-weight:bold;font-size:14px\">Kedves {addressee.UName}!</h1><section style=\"text-align:justify;font-size:12px\">";
                string messageEnd = $"<p>Üdvözlettel<br><font style=\"font-weight:bold;font-style: italic;\">Informatikai Biztonsági Adminisztratív Nyilvántartó Rendszer</font></p></section><hr style=\"background: linear - gradient(to right, rgb(204, 204, 204), rgb(86, 86, 86), rgb(204, 204, 204)) rgb(86, 86, 86); border: 0px currentColor; border - image: none; height: 1px;\"><footer style=\"font-style: italic;text-align:justify;font-size:12px\"><img src=\"cid:logo\" title=\"Informatikai Biztonsági Adminisztratív Nyilvántartó Rendszer\"/>Ez egy automatikusan generált üzenet! Kérem, ne válaszoljon rá!</footer></BODY></HTML>";
                message = messageStart + message + messageEnd;

                MailMessage mail = new MailMessage();

                conf = DBManager.GetConfiguration();
                mail.To.Add(addressee.Email);
                mail.Subject = subject;
                mail.SubjectEncoding = Encoding.UTF8;
                string sender = !String.IsNullOrEmpty(conf.EmailAddress) ? conf.EmailAddress : "no-reply@ibanyr.hu";
                mail.Headers.Add("Sender", sender);
                string pattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

                mail.From = new MailAddress(Regex.IsMatch(Password.Decrypt(conf.SmtpUserName), pattern) ? Password.Decrypt(conf.SmtpUserName) : sender, "Informatikai Biztonsági Adminisztratív Nyilvántartó Rendszer");

                mail.IsBodyHtml = true;

                AlternateView view = AlternateView.CreateAlternateViewFromString(message, null, MediaTypeNames.Text.Html);
                LinkedResource resource = new LinkedResource($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\ibanyr.png", MediaTypeNames.Image.Jpeg);
                resource.ContentId = "logo";
                view.LinkedResources.Add(resource);
                mail.AlternateViews.Add(view);


                smtp = new SmtpClient(conf.SmtpServer)
                {
                    Port = conf.Port,
                    EnableSsl = conf.EnableSSL,
                    Credentials = new NetworkCredential(Password.Decrypt(conf.SmtpUserName), Password.Decrypt(conf.SmtpPassword))
                };
                smtp.SendCompleted += (s, e) => {
                    mail.Dispose();
                    smtp.Dispose();
                };
                smtp.SendAsync(mail, mail.Subject);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
