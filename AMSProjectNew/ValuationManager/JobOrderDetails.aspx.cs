using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.IO;
using System.Text;
using System.Globalization;

namespace AMSProjectNew.ValuationManager
{
    public partial class JobOrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnValuerReassign.Value = "";
                hdnCompanyReAssign.Value = "";
                if (Request.QueryString["JobId"] != null)
                {
                    lblGenerateReport.Text = "<a target='0' href='GenerateReport.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]) + "' style='Border:solid 1px #074A87; background-color:#FFCA01;color:#074A87; font-size:11px; text-decoration:none; font-weight:bold; padding:3px 30px 3px 30px;'>Generate Report</a>";
                    hdnValuerId.Value = "0";
                    hdnCompanyId.Value = "0";
                    FillActiveValuationCompany();
                    FillJobOrderDetails();
                    FillJobDocuments();
                    FillJobHistory();
                    FillJobEditRequests();
                    FillEmailHistory();
                    tdJobDetails.Attributes.Add("class", "TDSelected");
                    tdEditRequest.Attributes.Add("class", "TDNotSelected");
                }
                else
                {
                    lblMessage.Text = "Job details doesnt available at this moments.";
                    trMessage.Visible = true;
                }
            }
        }
        private void FillActiveValuationCompany()
        {
            ValuationCompanyController valuationCompanyController = new ValuationCompanyController();
            DataSet ds = new DataSet();
            try
            {
                ds = valuationCompanyController.ValuationCompanySelectAll(0, 0, 2);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvValuationCompany.DataSource = ds.Tables[0].DefaultView;
                    gvValuationCompany.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                valuationCompanyController = null;
                ds = null;
            }
        }
        private void FillActiveValuers()
        {
            ValuersController valuersController = new ValuersController();
            DataSet ds = new DataSet();
            try
            {
                if (lblValuationCompanyId.Text.Trim() != "")
                {
                    ds = valuersController.ValuersSelectAll(0, Convert.ToInt64(lblValuationCompanyId.Text.Trim()), 2);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        gvValuer.DataSource = ds.Tables[0].DefaultView;
                        gvValuer.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                valuersController = null;
                ds = null;
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
                        lblJobTitlePopup.Text = Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]) + "/" + Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                        lblAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]) + "/" + Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);

                    }
                    else
                    {
                        lblJobTitle.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                        lblJobTitlePopup.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
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
                    lblAdditionalNotes.Text = Convert.ToString(ds.Tables[0].Rows[0]["AdditionalNotes"]).Replace("\r", "<br />");
                    lblJobStatus.Text = Convert.ToString(ds.Tables[0].Rows[0]["StatusName"]);
                    lblCompanyFee.Text = Convert.ToString(ds.Tables[0].Rows[0]["FeeByValuationCompany"]);
                    lblValuersEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuersEmail"]);
                    lblOtherNote.Text = Convert.ToString(ds.Tables[0].Rows[0]["OtherNote"]);

                    if (Convert.ToString(ds.Tables[0].Rows[0]["CreatedByType"]) == "Valuation Manager")
                        lblCreatedBy.Text = "Valuation Manager";
                    else
                        lblCreatedBy.Text = Convert.ToString(ds.Tables[0].Rows[0]["CreatedByName"]);
                    lblCreatedOn.Text = Convert.ToString(ds.Tables[0].Rows[0]["CreatedOn"]);
                    trJobDetails.Visible = true;

                    trPaymentStatus.Visible = false;
                    trPaymentStatusButton.Visible = false;
                    if (Convert.ToString(ds.Tables[0].Rows[0]["ClientName"]) != "")
                    {
                        lblPaymentStatus.Text = Convert.ToString(ds.Tables[0].Rows[0]["PaymentStatus"]);
                        if (Convert.ToString(ds.Tables[0].Rows[0]["PaymentStatus"]) != "Completed")
                            trPaymentStatusButton.Visible = true;
                        trPaymentStatus.Visible = true;
                        trAccontUpload.Visible = true;

                    }

                    lblReportUpload.Text = "--N/A--";
                    if (Convert.ToString(ds.Tables[0].Rows[0]["ReportUpload"]) != "")
                    {
                        lblReportUpload.Text = "<a class='Error' target='0' href='../FinalReports/" + Convert.ToString(ds.Tables[0].Rows[0]["ReportUpload"]) + "'>Click here to view</a>";
                        lblPdfReport.Text = Convert.ToString(ds.Tables[0].Rows[0]["ReportUpload"]);
                    }

                    lblAccountUpload.Text = "--N/A--";
                    if (Convert.ToString(ds.Tables[0].Rows[0]["AccountUpload"]) != "")
                    {
                        lblAccountUpload.Text = "<a class='Error' target='0' href='../FinalReports/Accounts/" + Convert.ToString(ds.Tables[0].Rows[0]["AccountUpload"]) + "'>Click here to view</a>";
                        lblAccountUploadNew.Text = Convert.ToString(ds.Tables[0].Rows[0]["AccountUpload"]);
                    }
                    lblFieldNoteUpload.Text = "--N/A--";
                    if (Convert.ToString(ds.Tables[0].Rows[0]["FieldNoteUpload"]) != "")
                    {
                        lblFieldNoteUpload.Text = "<a class='Error' target='0' href='../FinalReports/" + Convert.ToString(ds.Tables[0].Rows[0]["FieldNoteUpload"]) + "'>Click here to view</a>";
                        lblFieldNoteUploadNew.Text = Convert.ToString(ds.Tables[0].Rows[0]["FieldNoteUpload"]);
                    }

                    btnAssignCompany.Visible = false;

                    if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "1" || Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "3")
                    {
                        btnAssignCompany.Visible = true;
                    }



                    lblValuationCompany.Text = "--N/A--";
                    lblValuer.Text = "--N/A--";
                    lblReviewer.Text = "--N/A--";

                    if (Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedName"]) != "")
                    {
                        lblValuationCompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedName"]);
                        lblValuationCompanyId.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedId"]);
                        FillActiveValuers();
                    }


                    btnReAssignCompany.Visible = false;
                    if (lblValuationCompanyId.Text.Trim() != "")
                        btnReAssignCompany.Visible = true;

                    btnChangeValuer.Visible = false;
                    btnAssignValuer.Visible = true;
                    if (Convert.ToString(ds.Tables[0].Rows[0]["ValuersName"]) != "")
                    {
                        lblValuer.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuersUsername"]) + "(" + Convert.ToString(ds.Tables[0].Rows[0]["ValuersName"]) + ")";
                        btnAssignValuer.Visible = false;
                        btnChangeValuer.Visible = true;
                    }
                    if (Convert.ToString(ds.Tables[0].Rows[0]["ReviewerName"]) != "")
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

                    //    lblUploadedOn.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ReportUploadedOn"]).ToString();
                    //    trAccontUpload.Visible = false;
                    //}

                    tblFeeUpdate.Visible = false;
                    if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "10")
                    {
                        tblFeeUpdate.Visible = true;
                    }

                    tblJobDetails.Visible = true;
                    tblEditRequest.Visible = false;

                    tblFinalReport.Visible = false;
                    //tblInspected.Visible = false;
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





                    if (Convert.ToString(ds.Tables[0].Rows[0]["ClientName"]) != "")
                    {
                        trPaymentNote.Visible = true;
                        trAccept.Visible = true;
                        trReject.Visible = true;
                        trARButtons.Visible = true;


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
                        btnAccept.Visible = true;
                        btnReject.Visible = true;
                        trPaymentNote.Visible = false;

                    }

                    if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "9")
                    {
                        trReject.Visible = true;
                        trARButtons.Visible = true;
                        btnReject.Visible = true;
                        btnAccept.Visible = false;
                    }

                    if (Convert.ToString(ds.Tables[0].Rows[0]["PaymentStatus"]) != "Completed")
                    {
                        trPaymentNote.Visible = true;
                        trAccept.Visible = false;
                        trReject.Visible = true;
                        trARButtons.Visible = true;
                        btnAccept.Visible = false;
                    }

                    lblValuationInstructionDisplay.Text = "";
                    fuVI.Visible = true;
                    btnValuationInstructionUpload.Visible = true;
                    btnValuationInstructionDelete.Visible = false;

                    if (Convert.ToString(ds.Tables[0].Rows[0]["ValuationInstruction"]) != "")
                    {
                        string ValuationInstructionPath = Server.MapPath("~/Documents/ValuationInstruction/" + Convert.ToString(ds.Tables[0].Rows[0]["ValuationInstruction"]));
                        if (File.Exists(ValuationInstructionPath))
                        {
                            hdnValuationInstruction.Value = Convert.ToString(ds.Tables[0].Rows[0]["ValuationInstruction"]);
                            lblValuationInstructionDisplay.Text = "<a href='../Documents/ValuationInstruction/" + Convert.ToString(ds.Tables[0].Rows[0]["ValuationInstruction"]) + "' target='0'>View Valuation Instruction</a>";
                            fuVI.Visible = false;
                            btnValuationInstructionUpload.Visible = false;
                            btnValuationInstructionDelete.Visible = true;
                        }
                    }

                    lblPropertyReportDisplay.Text = "";
                    fuPR.Visible = true;
                    btnPropertyReportUpload.Visible = true;
                    btnPropertyReportDelete.Visible = false;

                    if (Convert.ToString(ds.Tables[0].Rows[0]["PropertyReport"]) != "")
                    {
                        string PropertyReportPath = Server.MapPath("~/Documents/PropertyReport/" + Convert.ToString(ds.Tables[0].Rows[0]["PropertyReport"]));
                        if (File.Exists(PropertyReportPath))
                        {
                            hdnPropertyReport.Value = Convert.ToString(ds.Tables[0].Rows[0]["PropertyReport"]);
                            lblPropertyReportDisplay.Text = "<a href='../Documents/PropertyReport/" + Convert.ToString(ds.Tables[0].Rows[0]["PropertyReport"]) + "' target='0'>View Property Report</a>";
                            fuPR.Visible = false;
                            btnPropertyReportUpload.Visible = false;
                            btnPropertyReportDelete.Visible = true;
                        }
                    }

                    lblOverlaysDisplay.Text = "";
                    fuOL.Visible = true;
                    btnOverlaysUpload.Visible = true;
                    btnOverlaysDelete.Visible = false;

                    if (Convert.ToString(ds.Tables[0].Rows[0]["Overlays"]) != "")
                    {
                        string PropertyReportPath = Server.MapPath("~/Documents/Overlays/" + Convert.ToString(ds.Tables[0].Rows[0]["Overlays"]));
                        if (File.Exists(PropertyReportPath))
                        {
                            hdnOverlays.Value = Convert.ToString(ds.Tables[0].Rows[0]["Overlays"]);
                            lblOverlaysDisplay.Text = "<a href='../Documents/Overlays/" + Convert.ToString(ds.Tables[0].Rows[0]["Overlays"]) + "' target='0'>View Overlays</a>";
                            fuOL.Visible = false;
                            btnOverlaysUpload.Visible = false;
                            btnOverlaysDelete.Visible = true;
                        }
                    }

                    lblTitleDisplay.Text = "";
                    fuTL.Visible = true;
                    btnTitleUpload.Visible = true;
                    btnTitleDelete.Visible = false;

                    if (Convert.ToString(ds.Tables[0].Rows[0]["Title"]) != "")
                    {
                        string PropertyReportPath = Server.MapPath("~/Documents/Title/" + Convert.ToString(ds.Tables[0].Rows[0]["Title"]));
                        if (File.Exists(PropertyReportPath))
                        {
                            hdnTitle.Value = Convert.ToString(ds.Tables[0].Rows[0]["Title"]);
                            lblTitleDisplay.Text = "<a href='../Documents/Title/" + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + "' target='0'>View Title</a>";
                            fuTL.Visible = false;
                            btnTitleUpload.Visible = false;
                            btnTitleDelete.Visible = true;
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
        private void FillJobEditRequests()
        {
            JobsController objJobsController = new JobsController();
            DataSet ds = new DataSet();
            try
            {
                lblEditRequestMessage.Text = "No job edit request found.";
                ds = objJobsController.JobEditRequestsSelect(0, Convert.ToInt64(Request.QueryString["JobId"]));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvEditRequest.DataSource = ds.Tables[0].DefaultView;
                    gvEditRequest.DataBind();
                    lblEditRequestMessage.Text = "";
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
        private void FillEmailHistory()
        {
            JobsController objJobsController = new JobsController();
            DataSet ds = new DataSet();
            try
            {

                ds = JobsController.EmailHistorySelect(0, Convert.ToInt64(Request.QueryString["JobId"]), 0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dlEmailHistory.DataSource = ds.Tables[0].DefaultView;
                    dlEmailHistory.DataBind();
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
        protected void btnAssignCompany_Click(object sender, EventArgs e)
        {
            mdlPopUp.Show();
        }
        protected void btnReAssignCompany_Click(object sender, EventArgs e)
        {
            hdnCompanyReAssign.Value = "Company";
            mdlPopUp.Show();
        }
        protected void btnAcceptAndAssignSubmit_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                int RetVal = 0;
                if (hdnCompanyReAssign.Value == "Company")
                    RetVal = objJobsController.JobsEditReAssignToValuationCompany(Convert.ToInt64(Request.QueryString["JobId"]), Convert.ToInt64(hdnCompanyId.Value));
                else
                    RetVal = objJobsController.JobsEditAssignToValuationCompany(Convert.ToInt64(Request.QueryString["JobId"]), Convert.ToInt64(hdnCompanyId.Value));

                if (RetVal > 0)
                {
                    hdnCompanyReAssign.Value = "";
                    CommonController.LogInsert("Start", "GenerateAccountHtmlFile");
                    //Create Account PDF
                    GenerateAccountHtmlFile(Convert.ToString(Request.QueryString["JobId"]), Convert.ToInt64(hdnCompanyId.Value));
                    CommonController.LogInsert("End", "GenerateAccountHtmlFile");

                    objJobsController.JobEditFinalReportSubmit(Convert.ToInt64(Request.QueryString["JobId"]), "", "Account_" + Convert.ToString(Request.QueryString["JobId"]) + ".pdf", "", 7, "ACCOUNTUPLOAD");


                    hdnCompanyId.Value = "0";
                    FillJobOrderDetails();
                    FillActiveValuers();
                    lblMessage.Text = "Job is successfully assigned to valuation company.";
                    trMessage.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Due to technical issues, your Job does not assigned to valuation company.";
                    trMessage.Visible = true;
                    return;
                }
                mdlPopUp.Hide();
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

        public void GenerateAccountHtmlFile(string RetVal, Int64 CompanyId)
        {
            CommonController objCommonController = new CommonController();
            ValuationCompanyController valuationCompanyController = new ValuationCompanyController();
            DataSet ds = new DataSet();

            StreamReader sr = new StreamReader(Server.MapPath("~/EmailTemplates/AccountReport.htm"));
            string strHtmlFile = Server.MapPath("~/FinalReportsTemp/" + RetVal + ".html");
            string strPDFFile = Server.MapPath("~/FinalReports/Accounts/Account_" + RetVal + ".pdf");
            string strMsg = sr.ReadToEnd();
            sr.Close();
            sr = null;

            if (File.Exists(strHtmlFile))
                File.Delete(strHtmlFile);

            if (File.Exists(strPDFFile))
                File.Delete(strPDFFile);

            StreamWriter sw = new StreamWriter(Server.MapPath("~/FinalReportsTemp/" + RetVal + ".html"));
            try
            {
                ds = valuationCompanyController.ValuationCompanySelectAll(CompanyId, 0, 0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    strMsg = strMsg.Replace("{CompanyName}", Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]));
                    strMsg = strMsg.Replace("{CompanyAddress1}", Convert.ToString(ds.Tables[0].Rows[0]["Address"]));
                    strMsg = strMsg.Replace("{CompanyAddress2}", Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "  " + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + " - " + Convert.ToString(ds.Tables[0].Rows[0]["Postcode"]));
                    strMsg = strMsg.Replace("{CompanyAddress3}", "");
                    strMsg = strMsg.Replace("{ClientName}", lblBankLender.Text.Trim() + "<br>" + lblClientAddress.Text.Trim().Replace("\r", "<br>"));
                    strMsg = strMsg.Replace("{InvoiceNo}", RetVal);
                    strMsg = strMsg.Replace("{Date}", DateTime.Now.ToString("ddd dd MM yyyy"));
                    strMsg = strMsg.Replace("{PropertyAddress}", lblJobTitle.Text.Trim());
                    strMsg = strMsg.Replace("{RefNo}", RetVal);
                    strMsg = strMsg.Replace("{QuoteFee}", lblQuoteFee.Text.Trim());
                    strMsg = strMsg.Replace("{CompanyName}", Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]));
                    strMsg = strMsg.Replace("{QuoteFee}", lblQuoteFee.Text.Trim());
                    strMsg = strMsg.Replace("{CompanyAddress2}", Convert.ToString(ds.Tables[0].Rows[0]["Address"]));
                    strMsg = strMsg.Replace("{CompanyAddress3}", Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "  " + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + " - " + Convert.ToString(ds.Tables[0].Rows[0]["Postcode"]));
                    strMsg = strMsg.Replace("{CompanyTelephone}", Convert.ToString(ds.Tables[0].Rows[0]["Phone1"]));
                    strMsg = strMsg.Replace("{CompanyEmail}", Convert.ToString(ds.Tables[0].Rows[0]["Email"]));
                    strMsg = strMsg.Replace("{CompanyWebsite}", "www.valuationcentral.com.au");

                    string LogoURL = "Images/Logo.png";
                    if (Convert.ToString(ds.Tables[0].Rows[0]["CompanyLogo"]) != "")
                        LogoURL = "CompanyLogo/" + Convert.ToString(ds.Tables[0].Rows[0]["CompanyLogo"]);

                    strMsg = strMsg.Replace("{LogoURL}", LogoURL);
                    strMsg = strMsg.Replace("{BankName}", Convert.ToString(ds.Tables[0].Rows[0]["BankName"]));
                    strMsg = strMsg.Replace("{BSB}", Convert.ToString(ds.Tables[0].Rows[0]["BSB"]));
                    strMsg = strMsg.Replace("{AccountNumber}", Convert.ToString(ds.Tables[0].Rows[0]["ACNumber"]));
                    strMsg = strMsg.Replace("{ABN}", Convert.ToString(ds.Tables[0].Rows[0]["ABN"]));
                    strMsg = strMsg.Replace("â€“", "-");
                    sw.Write(strMsg);
                    sw.Close();
                    sw = null;

                    //objCommonController.CreateAccountPdf(System.Configuration.ConfigurationManager.AppSettings["URL"].ToString() + "FinalReportsTemp/" + RetVal + ".html", strPDFFile, RetVal.ToString());
                    objCommonController.CreateAccountPdf(strHtmlFile, strPDFFile, RetVal.ToString());

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                valuationCompanyController = null;
                ds = null;


            }
        }
        public void GenerateAccountHtmlFile1(string RetVal, Int64 CompanyId)
        {
            /*
            CommonController objCommonController = new CommonController();
            ValuationCompanyController valuationCompanyController = new ValuationCompanyController();
            DataSet ds = new DataSet();
            StreamWriter sw = null;
            StreamReader sr = new StreamReader(Server.MapPath("~/EmailTemplates/AccountReport.htm"));
            string strHtmlFile = Server.MapPath("~/FinalReportsTemp/" + RetVal + ".html");
            string strPDFFile = Server.MapPath("~/FinalReports/Accounts/Account_" + RetVal + ".pdf");

            StringBuilder strMsg = new StringBuilder();
            strMsg.Append(sr.ReadToEnd());
            lblAccount.Text = strMsg.ToString();
            CommonController.LogInsert("GenerateAccountHtmlFile", "Start");

            if (File.Exists(strHtmlFile))
            {
                File.Delete(strHtmlFile);
                CommonController.LogInsert("File.Delete(strHtmlFile);", strHtmlFile);
            }
            if (File.Exists(strPDFFile))
            {
                File.Delete(strPDFFile);
                CommonController.LogInsert("File.Delete(strPDFFile);", strHtmlFile);
            }
            string HtmlFile = Server.MapPath("~/FinalReportsTemp/" + RetVal + ".html");
            CommonController.LogInsert("Create File Start", HtmlFile);
            sw = new StreamWriter(HtmlFile);
            CommonController.LogInsert("Create File End", HtmlFile);
            try
            {
                ds = valuationCompanyController.ValuationCompanySelectAll(CompanyId, 0, 0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblAccount.Text = lblAccount.Text.Replace("{CompanyName}", Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]));
                    lblAccount.Text = lblAccount.Text.Replace("{CompanyAddress1}", Convert.ToString(ds.Tables[0].Rows[0]["Address"]));
                    lblAccount.Text = lblAccount.Text.Replace("{CompanyAddress2}", Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "  " + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + " - " + Convert.ToString(ds.Tables[0].Rows[0]["Postcode"]));
                    lblAccount.Text = lblAccount.Text.Replace("{CompanyAddress3}", "");
                    lblAccount.Text = lblAccount.Text.Replace("{ClientName}", lblBankLender.Text.Trim());
                    lblAccount.Text = lblAccount.Text.Replace("{InvoiceNo}", RetVal);
                    lblAccount.Text = lblAccount.Text.Replace("{Date}", DateTime.Now.ToString("ddd dd MM yyyy"));
                    lblAccount.Text = lblAccount.Text.Replace("{PropertyAddress}", lblJobTitle.Text.Trim());
                    lblAccount.Text = lblAccount.Text.Replace("{RefNo}", RetVal);
                    lblAccount.Text = lblAccount.Text.Replace("{QuoteFee}", lblQuoteFee.Text.Trim());
                    lblAccount.Text = lblAccount.Text.Replace("{CompanyName}", Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]));
                    lblAccount.Text = lblAccount.Text.Replace("{QuoteFee}", lblQuoteFee.Text.Trim());
                    lblAccount.Text = lblAccount.Text.Replace("{CompanyAddress2}", Convert.ToString(ds.Tables[0].Rows[0]["Address"]));
                    lblAccount.Text = lblAccount.Text.Replace("{CompanyAddress3}", Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "  " + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + " - " + Convert.ToString(ds.Tables[0].Rows[0]["Postcode"]));
                    lblAccount.Text = lblAccount.Text.Replace("{CompanyTelephone}", Convert.ToString(ds.Tables[0].Rows[0]["Phone1"]));
                    lblAccount.Text = lblAccount.Text.Replace("{CompanyEmail}", Convert.ToString(ds.Tables[0].Rows[0]["Email"]));
                    lblAccount.Text = lblAccount.Text.Replace("{CompanyWebsite}", "www.valuationcentral.com.au");

                    string LogoURL = System.Configuration.ConfigurationManager.AppSettings["URL"].ToString() + "Images/Logo.png";
                    if (Convert.ToString(ds.Tables[0].Rows[0]["CompanyLogo"]) != "")
                        LogoURL = System.Configuration.ConfigurationManager.AppSettings["URL"].ToString() + "CompanyLogo/" + Convert.ToString(ds.Tables[0].Rows[0]["CompanyLogo"]);

                    lblAccount.Text = lblAccount.Text.Replace("{LogoURL}", LogoURL);
                    lblAccount.Text = lblAccount.Text.Replace("{BankName}", Convert.ToString(ds.Tables[0].Rows[0]["BankName"]));
                    lblAccount.Text = lblAccount.Text.Replace("{BSB}", Convert.ToString(ds.Tables[0].Rows[0]["BSB"]));
                    lblAccount.Text = lblAccount.Text.Replace("{AccountNumber}", Convert.ToString(ds.Tables[0].Rows[0]["ACNumber"]));
                    lblAccount.Text = lblAccount.Text.Replace("{ABN}", Convert.ToString(ds.Tables[0].Rows[0]["ABN"]));
                    lblAccount.Text = lblAccount.Text.Replace("â€“", "-");

                    CommonController.LogInsert("Write in File Start", HtmlFile);
                    sw.Write(lblAccount.Text.Trim());
                    CommonController.LogInsert("Write in File End", HtmlFile);

                    objCommonController.CreateAccountPdf(System.Configuration.ConfigurationManager.AppSettings["URL"].ToString() + "FinalReportsTemp/" + RetVal + ".html", strPDFFile, RetVal.ToString());

                }
            }
            catch (Exception ex)
            {
                throw ex;
                sw.Close();
                sw = null;
                sr.Close();
                sr = null;
            }
            finally
            {
                valuationCompanyController = null;
                ds = null;
                sw.Close();
                sw = null;
                sr.Close();
                sr = null;
            }
             */
        }
        protected void btnPaymentCompleted_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                int RetVal = objJobsController.JobsEditPaymentStatusCompleted(Convert.ToInt64(Request.QueryString["JobId"]), "Completed");
                if (RetVal > 0)
                {
                    FillJobOrderDetails();
                    lblMessage.Text = "Payment status updated successfully.";
                    trMessage.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Due to technical issues, Payment staus does not updated.";
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
        protected void gvValuationCompany_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument.ToString() == "Assign")
            {
                JobsController objJobsController = new JobsController();
                try
                {
                    int RetVal = objJobsController.JobsEditAssignToValuationCompany(Convert.ToInt64(Request.QueryString["JobId"]), Convert.ToInt64(e.CommandName.ToString()));
                    if (RetVal > 0)
                    {
                        FillJobOrderDetails();
                        lblMessage.Text = "Job is successfully assigned to valuation company.";
                        trMessage.Visible = true;
                    }
                    else
                    {
                        lblMessage.Text = "Due to technical issues, your Job does not assigned to valuation company.";
                        trMessage.Visible = true;
                        return;
                    }
                    mdlPopUp.Hide();
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

        protected void lbtnJobDetails_Click(object sender, EventArgs e)
        {
            tblJobDetails.Visible = true;
            tblEditRequest.Visible = false;
            tdJobDetails.Attributes.Add("class", "TDSelected");
            tdEditRequest.Attributes.Add("class", "TDNotSelected");
        }
        protected void lbtnEditRequest_Click(object sender, EventArgs e)
        {
            tblJobDetails.Visible = false;
            tblEditRequest.Visible = true;
            tdJobDetails.Attributes.Add("class", "TDNotSelected");
            tdEditRequest.Attributes.Add("class", "TDSelected");
        }

        protected void btnEditJob_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobOrderEdit.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
        }

        protected void btnDeleteJob_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();

            try
            {
                if (objJobsController.JobDeleteByJobId(Convert.ToInt64(Request.QueryString["JobId"])) > 0)
                {
                    Response.Redirect("JobOrderList.aspx?Option=Deleted", false);
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
        protected void btnUpdateFee_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                decimal NewFee = Convert.ToDecimal(txtNewFee.Text.Trim());
                Int64 RetVal = 0;

                RetVal = objJobsController.JobEditReject(0, Convert.ToInt64(Request.QueryString["JobId"]), Convert.ToInt64(Session["UserId"]), 2, NewFee, "FEEUPDATE");

                if (RetVal > 0)
                {
                    objJobsController.JobHistoryEdit(0, Convert.ToInt64(Request.QueryString["JobId"]), Convert.ToInt64(Session["UserId"]), "", "Confirmation fee updated by client. New fee is $ " + txtNewFee.Text.Trim(), "JobFeeUpdate", "ADD");
                    FillJobOrderDetails();
                    FillJobHistory();
                    lblMessage.Text = "Confirmation fee updated successfully.";
                    trMessage.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Due to technical issues, Confirmation fee does not updated.";
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
        protected void btnSubmitReports_Click(object sender, EventArgs e)
        {
            if (lblStatus.Text.Trim() == "6" || lblStatus.Text.Trim() == "7" || lblStatus.Text.Trim() == "8" || lblStatus.Text.Trim() == "9")
            {
                lblMessage.Text = "You can not upload account document at this stage.";
                return;
            }

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
                    lblAccountUploadNewShow.Text = "<a class='Error' target='0' href='../FinalReports/" + strAccountUpload + "'>Click here to view</a>";
                    DeleteFilesFromFinalReportsTemp();
                    lblMessage.Text = "Account document uploaded successfully..";
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
        public void DeleteFilesFromFinalReports(string strReportUpload, string strAccountUpload, string strFieldNoteUpload)
        {
            try
            {
                if (fuAccount.FileName.ToString() != "")
                {
                    if (File.Exists(Server.MapPath("../FinalReports/") + strAccountUpload))
                        File.Delete(Server.MapPath("../FinalReports/") + strAccountUpload);
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
            }
            catch (Exception)
            {

            }
        }

        protected void btnAssignValuer_Click(object sender, EventArgs e)
        {
            mdlPopupValuer.Show();
        }
        protected void btnAssignValuerSubmit_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                int RetVal = objJobsController.JobsEditAssignToValuer(Convert.ToInt64(Request.QueryString["JobId"]), Convert.ToInt64(hdnValuerId.Value));

                if (RetVal > 0)
                {
                    if (hdnValuerReassign.Value != "Valuer")
                    {
                        //GenerateAccountHtmlFile(Convert.ToString(Request.QueryString["JobId"]));
                        objJobsController.JobStatusEdit(Convert.ToInt64(Request.QueryString["JobId"]), 4);
                    }
                    FillJobOrderDetails();
                    hdnValuerReassign.Value = "";
                    hdnValuerId.Value = "0";
                    lblMessage.Text = "Job is successfully accepted and assigned to valuer.";
                    trMessage.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Due to technical issues, your Job does not accepted and assigned to valuer.";
                    trMessage.Visible = true;
                    return;
                }
                mdlPopupValuer.Hide();
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
                    {
                        dtAppointment = DateTime.ParseExact(txtAppointmentDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                }

                int RetVal = objJobsController.JobAppointmentAndInspectedDateSetEdit(Convert.ToInt64(Request.QueryString["JobId"]), dtAppointment, dtAppointment, 5, "", "Appointment", ddlAppointmentTime.SelectedValue);
                if (RetVal > 0)
                {
                    CommonController.LogInsert("AppointmentSet:", "done");
                    //SendToClientForConfirmationofValuersAppointment();
                    FillJobOrderDetails();
                    lblMessage.Text = "Your appointment set date updated successfully.";
                    trMessage.Visible = true;
                    if (chkAppointmentEmail.Checked)
                        Response.Redirect("EmailAppointment.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
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
                    CommonController.LogInsert("AppointmentSet:", "");
                    objCommonController.SendToClientForConfirmationofValuersAppointment(Convert.ToString(ds.Tables[0].Rows[0]["EmailAddress"]),
                        Convert.ToString(ds.Tables[0].Rows[0]["EmailAddress1"]), Convert.ToString(ds.Tables[0].Rows[0]["CompanyEmail"]),
                        Convert.ToString(ds.Tables[0].Rows[0]["CompanyEmail"]), Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]), strMsg, "Confirmation of Valuers Appointment");
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
                int RetVal = objJobsController.JobAppointmentAndInspectedDateSetEdit(Convert.ToInt64(Request.QueryString["JobId"]), Convert.ToDateTime(txtInspectedDate.Text.Trim()), Convert.ToDateTime(txtInspectedDate.Text.Trim()), 6, "Yes", "Inspected", ddlAppointmentTime.SelectedValue);
                if (RetVal > 0)
                {

                    //SendToClientForConfirmationofValuersInspected();
                    FillJobOrderDetails();
                    lblMessage.Text = "Job is successfully updated with Inspected status for property.";
                    trMessage.Visible = true;
                    Response.Redirect("EmailInspected.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
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
                    AccountUpload = Server.MapPath("../FinalReports/Accounts/" + lblAccountUploadNew.Text);
                    CommonController.LogInsert("Inspected:", "SendToClientForConfirmationofValuersInspected");
                    CommonController.LogInsert("AccountUpload:", AccountUpload);
                    objCommonController.SendToClientForConfirmationofValuersInspected(Convert.ToString(ds.Tables[0].Rows[0]["EmailAddress"]),
                        Convert.ToString(ds.Tables[0].Rows[0]["EmailAddress1"]), Convert.ToString(ds.Tables[0].Rows[0]["CompanyEmail"]),
                        Convert.ToString(ds.Tables[0].Rows[0]["CompanyEmail"]), Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]),
                        strMsg, AccountUpload, "Property Valuation - Account");
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

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                int RetVal = objJobsController.JobStatusEdit(Convert.ToInt64(Request.QueryString["JobId"]), 9);
                if (RetVal > 0)
                {
                    if (!chkFinalReportEditEmail.Checked)
                    {
                        SendPDFReportEmailToClient();
                        FillJobOrderDetails();
                        lblMessage.Text = "Job is Completed.";
                        trMessage.Visible = true;
                    }
                    else
                    {
                        Response.Redirect("EmailFinalReport.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
                    }
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


                    string ReportUpload = Server.MapPath("../FinalReports/" + lblPdfReport.Text);
                    string AccountUpload = "";
                    if (lblAccountUploadNew.Text.Trim() != "")
                        AccountUpload = Server.MapPath("../FinalReports/Accounts/" + lblAccountUploadNew.Text);
                    string FieldNoteUpload = "";
                    if (lblFieldNoteUploadNew.Text.Trim() != "")
                        FieldNoteUpload = Server.MapPath("../FinalReports/" + lblFieldNoteUploadNew.Text);

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


        protected void btnChangeValuer_Click(object sender, EventArgs e)
        {
            hdnValuerReassign.Value = "Valuer";
            mdlPopupValuer.Show();
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

        protected void btnValuationInstructionUpload_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                string strDocument = hdnValuationInstruction.Value.Trim();
                if (fuVI.FileName.ToString() != "")
                    strDocument = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + "Instructions" + Path.GetExtension(fuVI.FileName);
                if (objJobsController.JobDocumentEdit(Convert.ToInt64(Request.QueryString["JobId"]), strDocument, "ADDVI") > 0)
                {
                    string ValuationInstructionPath = Server.MapPath("~/Documents/ValuationInstruction/");
                    if (fuVI.FileName.ToString() != "")
                    {
                        fuVI.SaveAs(ValuationInstructionPath + fuVI.FileName);
                        File.Move(ValuationInstructionPath + fuVI.FileName, ValuationInstructionPath + strDocument);
                    }

                    lblMessage.Text = "Document for Valuation Instruction uploaded successfully";
                    trMessage.Visible = true;
                    FillJobOrderDetails();
                }
                else
                {
                    lblMessage.Text = "Document for Valuation Instruction does not uploaded successfully";
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
        protected void btnValuationInstructionDelete_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                string strDocument = "";
                if (objJobsController.JobDocumentEdit(Convert.ToInt64(Request.QueryString["JobId"]), "", "DELVI") > 0)
                {
                    lblMessage.Text = "Document for Valuation Instruction deleted successfully";
                    trMessage.Visible = true;
                    FillJobOrderDetails();
                }
                else
                {
                    lblMessage.Text = "Document for Valuation Instruction does not deleted successfully";
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
        protected void btnPropertyReportUpload_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                string strDocument = hdnPropertyReport.Value.Trim();
                if (fuPR.FileName.ToString() != "")
                    strDocument = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + "PropertyReport" + Path.GetExtension(fuPR.FileName);
                if (objJobsController.JobDocumentEdit(Convert.ToInt64(Request.QueryString["JobId"]), strDocument, "ADDPR") > 0)
                {
                    string PropertyReportPath = Server.MapPath("~/Documents/PropertyReport/");
                    if (fuPR.FileName.ToString() != "")
                    {
                        fuPR.SaveAs(PropertyReportPath + fuPR.FileName);
                        File.Move(PropertyReportPath + fuPR.FileName, PropertyReportPath + strDocument);
                    }

                    lblMessage.Text = "Document for Property Report uploaded successfully";
                    trMessage.Visible = true;
                    FillJobOrderDetails();
                }
                else
                {
                    lblMessage.Text = "Document for Property Report does not uploaded successfully";
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
        protected void btnPropertyReportDelete_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                string strDocument = "";
                if (objJobsController.JobDocumentEdit(Convert.ToInt64(Request.QueryString["JobId"]), "", "DELPR") > 0)
                {
                    lblMessage.Text = "Document for Property Report deleted successfully";
                    trMessage.Visible = true;
                    FillJobOrderDetails();
                }
                else
                {
                    lblMessage.Text = "Document for Property Report does not deleted successfully";
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
        protected void btnOverlaysUpload_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                string strDocument = hdnOverlays.Value.Trim();
                if (fuOL.FileName.ToString() != "")
                    strDocument = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + "Overlays" + Path.GetExtension(fuOL.FileName);
                if (objJobsController.JobDocumentEdit(Convert.ToInt64(Request.QueryString["JobId"]), strDocument, "ADDOL") > 0)
                {
                    string OverlaysPath = Server.MapPath("~/Documents/Overlays/");
                    if (fuOL.FileName.ToString() != "")
                    {
                        fuOL.SaveAs(OverlaysPath + fuOL.FileName);
                        File.Move(OverlaysPath + fuOL.FileName, OverlaysPath + strDocument);
                    }

                    lblMessage.Text = "Document for Overlays uploaded successfully";
                    trMessage.Visible = true;
                    FillJobOrderDetails();
                }
                else
                {
                    lblMessage.Text = "Document for Overlays does not uploaded successfully";
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
        protected void btnOverlaysDelete_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                if (objJobsController.JobDocumentEdit(Convert.ToInt64(Request.QueryString["JobId"]), "", "DELOL") > 0)
                {
                    lblMessage.Text = "Document for Overlays deleted successfully";
                    trMessage.Visible = true;
                    FillJobOrderDetails();
                }
                else
                {
                    lblMessage.Text = "Document for Overlays does not deleted successfully";
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
        protected void btnTitleUpload_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                string strDocument = hdnTitle.Value.Trim();
                if (fuTL.FileName.ToString() != "")
                    strDocument = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + "Title" + Path.GetExtension(fuTL.FileName);
                if (objJobsController.JobDocumentEdit(Convert.ToInt64(Request.QueryString["JobId"]), strDocument, "ADDTL") > 0)
                {
                    string TitlePath = Server.MapPath("~/Documents/Title/");
                    if (fuTL.FileName.ToString() != "")
                    {
                        fuTL.SaveAs(TitlePath + fuTL.FileName);
                        File.Move(TitlePath + fuTL.FileName, TitlePath + strDocument);
                    }

                    lblMessage.Text = "Document for Title uploaded successfully";
                    trMessage.Visible = true;
                    FillJobOrderDetails();
                }
                else
                {
                    lblMessage.Text = "Document for Title does not uploaded successfully";
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
        protected void btnTitleDelete_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                string strDocument = "";
                if (objJobsController.JobDocumentEdit(Convert.ToInt64(Request.QueryString["JobId"]), "", "DELTL") > 0)
                {
                    lblMessage.Text = "Document for Title deleted successfully";
                    trMessage.Visible = true;
                    FillJobOrderDetails();
                }
                else
                {
                    lblMessage.Text = "Document for Title does not deleted successfully";
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
        protected void btnUploadOthers_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                string strDocument = "";
                if (fuOthers.FileName.ToString() != "")
                    strDocument = DateTime.Now.ToString("HHmmssffff") + "_" + fuOthers.FileName;
                if (objJobsController.JobDocumentsEdit(0, Convert.ToInt64(Request.QueryString["JobId"]), strDocument, "ADD") > 0)
                {
                    string OtherPath = Server.MapPath("~/Documents/Others/");
                    if (fuOthers.FileName.ToString() != "")
                    {
                        fuOthers.SaveAs(OtherPath + fuOthers.FileName);
                        File.Move(OtherPath + fuOthers.FileName, OtherPath + strDocument);
                    }

                    lblMessage.Text = "Document uploaded successfully";
                    trMessage.Visible = true;
                    FillJobDocuments();
                }
                else
                {
                    lblMessage.Text = "Document does not uploaded successfully";
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

        protected void dlDocuments_ItemCommand(object source, DataListCommandEventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                if (e.CommandName.ToString() == "DEL")
                {
                    if (objJobsController.JobDocumentsEdit(Convert.ToInt64(e.CommandArgument.ToString()), 0, "", "DELETE") > 0)
                    {
                        lblMessage.Text = "Document deleted successfully";
                        trMessage.Visible = true;
                        FillJobDocuments();
                    }
                    else
                    {
                        lblMessage.Text = "Document does not deleted successfully";
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

        protected void btnEmailToClient_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                JobsController.JobsEditIsClientReportEdit(Convert.ToInt64(Request.QueryString["JobId"]), 1);
                SendReportEditByClient();

                lblMessage.Text = "Email sent successfully to client to edit property details to generate final reports.";
                trMessage.Visible = true;

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

        private void SendReportEditByClient()
        {
            CommonController objCommonController = new CommonController();
            StreamReader sr = new StreamReader(Server.MapPath("~/EmailTemplates/ReportEditByClient.html"));
            DataSet ds = new DataSet();
            try
            {
                string strMsg = sr.ReadToEnd();
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



                    objCommonController.SendReportEditByClient(lblEmailAddress.Text.Trim(), Convert.ToString(ds.Tables[0].Rows[0]["CompanyEmail"]),
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
