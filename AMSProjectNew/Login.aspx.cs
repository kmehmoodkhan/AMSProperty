using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;

namespace AMSProjectNew
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UsersController userController = new UsersController();
            DataSet ds = new DataSet();
            try
            {
                ds = userController.UsersLogin(txtUsername.Text.Trim(), txtPassword.Text.Trim(), "LOGIN");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) != "2")
                    {
                        lblError.Text = "Your account is not active. Please contact administrator.";
                        return;
                    }

                    UpdateLastLoggedOn();
                    Session["UserId"] = Convert.ToString(ds.Tables[0].Rows[0]["Id"]);
                    Session["Username"] = Convert.ToString(ds.Tables[0].Rows[0]["Username"]);
                    Session["UserType"] = Convert.ToString(ds.Tables[0].Rows[0]["UserType"]);
                    Session["FullName"] = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
                    Session["Email"] = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                    Session["LastLoggedOn"] = Convert.ToString(ds.Tables[0].Rows[0]["LastLoggedOn"]);
                    Session.Timeout = 120;
                    if (Convert.ToString(ds.Tables[0].Rows[0]["UserType"]) == "SuperAdministrator")
                        Response.Redirect("~/Admin/ManageJobOrderList.aspx", false);
                    if (Convert.ToString(ds.Tables[0].Rows[0]["UserType"]) == "Clients")
                        Response.Redirect("~/Clients/Default.aspx", false);
                    if (Convert.ToString(ds.Tables[0].Rows[0]["UserType"]) == "ValuationManager")
                    {
                        Session["TDSelectedJob"] = "InProgress";
                        Response.Redirect("~/ValuationManager/JobOrderList.aspx", false);
                        //Response.Redirect("~/ValuationManager/Default.aspx", false);
                    }
                    if (Convert.ToString(ds.Tables[0].Rows[0]["UserType"]) == "ValuationCompany")
                        Response.Redirect("~/ValuationCompany/Default.aspx", false);
                    if (Convert.ToString(ds.Tables[0].Rows[0]["UserType"]) == "Valuers")
                        Response.Redirect("~/Valuers/Default.aspx", false);
                    if (Convert.ToString(ds.Tables[0].Rows[0]["UserType"]) == "Reviewers")
                        Response.Redirect("~/Reviewers/Default.aspx", false);
                    else
                        lblError.Text = "Invalid username and password.";
                }
                else
                {
                    lblError.Text = "Invalid username and password.";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void UpdateLastLoggedOn()
        {
            UsersController userController = new UsersController();
            DataSet ds = new DataSet();
            try
            {
                userController.UsersLoginCreate(txtUsername.Text.Trim(), txtPassword.Text.Trim(),"", "UPDATELASTLOGIN");
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
