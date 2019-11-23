using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMSProjectNew
{
    public partial class MessageDisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetInvisible();

                if (Request.QueryString["From"] != null && Convert.ToString(Request.QueryString["From"]) == "CompanyRegistrationSuccess")
                {
                    tblCompanyRegistrationSuccess.Visible = true;
                }
            }
        }

        private void SetInvisible()
        {
            tblCompanyRegistrationSuccess.Visible = false;
        }
    }
}
