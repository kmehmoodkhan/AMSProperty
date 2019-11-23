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
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            lblError.Text = "";
            if (!IsPostBack)
            {
                if (Session["UserId"] != null && Convert.ToString(Session["UserId"]) != "")
                {
                    FillValuationCompanyDetails();

                    tdProfileDetails.Attributes.Add("class", "TDSelected");
                    tdAccountDetails.Attributes.Add("class", "TDNotSelected");
                    tdLogoDetails.Attributes.Add("class", "TDNotSelected");

                    tblAccountDetails.Visible = false;
                    tblLogoDetails.Visible = false;
                }
            }
        }

        private void FillValuationCompanyDetails()
        {
            ValuationCompanyController valuationCompanyController = new ValuationCompanyController();
            DataSet ds = new DataSet();
            try
            {
                ds = valuationCompanyController.ValuationCompanySelectAll(Convert.ToInt64(Session["UserId"]), 0, 0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    
                    rdStatus.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Status"]);
                    txtUsername.Text = Convert.ToString(ds.Tables[0].Rows[0]["Username"]);
                    txtPassword.Text = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
                    trConfirmPassword.Visible = false;
                    txtPassword.Visible = false;
                    lblPassword.Visible = true;

                    txtCompanyName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]);
                    txtStartDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["StartDate"]).ToString("MM/dd/yyyy");
                    txtEndDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["EndDate"]).ToString("MM/dd/yyyy");
                    txtEmailAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                    txtFirstName.Text = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
                    txtLastName.Text = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
                    txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
                    txtSuburb.Text = Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]);
                    txtPostcode.Text = Convert.ToString(ds.Tables[0].Rows[0]["Postcode"]);
                    txtState.Text = Convert.ToString(ds.Tables[0].Rows[0]["State"]);
                    txtPhone1.Text = Convert.ToString(ds.Tables[0].Rows[0]["Phone1"]);
                    txtPhone2.Text = Convert.ToString(ds.Tables[0].Rows[0]["Phone2"]);
                    txtFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["Fax"]);
                   
                    txtOtherDetails.Text = Convert.ToString(ds.Tables[0].Rows[0]["OtherDetails"]);
                    trStatistics.Visible = true;

                    lblCreatedOn.Text = Convert.ToString(ds.Tables[0].Rows[0]["CreatedOn"]);
                    lblModifiedOn.Text = Convert.ToString(ds.Tables[0].Rows[0]["ModifiedOn"]);
                    lblLastLoggedOn.Text = Convert.ToString(ds.Tables[0].Rows[0]["LastLoggedOn"]);

                    //string PdfFile = "<a target='0' href='../InsurancePolicy/" + Convert.ToString(ds.Tables[0].Rows[0]["ProfessionalIndemnityInsurancePolicy"]) + "'><img src='../Images/pdf_icon.gif' border='0'></a>";
                    string PdfFile = "<a target='0' href='../InsurancePolicy/ABC.pdf'><img src='../Images/pdf_icon.gif' border='0'></a>";
                    lblPdfFileShow.Text = PdfFile;
                    lblPdfFileName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProfessionalIndemnityInsurancePolicy"]);

                    txtBankName.Text = Convert.ToString(ds.Tables[0].Rows[0]["BankName"]);
                    txtACNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["ACNumber"]);
                    txtBSB.Text = Convert.ToString(ds.Tables[0].Rows[0]["BSB"]);
                    txtABN.Text = Convert.ToString(ds.Tables[0].Rows[0]["ABN"]);

                    lblCompanyLogo.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyLogo"]);
                    imgLogo.Visible = false;
                    if (File.Exists(Server.MapPath("~/CompanyLogo/" + lblCompanyLogo.Text)))
                    {
                        imgLogo.ImageUrl = "~/CompanyLogo/" + lblCompanyLogo.Text;
                        imgLogo.Visible = true;
                    }
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
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ValuationCompanyController valuationCompanyController = new ValuationCompanyController();
            UsersController usersController = new UsersController();
            DataSet ds = new DataSet();
            try
            {

                Int64 Id = valuationCompanyController.ValuationCompanyEdit(Convert.ToInt64(Session["UserId"]), Convert.ToInt64(Session["UserId"]),
                            txtEmailAddress.Text.Trim(),
                            txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtCompanyName.Text.Trim(), txtAddress.Text.Trim(),
                            txtSuburb.Text.Trim(), txtState.Text.Trim(), txtPostcode.Text.Trim(), txtPhone1.Text.Trim(),
                            txtPhone2.Text.Trim(), txtOtherDetails.Text.Trim(), txtFax.Text.Trim(),
                            Convert.ToInt64(Session["UserId"]), Convert.ToInt64(Session["UserId"]),
                            Convert.ToInt64(rdStatus.SelectedValue), lblPdfFileName.Text.Trim(),
                            Convert.ToDateTime(txtStartDate.Text.Trim()), Convert.ToDateTime(txtEndDate.Text.Trim()),
                            "EDITBYVC",false,lblCompanyLogo.Text.Trim(),txtBankName.Text.Trim(),txtBSB.Text.Trim(),
                            txtACNumber.Text.Trim(), txtABN.Text.Trim(), txtUrl.Text.Trim());

                if (Id > 0)
                {
                    if (chkChangePassword.Checked)
                    {
                        usersController.UsersPasswordEdit(Convert.ToInt64(Session["UserId"]), txtPassword.Text.Trim(), "PASSEDIT");
                    }

                    lblError.Text = "Your details updated successfully.";
                    return;
                }
                else
                {
                    lblError.Text = "Your details does not submitted successfully. Please try again later!";
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                valuationCompanyController = null;
                usersController = null;
                ds = null;
            }
        }

        protected void btnAccountSubmit_Click(object sender, EventArgs e)
        {
            ValuationCompanyController valuationCompanyController = new ValuationCompanyController();
            UsersController usersController = new UsersController();
            DataSet ds = new DataSet();
            try
            {

                Int64 Id = valuationCompanyController.ValuationCompanyBankAndLogoEdit(Convert.ToInt64(Session["UserId"]),
                            "BANKEDIT", lblCompanyLogo.Text.Trim(), txtBankName.Text.Trim(), txtBSB.Text.Trim(),
                            txtACNumber.Text.Trim(), txtABN.Text.Trim());

                if (Id > 0)
                {
                    lblError.Text = "Your bank details updated successfully.";
                    return;
                }
                else
                {
                    lblError.Text = "Your bank details does not updated successfully. Please try again later!";
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                valuationCompanyController = null;
                usersController = null;
                ds = null;
            }
        }

        protected void btnImageUpload_Click(object sender, EventArgs e)
        {
            ValuationCompanyController valuationCompanyController = new ValuationCompanyController();
            UsersController usersController = new UsersController();
            DataSet ds = new DataSet();
            try
            {
                string strCompanyLogo = DateTime.Now.ToString("MMddyyyyhhmmss");
                if (fuLogo.FileName.ToString() != "")
                    strCompanyLogo = strCompanyLogo + fuLogo.FileName;

                Int64 Id = valuationCompanyController.ValuationCompanyBankAndLogoEdit(Convert.ToInt64(Session["UserId"]),
                            "LOGOEDIT", strCompanyLogo, txtBankName.Text.Trim(), txtBSB.Text.Trim(), txtACNumber.Text.Trim(),
                            txtABN.Text.Trim());

                if (Id > 0)
                {
                    fuLogo.SaveAs(Server.MapPath("~/CompanyLogo/" + fuLogo.FileName));
                    File.Move(Server.MapPath("~/CompanyLogo/" + fuLogo.FileName), Server.MapPath("~/CompanyLogo/" + strCompanyLogo));
                    imgLogo.ImageUrl = "~/CompanyLogo/" + strCompanyLogo;
                    lblError.Text = "Your logo updated successfully.";
                    return;
                }
                else
                {
                    lblError.Text = "Your logo does not updated successfully. Please try again later!";
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                valuationCompanyController = null;
                usersController = null;
                ds = null;
            }
        }

        protected void chkChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChangePassword.Checked)
            {
                trConfirmPassword.Visible = true;
                txtPassword.Visible = true;
                lblPassword.Visible = false;
            }
            else
            {
                trConfirmPassword.Visible = false;
                txtPassword.Visible = false;
                lblPassword.Visible = true;
            }
        }

        protected void lbtnProfileDetails_Click(object sender, EventArgs e)
        {
            tblProfileDetails.Visible = true;
            tblLogoDetails.Visible = false;
            tblAccountDetails.Visible = false;
            tdProfileDetails.Attributes.Add("class", "TDSelected");
            tdAccountDetails.Attributes.Add("class", "TDNotSelected");
            tdLogoDetails.Attributes.Add("class", "TDNotSelected");
        }
        protected void lbtnAccountDetails_Click(object sender, EventArgs e)
        {
            tblProfileDetails.Visible = false;
            tblLogoDetails.Visible = false;
            tblAccountDetails.Visible = true;
            tdProfileDetails.Attributes.Add("class", "TDNotSelected");
            tdAccountDetails.Attributes.Add("class", "TDSelected");
            tdLogoDetails.Attributes.Add("class", "TDNotSelected");
        }
        protected void lbtnLogoDetails_Click(object sender, EventArgs e)
        {
            tblProfileDetails.Visible = false;
            tblLogoDetails.Visible = true;
            tblAccountDetails.Visible = false;
            tdProfileDetails.Attributes.Add("class", "TDNotSelected");
            tdAccountDetails.Attributes.Add("class", "TDNotSelected");
            tdLogoDetails.Attributes.Add("class", "TDSelected");
        }
    }
}
