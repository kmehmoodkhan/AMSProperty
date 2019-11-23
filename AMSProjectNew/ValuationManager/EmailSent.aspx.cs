using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace AMSProjectNew.ValuationManager
{
    public partial class EmailSent : System.Web.UI.Page
    {
        protected string strRedirect = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["JobId"] != null)
                {
                    lblJobId1.Text = Request.QueryString["JobId"].ToString();
                    lblMessage.Text = "Your email sent successfully. Click on below button to go to Job Details.";
                    //strRedirect = "window.setTimeout(function(){window.location.href = 'JobDetails.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]) + "';}, 5000);";
                }
            }
        }

        protected void btnGoJobDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobOrderDetails.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
        }
    }
}
