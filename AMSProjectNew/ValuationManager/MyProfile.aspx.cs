using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;

namespace AMSProjectNew.ValuationManager
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
                    FillClientDetails();
                }
            }
        }

        private void FillClientDetails()
        {
            ValuationManagerController valuationManagerController = new ValuationManagerController();
            DataSet ds = new DataSet();
            try
            {
                ds = valuationManagerController.ValuationManagerSelectAll(Convert.ToInt64(Session["UserId"]), 0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    rdStatus.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Status"]);
                    txtUsername.Text = Convert.ToString(ds.Tables[0].Rows[0]["Username"]);
                    txtPassword.Text = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
                    trConfirmPassword.Visible = false;
                    txtPassword.Visible = false;
                    lblPassword.Visible = true;

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
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                valuationManagerController = null;
                ds = null;
            }
        }

       
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ValuationManagerController valuationManagerController = new ValuationManagerController();
            UsersController usersController = new UsersController();
            DataSet ds = new DataSet();
            try
            {
                Int64 Id = valuationManagerController.ValuationManagerEdit(Convert.ToInt64(Session["UserId"]),
                        Convert.ToInt64(Session["UserId"]), txtEmailAddress.Text.Trim(),
                        txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress.Text.Trim(),
                        txtSuburb.Text.Trim(), txtState.Text.Trim(), txtPostcode.Text.Trim(), txtPhone1.Text.Trim(),
                        txtPhone2.Text.Trim(), txtOtherDetails.Text.Trim(), txtFax.Text.Trim(),
                        Convert.ToInt64(Session["UserId"]), Convert.ToInt64(Session["UserId"]),
                        Convert.ToInt64(rdStatus.SelectedValue), "EDITBYADMIN");

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
                valuationManagerController = null;
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
    }
}
