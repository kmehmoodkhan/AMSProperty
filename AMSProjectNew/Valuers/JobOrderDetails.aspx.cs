using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.IO;
using System.Globalization;

namespace AMSProjectNew.Valuers
{
    public partial class JobOrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            if (!IsPostBack)
            {
                if (Session["ShowMessage"] != null && Convert.ToString(Session["ShowMessage"]) == "ReportCompleted")
                {
                    lblMessage.Text = "You have successfully completed your report. Report send to Reviewer to review and further process.";
                    Session["ShowMessage"] = null;
                }

                if (Request.QueryString["JobId"] != null)
                {
                    FillJobDocuments();
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
                    lblOtherNote.Text = Convert.ToString(ds.Tables[0].Rows[0]["OtherNote"]);
                    lblCreatedOn.Text = Convert.ToString(ds.Tables[0].Rows[0]["CreatedOn"]);

                    trJobDetails.Visible = true;
                    tblFinalReport.Visible = false;
                    //trReports.Visible = false;

                    trPaymentStatus.Visible = false;
                    if (Convert.ToString(ds.Tables[0].Rows[0]["ClientName"]) != "")
                    {
                        lblOneOffClient.Text = "Yes";
                        lblClientName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ClientName"]);
                        lblPaymentStatus.Text = Convert.ToString(ds.Tables[0].Rows[0]["PaymentStatus"]);
                        trPaymentStatus.Visible = true;

                        
                    }
                    //if (Convert.ToString(ds.Tables[0].Rows[0]["AccountUpload"]) != "")
                    //    lblAccountUploadNew.Text = Convert.ToString(ds.Tables[0].Rows[0]["AccountUpload"]);
                    //if (Convert.ToString(ds.Tables[0].Rows[0]["AccountUpload"]) != "")
                    //    lblAccountUploadNew.Text = Convert.ToString(ds.Tables[0].Rows[0]["AccountUpload"]);
                    //if (Convert.ToString(ds.Tables[0].Rows[0]["AccountUpload"]) != "")
                    //    lblAccountUploadNew.Text = Convert.ToString(ds.Tables[0].Rows[0]["AccountUpload"]);


                    lblAccountUpload.Text = "--N/A--";
                    if (Convert.ToString(ds.Tables[0].Rows[0]["AccountUpload"]) != "")
                    {
                        lblAccountUpload.Text = "<a class='Error' target='0' href='../FinalReports/Accounts/" + Convert.ToString(ds.Tables[0].Rows[0]["AccountUpload"]) + "'>Click here to view</a>";
                        lblAccountUploadNew.Text = Convert.ToString(ds.Tables[0].Rows[0]["AccountUpload"]);
                    }
                    lblFieldNoteUpload.Text = "--N/A--";
                    if (Convert.ToString(ds.Tables[0].Rows[0]["FieldNoteUpload"]) != "")
                        lblFieldNoteUpload.Text = "<a class='Error' target='0' href='../FinalReports/" + Convert.ToString(ds.Tables[0].Rows[0]["FieldNoteUpload"]) + "'>Click here to view</a>";

                    lblReportUpload.Text = "--N/A--";
                    if (Convert.ToString(ds.Tables[0].Rows[0]["ReportUpload"]) != "")
                        lblReportUpload.Text = "<a class='Error' target='0' href='../FinalReports/" + Convert.ToString(ds.Tables[0].Rows[0]["ReportUpload"]) + "'>Click here to view</a>";

                    tblFinalReport.Visible = false;
                    tblInspected.Visible = false;
                    trAppointment.Visible = false;

                    if (Convert.ToString(ds.Tables[0].Rows[0]["AppointmentSetTime"]) != "")
                        ddlAppointmentTime.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["AppointmentSetTime"]);

                    if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "4" || Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "5" || Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "6")
                        trAppointment.Visible = true;
                    
                    if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "5")
                    {
                        txtInspectedDate.Text = DateTime.Now.ToShortDateString();
                        tblInspected.Visible = true;
                    }
                    if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "6")
                    {
                        tblFinalReport.Visible = true;
                        tblInspected.Visible = true;
                    }
                    

                    if (Convert.ToString(ds.Tables[0].Rows[0]["AppointmentSet"]) != "")
                    {
                        txtAppointmentDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["AppointmentSet"]).ToString("dd/MM/yyyy");
                    }

                    if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "7" || Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "8" || Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "9")
                    {
                        trReports.Visible = true;
                        lblReportUpload.Text = "<a class='Error' target='0' href='../FinalReports/" + Convert.ToString(ds.Tables[0].Rows[0]["ReportUpload"]) + "'>Click here to view</a>";

                        lblUploadedOn.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ReportUploadedOn"]).ToString();
                    }

                    lblValuationInstructionDisplay.Text = "";
                    
                    if (Convert.ToString(ds.Tables[0].Rows[0]["ValuationInstruction"]) != "")
                    {
                        string ValuationInstructionPath = Server.MapPath("~/Documents/ValuationInstruction/" + Convert.ToString(ds.Tables[0].Rows[0]["ValuationInstruction"]));
                        if (File.Exists(ValuationInstructionPath))
                        {
                            lblValuationInstructionDisplay.Text = "<a href='../Documents/ValuationInstruction/" + Convert.ToString(ds.Tables[0].Rows[0]["ValuationInstruction"]) + "' target='0'>View Valuation Instruction</a>";                            
                        }
                    }

                    lblPropertyReportDisplay.Text = "";

                    if (Convert.ToString(ds.Tables[0].Rows[0]["PropertyReport"]) != "")
                    {
                        string PropertyReportPath = Server.MapPath("~/Documents/PropertyReport/" + Convert.ToString(ds.Tables[0].Rows[0]["PropertyReport"]));
                        if (File.Exists(PropertyReportPath))
                        {
                            lblPropertyReportDisplay.Text = "<a href='../Documents/PropertyReport/" + Convert.ToString(ds.Tables[0].Rows[0]["PropertyReport"]) + "' target='0'>View Property Report</a>";
                        }
                    }

                    lblOverlaysDisplay.Text = "";

                    if (Convert.ToString(ds.Tables[0].Rows[0]["Overlays"]) != "")
                    {
                        string PropertyReportPath = Server.MapPath("~/Documents/Overlays/" + Convert.ToString(ds.Tables[0].Rows[0]["Overlays"]));
                        if (File.Exists(PropertyReportPath))
                        {
                            lblOverlaysDisplay.Text = "<a href='../Documents/Overlays/" + Convert.ToString(ds.Tables[0].Rows[0]["Overlays"]) + "' target='0'>View Overlays</a>";
                        }
                    }

                    lblTitleDisplay.Text = "";

                    if (Convert.ToString(ds.Tables[0].Rows[0]["Title"]) != "")
                    {
                        string PropertyReportPath = Server.MapPath("~/Documents/Title/" + Convert.ToString(ds.Tables[0].Rows[0]["Title"]));
                        if (File.Exists(PropertyReportPath))
                        {
                            lblTitleDisplay.Text = "<a href='../Documents/Title/" + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + "' target='0'>View Title</a>";
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
        protected void btnAppointmentSetSubmit_Click(object sender, EventArgs e)
        {
            if (lblJobStatus.Text.Trim() == "In Progress - Reviewer")
            {
                lblMessage.Text = "You can not set appointment date at this status.";
                trMessage.Visible = true;
                return;
            }

            JobsController objJobsController = new JobsController();
            try
            {

                DateTime dtAppointment = DateTime.Now;
                if (txtAppointmentDate.Text.Trim() != "")
                {   
                    if (CommonController.GetConfigurationVal("Mode") == "LOCAL")
                    {
                        string[] strDate = txtAppointmentDate.Text.Trim().Split('/');
                        dtAppointment = Convert.ToDateTime(strDate[1].ToString() + "/" + strDate[0].ToString() + "/" + strDate[2].ToString());
                    }
                    else                        
                        dtAppointment = Convert.ToDateTime(txtAppointmentDate.Text.Trim());
                }

                int RetVal = objJobsController.JobAppointmentAndInspectedDateSetEdit(Convert.ToInt64(Request.QueryString["JobId"]), dtAppointment, dtAppointment, 5, "", "Appointment",ddlAppointmentTime.SelectedValue);
                if (RetVal > 0)
                {
                    SendToClientForConfirmationofValuersAppointment();
                    FillJobOrderDetails();
                    lblMessage.Text = "Your appointment set date updated successfully.";
                    trMessage.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Your appointment set date does not updated successfully.";
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
        protected void btnInspected_Click(object sender, EventArgs e)
        {
            if (lblJobStatus.Text.Trim() == "In Progress - Reviewer")
            {
                lblMessage.Text = "You can not set inspected date at this status."; 
                trMessage.Visible = true;
                return;
            }
            //if (lblAccountUploadNew.Text.Trim() == "" && lblOneOffClient.Text.Trim() == "Yes")
            //{
            //    lblMessage.Text = "You can not set inspected date because account is not uploaded.";
            //    trMessage.Visible = true;
            //    return;
            //}
            JobsController objJobsController = new JobsController();
            try
            {
                int RetVal = objJobsController.JobAppointmentAndInspectedDateSetEdit(Convert.ToInt64(Request.QueryString["JobId"]), Convert.ToDateTime(txtInspectedDate.Text.Trim()), Convert.ToDateTime(txtInspectedDate.Text.Trim()), 6, "Yes", "Inspected",ddlAppointmentTime.SelectedValue);
                if (RetVal > 0)
                {
                    SendToClientForConfirmationofValuersInspected();
                    FillJobOrderDetails();
                    lblMessage.Text = "Job is successfully updated with Inspected status for property.";
                    trMessage.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Job does not updated for Inspected status for property.";
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

        private void SendToClientForConfirmationofValuersAppointment()
        {
            CommonController objCommonController = new CommonController();
            StreamReader sr = new StreamReader(Server.MapPath("~/EmailTemplates/ConfirmationofValuersAppointment.htm"));
            DataSet ds = new DataSet();
            try
            {
                ds = objCommonController.SelectConfirmationofValuersAppointmentDetails(Convert.ToInt64(Request.QueryString["JobId"]));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    string strMsg = sr.ReadToEnd();
                    strMsg = strMsg.Replace("{CompanyName}", Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]));
                    strMsg = strMsg.Replace("{CompanyAddress1}", Convert.ToString(ds.Tables[0].Rows[0]["CompanyAddress1"]));
                    strMsg = strMsg.Replace("{CompanyAddress2}", Convert.ToString(ds.Tables[0].Rows[0]["CompanyAddress2"]));
                    strMsg = strMsg.Replace("{Date}", Convert.ToString(ds.Tables[0].Rows[0]["AppointmentSet"]));
                    strMsg = strMsg.Replace("{Time}", Convert.ToString(ds.Tables[0].Rows[0]["AppointmentSetTime"]));
                    strMsg = strMsg.Replace("{PropertyAddress}", lblAddress.Text.Trim());
                    strMsg = strMsg.Replace("{Price}", Convert.ToString(ds.Tables[0].Rows[0]["QuoteFee"]));
                    strMsg = strMsg.Replace("{ValuerName}", Convert.ToString(ds.Tables[0].Rows[0]["ValuerName"]));
                    strMsg = strMsg.Replace("{ValuerPhone}", Convert.ToString(ds.Tables[0].Rows[0]["ValuerPhone"]));
                    strMsg = strMsg.Replace("{ValuerEmail}", Convert.ToString(ds.Tables[0].Rows[0]["ValuerEmail"]));

                    objCommonController.SendToClientForConfirmationofValuersAppointment(Convert.ToString(ds.Tables[0].Rows[0]["EmailAddress"]), Convert.ToString(ds.Tables[0].Rows[0]["EmailAddress1"]), Convert.ToString(Session["Email"]), Convert.ToString(ds.Tables[0].Rows[0]["CompanyEmail"]), Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]), strMsg, "Confirmation of Valuers Appointment");
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
        private void SendToClientForConfirmationofValuersInspected()
        {
            CommonController objCommonController = new CommonController();
            StreamReader sr = new StreamReader(Server.MapPath("~/EmailTemplates/ConfirmationofValuersInspected.htm"));
            DataSet ds = new DataSet();
            try
            {
                ds = objCommonController.SelectConfirmationofValuersAppointmentDetails(Convert.ToInt64(Request.QueryString["JobId"]));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    string strMsg = sr.ReadToEnd();
                    strMsg = strMsg.Replace("{CompanyName}", Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]));
                    strMsg = strMsg.Replace("{CompanyAddress1}", Convert.ToString(ds.Tables[0].Rows[0]["CompanyAddress1"]));
                    strMsg = strMsg.Replace("{CompanyAddress2}", Convert.ToString(ds.Tables[0].Rows[0]["CompanyAddress2"]));
                    strMsg = strMsg.Replace("{PropertyAddress}", lblAddress.Text.Trim());
                    strMsg = strMsg.Replace("{ValuerName}", Convert.ToString(ds.Tables[0].Rows[0]["ValuerName"]));
                    strMsg = strMsg.Replace("{ValuerPhone}", Convert.ToString(ds.Tables[0].Rows[0]["ValuerPhone"]));
                    strMsg = strMsg.Replace("{ValuerEmail}", Convert.ToString(ds.Tables[0].Rows[0]["ValuerEmail"]));


                    string AccountUpload = "";
                    if (lblAccountUploadNew.Text.Trim() != "")
                    {
                        if (File.Exists(Server.MapPath("../FinalReports/Accounts/" + lblAccountUploadNew.Text)))
                            AccountUpload = Server.MapPath("../FinalReports/Accounts/" + lblAccountUploadNew.Text);
                    }

                    objCommonController.SendToClientForConfirmationofValuersInspected(Convert.ToString(ds.Tables[0].Rows[0]["EmailAddress"]), Convert.ToString(ds.Tables[0].Rows[0]["EmailAddress1"]), Convert.ToString(Session["Email"]), Convert.ToString(ds.Tables[0].Rows[0]["CompanyEmail"]), Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]), strMsg, AccountUpload, "Property Valuation - Account");
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
        protected void btnUploadReport_Click(object sender, EventArgs e)
        {

            if (lblJobStatus.Text.Trim() == "In Progress - Reviewer")
            {
                lblMessage.Text = "Reports are already uploaded. You can not upload reports at this status.";
                trMessage.Visible = true;
                return;
            }
            //Response.Redirect("JobOrderGenerateReport.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
            Response.Redirect("GenerateReportOption.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
        }
        protected void btnJobEditRequest_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobOrderEditRequest.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobOrderList.aspx", false);
        }
        protected void btnUploadAccount_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            string strAccountUpload = DateTime.Now.ToString("MMddyyyyhhmmss");

            try
            {
                if (fuAccount.FileName.ToString() != "")
                {
                    if (File.Exists(Server.MapPath("../FinalReportsTemp/") + fuAccount.FileName.ToString()))
                        File.Delete(Server.MapPath("../FinalReportsTemp/") + fuAccount.FileName.ToString());

                    fuAccount.SaveAs(Server.MapPath("../FinalReportsTemp/") + fuAccount.FileName.ToString());
                    strAccountUpload = strAccountUpload + "_" + fuAccount.FileName.ToString();

                    File.Copy(Server.MapPath("../FinalReportsTemp/") + fuAccount.FileName.ToString(), Server.MapPath("../FinalReports/") + strAccountUpload);
                }
                else
                    strAccountUpload = "";

                int RetVal = objJobsController.JobEditFinalReportSubmit(Convert.ToInt64(Request.QueryString["JobId"]), "", strAccountUpload, "", 7, "ACCOUNTUPLOAD");
                if (RetVal > 0)
                {
                    lblAccountUpload.Text = "<a class='Error' target='0' href='../FinalReports/" + strAccountUpload + "'>Click here to view</a>";
                    DeleteFilesFromFinalReportsTemp();
                    lblMessage.Text = "Account document uploaded successfully.";
                    trMessage.Visible = true;
                }
                else
                {
                    DeleteFilesFromFinalReportsTemp();
                    DeleteFilesFromFinalReports("", strAccountUpload, "");

                    lblMessage.Text = "Error to upload account document.";
                    trMessage.Visible = true;
                }

            }
            catch (Exception ex)
            {
                DeleteFilesFromFinalReportsTemp();
                lblMessage.Text = ex.Message.ToString();
                trMessage.Visible = true;
            }
            finally
            {
                objJobsController = null;
            }
        }
        protected void btnUploadField_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
           string strFieldNoteUpload = DateTime.Now.ToString("MMddyyyyhhmmss");

            try
            {
                if (fuNote.FileName.ToString() != "")
                {
                    if (File.Exists(Server.MapPath("../FinalReportsTemp/") + fuNote.FileName.ToString()))
                        File.Delete(Server.MapPath("../FinalReportsTemp/") + fuNote.FileName.ToString());
                    
                    fuNote.SaveAs(Server.MapPath("../FinalReportsTemp/") + fuNote.FileName.ToString());
                    strFieldNoteUpload = strFieldNoteUpload + "_" + fuNote.FileName.ToString();

                    File.Copy(Server.MapPath("../FinalReportsTemp/") + fuNote.FileName.ToString(), Server.MapPath("../FinalReports/") + strFieldNoteUpload);
                }
                else
                    strFieldNoteUpload = "";

                int RetVal = objJobsController.JobEditFinalReportSubmit(Convert.ToInt64(Request.QueryString["JobId"]), "", "", strFieldNoteUpload, 7, "NOTEUPLOAD");
                if (RetVal > 0)
                {
                    lblFieldNoteUpload.Text = "<a class='Error' target='0' href='../FinalReports/" + strFieldNoteUpload + "'>Click here to view</a>";
                    DeleteFilesFromFinalReportsTemp();
                    lblMessage.Text = "Note document uploaded successfully..";
                    trMessage.Visible = true;
                }
                else
                {
                    DeleteFilesFromFinalReportsTemp();
                    DeleteFilesFromFinalReports("", "", strFieldNoteUpload);

                    lblMessage.Text = "Error to upload note document.";
                    trMessage.Visible = true;
                }

            }
            catch (Exception ex)
            {
                DeleteFilesFromFinalReportsTemp();
                lblMessage.Text = ex.Message.ToString();
                trMessage.Visible = true;
            }
            finally
            {
                objJobsController = null;
            }
        }
        public void DeleteFilesFromFinalReports(string strReportUpload, string strAccountUpload, string strFieldNoteUpload)
        {
            try
            {
                if (fuAccount.FileName.ToString() != "")
                {
                    if (File.Exists(Server.MapPath("../FinalReports/") + strAccountUpload))
                        File.Delete(Server.MapPath("../FinalReports/") + strAccountUpload);
                }
                if (fuNote.FileName.ToString() != "")
                {
                    if (File.Exists(Server.MapPath("../FinalReports/") + strFieldNoteUpload))
                        File.Delete(Server.MapPath("../FinalReports/") + strFieldNoteUpload);
                }
            }
            catch (Exception)
            {

            }
        }
        public void DeleteFilesFromFinalReportsTemp()
        {
            try
            {
                if (fuAccount.FileName.ToString() != "")
                {
                    if (File.Exists(Server.MapPath("../FinalReportsTemp/") + fuAccount.FileName.ToString()))
                        File.Delete(Server.MapPath("../FinalReportsTemp/") + fuAccount.FileName.ToString());
                }
                if (fuNote.FileName.ToString() != "")
                {
                    if (File.Exists(Server.MapPath("../FinalReportsTemp/") + fuNote.FileName.ToString()))
                        File.Delete(Server.MapPath("../FinalReportsTemp/") + fuNote.FileName.ToString());
                }
            }
            catch (Exception)
            {

            }
        }
        protected void btnSubmitOtherNote_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                string OtherNote = lblOtherNote.Text.Trim();
                if (txtOtherNote.Text.Trim() != "")
                {
                    OtherNote += "[<i>Note added by <b>" + Session["Username"].ToString() + "</b> on " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt") + "</i>]<br><br>" + txtOtherNote.Text.Trim().Replace("\r", "<br>") + "<br><br>";
                    int RetVal = objJobsController.JobOtherNoteEdit(Convert.ToInt64(Request.QueryString["JobId"]), OtherNote);
                    if (RetVal > 0)
                    {
                        txtOtherNote.Text = "";
                        lblOtherNote.Text = OtherNote;
                        lblMessage.Text = "Your note added successfully.";
                        trMessage.Visible = true;
                    }
                    else
                    {
                        lblMessage.Text = "Your note does not added successfully.";
                        trMessage.Visible = true;
                    }
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
        private void FillJobDocuments()
        {
            JobsController objJobsController = new JobsController();
            DataSet ds = new DataSet();
            try
            {
                dlDocuments.Visible = false;
                ds = objJobsController.JobDocumentsSelect(0, Convert.ToInt64(Request.QueryString["JobId"]));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dlDocuments.DataSource = ds.Tables[0].DefaultView;
                    dlDocuments.DataBind();
                    dlDocuments.Visible = true;
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
    }
}
