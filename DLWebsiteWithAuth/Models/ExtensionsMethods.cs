using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;

namespace DLWebsiteWithAuth.Models
{
    public static class ExtensionsMethods
    {
        public static string ReplaceString(this string originalValue, string whattoreplace, string replacewith)
        {
            string orgvalue = originalValue;

            StringBuilder sb = new StringBuilder();
            string compvalue = orgvalue;

            compvalue = compvalue.ToUpper();

            if (compvalue.Contains(whattoreplace.ToUpper()))
            {
                string[] res = orgvalue.Split(' ');
                if (res.Length > 0)
                {
                    for (int i = 0; i < res.Length; i++)
                    {
                        if (res[i].ToUpper().Equals(whattoreplace.ToUpper()))
                        {
                            string ss = res[i].ToUpper();
                            ss = ss.Replace(whattoreplace.ToUpper(), "^"+replacewith+"^");
                            sb.Append(ss + " ");
                        }
                        else
                        {
                            sb.Append(res[i] + " ");
                        }
                    }
                }
            }
            else
                sb.Append(orgvalue);


            sb = sb.Replace("<", "");
            sb = sb.Replace(">", "");
            return sb.ToString().Replace(";", ",");
        }




        public static void sendemail(emailfields _emailfields)
        {

            string mFrom = _emailfields.from_whom;
            MailMessage message = default(MailMessage);
            try
            {
                message = new MailMessage(mFrom, _emailfields.To_whom);
            }
            catch
            {
                message = new MailMessage(mFrom, "ajitl@duncanlewis.com");
            }
            message.IsBodyHtml = true;
            message.Subject = _emailfields.subject;



            message.ReplyTo = new MailAddress(_emailfields.from_whom, "Re:" + _emailfields.subject);
            if (_emailfields.formatted == true)
            {
                message.Body = "<p style=\"font-family:Arial; font-size:14px\">" + _emailfields.msg + "</p>";
            }
            else
            {
                message.Body = _emailfields.msg;
            }

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(_emailfields.msg, null, "text/html");

            if (_emailfields._embeddedimagelist != null)
            {
                foreach (var el in _emailfields._embeddedimagelist)
                {
                    LinkedResource LinkedImage = new LinkedResource(el.path);
                    LinkedImage.ContentId = el.contentid;
                    if (el._mimetype == mimetype.JPEG)
                    {
                        LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);
                    }
                    else if (el._mimetype == mimetype.GIF)
                    {
                        LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Gif);
                    }
                    else if (el._mimetype == mimetype.PNG)
                    {
                        LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);
                    }
                    htmlView.LinkedResources.Add(LinkedImage);
                }
            }

            message.AlternateViews.Add(htmlView);


            if ((_emailfields.cclist != null) && _emailfields.cclist.Count > 0)
            {
                foreach (string item in _emailfields.cclist)
                {
                    try
                    {
                        message.CC.Add(item.ToString());
                    }
                    catch
                    {
                        message.CC.Add("ajitl@duncanlewis.com");
                    }
                }
            }
            if ((_emailfields.bcclist != null) && _emailfields.bcclist.Count > 0)
            {
                foreach (string item in _emailfields.bcclist)
                {
                    try
                    {
                        message.Bcc.Add(item.ToString());
                    }
                    catch
                    {
                        message.Bcc.Add("ajitl@duncanlewis.com");
                    }
                }
            }

            if (_emailfields.attachments != null)
            {
                foreach (string att in _emailfields.attachments)
                {
                    System.Net.Mail.Attachment attachment1;
                    attachment1 = new System.Net.Mail.Attachment(att);
                    message.Attachments.Add(attachment1);
                }
            }

            var basicCredential = new NetworkCredential("booking@24-7languageservices.com", "24-7languageservices.com");
            //SmtpClient smtpClient = new SmtpClient("81.150.163.113", 25);
            //smtpClient.Host = "81.150.163.113";
            //smtpClient.UseDefaultCredentials = false;
            //smtpClient.Credentials = basicCredential;
            string smtphost = ConfigurationManager.AppSettings["SMTPServer"].ToString();
            SmtpClient smtpClient = new SmtpClient(smtphost, 25);
            message.Priority = MailPriority.High;
            smtpClient.Send(message);
        }

    }


    public class emailfields
    {

        public string To_whom { get; set; }
        public string from_whom { get; set; }
        public string subject { get; set; }
        public string msg { get; set; }
        public List<string> cclist { get; set; }
        public List<string> bcclist { get; set; }
        public bool formatted { get; set; }
        public List<embeddedImagelist> _embeddedimagelist { get; set; }
        public List<string> attachments { get; set; }

        public emailfields()
        {
            this.formatted = true;
        }
    }

    public class embeddedImagelist
    {
        public string path { get; set; }
        public string contentid { get; set; }
        public mimetype _mimetype { get; set; }
    }
    public enum mimetype
    {
        GIF,
        JPEG,
        PNG
    }
}