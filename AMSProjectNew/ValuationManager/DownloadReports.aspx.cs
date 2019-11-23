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
using ICSharpCode.SharpZipLib.Zip;

namespace AMSProjectNew.ValuationManager
{
    public partial class DownloadReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["JobPageSize"] != null && Convert.ToString(Session["JobPageSize"]) != "")
                {
                    ddlPageSize.SelectedValue = Convert.ToString(Session["JobPageSize"]);
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
                ds = objJobsController.JobsSelectForValuationManagerDownloadReports("", txtStart.Text.Trim(),txtEnd.Text.Trim());

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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblStatusName = (Label)e.Row.FindControl("lblStatusName");
                
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

                
                lblStatusName.Attributes.Add("style", "color:" + ForeColor);
                
            }
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
            string source = Server.MapPath("~/FinalReports/");
            string dir = Server.MapPath("~/FinalReports/") + DateTime.Now.ToString("MMddyyyy");
            if(Directory.Exists(dir))
                Directory.Delete(dir, true);
            Directory.CreateDirectory(dir);

            string zip = dir + "/Reports.zip";

            for (int i = 0; i < gvJobs.Rows.Count; i++)
            {
                CheckBox chkDelete = (CheckBox)gvJobs.Rows[i].FindControl("chkDelete");
                Label lblReportUpload = (Label)gvJobs.Rows[i].FindControl("lblReportUpload");

                if (chkDelete.Checked)
                {
                    if (File.Exists(source + lblReportUpload.Text.Trim()))
                        File.Copy(source + lblReportUpload.Text.Trim(), dir + "/" + lblReportUpload.Text.Trim(), true);
                }
            }

            StartZip2(dir, zip);

            Directory.Delete(dir, true);
        }
        public void StartZip2(string directory, string zipfile_path)
        {
            // the directory you need to zip
            string[] filenames = Directory.GetFiles(directory);


            // path which the zip file built in
            ZipOutputStream s = new ZipOutputStream(File.Create(zipfile_path));
            foreach (string filename in filenames)
            {
                FileStream fs = File.OpenRead(filename);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                ZipEntry entry = new ZipEntry(filename);
                s.PutNextEntry(entry);
                s.Write(buffer, 0, buffer.Length);
                fs.Close();


            }
            s.SetLevel(1);
            s.Finish();
            s.Close();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Reports.zip");
            Response.TransmitFile(zipfile_path);
            Response.End();
        }
        protected void StartZip(string strPath, string strFileName)
        {
            MemoryStream ms = null;
            ZipOutputStream zos = null;

            Response.ContentType = "application/octet-stream";
            strFileName = HttpUtility.UrlEncode(strFileName).Replace('+', ' ');
            Response.AddHeader("Content-Disposition", "attachment; filename=Reports.zip");
            ms = new MemoryStream();
            zos = new ZipOutputStream(ms);
            string strBaseDir = strPath + "\\";
            addZipEntry(strBaseDir, strFileName);
            zos.Finish();
            zos.Close();
            Response.Clear();
            Response.BinaryWrite(ms.ToArray());
            Response.End();
        }


        protected void addZipEntry(string PathStr, string zipfile_path)
        {
            DirectoryInfo di = new DirectoryInfo(PathStr);
            
            //foreach (DirectoryInfo item in di.GetDirectories())
            //{
            //    addZipEntry(item.FullName);
            //}

            ZipOutputStream zos = new ZipOutputStream(File.Create(zipfile_path));
            foreach (FileInfo item in di.GetFiles())
            {
                FileStream fs = File.OpenRead(item.FullName);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                //string strEntryName = item.FullName.Replace(strBaseDir, "");
                string strEntryName = item.FullName;
                ZipEntry entry = new ZipEntry(strEntryName);
                zos.PutNextEntry(entry);
                zos.Write(buffer, 0, buffer.Length);
                fs.Close();
            }

            zos.SetLevel(1);
            zos.Finish();
            zos.Close();
        }

    }
}
