using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;

namespace AMSProjectNew.Admin
{
    public partial class ManageJobOrderDetails : System.Web.UI.Page    
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["JobId"] != null)
                {
                    FillJobOrderDetails();
                    FillJobHistory();
                }
                else
                {
                    lblMessage.Text = "Job details doesnt available at this moments.";
                    trMessage.Visible = true;
                }
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
                        lblJobTitle.Text = Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]) + "/" + Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                    else
                        lblJobTitle.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                    lblClientAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["ClientAddress"]);
                    lblCustomerFullName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CustomerFullName"]);
                    lblContractDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["ContractDate"]);
                    lblEstimatedPrice.Text = Convert.ToString(ds.Tables[0].Rows[0]["EstimatedPrice"]);
                    lblQuoteFee.Text = Convert.ToString(ds.Tables[0].Rows[0]["QuoteFee"]);
                    lblContractPrice.Text = Convert.ToString(ds.Tables[0].Rows[0]["ContractPrice"]);
                    lblPriorJobReference.Text = Convert.ToString(ds.Tables[0].Rows[0]["PriorJobreference"]);
                    lblServiceType.Text = Convert.ToString(ds.Tables[0].Rows[0]["ServiceTypeName"]);
                    lblValuationType.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuationTypeName"]);
                    lblPropertyType.Text = Convert.ToString(ds.Tables[0].Rows[0]["PropertyTypeName"]);
                    lblPurpose.Text = Convert.ToString(ds.Tables[0].Rows[0]["PurposeName"]);
                    lblTransactionType.Text = Convert.ToString(ds.Tables[0].Rows[0]["TransactionTypeName"]);
                    lblUrgency.Text = Convert.ToString(ds.Tables[0].Rows[0]["UrgencyName"]);
                    lblBankLender.Text = Convert.ToString(ds.Tables[0].Rows[0]["ClientNameDisplay"]);
                    lblLoanReference.Text = Convert.ToString(ds.Tables[0].Rows[0]["LoanReference"]);
                    lblCustomerPhoneNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["CustomerPhoneNumber"]);
                    lblCustomerMobilePhoneNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["CustomerMobilePhoneNumber"]);
                    lblCustomerAdditionalPhoneNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["CustomerAdditionalPhoneNumber"]);
                    lblEmailAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmailAddress"]);
                    lblEmailAddress1.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmailAddress1"]);
                    lblAccessRrangementsVia.Text = Convert.ToString(ds.Tables[0].Rows[0]["AccessArangementsViaName"]);
                    lblNameOfPersonToContactForAccess.Text = Convert.ToString(ds.Tables[0].Rows[0]["NameOfPersonToContactForAccess"]);
                    lblPhoneNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["PhoneNumber"]);
                    lblMobilePhoneNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["MobilePhoneNumber"]);
                    lblAdditionalPhoneNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["AdditionalPhoneNumber"]);
                    lblAdditionalNotes.Text = Convert.ToString(ds.Tables[0].Rows[0]["AdditionalNotes"]).Replace("\r", "<br />"); ;
                    lblJobStatus.Text = Convert.ToString(ds.Tables[0].Rows[0]["StatusName"]);
                    if (Convert.ToString(ds.Tables[0].Rows[0]["CreatedByType"]) == "Valuation Manager")
                        lblCreatedBy.Text = "Valuation Manager";
                    else
                        lblCreatedBy.Text = Convert.ToString(ds.Tables[0].Rows[0]["CreatedByName"]);
                    lblCreatedOn.Text = Convert.ToString(ds.Tables[0].Rows[0]["CreatedOn"]);
                    trJobDetails.Visible = true;

                    trPaymentStatus.Visible = false;
                    if (Convert.ToString(ds.Tables[0].Rows[0]["ClientName"]) != "")
                    {
                        lblPaymentStatus.Text = Convert.ToString(ds.Tables[0].Rows[0]["PaymentStatus"]);
                        trPaymentStatus.Visible = true;
                    }

                    lblReportUpload.Text = "--N/A--";
                    if (Convert.ToString(ds.Tables[0].Rows[0]["ReportUpload"]) != "")
                        lblReportUpload.Text = "<a class='Error' target='0' href='../FinalReports/" + Convert.ToString(ds.Tables[0].Rows[0]["ReportUpload"]) + "'>Click here to view</a>";


                    lblAccountUpload.Text = "--N/A--";
                    if (Convert.ToString(ds.Tables[0].Rows[0]["AccountUpload"]) != "")
                        lblAccountUpload.Text = "<a class='Error' target='0' href='../FinalReports/Accounts/" + Convert.ToString(ds.Tables[0].Rows[0]["AccountUpload"]) + "'>Click here to view</a>";

                    lblFieldNoteUpload.Text = "--N/A--";
                    if (Convert.ToString(ds.Tables[0].Rows[0]["FieldNoteUpload"]) != "")
                        lblFieldNoteUpload.Text = "<a class='Error' target='0' href='../FinalReports/" + Convert.ToString(ds.Tables[0].Rows[0]["FieldNoteUpload"]) + "'>Click here to view</a>";



                    lblValuationCompany.Text = "--N/A--";
                    lblValuer.Text = "--N/A--";
                    lblReviewer.Text = "--N/A--";

                    if (Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedName"])!="")
                        lblValuationCompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedName"]);
                    if (Convert.ToString(ds.Tables[0].Rows[0]["ValuersName"])!="")
                        lblValuer.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuersName"]);
                    if (Convert.ToString(ds.Tables[0].Rows[0]["ReviewerName"])!="")
                        lblReviewer.Text = Convert.ToString(ds.Tables[0].Rows[0]["ReviewerName"]);
                    //trReports.Visible = false;

                    //if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "7" || Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "8" || Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "9")
                    //{
                    //    trReports.Visible = true;
                    //    lblReportUpload.Text = "<a class='Error' target='0' href='../FinalReports/" + Convert.ToString(ds.Tables[0].Rows[0]["ReportUpload"]) + "'>Click here to view</a>";

                    //    lblAccountUpload.Text = "--N/A--";
                    //    if (Convert.ToString(ds.Tables[0].Rows[0]["AccountUpload"]) != "")
                    //        lblAccountUpload.Text = "<a class='Error' target='0' href='../FinalReports/" + Convert.ToString(ds.Tables[0].Rows[0]["AccountUpload"]) + "'>Click here to view</a>";
                    //    lblFieldNoteUpload.Text = "--N/A--";
                    //    if (Convert.ToString(ds.Tables[0].Rows[0]["FieldNoteUpload"]) != "")
                    //        lblFieldNoteUpload.Text = "<a class='Error' target='0' href='../FinalReports/" + Convert.ToString(ds.Tables[0].Rows[0]["FieldNoteUpload"]) + "'>Click here to view</a>";


                    //    if (Convert.ToString(ds.Tables[0].Rows[0]["ReportUploadedOn"])!="")
                    //        lblUploadedOn.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ReportUploadedOn"]).ToString();
                    //}
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
        private void FillJobHistory()
        {
            JobsController objJobsController = new JobsController();
            DataSet ds = new DataSet();
            try
            {
                ds = objJobsController.JobsHistorySelectByJobId(Convert.ToInt64(Request.QueryString["JobId"]));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvJobHistory.DataSource = ds.Tables[0].DefaultView;
                    gvJobHistory.DataBind();
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
            Response.Redirect("ManageJobOrderList.aspx", false);
        }
        protected void btnDeleteJob_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();

            try
            {
                if (objJobsController.JobDeleteByJobId(Convert.ToInt64(Request.QueryString["JobId"])) > 0)
                {
                    Response.Redirect("ManageJobOrderList.aspx?Option=Deleted", false);
                }
                else
                {
                    lblMessage.Text = "Due to some error, Job does not deleted successfully.";
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
            }
        }
    }
}
