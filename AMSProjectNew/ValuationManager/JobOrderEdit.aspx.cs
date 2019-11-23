using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.IO;

namespace AMSProjectNew.ValuationManager
{
    public partial class JobOrderEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillClients();
                FillAccessArangementsType();
                FillServiceType();
                FillValuationType();
                FillPropertyType();
                FillPurpose();
                FillTransactionType();
                FillUrgency();

                if (Request.QueryString["JobId"] != null)
                    FillJobOrderDetails();
            }
        }
        private void FillClients()
        {
            ClientsController clientsController = new ClientsController();
            DataSet ds = new DataSet();
            try
            {
                ds = clientsController.ClientsSelectAll(0, "", 0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlClients.DataSource = ds.Tables[0].DefaultView;
                    ddlClients.DataTextField = "CompanyName";
                    ddlClients.DataValueField = "Id";
                    ddlClients.DataBind();
                }
                ddlClients.Items.Insert(0, new ListItem("--- Select Client ---", "0"));
                ddlClients.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                clientsController = null;
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

        private void FillJobOrderDetails()
        {
            JobsController objJobsController = new JobsController();
            DataSet ds = new DataSet();
            try
            {
                ds = objJobsController.JobsSelectByJobIdForEdit(Convert.ToInt64(Request.QueryString["JobId"]));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblJobNo.Text = "Job No - " + Convert.ToString(ds.Tables[0].Rows[0]["JobId"]);
                    if (Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]) != "")
                        lblJobTitle.Text = Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]) + "/" + Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + " - " + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                    else
                        lblJobTitle.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + " - " + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);

                    if (Convert.ToString(ds.Tables[0].Rows[0]["ClientId"]) != "0")
                    {
                        ddlClients.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ClientId"]);
                        txtClientName.Enabled = false;
                        txtClientAddress.Enabled = false;
                    }
                    else
                    {
                        txtClientName.Text= Convert.ToString(ds.Tables[0].Rows[0]["ClientName"]);
                        txtClientAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["ClientAddress"]);
                        ddlClients.Enabled = false;
                    }

                    txtLoanReference.Text = Convert.ToString(ds.Tables[0].Rows[0]["LoanReference"]);
                    txtCustomerFullName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CustomerFullName"]);
                    txtCustomerPhoneNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["CustomerPhoneNumber"]);
                    txtCustomerMobileNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["CustomerMobilePhoneNumber"]);
                    txtCustomerAdditionalPhoneNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["CustomerAdditionalPhoneNumber"]);
                    txtCustomerEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmailAddress"]);
                    ddlAccessArangementsType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["AccessArangementsVia"]);
                    txtNameOfPersonToContactForAccess.Text = Convert.ToString(ds.Tables[0].Rows[0]["NameOfPersonToContactForAccess"]);
                    txtPhoneNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["PhoneNumber"]);
                    txtMobilePhoneNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["MobilePhoneNumber"]);
                    txtAdditionalPhoneNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["AdditionalPhoneNumber"]);
                    txtAdditionalNotes.Text = Convert.ToString(ds.Tables[0].Rows[0]["AdditionalNotes"]);
                    txtUnitLot.Text = Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]);
                    txtStreetNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]);
                    txtStreetName.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]);
                    txtStreetType.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]);
                    txtSuburb.Text = Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]);
                    txtPostcode.Text = Convert.ToString(ds.Tables[0].Rows[0]["Postcode"]);
                    ddlState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["State"]);
                    txtPriorJobReference.Text = Convert.ToString(ds.Tables[0].Rows[0]["PriorJobreference"]);
                    txtContractPrice.Text = Convert.ToString(ds.Tables[0].Rows[0]["ContractPrice"]);
                    if (Convert.ToString(ds.Tables[0].Rows[0]["ContractDate"])!="")
                        txtContractDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ContractDate"]).ToString("dd/MM/yyyy");
                    txtEstimatedPrice.Text = Convert.ToString(ds.Tables[0].Rows[0]["EstimatedPrice"]);
                    ddlServiceType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ServiceType"]);
                    ddlValuationType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ValuationType"]);
                    ddlPropertyType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PropertyType"]);
                    ddlPurpose.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Purpose"]);
                    ddlTransactionType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TransactionType"]);
                    ddlUrgency.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Urgency"]);
                    txtQuoteFee.Text = Convert.ToString(ds.Tables[0].Rows[0]["QuoteFee"]);
                    lblAssignCompanyId.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedId"]);
                    txtCustomerEmail1.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmailAddress1"]);
                }
                else
                {
                    lblError.Text = "Job details doesnt available at this moments.";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
            finally
            {
                objJobsController = null;
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
                string ValuationInstruction="";
                string PropertyReport = "";
                string Overlays = "";
                string Title = "";

                Int64 RetVal = objJobsController.JobsEdit(Convert.ToInt64(Request.QueryString["JobId"]), 
                    Convert.ToInt64(ddlClients.SelectedValue), Convert.ToInt64(ddlClients.SelectedValue), 0, 0, 
                    txtLoanReference.Text.Trim(), txtCustomerFullName.Text.Trim(), txtCustomerPhoneNumber.Text.Trim(),
                    txtCustomerMobileNumber.Text.Trim(), txtCustomerAdditionalPhoneNumber.Text.Trim(), 
                    Convert.ToInt64(ddlAccessArangementsType.SelectedValue), txtNameOfPersonToContactForAccess.Text.Trim(),
                    txtPhoneNumber.Text.Trim(), txtMobilePhoneNumber.Text.Trim(), txtAdditionalPhoneNumber.Text.Trim(), 
                    txtAdditionalNotes.Text.Trim(), txtUnitLot.Text.Trim(), txtStreetNumber.Text.Trim(), 
                    txtStreetName.Text.Trim(),txtStreetType.Text.Trim(), txtSuburb.Text.Trim(), txtPostcode.Text.Trim(), 
                    txtPriorJobReference.Text.Trim(), ContractPrice, ContractDate, EstimatedPrice, 
                    Convert.ToInt64(ddlServiceType.SelectedValue),
                    Convert.ToInt64(ddlValuationType.SelectedValue), Convert.ToInt64(ddlPropertyType.SelectedValue),
                    Convert.ToInt64(ddlPurpose.SelectedValue), Convert.ToInt64(ddlTransactionType.SelectedValue),
                    Convert.ToInt64(ddlUrgency.SelectedValue), QuoteFee, Convert.ToInt64(Session["UserId"]), 0,
                    1, "EDITBYVC", txtCustomerEmail.Text.Trim(), txtClientName.Text.Trim(), "Valuation Manager",
                    ddlState.SelectedValue, txtClientAddress.Text.Trim(), txtCustomerEmail1.Text.Trim(),
                    ValuationInstruction, PropertyReport, Overlays, Title);
                if (RetVal > 0)
                {
                    if (lblAssignCompanyId.Text.Trim() != "")
                    {
                        GenerateAccountHtmlFile(Convert.ToString(Request.QueryString["JobId"]));
                        objJobsController.JobEditFinalReportSubmit(Convert.ToInt64(Request.QueryString["JobId"]), "", "Account_" + Convert.ToString(Request.QueryString["JobId"]) + ".pdf", "", 7, "ACCOUNTUPLOAD");
                    }

                    Response.Redirect("JobOrderDetails.aspx?JobId=" + RetVal.ToString(), false);
                }
                else
                {
                    lblError.Text = "Your job doesnt updated due to some technical issues. Please try again later.";
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
                ds = valuationCompanyController.ValuationCompanySelectAll(Convert.ToInt64(lblAssignCompanyId.Text.Trim()), 0, 0);
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
                    if (Convert.ToString(ds.Tables[0].Rows[0]["CompanyLogo"]) != "")
                        LogoURL = "CompanyLogo/" + Convert.ToString(ds.Tables[0].Rows[0]["CompanyLogo"]);
                        //LogoURL = System.Configuration.ConfigurationManager.AppSettings["URL"].ToString() + "CompanyLogo/" + Convert.ToString(ds.Tables[0].Rows[0]["CompanyLogo"]);

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
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobOrderDetails.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
        }
    }
}
