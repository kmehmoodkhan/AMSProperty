using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.IO;

namespace AMSProjectNew.Reviewers
{
    public partial class JobOrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";

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
                    {
                        lblJobTitle.Text = Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]) + "/" + Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                        lblAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]) + "/" + Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                    }
                    else
                    {
                        lblJobTitle.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                        lblAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                    }
                    lblClientAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["ClientAddress"]);
                    lblCustomerFullName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CustomerFullName"]);
                    lblContractDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["ContractDate"]);
                    lblEstimatedPrice.Text = Convert.ToString(ds.Tables[0].Rows[0]["EstimatedPrice"]);
                    lblQuoteFee.Text = Convert.ToString(ds.Tables[0].Rows[0]["QuoteFee"]);
                    lblContractPrice.Text = Convert.ToString(ds.Tables[0].Rows[0]["ContractPrice"]);
                    //lblUnitLog.Text = Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]);
                    lblPriorJobReference.Text = Convert.ToString(ds.Tables[0].Rows[0]["PriorJobreference"]);
                    lblServiceType.Text = Convert.ToString(ds.Tables[0].Rows[0]["ServiceTypeName"]);
                    lblValuationType.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuationTypeName"]);
                    lblPropertyType.Text = Convert.ToString(ds.Tables[0].Rows[0]["PropertyTypeName"]);
                    lblPurpose.Text = Convert.ToString(ds.Tables[0].Rows[0]["PurposeName"]);
                    lblTransactionType.Text = Convert.ToString(ds.Tables[0].Rows[0]["TransactionTypeName"]);
                    lblUrgency.Text = Convert.ToString(ds.Tables[0].Rows[0]["UrgencyName"]);
                    lblLoanReference.Text = Convert.ToString(ds.Tables[0].Rows[0]["LoanReference"]);
                    lblBankLender.Text = Convert.ToString(ds.Tables[0].Rows[0]["ClientNameDisplay"]);
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
                    lblValuersEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuersEmail"]);
                    if (Convert.ToString(ds.Tables[0].Rows[0]["CreatedByType"]) == "Valuation Manager")
                        lblCreatedBy.Text = "Valuation Manager";
                    else
                        lblCreatedBy.Text = Convert.ToString(ds.Tables[0].Rows[0]["CreatedByName"]);
                    lblCreatedOn.Text = Convert.ToString(ds.Tables[0].Rows[0]["CreatedOn"]);
                    
                    trPaymentStatus.Visible = false;
                    if (Convert.ToString(ds.Tables[0].Rows[0]["ClientName"]) != "")
                    {
                        lblPaymentStatus.Text = Convert.ToString(ds.Tables[0].Rows[0]["PaymentStatus"]);
                        trPaymentStatus.Visible = true;
                    }

                    trJobDetails.Visible = true;
                    lblValuationCompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedName"]);
                    lblValuer.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuersName"]);

                    trReports.Visible = false;

                    if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "7" || Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "8" || Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "9")
                    {
                        trReports.Visible = true;
                        lblReportUpload.Text = "<a class='Error' target='0' href='../FinalReports/" + Convert.ToString(ds.Tables[0].Rows[0]["ReportUpload"]) + "'>Click here to view</a>";
                        lblReportUploadFileName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ReportUpload"]);

                        lblAccountUpload.Text = "--N/A--";
                        if (Convert.ToString(ds.Tables[0].Rows[0]["AccountUpload"]) != "")
                        {
                            lblAccountUploadFileName.Text = Convert.ToString(ds.Tables[0].Rows[0]["AccountUpload"]);
                            lblAccountUpload.Text = "<a class='Error' target='0' href='../FinalReports/" + Convert.ToString(ds.Tables[0].Rows[0]["AccountUpload"]) + "'>Click here to view</a>";
                        }
                        lblFieldNoteUpload.Text = "--N/A--";
                        if (Convert.ToString(ds.Tables[0].Rows[0]["FieldNoteUpload"]) != "")
                        {
                            lblFieldNoteUploadFileName.Text = Convert.ToString(ds.Tables[0].Rows[0]["FieldNoteUpload"]);
                            lblFieldNoteUpload.Text = "<a class='Error' target='0' href='../FinalReports/" + Convert.ToString(ds.Tables[0].Rows[0]["FieldNoteUpload"]) + "'>Click here to view</a>";
                        }
                        
                        lblUploadedOn.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ReportUploadedOn"]).ToString();
                    }

                    trAccept.Visible = false;
                    trReject.Visible = false;
                    trARButtons.Visible = false;
                    trPaymentNote.Visible = false;

                    if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "7")
                    {
                        trAccept.Visible = true;
                        trReject.Visible = true;
                        trARButtons.Visible = true;
                    }

                    if (Convert.ToString(ds.Tables[0].Rows[0]["ClientName"]) != "")
                    {
                        trPaymentNote.Visible = true;
                        trAccept.Visible = true;
                        trReject.Visible = true;
                        trARButtons.Visible = true;

                        if (Convert.ToString(ds.Tables[0].Rows[0]["PaymentStatus"]) != "Completed")
                        {
                            trPaymentNote.Visible = true;
                            trAccept.Visible = false;
                            trReject.Visible = true;
                            trARButtons.Visible = true;
                            btnAccept.Visible = false;
                        }
                    }
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
            Response.Redirect("JobOrderList.aspx", false);
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                int RetVal = objJobsController.JobStatusEdit(Convert.ToInt64(Request.QueryString["JobId"]), 9);
                if (RetVal > 0)
                {
                    SendPDFReportEmailToClient();
                    FillJobOrderDetails();
                    lblMessage.Text = "Job is Completed.";
                    trMessage.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Due to technical issues, your Job does not Completed.";
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
        private void SendPDFReportEmailToClient()
        {
            CommonController objCommonController = new CommonController();
            StreamReader sr = new StreamReader(Server.MapPath("~/EmailTemplates/ConfirmationofValuationReport.htm"));
            DataSet ds = new DataSet();
            try
            {
                string strMsg = sr.ReadToEnd();          

                ds = objCommonController.SelectConfirmationofValuersAppointmentDetails(Convert.ToInt64(Request.QueryString["JobId"]));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {                   
                    strMsg = strMsg.Replace("{CompanyName}", Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]));
                    strMsg = strMsg.Replace("{CompanyAddress1}", Convert.ToString(ds.Tables[0].Rows[0]["CompanyAddress1"]));
                    strMsg = strMsg.Replace("{CompanyAddress2}", Convert.ToString(ds.Tables[0].Rows[0]["CompanyAddress2"]));
                    strMsg = strMsg.Replace("{Date}", Convert.ToString(ds.Tables[0].Rows[0]["AppointmentSet"]));
                    strMsg = strMsg.Replace("{PropertyAddress}", lblAddress.Text.Trim());
                    strMsg = strMsg.Replace("{Price}", Convert.ToString(ds.Tables[0].Rows[0]["QuoteFee"]));
                    strMsg = strMsg.Replace("{ValuerName}", Convert.ToString(ds.Tables[0].Rows[0]["ValuerName"]));
                    strMsg = strMsg.Replace("{ValuerPhone}", Convert.ToString(ds.Tables[0].Rows[0]["ValuerPhone"]));
                    strMsg = strMsg.Replace("{ValuerEmail}", Convert.ToString(ds.Tables[0].Rows[0]["ValuerEmail"]));

                    
                    string ReportUpload = Server.MapPath("../FinalReports/" + lblReportUploadFileName.Text);
                    string AccountUpload = "";
                    if (lblAccountUploadFileName.Text.Trim() != "")
                        AccountUpload = Server.MapPath("../FinalReports/" + lblAccountUploadFileName.Text);
                    string FieldNoteUpload = "";
                    if (lblFieldNoteUploadFileName.Text.Trim() != "")
                        FieldNoteUpload = Server.MapPath("../FinalReports/" + lblFieldNoteUploadFileName.Text);

                    objCommonController.SendPDFReportEmailToClient(lblEmailAddress.Text.Trim(), lblEmailAddress1.Text.Trim(),
                        lblValuersEmail.Text.Trim(), Convert.ToString(ds.Tables[0].Rows[0]["CompanyEmail"]), Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]),
                        strMsg, ReportUpload, AccountUpload, FieldNoteUpload, "Valuation Report Completed");

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
        protected void btnReject_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                int RetVal = objJobsController.JobStatusEdit(Convert.ToInt64(Request.QueryString["JobId"]), 6);
                if (RetVal > 0)
                {                    
                    FillJobOrderDetails();
                    lblMessage.Text = "Job is Rejected.";
                    trMessage.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Due to technical issues, your Job does not Rejected.";
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
        protected void btnJobEditRequest_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobOrderEditRequest.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
        }
    }
}
