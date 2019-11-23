using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.IO;

namespace AMSProjectNew.Admin
{
    public partial class ManageValuationCompanyEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCheckAvailabilty.Text = "";
            lblError.Text = "";
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null && Convert.ToString(Request.QueryString["Id"]) != "")
                {
                    FillValuationCompanyDetails();

                    tdProfileDetails.Attributes.Add("class", "TDSelected");
                    tdAccountDetails.Attributes.Add("class", "TDNotSelected");
                    tdLogoDetails.Attributes.Add("class", "TDNotSelected");
                    tdOtherDetails.Attributes.Add("class", "TDNotSelected");
                    tdHF.Attributes.Add("class", "TDNotSelected");

                    tblAccountDetails.Visible = false;
                    tblLogoDetails.Visible = false;
                    tblOtherDetails.Visible = false;
                    tblHF.Visible = false;
                }
            }
        }

        private void FillValuationCompanyDetails()
        {
            ValuationCompanyController valuationCompanyController = new ValuationCompanyController();
            DataSet ds = new DataSet();
            try
            {
                ds = valuationCompanyController.ValuationCompanySelectAll(Convert.ToInt64(Request.QueryString["Id"]), 0,0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    btnCheckAvailabilty.Visible = false;
                    rdStatus.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Status"]);
                    txtUsername.Text = Convert.ToString(ds.Tables[0].Rows[0]["Username"]);
                    txtUsername.Enabled = false;
                    txtPassword.Text = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
                    txtPassword.Enabled = false;
                    txtCompanyName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]);
                    txtStartDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["StartDate"]).ToString("MM/dd/yyyy");
                    txtEndDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["EndDate"]).ToString("MM/dd/yyyy");
                    txtEmailAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                    txtFirstName.Text = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
                    txtLastName.Text = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
                    txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
                    txtSuburb.Text = Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]);
                    txtPostcode.Text = Convert.ToString(ds.Tables[0].Rows[0]["Postcode"]);
                    ddlState.SelectedValue= Convert.ToString(ds.Tables[0].Rows[0]["State"]);
                    txtPhone1.Text = Convert.ToString(ds.Tables[0].Rows[0]["Phone1"]);
                    txtPhone2.Text = Convert.ToString(ds.Tables[0].Rows[0]["Phone2"]);
                    txtFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["Fax"]);
                    
                    rdAllowJobCreate.SelectedValue = "False";
                    if (Convert.ToString(ds.Tables[0].Rows[0]["AllowJobCreate"])!="" && Convert.ToBoolean(ds.Tables[0].Rows[0]["AllowJobCreate"]) == true)
                        rdAllowJobCreate.SelectedValue = "True";

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
                    txtABN.Text = Convert.ToString(ds.Tables[0].Rows[0]["BSB"]);

                    lblCompanyLogo.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyLogo"]);
                    imgLogo.Visible = false;
                    if (File.Exists(Server.MapPath("~/CompanyLogo/" + lblCompanyLogo.Text)))
                    {
                        imgLogo.ImageUrl = "~/CompanyLogo/" + lblCompanyLogo.Text;
                        imgLogo.Visible = true;
                    }

                    lblOldHeaderImage.Text = Convert.ToString(ds.Tables[0].Rows[0]["HeaderImage"]);
                    imgOldHeaderImage.Visible = false;
                    if (File.Exists(Server.MapPath("~/CompanyLogo/" + lblOldHeaderImage.Text)))
                    {
                        imgOldHeaderImage.ImageUrl = "~/CompanyLogo/" + lblOldHeaderImage.Text;
                        imgOldHeaderImage.Visible = true;
                    }

                    lblOldFooterImage.Text = Convert.ToString(ds.Tables[0].Rows[0]["FooterImage"]);
                    imgOldFooterImage.Visible = false;
                    if (File.Exists(Server.MapPath("~/CompanyLogo/" + lblOldFooterImage.Text)))
                    {
                        imgOldFooterImage.ImageUrl = "~/CompanyLogo/" + lblOldFooterImage.Text;
                        imgOldFooterImage.Visible = true;
                    }

                    txtTermsandCondition.Text = Convert.ToString(ds.Tables[0].Rows[0]["TermsandCondition"]);
                    txtCertificationQualification.Text = Convert.ToString(ds.Tables[0].Rows[0]["CertificationQualification"]);
                    txtFamilyLawCertification.Text = Convert.ToString(ds.Tables[0].Rows[0]["FamilyLawCertification"]);
                    txtUrl.Text = Convert.ToString(ds.Tables[0].Rows[0]["URL"]);
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

        protected void btnCheckAvailabilty_Click(object sender, EventArgs e)
        {
            Int64 Id = -1;
            UsersController usersController = new UsersController();
            DataSet ds = new DataSet();
            try
            {
                Id = usersController.UsersLoginCreate(txtUsername.Text.Trim(), txtPassword.Text.Trim(), "ValuationCompany", "CHECKUSERNAME");
                if (Id > 0)
                {
                    lblCheckAvailabilty.Text = "Available!";
                    return;
                }
                else
                {
                    lblCheckAvailabilty.Text = "Not available.";
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                usersController = null;
                ds = null;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ManageValuationCompany.aspx", false);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ValuationCompanyController valuationCompanyController = new ValuationCompanyController();
            DataSet ds = new DataSet();
            UsersController usersController = new UsersController();
            try
            {                
                Int64 Id = 0;
                if (Request.QueryString["Id"] != null && Convert.ToString(Request.QueryString["Id"]) != "")
                {
                    Id = Convert.ToInt64(Request.QueryString["Id"]);
                    Id = valuationCompanyController.ValuationCompanyEdit(Id, Id, txtEmailAddress.Text.Trim(),
                            txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtCompanyName.Text.Trim(), txtAddress.Text.Trim(),
                            txtSuburb.Text.Trim(), ddlState.SelectedValue, txtPostcode.Text.Trim(), txtPhone1.Text.Trim(),
                            txtPhone2.Text.Trim(), txtOtherDetails.Text.Trim(), txtFax.Text.Trim(),
                            Convert.ToInt64(Session["UserId"]), Convert.ToInt64(Session["UserId"]),
                            Convert.ToInt64(rdStatus.SelectedValue), lblPdfFileName.Text.Trim(),
                            Convert.ToDateTime(txtStartDate.Text.Trim()), Convert.ToDateTime(txtEndDate.Text.Trim()),
                            "EDITBYADMIN", Convert.ToBoolean(rdAllowJobCreate.SelectedValue), lblCompanyLogo.Text.Trim(),
                            txtBankName.Text.Trim(), txtBSB.Text.Trim(), txtACNumber.Text.Trim(), txtABN.Text.Trim(), txtUrl.Text.Trim());

                    if (Id > 0)
                    {
                        Response.Redirect("~/Admin/ManageValuationCompany.aspx", false);
                    }
                    else
                    {
                        lblError.Text = "ValuationCompany details does not submitted successfully. Please try again later!";
                        return;
                    }
                }
                else
                {
                    Id = CreateLogin();
                    if (Id > 0)
                    {
                        Id = valuationCompanyController.ValuationCompanyEdit(0, Id, txtEmailAddress.Text.Trim(),
                            txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtCompanyName.Text.Trim(), txtAddress.Text.Trim(),
                            txtSuburb.Text.Trim(), ddlState.SelectedValue, txtPostcode.Text.Trim(), txtPhone1.Text.Trim(),
                            txtPhone2.Text.Trim(), txtOtherDetails.Text.Trim(), txtFax.Text.Trim(), 
                            Convert.ToInt64(Session["UserId"]), Convert.ToInt64(Session["UserId"]), 
                            Convert.ToInt64(rdStatus.SelectedValue),lblPdfFileName.Text.Trim(),
                            Convert.ToDateTime(txtStartDate.Text.Trim()),Convert.ToDateTime(txtEndDate.Text.Trim()),"ADD",
                            Convert.ToBoolean(rdAllowJobCreate.SelectedValue), lblCompanyLogo.Text.Trim(),
                            txtBankName.Text.Trim(), txtBSB.Text.Trim(), txtACNumber.Text.Trim(), txtABN.Text.Trim(), txtUrl.Text.Trim());
                        if (Id > 0)
                        {
                            Response.Redirect("~/Admin/ManageValuationCompany.aspx", false);
                        }
                        else
                        {
                            lblError.Text = "Valuation company details does not submitted successfully. Please try again later!";
                            return;
                        }
                    }
                    else if (Id == -1)
                    {
                        usersController.UsersLogin(txtUsername.Text.Trim(), "", "DELETE");
                        lblError.Text = "Username is already taken. Please choose different Username!";
                        return;
                    }
                    else
                    {
                        usersController.UsersLogin(txtUsername.Text.Trim(), "", "DELETE");
                        lblError.Text = "Valuation company details does not submitted successfully. Please try again later!";
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                usersController = null;
                valuationCompanyController = null;
                ds = null;
            }
        }

        private long CreateLogin()
        {
            Int64 Id = -1;
            UsersController usersController = new UsersController();
            DataSet ds = new DataSet();
            try
            {                
                if (Request.QueryString["Id"] != null && Convert.ToString(Request.QueryString["Id"]) != "")
                {
                    Id = Convert.ToInt64(Request.QueryString["Id"]);
                }
                else
                {
                    Id = usersController.UsersLoginCreate(txtUsername.Text.Trim(), txtPassword.Text.Trim(), "ValuationCompany", "CREATE");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                usersController = null;
                ds = null;
            }
            return Id;
        }
        protected void btnAccountSubmit_Click(object sender, EventArgs e)
        {
            ValuationCompanyController valuationCompanyController = new ValuationCompanyController();
            UsersController usersController = new UsersController();
            DataSet ds = new DataSet();
            try
            {

                Int64 Id = valuationCompanyController.ValuationCompanyBankAndLogoEdit(Convert.ToInt64(Request.QueryString["Id"]),
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

                Int64 Id = valuationCompanyController.ValuationCompanyBankAndLogoEdit(Convert.ToInt64(Request.QueryString["Id"]),
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

        protected void btnHeaderUpload_Click(object sender, EventArgs e)
        {
            ValuationCompanyController valuationCompanyController = new ValuationCompanyController();
            UsersController usersController = new UsersController();
            DataSet ds = new DataSet();
            try
            {
                string strHeaderImage= DateTime.Now.ToString("MMddyyyyhhmmss");
                if (fuHeaderImage.FileName.ToString() != "")
                    strHeaderImage = strHeaderImage + fuHeaderImage.FileName;

                Int64 Id = valuationCompanyController.ValuationCompanyHFImageEdit(Convert.ToInt64(Request.QueryString["Id"]),
                             strHeaderImage, lblOldFooterImage.Text.Trim());

                if (Id > 0)
                {
                    fuHeaderImage.SaveAs(Server.MapPath("~/CompanyLogo/" + fuHeaderImage.FileName));
                    File.Move(Server.MapPath("~/CompanyLogo/" + fuHeaderImage.FileName), Server.MapPath("~/CompanyLogo/" + strHeaderImage));
                    imgOldHeaderImage.ImageUrl = "~/CompanyLogo/" + strHeaderImage;
                    imgOldHeaderImage.Visible = true;
                    lblOldHeaderImage.Text = strHeaderImage;
                    lblError.Text = "Your header image updated successfully.";
                    return;
                }
                else
                {
                    lblError.Text = "Your header image does not updated successfully. Please try again later!";
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

        protected void btnFooterUpload_Click(object sender, EventArgs e)
        {
            ValuationCompanyController valuationCompanyController = new ValuationCompanyController();
            UsersController usersController = new UsersController();
            DataSet ds = new DataSet();
            try
            {
                string strFooterImage = DateTime.Now.ToString("MMddyyyyhhmmss");
                if (fuFooterImage.FileName.ToString() != "")
                    strFooterImage = strFooterImage + fuFooterImage.FileName;

                Int64 Id = valuationCompanyController.ValuationCompanyHFImageEdit(Convert.ToInt64(Request.QueryString["Id"]),
                             lblOldHeaderImage.Text.Trim(), strFooterImage);

                if (Id > 0)
                {
                    fuFooterImage.SaveAs(Server.MapPath("~/CompanyLogo/" + fuFooterImage.FileName));
                    File.Move(Server.MapPath("~/CompanyLogo/" + fuFooterImage.FileName), Server.MapPath("~/CompanyLogo/" + strFooterImage));
                    imgOldFooterImage.ImageUrl = "~/CompanyLogo/" + strFooterImage;
                    imgOldFooterImage.Visible = true;
                    lblOldFooterImage.Text = strFooterImage;
                    lblError.Text = "Your footer image updated successfully.";
                    return;
                }
                else
                {
                    lblError.Text = "Your footer image does not updated successfully. Please try again later!";
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
        
        protected void btnSubmitOtherDetails_Click(object sender, EventArgs e)
        {
            ValuationCompanyController valuationCompanyController = new ValuationCompanyController();
            UsersController usersController = new UsersController();
            DataSet ds = new DataSet();
            try
            {

                Int64 Id = valuationCompanyController.ValuationCompanyOtherEdit(0,Convert.ToInt64(Request.QueryString["Id"]),
                            txtTermsandCondition.Text.Trim(),txtCertificationQualification.Text.Trim(),
                            txtFamilyLawCertification.Text.Trim());

                if (Id > 0)
                {
                    lblError.Text = "Your details updated successfully.";
                    return;
                }
                else
                {
                    lblError.Text = "Your details does not updated successfully. Please try again later!";
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




        protected void lbtnProfileDetails_Click(object sender, EventArgs e)
        {
            tblProfileDetails.Visible = true;
            tblLogoDetails.Visible = false;
            tblAccountDetails.Visible = false;
            tblOtherDetails.Visible = false;
            tblHF.Visible = false;
            tdHF.Attributes.Add("class", "TDNotSelected");
            tdProfileDetails.Attributes.Add("class", "TDSelected");
            tdAccountDetails.Attributes.Add("class", "TDNotSelected");
            tdLogoDetails.Attributes.Add("class", "TDNotSelected");
            tdOtherDetails.Attributes.Add("class", "TDNotSelected");
        }
        protected void lbtnAccountDetails_Click(object sender, EventArgs e)
        {
            tblProfileDetails.Visible = false;
            tblLogoDetails.Visible = false;
            tblAccountDetails.Visible = true;
            tblOtherDetails.Visible = false;
            tblHF.Visible = false;
            tdHF.Attributes.Add("class", "TDNotSelected");
            tdProfileDetails.Attributes.Add("class", "TDNotSelected");
            tdAccountDetails.Attributes.Add("class", "TDSelected");
            tdLogoDetails.Attributes.Add("class", "TDNotSelected"); tdOtherDetails.Attributes.Add("class", "TDNotSelected");
        }
        protected void lbtnLogoDetails_Click(object sender, EventArgs e)
        {
            tblProfileDetails.Visible = false;
            tblLogoDetails.Visible = true;
            tblAccountDetails.Visible = false;
            tblOtherDetails.Visible = false;
            tblHF.Visible = false;
            tdHF.Attributes.Add("class", "TDNotSelected");
            tdProfileDetails.Attributes.Add("class", "TDNotSelected");
            tdAccountDetails.Attributes.Add("class", "TDNotSelected");
            tdLogoDetails.Attributes.Add("class", "TDSelected");
            tdOtherDetails.Attributes.Add("class", "TDNotSelected");
        }
        protected void lbtnHFDetails_Click(object sender, EventArgs e)
        {
            tblProfileDetails.Visible = false;
            tblLogoDetails.Visible = false;
            tblHF.Visible = true;
            tblAccountDetails.Visible = false;
            tblOtherDetails.Visible = false;
            tdProfileDetails.Attributes.Add("class", "TDNotSelected");
            tdAccountDetails.Attributes.Add("class", "TDNotSelected");
            tdHF.Attributes.Add("class", "TDSelected");
            tdLogoDetails.Attributes.Add("class", "TDNotSelected");
            tdOtherDetails.Attributes.Add("class", "TDNotSelected");
        }
        protected void lbtnOtherDetails_Click(object sender, EventArgs e)
        {
            tblProfileDetails.Visible = false;
            tblLogoDetails.Visible = false;
            tblOtherDetails.Visible = true;
            tblAccountDetails.Visible = false;
            tdProfileDetails.Attributes.Add("class", "TDNotSelected");
            tdAccountDetails.Attributes.Add("class", "TDNotSelected");
            tdLogoDetails.Attributes.Add("class", "TDNotSelected");
            tdOtherDetails.Attributes.Add("class", "TDSelected");
        }
    }
}
