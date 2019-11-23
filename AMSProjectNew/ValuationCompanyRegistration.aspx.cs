using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.IO;

namespace AMSProjectNew
{
    public partial class ValuationCompanyRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCheckAvailabilty.Text = "";
            lblError.Text = "";
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
            Response.Redirect("~/Login.aspx", false);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string strCompanyLogo = DateTime.Now.ToString("MMddyyyyhhmmss");

            ValuationCompanyController valuationCompanyController = new ValuationCompanyController();
            DataSet ds = new DataSet();
            UsersController usersController = new UsersController();
            try
            {
                if (fuLogo.FileName.ToString() != "")
                    strCompanyLogo = strCompanyLogo + fuLogo.FileName;

                Int64 Id = CreateLogin();
                if (Id > 0)
                {
                    string PdfFileName = Id.ToString() + "" + DateTime.Now.ToString("MMddyyyyhhssmm") + ".pdf";

                    Id = valuationCompanyController.ValuationCompanyEdit(0, Id, txtEmailAddress.Text.Trim(),
                        txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtCompanyName.Text.Trim(), txtAddress.Text.Trim(),
                        txtSuburb.Text.Trim(), ddlState.SelectedValue, txtPostcode.Text.Trim(), txtPhone1.Text.Trim(),
                        txtPhone2.Text.Trim(), txtOtherDetails.Text.Trim(), txtFax.Text.Trim(),
                        Convert.ToInt64(Session["UserId"]), Convert.ToInt64(Session["UserId"]),
                        1, PdfFileName, Convert.ToDateTime(txtStartDate.Text.Trim()),
                        Convert.ToDateTime(txtEndDate.Text.Trim()), "ADD", false, strCompanyLogo, txtBankName.Text.Trim(),
                        txtBSB.Text.Trim(), txtACNumber.Text.Trim(), txtABN.Text.Trim(), txtUrl.Text.Trim());
                    if (Id > 0)
                    {
                        fileUploadInsurance.SaveAs(Server.MapPath("~/InsurancePolicy/") + fileUploadInsurance.FileName.ToString());
                        File.Move(Server.MapPath("~/InsurancePolicy/") + fileUploadInsurance.FileName.ToString(), Server.MapPath("~/InsurancePolicy/") + PdfFileName);
                                                
                        fuLogo.SaveAs(Server.MapPath("~/CompanyLogo/" + fuLogo.FileName));
                        File.Move(Server.MapPath("~/CompanyLogo/" + fuLogo.FileName), Server.MapPath("~/CompanyLogo/" + strCompanyLogo));

                        Response.Redirect("~/MessageDisplay.aspx?From=CompanyRegistrationSuccess", false);
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
    }
}
