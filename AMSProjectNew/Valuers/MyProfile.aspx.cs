using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.IO;

namespace AMSProjectNew.Valuers
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            lblError.Text = "";
            if (!IsPostBack)
            {
                FillValuationCompany();
                if (Session["UserId"] != null && Convert.ToString(Session["UserId"]) != "")
                {
                    FillValuerDetails();

                    tdAccountDetails.Attributes.Add("class", "TDSelected");
                    tdLogoDetails.Attributes.Add("class", "TDNotSelected");

                    tblAccountDetails.Visible = true;
                    tblLogoDetails.Visible = false;
                }
            }
        }
        private void FillValuationCompany()
        {
            ValuationCompanyController valuationCompanyController = new ValuationCompanyController();
            DataSet ds = new DataSet();
            try
            {
                ds = valuationCompanyController.ValuationCompanySelectAll(0, 0, 2);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    ddlCompany.DataSource = ds.Tables[0].DefaultView;
                    ddlCompany.DataTextField = "CompanyName";
                    ddlCompany.DataValueField = "Id";
                    ddlCompany.DataBind();
                }
                ddlCompany.Items.Insert(0, new ListItem("Select Company", "0"));
                ddlCompany.SelectedValue = "0";
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
        private void FillValuerDetails()
        {
            ValuersController valuersController = new ValuersController();
            DataSet ds = new DataSet();
            try
            {
                ds = valuersController.ValuersSelectAll(Convert.ToInt64(Session["UserId"]), 0, 0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {                    
                    rdStatus.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Status"]);
                    txtUsername.Text = Convert.ToString(ds.Tables[0].Rows[0]["Username"]);
                    txtPassword.Text = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
                    trConfirmPassword.Visible = false;
                    txtPassword.Visible = false;
                    lblPassword.Visible = true;

                    ddlCompany.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyId"]);
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

                    txtTitle.Text = Convert.ToString(ds.Tables[0].Rows[0]["Title"]);
                    txtQualifications.Text = Convert.ToString(ds.Tables[0].Rows[0]["Qualifications"]);
                    txtExperience.Text = Convert.ToString(ds.Tables[0].Rows[0]["Experience"]);
                    txtMembershipStatus.Text = Convert.ToString(ds.Tables[0].Rows[0]["MembershipStatus"]);
                    txtMembershipBody.Text = Convert.ToString(ds.Tables[0].Rows[0]["MembershipBody"]);

                    lblValuerLogo.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuerLogo"]);
                    imgLogo.Visible = false;
                    if (File.Exists(Server.MapPath("~/ValuerLogo/" + lblValuerLogo.Text)))
                    {
                        imgLogo.ImageUrl = "~/ValuerLogo/" + lblValuerLogo.Text;
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
                valuersController = null;
                ds = null;
            }
        }
               
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ValuersController valuersController = new ValuersController();
            UsersController usersController = new UsersController();
            DataSet ds = new DataSet();
            try
            {                
                Int64 Id = valuersController.ValuersEdit(Convert.ToInt64(Session["UserId"]), Convert.ToInt64(Session["UserId"]), "", txtEmailAddress.Text.Trim(),
                    txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress.Text.Trim(),
                    txtSuburb.Text.Trim(), txtState.Text.Trim(), txtPostcode.Text.Trim(), txtPhone1.Text.Trim(),
                    txtPhone2.Text.Trim(), txtOtherDetails.Text.Trim(), txtFax.Text.Trim(),
                    Convert.ToInt64(Session["UserId"]), Convert.ToInt64(Session["UserId"]),
                    Convert.ToInt64(rdStatus.SelectedValue), "EDITBYADMIN", Convert.ToInt64(ddlCompany.SelectedValue),
                     txtTitle.Text.Trim(), txtQualifications.Text.Trim(), txtExperience.Text.Trim(),
                        txtMembershipStatus.Text.Trim(), txtMembershipBody.Text.Trim());

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
                valuersController = null;
                usersController = null;
                ds = null;
            }
        }
        protected void btnImageUpload_Click(object sender, EventArgs e)
        {
            ValuersController valuersController = new ValuersController();
            UsersController usersController = new UsersController();
            DataSet ds = new DataSet();
            try
            {
                string strValuerLogo = DateTime.Now.ToString("MMddyyyyhhmmss");
                if (fuLogo.FileName.ToString() != "")
                    strValuerLogo = strValuerLogo + fuLogo.FileName;

                Int64 Id = valuersController.ValuersLogoEdit(Convert.ToInt64(Request.QueryString["Id"]),
                    Convert.ToInt64(Request.QueryString["Id"]), strValuerLogo);

                if (Id > 0)
                {
                    fuLogo.SaveAs(Server.MapPath("~/ValuerLogo/" + fuLogo.FileName));
                    File.Move(Server.MapPath("~/ValuerLogo/" + fuLogo.FileName), Server.MapPath("~/ValuerLogo/" + strValuerLogo));
                    imgLogo.ImageUrl = "~/ValuerLogo/" + strValuerLogo;
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
                valuersController = null;
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
        protected void lbtnAccountDetails_Click(object sender, EventArgs e)
        {

            tblLogoDetails.Visible = false;
            tblAccountDetails.Visible = true;
            tdAccountDetails.Attributes.Add("class", "TDSelected");
            tdLogoDetails.Attributes.Add("class", "TDNotSelected");

        }
        protected void lbtnLogoDetails_Click(object sender, EventArgs e)
        {
            tblLogoDetails.Visible = true;
            tblAccountDetails.Visible = false;
            tdAccountDetails.Attributes.Add("class", "TDNotSelected");
            tdLogoDetails.Attributes.Add("class", "TDSelected");
        }
    }   
}
