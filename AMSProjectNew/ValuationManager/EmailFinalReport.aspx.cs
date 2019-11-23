using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using BusinessLayer;
using System.IO;

namespace AMSProjectNew.ValuationManager
{
    public partial class EmailFinalReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["JobId"] != null)
                {
                    FillJobOrderDetails();
                    SendToClientForConfirmationofValuersInspected();
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
                    lblJobId1.Text = "Job No - " + Convert.ToString(ds.Tables[0].Rows[0]["JobId"]);
                    if (Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]) != "")
                    {
                        lblAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]) + "/" + Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);

                    }
                    else
                    {
                        lblAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                    }

                    lblAccountUploadNew.Text = Convert.ToString(ds.Tables[0].Rows[0]["AccountUpload"]);
                    lblPdfReport.Text = Convert.ToString(ds.Tables[0].Rows[0]["ReportUpload"]);
                    lblFieldNoteUploadNew.Text = Convert.ToString(ds.Tables[0].Rows[0]["FieldNoteUpload"]);

                    lblFinalReport.Text = "<a class='Error' target='0' href='../FinalReports/" + Convert.ToString(ds.Tables[0].Rows[0]["ReportUpload"]) + "'>Click here to view file</a>";
                    
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
        private void SendToClientForConfirmationofValuersInspected()
        {
            CommonController objCommonController = new CommonController();
            StreamReader sr = new StreamReader(Server.MapPath("~/EmailTemplates/ConfirmationofValuationReport.htm"));
            DataSet ds = new DataSet();
            try
            {
                ds = objCommonController.SelectConfirmationofValuersAppointmentDetails(Convert.ToInt64(Request.QueryString["JobId"]));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    string strMsg = sr.ReadToEnd();
                    strMsg = strMsg.Replace("{CompanyName}", Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]));
                    strMsg = strMsg.Replace("{CompanyAddress1}", Convert.ToString(ds.Tables[0].Rows[0]["CompanyAddress1"]));
                    strMsg = strMsg.Replace("{CompanyAddress2}", Convert.ToString(ds.Tables[0].Rows[0]["CompanyAddress2"]));
                    strMsg = strMsg.Replace("{Date}", Convert.ToString(ds.Tables[0].Rows[0]["AppointmentSet"]));
                    strMsg = strMsg.Replace("{PropertyAddress}", lblAddress.Text.Trim());
                    strMsg = strMsg.Replace("{Price}", Convert.ToString(ds.Tables[0].Rows[0]["QuoteFee"]));
                    strMsg = strMsg.Replace("{ValuerName}", Convert.ToString(ds.Tables[0].Rows[0]["ValuerName"]));
                    strMsg = strMsg.Replace("{ValuerPhone}", Convert.ToString(ds.Tables[0].Rows[0]["ValuerPhone"]));
                    strMsg = strMsg.Replace("{ValuerEmail}", Convert.ToString(ds.Tables[0].Rows[0]["ValuerEmail"]));


                    fckEditor.Text = strMsg;
                    txtToEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmailAddress"]);
                    txtToEmail1.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmailAddress1"]);
                    txtFromEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyEmail"]);
                    txtReplyTo.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyEmail"]);
                    txtCompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]);

                    txtSubject.Text = "Valuation Report Completed";

                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objCommonController = null;
                sr = null;
                ds = null;
            }
        }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            CommonController objCommonController = new CommonController();
            //StreamWriter sw = null;
            try
            {
                string strFileName = Request.QueryString["JobId"].ToString() + "_Report.html";
                string strHtmlFile = Server.MapPath("~/EmailHistoryFiles/" + strFileName);

                if (File.Exists(strHtmlFile))
                    File.Delete(strHtmlFile);

                JobsController.EmailHistoryEdit(0, Convert.ToInt64(Request.QueryString["JobId"]), Convert.ToInt64(Session["UserId"]), "Final Report Sent",
                    txtToEmail.Text.Trim(), txtSubject.Text.Trim(), txtFromEmail.Text.Trim(), txtReplyTo.Text.Trim(), strFileName,
                    HttpContext.Current.Request.UserHostAddress.ToString(), "ADD");


                string ReportUpload = Server.MapPath("../FinalReports/" + lblPdfReport.Text);
                string AccountUpload = "";
                if (lblAccountUploadNew.Text.Trim() != "")
                    AccountUpload = Server.MapPath("../FinalReports/Accounts/" + lblAccountUploadNew.Text);
                string FieldNoteUpload = "";
                if (lblFieldNoteUploadNew.Text.Trim() != "")
                    FieldNoteUpload = Server.MapPath("../FinalReports/" + lblFieldNoteUploadNew.Text);

                CommonController.LogInsert("Final Report Sent:", "");
                objCommonController.SendPDFReportEmailToClient(txtToEmail.Text.Trim(), txtToEmail1.Text.Trim(), txtReplyTo.Text.Trim(),
                     txtFromEmail.Text.Trim(), txtCompany.Text.Trim(),fckEditor.Text.Trim(), ReportUpload, AccountUpload, 
                     FieldNoteUpload, txtSubject.Text.Trim());

                //sw = new StreamWriter(strHtmlFile);
                string strContents = "";

                strContents += "<link href='../CSS/Default.css' rel='stylesheet' type='text/css' />";
                strContents += "<table width='100%'>";
                strContents = "<tr><td width='100px' class='TDLeftTextLeft'>Final Report:</td><td><a class='Error' target='0' href='../FinalReports/" + lblPdfReport.Text.Trim() + "'>Click here to view file</a></td></tr>";
                strContents = "<tr><td width='100px' class='TDLeftTextLeft'>To Email:</td><td>" + txtToEmail.Text.Trim() + "</td></tr>";
                strContents = "<tr><td class='TDLeftTextLeft'>To Email:</td><td>" + txtToEmail1.Text.Trim() + "</td></tr>";
                strContents = "<tr><td class='TDLeftTextLeft'>Subject:</td><td>" + txtSubject.Text.Trim() + "</td></tr>";
                strContents = "<tr><td class='TDLeftTextLeft'>Company:</td><td>" + txtCompany.Text.Trim() + "</td></tr>";
                strContents = "<tr><td class='TDLeftTextLeft'>From Email:</td><td>" + txtFromEmail.Text.Trim() + "</td></tr>";
                strContents = "<tr><td class='TDLeftTextLeft'>Reply To:</td><td>" + txtReplyTo.Text.Trim() + "</td></tr>";
                strContents = "<tr><td class='TDLeftTextLeft'>Date & Time:</td><td>" + DateTime.Now.ToString("dd/MM/yyyy hh:mm") + "</td></tr>";
                strContents = "</table><br/><br/>";
                //sw.Write(strContents + fckEditor.Text.Trim());

                using (StreamWriter outfile = new StreamWriter(strHtmlFile))
                {
                    outfile.Write(strContents + fckEditor.Text.Trim());
                }

                Response.Redirect("EmailSent.aspx?Mode=Insp&JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobOrderDetails.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
        }
    }
}
