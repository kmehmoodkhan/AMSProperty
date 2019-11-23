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
using BusinessLayer;
using System.IO;

namespace AMSProjectNew.Clients
{
    public partial class Reports_Comments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["JobId"] != null && Convert.ToString(Request.QueryString["JobId"]) != "")
                {
                    FillJobOrderDetails();
                    FillTab6Comments();
                }
            }
        }
        private void FillJobOrderDetails()
        {
            JobsController objJobsController = new JobsController();
            DataSet ds = new DataSet();
            try
            {
                string JobId = CommonController.Decrypt(Request.QueryString["JobId"].ToString());
                ds = objJobsController.JobsSelectByJobId(Convert.ToInt64(JobId));

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblCompanyLogo.Text = "<img class='img-responsive' src='" + System.Configuration.ConfigurationManager.AppSettings["URL"].ToString() + "CompanyLogo/" + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedLogo"]) + "' />";
                    lblJobId.Text = Convert.ToString(ds.Tables[0].Rows[0]["JobId"]);
                    if (Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]) != "")
                    {
                        lblAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]) + "/" + Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                    }
                    else
                    {
                        lblAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                    }

                    lblClientName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CustomerFullName"]);

                    if (Convert.ToString(ds.Tables[0].Rows[0]["IsClientReportEdit"]) == "2")
                        Response.Redirect("Reports-Finish.aspx?Done=Yes&JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objJobsController = null;
                ds = null;
            }
        }

        public void FillTab6Comments()
        {
            ReportController objReportController = new ReportController();
            DataSet ds = new DataSet();
            try
            {   
                
                ds = objReportController.Tab6_CommentsSelect(Convert.ToInt64(lblJobId.Text));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtTab6Standard.Value = Convert.ToString(ds.Tables[0].Rows[0]["Standard"]);
                    txtTab6Defects.Value = Convert.ToString(ds.Tables[0].Rows[0]["Defects"]);
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
                ds = null;
            }
        }
        protected void btnTab6Next_Click(object sender, EventArgs e)
        {
            ReportController objReportController = new ReportController();
            Int64 JobId = Convert.ToInt64(lblJobId.Text);
            try
            {
                
                JobId = objReportController.Tab6_CommentsEdit(JobId, "", txtTab6Standard.Value.Trim(),
                    "", txtTab6Defects.Value.Trim(), "",0, "ADD", "");
                if (JobId > 0)
                {
                    SendReportEditByClientToAdmin();
                    JobsController.JobsEditIsClientReportEdit(JobId, 2);
                    Response.Redirect("Reports-Finish.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
            }

        }
        protected void btnTab6Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports-Rooms.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
        }
        private void SendReportEditByClientToAdmin()
        {
            CommonController objCommonController = new CommonController();
            StreamReader sr = new StreamReader(Server.MapPath("~/EmailTemplates/ReportEditByClientToAdmin.html"));
            DataSet ds = new DataSet();
            try
            {
                string strMsg = sr.ReadToEnd();
                strMsg = strMsg.Replace("{JobId}", lblJobId.Text.Trim());

                string URL = System.Configuration.ConfigurationSettings.AppSettings["URL"].ToString() + "Clients/Reports-Buildings.aspx?JobId=" + CommonController.Encrypt(Convert.ToString(Request.QueryString["JobId"]));

                ds = objCommonController.SelectConfirmationofValuersAppointmentDetails(Convert.ToInt64(Request.QueryString["JobId"]));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    strMsg = strMsg.Replace("{CompanyName}", Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]));
                    strMsg = strMsg.Replace("{CompanyAddress1}", Convert.ToString(ds.Tables[0].Rows[0]["CompanyAddress1"]));
                    strMsg = strMsg.Replace("{CompanyAddress2}", Convert.ToString(ds.Tables[0].Rows[0]["CompanyAddress2"]));
                    strMsg = strMsg.Replace("{URL}", URL);
                    strMsg = strMsg.Replace("{ValuerName}", Convert.ToString(ds.Tables[0].Rows[0]["ValuerName"]));
                    strMsg = strMsg.Replace("{ValuerPhone}", Convert.ToString(ds.Tables[0].Rows[0]["ValuerPhone"]));
                    strMsg = strMsg.Replace("{ValuerEmail}", Convert.ToString(ds.Tables[0].Rows[0]["ValuerEmail"]));


                    objCommonController.SendReportEditByClientToAdmin(Convert.ToString(ds.Tables[0].Rows[0]["CompanyEmail"]),
                        Convert.ToString(ds.Tables[0].Rows[0]["CompanyEmail"]), Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]), strMsg);
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objCommonController = null;
                sr = null;
                ds = null;
            }

            
        }
    }
}
