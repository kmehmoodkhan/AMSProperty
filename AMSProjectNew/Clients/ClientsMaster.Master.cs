using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMSProjectNew.Clients
{
    public partial class ClientsMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null && Convert.ToString(Session["UserId"]) != "")
            {
                if (Session["FullName"] != null && Convert.ToString(Session["FullName"]) != "")
                {
                    lblUsername.Text = Convert.ToString(Session["FullName"]);
                    if (Convert.ToString(Session["LastLoggedOn"]) != "")
                        lblLastloggedOn.Text = Convert.ToDateTime(Session["LastLoggedOn"]).ToString("MM/dd/yyyy hh:mm:ss");
                    else
                        lblLastloggedOn.Text = "N/A";
                }
                else
                    Response.Redirect("~/Logout.aspx?From=Timeout", false);
            }
            else
                Response.Redirect("~/Logout.aspx?From=Timeout", false);
        }
    }
}
