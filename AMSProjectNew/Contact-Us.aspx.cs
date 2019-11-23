using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.IO;
using System.Net.Mail;
using System.Net;


namespace AMSProjectNew
{
    public partial class Contact_Us : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            string SMTP = System.Configuration.ConfigurationSettings.AppSettings["SMTP"].ToString();
            string Port = System.Configuration.ConfigurationSettings.AppSettings["Port"].ToString();

            CommonController objCommonController = new CommonController();
            StreamReader sr = new StreamReader(Server.MapPath("~/EmailTemplates/ContactUs.htm"));
            string strMsg = sr.ReadToEnd();
            strMsg = strMsg.Replace("{Name}", txtFullName.Text.Trim());
            strMsg = strMsg.Replace("{Email}", txtEmailAddress.Text.Trim());
            strMsg = strMsg.Replace("{Message}", txtMessage.Text.Trim().Replace("\r", "<br>"));

            objCommonController.SendContactUs(System.Configuration.ConfigurationManager.AppSettings["AdminEmail"].ToString(),txtEmailAddress.Text.Trim(), strMsg);
            objCommonController.SendContactUs("ndfd2008@gmail.com", txtEmailAddress.Text.Trim(), strMsg);

            //MailMessage mMessage = new MailMessage("valuations@marketval.com.au", "ndfd2008@gmail.com");
            //mMessage.Subject = "Inquiry Details";
            //mMessage.Body = strMsg;
            //mMessage.IsBodyHtml = true;
            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = SMTP;
            //smtp.Port = Convert.ToInt16(Port);//25
            //smtp.UseDefaultCredentials = true;
            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            
            try
            {
                //smtp.Send(mMessage);
                lblError.Text = "Email sent successfully.<br>Please allow us 72 hours to look at your request and we will get back to you soon.";
                txtEmailAddress.Text = "";
                txtFullName.Text = "";
                txtMessage.Text = "";



                //SmtpClient SmtpMail = new SmtpClient("outlook.office365.com", 587);
                ////SmtpMail.Credentials = new NetworkCredential("valuations@marketval.com.au", "goCROWS20001");
                //SmtpMail.UseDefaultCredentials = true;
                //SmtpMail.DeliveryMethod = SmtpDeliveryMethod.Network;
                ////////Smtpclient to send the mail message
                //////SmtpClient SmtpMail = new SmtpClient();
                //////SmtpMail.DeliveryMethod = SmtpDeliveryMethod.Network;
                //SmtpMail.Send(mMessage);
                //////Message Successful                          
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            
        }
    }
}
