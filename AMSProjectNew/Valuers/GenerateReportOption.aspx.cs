using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMSProjectNew.Valuers
{
    public partial class GenerateReportOption : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobOrderGenerateReport.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            Response.Redirect("GenerateReport.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
        }
    }
}
