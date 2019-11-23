﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;

namespace AMSProjectNew.Clients
{
    public partial class JobOrderCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillAccessArangementsType();
                FillServiceType();
                FillValuationType();
                FillPropertyType();
                FillPurpose();
                FillTransactionType();
                FillUrgency();
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
                string ContractPrice = txtContractPrice.Text;

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

                string EstimatedPrice = txtEstimatedPrice.Text;
                string ValuationInstruction = "";
                string PropertyReport = "";
                string Overlays = "";
                string Title = "";

                Int64 RetVal = objJobsController.JobsEdit(0, Convert.ToInt64(Session["UserId"]), Convert.ToInt64(Session["UserId"]), 0, 0, txtLoanReference.Text.Trim(), txtCustomerFullName.Text.Trim(), txtCustomerPhoneNumber.Text.Trim(),
                    txtCustomerMobileNumber.Text.Trim(), txtCustomerAdditionalPhoneNumber.Text.Trim(), Convert.ToInt64(ddlAccessArangementsType.SelectedValue), txtNameOfPersonToContactForAccess.Text.Trim(),
                    txtPhoneNumber.Text.Trim(), txtMobilePhoneNumber.Text.Trim(), txtAdditionalPhoneNumber.Text.Trim(), txtAdditionalNotes.Text.Trim(), txtUnitLot.Text.Trim(), txtStreetNumber.Text.Trim(), txtStreetName.Text.Trim(),
                    txtStreetType.Text.Trim(), txtSuburb.Text.Trim(), txtPostcode.Text.Trim(), txtPriorJobReference.Text.Trim(), ContractPrice, ContractDate, EstimatedPrice, Convert.ToInt64(ddlServiceType.SelectedValue),
                    Convert.ToInt64(ddlValuationType.SelectedValue), Convert.ToInt64(ddlPropertyType.SelectedValue), Convert.ToInt64(ddlPurpose.SelectedValue), Convert.ToInt64(ddlTransactionType.SelectedValue),
                    Convert.ToInt64(ddlUrgency.SelectedValue), QuoteFee, Convert.ToInt64(Session["UserId"]), 0, 1, "ADD", txtCustomerEmail.Text.Trim(), "", "Client", ddlState.SelectedValue,
                    "", txtCustomerEmail1.Text.Trim(), ValuationInstruction, PropertyReport, Overlays, Title);
                if (RetVal > 0)
                {
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
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobOrderList.aspx", false);
        }
    }
}
