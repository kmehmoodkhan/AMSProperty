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
    public partial class ManageClientsBranchManagerBranchManagerEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCheckAvailabilty.Text = "";
            lblError.Text = "";
            if (!IsPostBack)
            {
                FillClients();
                if (Request.QueryString["Id"] != null && Convert.ToString(Request.QueryString["Id"]) != "")
                {
                    FillClientDetails();
                }
            }
        }
        private void FillClients()
        {
            ClientsController clientsController = new ClientsController();
            DataSet ds = new DataSet();
            try
            {
                ds = clientsController.ClientsSelectAll(0,"", 0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    ddlClient.DataSource = ds.Tables[0].DefaultView;
                    ddlClient.DataTextField = "CompanyName";
                    ddlClient.DataValueField = "Id";
                    ddlClient.DataBind();
                }
                ddlClient.Items.Insert(0, new ListItem("Select Client", "0"));
                ddlClient.SelectedValue = "0";
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
        private void FillClientDetails()
        {
            ClientsBranchManagerController clientsBranchManagerController = new ClientsBranchManagerController();
            DataSet ds = new DataSet();
            try
            {
                ds = clientsBranchManagerController.ClientsBranchManagerSelectAll(Convert.ToInt64(Request.QueryString["Id"]),0, 0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlClient.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ClientId"]);
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
                clientsBranchManagerController = null;
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
                Id = usersController.UsersLoginCreate(txtUsername.Text.Trim(), txtPassword.Text.Trim(), "ClientsBranchManager", "CHECKUSERNAME");
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
            Response.Redirect("~/Admin/ManageClientsBranchManager.aspx", false);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ClientsBranchManagerController clientsBranchManagerController = new ClientsBranchManagerController();
            DataSet ds = new DataSet();
            try
            {                
                Int64 Id = 0;
                if (Request.QueryString["Id"] != null && Convert.ToString(Request.QueryString["Id"]) != "")
                {
                    Id = Convert.ToInt64(Request.QueryString["Id"]);
                    Id = clientsBranchManagerController.ClientsBranchManagerEdit(Id, Id,Convert.ToInt64(ddlClient.SelectedValue), txtEmailAddress.Text.Trim(),
                        txtFirstName.Text.Trim(), txtLastName.Text.Trim(), "", txtAddress.Text.Trim(),
                        txtSuburb.Text.Trim(), txtState.Text.Trim(), txtPostcode.Text.Trim(), txtPhone1.Text.Trim(),
                        txtPhone2.Text.Trim(), txtOtherDetails.Text.Trim(), txtFax.Text.Trim(),
                        Convert.ToInt64(Session["UserId"]), Convert.ToInt64(Session["UserId"]),
                        Convert.ToInt64(rdStatus.SelectedValue), "EDITBYADMIN");

                    if (Id > 0)
                    {
                        Response.Redirect("~/Admin/ManageClientsBranchManager.aspx", false);
                    }
                    else
                    {
                        lblError.Text = "Clients branch manager details does not submitted successfully. Please try again later!";
                        return;
                    }
                }
                else
                {
                    Id = CreateLogin();
                    if (Id > 0)
                    {
                        Id = clientsBranchManagerController.ClientsBranchManagerEdit(0, Id, Convert.ToInt64(ddlClient.SelectedValue), txtEmailAddress.Text.Trim(),
                            txtFirstName.Text.Trim(), txtLastName.Text.Trim(), "", txtAddress.Text.Trim(),
                            txtSuburb.Text.Trim(), txtState.Text.Trim(), txtPostcode.Text.Trim(), txtPhone1.Text.Trim(),
                            txtPhone2.Text.Trim(), txtOtherDetails.Text.Trim(), txtFax.Text.Trim(), 
                            Convert.ToInt64(Session["UserId"]), Convert.ToInt64(Session["UserId"]), 
                            Convert.ToInt64(rdStatus.SelectedValue),"ADD");
                        if (Id > 0)
                        {
                            Response.Redirect("~/Admin/ManageClientsBranchManager.aspx", false);
                        }
                        else
                        {
                            lblError.Text = "Clients branch manager details does not submitted successfully. Please try again later!";
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
                        lblError.Text = "Clients branch manager details does not submitted successfully. Please try again later!";
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
                clientsBranchManagerController = null;
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
                    Id = usersController.UsersLoginCreate(txtUsername.Text.Trim(), txtPassword.Text.Trim(), "ClientsBranchManager", "CREATE");
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
