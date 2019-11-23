using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;
using System.Net;

namespace AMSProjectNew
{
    public partial class AdelaideInstantQuote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    string FromEmail = txtEmail.Text.Trim();//System.Configuration.ConfigurationSettings.AppSettings["FromEmail"].ToString();
                    string Username = System.Configuration.ConfigurationSettings.AppSettings["Username"].ToString();
                    string FromName = txtName.Text.Trim();// System.Configuration.ConfigurationSettings.AppSettings["FromName"].ToString();
                    string SMTP = System.Configuration.ConfigurationSettings.AppSettings["SMTP"].ToString();
                    string Port = System.Configuration.ConfigurationSettings.AppSettings["Port"].ToString();
                    string Password = System.Configuration.ConfigurationSettings.AppSettings["Password"].ToString();


                    MailMessage MailMsg = new MailMessage(new MailAddress(FromEmail), new MailAddress("valuations@adelaidepropertyvaluers.net.au"));
                    //MailMessage MailMsg = new MailMessage(new MailAddress(FromEmail), new MailAddress("ndfd2008@gmail.com"));
                    MailMsg.Subject = "Instant Quote Inquiry Details from AdelaidePropertyValuers.net.au";
                    MailMsg.Body = txtMessage.Text.Trim();
                    MailMsg.Priority = MailPriority.High;
                    MailMsg.IsBodyHtml = true;
                    MailMsg.Bcc.Add("ndfd2008@gmail.com");
                    if (Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["EmailMode"]) == "Server")
                    {
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = SMTP;
                        smtp.Port = Convert.ToInt16(Port);
                        smtp.UseDefaultCredentials = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Send(MailMsg);
                    }
                    else
                    {
                        SmtpClient SmtpMail = new SmtpClient(SMTP, Convert.ToInt16(Port));
                        SmtpMail.Credentials = new NetworkCredential(Username, Password);
                        SmtpMail.Send(MailMsg);
                        
                    }

                    lblMessage.Text = "Thank you for your inquiry details. We will contact you soon.";
                    txtEmail.Text="";
                    txtName.Text = "";
                    txtMessage.Text = "";
                    txtSubject.Text = "";
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
