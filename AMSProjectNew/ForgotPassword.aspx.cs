using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.IO;

namespace AMSProjectNew
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            UsersController objUsersController = new UsersController();
            DataSet ds = new DataSet();
            try
            {
                ds = objUsersController.UsersLogin(txtUsername.Text.Trim(), "", "FORGOTPASSWORD");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    SendEmail(Convert.ToString(ds.Tables[0].Rows[0]["Password"]), Convert.ToString(ds.Tables[0].Rows[0]["Email"]));
                }
                else
                {
                    lblError.Text = "Invalid email address.";
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objUsersController = null;
            }
        }
        public void SendEmail(string Password, string Email)
        {
            CommonController objCommonController = new CommonController();
            StreamReader sr = new StreamReader(Server.MapPath("~/EmailTemplates/ForgetPassword.html"));
            string strMsg = sr.ReadToEnd();
            strMsg = strMsg.Replace("{Username}", txtUsername.Text.Trim());
            strMsg = strMsg.Replace("{Password}", Password);
            objCommonController.SendForgetPasswordEmail(Email, strMsg);
            lblError.Text = "Email sent with your login details.";
            txtUsername.Text = "";
        }
    }
}
