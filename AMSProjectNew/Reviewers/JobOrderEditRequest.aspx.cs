using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;

namespace AMSProjectNew.Reviewers
{
    public partial class JobOrderEditRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["JobId"] != null)
            {   
                FillJobOrderDetails();
            }
            else
            {
                lblMessage.Text = "Job details doesnt available at this moments.";
                trMessage.Visible = true;
            }
        }
        private void FillJobOrderDetails()
        {
            JobsController objJobsController = new JobsController();
            DataSet ds = new DataSet();
            try
            {
                ds = objJobsController.JobsSelectByJobId(Convert.ToInt64(Request.QueryString["JobId"]));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblJobNo.Text = "Job No - " + Convert.ToString(ds.Tables[0].Rows[0]["JobId"]);
                    if (Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]) != "")
                        lblJobTitle.Text = Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]) + "/" + Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + " - " + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                    else
                        lblJobTitle.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + " - " + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                                        
                    lblJobStatus.Text = Convert.ToString(ds.Tables[0].Rows[0]["StatusName"]);
                    if (Convert.ToString(ds.Tables[0].Rows[0]["CreatedByType"]) == "Valuation Manager")
                        lblCreatedBy.Text = "Valuation Manager";
                    else
                        lblCreatedBy.Text = Convert.ToString(ds.Tables[0].Rows[0]["CreatedByName"]);
                    lblCreatedOn.Text = Convert.ToString(ds.Tables[0].Rows[0]["CreatedOn"]);
                    trJobDetails.Visible = true;
                    lblPaymentStatus.Text = Convert.ToString(ds.Tables[0].Rows[0]["PaymentStatus"]);
                }
                else
                {
                    lblMessage.Text = "Job details doesnt available at this moments.";
                    trMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
                trMessage.Visible = true;
            }
            finally
            {
                objJobsController = null;
                ds = null;
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobOrderDetails.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
        }

        protected void btnSubmitRequest_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                Int64 RetVal = objJobsController.JobEditRequestsEdit(0, Convert.ToInt64(Request.QueryString["JobId"]), txtRequestTitle.Text.Trim(), txtRequestDetails.Text.Trim().Replace("\r", "<Br>"), Convert.ToString(Session["FullName"]), "Reviewer", Convert.ToInt64(Session["UserId"]), "ADD");
                if (RetVal > 0)
                {
                    lblMessage.Text = "Your request sent successfully. Please click on Back button to go back to Job Details.";
                    trMessage.Visible = true;
                    txtRequestDetails.Text = "";
                    txtRequestTitle.Text = "";
                }
                else
                {
                    lblMessage.Text = "Your request doesnt sent. Please try later again.";
                    trMessage.Visible = true;
                    return;
                }
            }
            catch (Exception Ex)
            {
                lblMessage.Text = Ex.Message.ToString();
                trMessage.Visible = true;
            }
            finally
            {
                objJobsController = null;
            }
        }
    }
}
