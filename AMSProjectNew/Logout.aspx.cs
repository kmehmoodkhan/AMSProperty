using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMSProjectNew
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["TDSelectedJobJob"] = null;
                Session["TDSelected"] = null;
                Session["UserId"] = null;
                Session["Username"] = null;
                Session["UserType"] = null;
                Session["FullName"] = null;
                Session["Email"] = null;
                Session["LastLoggedOn"] = null;
                Session["JobPageSize"] = null;
                Session.Abandon();
            }
        }
    }
}
