using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;

namespace AMSProjectNew.ValuationCompany
{
    public partial class ManageValuersEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCheckAvailabilty.Text = "";
            lblError.Text = "";
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null && Convert.ToString(Request.QueryString["Id"]) != "")
                {
                    FillValuerDetails();
                }
            }
        }

        private void FillValuerDetails()
        {
            ValuersController valuersController = new ValuersController();
            DataSet ds = new DataSet();
            try
            {
                ds = valuersController.ValuersSelectAll(Convert.ToInt64(Request.QueryString["Id"]), Convert.ToInt64(Session["UserId"]),0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    btnCheckAvailabilty.Visible = false;
                    rdStatus.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Status"]);
                    txtUsername.Text = Convert.ToString(ds.Tables[0].Rows[0]["Username"]);
                    txtUsername.Enabled = false;
                    txtPassword.Text = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
                    txtPassword.Enabled = false;
                    txtEmailAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                    txtFirstName.Text = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
                    txtLastName.Text = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
                    txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
                    txtSuburb.Text = Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]);
                    txtPostcode.Text = Convert.ToString(ds.Tables[0].Rows[0]["Postcode"]);
                    ddlState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["State"]);
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

        protected void btnCheckAvailabilty_Click(object sender, EventArgs e)
        {
            Int64 Id = -1;
            UsersController usersController = new UsersController();
            DataSet ds = new DataSet();
            try
            {
                Id = usersController.UsersLoginCreate(txtUsername.Text.Trim(), txtPassword.Text.Trim(), "Valuers", "CHECKUSERNAME");
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
            Response.Redirect("ManageValuers.aspx", false);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ValuersController valuersController = new ValuersController();
            DataSet ds = new DataSet();
            try
            {                
                Int64 Id = 0;
                if (Request.QueryString["Id"] != null && Convert.ToString(Request.QueryString["Id"]) != "")
                {
                    Id = Convert.ToInt64(Request.QueryString["Id"]);
                    Id = valuersController.ValuersEdit(Id, Id, "", txtEmailAddress.Text.Trim(),
                        txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress.Text.Trim(),
                        txtSuburb.Text.Trim(), ddlState.SelectedValue, txtPostcode.Text.Trim(), txtPhone1.Text.Trim(),
                        txtPhone2.Text.Trim(), txtOtherDetails.Text.Trim(), txtFax.Text.Trim(), 
                        Convert.ToInt64(Session["UserId"]), Convert.ToInt64(Session["UserId"]),
                        Convert.ToInt64(rdStatus.SelectedValue), "EDITBYADMIN", Convert.ToInt64(Session["UserId"]),
                        txtTitle.Text.Trim(),txtQualifications.Text.Trim(),txtExperience.Text.Trim(),
                        txtMembershipStatus.Text.Trim(),txtMembershipBody.Text.Trim());

                    if (Id > 0)
                    {
                        Response.Redirect("ManageValuers.aspx", false);
                    }
                    else
                    {
                        lblError.Text = "Valuer details does not submitted successfully. Please try again later!";
                        return;
                    }
                }
                else
                {
                    Id = CreateLogin();
                    if (Id > 0)
                    {
                        Id = valuersController.ValuersEdit(0, Id, "", txtEmailAddress.Text.Trim(),
                        txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress.Text.Trim(),
                        txtSuburb.Text.Trim(), ddlState.SelectedValue, txtPostcode.Text.Trim(), txtPhone1.Text.Trim(),
                        txtPhone2.Text.Trim(), txtOtherDetails.Text.Trim(), txtFax.Text.Trim(), 
                        Convert.ToInt64(Session["UserId"]), Convert.ToInt64(Session["UserId"]),
                        Convert.ToInt64(rdStatus.SelectedValue), "ADD", Convert.ToInt64(Session["UserId"]),
                         txtTitle.Text.Trim(), txtQualifications.Text.Trim(), txtExperience.Text.Trim(),
                        txtMembershipStatus.Text.Trim(), txtMembershipBody.Text.Trim());
                        if (Id > 0)
                        {
                            Response.Redirect("ManageValuers.aspx", false);
                        }
                        else
                        {
                            lblError.Text = "Valuer details does not submitted successfully. Please try again later!";
                            return;
                        }
                    }
                    else if (Id == -1)
                    {
                        lblError.Text = "Username is already taken. Please choose different Username!";
                        return;
                    }
                    else 
                    {
                        lblError.Text = "Valuer details does not submitted successfully. Please try again later!";
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
                valuersController = null;
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
                    Id = usersController.UsersLoginCreate(txtUsername.Text.Trim(), txtPassword.Text.Trim(), "Valuers", "CREATE");
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
