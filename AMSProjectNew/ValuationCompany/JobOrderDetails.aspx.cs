using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.IO;

namespace AMSProjectNew.ValuationCompany
{
    public partial class JobOrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["JobId"] != null)
                {
                    hdnValuerId.Value = "0";
                    FillActiveValuers();
                    FillJobOrderDetails();
                    FillJobHistory();
                    FillJobEditRequests();

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
        private void FillActiveValuers()
        {
            ValuersController valuersController = new ValuersController();
            DataSet ds = new DataSet();
            try
            {
                ds = valuersController.ValuersSelectAll(0, Convert.ToInt64(Session["UserId"]), 2);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvValuer.DataSource = ds.Tables[0].DefaultView;
                    gvValuer.DataBind();
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
                        lblJobTitle.Text = Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]) + "/" + Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                        lblJobTitlePopup.Text = "Job # " + Convert.ToString(ds.Tables[0].Rows[0]["JobId"]) + " - " + Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]) + "/" + Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                        lblJobTitlePopupReject.Text = "Job # " + Convert.ToString(ds.Tables[0].Rows[0]["JobId"]) + " - " + Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]) + "/" + Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                    }
                    else
                    {
                        lblJobTitle.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                        lblJobTitlePopup.Text = "Job # " + Convert.ToString(ds.Tables[0].Rows[0]["JobId"]) + " - " + Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                        lblJobTitlePopupReject.Text = "Job # " + Convert.ToString(ds.Tables[0].Rows[0]["JobId"]) + " - " + Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
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
                    lblStatus.Text = Convert.ToString(ds.Tables[0].Rows[0]["Status"]);
                    lblCreatedOn.Text = Convert.ToString(ds.Tables[0].Rows[0]["CreatedOn"]);
                    trJobDetails.Visible = true;

                    trPaymentStatus.Visible = false;
                    if (Convert.ToString(ds.Tables[0].Rows[0]["ClientName"]) != "")
                    {
                        lblPaymentStatus.Text = Convert.ToString(ds.Tables[0].Rows[0]["PaymentStatus"]);
                        trPaymentStatus.Visible = true;
                        tblAccontUpload.Visible = true;
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


                    lblValuer.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuersName"]);
                    lblReviewer.Text = Convert.ToString(ds.Tables[0].Rows[0]["ReviewerName"]);

                    if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "2")
                    {
                        tblAR.Visible = true;
                        tblVR.Visible = false;
                        tblRejected.Visible = false;
                    }
                    else if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "3")
                    {
                        tblAR.Visible = false;
                        tblVR.Visible = false;
                        tblRejected.Visible = true;
                    }
                    else
                    {
                        tblAR.Visible = false;
                        tblVR.Visible = true;
                        tblRejected.Visible = false;
                    }

                    tdEditRequest.Visible = false;
                    btnEditJob.Visible = false;
                    btnDeleteJob.Visible = false;
                    if (Convert.ToString(ds.Tables[0].Rows[0]["UserId"]) == Convert.ToString(Session["UserId"]))
                    {
                        tdEditRequest.Visible = true;
                        btnEditJob.Visible = true;
                        btnDeleteJob.Visible = false;
                    }

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
        protected void gvValuer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument.ToString() == "Assign")
            {
                JobsController objJobsController = new JobsController();
                try
                {
                    int RetVal = objJobsController.JobsEditAssignToValuer(Convert.ToInt64(Request.QueryString["JobId"]), Convert.ToInt64(e.CommandName.ToString()));
                    if (RetVal > 0)
                    {
                        objJobsController.JobStatusEdit(Convert.ToInt64(Request.QueryString["JobId"]), 4);
                        FillJobOrderDetails();
                        lblMessage.Text = "Job is successfully accepted and assigned to valuer.";
                        trMessage.Visible = true;
                    }
                    else
                    {
                        lblMessage.Text = "Due to technical issues, your Job does not accepted and assigned to valuer.";
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
        protected void btnAccept_Click(object sender, EventArgs e)
        {
            mdlPopUp.Show();
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            mdlPopUpReject.Show();
        }
        protected void btnAssignValuerSubmit_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                int RetVal = objJobsController.JobsEditAssignToValuer(Convert.ToInt64(Request.QueryString["JobId"]), Convert.ToInt64(hdnValuerId.Value));
                if (RetVal > 0)
                {
                    //GenerateAccountHtmlFile(Convert.ToString(Request.QueryString["JobId"]));
                    objJobsController.JobStatusEdit(Convert.ToInt64(Request.QueryString["JobId"]), 4);
                    FillJobOrderDetails();
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
        public void GenerateAccountHtmlFile(string RetVal)
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
                ds = valuationCompanyController.ValuationCompanySelectAll(Convert.ToInt64(Session["UserId"]), 0, 0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    strMsg = strMsg.Replace("{CompanyName}", Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]));
                    strMsg = strMsg.Replace("{CompanyAddress1}", Convert.ToString(ds.Tables[0].Rows[0]["Address"]));
                    strMsg = strMsg.Replace("{CompanyAddress2}", Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "  " + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + " - " + Convert.ToString(ds.Tables[0].Rows[0]["Postcode"]));
                    strMsg = strMsg.Replace("{CompanyAddress3}", "");
                    strMsg = strMsg.Replace("{ClientName}", lblBankLender.Text.Trim());
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
        protected void btnRejectJobSubmit_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                decimal NewFee = 0;
                Int64 RetVal = 0;
                
                if (chkFeeReject.Checked == true)
                {
                    NewFee = Convert.ToDecimal(txtNewFee.Text.Trim());
                    RetVal = objJobsController.JobEditReject(0, Convert.ToInt64(Request.QueryString["JobId"]), Convert.ToInt64(Session["UserId"]),10, NewFee, "REJECT");
                }
                else
                    RetVal = objJobsController.JobEditReject(0, Convert.ToInt64(Request.QueryString["JobId"]), Convert.ToInt64(Session["UserId"]),1, NewFee, "REJECT");

                if (RetVal > 0)
                {
                    objJobsController.JobHistoryEdit(0, Convert.ToInt64(Request.QueryString["JobId"]), Convert.ToInt64(Session["UserId"]), "", txtRejectReason.Text.Trim(), "JobReject", "ADD");
                    FillJobOrderDetails();
                    lblMessage.Text = "Job is successfully rejected.";
                    trMessage.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Due to technical issues, your Job does not rejected.";
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
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobOrderList.aspx", false);
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
    }
}
