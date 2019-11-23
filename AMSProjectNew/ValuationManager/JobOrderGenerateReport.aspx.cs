using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.IO;

namespace AMSProjectNew.ValuationManager
{
    public partial class JobOrderGenerateReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["JobId"] != null)
                {
                    FillJobOrderDetails();
                }
                else
                {
                    lblMessage.Text = "Job details doesnt available at this moments.";
                    trMessage.Visible = true;
                }
            }
        }

        private void FillJobOrderDetails()
        {
            JobsController objJobsController = new JobsController();
            DataSet ds = new DataSet();
            try
            {
                ds = objJobsController.JobsSelectByJobId(Convert.ToInt64(Request.QueryString["JobId"]));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblJobTitle.Text = "Job # " + Convert.ToString(ds.Tables[0].Rows[0]["JobId"]) + " - " + Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + " - " + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                    lblJobStatus.Text = Convert.ToString(ds.Tables[0].Rows[0]["StatusName"]);
                    lblCreatedOn.Text = Convert.ToString(ds.Tables[0].Rows[0]["CreatedOn"]);
                    trJobDetails.Visible = true;
                    if (Convert.ToString(ds.Tables[0].Rows[0]["AccountUpload"]) != "")
                    {
                        lblAccountUpload.Text = Convert.ToString(ds.Tables[0].Rows[0]["AccountUpload"]);
                    }
                    trAccountUpload.Visible = false;
                    trFieldNote.Visible = false;
                }
                else
                {
                    lblMessage.Text = "Job details doesnt available at this moments.";
                    trMessage.Visible = true;
                }

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
                trMessage.Visible = true;
            }
            finally
            {
                objJobsController = null;
                ds = null;
            }
        }
        protected void btnSubmitReports_Click(object sender, EventArgs e)
        {
            JobsController objJobsController = new JobsController();
            string strReportUpload = DateTime.Now.ToString("MMddyyyyhhmmss");
            string strAccountUpload = DateTime.Now.ToString("MMddyyyyhhmmss");
            string strFieldNoteUpload = DateTime.Now.ToString("MMddyyyyhhmmss");

            try
            {
                if (fuReport.FileName.ToString() != "")
                {
                    if (File.Exists(Server.MapPath("../FinalReportsTemp/") + fuReport.FileName.ToString()))
                        File.Delete(Server.MapPath("../FinalReportsTemp/") + fuReport.FileName.ToString());

                    fuReport.SaveAs(Server.MapPath("../FinalReportsTemp/") + fuReport.FileName.ToString());
                    strReportUpload = strReportUpload + "_" + fuReport.FileName.ToString();

                    File.Copy(Server.MapPath("../FinalReportsTemp/") + fuReport.FileName.ToString(), Server.MapPath("../FinalReports/") + strReportUpload);
                }
                else
                    strReportUpload = "";
                if (fuAccount.FileName.ToString() != "")
                {
                    if (File.Exists(Server.MapPath("../FinalReportsTemp/") + fuAccount.FileName.ToString()))
                        File.Delete(Server.MapPath("../FinalReportsTemp/") + fuAccount.FileName.ToString());

                    fuAccount.SaveAs(Server.MapPath("../FinalReportsTemp/") + fuAccount.FileName.ToString());
                    strAccountUpload = strAccountUpload + "_" + fuAccount.FileName.ToString();

                    File.Copy(Server.MapPath("../FinalReportsTemp/") + fuAccount.FileName.ToString(), Server.MapPath("../FinalReports/") + strAccountUpload);
                }
                else
                    strAccountUpload = lblAccountUpload.Text;
                if (fuNote.FileName.ToString() != "")
                {
                    if (File.Exists(Server.MapPath("../FinalReportsTemp/") + fuNote.FileName.ToString()))
                        File.Delete(Server.MapPath("../FinalReportsTemp/") + fuNote.FileName.ToString());

                    fuNote.SaveAs(Server.MapPath("../FinalReportsTemp/") + fuNote.FileName.ToString());
                    strFieldNoteUpload = strFieldNoteUpload + "_" + fuNote.FileName.ToString();

                    File.Copy(Server.MapPath("../FinalReportsTemp/") + fuNote.FileName.ToString(), Server.MapPath("../FinalReports/") + strFieldNoteUpload);
                }
                else
                    strFieldNoteUpload = "";

                int RetVal = objJobsController.JobEditFinalReportSubmit(Convert.ToInt64(Request.QueryString["JobId"]), strReportUpload, strAccountUpload, strFieldNoteUpload, 7, "FINALREPORTUPLOAD");
                if (RetVal > 0)
                {
                    DeleteFilesFromFinalReportsTemp();
                    Session["ShowMessage"] = "ReportCompleted";
                    Response.Redirect("JobOrderDetails.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
                }
                else
                {
                    DeleteFilesFromFinalReportsTemp();
                    DeleteFilesFromFinalReports(strReportUpload, strAccountUpload, strFieldNoteUpload);
                    lblMessage.Text = "Error to upload documents.";
                    trMessage.Visible = true;
                }

            }
            catch (Exception ex)
            {
                DeleteFilesFromFinalReportsTemp();
                lblMessage.Text = ex.Message.ToString();
                trMessage.Visible = true;
            }
            finally
            {
                objJobsController = null;
            }
        }
        public void DeleteFilesFromFinalReports(string strReportUpload, string strAccountUpload, string strFieldNoteUpload)
        {
            try
            {
                if (fuReport.FileName.ToString() != "")
                {
                    if (File.Exists(Server.MapPath("../FinalReports/") + strFieldNoteUpload))
                        File.Delete(Server.MapPath("../FinalReports/") + strFieldNoteUpload);
                }
                if (fuAccount.FileName.ToString() != "")
                {
                    if (File.Exists(Server.MapPath("../FinalReports/") + strAccountUpload))
                        File.Delete(Server.MapPath("../FinalReports/") + strAccountUpload);
                }
                if (fuNote.FileName.ToString() != "")
                {
                    if (File.Exists(Server.MapPath("../FinalReports/") + strFieldNoteUpload))
                        File.Delete(Server.MapPath("../FinalReports/") + strFieldNoteUpload);
                }
            }
            catch (Exception)
            {

            }
        }
        public void DeleteFilesFromFinalReportsTemp()
        {
            try
            {
                if (fuReport.FileName.ToString() != "")
                {
                    if (File.Exists(Server.MapPath("../FinalReportsTemp/") + fuReport.FileName.ToString()))
                        File.Delete(Server.MapPath("../FinalReportsTemp/") + fuReport.FileName.ToString());
                }
                if (fuAccount.FileName.ToString() != "")
                {
                    if (File.Exists(Server.MapPath("../FinalReportsTemp/") + fuAccount.FileName.ToString()))
                        File.Delete(Server.MapPath("../FinalReportsTemp/") + fuAccount.FileName.ToString());
                }
                if (fuNote.FileName.ToString() != "")
                {
                    if (File.Exists(Server.MapPath("../FinalReportsTemp/") + fuNote.FileName.ToString()))
                        File.Delete(Server.MapPath("../FinalReportsTemp/") + fuNote.FileName.ToString());
                }
            }
            catch (Exception)
            {

            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobOrderDetails.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
        }
    }
}
