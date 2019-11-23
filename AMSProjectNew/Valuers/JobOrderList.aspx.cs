using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;

namespace AMSProjectNew.Valuers
{
    public partial class JobOrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            if (!IsPostBack)
            {
                if (Session["JobPageSize"] != null && Convert.ToString(Session["JobPageSize"]) != "")
                {
                    ddlPageSize.SelectedValue = Convert.ToString(Session["JobPageSize"]);
                }
                if (Session["TDSelectedJobJob"] != null && Convert.ToString(Session["TDSelectedJobJob"]) != "")
                {
                    SetNotSelectedTD();
                    SetSelectedTD();
                }
                else
                {
                    SetNotSelectedTD();
                    Session["TDSelectedJobJob"] = "InProgress";
                    SetSelectedTD();
                }      
                FillJobs();
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

                ds = objJobsController.JobsSelectForValuer(Convert.ToInt64(Session["UserId"]), hdnStatus.Value);
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
            FillJobs();
        }
        protected void lbtnInProgress_Click(object sender, EventArgs e)
        {
            SetNotSelectedTD();
            Session["TDSelectedJob"] = "InProgress";
            SetSelectedTD();
            hdnStatus.Value = "4,5,6,7";
            FillJobs();
        }
        protected void lbtnQueried_Click(object sender, EventArgs e)
        {
            SetNotSelectedTD();
            Session["TDSelectedJob"] = "Queried";
            SetSelectedTD();
            hdnStatus.Value = "8";
            FillJobs();
        }
        protected void lbtnCompleted_Click(object sender, EventArgs e)
        {
            SetNotSelectedTD();
            Session["TDSelectedJob"] = "Completed";
            SetSelectedTD();
            hdnStatus.Value = "9";
            FillJobs();
        }
        

        public void SetNotSelectedTD()
        {
            tdAll.Attributes.Add("class", "TDNotSelected");
            tdInProgress.Attributes.Add("class", "TDNotSelected");
            tdQueried.Attributes.Add("class", "TDNotSelected");
            tdCompleted.Attributes.Add("class", "TDNotSelected");
            
        }
        public void SetSelectedTD()
        {
            if (Session["TDSelectedJob"] != null && Convert.ToString(Session["TDSelectedJob"]) == "ALL")
            {
                hdnStatus.Value = "0";
                tdAll.Attributes.Add("class", "TDSelected");
            }
            else if (Session["TDSelectedJob"] != null && Convert.ToString(Session["TDSelectedJob"]) == "InProgress")
            {
                hdnStatus.Value = "4,5,6,7";
                tdInProgress.Attributes.Add("class", "TDSelected");
            }
            else if (Session["TDSelectedJob"] != null && Convert.ToString(Session["TDSelectedJob"]) == "Queried")
            {
                hdnStatus.Value = "8";
                tdQueried.Attributes.Add("class", "TDSelected");
            }
            else if (Session["TDSelectedJob"] != null && Convert.ToString(Session["TDSelectedJob"]) == "Completed")
            {
                hdnStatus.Value = "9";
                tdCompleted.Attributes.Add("class", "TDSelected");
            }
            else
            {
                hdnStatus.Value = "4,5,6,7";
                tdInProgress.Attributes.Add("class", "TDSelected");
            }
        }
        protected void gvJobs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvJobs.PageIndex = e.NewPageIndex;
            FillJobs();
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
            }
        }
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["JobPageSize"] = ddlPageSize.SelectedValue;
            FillJobs();
        }
    }
}
