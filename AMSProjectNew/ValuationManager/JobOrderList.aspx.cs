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
    public partial class JobOrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillActiveValuers();
                FillPurpose();
                if (Session["JobPageSize"] != null && Convert.ToString(Session["JobPageSize"]) != "")
                {
                    ddlPageSize.SelectedValue = Convert.ToString(Session["JobPageSize"]);
                }
                if (Session["TDSelectedJob"] != null && Convert.ToString(Session["TDSelectedJob"]) != "")
                {
                    SetNotSelectedTD();
                    SetSelectedTD();
                }
                else
                {
                    SetNotSelectedTD();
                    Session["TDSelectedJob"] = "Incoming";
                    SetSelectedTD();
                } 
                FillJobs();
                if (Request.QueryString["Option"] != null && Convert.ToString(Request.QueryString["Option"]) == "Deleted")
                {
                    lblMessage.Text = "Job deleted successfully.";
                }
            }
        }
        public void FillActiveValuers()
        {
            ValuersController valuersController = new ValuersController();
            DataSet ds = new DataSet();
            try
            {
                ds = valuersController.ValuersSelectAll(0, 0, 2);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlValuers.DataSource = ds.Tables[0].DefaultView;
                    ddlValuers.DataTextField = "Username";
                    ddlValuers.DataValueField = "UserId";
                    ddlValuers.DataBind();
                }

                ddlValuers.Items.Insert(0, new ListItem("All Valuers", "0"));
                ddlValuers.SelectedValue = "0";
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

        private void FillPurpose()
        {
            CommonController commonController = new CommonController();
            DataSet ds = new DataSet();
            try
            {
                ds = commonController.PurposeSelectAll(0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    this.ddlPurpose.DataSource = ds.Tables[0].DefaultView;
                    this.ddlPurpose.DataValueField = "Id";
                    this.ddlPurpose.DataTextField = "PurposeName";
                    ddlPurpose.DataBind();

                    this.ddlPurpose.Items.Insert(0, new ListItem("All Purposes", "0"));
                }
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
        private void FillJobs()
        {
            JobsController objJobsController = new JobsController();
            DataSet ds = new DataSet();
            try
            {
                if (hdnStatus.Value == "")
                    hdnStatus.Value = "0";

                ds = objJobsController.JobsSelectForValuationManager(hdnStatus.Value, hdnIsEditRequest.Value,
                    txtJobIdSearch.Text.Trim(),txtStreetSearch.Text.Trim(),txtClientSearch.Text.Trim(),
                    txtSuburbSearch.Text.Trim(),ddlValuers.SelectedValue,Convert.ToInt32(this.ddlPurpose.SelectedValue));

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvJobs.PageSize = Convert.ToInt16(ddlPageSize.SelectedValue);
                    gvJobs.DataSource = ds.Tables[0].DefaultView;
                    gvJobs.DataBind();
                    gvJobs.Visible = true;
                    lblTotal.Text = "Total " + ds.Tables[0].Rows.Count.ToString() + " Jobs are available.";
                }
                else
                {
                    gvJobs.Visible = false;
                    lblTotal.Text = "Job are not available at this moments.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
            }
            finally
            {
                objJobsController = null;
                ds = null;
            }
        }
        protected void lbtnALL_Click(object sender, EventArgs e)
        {
            SetNotSelectedTD();
            Session["TDSelectedJob"] = "ALL";
            SetSelectedTD();
            hdnStatus.Value = "0";
            hdnIsEditRequest.Value = "";
            FillJobs();
        }
        protected void lbtnIncoming_Click(object sender, EventArgs e)
        {
            SetNotSelectedTD();
            Session["TDSelectedJob"] = "Incoming";
            SetSelectedTD();
            hdnStatus.Value = "1";
            hdnIsEditRequest.Value = "";
            FillJobs();
        }
        protected void lbtnQueued_Click(object sender, EventArgs e)
        {
            SetNotSelectedTD();
            Session["TDSelectedJob"] = "Queued";
            SetSelectedTD();
            hdnStatus.Value = "2";
            hdnIsEditRequest.Value = "";
            FillJobs();
        }
        protected void lbtnInProgress_Click(object sender, EventArgs e)
        {
            SetNotSelectedTD();
            Session["TDSelectedJob"] = "InProgress";
            SetSelectedTD();
            hdnStatus.Value = "4,5,6,7";
            hdnIsEditRequest.Value = "";
            FillJobs();
        }
        protected void lbtnQueried_Click(object sender, EventArgs e)
        {
            SetNotSelectedTD();
            Session["TDSelectedJob"] = "Queried";
            SetSelectedTD();
            hdnStatus.Value = "8";
            hdnIsEditRequest.Value = "";
            FillJobs();
        }
        protected void lbtnCompleted_Click(object sender, EventArgs e)
        {
            SetNotSelectedTD();
            Session["TDSelectedJob"] = "Completed";
            SetSelectedTD();
            hdnStatus.Value = "9";
            hdnIsEditRequest.Value = "";
            FillJobs();
        }
        protected void lbtnRejectFee_Click(object sender, EventArgs e)
        {
            SetNotSelectedTD();
            Session["TDSelectedJob"] = "RejectFee";
            SetSelectedTD();
            hdnStatus.Value = "10";
            hdnIsEditRequest.Value = "";
            FillJobs();
        }
        protected void lbtnUpdate_Click(object sender, EventArgs e)
        {
            SetNotSelectedTD();
            Session["TDSelectedJob"] = "Update";
            SetSelectedTD();
            hdnStatus.Value = "0";
            hdnIsEditRequest.Value = "Yes";
            FillJobs();
        }

        public void SetNotSelectedTD()
        {
            tdAll.Attributes.Add("class", "TDNotSelected");
            tdIncoming.Attributes.Add("class", "TDNotSelected");
            tdQueued.Attributes.Add("class", "TDNotSelected");
            tdInProgress.Attributes.Add("class", "TDNotSelected");
            tdCompleted.Attributes.Add("class", "TDNotSelected");
            tdRejectFee.Attributes.Add("class", "TDNotSelected");

            tdQueried.Attributes.Add("class", "TDNotSelected");
            tdUpdate.Attributes.Add("class", "TDNotSelectedRed");
        }
        public void SetSelectedTD()
        {
            if (Session["TDSelectedJob"] != null && Convert.ToString(Session["TDSelectedJob"]) == "ALL")
            {
                hdnStatus.Value = "0";
                hdnIsEditRequest.Value = "";
                tdAll.Attributes.Add("class", "TDSelected");
            }
            else if (Session["TDSelectedJob"] != null && Convert.ToString(Session["TDSelectedJob"]) == "Incoming")
            {
                hdnStatus.Value = "1";
                hdnIsEditRequest.Value = "";
                tdIncoming.Attributes.Add("class", "TDSelected");
            }
            else if (Session["TDSelectedJob"] != null && Convert.ToString(Session["TDSelectedJob"]) == "Queued")
            {
                hdnStatus.Value = "2";
                hdnIsEditRequest.Value = "";
                tdQueued.Attributes.Add("class", "TDSelected");
            }
            else if (Session["TDSelectedJob"] != null && Convert.ToString(Session["TDSelectedJob"]) == "InProgress")
            {
                hdnStatus.Value = "4,5,6,7";
                hdnIsEditRequest.Value = "";
                tdInProgress.Attributes.Add("class", "TDSelected");
            }
            else if (Session["TDSelectedJob"] != null && Convert.ToString(Session["TDSelectedJob"]) == "Queried")
            {
                hdnStatus.Value = "8";
                hdnIsEditRequest.Value = "";
                tdQueried.Attributes.Add("class", "TDSelected");
            }
            else if (Session["TDSelectedJob"] != null && Convert.ToString(Session["TDSelectedJob"]) == "Completed")
            {
                hdnStatus.Value = "9";
                hdnIsEditRequest.Value = "";
                tdCompleted.Attributes.Add("class", "TDSelected");
            }
            else if (Session["TDSelectedJob"] != null && Convert.ToString(Session["TDSelectedJob"]) == "RejectFee")
            {
                hdnStatus.Value = "10";
                hdnIsEditRequest.Value = "";
                tdRejectFee.Attributes.Add("class", "TDSelected");
            }
            else if (Session["TDSelectedJob"] != null && Convert.ToString(Session["TDSelectedJob"]) == "Update")
            {
                hdnStatus.Value = "0";
                hdnIsEditRequest.Value = "Yes";
                tdUpdate.Attributes.Add("class", "TDSelected");
            }
            else
            {
                hdnStatus.Value = "1";
                hdnIsEditRequest.Value = "";
                tdIncoming.Attributes.Add("class", "TDSelected");
            }
        }
        protected void gvJobs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvJobs.PageIndex = e.NewPageIndex;
            FillJobs();
        }        
        protected void btnCreateJob_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobOrderCreate.aspx", false);
        }
        protected void gvJobs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblStatusName = (Label)e.Row.FindControl("lblStatusName");
                Label lblAppointmentSet = (Label)e.Row.FindControl("lblAppointmentSet");
                Label lblPaymentStatus = (Label)e.Row.FindControl("lblPaymentStatus");
                string ForeColor = "Black";
                string BackColor = "";

                if (lblStatusName.Text.Trim() == "Incoming")
                {
                    BackColor = "#FFFF84";
                    ForeColor = "#9D9D00";
                }
                else if (lblStatusName.Text.Trim() == "Queued")
                {
                    BackColor = "#FFB428";
                    ForeColor = "#C27E3A";
                }
                else if (lblStatusName.Text.Trim() == "In Progress - Accepted")
                {
                    lblStatusName.Text = "Accepted";
                    BackColor = "#93BF96";
                    ForeColor = "#005A00";
                }
                else if (lblStatusName.Text.Trim() == "In Progress - Appointment Set")
                {
                    lblStatusName.Text = "Appointment Set";
                    BackColor = "#5FFEF7";
                    ForeColor = "#008EB2";
                }
                else if (lblStatusName.Text.Trim() == "In Progress - Inspected")
                {
                    lblStatusName.Text = "Inspected";
                    BackColor = "#FFBBDD";
                    ForeColor = "#872187";
                }
                else if (lblStatusName.Text.Trim() == "In Progress - Reviewer")
                {
                    lblStatusName.Text = "Review";
                    BackColor = "#FF3333";
                    ForeColor = "Black";
                }
                else if (lblStatusName.Text.Trim() == "Completed")
                {
                    BackColor = "#A5CE37";
                    ForeColor = "#005A00";
                }
                else if (lblStatusName.Text.Trim() == "Queried")
                {
                    BackColor = "Red";
                    ForeColor = "Black";
                }
                else if (lblStatusName.Text.Trim() == "Reject Fee")
                {
                    BackColor = "FF3333";
                    ForeColor = "#660000";
                }
                else if (lblStatusName.Text.Trim() == "Rejected by Valuation Company")
                {
                    BackColor = "Red";
                    ForeColor = "Black";
                }

                e.Row.Cells[5].Attributes.Add("style", "background-color:" + BackColor);
                lblStatusName.Attributes.Add("style", "color:" + ForeColor);
                lblAppointmentSet.Attributes.Add("style", "color:" + ForeColor);
                lblPaymentStatus.Attributes.Add("style", "color:" + ForeColor);

                Label lblIsClientReportEdit = (Label)e.Row.FindControl("lblIsClientReportEdit");

                if (lblIsClientReportEdit.Text.Trim() == "1")
                    lblIsClientReportEdit.Text = "<img src='../Images/red-star.png' style='width:15px;' />";
                else if (lblIsClientReportEdit.Text.Trim() == "2")
                    lblIsClientReportEdit.Text = "<img src='../Images/gray-star.png' style='width:15px;' />";
            }
        }
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["JobPageSize"] = ddlPageSize.SelectedValue;
            FillJobs();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["JobPageSize"] = ddlPageSize.SelectedValue;
            FillJobs();
        }
        protected void btnSearchClear_Click(object sender, EventArgs e)
        {
            txtJobIdSearch.Text = "";
            txtClientSearch.Text = "";
            txtStreetSearch.Text = "";
            txtSuburbSearch.Text = "";
            FillJobs();
        }
    }
}
