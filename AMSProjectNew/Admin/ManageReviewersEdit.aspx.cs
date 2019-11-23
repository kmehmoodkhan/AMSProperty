﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;

namespace AMSProjectNew.Admin
{
    public partial class ManageReviewersEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCheckAvailabilty.Text = "";
            lblError.Text = "";
            if (!IsPostBack)
            {
                FillValuationCompany();
                if (Request.QueryString["Id"] != null && Convert.ToString(Request.QueryString["Id"]) != "")
                {
                    FillReviewersDetails();
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
                    ddlCompany.DataValueField = "UserId";
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
        private void FillReviewersDetails()
        {
            ReviewersController reviewersController = new ReviewersController();
            DataSet ds = new DataSet();
            try
            {
                ds = reviewersController.ReviewersSelectAll(Convert.ToInt64(Request.QueryString["Id"]), 0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    btnCheckAvailabilty.Visible = false;
                    ddlCompany.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyId"]);
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
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                reviewersController = null;
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
                Id = usersController.UsersLoginCreate(txtUsername.Text.Trim(), txtPassword.Text.Trim(), "Reviewers", "CHECKUSERNAME");
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
            Response.Redirect("~/Admin/ManageReviewers.aspx", false);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ReviewersController reviewersController = new ReviewersController();
            DataSet ds = new DataSet();
            UsersController usersController = new UsersController();
            try
            {
                Int64 Id = 0;
                if (Request.QueryString["Id"] != null && Convert.ToString(Request.QueryString["Id"]) != "")
                {
                    Id = Convert.ToInt64(Request.QueryString["Id"]);
                    Id = reviewersController.ReviewersEdit(Id, Id, Convert.ToInt64(ddlCompany.SelectedValue), txtEmailAddress.Text.Trim(),
                        txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress.Text.Trim(),
                        txtSuburb.Text.Trim(), ddlState.SelectedValue, txtPostcode.Text.Trim(), txtPhone1.Text.Trim(),
                        txtPhone2.Text.Trim(), txtOtherDetails.Text.Trim(), txtFax.Text.Trim(),
                        Convert.ToInt64(Session["UserId"]), Convert.ToInt64(Session["UserId"]),
                        Convert.ToInt64(rdStatus.SelectedValue), "EDITBYADMIN");

                    if (Id > 0)
                    {
                        Response.Redirect("~/Admin/ManageReviewers.aspx", false);
                    }
                    else
                    {
                        lblError.Text = "Reviewers details does not submitted successfully. Please try again later!";
                        return;
                    }
                }
                else
                {
                    Id = CreateLogin();
                    if (Id > 0)
                    {
                        Id = reviewersController.ReviewersEdit(0, Id, Convert.ToInt64(ddlCompany.SelectedValue), txtEmailAddress.Text.Trim(),
                            txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress.Text.Trim(),
                            txtSuburb.Text.Trim(), ddlState.SelectedValue, txtPostcode.Text.Trim(), txtPhone1.Text.Trim(),
                            txtPhone2.Text.Trim(), txtOtherDetails.Text.Trim(), txtFax.Text.Trim(),
                            Convert.ToInt64(Session["UserId"]), Convert.ToInt64(Session["UserId"]),
                            Convert.ToInt64(rdStatus.SelectedValue), "ADD");
                        if (Id > 0)
                        {
                            Response.Redirect("~/Admin/ManageReviewers.aspx", false);
                        }
                        else
                        {
                            lblError.Text = "Reviewers details does not submitted successfully. Please try again later!";
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
                        lblError.Text = "Reviewers details does not submitted successfully. Please try again later!";
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
                reviewersController = null;
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
                    Id = usersController.UsersLoginCreate(txtUsername.Text.Trim(), txtPassword.Text.Trim(), "Reviewers", "CREATE");
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
