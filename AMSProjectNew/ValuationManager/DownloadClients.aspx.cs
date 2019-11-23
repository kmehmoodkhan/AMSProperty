using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.IO.Compression;
using System.IO;

namespace AMSProjectNew.ValuationManager
{
    public partial class DownloadClients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["JobPageSize"] != null && Convert.ToString(Session["JobPageSize"]) != "")
                {
                    ddlPageSize.SelectedValue = Convert.ToString(Session["JobPageSize"]);
                }
                FillJobStatus();
                FillJobs();
            }
        }
        private void FillJobStatus()
        {   
            DataSet ds = new DataSet();
            try
            {
                ds = CommonController.JobStatusAllSelect();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlStatus.DataSource = ds.Tables[0].DefaultView;
                    ddlStatus.DataTextField = "StatusName";
                    ddlStatus.DataValueField = "StatusCode";
                    ddlStatus.DataBind();
                }
                ddlStatus.Items.Insert(0, new ListItem("--- All Status ---", "0"));
                ddlStatus.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds = null;
            }
        }
        private void FillJobs()
        {
            JobsController objJobsController = new JobsController();
            DataSet ds = new DataSet();
            try
            {
                ds = objJobsController.JobsSelectForValuationManagerDownloadClients(ddlStatus.SelectedValue);

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

        protected void gvJobs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvJobs.PageIndex = e.NewPageIndex;
            FillJobs();
        }

        protected void gvJobs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    CheckBox cbheaderCategory = ((CheckBox)e.Row.Cells[0].FindControl("cbheaderCategory"));
                    cbheaderCategory.Attributes.Add("onclick", "SelectAllCheckboxesCategoryList('" + cbheaderCategory.ClientID + "');");
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkDelete = ((CheckBox)e.Row.Cells[0].FindControl("chkDelete"));
                    chkDelete.Attributes.Add("onclick", "UncheckAllCategoryList('" + chkDelete.ClientID + "');");
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            

            //Create Tempory Table
            DataTable dtTemp = new DataTable();

            //Creating Header Row
            dtTemp.Columns.Add("<b>JobId</b>");
            dtTemp.Columns.Add("<b>ClientName</b>");
            dtTemp.Columns.Add("<b>InstructedBy</b>");
            dtTemp.Columns.Add("<b>Address</b>");
            dtTemp.Columns.Add("<b>MobilePhoneNumber</b>");
            dtTemp.Columns.Add("<b>EmailAddress</b>");
            dtTemp.Columns.Add("<b>ValuationCompanyName</b>");
            dtTemp.Columns.Add("<b>StatusName</b>");
            dtTemp.Columns.Add("<b>CreatedOn</b>");

            //double dSalary;
            //DateTime dtDate;
            DataRow drAddItem;
            for (int i = 0; i < gvJobs.Rows.Count; i++)
            {
                if (((CheckBox)gvJobs.Rows[i].FindControl("chkDelete")).Checked)
                {
                    drAddItem = dtTemp.NewRow();
                    drAddItem[0] = gvJobs.Rows[i].Cells[0].Text.Trim();
                    drAddItem[1] = gvJobs.Rows[i].Cells[1].Text.Trim();
                    drAddItem[2] = gvJobs.Rows[i].Cells[2].Text.Trim();
                    drAddItem[3] = gvJobs.Rows[i].Cells[3].Text.Trim();
                    drAddItem[4] = gvJobs.Rows[i].Cells[4].Text.Trim();
                    drAddItem[5] = gvJobs.Rows[i].Cells[5].Text.Trim();
                    drAddItem[6] = gvJobs.Rows[i].Cells[6].Text.Trim();
                    drAddItem[7] = gvJobs.Rows[i].Cells[7].Text.Trim();
                    drAddItem[8] = gvJobs.Rows[i].Cells[8].Text.Trim();
                    dtTemp.Rows.Add(drAddItem);
                }
            }

            //Temp Grid
            DataGrid dg = new DataGrid();
            dg.DataSource = dtTemp;
            dg.DataBind();
            ExportToExcel("ValuationClients.xls", dg);
            dg = null;
            dg.Dispose();

        }
        private void ExportToExcel(string strFileName, DataGrid dg)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=" + strFileName);
            Response.ContentType = "application/excel";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dg.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
    }
}
