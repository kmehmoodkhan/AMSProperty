using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Drawing;
using ExpertPdf.HtmlToPdf;
using ExpertPdf.HtmlToPdf.PdfDocument;
using System.IO;

namespace AMSProjectNew.ValuationCompany
{
    public partial class JobOrderCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillActiveValuers();     
                FillAccessArangementsType();
                FillServiceType();
                FillValuationType();
                FillPropertyType();
                FillPurpose();
                FillTransactionType();
                FillUrgency();
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
                    ddlValuer.DataSource = ds.Tables[0].DefaultView;
                    ddlValuer.DataTextField = "FullName";
                    ddlValuer.DataValueField = "UserId";
                    ddlValuer.DataBind();
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
        
        private void FillAccessArangementsType()
        {
            CommonController commonController = new CommonController();
            DataSet ds = new DataSet();
            try
            {
                ds = commonController.AccessArangementsTypeSelectAll(0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlAccessArangementsType.DataSource = ds.Tables[0].DefaultView;
                    ddlAccessArangementsType.DataTextField = "AccessArangementsTypeName";
                    ddlAccessArangementsType.DataValueField = "Id";
                    ddlAccessArangementsType.DataBind();
                }
                ddlAccessArangementsType.Items.Insert(0, new ListItem("Select Access Arangements Type", "0"));
                ddlAccessArangementsType.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                commonController = null;
                ds = null;
            }
        }
        private void FillServiceType()
        {
            CommonController commonController = new CommonController();
            DataSet ds = new DataSet();
            try
            {
                ds = commonController.ServiceTypeSelectAll(0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlServiceType.DataSource = ds.Tables[0].DefaultView;
                    ddlServiceType.DataTextField = "ServiceTypeName";
                    ddlServiceType.DataValueField = "Id";
                    ddlServiceType.DataBind();                    
                }
                ddlServiceType.Items.Insert(0, new ListItem("Select Service Type", "0"));
                ddlServiceType.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                commonController = null;
                ds = null;
            }
        }
        private void FillUrgency()
        {
            CommonController commonController = new CommonController();
            DataSet ds = new DataSet();
            try
            {
                ds = commonController.UrgencySelectAll(0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlUrgency.DataSource = ds.Tables[0].DefaultView;
                    ddlUrgency.DataTextField = "UrgencyName";
                    ddlUrgency.DataValueField = "Id";
                    ddlUrgency.DataBind();
                }
                ddlUrgency.Items.Insert(0, new ListItem("Select Urgency", "0"));
                ddlUrgency.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                commonController = null;
                ds = null;
            }
        }

        private void FillTransactionType()
        {
            CommonController commonController = new CommonController();
            DataSet ds = new DataSet();
            try
            {
                ds = commonController.TransactionTypeSelectAll(0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlTransactionType.DataSource = ds.Tables[0].DefaultView;
                    ddlTransactionType.DataTextField = "TransactionTypeName";
                    ddlTransactionType.DataValueField = "Id";
                    ddlTransactionType.DataBind();
                }
                ddlTransactionType.Items.Insert(0, new ListItem("Select Transaction Type", "0"));
                ddlTransactionType.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                commonController = null;
                ds = null;
            }
        }

        private void FillPurpose()
        {
            CommonController commonController = new CommonController();
            DataSet ds = new DataSet();
            try
            {
                ds = commonController.PurposeSelectAll(0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlPurpose.DataSource = ds.Tables[0].DefaultView;
                    ddlPurpose.DataTextField = "PurposeName";
                    ddlPurpose.DataValueField = "Id";
                    ddlPurpose.DataBind();
                }
                ddlPurpose.Items.Insert(0, new ListItem("Select Purpose", "0"));
                ddlPurpose.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                commonController = null;
                ds = null;
            }
        }

        private void FillPropertyType()
        {
            CommonController commonController = new CommonController();
            DataSet ds = new DataSet();
            try
            {
                ds = commonController.PropertyTypeSelectAll(0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlPropertyType.DataSource = ds.Tables[0].DefaultView;
                    ddlPropertyType.DataTextField = "PropertyTypeName";
                    ddlPropertyType.DataValueField = "Id";
                    ddlPropertyType.DataBind();
                }
                ddlPropertyType.Items.Insert(0, new ListItem("Select Property Type", "0"));
                ddlPropertyType.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                commonController = null;
                ds = null;
            }
        }

        private void FillValuationType()
        {
            CommonController commonController = new CommonController();
            DataSet ds = new DataSet();
            try
            {
                ds = commonController.ValuationTypeSelectAll(0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlValuationType.DataSource = ds.Tables[0].DefaultView;
                    ddlValuationType.DataTextField = "ValuationTypeName";
                    ddlValuationType.DataValueField = "Id";
                    ddlValuationType.DataBind();
                }
                ddlValuationType.Items.Insert(0, new ListItem("Select Valuation Type", "0"));
                ddlValuationType.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                commonController = null;
                ds = null;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            try
            {
                string QuoteFee = txtQuoteFee.Text;
                string ContractPrice =txtContractPrice.Text;

                DateTime? ContractDate = null;
                if (txtContractDate.Text.Trim() != "")
                {
                    if (CommonController.GetConfigurationVal("Mode") == "LOCAL")
                    {
                        string[] strDate = txtContractDate.Text.Trim().Split('/');
                        ContractDate = Convert.ToDateTime(strDate[1].ToString() + "/" + strDate[0].ToString() + "/" + strDate[2].ToString());
                    }
                    else
                    {
                        ContractDate = Convert.ToDateTime(txtContractDate.Text.Trim());
                    }
                }

                string EstimatedPrice =txtEstimatedPrice.Text;
                string ValuationInstruction = "";
                string PropertyReport = "";
                string Overlays = "";
                string Title = "";

                Int64 RetVal = objJobsController.JobsEdit(0, 0, Convert.ToInt64(Session["UserId"]), 0, 0, txtLoanReference.Text.Trim(), txtCustomerFullName.Text.Trim(), txtCustomerPhoneNumber.Text.Trim(),
                    txtCustomerMobileNumber.Text.Trim(), txtCustomerAdditionalPhoneNumber.Text.Trim(), Convert.ToInt64(ddlAccessArangementsType.SelectedValue), txtNameOfPersonToContactForAccess.Text.Trim(),
                    txtPhoneNumber.Text.Trim(), txtMobilePhoneNumber.Text.Trim(), txtAdditionalPhoneNumber.Text.Trim(), txtAdditionalNotes.Text.Trim(), txtUnitLot.Text.Trim(), txtStreetNumber.Text.Trim(), txtStreetName.Text.Trim(),
                    txtStreetType.Text.Trim(), txtSuburb.Text.Trim(), txtPostcode.Text.Trim(), txtPriorJobReference.Text.Trim(), ContractPrice, ContractDate, EstimatedPrice, Convert.ToInt64(ddlServiceType.SelectedValue),
                    Convert.ToInt64(ddlValuationType.SelectedValue), Convert.ToInt64(ddlPropertyType.SelectedValue), Convert.ToInt64(ddlPurpose.SelectedValue), Convert.ToInt64(ddlTransactionType.SelectedValue),
                    Convert.ToInt64(ddlUrgency.SelectedValue), QuoteFee, Convert.ToInt64(Session["UserId"]), 0, 4, "ADD", txtCustomerEmail.Text.Trim(), txtClientName.Text.Trim(), "Valuation Company", ddlState.SelectedValue,
                    txtClientAddress.Text.Trim(), txtCustomerEmail1.Text.Trim(), ValuationInstruction, PropertyReport, Overlays, Title);
                if (RetVal > 0)
                {
                    //Assign to Company
                    objJobsController.JobsEditAssignToValuationCompany(RetVal, Convert.ToInt64(Session["UserId"]));
                    //Assign to Valuer
                    objJobsController.JobsEditAssignToValuer(RetVal, Convert.ToInt64(ddlValuer.SelectedValue));
                    //Edit Status
                    objJobsController.JobStatusEdit(RetVal, 4);

                    //Create Account PDF
                    GenerateAccountHtmlFile(RetVal.ToString());

                    objJobsController.JobEditFinalReportSubmit(RetVal, "", "Account_" + RetVal.ToString() + ".pdf", "", 7, "ACCOUNTUPLOAD");

                    Response.Redirect("JobOrderDetails.aspx?JobId=" + RetVal.ToString(), false);
                }
                else
                {
                    lblError.Text = "Your job doesnt created due to some technical issues. Please try again.";
                    return;
                }
            }
            catch (Exception Ex)
            {
                lblError.Text = Ex.Message.ToString();
            }
            finally
            {
                objJobsController = null;
            }
        }

        public void GenerateAccountHtmlFile(string RetVal)
        {
            CommonController objCommonController=new CommonController();
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
                    strMsg = strMsg.Replace("{ClientName}", txtClientName.Text.Trim() + "<br>" + txtClientAddress.Text.Trim().Replace("\r", "<br>"));
                    strMsg = strMsg.Replace("{InvoiceNo}", RetVal);
                    strMsg = strMsg.Replace("{Date}", DateTime.Now.ToString("ddd dd MM yyyy"));

                    string PropertyAddress = txtStreetNumber.Text.Trim() + " " + txtStreetName.Text.Trim() + " " + txtStreetType.Text.Trim() + " " + txtSuburb.Text.Trim() + "  " + ddlState.SelectedValue + " - " + txtPostcode.Text.Trim();
                    if (txtUnitLot.Text.Trim() != "")
                        PropertyAddress = txtUnitLot.Text.Trim() + " / " + PropertyAddress;
                    strMsg = strMsg.Replace("{PropertyAddress}", PropertyAddress);

                    strMsg = strMsg.Replace("{RefNo}", RetVal);
                    strMsg = strMsg.Replace("{QuoteFee}", txtQuoteFee.Text.Trim());
                    strMsg = strMsg.Replace("{CompanyName}", Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]));
                    strMsg = strMsg.Replace("{QuoteFee}", txtQuoteFee.Text.Trim());
                    strMsg = strMsg.Replace("{CompanyAddress2}", Convert.ToString(ds.Tables[0].Rows[0]["Address"]));
                    strMsg = strMsg.Replace("{CompanyAddress3}", Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "  " + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + " - " + Convert.ToString(ds.Tables[0].Rows[0]["Postcode"]));
                    strMsg = strMsg.Replace("{CompanyTelephone}", Convert.ToString(ds.Tables[0].Rows[0]["Phone1"]));
                    strMsg = strMsg.Replace("{CompanyEmail}", Convert.ToString(ds.Tables[0].Rows[0]["Email"]));
                    strMsg = strMsg.Replace("{CompanyWebsite}", "www.valuationcentral.com.au");

                    string LogoURL = "Images/Logo.png";
                    if(Convert.ToString(ds.Tables[0].Rows[0]["CompanyLogo"])!="")
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

                    //objCommonController.CreateAccountPdf(System.Configuration.ConfigurationManager.AppSettings["URL"].ToString() + "FinalReportsTemp/" + RetVal + ".html",strPDFFile, RetVal.ToString());
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
        
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobOrderList.aspx", false);
        }


    }
}
