using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.IO;
using System.Drawing;
using System.Collections;
using CuteWebUI;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
//using Winnovative.PdfToImage;
using ExpertPdf.PdfCreator;
using ExpertPdf;

namespace AMSProjectNew.ValuationManager
{
    public partial class GenerateReport : System.Web.UI.Page
    {
        protected string ActiveTab = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillAllDropDowns();
                //FillPropertyType();
                //FillPurpose();
                SetDefaultText();

                if (Request.QueryString["JobId"] != null && Convert.ToString(Request.QueryString["JobId"]) != "")
                {
                    FillJobOrderDetails();
                    lblJobId.Text = Convert.ToString(Request.QueryString["JobId"]);
                    lblJobId1.Text = Convert.ToString(Request.QueryString["JobId"]);
                }
                GetCompanyDetails();
                if (Session["TDReportSelected"] != null && Convert.ToString(Session["TDReportSelected"]) != "")
                {
                    SetNotSelectedTD();
                    SetSelectedTD();
                }
                else
                {
                    SetNotSelectedTD();
                    Session["TDReportSelected"] = "Tab1Summary";
                    SetSelectedTD();
                }
                FillTab1Summary();
                FillDocumentDetails();
            }
        }

        private int ParamJobId
        {
            get
            {
                int jobId = 0;

                if (Request.QueryString["JobId"] != null)
                {
                    jobId = Convert.ToInt32(Request.QueryString["JobId"]);
                }
                return jobId;
            }
        }

        

    private void FillDocumentDetails()
        {
            using (var context = new marketvalDBEntities())
            {
                var sections = from p in context.AMS_ReportSections
                               join q in context.AMS_Tab8_Attachments on p.AMS_ReportSectionsId equals q.SectionId
                               where p.JobId == ParamJobId && q.JobId == ParamJobId
                               select new { Id = q.Id, p.SectionName, ImageUrl = q.ImageName, p.CreatedOn };



                this.GridViewSections.DataSource = sections.ToList();
                this.GridViewSections.DataBind();

                this.dropDownSection.DataSource = context.AMS_ReportSections.Where(t=>t.JobId== ParamJobId).ToList();
                this.dropDownSection.DataBind();

                this.GridViewSectionsList.DataSource = context.AMS_ReportSections.Where(t => t.JobId == ParamJobId).ToList();
                this.GridViewSectionsList.DataBind();

                this.dropDownSection.Items.Insert(0, "Select Section");
            }
        }

        private void LoadDocumentsListing()
        {
            

            using (var context = new marketvalDBEntities())
            {
                var sections = from p in context.AMS_ReportSections
                               join q in context.AMS_Tab8_Attachments on p.AMS_ReportSectionsId equals q.SectionId
                               where p.JobId == ParamJobId && q.JobId == ParamJobId
                               select new { Id = q.Id, p.SectionName, ImageUrl = q.ImageName, p.CreatedOn };
                this.GridViewSections.DataSource = sections.ToList();
                this.GridViewSections.DataBind();
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

                    if (Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]) != "")
                    {
                        lblAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]) + "/" + Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);

                    }
                    else
                    {
                        lblAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                    }

                    lblCompanyHeaderImage.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyHeaderImage"]);
                    lblCompanyFooterImage.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyFooterImage"]);

                    lblClient.Text = Convert.ToString(ds.Tables[0].Rows[0]["CustomerFullName"]);

                    string purposeId = ds.Tables[0].Rows[0]["Purpose"].ToString();
                    if (!string.IsNullOrEmpty(purposeId))
                    {
                        this.ddlPurpose.SelectedIndex = this.ddlPurpose.Items.IndexOf(this.ddlPurpose.Items.FindByValue(purposeId));
                    }

                    //lblPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["PhoneNumber"]);

                    //lblEmailAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmailAddress"]);

                }
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

        #region Fill Custom Dropdowns
        public void FillAllDropDowns()
        {
            CommonController commonController = new CommonController();
            DataSet ds = new DataSet();
            try
            {
                //Valuation Approach
                ds = commonController.GetCustomList();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlValuationApproach.DataSource = ds.Tables[0].DefaultView;
                    ddlValuationApproach.DataTextField = "Name";
                    ddlValuationApproach.DataValueField = "LookupId";
                    ddlValuationApproach.DataBind();
                }

                //Purpose
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    ddlPurpose.DataSource = ds.Tables[1].DefaultView;
                    ddlPurpose.DataTextField = "Name";
                    ddlPurpose.DataValueField = "LookupId";
                    ddlPurpose.DataBind();
                }
                ddlPurpose.Items.Insert(0, new ListItem("Select Purpose", "0"));
                ddlPurpose.SelectedValue = "0";

                //Property Type
                if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                {
                    ddlTab2PropertyType.DataSource = ds.Tables[2].DefaultView;
                    ddlTab2PropertyType.DataTextField = "Name";
                    ddlTab2PropertyType.DataValueField = "Name";
                    ddlTab2PropertyType.DataBind();
                }
                ddlTab2PropertyType.Items.Insert(0, new ListItem("Select Property Type", "0"));
                ddlTab2PropertyType.SelectedValue = "0";

                //Property Identification
                if (ds != null && ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                {
                    ddlTab2PropertyIdentification.DataSource = ds.Tables[3].DefaultView;
                    ddlTab2PropertyIdentification.DataTextField = "Name";
                    ddlTab2PropertyIdentification.DataValueField = "Name";
                    ddlTab2PropertyIdentification.DataBind();
                }

                //Title Search
                if (ds != null && ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
                {
                    ddlTab2TitleSearch.DataSource = ds.Tables[4].DefaultView;
                    ddlTab2TitleSearch.DataTextField = "Name";
                    ddlTab2TitleSearch.DataValueField = "Name";
                    ddlTab2TitleSearch.DataBind();
                }
                ddlTab2TitleSearch.Items.Insert(0, new ListItem("Select One", "0"));
                ddlTab2TitleSearch.SelectedValue = "0";

                //Plan
                if (ds != null && ds.Tables.Count > 5 && ds.Tables[5].Rows.Count > 0)
                {
                    ddlTab2Plan.DataSource = ds.Tables[5].DefaultView;
                    ddlTab2Plan.DataTextField = "Name";
                    ddlTab2Plan.DataValueField = "Name";
                    ddlTab2Plan.DataBind();
                }
                ddlTab2Plan.Items.Insert(0, new ListItem("Plan", "0"));
                ddlTab2Plan.SelectedValue = "0";

                //Registered Proprietors
                if (ds != null && ds.Tables.Count > 6 && ds.Tables[6].Rows.Count > 0)
                {
                    ddltab2RegisteredProprietors.DataSource = ds.Tables[6].DefaultView;
                    ddltab2RegisteredProprietors.DataTextField = "Name";
                    ddltab2RegisteredProprietors.DataValueField = "Name";
                    ddltab2RegisteredProprietors.DataBind();
                }

                //Encumbrances
                if (ds != null && ds.Tables.Count > 7 && ds.Tables[7].Rows.Count > 0)
                {
                    ddlTab2Encumbrances.DataSource = ds.Tables[7].DefaultView;
                    ddlTab2Encumbrances.DataTextField = "Name";
                    ddlTab2Encumbrances.DataValueField = "Name";
                    ddlTab2Encumbrances.DataBind();
                }

                //Zoning Effect
                if (ds != null && ds.Tables.Count > 8 && ds.Tables[8].Rows.Count > 0)
                {
                    ddlTab2ZoningEffect.DataSource = ds.Tables[8].DefaultView;
                    ddlTab2ZoningEffect.DataTextField = "Name";
                    ddlTab2ZoningEffect.DataValueField = "Name";
                    ddlTab2ZoningEffect.DataBind();
                }

                //Site Layout
                if (ds != null && ds.Tables.Count > 9 && ds.Tables[9].Rows.Count > 0)
                {
                    ddlTab2SiteLayout.DataSource = ds.Tables[9].DefaultView;
                    ddlTab2SiteLayout.DataTextField = "Name";
                    ddlTab2SiteLayout.DataValueField = "Name";
                    ddlTab2SiteLayout.DataBind();
                }

                //Services
                if (ds != null && ds.Tables.Count > 10 && ds.Tables[10].Rows.Count > 0)
                {
                    ddltab2Services.DataSource = ds.Tables[10].DefaultView;
                    ddltab2Services.DataTextField = "Name";
                    ddltab2Services.DataValueField = "Name";
                    ddltab2Services.DataBind();
                }

                //Environmental Hazards
                if (ds != null && ds.Tables.Count > 11 && ds.Tables[11].Rows.Count > 0)
                {
                    ddlTab2EnvironmentalHazards.DataSource = ds.Tables[11].DefaultView;
                    ddlTab2EnvironmentalHazards.DataTextField = "Name";
                    ddlTab2EnvironmentalHazards.DataValueField = "Name";
                    ddlTab2EnvironmentalHazards.DataBind();
                }

                //Pest Infestation
                if (ds != null && ds.Tables.Count > 12 && ds.Tables[12].Rows.Count > 0)
                {
                    ddlTab2PestInfestation.DataSource = ds.Tables[12].DefaultView;
                    ddlTab2PestInfestation.DataTextField = "Name";
                    ddlTab2PestInfestation.DataValueField = "Name";
                    ddlTab2PestInfestation.DataBind();
                }

                //Property Style
                if (ds != null && ds.Tables.Count > 13 && ds.Tables[13].Rows.Count > 0)
                {
                    ddlTab3PropertyStyle.DataSource = ds.Tables[13].DefaultView;
                    ddlTab3PropertyStyle.DataTextField = "Name";
                    ddlTab3PropertyStyle.DataValueField = "Name";
                    ddlTab3PropertyStyle.DataBind();
                }
                ddlTab3PropertyStyle.Items.Insert(0, new ListItem("Select One", "0"));
                ddlTab3PropertyStyle.SelectedValue = "0";

                //External Walls
                if (ds != null && ds.Tables.Count > 14 && ds.Tables[14].Rows.Count > 0)
                {
                    ddlTab3ExternalWalls.DataSource = ds.Tables[14].DefaultView;
                    ddlTab3ExternalWalls.DataTextField = "Name";
                    ddlTab3ExternalWalls.DataValueField = "Name";
                    ddlTab3ExternalWalls.DataBind();
                }
                ddlTab3ExternalWalls.Items.Insert(0, new ListItem("Select One", "0"));
                ddlTab3ExternalWalls.SelectedValue = "0";

                //Roof
                if (ds != null && ds.Tables.Count > 15 && ds.Tables[15].Rows.Count > 0)
                {
                    ddltab3Roof.DataSource = ds.Tables[15].DefaultView;
                    ddltab3Roof.DataTextField = "Name";
                    ddltab3Roof.DataValueField = "Name";
                    ddltab3Roof.DataBind();
                }
                ddltab3Roof.Items.Insert(0, new ListItem("Select One", "0"));
                ddltab3Roof.SelectedValue = "0";

                //Wall Linings
                if (ds != null && ds.Tables.Count > 16 && ds.Tables[16].Rows.Count > 0)
                {
                    ddlTab3InteriorLinings.DataSource = ds.Tables[16].DefaultView;
                    ddlTab3InteriorLinings.DataTextField = "Name";
                    ddlTab3InteriorLinings.DataValueField = "Name";
                    ddlTab3InteriorLinings.DataBind();
                }
                ddlTab3InteriorLinings.Items.Insert(0, new ListItem("Select One", "0"));
                ddlTab3InteriorLinings.SelectedValue = "0";

                //Main Flooring
                if (ds != null && ds.Tables.Count > 17 && ds.Tables[17].Rows.Count > 0)
                {
                    ddlTab3MainFlooring.DataSource = ds.Tables[17].DefaultView;
                    ddlTab3MainFlooring.DataTextField = "Name";
                    ddlTab3MainFlooring.DataValueField = "Name";
                    ddlTab3MainFlooring.DataBind();
                }
                ddlTab3MainFlooring.Items.Insert(0, new ListItem("Select One", "0"));
                ddlTab3MainFlooring.SelectedValue = "0";

                //Window Frames
                if (ds != null && ds.Tables.Count > 18 && ds.Tables[18].Rows.Count > 0)
                {
                    ddlTab3WindowFrames.DataSource = ds.Tables[18].DefaultView;
                    ddlTab3WindowFrames.DataTextField = "Name";
                    ddlTab3WindowFrames.DataValueField = "Name";
                    ddlTab3WindowFrames.DataBind();
                }
                ddlTab3WindowFrames.Items.Insert(0, new ListItem("Select One", "0"));
                ddlTab3WindowFrames.SelectedValue = "0";

                //Internal Condition
                if (ds != null && ds.Tables.Count > 19 && ds.Tables[19].Rows.Count > 0)
                {
                    ddlTab3InternalCondition.DataSource = ds.Tables[19].DefaultView;
                    ddlTab3InternalCondition.DataTextField = "Name";
                    ddlTab3InternalCondition.DataValueField = "Name";
                    ddlTab3InternalCondition.DataBind();
                }
                ddlTab3InternalCondition.Items.Insert(0, new ListItem("Select One", "0"));
                ddlTab3InternalCondition.SelectedValue = "0";

                //External Condition
                if (ds != null && ds.Tables.Count > 20 && ds.Tables[20].Rows.Count > 0)
                {
                    ddlTab3ExternalCondition.DataSource = ds.Tables[20].DefaultView;
                    ddlTab3ExternalCondition.DataTextField = "Name";
                    ddlTab3ExternalCondition.DataValueField = "Name";
                    ddlTab3ExternalCondition.DataBind();
                }
                ddlTab3ExternalCondition.Items.Insert(0, new ListItem("Select One", "0"));
                ddlTab3ExternalCondition.SelectedValue = "0";

                //Street Appeal
                if (ds != null && ds.Tables.Count > 21 && ds.Tables[21].Rows.Count > 0)
                {
                    ddlTab3StreetAppeal.DataSource = ds.Tables[21].DefaultView;
                    ddlTab3StreetAppeal.DataTextField = "Name";
                    ddlTab3StreetAppeal.DataValueField = "Name";
                    ddlTab3StreetAppeal.DataBind();
                }
                ddlTab3StreetAppeal.Items.Insert(0, new ListItem("Select One", "0"));
                ddlTab3StreetAppeal.SelectedValue = "0";


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
        #endregion
        public void SetDefaultText()
        {
            txtTab1Instructions.Text = "Instructions were received to determine the current fair market value of the subject property for " + ddlPurpose.SelectedItem.Text + " purposes as at the date of valuation.";

            //txtTab6Instructions.Text = "Instructions were received to determine the current fair market value of the subject property for " + ddlPurpose.SelectedValue + " purposes as at the date of valuation.";
            //txtTab6Standard.Text = "The subject property is a 2 bedroom dwelling, built in circa 1965 of brick construction with steel roof, single carport, iron shed with basic lawns and gardens.  \r\rInternally the dwelling provides an average level of accommodation with partially upgraded fixtures and fittings throughout. Internal features of the dwelling include...  \r\rExternally the home presents in an average condition and is considered typical for its age, style and in comparison to surrounding homes.";
            //txtTab6LastSaleofProperty.Text = "";
            //txtTab6Defects.Text = "";
            //txtTab6Methodology.Text = "In assessing the market value of the property we have regard to sales of properties in the surrounding area.  \r\rThe sales evidence provided in this report is considered to be representative of the real estate market in the Heidelberg Heights and surrounding area over the past 12 months.\r\rThe sales chosen are properties of slightly inferior, slightly superior and comparable standard based on age, size of land, size dwelling, level of ancillary (external) improvements, location and overall appeal and level of establishment.";
            //txtTab6Closing.Text = "We have been able to identify the market range for the subject property based on our research and the sales analysed in this report.  \r\rThe assessed market range of the property is between ${000,000} and ${000,000}.  \r\rBased on our analysis we have adopted ${marketvalue replace} as the fair market value of the subject property. \r\r{MARKET VALUE:}";

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
                    ddlTab2PropertyType.DataSource = ds.Tables[0].DefaultView;
                    ddlTab2PropertyType.DataTextField = "PropertyTypeName";
                    ddlTab2PropertyType.DataValueField = "PropertyTypeName";
                    ddlTab2PropertyType.DataBind();
                }
                ddlTab2PropertyType.Items.Insert(0, new ListItem("Select Property Type", "0"));
                ddlTab2PropertyType.SelectedValue = "0";
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
                    ddlPurpose.DataValueField = "LookupId";
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

        protected void ddlPurpose_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtTab6Instructions.Text = "Instructions were received to determine the current fair market value of the subject property for " + ddlPurpose.SelectedItem.Text + " purposes as at the date of valuation.";
            txtTab1Instructions.Text = "Instructions were received to determine the current fair market value of the subject property for " + ddlPurpose.SelectedItem.Text + " purposes as at the date of valuation.";
        }

        #region Menu
        public void SetNotSelectedTD()
        {
            tdTab1Summary.Attributes.Add("class", "TDNotSelected");
            tdTab2Land.Attributes.Add("class", "TDNotSelected");
            tdTab3BuildingImprovements.Attributes.Add("class", "TDNotSelected");
            tdTab4RoomsFixtures.Attributes.Add("class", "TDNotSelected");
            tdTab5Area.Attributes.Add("class", "TDNotSelected");
            tdTab6Comments.Attributes.Add("class", "TDNotSelected");
            tdTab7SalesEvidence.Attributes.Add("class", "TDNotSelected");
            tdTab8Attachments.Attributes.Add("class", "TDNotSelected");

            tblTab1Summary.Visible = false;
            tblTab2Land.Visible = false;
            tblTab3BuildingImprovements.Visible = false;
            tblTab4RoomsFixtures.Visible = false;
            tblTab5Area.Visible = false;
            tblTab6Comments.Visible = false;
            tblTab7SalesEvidence.Visible = false;
            tblTab8Attachments.Visible = false;
        }
        public void SetSelectedTD()
        {
            if (Session["TDReportSelected"] != null && Convert.ToString(Session["TDReportSelected"]) == "Tab1Summary")
            {
                hdnStatus.Value = "1";
                tdTab1Summary.Attributes.Add("class", "TDSelected");
                tblTab1Summary.Visible = true;
                FillTab1Summary();
            }
            else if (Session["TDReportSelected"] != null && Convert.ToString(Session["TDReportSelected"]) == "Tab2Land")
            {
                hdnStatus.Value = "2";
                tdTab2Land.Attributes.Add("class", "TDSelected");
                tblTab2Land.Visible = true;
                FillTab2Land();
            }
            else if (Session["TDReportSelected"] != null && Convert.ToString(Session["TDReportSelected"]) == "Tab3BuildingImprovements")
            {
                hdnStatus.Value = "3";
                tdTab3BuildingImprovements.Attributes.Add("class", "TDSelected");
                tblTab3BuildingImprovements.Visible = true;
                FillTab3BuildingandImprovements();
            }
            else if (Session["TDReportSelected"] != null && Convert.ToString(Session["TDReportSelected"]) == "Tab4RoomsFixtures")
            {
                hdnStatus.Value = "4";
                tdTab4RoomsFixtures.Attributes.Add("class", "TDSelected");
                tblTab4RoomsFixtures.Visible = true;
                FillTab4RoomsandFixtures();
            }
            else if (Session["TDReportSelected"] != null && Convert.ToString(Session["TDReportSelected"]) == "Tab5Area")
            {
                hdnStatus.Value = "5";
                tdTab5Area.Attributes.Add("class", "TDSelected");
                tblTab5Area.Visible = true;
                FillTab5Area();
            }
            else if (Session["TDReportSelected"] != null && Convert.ToString(Session["TDReportSelected"]) == "Tab6Comments")
            {
                hdnStatus.Value = "6";
                tdTab6Comments.Attributes.Add("class", "TDSelected");
                tblTab6Comments.Visible = true;
                FillTab6Comments();
            }
            else if (Session["TDReportSelected"] != null && Convert.ToString(Session["TDReportSelected"]) == "Tab7SalesEvidence")
            {
                hdnStatus.Value = "7";
                tdTab7SalesEvidence.Attributes.Add("class", "TDSelected");
                tblTab7SalesEvidence.Visible = true;
                FillTab7SalesDetails();
            }
            else if (Session["TDReportSelected"] != null && Convert.ToString(Session["TDReportSelected"]) == "Tab8Attachments")
            {
                hdnStatus.Value = "8";
                tdTab8Attachments.Attributes.Add("class", "TDSelected");
                tblTab8Attachments.Visible = true;
                lbtnTab8PrimaryPhoto_Click(null, null);
            }
            else
            {
                hdnStatus.Value = "1";
                tdTab1Summary.Attributes.Add("class", "TDSelected");
                tblTab1Summary.Visible = true;
                FillTab1Summary();
            }
        }
        protected void lbtnTab1Summary_Click(object sender, EventArgs e)
        {
            SaveTabsData();
            SetNotSelectedTD();
            Session["TDReportSelected"] = "Tab1Summary";
            SetSelectedTD();
            hdnStatus.Value = "1";
            FillTab1Summary();
        }

        protected void lbtnTab2Land_Click(object sender, EventArgs e)
        {
            SaveTabsData();
            SetNotSelectedTD();
            Session["TDReportSelected"] = "Tab2Land";
            SetSelectedTD();
            hdnStatus.Value = "2";
            FillTab2Land();
        }

        protected void lbtnTab3BuildingImprovements_Click(object sender, EventArgs e)
        {
            SaveTabsData();
            SetNotSelectedTD();
            Session["TDReportSelected"] = "Tab3BuildingImprovements";
            SetSelectedTD();
            hdnStatus.Value = "3";
            FillTab3BuildingandImprovements();
        }

        protected void lbtnTab4RoomsFixtures_Click(object sender, EventArgs e)
        {
            SaveTabsData();
            SetNotSelectedTD();
            Session["TDReportSelected"] = "Tab4RoomsFixtures";
            SetSelectedTD();
            hdnStatus.Value = "4";
            //FillTab4RoomsandFixtures();
        }

        protected void lbtnTab5Area_Click(object sender, EventArgs e)
        {
            SaveTabsData();
            SetNotSelectedTD();
            Session["TDReportSelected"] = "Tab5Area";
            SetSelectedTD();
            hdnStatus.Value = "5";
            FillTab5Area();
        }

        protected void lbtnTab6Comments_Click(object sender, EventArgs e)
        {
            SaveTabsData();
            SetNotSelectedTD();
            Session["TDReportSelected"] = "Tab6Comments";
            SetSelectedTD();
            hdnStatus.Value = "6";
            FillTab6Comments();
        }

        protected void lbtnTab7SalesEvidence_Click(object sender, EventArgs e)
        {
            SaveTabsData();
            SetNotSelectedTD();
            Session["TDReportSelected"] = "Tab7SalesEvidence";
            SetSelectedTD();
            hdnStatus.Value = "7";
            FillTab7SalesDetails();
        }

        protected void lbtnTab8Attachments_Click(object sender, EventArgs e)
        {
            SaveTabsData();
            SetNotSelectedTD();
            Session["TDReportSelected"] = "Tab8Attachments";
            SetSelectedTD();
            hdnStatus.Value = "8";
            HideTab8InnerTables();
            tblTab8Primary.Visible = true;
            lbtnTab8Primary.Font.Bold = true;
            lbtnTab8PrimaryPhoto_Click(null, null);

        }
        #endregion

        #region Tab 1
        public void FillTab1Summary()
        {
            ReportController objReportController = new ReportController();
            DataSet ds = new DataSet();
            try
            {
                ds = objReportController.Tab1_SummarySelect(Convert.ToInt64(lblJobId.Text));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtUnitLot.Text = Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]);
                    txtStreetNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]);
                    txtStreetName.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]);
                    txtStreetType.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]);
                    txtSuburb.Text = Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]);
                    txtPostcode.Text = Convert.ToString(ds.Tables[0].Rows[0]["Postcode"]);
                    ddlState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["State"]);

                    lblPropertyAddress.Text = txtStreetNumber.Text + " " + txtStreetName.Text + " " + txtStreetType.Text + ", " +
                        txtSuburb.Text + "&nbsp;&nbsp;" + ddlState.SelectedValue + "&nbsp;&nbsp;" + txtPostcode.Text;

                    //ddlPurpose.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Purpose"]);

                    string purposeId = ds.Tables[0].Rows[0]["Purpose"].ToString();
                    if (!string.IsNullOrEmpty(purposeId))
                    {
                        if (this.ddlPurpose.Items.IndexOf(this.ddlPurpose.Items.FindByValue(purposeId)) < 0)
                        {
                            this.ddlPurpose.SelectedIndex = this.ddlPurpose.Items.IndexOf(this.ddlPurpose.Items.FindByText(purposeId));
                        }
                        else
                        {
                            this.ddlPurpose.SelectedIndex = this.ddlPurpose.Items.IndexOf(this.ddlPurpose.Items.FindByValue(purposeId));
                        }
                    }

                    string valuationApproachId = ds.Tables[0].Rows[0]["valuationApproachId"].ToString();
                    if (!string.IsNullOrEmpty(valuationApproachId))
                    {
                        this.ddlValuationApproach.SelectedIndex = this.ddlValuationApproach.Items.IndexOf(this.ddlValuationApproach.Items.FindByValue(valuationApproachId));
                    }


                    txtTab6InstructionsOld.Text = Convert.ToString(ds.Tables[0].Rows[0]["Instructions"]);
                    //"Instructions were received to determine the current fair market value of the subject property for " + ddlPurpose.SelectedValue + " purposes as at the date of valuation.";
                    txtTab1Instructions.Text = Convert.ToString(ds.Tables[0].Rows[0]["Instructions"]); //"Instructions were received to determine the current fair market value of the subject property for " + ddlPurpose.SelectedValue + " purposes as at the date of valuation.";

                    txtClient.Text = Convert.ToString(ds.Tables[0].Rows[0]["Client"]);
                    txtInstructedBy.Text = Convert.ToString(ds.Tables[0].Rows[0]["InstructedBy"]);
                    if (Convert.ToString(ds.Tables[0].Rows[0]["InspectionDate"]) != "")
                    {
                        txtInspectionDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["InspectionDate"]).ToString("dd/MM/yyyy");
                        txtValuationsDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ValuationsDate"]).ToString("dd/MM/yyyy");
                    }
                    ddlValueComponent.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValueComponent"]);
                    txtLandValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["LandValue"]);
                    txtImprovements.Text = Convert.ToString(ds.Tables[0].Rows[0]["Improvements"]);
                    txtMarketValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["MarketValue"]);
                }
                else
                {
                    ds = objReportController.JobsSelectByJobId(Convert.ToInt64(lblJobId.Text));
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        txtUnitLot.Text = Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]);
                        txtStreetNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]);
                        txtStreetName.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]);
                        txtStreetType.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]);
                        txtSuburb.Text = Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]);
                        txtPostcode.Text = Convert.ToString(ds.Tables[0].Rows[0]["Postcode"]);
                        ddlState.Text = Convert.ToString(ds.Tables[0].Rows[0]["State"]);

                        lblPropertyAddress.Text = txtStreetNumber.Text + " " + txtStreetName.Text + " " + txtStreetType.Text + ", " +
                        txtSuburb.Text + "&nbsp;&nbsp;" + ddlState.SelectedValue + "&nbsp;&nbsp;" + txtPostcode.Text;

                        string purposeId = ds.Tables[0].Rows[0]["Purpose"].ToString();
                        if (!string.IsNullOrEmpty(purposeId))
                        {
                            this.ddlPurpose.SelectedIndex = this.ddlPurpose.Items.IndexOf(this.ddlPurpose.Items.FindByValue(purposeId));
                        }

                        txtTab6InstructionsOld.Text = "Instructions were received to determine the current fair market value of the subject property for " + ddlPurpose.SelectedItem.Text + " purposes as at the date of valuation.";
                        txtTab1Instructions.Text = "Instructions were received to determine the current fair market value of the subject property for " + ddlPurpose.SelectedItem.Text + " purposes as at the date of valuation.";

                        txtClient.Text = Convert.ToString(ds.Tables[0].Rows[0]["CustomerFullName"]);
                        txtInstructedBy.Text = Convert.ToString(ds.Tables[0].Rows[0]["InstructedBy"]);
                        if (Convert.ToString(ds.Tables[0].Rows[0]["InspectedOn"]) != "")
                        {
                            txtInspectionDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["InspectedOn"]).ToString("dd/MM/yyyy");
                            txtValuationsDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["InspectedOn"]).ToString("dd/MM/yyyy");
                        }
                        txtInstructedBy.Text = Convert.ToString(ds.Tables[0].Rows[0]["ClientName"]);
                        txtMarketValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["QuoteFee"]);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
                ds = null;
            }
        }
        protected void btnTab1Submit_Click(object sender, EventArgs e)
        {
            tblTab1Summary.Visible = false;
            tblTab2Land.Visible = true;
            lbtnTab2Land_Click(null, null);
        }
        #endregion

        #region Tab 2
        public void FillTab2Land()
        {
            ReportController objReportController = new ReportController();
            DataSet ds = new DataSet();
            try
            {
                ds = objReportController.Tab2_LandSelect(Convert.ToInt64(lblJobId.Text));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlTab2PropertyType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PropertyType"]);
                    ddlTab2PropertyIdentification.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PropertyIdentification"]);
                    ddlTab2TitleSearch.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TitleSearch"]);
                    txtTab2LotNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["LotNumber"]);
                    txtTab2PlanNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["PlanNumber"]);
                    txtTab2PlanText.Text = Convert.ToString(ds.Tables[0].Rows[0]["PlanTitle"]);
                    ddlTab2Plan.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PlanTitle"]);
                    txtTab2Volume.Text = Convert.ToString(ds.Tables[0].Rows[0]["Volume"]);
                    txtTab2Folio.Text = Convert.ToString(ds.Tables[0].Rows[0]["Folio"]);
                    txtTab2RegisteredProprietors.Text = Convert.ToString(ds.Tables[0].Rows[0]["RegisteredProprietors"]);
                    txtTab2Encumbrances.Text = Convert.ToString(ds.Tables[0].Rows[0]["Encumbrances"]);
                    txtTab2SiteArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["SiteArea"]);
                    ddlTab2SqmHectares.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SqmHectares"]);
                    txtTab2LocalGovernmentArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["LocalGovernmentArea"]);
                    txtTab2Zoning.Text = Convert.ToString(ds.Tables[0].Rows[0]["Zoning"]);
                    txtTab2Overlays.Text = Convert.ToString(ds.Tables[0].Rows[0]["Overlays"]);
                    ddlTab2ZoningEffect.Text = Convert.ToString(ds.Tables[0].Rows[0]["ZoningEffect"]);
                    txtTab2Transport.Text = Convert.ToString(ds.Tables[0].Rows[0]["Shops"]);
                    txtTab2Schools.Text = Convert.ToString(ds.Tables[0].Rows[0]["Transport"]);
                    txtTab2Shops.Text = Convert.ToString(ds.Tables[0].Rows[0]["Schools"]);
                    txtTab2CBD.Text = Convert.ToString(ds.Tables[0].Rows[0]["CBD"]);
                    txtTab2SiteLayout.Text = Convert.ToString(ds.Tables[0].Rows[0]["SiteLayout"]);
                    ddltab2Services.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Services"]);
                    ddlTab2EnvironmentalHazards.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["EnvironmentalHazards"]);
                    ddlTab2PestInfestation.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PestInfestation"]);
                }
                else
                {
                    ds = objReportController.JobsSelectByJobId(Convert.ToInt64(lblJobId.Text));
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        ddlTab2PropertyType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PropertyTypeName"]);
                        //ddlTab2PropertyIdentification.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PropertyIdentification"]);
                        //ddlTab2TitleSearch.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TitleSearch"]);
                        //txtTab2LotNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["LotNumber"]);
                        //txtTab2PlanNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["PlanNumber"]);
                        //txtTab2Volume.Text = Convert.ToString(ds.Tables[0].Rows[0]["Volume"]);
                        //txtTab2Folio.Text = Convert.ToString(ds.Tables[0].Rows[0]["Folio"]);
                        //txtTab2RegisteredProprietors.Text = Convert.ToString(ds.Tables[0].Rows[0]["RegisteredProprietors"]);
                        //txtTab2Encumbrances.Text = Convert.ToString(ds.Tables[0].Rows[0]["Encumbrances"]);
                        //txtTab2SiteArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["SiteArea"]);
                        //ddlTab2SqmHectares.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SqmHectares"]);
                        //txtTab2LocalGovernmentArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["LocalGovernmentArea"]);
                        //txtTab2Zoning.Text = Convert.ToString(ds.Tables[0].Rows[0]["Zoning"]);
                        //txtTab2Overlays.Text = Convert.ToString(ds.Tables[0].Rows[0]["Overlays"]);
                        //ddlTab2ZoningEffect.Text = Convert.ToString(ds.Tables[0].Rows[0]["ZoningEffect"]);
                        //txtTab2Transport.Text = Convert.ToString(ds.Tables[0].Rows[0]["Shops"]);
                        //txtTab2Schools.Text = Convert.ToString(ds.Tables[0].Rows[0]["Transport"]);
                        //txtTab2Shops.Text = Convert.ToString(ds.Tables[0].Rows[0]["Schools"]);
                        //txtTab2CBD.Text = Convert.ToString(ds.Tables[0].Rows[0]["CBD"]);
                        //txtTab2SiteLayout.Text = Convert.ToString(ds.Tables[0].Rows[0]["SiteLayout"]);
                        //ddltab2Services.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Services"]);
                        //ddlTab2EnvironmentalHazards.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["EnvironmentalHazards"]);
                        //ddlTab2PestInfestation.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PestInfestation"]);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
                ds = null;
            }
        }
        protected void btnTab2Next_Click(object sender, EventArgs e)
        {
            tblTab2Land.Visible = false;
            tblTab3BuildingImprovements.Visible = true;
            lbtnTab3BuildingImprovements_Click(null, null);

        }
        protected void btnTab2Back_Click(object sender, EventArgs e)
        {
            tblTab1Summary.Visible = true;
            tblTab2Land.Visible = false;
            lbtnTab1Summary_Click(null, null);
        }
        #endregion

        #region Tab 3
        public void FillTab3BuildingandImprovements()
        {
            ReportController objReportController = new ReportController();
            DataSet ds = new DataSet();
            try
            {
                ds = objReportController.Tab3_BuildingImprovementsSelect(Convert.ToInt64(lblJobId.Text));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlTab3PropertyStyle.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PropertyStyle"]);
                    txtTab3YearBuilt.Text = Convert.ToString(ds.Tables[0].Rows[0]["YearBuilt"]);
                    ddlTab3ExternalWalls.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ExternalWalls"]);
                    ddltab3Roof.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Roof"]);
                    ddlTab3InteriorLinings.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["InteriorLinings"]);
                    ddlTab3MainFlooring.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["MainFlooring"]);
                    ddlTab3WindowFrames.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["WindowFrames"]);
                    ddlTab3InternalCondition.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["InternalCondition"]);
                    ddlTab3ExternalCondition.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ExternalCondition"]);
                    ddlTab3StreetAppeal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["StreetAppeal"]);
                    //chkTab3PergolaVerandah
                    string[] strPergolaVerandah = Convert.ToString(ds.Tables[0].Rows[0]["PergolaVerandah"]).Split('@');
                    for (int i = 0; i < strPergolaVerandah.Length; i++)
                    {
                        for (int j = 0; j < chkTab3PergolaVerandah.Items.Count; j++)
                        {
                            if (strPergolaVerandah[i].ToString() == chkTab3PergolaVerandah.Items[j].Value.ToString())
                                chkTab3PergolaVerandah.Items[j].Selected = true;
                        }
                    }
                    //chkTab3Shedding
                    string[] strShedding = Convert.ToString(ds.Tables[0].Rows[0]["Shedding"]).Split('@');
                    for (int i = 0; i < strShedding.Length; i++)
                    {
                        for (int j = 0; j < chkTab3Shedding.Items.Count; j++)
                        {
                            if (strShedding[i].ToString() == chkTab3Shedding.Items[j].Value.ToString())
                                chkTab3Shedding.Items[j].Selected = true;
                        }
                    }
                    //chkTab3Pools
                    string[] strPools = Convert.ToString(ds.Tables[0].Rows[0]["Pools"]).Split('@');
                    for (int i = 0; i < strPools.Length; i++)
                    {
                        for (int j = 0; j < chkTab3Pools.Items.Count; j++)
                        {
                            if (strPools[i].ToString() == chkTab3Pools.Items[j].Value.ToString())
                                chkTab3Pools.Items[j].Selected = true;
                        }
                    }
                    //chkTab3Gardens
                    string[] strGardens = Convert.ToString(ds.Tables[0].Rows[0]["Gardens"]).Split('@');
                    for (int i = 0; i < strGardens.Length; i++)
                    {
                        for (int j = 0; j < chkTab3Gardens.Items.Count; j++)
                        {
                            if (strGardens[i].ToString() == chkTab3Gardens.Items[j].Value.ToString())
                                chkTab3Gardens.Items[j].Selected = true;
                        }
                    }
                    //chkTab3Fencing
                    string[] strFencing = Convert.ToString(ds.Tables[0].Rows[0]["Fencing"]).Split('@');
                    for (int i = 0; i < strFencing.Length; i++)
                    {
                        for (int j = 0; j < chkTab3Fencing.Items.Count; j++)
                        {
                            if (strFencing[i].ToString() == chkTab3Fencing.Items[j].Value.ToString())
                                chkTab3Fencing.Items[j].Selected = true;
                        }
                    }
                    //chkTab3DrivewayPaving
                    string[] strDrivewayPaving = Convert.ToString(ds.Tables[0].Rows[0]["DrivewayPaving"]).Split('@');
                    for (int i = 0; i < strDrivewayPaving.Length; i++)
                    {
                        for (int j = 0; j < chkTab3DrivewayPaving.Items.Count; j++)
                        {
                            if (strDrivewayPaving[i].ToString() == chkTab3DrivewayPaving.Items[j].Value.ToString())
                                chkTab3DrivewayPaving.Items[j].Selected = true;
                        }
                    }
                    //chkTab3Outbuildings
                    string[] strOutbuildings = Convert.ToString(ds.Tables[0].Rows[0]["Outbuildings"]).Split('@');
                    for (int i = 0; i < strOutbuildings.Length; i++)
                    {
                        for (int j = 0; j < chkTab3Outbuildings.Items.Count; j++)
                        {
                            if (strOutbuildings[i].ToString() == chkTab3Outbuildings.Items[j].Value.ToString())
                                chkTab3Outbuildings.Items[j].Selected = true;
                        }
                    }

                    txtTab3AncillaryImprovements.Text = Convert.ToString(ds.Tables[0].Rows[0]["AncillaryImprovements"]);
                }
                else
                {
                    ds = objReportController.JobsSelectByJobId(Convert.ToInt64(lblJobId.Text));
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {

                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
                ds = null;
            }
        }
        protected void btnTab3Next_Click(object sender, EventArgs e)
        {
            tblTab3BuildingImprovements.Visible = false;
            tblTab4RoomsFixtures.Visible = true;
            lbtnTab4RoomsFixtures_Click(null, null);
        }
        protected void btnTab3Back_Click(object sender, EventArgs e)
        {
            tblTab2Land.Visible = true;
            tblTab3BuildingImprovements.Visible = false;
            lbtnTab2Land_Click(null, null);
        }
        #endregion

        #region Tab 4
        public void FillTab4RoomsandFixtures()
        {
            ReportController objReportController = new ReportController();
            DataSet ds = new DataSet();
            try
            {
                ds = objReportController.Tab4_RoomsFixtures(Convert.ToInt64(lblJobId.Text));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    //chkTab3PergolaVerandah
                    string[] strRooms1 = Convert.ToString(ds.Tables[0].Rows[0]["Rooms1"]).Split('@');
                    for (int i = 0; i < strRooms1.Length; i++)
                    {
                        for (int j = 0; j < chkTab4Rooms1.Items.Count; j++)
                        {
                            if (strRooms1[i].ToString() == chkTab4Rooms1.Items[j].Value.ToString())
                                chkTab4Rooms1.Items[j].Selected = true;
                        }
                    }
                    //chkTab3Shedding
                    string[] strRooms2 = Convert.ToString(ds.Tables[0].Rows[0]["Rooms2"]).Split('@');
                    for (int i = 0; i < strRooms2.Length; i++)
                    {
                        for (int j = 0; j < chkTab4Rooms2.Items.Count; j++)
                        {
                            if (strRooms2[i].ToString() == chkTab4Rooms2.Items[j].Value.ToString())
                                chkTab4Rooms2.Items[j].Selected = true;
                        }
                    }
                    //chkTab3Pools
                    string[] strRooms3 = Convert.ToString(ds.Tables[0].Rows[0]["Rooms3"]).Split('@');
                    for (int i = 0; i < strRooms3.Length; i++)
                    {
                        for (int j = 0; j < chkTab4Rooms3.Items.Count; j++)
                        {
                            if (strRooms3[i].ToString() == chkTab4Rooms3.Items[j].Value.ToString())
                                chkTab4Rooms3.Items[j].Selected = true;
                        }
                    }
                    //chkTab3Gardens
                    string[] strRooms4 = Convert.ToString(ds.Tables[0].Rows[0]["Rooms4"]).Split('@');
                    for (int i = 0; i < strRooms4.Length; i++)
                    {
                        for (int j = 0; j < chkTab4Rooms4.Items.Count; j++)
                        {
                            if (strRooms4[i].ToString() == chkTab4Rooms4.Items[j].Value.ToString())
                                chkTab4Rooms4.Items[j].Selected = true;
                        }
                    }

                    if (Convert.ToString(ds.Tables[0].Rows[0]["Bedroom"]) != "0")
                    {
                        ddlTab4Bedroom.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Bedroom"]);
                        chkTab4Bedroom.Items[0].Selected = true;
                    }

                    if (Convert.ToString(ds.Tables[0].Rows[0]["Bathroom"]) != "0")
                    {
                        ddlTab4Bathroom.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Bathroom"]);
                        chkTab4Bathroom.Items[0].Selected = true;
                    }

                    if (Convert.ToString(ds.Tables[0].Rows[0]["Ensuite"]) != "0")
                    {
                        ddlTab4Ensuite.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Ensuite"]);
                        chkTab4Ensuite.Items[0].Selected = true;
                    }

                    if (Convert.ToString(ds.Tables[0].Rows[0]["Toilet"]) != "0")
                    {
                        ddlTab4Toilet.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Toilet"]);
                        chkTab4Toilet.Items[0].Selected = true;
                    }


                    if (Convert.ToString(ds.Tables[0].Rows[0]["Laundry"]) != "")
                        chkTab4Laundry.Items[0].Selected = true;

                    Tab4Text1.Text = Convert.ToString(ds.Tables[0].Rows[0]["Text1"]);

                    //chkTab3Fencing
                    string[] strHeatingCooling = Convert.ToString(ds.Tables[0].Rows[0]["HeatingCooling"]).Split('@');
                    for (int i = 0; i < strHeatingCooling.Length; i++)
                    {
                        if (strHeatingCooling[i].ToString().Trim() != "")
                        {
                            for (int j = 0; j < chkTab4HeatingCooling.Items.Count; j++)
                            {
                                if (strHeatingCooling[i].ToString() == chkTab4HeatingCooling.Items[j].Value.ToString())
                                {
                                    chkTab4HeatingCooling.Items[j].Selected = true;
                                    break;
                                }
                            }
                        }
                    }

                }
                else
                {
                    ds = objReportController.JobsSelectByJobId(Convert.ToInt64(lblJobId.Text));
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {

                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
                ds = null;
            }
        }
        protected void btnTab4UploadPhoto_Click(object sender, EventArgs e)
        {

        }
        protected void btnTab4Next_Click(object sender, EventArgs e)
        {
            tblTab4RoomsFixtures.Visible = false;
            tblTab5Area.Visible = true;
            lbtnTab5Area_Click(null, null);

        }
        protected void btnTab4Back_Click(object sender, EventArgs e)
        {
            tblTab3BuildingImprovements.Visible = true;
            tblTab4RoomsFixtures.Visible = false;
            lbtnTab3BuildingImprovements_Click(null, null);
        }
        #endregion

        #region Tab 5
        public void FillTab5Area()
        {
            ReportController objReportController = new ReportController();
            DataSet ds = new DataSet();
            try
            {
                ds = objReportController.Tab5_AreasSelect(Convert.ToInt64(lblJobId.Text));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtTab5LivingArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["LivingArea"]);
                    ddlTab5SqmEq.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SqmEq"]);
                    txtTab5Garage.Text = Convert.ToString(ds.Tables[0].Rows[0]["Garage"]);
                    txtTab5Carport.Text = Convert.ToString(ds.Tables[0].Rows[0]["Carport"]);
                    txtTab5CarSpaces.Text = Convert.ToString(ds.Tables[0].Rows[0]["CarSpaces"]);
                    txtTab5Balcony.Text = Convert.ToString(ds.Tables[0].Rows[0]["Balcony"]);
                    txtTab5Verandah.Text = Convert.ToString(ds.Tables[0].Rows[0]["Verandah"]);
                    txtTab5Alfresco.Text = Convert.ToString(ds.Tables[0].Rows[0]["Alfresco"]);
                    txtTab5Pergola.Text = Convert.ToString(ds.Tables[0].Rows[0]["Pergola"]);
                }
                else
                {
                    ds = objReportController.JobsSelectByJobId(Convert.ToInt64(lblJobId.Text));
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {

                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
                ds = null;
            }
        }
        protected void btnTab5Next_Click(object sender, EventArgs e)
        {
            tblTab5Area.Visible = false;
            tblTab6Comments.Visible = true;
            lbtnTab6Comments_Click(null, null);
        }
        protected void btnTab5Back_Click(object sender, EventArgs e)
        {
            tblTab4RoomsFixtures.Visible = true;
            tblTab5Area.Visible = false;
            lbtnTab4RoomsFixtures_Click(null, null);
        }
        #endregion

        #region Tab 6
        public void FillTab6Comments()
        {
            ReportController objReportController = new ReportController();
            DataSet ds = new DataSet();
            try
            {

                //Default at right side
                //txtTab6Instructions.Text = Convert.ToString(ds.Tables[0].Rows[0]["Instructions"]);
                string strAncillary = "";


                //chkTab3Shedding

                for (int i = 0; i < chkTab3Shedding.Items.Count; i++)
                {
                    if (chkTab3Shedding.Items[i].Selected == true)
                        strAncillary += chkTab3Shedding.Items[i].Value + ", ";
                }

                //chk Tab3 Pergola Verandah

                for (int i = 0; i < chkTab3PergolaVerandah.Items.Count; i++)
                {
                    if (chkTab3PergolaVerandah.Items[i].Selected == true)
                        strAncillary += chkTab3PergolaVerandah.Items[i].Value + ", ";
                }

                //chkTab3Pools

                for (int i = 0; i < chkTab3Pools.Items.Count; i++)
                {
                    if (chkTab3Pools.Items[i].Selected == true)
                        strAncillary += chkTab3Pools.Items[i].Value + ", ";
                }

                //chkTab3Fencing

                for (int i = 0; i < chkTab3Fencing.Items.Count; i++)
                {
                    if (chkTab3Fencing.Items[i].Selected == true)
                        strAncillary += chkTab3Fencing.Items[i].Value + ", ";
                }
                //chkTab3DrivewayPaving

                for (int i = 0; i < chkTab3DrivewayPaving.Items.Count; i++)
                {
                    if (chkTab3DrivewayPaving.Items[i].Selected == true)
                        strAncillary += chkTab3DrivewayPaving.Items[i].Value + ", ";
                }
                //chkTab3Outbuildings

                for (int i = 0; i < chkTab3Outbuildings.Items.Count; i++)
                {
                    if (chkTab3Outbuildings.Items[i].Selected == true)
                        strAncillary += chkTab3Outbuildings.Items[i].Value + ", ";
                }

                //chkTab3Gardens

                for (int i = 0; i < chkTab3Gardens.Items.Count; i++)
                {
                    if (chkTab3Gardens.Items[i].Selected == true)
                        strAncillary += chkTab3Gardens.Items[i].Value + ", ";
                }



                strAncillary = strAncillary.Trim();
                strAncillary = strAncillary.TrimEnd(',');
                strAncillary = strAncillary.TrimEnd(',');
                if (strAncillary != "")
                {
                    if (txtTab3AncillaryImprovements.Text.Trim() != "")
                        strAncillary = ", " + strAncillary + ", " + txtTab3AncillaryImprovements.Text.Trim() + ".";
                    else
                        strAncillary = ", " + strAncillary + ".";
                }
                strAncillary = strAncillary.Replace("..", ".");
                txtTab6InstructionsOld.Text = "Instructions were received to determine the current fair market value of the subject property for " + ddlPurpose.SelectedItem.Text + " purposes as at the date of valuation.";
                txtTab6StandardOld.Text = "The subject property is a " + ddlTab4Bedroom.SelectedValue + " bedroom " + ddlTab2PropertyType.SelectedValue + ", built in circa " + txtTab3YearBuilt.Text.Trim() + " of " + ddlTab3ExternalWalls.SelectedValue + " construction with " + ddltab3Roof.SelectedValue + " roof" + strAncillary + " \r\rInternally the " + ddlTab2PropertyType.SelectedValue + " presents in " + ddlTab3InternalCondition.SelectedValue + "\r\rExternally the property presents in " + ddlTab3ExternalCondition.SelectedValue;
                txtTab6MethodologyOld.Text = "The sales evidence provided in this report is considered to be representative of the real estate market in the " + txtSuburb.Text.Trim() + " and surrounding area over the 12 months prior to the noted valuation date.\r\rThe sales chosen are properties of slightly inferior, slightly superior and comparable standard where available.  Sales selected are based on age, size of land, size dwelling, level of ancillary (external) improvements, location and overall appeal and level of establishment.\r\rSales noted as inferior are homes that provide a price level that the subject property is considered to be above.  Sales noted as superior are homes that provide a price level that the subject property is considered to be under.\r\rHence superior and inferior sales are considered outside the price range of the subject property.  The price gap between these inferior and superior proprieties is considered to be the price range that the subject property falls into.\r\rAs a result the comparable properties (if any) noted in this report fit within this market range and are considered the most comparable properties available at the date of valuation.";
                txtTab6ClosingOld.Text = "We have been able to identify the market range for the subject property based on our research and the sales analysed in this report.  \r\rThe assessed market range of the property is between ${000,000} and ${000,000}.  \r\rBased on our analysis we have adopted $" + txtMarketValue.Text.Trim() + " as the fair market value of the subject property. \r\r$" + txtMarketValue.Text.Trim() + "";




                //Database values at left side

                ds = objReportController.Tab6_CommentsSelect(Convert.ToInt64(lblJobId.Text));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    //txtTab6LastSaleofProperty.Text = Convert.ToString(ds.Tables[0].Rows[0]["LastSaleofProperty"]);
                    //txtTab6Defects.Text = Convert.ToString(ds.Tables[0].Rows[0]["Defects"]);
                    txtTab6Methodology.Text = Convert.ToString(ds.Tables[0].Rows[0]["Methodology"]);// +"\r\r\rSale 1:\r{must be an inferior within 10% of assessed value}\r\rSale 2:\r{must be a comparable value}\r\rSale 3:\r{must be a superior within 10% of assessed value}";
                    //txtTab6Closing.Text = Convert.ToString(ds.Tables[0].Rows[0]["Closing"]);


                    txtTab6Instructions.Text = Convert.ToString(ds.Tables[0].Rows[0]["Instructions"]);
                    txtTab6Standard.Text = Convert.ToString(ds.Tables[0].Rows[0]["Standard"]);
                    txtTab6LastSaleofProperty.Text = Convert.ToString(ds.Tables[0].Rows[0]["LastSaleofProperty"]);
                    txtTab6Defects.Text = Convert.ToString(ds.Tables[0].Rows[0]["Defects"]);
                    txtTab6Methodology.Text = Convert.ToString(ds.Tables[0].Rows[0]["Methodology"]);
                    txtTab6Closing.Text = Convert.ToString(ds.Tables[0].Rows[0]["Closing"]);
                }

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
                ds = null;
            }
        }
        protected void btnTab6Next_Click(object sender, EventArgs e)
        {
            tblTab6Comments.Visible = false;
            tblTab7SalesEvidence.Visible = true;
            lbtnTab7SalesEvidence_Click(null, null);

        }
        protected void btnTab6Back_Click(object sender, EventArgs e)
        {
            tblTab5Area.Visible = true;
            tblTab6Comments.Visible = false;
            lbtnTab5Area_Click(null, null);
        }
        #endregion

        #region Tab 7
        public void FillTab7SalesDetails()
        {
            ReportController objReportController = new ReportController();
            DataSet ds = new DataSet();
            try
            {
                gvSalesDetails.Visible = false;
                ds = objReportController.Tab7_SalesEvidenceSelect(0, Convert.ToInt64(lblJobId.Text));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvSalesDetails.DataSource = ds.Tables[0].DefaultView;
                    gvSalesDetails.DataBind();
                    gvSalesDetails.Visible = true;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
                ds = null;
            }
        }
        protected void btnTab7AddSalesDetails_Click(object sender, EventArgs e)
        {
            ReportController objReportController = new ReportController();
            Int64 JobId = Convert.ToInt64(lblJobId.Text);
            try
            {
                string strFileName = "";
                if (fuTab7Photo.FileName.ToString() != "")
                {
                    if (!string.IsNullOrEmpty(fuTab7Photo.FileName))
                    {
                        fuTab7Photo.SaveAs(Server.MapPath("~/Tab7Files/" + fuTab7Photo.FileName.ToString()));
                        strFileName = DateTime.Now.ToString("MMddyyyyHHmmss") + "_SalesDetails" + Path.GetExtension(fuTab7Photo.FileName.ToString());
                        File.Move(Server.MapPath("~/Tab7Files/" + fuTab7Photo.FileName.ToString()), Server.MapPath("~/Tab7Files/" + strFileName));
                    }
                }

                JobId = objReportController.Tab7_SalesEvidenceEdit(0, JobId, "", DateTime.Now, "", "", "", "", "", "", "", "", "", "", "",
                    Convert.ToInt64(Session["UserId"]), "ADD", "Image", strFileName, ddlSalesCategory.SelectedValue);
                if (JobId > 0)
                {
                    lblTab7Error.Text = "Sales details uploaded successfully.";
                    FillTab7SalesDetails();
                }
                else
                {
                    lblTab7Error.Text = "Sales details doesnt uploaded successfully. Please try again.";
                    return;
                }
            }
            catch (Exception Ex)
            {
                lblTab7Error.Text = Ex.Message.ToString();
            }
            finally
            {
                objReportController = null;
            }
        }
        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnDelete = sender as ImageButton;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;
            ReportController objReportController = new ReportController();
            try
            {
                if (objReportController.Tab7_SalesEvidenceEdit(Convert.ToInt64(((Label)row.FindControl("lblId")).Text), 0,
                "", DateTime.Now, "", "", "", "", "", "", "", "", "", "", "", 0, "DELETE", "", "", "") > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Sales details deleted.');", true);
                    if (!string.IsNullOrEmpty(((Label)row.FindControl("lblImageName")).Text))
                    {
                        File.Delete(Server.MapPath("~/Tab7Files/" + ((Label)row.FindControl("lblImageName")).Text));
                    }
                    FillTab7SalesDetails();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Sales details does not deleted.');", true);
                    return;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
            }
        }
        protected void btnTab7Next_Click(object sender, EventArgs e)
        {
            tblTab7SalesEvidence.Visible = false;
            tblTab8Attachments.Visible = true;
            lbtnTab8Attachments_Click(null, null);
        }
        protected void btnTab7Back_Click(object sender, EventArgs e)
        {
            tblTab6Comments.Visible = true;
            tblTab7SalesEvidence.Visible = false;
            lbtnTab6Comments_Click(null, null);
        }
        #endregion

        #region Tab 8

        #region Tab 8 Menu
        protected void lbtnTab8PrimaryPhoto_Click(object sender, EventArgs e)
        {
            HideTab8InnerTables();
            tblTab8Primary.Visible = true;
            lbtnTab8Primary.Font.Bold = true;
            FillTab8PrimaryPhoto();
        }
        protected void lbtnTab8ExternalPhoto_Click(object sender, EventArgs e)
        {
            HideTab8InnerTables();
            tblTab8External.Visible = true;
            lbtnTab8External.Font.Bold = true;
            FillTab8ExternalPhoto();
        }
        protected void lbtnTab8InternalPhoto_Click(object sender, EventArgs e)
        {
            HideTab8InnerTables();
            tblTab8Internal.Visible = true;
            lbtnTab8Internal.Font.Bold = true;
            FillTab8InternalPhoto();
        }
        protected void lbtnTab8DefectPhoto_Click(object sender, EventArgs e)
        {
            HideTab8InnerTables();
            tblTab8Defect.Visible = true;
            lbtnTab8Defect.Font.Bold = true;
            FillTab8DefectPhoto();
        }
        protected void lbtnTab8TitlePhoto_Click(object sender, EventArgs e)
        {
            HideTab8InnerTables();
            tblTab8Title.Visible = true;
            lbtnTab8Title.Font.Bold = true;
            FillTab8TitlePhoto();
        }
        protected void lbtnTab8ZoningPhoto_Click(object sender, EventArgs e)
        {
            HideTab8InnerTables();
            tblTab8Zoning.Visible = true;
            lbtnTab8Zoning.Font.Bold = true;
            FillTab8ZoningPhoto();
        }
        protected void lbtnTab8OverlayPhoto_Click(object sender, EventArgs e)
        {
            HideTab8InnerTables();
            tblTab8Overlay.Visible = true;
            lbtnTab8Overlay.Font.Bold = true;
            FillTab8OverlayPhoto();
        }
        protected void lbtnTab8OthersPhoto_Click(object sender, EventArgs e)
        {
            HideTab8InnerTables();
            tblTab8Others.Visible = true;
            lbtnTab8Others.Font.Bold = true;
            FillTab8OthersPhoto();
        }
        public void HideTab8InnerTables()
        {
            tblTab8Primary.Visible = false;
            tblTab8External.Visible = false;
            tblTab8Internal.Visible = false;
            tblTab8Defect.Visible = false;
            tblTab8Title.Visible = false;
            tblTab8Zoning.Visible = false;
            tblTab8Overlay.Visible = false;
            tblTab8Others.Visible = false;
            tblTab8AddDocuments.Visible = false;

            lbtnTab8Primary.Font.Bold = false;
            lbtnTab8External.Font.Bold = false;
            lbtnTab8Internal.Font.Bold = false;
            lbtnTab8Defect.Font.Bold = false;
            lbtnTab8Title.Font.Bold = false;
            lbtnTab8Zoning.Font.Bold = false;
            lbtnTab8Overlay.Font.Bold = false;
            lbtnTab8Others.Font.Bold = false;
            lbtnTab8AddDocuments.Font.Bold = false;
        }
        #endregion

        #region Tab 8 Upload Photo
        public DataSet Tab8GetImages(string ImageType, Int64 jobId = 0)
        {
            ReportController objReportController = new ReportController();
            try
            {
                if (jobId < 1)
                {
                    jobId = Convert.ToInt64(lblJobId.Text);
                }
                return objReportController.Tab8_AttachmentsSelect(0, jobId, ImageType);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
            }
        }

        protected void btnTab8PrimaryPhoto_Click(object sender, EventArgs e)
        {
            ReportController objReportController = new ReportController();
            Int64 JobId = Convert.ToInt64(lblJobId.Text);
            try
            {
                //DataSet ds = Tab8GetImages("PrimaryPhoto");
                //if (ds.Tables[0] != null)
                //{ 
                //    foreach (DataRow dr in ds.Tables[0].Rows)
                //    {
                //        if (System.IO.File.Exists(Server.MapPath("~/Tab8Files/" + Convert.ToString(dr["ImageName"]))))
                //        {
                //            System.IO.File.Delete(Server.MapPath("~/Tab8Files/" + Convert.ToString(dr["ImageName"])));
                //        }
                //    }
                //}
                ////Delete images before upload
                //objReportController.Tab8_AttachmentsEdit(0, JobId, string.Empty, string.Empty, 0, "DELETE");

                HttpFileCollection fileCollection = Request.Files;
                for (int i = 0; i < fileCollection.Count; i++)
                {
                    HttpPostedFile uploadfile = fileCollection[i];
                    string ticks = DateTime.Now.Ticks.ToString();
                    string extension = Path.GetExtension(uploadfile.FileName);
                    string strFileName = ticks + "_Attachment" + extension;
                    ImageHandler.ResizeAndSaveImage(uploadfile, 680, 680, Server.MapPath("~/Tab8Files/" + strFileName));
                    objReportController.Tab8_AttachmentsEdit(0, JobId, strFileName, "PrimaryPhoto", Convert.ToInt64(Session["UserId"]), "ADD");
                }

                //string strFileName = "";
                //if (fuTab8Primary.FileName.ToString() != "")
                //{
                //    fuTab8Primary.SaveAs(Server.MapPath("~/Tab8Files/" + fuTab8Primary.FileName.ToString()));
                //    strFileName = DateTime.Now.ToString("MMddyyyyHHmmss") + "_Attachment" + Path.GetExtension(fuTab8Primary.FileName.ToString());
                //    strFileName = Server.MapPath("~/Tab8Files/" + strFileName);
                //    SetFile(fuTab8Primary, Server.MapPath("~/Tab8Files/" + fuTab8Primary.FileName.ToString()), strFileName);
                //    strFileName = Path.GetFileName(strFileName);

                //    ///File.Move(Server.MapPath("~/Tab8Files/" + fuTab8Primary.FileName.ToString()), Server.MapPath("~/Tab8Files/" + strFileName));
                //}

                if (JobId > 0)
                {
                    lblTab8Error.Text = "Photo(s) uploaded successfully.";
                    FillTab8PrimaryPhoto();
                }
                else
                {
                    lblTab8Error.Text = "Photo doesnt uploaded successfully. Please try again.";
                    return;
                }
            }
            catch (Exception Ex)
            {
                lblTab8Error.Text = Ex.Message.ToString();
            }
            finally
            {
                objReportController = null;
            }

        }
        public void FillTab8PrimaryPhoto()
        {
            ReportController objReportController = new ReportController();
            DataSet ds = new DataSet();
            try
            {
                gvTab8Primary.Visible = false;
                ds = Tab8GetImages("PrimaryPhoto");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvTab8Primary.DataSource = ds.Tables[0].DefaultView;
                    gvTab8Primary.DataBind();
                    gvTab8Primary.Visible = true;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
                ds = null;
            }
        }
        protected void btnTab8DeletePrimaryPhoto_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnDelete = sender as ImageButton;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;
            ReportController objReportController = new ReportController();
            try
            {
                if (objReportController.Tab8_AttachmentsEdit(Convert.ToInt64(((Label)row.FindControl("lblId")).Text), 0, "", "", 0, "DELETE") > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Photo details deleted.');", true);
                    if (!string.IsNullOrEmpty(((Label)row.FindControl("lblImageName")).Text))
                    {
                        File.Delete(Server.MapPath("~/Tab8Files/" + ((Label)row.FindControl("lblImageName")).Text));
                    }
                    FillTab8PrimaryPhoto();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Photo does not deleted.');", true);
                    return;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
            }
        }

        protected void btnTab8ExternalPhoto_Click(object sender, EventArgs e)
        {
            //HideTab8InnerTables();
            //tblTab8External.Visible = true;
            //lbtnTab8External.Font.Bold = true;
            ReportController objReportController = new ReportController();
            Int64 JobId = Convert.ToInt64(lblJobId.Text);
            try
            {
                HttpFileCollection fileCollection = Request.Files;
                for (int i = 0; i < fileCollection.Count; i++)
                {
                    HttpPostedFile uploadfile = fileCollection[i];
                    string ticks = DateTime.Now.Ticks.ToString();
                    string extension = Path.GetExtension(uploadfile.FileName);
                    string strFileName = ticks + "_Attachment" + extension;
                    ImageHandler.ResizeAndSaveImage(uploadfile, 680, 680, Server.MapPath("~/Tab8Files/" + strFileName));
                    objReportController.Tab8_AttachmentsEdit(0, JobId, strFileName, "ExternalPhoto", Convert.ToInt64(Session["UserId"]), "ADD");
                }
                //string strFileName = "";
                //if (fuTab8External.FileName.ToString() != "")
                //{
                //    //fuTab8External.SaveAs(Server.MapPath("~/Tab8Files/" + fuTab8External.FileName.ToString()));
                //    //strFileName = DateTime.Now.ToString("MMddyyyyHHmmss") + "_Attachment" + Path.GetExtension(fuTab8External.FileName.ToString());
                //    //File.Move(Server.MapPath("~/Tab8Files/" + fuTab8External.FileName.ToString()), Server.MapPath("~/Tab8Files/" + strFileName));

                //    fuTab8External.SaveAs(Server.MapPath("~/Tab8Files/" + fuTab8External.FileName.ToString()));
                //    strFileName = DateTime.Now.ToString("MMddyyyyHHmmss") + "_Attachment" + Path.GetExtension(fuTab8External.FileName.ToString());
                //    strFileName = Server.MapPath("~/Tab8Files/" + strFileName);
                //    SetFile(fuTab8External, Server.MapPath("~/Tab8Files/" + fuTab8External.FileName.ToString()), strFileName);
                //    strFileName = Path.GetFileName(strFileName);
                //}

                //JobId = objReportController.Tab8_AttachmentsEdit(0, JobId, strFileName, "ExternalPhoto", Convert.ToInt64(Session["UserId"]), "ADD");
                if (JobId > 0)
                {
                    lblTab8Error.Text = "Photo uploaded successfully.";
                    FillTab8ExternalPhoto();
                }
                else
                {
                    lblTab8Error.Text = "Photo doesnt uploaded successfully. Please try again.";
                    return;
                }
            }
            catch (Exception Ex)
            {
                lblTab8Error.Text = Ex.Message.ToString();
            }
            finally
            {
                objReportController = null;
            }
        }
        public void FillTab8ExternalPhoto()
        {
            ReportController objReportController = new ReportController();
            DataSet ds = new DataSet();
            try
            {
                gvTab8ExternalPhoto.Visible = false;
                ds = Tab8GetImages("ExternalPhoto");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvTab8ExternalPhoto.DataSource = ds.Tables[0].DefaultView;
                    gvTab8ExternalPhoto.DataBind();
                    gvTab8ExternalPhoto.Visible = true;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
                ds = null;
            }
        }
        protected void btnTab8DeleteExternalPhoto_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnDelete = sender as ImageButton;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;
            ReportController objReportController = new ReportController();
            try
            {
                if (objReportController.Tab8_AttachmentsEdit(Convert.ToInt64(((Label)row.FindControl("lblId")).Text), 0, "", "", 0, "DELETE") > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Photo details deleted.');", true);
                    File.Delete(Server.MapPath("~/Tab8Files/" + ((Label)row.FindControl("lblImageName")).Text));
                    FillTab8ExternalPhoto();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Photo does not deleted.');", true);
                    return;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
            }
        }

        protected void btnTab8InternalPhoto_Click(object sender, EventArgs e)
        {
            //HideTab8InnerTables();
            //tblTab8Internal.Visible = true;
            //lbtnTab8Internal.Font.Bold = true;
            ReportController objReportController = new ReportController();
            Int64 JobId = Convert.ToInt64(lblJobId.Text);
            try
            {
                HttpFileCollection fileCollection = Request.Files;
                for (int i = 0; i < fileCollection.Count; i++)
                {
                    HttpPostedFile uploadfile = fileCollection[i];
                    string ticks = DateTime.Now.Ticks.ToString();
                    string extension = Path.GetExtension(uploadfile.FileName);
                    string strFileName = ticks + "_Attachment" + extension;
                    ImageHandler.ResizeAndSaveImage(uploadfile, 680, 680, Server.MapPath("~/Tab8Files/" + strFileName));
                    objReportController.Tab8_AttachmentsEdit(0, JobId, strFileName, "InternalPhoto", Convert.ToInt64(Session["UserId"]), "ADD");
                }
                //string strFileName = "";
                //if (fuTab8Internal.FileName.ToString() != "")
                //{
                //    //fuTab8Internal.SaveAs(Server.MapPath("~/Tab8Files/" + fuTab8Internal.FileName.ToString()));
                //    //strFileName = DateTime.Now.ToString("MMddyyyyHHmmss") + "_Attachment" + Path.GetExtension(fuTab8Internal.FileName.ToString());
                //    //File.Move(Server.MapPath("~/Tab8Files/" + fuTab8Internal.FileName.ToString()), Server.MapPath("~/Tab8Files/" + strFileName));

                //    fuTab8Internal.SaveAs(Server.MapPath("~/Tab8Files/" + fuTab8Internal.FileName.ToString()));
                //    strFileName = DateTime.Now.ToString("MMddyyyyHHmmss") + "_Attachment" + Path.GetExtension(fuTab8Internal.FileName.ToString());
                //    strFileName = Server.MapPath("~/Tab8Files/" + strFileName);
                //    SetFile(fuTab8Internal, Server.MapPath("~/Tab8Files/" + fuTab8Internal.FileName.ToString()), strFileName);
                //    strFileName = Path.GetFileName(strFileName);
                //}

                //JobId = objReportController.Tab8_AttachmentsEdit(0, JobId, strFileName, "InternalPhoto", Convert.ToInt64(Session["UserId"]), "ADD");
                if (JobId > 0)
                {
                    lblTab8Error.Text = "Photo uploaded successfully.";
                    FillTab8InternalPhoto();
                }
                else
                {
                    lblTab8Error.Text = "Photo doesnt uploaded successfully. Please try again.";
                    return;
                }
            }
            catch (Exception Ex)
            {
                lblTab8Error.Text = Ex.Message.ToString();
            }
            finally
            {
                objReportController = null;
            }
        }
        public void FillTab8InternalPhoto()
        {
            ReportController objReportController = new ReportController();
            DataSet ds = new DataSet();
            try
            {
                gvTab8InternalPhoto.Visible = false;
                ds = Tab8GetImages("InternalPhoto");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvTab8InternalPhoto.DataSource = ds.Tables[0].DefaultView;
                    gvTab8InternalPhoto.DataBind();
                    gvTab8InternalPhoto.Visible = true;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
                ds = null;
            }
        }
        protected void btnTab8DeleteInternalPhoto_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnDelete = sender as ImageButton;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;
            ReportController objReportController = new ReportController();
            try
            {
                if (objReportController.Tab8_AttachmentsEdit(Convert.ToInt64(((Label)row.FindControl("lblId")).Text), 0, "", "", 0, "DELETE") > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Photo details deleted.');", true);
                    File.Delete(Server.MapPath("~/Tab8Files/" + ((Label)row.FindControl("lblImageName")).Text));
                    FillTab8InternalPhoto();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Photo does not deleted.');", true);
                    return;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
            }
        }

        protected void btnTab8DefectPhoto_Click(object sender, EventArgs e)
        {
            //HideTab8InnerTables();
            //tblTab8Defect.Visible = true;
            //lbtnTab8Defect.Font.Bold = true;
            ReportController objReportController = new ReportController();
            Int64 JobId = Convert.ToInt64(lblJobId.Text);
            try
            {
                HttpFileCollection fileCollection = Request.Files;
                for (int i = 0; i < fileCollection.Count; i++)
                {
                    HttpPostedFile uploadfile = fileCollection[i];
                    string ticks = DateTime.Now.Ticks.ToString();
                    string extension = Path.GetExtension(uploadfile.FileName);
                    string strFileName = ticks + "_Attachment" + extension;
                    ImageHandler.ResizeAndSaveImage(uploadfile, 680, 680, Server.MapPath("~/Tab8Files/" + strFileName));
                    objReportController.Tab8_AttachmentsEdit(0, JobId, strFileName, "DefectPhoto", Convert.ToInt64(Session["UserId"]), "ADD");
                }
                //string strFileName = "";
                //if (fuTab8Defect.FileName.ToString() != "")
                //{
                //    //fuTab8Defect.SaveAs(Server.MapPath("~/Tab8Files/" + fuTab8Defect.FileName.ToString()));
                //    //strFileName = DateTime.Now.ToString("MMddyyyyHHmmss") + "_Attachment" + Path.GetExtension(fuTab8Defect.FileName.ToString());
                //    //File.Move(Server.MapPath("~/Tab8Files/" + fuTab8Defect.FileName.ToString()), Server.MapPath("~/Tab8Files/" + strFileName));

                //    fuTab8Defect.SaveAs(Server.MapPath("~/Tab8Files/" + fuTab8Defect.FileName.ToString()));
                //    strFileName = DateTime.Now.ToString("MMddyyyyHHmmss") + "_Attachment" + Path.GetExtension(fuTab8Defect.FileName.ToString());
                //    strFileName = Server.MapPath("~/Tab8Files/" + strFileName);
                //    SetFile(fuTab8Defect, Server.MapPath("~/Tab8Files/" + fuTab8Defect.FileName.ToString()), strFileName);
                //    strFileName = Path.GetFileName(strFileName);
                //}

                //JobId = objReportController.Tab8_AttachmentsEdit(0, JobId, strFileName, "DefectPhoto", Convert.ToInt64(Session["UserId"]), "ADD");
                if (JobId > 0)
                {
                    lblTab8Error.Text = "Photo uploaded successfully.";
                    FillTab8DefectPhoto();
                }
                else
                {
                    lblTab8Error.Text = "Photo doesnt uploaded successfully. Please try again.";
                    return;
                }
            }
            catch (Exception Ex)
            {
                lblTab8Error.Text = Ex.Message.ToString();
            }
            finally
            {
                objReportController = null;
            }
        }
        public void FillTab8DefectPhoto()
        {
            ReportController objReportController = new ReportController();
            DataSet ds = new DataSet();
            try
            {
                gvTab8DefectPhoto.Visible = false;
                ds = Tab8GetImages("DefectPhoto");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvTab8DefectPhoto.DataSource = ds.Tables[0].DefaultView;
                    gvTab8DefectPhoto.DataBind();
                    gvTab8DefectPhoto.Visible = true;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
                ds = null;
            }
        }
        protected void btnTab8DeleteDefectPhoto_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnDelete = sender as ImageButton;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;
            ReportController objReportController = new ReportController();
            try
            {
                if (objReportController.Tab8_AttachmentsEdit(Convert.ToInt64(((Label)row.FindControl("lblId")).Text), 0, "", "", 0, "DELETE") > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Photo details deleted.');", true);
                    if (!string.IsNullOrEmpty(((Label)row.FindControl("lblImageName")).Text))
                    {
                        File.Delete(Server.MapPath("~/Tab8Files/" + ((Label)row.FindControl("lblImageName")).Text));
                    }
                    FillTab8DefectPhoto();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Photo does not deleted.');", true);
                    return;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
            }
        }

        protected void btnTab8TitlePhoto_Click(object sender, EventArgs e)
        {
            //HideTab8InnerTables();
            //tblTab8Title.Visible = true;
            //lbtnTab8Title.Font.Bold = true;
            ReportController objReportController = new ReportController();
            Int64 JobId = Convert.ToInt64(lblJobId.Text);
            try
            {
                HttpFileCollection fileCollection = Request.Files;
                for (int i = 0; i < fileCollection.Count; i++)
                {
                    HttpPostedFile uploadfile = fileCollection[i];
                    string ticks = DateTime.Now.Ticks.ToString();
                    string extension = Path.GetExtension(uploadfile.FileName);
                    string strFileName = ticks + "_Attachment" + extension;
                    ImageHandler.ResizeAndSaveImage(uploadfile, 775, 990, Server.MapPath("~/Tab8Files/" + strFileName));
                    objReportController.Tab8_AttachmentsEdit(0, JobId, strFileName, "TitlePhoto", Convert.ToInt64(Session["UserId"]), "ADD");
                }
                //string strFileName = "";
                //if (fuTab8Title.FileName.ToString() != "")
                //{
                //    fuTab8Title.SaveAs(Server.MapPath("~/Tab8Files/" + fuTab8Title.FileName.ToString()));
                //    strFileName = DateTime.Now.ToString("MMddyyyyHHmmss") + "_Attachment" + Path.GetExtension(fuTab8Title.FileName.ToString());
                //    File.Move(Server.MapPath("~/Tab8Files/" + fuTab8Title.FileName.ToString()), Server.MapPath("~/Tab8Files/" + strFileName));

                //    //fuTab8Title.SaveAs(Server.MapPath("~/Tab8Files/" + fuTab8Title.FileName.ToString()));
                //    //strFileName = DateTime.Now.ToString("MMddyyyyHHmmss") + "_Attachment" + Path.GetExtension(fuTab8Title.FileName.ToString());
                //    //strFileName = Server.MapPath("~/Tab8Files/" + strFileName);
                //    //SetFile(fuTab8Title, Server.MapPath("~/Tab8Files/" + fuTab8Title.FileName.ToString()), strFileName);
                //    //strFileName = Path.GetFileName(strFileName);
                //}

                //JobId = objReportController.Tab8_AttachmentsEdit(0, JobId, strFileName, "TitlePhoto", Convert.ToInt64(Session["UserId"]), "ADD");
                if (JobId > 0)
                {
                    lblTab8Error.Text = "Photo uploaded successfully.";
                    FillTab8TitlePhoto();
                }
                else
                {
                    lblTab8Error.Text = "Photo doesnt uploaded successfully. Please try again.";
                    return;
                }
            }
            catch (Exception Ex)
            {
                lblTab8Error.Text = Ex.Message.ToString();
            }
            finally
            {
                objReportController = null;
            }
        }
        public void FillTab8TitlePhoto()
        {
            ReportController objReportController = new ReportController();
            DataSet ds = new DataSet();
            try
            {
                gvTab8TitlePhoto.Visible = false;
                ds = Tab8GetImages("TitlePhoto");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvTab8TitlePhoto.DataSource = ds.Tables[0].DefaultView;
                    gvTab8TitlePhoto.DataBind();
                    gvTab8TitlePhoto.Visible = true;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
                ds = null;
            }
        }
        protected void btnTab8DeleteTitlePhoto_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnDelete = sender as ImageButton;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;
            ReportController objReportController = new ReportController();
            try
            {
                if (objReportController.Tab8_AttachmentsEdit(Convert.ToInt64(((Label)row.FindControl("lblId")).Text), 0, "", "", 0, "DELETE") > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Photo details deleted.');", true);
                    if (!string.IsNullOrEmpty(((Label)row.FindControl("lblImageName")).Text))
                    {
                        File.Delete(Server.MapPath("~/Tab8Files/" + ((Label)row.FindControl("lblImageName")).Text));
                    }
                    FillTab8TitlePhoto();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Photo does not deleted.');", true);
                    return;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
            }
        }

        protected void btnTab8ZoningPhoto_Click(object sender, EventArgs e)
        {
            //HideTab8InnerTables();
            //tblTab8Zoning.Visible = true;
            //lbtnTab8Zoning.Font.Bold = true;
            ReportController objReportController = new ReportController();
            Int64 JobId = Convert.ToInt64(lblJobId.Text);
            try
            {
                HttpFileCollection fileCollection = Request.Files;
                for (int i = 0; i < fileCollection.Count; i++)
                {
                    HttpPostedFile uploadfile = fileCollection[i];
                    string ticks = DateTime.Now.Ticks.ToString();
                    string extension = Path.GetExtension(uploadfile.FileName);
                    string strFileName = ticks + "_Attachment" + extension;
                    ImageHandler.ResizeAndSaveImage(uploadfile, 680, 680, Server.MapPath("~/Tab8Files/" + strFileName));
                    objReportController.Tab8_AttachmentsEdit(0, JobId, strFileName, "ZoningPhoto", Convert.ToInt64(Session["UserId"]), "ADD");
                }
                //string strFileName = "";
                //if (fuTab8Zoning.FileName.ToString() != "")
                //{
                //    fuTab8Zoning.SaveAs(Server.MapPath("~/Tab8Files/" + fuTab8Zoning.FileName.ToString()));
                //    strFileName = DateTime.Now.ToString("MMddyyyyHHmmss") + "_Attachment" + Path.GetExtension(fuTab8Zoning.FileName.ToString());
                //    File.Move(Server.MapPath("~/Tab8Files/" + fuTab8Zoning.FileName.ToString()), Server.MapPath("~/Tab8Files/" + strFileName));

                //    //fuTab8Zoning.SaveAs(Server.MapPath("~/Tab8Files/" + fuTab8Zoning.FileName.ToString()));
                //    //strFileName = DateTime.Now.ToString("MMddyyyyHHmmss") + "_Attachment" + Path.GetExtension(fuTab8Zoning.FileName.ToString());
                //    //strFileName = Server.MapPath("~/Tab8Files/" + strFileName);
                //    //SetFile(fuTab8Zoning, Server.MapPath("~/Tab8Files/" + fuTab8Zoning.FileName.ToString()), strFileName);
                //    //strFileName = Path.GetFileName(strFileName);
                //}

                //JobId = objReportController.Tab8_AttachmentsEdit(0, JobId, strFileName, "ZoningPhoto", Convert.ToInt64(Session["UserId"]), "ADD");
                if (JobId > 0)
                {
                    lblTab8Error.Text = "Photo uploaded successfully.";
                    FillTab8ZoningPhoto();
                }
                else
                {
                    lblTab8Error.Text = "Photo doesnt uploaded successfully. Please try again.";
                    return;
                }
            }
            catch (Exception Ex)
            {
                lblTab8Error.Text = Ex.Message.ToString();
            }
            finally
            {
                objReportController = null;
            }
        }
        public void FillTab8ZoningPhoto()
        {
            ReportController objReportController = new ReportController();
            DataSet ds = new DataSet();
            try
            {
                gvTab8ZoningPhoto.Visible = false;
                ds = Tab8GetImages("ZoningPhoto");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvTab8ZoningPhoto.DataSource = ds.Tables[0].DefaultView;
                    gvTab8ZoningPhoto.DataBind();
                    gvTab8ZoningPhoto.Visible = true;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
                ds = null;
            }
        }
        protected void btnTab8DeleteZoningPhoto_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnDelete = sender as ImageButton;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;
            ReportController objReportController = new ReportController();
            try
            {
                if (objReportController.Tab8_AttachmentsEdit(Convert.ToInt64(((Label)row.FindControl("lblId")).Text), 0, "", "", 0, "DELETE") > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Photo details deleted.');", true);
                    if (!string.IsNullOrEmpty(((Label)row.FindControl("lblImageName")).Text))
                    {
                        File.Delete(Server.MapPath("~/Tab8Files/" + ((Label)row.FindControl("lblImageName")).Text));
                    }
                    FillTab8ZoningPhoto();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Photo does not deleted.');", true);
                    return;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
            }
        }

        /// <summary>
        /// The PageConvertedEvent event handler called after when a PDF page was converted to image
        /// The event is raised when the ConvertPdfPagesToImageInEvent() method is used
        /// </summary>
        /// <param name="args">The handler argument containing the PDF page image and page number</param>
        //void pdfToImageConverter_PageConvertedEvent(PageConvertedEventArgs args)
        //{
        //    ReportController objReportController = new ReportController();
        //    Int64 JobId = Convert.ToInt64(lblJobId.Text);
        //    try
        //    {
        //        // get the image object and page number from even handler argument
        //        System.Drawing.Image originalImage = args.PdfPageImage.ImageObject;
        //        int pageNumber = args.PdfPageImage.PageNumber;
        //        // save the PDF page image to a PNG file
        //        string ticks = DateTime.Now.Ticks.ToString();
        //        string strFileName = ticks + "_Attachment" + pageNumber + ".jpg";
        //        string outputPageImage = Server.MapPath("~/Tab8Files/" + strFileName);
        //        originalImage.Save(outputPageImage, ImageFormat.Jpeg);

        //        ////ImageHandler.ResizeAndSaveImage(uploadfile, 680, 680, Server.MapPath("~/Tab8Files/" + strFileName));
        //        //float ratio;
        //        //// Get height and width of current image
        //        //int width = originalImage.Width;
        //        //int height = originalImage.Height;
        //        //int maxWidth = 1000;
        //        //int maxHeight = 1200;

        //        //// Ratio and conversion for new size
        //        //if (width > maxWidth)
        //        //{
        //        //    ratio = (float)width / (float)maxWidth;
        //        //    width = (int)(width / ratio);
        //        //    height = (int)(height / ratio);
        //        //}

        //        //// Ratio and conversion for new size
        //        //if (height > maxHeight)
        //        //{
        //        //    ratio = (float)height / (float)maxHeight;
        //        //    height = (int)(height / ratio);
        //        //    width = (int)(width / ratio);
        //        //}

        //        ////Convert other formats (including CMYK) to RGB.
        //        //using (Bitmap newImage = new Bitmap(width, height))
        //        //{
        //        //    using (Graphics outGraphics = Graphics.FromImage(newImage))
        //        //    {
        //        //        outGraphics.CompositingQuality = CompositingQuality.HighQuality;
        //        //        outGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //        //        outGraphics.SmoothingMode = SmoothingMode.HighQuality;
        //        //        using (SolidBrush sb = new SolidBrush(System.Drawing.Color.White))
        //        //        {
        //        //            // Fill "blank" with new sized image
        //        //            outGraphics.FillRectangle(sb, 0, 0, newImage.Width, newImage.Height);
        //        //            outGraphics.DrawImage(originalImage, 0, 0, newImage.Width, newImage.Height);
        //        //            newImage.Save(outputPageImage, System.Drawing.Imaging.ImageFormat.Jpeg);
        //        //        }
        //        //    }
        //        //}

        //        objReportController.Tab8_AttachmentsEdit(0, JobId, strFileName, "OverlayPhoto", Convert.ToInt64(Session["UserId"]), "ADD");
        //        args.PdfPageImage.Dispose();
        //    }
        //    catch (Exception Ex)
        //    {
        //        lblTab8Error.Text = Ex.Message.ToString();
        //    }
        //    finally
        //    {
        //        objReportController = null;
        //    }
        //}

        protected void btnTab8OverlayPhoto_Click(object sender, EventArgs e)
        {
            //HideTab8InnerTables();
            //tblTab8Overlay.Visible = true;
            //lbtnTab8Overlay.Font.Bold = true;
            ReportController objReportController = new ReportController();
            Int64 JobId = Convert.ToInt64(lblJobId.Text);
            try
            {
                HttpFileCollection fileCollection = Request.Files;
                for (int i = 0; i < fileCollection.Count; i++)
                {
                    HttpPostedFile uploadfile = null;
                    uploadfile = fileCollection[i];
                    string ticks = DateTime.Now.Ticks.ToString();
                    string extension = Path.GetExtension(uploadfile.FileName);
                    if (extension == ".pdf")
                    {
                        try
                        {
                            string filePath = string.Empty;


                            filePath = Server.MapPath("~/Tab8Files/" + Path.GetFileName(uploadfile.FileName));
                            fuTab8Overlay.SaveAs(filePath);

                            PdfToImageConverter pdfToImageConverter = new PdfToImageConverter();
                            pdfToImageConverter.LicenseKey = "+dLI2cjI2cvAydnIydfJ2crI18jL18DAwMA="; // license key
                            pdfToImageConverter.ImagesFormat = ImageFormat.Jpeg; // image format
                            pdfToImageConverter.ColorSpace = PdfToImageColorSpace.RGB; // image color space
                            pdfToImageConverter.StartPageNumber = 1; // start page number
                            pdfToImageConverter.EndPageNumber = pdfToImageConverter.GetPageCount(filePath); // end page number
                            pdfToImageConverter.Resolution = 400; // image resolution    
                            System.Drawing.Image[] objImage = null;
                            objImage = pdfToImageConverter.ConvertToImages(filePath);
                            for (int ii = 0; ii < objImage.Count(); ii++)
                            {
                                string TimeTicks = DateTime.Now.Ticks.ToString();
                                string strFileName = TimeTicks + "_Attachment_" + i + "_" + ii + ".jpg";
                                string outputPageImage = Server.MapPath("~/Tab8Files/" + strFileName);
                                objImage[ii].Save(outputPageImage);
                                objReportController.Tab8_AttachmentsEdit(0, JobId, strFileName, "OverlayPhoto", Convert.ToInt64(Session["UserId"]), "ADD");
                                lblTab8Error.Text = "FIle path ..... " + outputPageImage;
                            }
                        }
                        catch (Exception ex)
                        {
                            lblTab8Error.Text = " Exception here : " + ex.Message;
                            return;
                        }
                    }
                    else
                    {
                        string strFileName = ticks + "_Attachment" + extension;
                        ImageHandler.ResizeAndSaveImage(uploadfile, 680, 680, Server.MapPath("~/Tab8Files/" + strFileName));
                        objReportController.Tab8_AttachmentsEdit(0, JobId, strFileName, "OverlayPhoto", Convert.ToInt64(Session["UserId"]), "ADD");
                    }
                }
                ////--------- Multiple  Image Upload ------------//
                //HttpFileCollection fileCollection = Request.Files;
                //for (int i = 0; i < fileCollection.Count; i++)
                //{
                //    HttpPostedFile uploadfile = fileCollection[i];
                //    string ticks = DateTime.Now.Ticks.ToString();
                //    string extension = Path.GetExtension(uploadfile.FileName);
                //    string strFileName = ticks + "_Attachment" + extension;
                //    ImageHandler.ResizeAndSaveImage(uploadfile, 680, 680, Server.MapPath("~/Tab8Files/" + strFileName));
                //    objReportController.Tab8_AttachmentsEdit(0, JobId, strFileName, "OverlayPhoto", Convert.ToInt64(Session["UserId"]), "ADD");
                //}
                ////--------- Multiple  Image Upload ------------//

                ////--------- Old Code ------------//
                //string strFileName = "";
                //if (fuTab8Overlay.FileName.ToString() != "")
                //{
                //    fuTab8Overlay.SaveAs(Server.MapPath("~/Tab8Files/" + fuTab8Overlay.FileName.ToString()));
                //    strFileName = DateTime.Now.ToString("MMddyyyyHHmmss") + "_Attachment" + Path.GetExtension(fuTab8Overlay.FileName.ToString());
                //    File.Move(Server.MapPath("~/Tab8Files/" + fuTab8Overlay.FileName.ToString()), Server.MapPath("~/Tab8Files/" + strFileName));

                //    //fuTab8Overlay.SaveAs(Server.MapPath("~/Tab8Files/" + fuTab8Overlay.FileName.ToString()));
                //    //strFileName = DateTime.Now.ToString("MMddyyyyHHmmss") + "_Attachment" + Path.GetExtension(fuTab8Overlay.FileName.ToString());
                //    //strFileName = Server.MapPath("~/Tab8Files/" + strFileName);
                //    //SetFile(fuTab8Overlay, Server.MapPath("~/Tab8Files/" + fuTab8Overlay.FileName.ToString()), strFileName);
                //    //strFileName = Path.GetFileName(strFileName);
                //}

                //JobId = objReportController.Tab8_AttachmentsEdit(0, JobId, strFileName, "OverlayPhoto", Convert.ToInt64(Session["UserId"]), "ADD");
                if (JobId > 0)
                {
                    lblTab8Error.Text = "Photo uploaded successfully.";
                    FillTab8OverlayPhoto();
                }
                else
                {
                    lblTab8Error.Text = "Photo doesnt uploaded successfully. Please try again.";
                    return;
                }
            }
            catch (Exception Ex)
            {
                lblTab8Error.Text = Ex.Message.ToString();
            }
            finally
            {
                objReportController = null;
            }
        }
        public void FillTab8OverlayPhoto()
        {
            ReportController objReportController = new ReportController();
            DataSet ds = new DataSet();
            try
            {
                gvTab8OverlayPhoto.Visible = false;
                ds = Tab8GetImages("OverlayPhoto");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvTab8OverlayPhoto.DataSource = ds.Tables[0].DefaultView;
                    gvTab8OverlayPhoto.DataBind();
                    gvTab8OverlayPhoto.Visible = true;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
                ds = null;
            }
        }
        protected void btnTab8DeleteOverlayPhoto_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnDelete = sender as ImageButton;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;
            ReportController objReportController = new ReportController();
            try
            {
                if (objReportController.Tab8_AttachmentsEdit(Convert.ToInt64(((Label)row.FindControl("lblId")).Text), 0, "", "", 0, "DELETE") > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Photo details deleted.');", true);
                    if (!string.IsNullOrEmpty(((Label)row.FindControl("lblImageName")).Text))
                    {
                        File.Delete(Server.MapPath("~/Tab8Files/" + ((Label)row.FindControl("lblImageName")).Text));
                    }
                    FillTab8OverlayPhoto();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Photo does not deleted.');", true);
                    return;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
            }
        }

        protected void btnTab8OthersPhoto_Click(object sender, EventArgs e)
        {
            //HideTab8InnerTables();
            //tblTab8Others.Visible = true;
            //lbtnTab8Others.Font.Bold = true;
            ReportController objReportController = new ReportController();
            Int64 JobId = Convert.ToInt64(lblJobId.Text);
            try
            {
                HttpFileCollection fileCollection = Request.Files;
                for (int i = 0; i < fileCollection.Count; i++)
                {
                    HttpPostedFile uploadfile = fileCollection[i];
                    string ticks = DateTime.Now.Ticks.ToString();
                    string extension = Path.GetExtension(uploadfile.FileName);
                    string strFileName = ticks + "_Attachment" + extension;
                    ImageHandler.ResizeAndSaveImage(uploadfile, 680, 680, Server.MapPath("~/Tab8Files/" + strFileName));
                    objReportController.Tab8_AttachmentsEdit(0, JobId, strFileName, "OthersPhoto", Convert.ToInt64(Session["UserId"]), "ADD");
                }
                //string strFileName = "";
                //if (fuTab8Others.FileName.ToString() != "")
                //{
                //    fuTab8Others.SaveAs(Server.MapPath("~/Tab8Files/" + fuTab8Others.FileName.ToString()));
                //    strFileName = DateTime.Now.ToString("MMddyyyyHHmmss") + "_Attachment" + Path.GetExtension(fuTab8Others.FileName.ToString());
                //    File.Move(Server.MapPath("~/Tab8Files/" + fuTab8Others.FileName.ToString()), Server.MapPath("~/Tab8Files/" + strFileName));

                //    //fuTab8Others.SaveAs(Server.MapPath("~/Tab8Files/" + fuTab8Others.FileName.ToString()));
                //    //strFileName = DateTime.Now.ToString("MMddyyyyHHmmss") + "_Attachment" + Path.GetExtension(fuTab8Others.FileName.ToString());
                //    //strFileName = Server.MapPath("~/Tab8Files/" + strFileName);
                //    //SetFile(fuTab8Others, Server.MapPath("~/Tab8Files/" + fuTab8Others.FileName.ToString()), strFileName);
                //    //strFileName = Path.GetFileName(strFileName);
                //}

                //JobId = objReportController.Tab8_AttachmentsEdit(0, JobId, strFileName, "OthersPhoto", Convert.ToInt64(Session["UserId"]), "ADD");
                if (JobId > 0)
                {
                    lblTab8Error.Text = "Photo uploaded successfully.";
                    FillTab8OthersPhoto();
                }
                else
                {
                    lblTab8Error.Text = "Photo doesnt uploaded successfully. Please try again.";
                    return;
                }
            }
            catch (Exception Ex)
            {
                lblTab8Error.Text = Ex.Message.ToString();
            }
            finally
            {
                objReportController = null;
            }
        }
        public void FillTab8OthersPhoto(Int64 jobId = 0)
        {
            ReportController objReportController = new ReportController();
            DataSet ds = new DataSet();
            try
            {
                gvTab8OthersPhoto.Visible = false;
                ds = Tab8GetImages("OthersPhoto", jobId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvTab8OthersPhoto.DataSource = ds.Tables[0].DefaultView;
                    gvTab8OthersPhoto.DataBind();
                    gvTab8OthersPhoto.Visible = true;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
                ds = null;
            }
        }
        protected void btnTab8DeleteOthersPhoto_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnDelete = sender as ImageButton;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;
            ReportController objReportController = new ReportController();
            try
            {
                if (objReportController.Tab8_AttachmentsEdit(Convert.ToInt64(((Label)row.FindControl("lblId")).Text), 0, "", "", 0, "DELETE") > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Photo details deleted.');", true);
                    File.Delete(Server.MapPath("~/Tab8Files/" + ((Label)row.FindControl("lblImageName")).Text));
                    FillTab8OthersPhoto();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Photo does not deleted.');", true);
                    return;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
            }
        }
        #endregion

        protected void btnTab8Next_Click(object sender, EventArgs e)
        {
            //SaveTabsData(true);

            string strReportUpload = GeneratePDF();
            if (strReportUpload != "")
            {
                JobsController objJobsController = new JobsController();
                int RetVal = objJobsController.JobEditFinalReportGenerate(Convert.ToInt64(Request.QueryString["JobId"]),
                    strReportUpload, 7);
                if (RetVal > 0)
                {
                    Session["ShowMessage"] = "ReportCompleted";
                    Response.Redirect("JobOrderDetails.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
                }
                else
                {
                    lblErrorMessage.Text = "Error to update job status with report.";
                }
            }
            else
            {
                lblErrorMessage.Text = "Error to generate pdf report.";
            }
            dvload.Style.Add("display", "none");
            dvoverlay.Style.Add("display", "none");
        }

        protected void btnTab8Back_Click(object sender, EventArgs e)
        {
            tblTab7SalesEvidence.Visible = true;
            tblTab8Attachments.Visible = false;
            lbtnTab7SalesEvidence_Click(null, null);
        }

        #endregion

        #region Data Save


        private void SaveSummaryTab()
        {
            #region Tab 1
            ReportController objReportController = new ReportController();
            Int64 JobId = Convert.ToInt64(lblJobId.Text);
            try
            {
                DateTime? InspectionDate = null;
                DateTime? ValuationsDate = null;


                if (CommonController.GetConfigurationVal("Mode") == "LOCAL")
                {
                    if (txtInspectionDate.Text.Trim() != "")
                    {
                        string[] strDate = txtInspectionDate.Text.Trim().Split('/');
                        InspectionDate = Convert.ToDateTime(strDate[1].ToString() + "/" + strDate[0].ToString() + "/" + strDate[2].ToString());
                    }
                    if (txtValuationsDate.Text.Trim() != "")
                    {
                        string[] strDate = txtValuationsDate.Text.Trim().Split('/');
                        ValuationsDate = Convert.ToDateTime(strDate[1].ToString() + "/" + strDate[0].ToString() + "/" + strDate[2].ToString());
                    }
                }
                else
                {
                    if (txtInspectionDate.Text.Trim() != "")
                        InspectionDate = Convert.ToDateTime(txtInspectionDate.Text.Trim());

                    if (txtValuationsDate.Text.Trim() != "")
                        ValuationsDate = Convert.ToDateTime(txtValuationsDate.Text.Trim());
                }

                int valApproach = 0;

                if (ddlValuationApproach.SelectedValue.Length > 0)
                {
                    valApproach = Convert.ToInt32(ddlValuationApproach.SelectedValue);
                }
                JobId = objReportController.Tab1_SummaryEdit(JobId, txtMarketValue.Text.Trim(), txtUnitLot.Text.Trim(), txtStreetNumber.Text.Trim(),
                    txtStreetName.Text.Trim(), txtStreetType.Text.Trim(), txtSuburb.Text.Trim(), txtPostcode.Text.Trim(), ddlState.SelectedValue,
                    ddlPurpose.SelectedItem.Text, txtInstructedBy.Text.Trim(), InspectionDate,
                    ValuationsDate, ddlValueComponent.SelectedValue,
                    Convert.ToInt64(Session["UserId"]), "ADD", txtLandValue.Text.Trim(), txtImprovements.Text.Trim(),
                    txtClient.Text.Trim(), txtTab1Instructions.Text.Trim(), valApproach);
                if (JobId > 0)
                {
                    lblPropertyAddress.Text = txtStreetNumber.Text + " " + txtStreetName.Text + " " + txtStreetType.Text + ", " +
                        txtSuburb.Text + "&nbsp;&nbsp;" + ddlState.SelectedValue + "&nbsp;&nbsp;" + txtPostcode.Text;
                }
            }
            catch (Exception Ex)
            {
                lblTab1Error.Text = Ex.Message.ToString();
            }
            finally
            {
                objReportController = null;
            }
            #endregion
        }

        private void SaveLandTab()
        {
            #region Tab 2
            ReportController objReportController = new ReportController();
            Int64 JobId = Convert.ToInt64(lblJobId.Text);
            try
            {
                JobId = objReportController.Tab2_LandEdit(JobId, ddlTab2PropertyType.SelectedValue, ddlTab2PropertyIdentification.SelectedValue,
                    ddlTab2TitleSearch.SelectedValue, txtTab2LotNumber.Text.Trim(), txtTab2PlanNumber.Text.Trim(),
                    txtTab2Volume.Text.Trim(), txtTab2Folio.Text.Trim(), txtTab2RegisteredProprietors.Text,
                    txtTab2Encumbrances.Text, txtTab2SiteArea.Text.Trim(), txtTab2LocalGovernmentArea.Text.Trim(),
                    txtTab2Zoning.Text.Trim(), txtTab2Overlays.Text.Trim(), ddlTab2ZoningEffect.SelectedValue,
                    txtTab2Shops.Text, txtTab2Transport.Text, txtTab2Schools.Text,
                    txtTab2CBD.Text, txtTab2SiteLayout.Text, ddltab2Services.SelectedValue,
                    ddlTab2EnvironmentalHazards.SelectedValue, ddlTab2PestInfestation.SelectedValue,
                    Convert.ToInt64(Session["UserId"]), "ADD", ddlTab2SqmHectares.SelectedValue, ddlTab2Plan.SelectedValue);

            }
            catch (Exception Ex)
            {
                lblTab2Error.Text = Ex.Message.ToString();
            }
            finally
            {
                objReportController = null;
            }

            #endregion
        }

        private void SaveBuildingImprovements()
        {
            #region Tab 3
            ReportController objReportController = new ReportController();
            Int64 JobId = Convert.ToInt64(lblJobId.Text);
            try
            {
                //chk Tab3 Pergola Verandah
                string strPergolaVerandah = "";
                for (int i = 0; i < chkTab3PergolaVerandah.Items.Count; i++)
                {
                    if (chkTab3PergolaVerandah.Items[i].Selected == true)
                        strPergolaVerandah += chkTab3PergolaVerandah.Items[i].Value + "@";
                }
                //chkTab3Shedding
                string strShedding = "";
                for (int i = 0; i < chkTab3Shedding.Items.Count; i++)
                {
                    if (chkTab3Shedding.Items[i].Selected == true)
                        strShedding += chkTab3Shedding.Items[i].Value + "@";
                }
                //chkTab3Pools
                string strPools = "";
                for (int i = 0; i < chkTab3Pools.Items.Count; i++)
                {
                    if (chkTab3Pools.Items[i].Selected == true)
                        strPools += chkTab3Pools.Items[i].Value + "@";
                }
                //chkTab3Gardens
                string strGardens = "";
                for (int i = 0; i < chkTab3Gardens.Items.Count; i++)
                {
                    if (chkTab3Gardens.Items[i].Selected == true)
                        strGardens += chkTab3Gardens.Items[i].Value + "@";
                }
                //chkTab3Fencing
                string strFencing = "";
                for (int i = 0; i < chkTab3Fencing.Items.Count; i++)
                {
                    if (chkTab3Fencing.Items[i].Selected == true)
                        strFencing += chkTab3Fencing.Items[i].Value + "@";
                }
                //chkTab3DrivewayPaving
                string strDrivewayPaving = "";
                for (int i = 0; i < chkTab3DrivewayPaving.Items.Count; i++)
                {
                    if (chkTab3DrivewayPaving.Items[i].Selected == true)
                        strDrivewayPaving += chkTab3DrivewayPaving.Items[i].Value + "@";
                }
                //chkTab3Outbuildings
                string strOutbuildings = "";
                for (int i = 0; i < chkTab3Outbuildings.Items.Count; i++)
                {
                    if (chkTab3Outbuildings.Items[i].Selected == true)
                        strOutbuildings += chkTab3Outbuildings.Items[i].Value + "@";
                }


                JobId = objReportController.Tab3_BuildingImprovementsEdit(JobId, "", ddlTab3PropertyStyle.SelectedValue,
                    txtTab3YearBuilt.Text.Trim(), ddlTab3ExternalWalls.SelectedValue, ddltab3Roof.SelectedValue,
                    ddlTab3InteriorLinings.SelectedValue, ddlTab3MainFlooring.SelectedValue, ddlTab3WindowFrames.SelectedValue,
                    ddlTab3InternalCondition.SelectedValue, ddlTab3ExternalCondition.SelectedValue, ddlTab3StreetAppeal.SelectedValue,
                    strPergolaVerandah, strShedding, strPools, strGardens, strFencing, strDrivewayPaving, strOutbuildings,
                    Convert.ToInt64(Session["UserId"]), "ADD", txtTab3AncillaryImprovements.Text.Trim());

                if (JobId > 0)
                { }

            }
            catch (Exception Ex)
            {
                lblTab3Error.Text = Ex.Message.ToString();
            }
            finally
            {
                objReportController = null;
            }
            #endregion
        }

        private void SaveRoomFixures()
        {
            #region Tab 4
            ReportController objReportController = new ReportController();
            Int64 JobId = Convert.ToInt64(lblJobId.Text);
            try
            {
                //chk Tab3 Pergola Verandah
                string strRooms1 = "";
                for (int i = 0; i < chkTab4Rooms1.Items.Count; i++)
                {
                    if (chkTab4Rooms1.Items[i].Selected == true)
                        strRooms1 += chkTab4Rooms1.Items[i].Value + "@";
                }
                //chkTab3Shedding
                string strRooms2 = "";
                for (int i = 0; i < chkTab4Rooms2.Items.Count; i++)
                {
                    if (chkTab4Rooms2.Items[i].Selected == true)
                        strRooms2 += chkTab4Rooms2.Items[i].Value + "@";
                }
                //chkTab3Pools
                string strRooms3 = "";
                for (int i = 0; i < chkTab4Rooms3.Items.Count; i++)
                {
                    if (chkTab4Rooms3.Items[i].Selected == true)
                        strRooms3 += chkTab4Rooms3.Items[i].Value + "@";
                }
                //chkTab3Gardens
                string strRooms4 = "";
                for (int i = 0; i < chkTab4Rooms4.Items.Count; i++)
                {
                    if (chkTab4Rooms4.Items[i].Selected == true)
                        strRooms4 += chkTab4Rooms4.Items[i].Value + "@";
                }

                string strBedroom = ddlTab4Bedroom.SelectedValue;
                string strBathroom = ddlTab4Bathroom.SelectedValue;
                string strEnsuite = ddlTab4Ensuite.SelectedValue;
                string strToilet = ddlTab4Toilet.SelectedValue;
                string strLaundry = ddlTab4Toilet.SelectedValue;
                if (chkTab4Laundry.SelectedValue == "Laundry")
                    strLaundry = "Laundry";

                //chkTab4HeatingCooling
                string strHeatingCooling = "";
                for (int i = 0; i < chkTab4HeatingCooling.Items.Count; i++)
                {
                    if (chkTab4HeatingCooling.Items[i].Selected == true)
                        strHeatingCooling += chkTab4HeatingCooling.Items[i].Value + "@";
                }



                JobId = objReportController.Tab4_RoomsFixturesEdit(JobId, strRooms1, strRooms2, strRooms3, strRooms4,
                    strBedroom, strBathroom, strEnsuite, strToilet, strLaundry, Tab4Text1.Text.Trim(), strHeatingCooling,
                    Convert.ToInt64(Session["UserId"]), "ADD");

            }
            catch (Exception Ex)
            {
                lblTab4Error.Text = Ex.Message.ToString();
            }
            finally
            {
                objReportController = null;
            }
            #endregion
        }

        private void SaveAreaTab()
        {
            #region Tab 5
            ReportController objReportController = new ReportController();
            Int64 JobId = Convert.ToInt64(lblJobId.Text);
            try
            {
                JobId = objReportController.Tab5_AreasEdit(JobId, txtTab5LivingArea.Text.Trim(), txtTab5Alfresco.Text.Trim(),
                    txtTab5Balcony.Text.Trim(), txtTab5Pergola.Text.Trim(), txtTab5Verandah.Text.Trim(), txtTab5Garage.Text.Trim(),
                    txtTab5Carport.Text.Trim(), txtTab5CarSpaces.Text.Trim(),
                    Convert.ToInt64(Session["UserId"]), "ADD", ddlTab5SqmEq.SelectedValue);

            }
            catch (Exception Ex)
            {
                lblTab5Error.Text = Ex.Message.ToString();
            }
            finally
            {
                objReportController = null;
            }
            #endregion
        }

        private void SaveCommentsTab()
        {
            #region Tab 6
            ReportController objReportController = new ReportController();
            Int64 JobId = Convert.ToInt64(lblJobId.Text);
            try
            {
                JobId = objReportController.Tab6_CommentsEdit(JobId, txtTab6Instructions.Text.Trim(), txtTab6Standard.Text.Trim(),
                    txtTab6LastSaleofProperty.Text.Trim(), txtTab6Defects.Text.Trim(), txtTab6Methodology.Text.Trim(),
                    Convert.ToInt64(Session["UserId"]), "ADD", txtTab6Closing.Text.Trim());
            }
            catch (Exception Ex)
            {
                lblTab6Error.Text = Ex.Message.ToString();
            }
            finally
            {
                objReportController = null;
            }
            #endregion
        }
        public void SaveTabsData(bool saveAll = false)
        {
            if (saveAll || Convert.ToString(Session["TDReportSelected"]) == "Tab1Summary")
            {
                SaveSummaryTab();
            }

            if (saveAll || Convert.ToString(Session["TDReportSelected"]) == "Tab2Land")
            {
                SaveLandTab();
            }


            if (saveAll || Convert.ToString(Session["TDReportSelected"]) == "Tab3BuildingImprovements")
            {
                SaveBuildingImprovements();
            }

            if (saveAll || Convert.ToString(Session["TDReportSelected"]) == "Tab4RoomsFixtures")
            {
                SaveRoomFixures();
            }

            if (saveAll || Convert.ToString(Session["TDReportSelected"]) == "Tab5Area")
            {
                SaveAreaTab();
            }

            if (saveAll || Convert.ToString(Session["TDReportSelected"]) == "Tab6Comments")
            {
                SaveCommentsTab();
            }
        }
        #endregion

        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }
            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            return dTable;
        }

        public string GetDateFormat(string Date)
        {
            if (string.IsNullOrEmpty(Date))
                return string.Empty;

            string strDate = "";
            if (CommonController.GetConfigurationVal("Mode") == "LOCAL")
            {
                Date = Convert.ToDateTime(Date).ToString("MM/dd/yyyy");


                //string Day = Convert.ToDateTime(Date).ToString("dd MMMM, yyyy");
                //string Month = Convert.ToDateTime(Date).ToString("dd MMMM, yyyy");
                //string Year = Convert.ToDateTime(Date).ToString("dd MMMM, yyyy");


                int DayInt = Convert.ToInt16(Convert.ToDateTime(Date).ToString("dd"));
                string Day = Convert.ToString(DayInt);
                string Month = Convert.ToDateTime(Date).ToString("MMMM");
                string Year = Convert.ToDateTime(Date).ToString("yyyy");

                if (Day == "1" || Day == "21" || Day == "31")
                    strDate = Day + "st " + Month + ", " + Year;

                else if (Day == "2" || Day == "22")
                    strDate = Day + "nd " + Month + ", " + Year;

                else if (Day == "3" || Day == "23")
                    strDate = Day + "rd " + Month + ", " + Year;
                else
                    strDate = Day + "th " + Month + ", " + Year;

                //string[] strDate = txtAppointmentDate.Text.Trim().Split('/');
                //dtAppointment = Convert.ToDateTime(strDate[1].ToString() + "/" + strDate[0].ToString() + "/" + strDate[2].ToString());
            }
            else
            {
                //DateTime Date1 = Convert.ToDateTime(Convert.ToDateTime(Date).ToString("dd/MM/yyyy"));
                DateTime Date1 = Convert.ToDateTime(Date);

                //string Day = Convert.ToDateTime(Date).ToString("dd MMMM, yyyy");
                //string Month = Convert.ToDateTime(Date).ToString("dd MMMM, yyyy");
                //string Year = Convert.ToDateTime(Date).ToString("dd MMMM, yyyy");

                int DayInt = Convert.ToInt16(Date1.ToString("dd"));
                string Day = Convert.ToString(DayInt);
                string Month = Date1.ToString("MMMM");
                string Year = Date1.ToString("yyyy");

                if (Day == "1" || Day == "21" || Day == "31")
                    strDate = Day + "st " + Month + ", " + Year;

                else if (Day == "2" || Day == "22")
                    strDate = Day + "nd " + Month + ", " + Year;

                else if (Day == "3" || Day == "23")
                    strDate = Day + "rd " + Month + ", " + Year;
                else
                    strDate = Day + "th " + Month + ", " + Year;

            }



            return strDate;
        }

        private string GeneratePDF()
        {
            string logFilePath = Server.MapPath("../FinalReports/") + "test.txt";
            System.IO.File.WriteAllText(logFilePath, "PDF Beginning");

            //ExpertPdf.HtmlToPdf.PdfConverter pdfConverter = new ExpertPdf.HtmlToPdf.PdfConverter();
            //pdfConverter.LicenseKey = "OBMJGAAYCgENGAkIFggYCwkWCQoWAQEBAQ==";
            //set the license key
            LicensingManager.LicenseKey = "+dLI2cjI2cvAydnIydfJ2crI18jL18DAwMA=";

            //create a PDF document
            Document document = new Document();
            document.Margins = new Margins(0, 0, 0, 0);

            // add header and footer before renderng the content
            // add a font to the document that can be used for the texts elements 
            PdfFont font = document.Fonts.Add(new System.Drawing.Font(new System.Drawing.FontFamily("Verdana"), 8, System.Drawing.GraphicsUnit.Point));
            //AddHtmlHeader(document);
            //AddHtmlFooter(document, font);

            FillPdfDetails(document, font);


            System.IO.File.WriteAllText(logFilePath, "Details filled");
            //AddTab2Land(document, font);

            // send the generated PDF document to client browser
            string pdfName = Convert.ToString(lblJobId.Text) + "_" + DateTime.Now.ToString("yyyyddMM_HHMMss") + "_FinalReport.pdf";
            string strPath = Server.MapPath("../FinalReports/") + pdfName;


            if (File.Exists(strPath))
                File.Delete(strPath);

            document.Save(strPath);

            lblReportHtml.Text = strPath + "<br><br><br>" + lblReportHtml.Text;

            if (File.Exists(strPath))
                return pdfName;
            else
                return "";
        }

        private void FillPdfDetails(Document document, PdfFont font)
        {
            #region All DataSet Filled
            ReportController objReportController = new ReportController();
            DataSet dsTab1 = new DataSet();
            DataSet dsTab2 = new DataSet();
            DataSet dsTab3 = new DataSet();
            DataSet dsTab4 = new DataSet();
            DataSet dsTab5 = new DataSet();
            DataSet dsTab6 = new DataSet();
            DataSet dsTab7 = new DataSet();
            DataSet dsTab7_U = new DataSet();
            DataSet dsComanyInfo = new JobsController().JobsSelectByJobId(Convert.ToInt64(lblJobId.Text.Trim()));
            //DataSet dsTab8 = new DataSet();
            dsTab1 = objReportController.Tab1_SummarySelect(Convert.ToInt64(lblJobId.Text));
            dsTab2 = objReportController.Tab2_LandSelect(Convert.ToInt64(lblJobId.Text));
            dsTab3 = objReportController.Tab3_BuildingImprovementsSelect(Convert.ToInt64(lblJobId.Text));
            dsTab4 = objReportController.Tab4_RoomsFixtures(Convert.ToInt64(lblJobId.Text));
            dsTab5 = objReportController.Tab5_AreasSelect(Convert.ToInt64(lblJobId.Text));
            dsTab6 = objReportController.Tab6_CommentsSelect(Convert.ToInt64(lblJobId.Text));
            dsTab7 = objReportController.Tab7_SalesEvidenceSelect(0, Convert.ToInt64(lblJobId.Text));
            dsTab7_U = objReportController.Tab7_SalesEvidenceSelectUnique(0, Convert.ToInt64(lblJobId.Text));
            //dsTab8 = objReportController.Tab8_AttachmentsSelect(0,Convert.ToInt64(lblJobId.Text));
            if (dsTab1 != null && dsTab1.Tables.Count <= 0 && dsTab1.Tables[0].Rows.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('1. Summary tab details missing.');", true);
                return;
            }
            if (dsTab2 != null && dsTab2.Tables.Count <= 0 && dsTab2.Tables[0].Rows.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('2. Land tab details missing.');", true);
                return;
            }
            if (dsTab3 != null && dsTab3.Tables.Count <= 0 && dsTab3.Tables[0].Rows.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('3. Building & Improvements tab details missing.');", true);
                return;
            }
            if (dsTab4 != null && dsTab4.Tables.Count <= 0 && dsTab4.Tables[0].Rows.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('4. Rooms & Fixtures tab details missing.');", true);
                return;
            }
            if (dsTab5 != null && dsTab5.Tables.Count <= 0 && dsTab5.Tables[0].Rows.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('5. Area tab details missing.');", true);
                return;
            }
            if (dsTab6 != null && dsTab6.Tables.Count <= 0 && dsTab6.Tables[0].Rows.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('6. Comments tab details missing.');", true);
                return;
            }
            if (dsTab7 != null && dsTab7.Tables.Count <= 0 && dsTab7.Tables[0].Rows.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('7. Sales Evidence tab details missing.');", true);
                return;
            }


            //Get All photos dataset
            DataSet dsPrimaryPhoto = new DataSet();
            DataSet dsExternalPhoto = new DataSet();
            DataSet dsInternalPhoto = new DataSet();
            DataSet dsDefectPhoto = new DataSet();
            DataSet dsTitlePhoto = new DataSet();
            DataSet dsZoningPhoto = new DataSet();
            DataSet dsOverlayPhoto = new DataSet();
            DataSet dsOthersPhoto = new DataSet();

            dsPrimaryPhoto = Tab8GetImages("PrimaryPhoto");
            dsExternalPhoto = Tab8GetImages("ExternalPhoto");
            dsInternalPhoto = Tab8GetImages("InternalPhoto");
            dsDefectPhoto = Tab8GetImages("DefectPhoto");
            dsTitlePhoto = Tab8GetImages("TitlePhoto");
            dsZoningPhoto = Tab8GetImages("ZoningPhoto");
            dsOverlayPhoto = Tab8GetImages("OverlayPhoto");
            dsOthersPhoto = Tab8GetImages("OthersPhoto");
            #endregion

            //set the license key
            //LicensingManager.LicenseKey = "OBMJGAAYCgENGAkIFggYCwkWCQoWAQEBAQ==";
            //ExpertPdf.HtmlToPdf.PdfConverter pdfConverter = new ExpertPdf.HtmlToPdf.PdfConverter();

            //create a PDF document

            document.Margins = new Margins();

            //Add a first page to the document. 
            PdfPage page = document.Pages.AddNewPage();

            // add a font to the document that can be used for the texts elements 
            //TextElement pageNumberText = new TextElement(document.FooterTemplate.ClientRectangle.Width - 100, 30,
            //                    "Page &p; of &P; pages", font);


            // add header and footer before renderng the content
            AddHtmlHeader(document);
            AddHtmlFooter(document, font);


            #region First Page Header + Footer
            //First page Header and Footer 
            string headerAndFooterHtmlUrl = ConfigurationManager.AppSettings["URL"].ToString() + "EmailTemplates/HeaderAndFooterHtml1.htm";
            //create a template to be added in the header and footer
            document.Pages[0].CustomHeaderTemplate = document.AddTemplate(document.Pages[0].ClientRectangle.Width, 100);
            document.Pages[0].CustomFooterTemplate = document.AddTemplate(document.Pages[0].ClientRectangle.Width, 100);
            // create a HTML to PDF converter element to be added to the header template

            string strHFImageUrl = System.Configuration.ConfigurationManager.AppSettings["ImageURL"].ToString() + "CompanyLogo/";

            string companyUrl = string.Empty;
            string companyName = string.Empty;
            string companyAddress = string.Empty;
            string companyPhone = string.Empty;
            string propertyAddress = string.Empty;
            string valuationApproachId = string.Empty;
            string propertyType = string.Empty;
            string valuationApproach = string.Empty;
            string valuationCompanyHeaderImage = string.Empty;
            string valuationCompanyAssignedLogo = string.Empty;
            string valuationCompanyFooterImage = string.Empty;

            if (dsComanyInfo.Tables[0].Rows.Count > 0)
            {
                var _companyUrl = dsComanyInfo.Tables[0].Rows[0]["ValuationCompanyAssignedURL"];
                if (_companyUrl != null && _companyUrl != DBNull.Value)
                {
                    companyUrl = _companyUrl.ToString().Trim();
                }
            }

            if (dsComanyInfo.Tables[0].Rows.Count > 0)
            {
                var _companyName = dsComanyInfo.Tables[0].Rows[0]["ValuationCompanyAssignedName"];
                if (_companyName != null && _companyName != DBNull.Value)
                {
                    companyName = _companyName.ToString().Trim();
                }
            }

            if (dsComanyInfo.Tables[0].Rows.Count > 0)
            {
                var _companyAddress1 = dsComanyInfo.Tables[0].Rows[0]["ValuationCompanyAssignedAddress"];
                if (_companyAddress1 != null && _companyAddress1 != DBNull.Value)
                {
                    companyAddress = _companyAddress1.ToString().Trim();
                }
            }

            if (dsComanyInfo.Tables[0].Rows.Count > 0)
            {
                var _companyPhone = dsComanyInfo.Tables[0].Rows[0]["ValuationCompanyAssignedPhone1"];
                if (_companyPhone != null && _companyPhone != DBNull.Value)
                {
                    companyPhone = _companyPhone.ToString().Trim();
                }
            }

            if (dsComanyInfo.Tables[0].Rows.Count > 0)
            {
                var _valuationCompanyHeaderImage = dsComanyInfo.Tables[0].Rows[0]["valuationCompanyHeaderImage"];
                if (_valuationCompanyHeaderImage != null && _valuationCompanyHeaderImage != DBNull.Value)
                {
                    valuationCompanyHeaderImage = _valuationCompanyHeaderImage.ToString().Trim();
                }
            }

            if (dsComanyInfo.Tables[0].Rows.Count > 0)
            {
                var _valuationCompanyAssignedLogo = dsComanyInfo.Tables[0].Rows[0]["valuationCompanyAssignedLogo"];
                if (_valuationCompanyAssignedLogo != null && _valuationCompanyAssignedLogo != DBNull.Value)
                {
                    valuationCompanyAssignedLogo = _valuationCompanyAssignedLogo.ToString().Trim();
                }
            }

            if (dsComanyInfo.Tables[0].Rows.Count > 0)
            {
                var _valuationCompanyFooterImage = dsComanyInfo.Tables[0].Rows[0]["valuationCompanyFooterImage"];
                if (_valuationCompanyFooterImage != null && _valuationCompanyFooterImage != DBNull.Value)
                {
                    valuationCompanyFooterImage = _valuationCompanyFooterImage.ToString().Trim();
                }
            }






            if (dsTab1.Tables.Count > 0 && dsTab1.Tables[0].Rows.Count > 0)
            {

                propertyAddress = dsTab1.Tables[0].Rows[0]["StreetNumber"] + " " +
                                  dsTab1.Tables[0].Rows[0]["StreetName"] + " " +
                                  dsTab1.Tables[0].Rows[0]["StreetType"] + ", " +
                                   dsTab1.Tables[0].Rows[0]["Suburb"] + "&nbsp;&nbsp;" +
                                   dsTab1.Tables[0].Rows[0]["State"] + "&nbsp;&nbsp;" +
                                   dsTab1.Tables[0].Rows[0]["Postcode"];

                propertyAddress = propertyAddress.Trim();

                valuationApproach = dsTab1.Tables[0].Rows[0]["ValuationApproach"].ToString();
            }

            if (dsTab2.Tables[0].Rows.Count > 0)
            {
                var _propertyType = dsTab2.Tables[0].Rows[0]["PropertyType"];
                if (_propertyType != null && _propertyType != DBNull.Value)
                {
                    propertyType = _propertyType.ToString().Trim();
                }
            }


            string padding = "165";

            /**********************************/
            string strHeaderHtml = "";
            if (valuationCompanyHeaderImage.Trim() != "")
            {
                strHeaderHtml += "<table width='1020px' cellpadding='0' cellspacing='0' border='0x'>";
                strHeaderHtml += "<tr><td align='center' style='height:50px;'><img style='width:100%;' src='" + strHFImageUrl + valuationCompanyHeaderImage.Trim() + "' /></td></tr>";
                strHeaderHtml += "</table>";
            }
            else
            {
                strHeaderHtml += "<table width='1020px' cellpadding='0' cellspacing='0' border='0x' style='border-top:solid 4px Red;font-family:Verdana; font-size:17px;color:white;'>";
                strHeaderHtml += "<tr><td align='center' style='background-color:#4D4E50; height:90px; font-size:30px;'>" + companyUrl.Trim() + "</td></tr>";
                strHeaderHtml += "</table>";
            }


            string strFooterHtml = "<table width='1020px' cellpadding='0' cellspacing='0' border='0x' style='font-family:Verdana; font-size:17px;'>";
            //strFooterHtml += "<tr><td align='center' style='font-size:25px; color:#4D4E50;font-weight:bold;'>" + lblCompanyName.Text.Trim() + "</td></tr>";
            //strFooterHtml += "<tr><td align='center' style='font-size:18px;color:grey;font-weight:bold;'>" + lblCompanyAddress.Text.Trim() + "  Phone:- " + lblCompanyPhone.Text.Trim() + "</td></tr>";
            strFooterHtml += "<tr><td align='center'><img src='" + strHFImageUrl + valuationCompanyAssignedLogo.Trim() + "' /></td></tr>";
            if (lblCompanyFooterImage.Text.Trim() != "")
                strFooterHtml += "<tr><td align='center'><img style='width:100%;' src='" + strHFImageUrl + valuationCompanyFooterImage.Trim() + "' /></td></tr>";
            else
                strFooterHtml += "<tr><td align='center' style='background-color:#4D4E50;color:white;height:80px; font-size:30px;border-top:solid 4px Red;'>" + companyUrl.Trim() + "</td></tr>";

            strFooterHtml += "</table>";
            /***********************************/

            //string strHeaderHtml1 = "<table width='1020px' cellpadding='0' cellspacing='0' border='0x' style='border-top:solid 4px Red;font-family:Verdana; font-size:17px;color:white;'>";
            //strHeaderHtml += "<tr><td align='center' style='background-color:#2A3492; height:90px; font-size:30px;'>" + companyUrl + "</td></tr>";
            //strHeaderHtml += "</table>";

            //string strFooterHtml1 = "<table width='1020px' cellpadding='0' cellspacing='0' border='0x' style='font-family:Verdana; font-size:17px;'>";
            //strFooterHtml += "<tr><td align='center' style='font-size:25px; color:darkblue;font-weight:bold;'>" + companyName + "</td></tr>";
            //strFooterHtml += "<tr><td align='center' style='font-size:18px;color:grey;font-weight:bold;'>" + companyAddress + "  Phone:- " + companyPhone + "</td></tr>";
            //strFooterHtml += "<tr><td align='center' style='height:15px;'></td></tr>";
            //strFooterHtml += "<tr><td align='center' style='background-color:#2A3492;color:white;height:80px; font-size:30px;border-top:solid 4px Red;'>" + lblCompanyUrl.Text.Trim() + "</td></tr>";
            //strFooterHtml += "</table>";

            //HtmlToPdfElement headerHtmlToPdf = new HtmlToPdfElement(-6, -9, strHeaderHtml, "");
            //HtmlToPdfElement footerHtmlToPdf = new HtmlToPdfElement(-6, 42, strFooterHtml, "");

            HtmlToPdfElement headerHtmlToPdf = new HtmlToPdfElement(-6, 0, strHeaderHtml, "");
            HtmlToPdfElement footerHtmlToPdf = new HtmlToPdfElement(-6, 0, strFooterHtml, "");

            document.Pages[0].CustomHeaderTemplate.Height = 60;
            //document.Pages[0].CustomFooterTemplate.Height = 250;

            document.Pages[0].CustomHeaderTemplate.AddElement(headerHtmlToPdf);
            document.Pages[0].CustomFooterTemplate.AddElement(footerHtmlToPdf);
            #endregion

            #region First Page

            string logFilePath = Server.MapPath("../FinalReports/") + "test.txt";
            System.IO.File.WriteAllText(logFilePath, "1st step");

            string strPageContents = "<table width='1000px' cellpadding='0' cellspacing='5' border='0' style='font-family:Verdana; font-size:17px; font-weight:bold;'>";

            string strProperty = "";
            strPageContents += "<tr><td align='center' style='height:10px;'></td></tr>";
            strPageContents += "<tr><td align='center' style='font-size:20px;'><b>VALUATION</b></td></tr>";
            strPageContents += "<tr><td align='center' style='height:10px;'></td></tr>";
            strPageContents += "<tr><td align='center' style='font-size:20px; color:grey;'><b>For " + Convert.ToString(dsTab1.Tables[0].Rows[0]["Purpose"]) + " Purposes</b></td></tr>";
            strPageContents += "<tr><td align='center' style='height:20px;'></td></tr>";

            string strImageName = GetPrimaryPhoto();

            if (!string.IsNullOrEmpty(strImageName))
            {
                string strImageUrl = System.Configuration.ConfigurationManager.AppSettings["ImageURL"].ToString() + strImageName;
                System.Drawing.Image imgImage1 = System.Drawing.Image.FromFile(this.Server.MapPath("~/" + strImageName));

                Int32 imgWidth1 = imgImage1.Width;
                Int32 imgHeight1 = imgImage1.Height;

                //if (imgWidth1 > 700) imgWidth1 = 700;
                //if (imgHeight1 > 550) imgHeight1 = 550;

                strPageContents += "<tr><td align='center'><div style='width:100%;height:100%;padding-left:" + padding + "px;padding-right:" + padding + "'><img src='" + strImageUrl + "' /></div></td></tr>";
            }
            strPageContents += "<tr><td align='center' style='height:40px;'></td></tr>";
            strPageContents += "<tr><td align='center'><b>Property:</b></td></tr>";

            strProperty = Convert.ToString(dsTab1.Tables[0].Rows[0]["StreetNumber"]) + " " +
                Convert.ToString(dsTab1.Tables[0].Rows[0]["StreetName"]) + " " +
                Convert.ToString(dsTab1.Tables[0].Rows[0]["StreetType"]) + ", " +
                Convert.ToString(dsTab1.Tables[0].Rows[0]["Suburb"]) + " " +
                Convert.ToString(dsTab1.Tables[0].Rows[0]["State"]) + " " +
                Convert.ToString(dsTab1.Tables[0].Rows[0]["Postcode"]);
            strPageContents += "<tr><td align='center' style='color:Gray;'><b>" + strProperty + "</b></td></tr>";

            strPageContents += "<tr><td align='center' style='height:30px;'>&nbsp;</td></tr>";

            if (Convert.ToString(dsTab1.Tables[0].Rows[0]["InstructedBy"]) == Convert.ToString(dsTab1.Tables[0].Rows[0]["Client"]))
            {
                strPageContents += "<tr><td align='center'><b>Client Name:</b></td></tr>";
                strPageContents += "<tr><td align='center' style='color:Gray;'><b>" + Convert.ToString(dsTab1.Tables[0].Rows[0]["Client"]) + "</b></td></tr>";
                strPageContents += "<tr><td align='center' style='height:30px;'>&nbsp;</td></tr>";
            }
            else
            {
                if (Convert.ToString(dsTab1.Tables[0].Rows[0]["InstructedBy"]) != "")
                {
                    strPageContents += "<tr><td align='center'><b>Instructed by:</b></td></tr>";
                    strPageContents += "<tr><td align='center' style='color:Gray;'><b>" + Convert.ToString(dsTab1.Tables[0].Rows[0]["InstructedBy"]) + "</b></td></tr>";
                    strPageContents += "<tr><td align='center' style='height:30px;'>&nbsp;</td></tr>";
                }
                strPageContents += "<tr><td align='center'><b>Client Name:</b></td></tr>";
                strPageContents += "<tr><td align='center' style='color:Gray;'><b>" + Convert.ToString(dsTab1.Tables[0].Rows[0]["Client"]) + "</b></td></tr>";
                strPageContents += "<tr><td align='center' style='height:30px;'>&nbsp;</td></tr>";
            }

            //strPageContents += "<tr><td align='center' style='height:15px;'></td></tr>";
            strPageContents += "<tr><td align='center'><b>Date of Inspection: <br><span style='color:Gray;'>" + GetDateFormat(dsTab1.Tables[0].Rows[0]["InspectionDate"].ToString()) + "</span></b></td></tr>";
            strPageContents += "<tr><td align='center' style='height:30px;'>&nbsp;</td></tr>";
            strPageContents += "<tr><td align='center'><b>Date of Valuation: <br><span style='color:Gray;'>" + GetDateFormat(dsTab1.Tables[0].Rows[0]["ValuationsDate"].ToString()) + "</span></b></td></tr>";
            //strPageContents += "<tr><td align='center' style='height:25px;'>&nbsp;</td></tr>";
            //strPageContents += GetCompanyDetails();
            strPageContents += "</table>";


            HtmlToPdfElement htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strPageContents, "");

            page.AddElement(htmlToPdfURL2);

            System.IO.File.WriteAllText(logFilePath, "2nd step");

            #endregion

            lblReportHtml.Text = strPageContents;

            #region Second Page

            strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='margin-left:120px;margin-right:40px;font-family:Verdana; font-size:18px;'>";

            strPageContents += "<tr><td style='width:300px;'></td><td style='width:430px;'></td></tr>";
            if (Convert.ToString(dsTab1.Tables[0].Rows[0]["Client"]) == Convert.ToString(dsTab1.Tables[0].Rows[0]["InstructedBy"]))
                strPageContents += "<tr><td style='font-weight:bold;'>Client:</td><td>" + Convert.ToString(dsTab1.Tables[0].Rows[0]["Client"]) + "</td></tr>";
            else
            {
                if (Convert.ToString(dsTab1.Tables[0].Rows[0]["InstructedBy"]) != "")
                {
                    strPageContents += "<tr><td style='font-weight:bold;'>INSTRUCTED BY:</td><td>" + Convert.ToString(dsTab1.Tables[0].Rows[0]["InstructedBy"]) + "</td></tr>";
                    strPageContents += "<tr><td colspan='2'></td></tr>";
                }
                strPageContents += "<tr><td style='font-weight:bold;'>CLIENT:</td><td>" + Convert.ToString(dsTab1.Tables[0].Rows[0]["Client"]) + "</td></tr>";
            }
            strPageContents += "<tr><td colspan='2' style='height:18px;'></td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>INSTRUCTIONS:</td><td>" + Convert.ToString(dsTab1.Tables[0].Rows[0]["Instructions"]) + "</td></tr>";
            strPageContents += "<tr><td colspan='2' style='height:18px;'></td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>PROPERTY ADDRESS:</td><td>" + propertyAddress + "</td></tr>";
            strPageContents += "<tr><td colspan='2' style='height:18px;'></td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>DATE OF INSPECTION:</td><td>" + GetDateFormat(dsTab1.Tables[0].Rows[0]["InspectionDate"].ToString()) + "</td></tr>";
            strPageContents += "<tr><td colspan='2' style='height:18px;'></td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>DATE OF VALUATION:</td><td>" + GetDateFormat(dsTab1.Tables[0].Rows[0]["ValuationsDate"].ToString()) + "</td></tr>";
            strPageContents += "<tr><td colspan='2' style='height:18px;'></td></tr>";

            strPageContents += "<tr><td style='font-weight:bold;' colspan='2'>TITLE DETAILS:</td><td></td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>Lot No:</td><td>" + Convert.ToString(dsTab2.Tables[0].Rows[0]["LotNumber"]) + "</td></tr>";
            if (Convert.ToString(dsTab2.Tables[0].Rows[0]["PlanTitle"]) != "" && Convert.ToString(dsTab2.Tables[0].Rows[0]["PlanNumber"]) != "")
                strPageContents += "<tr><td style='font-weight:bold;'>" + Convert.ToString(dsTab2.Tables[0].Rows[0]["PlanTitle"]) + ":</td><td>" + Convert.ToString(dsTab2.Tables[0].Rows[0]["PlanNumber"]) + "</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>Volume:</td><td>" + Convert.ToString(dsTab2.Tables[0].Rows[0]["Volume"]) + "</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>Folio:</td><td>" + Convert.ToString(dsTab2.Tables[0].Rows[0]["Folio"]) + "</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>Encumbrances:</td><td>" + Convert.ToString(dsTab2.Tables[0].Rows[0]["Encumbrances"]) + "</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>Registered Proprietors:</td><td>" + Convert.ToString(dsTab2.Tables[0].Rows[0]["RegisteredProprietors"]) + "</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>Site Total:</td><td>" + Convert.ToString(dsTab2.Tables[0].Rows[0]["SiteArea"]) + " " + Convert.ToString(dsTab2.Tables[0].Rows[0]["SqmHectares"]) + "</td></tr>";
            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";

            strPageContents += "<tr><td style='font-weight:bold;' colspan='2'>ZONING/PLANNING INSTRUMENT:</td><td></td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>Local Government Area:</td><td>" + Convert.ToString(dsTab2.Tables[0].Rows[0]["LocalGovernmentArea"]) + "</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>Zoning:</td><td>" + Convert.ToString(dsTab2.Tables[0].Rows[0]["Zoning"]) + "</td></tr>";

            if (Convert.ToString(dsTab2.Tables[0].Rows[0]["Overlays"]) != "")
            {
                strPageContents += "<tr><td style='font-weight:bold;'>Overlays:</td><td>" + Convert.ToString(dsTab2.Tables[0].Rows[0]["Overlays"]) + "</td></tr>";
            }
            strPageContents += "<tr><td style='font-weight:bold;'>Effect:</td><td>" + Convert.ToString(dsTab2.Tables[0].Rows[0]["ZoningEffect"]) + "</td></tr>";
            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;' colspan='2'>LOCATION/NEIGHBOURHOOD:</td><td></td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>Shops:</td><td>Within " + Convert.ToString(dsTab2.Tables[0].Rows[0]["Shops"]) + " kilometre</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>Transport:</td><td>Within " + Convert.ToString(dsTab2.Tables[0].Rows[0]["Transport"]) + " kilometre</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>Schools:</td><td>Within " + Convert.ToString(dsTab2.Tables[0].Rows[0]["Schools"]) + " kilometre</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>CBD:</td><td>Approximately " + Convert.ToString(dsTab2.Tables[0].Rows[0]["CBD"]) + " kilometre</td></tr>";
            strPageContents += "</table>";
            page = document.Pages.AddNewPage();
            htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strPageContents, "");
            page.AddElement(htmlToPdfURL2);

            strPageContents = "<table  cellpadding='0' cellspacing='9' border='0' style='margin-left:120px;margin-right:40px;font-family:Verdana; font-size:18px;'>";
            strPageContents += "<tr><td style='font-weight:bold;' colspan='2'>SITE DESCRIPTION AND TOPOGRAPHY:</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>Site Layout:</td><td>" + Convert.ToString(dsTab2.Tables[0].Rows[0]["SiteLayout"]) + "</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>Services:</td><td>" + Convert.ToString(dsTab2.Tables[0].Rows[0]["Services"]) + "</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>Environmental Hazards:</td><td>" + Convert.ToString(dsTab2.Tables[0].Rows[0]["EnvironmentalHazards"]) + "</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>Pest Infestation:</td><td>" + Convert.ToString(dsTab2.Tables[0].Rows[0]["PestInfestation"]) + "</td></tr>";
            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>MAIN BUILDING:</td><td></td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>Type:</td><td>" + propertyType + "</td></tr>";

            if (Convert.ToString(dsTab3.Tables[0].Rows[0]["PropertyStyle"]) != "0")
                strPageContents += "<tr><td style='font-weight:bold;'>Style:</td><td>" + Convert.ToString(dsTab3.Tables[0].Rows[0]["PropertyStyle"]) + "</td></tr>";

            strPageContents += "<tr><td style='font-weight:bold;'>Year Built:</td><td>" + Convert.ToString(dsTab3.Tables[0].Rows[0]["YearBuilt"]) + "</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>External Walls:</td><td>" + Convert.ToString(dsTab3.Tables[0].Rows[0]["ExternalWalls"]) + "</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>Roof:</td><td>" + Convert.ToString(dsTab3.Tables[0].Rows[0]["Roof"]) + "</td></tr>";

            string strRooms = "";
            if (Convert.ToString(dsTab4.Tables[0].Rows[0]["Rooms1"]) != "")
            {
                strRooms += Convert.ToString(dsTab4.Tables[0].Rows[0]["Rooms1"]).Replace("@", ", ");
                strRooms = strRooms.TrimEnd(' ');
                strRooms = strRooms.TrimEnd(',') + ", ";
            }
            if (Convert.ToString(dsTab4.Tables[0].Rows[0]["Rooms2"]) != "")
            {
                strRooms += Convert.ToString(dsTab4.Tables[0].Rows[0]["Rooms2"]).Replace("@", ", ");
                strRooms = strRooms.TrimEnd(' ');
                strRooms = strRooms.TrimEnd(',') + ", ";
            }
            if (Convert.ToString(dsTab4.Tables[0].Rows[0]["Rooms3"]) != "")
            {
                strRooms += Convert.ToString(dsTab4.Tables[0].Rows[0]["Rooms3"]).Replace("@", ", ");
                strRooms = strRooms.TrimEnd(' ');
                strRooms = strRooms.TrimEnd(',') + ", ";
            }
            if (Convert.ToString(dsTab4.Tables[0].Rows[0]["Rooms4"]) != "")
            {
                strRooms += Convert.ToString(dsTab4.Tables[0].Rows[0]["Rooms4"]).Replace("@", ", ");
                strRooms = strRooms.TrimEnd(' ');
                strRooms = strRooms.TrimEnd(',') + ", ";
            }

            if (strRooms != "")
            {
                strRooms = strRooms.Replace("@", ", ");
                strRooms = strRooms.TrimEnd(' ');
                strRooms = strRooms.TrimEnd(',');

                if (Convert.ToString(dsTab4.Tables[0].Rows[0]["Laundry"]) != "")
                    strRooms = strRooms + ", " + Convert.ToString(dsTab4.Tables[0].Rows[0]["Laundry"]);

                if (Convert.ToString(dsTab4.Tables[0].Rows[0]["Text1"]) != "")
                    strRooms = strRooms + ", " + Convert.ToString(dsTab4.Tables[0].Rows[0]["Text1"]);

                strPageContents += "<tr><td style='font-weight:bold;' valign='top'>Rooms:</td><td>" + strRooms + "</td></tr>";
            }

            strPageContents += "<tr><td style='font-weight:bold;'>Bedrooms:</td><td>" + Convert.ToString(dsTab4.Tables[0].Rows[0]["Bedroom"]) + " Bedroom</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>Bathrooms:</td><td>" + Convert.ToString(dsTab4.Tables[0].Rows[0]["Bathroom"]) + " Bathroom</td></tr>";

            if (Convert.ToString(dsTab4.Tables[0].Rows[0]["Ensuite"]).Trim() != "0")
                strPageContents += "<tr><td style='font-weight:bold;'>Ensuites:</td><td>" + Convert.ToString(dsTab4.Tables[0].Rows[0]["Ensuite"]) + " Ensuite</td></tr>";

            strPageContents += "<tr><td style='font-weight:bold;'>Toilets:</td><td>" + Convert.ToString(dsTab4.Tables[0].Rows[0]["Toilet"]) + " Toilet</td></tr>";
            //strPageContents += "<tr><td style='font-weight:bold;'>Laundry:</td><td>" + Convert.ToString(dsTab4.Tables[0].Rows[0]["Laundry"]) + "</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>Wall Linings:</td><td>" + Convert.ToString(dsTab3.Tables[0].Rows[0]["InteriorLinings"]) + "</td></tr>";

            string strHeatingColling = "";
            if (Convert.ToString(dsTab4.Tables[0].Rows[0]["HeatingCooling"]) != "")
                strHeatingColling = Convert.ToString(dsTab4.Tables[0].Rows[0]["HeatingCooling"]);
            if (strHeatingColling != "")
            {
                strHeatingColling = strHeatingColling.Replace("@", ", ");
                strHeatingColling = strHeatingColling.TrimEnd(' ');
                strHeatingColling = strHeatingColling.TrimEnd(',');
                strHeatingColling = strHeatingColling.TrimEnd(',');
                strPageContents += "<tr><td style='font-weight:bold;' valign='top'>Heating & Cooling:</td><td>" + strHeatingColling + "</td></tr>";
            }


            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>OBSERVATIONS:</td><td></td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>Internal Condition:</td><td>" + Convert.ToString(dsTab3.Tables[0].Rows[0]["InternalCondition"]) + "</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>External Condition:</td><td>" + Convert.ToString(dsTab3.Tables[0].Rows[0]["ExternalCondition"]) + "</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>Street Appeal:</td><td>" + Convert.ToString(dsTab3.Tables[0].Rows[0]["StreetAppeal"]) + "</td></tr>";

            strPageContents += "</table>";
            page = document.Pages.AddNewPage();
            htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strPageContents, "");
            page.AddElement(htmlToPdfURL2);


            #endregion

            #region Third Page

            strPageContents = "<table  cellpadding='0' cellspacing='9' border='0' style='margin-left:120px;margin-right:40px;font-family:Verdana; font-size:18px;'>";

            strPageContents += "<tr><td style='width:300px;'></td><td style='width:430px;'></td></tr>";
            strPageContents += "<tr><td colspan='2' style='font-weight:bold;'>ANCILLARY IMPROVEMENTS:</td><td></td></tr>";
            strPageContents += "<tr><td colspan='2'></td></tr>";

            string strPergolaVerandah = "";
            if (Convert.ToString(dsTab3.Tables[0].Rows[0]["PergolaVerandah"]) != "")
                strPergolaVerandah = Convert.ToString(dsTab3.Tables[0].Rows[0]["PergolaVerandah"]);
            if (strPergolaVerandah != "")
            {
                strPergolaVerandah = strPergolaVerandah.Replace("@", ", ");
                strPergolaVerandah = strPergolaVerandah.TrimEnd(' ');
                strPergolaVerandah = strPergolaVerandah.TrimEnd(',');
                strPageContents += "<tr><td valign='top' style='font-weight:bold;'>Pergola/ Verandah:</td><td>" + strPergolaVerandah + "</td></tr>";
            }

            string strShedding = "";
            if (Convert.ToString(dsTab3.Tables[0].Rows[0]["Shedding"]) != "")
                strShedding = Convert.ToString(dsTab3.Tables[0].Rows[0]["Shedding"]);
            if (strShedding != "")
            {
                strShedding = strShedding.Replace("@", ", ");
                strShedding = strShedding.TrimEnd(' ');
                strShedding = strShedding.TrimEnd(',');
                strPageContents += "<tr><td valign='top' style='font-weight:bold;'>Shedding:</td><td>" + strShedding + "</td></tr>";
            }

            string strPools = "";
            if (Convert.ToString(dsTab3.Tables[0].Rows[0]["Pools"]) != "")
                strPools = Convert.ToString(dsTab3.Tables[0].Rows[0]["Pools"]);
            if (strPools != "")
            {
                strPools = strPools.Replace("@", ", ");
                strPools = strPools.TrimEnd(' ');
                strPools = strPools.TrimEnd(',');
                strPageContents += "<tr><td valign='top' style='font-weight:bold;'>Pools:</td><td>" + strPools + "</td></tr>";
            }

            string strGardens = "";
            if (Convert.ToString(dsTab3.Tables[0].Rows[0]["Gardens"]) != "")
                strGardens = Convert.ToString(dsTab3.Tables[0].Rows[0]["Gardens"]);
            if (strGardens != "")
            {
                strGardens = strGardens.Replace("@", ", ");
                strGardens = strGardens.TrimEnd(' ');
                strGardens = strGardens.TrimEnd(',');
                strPageContents += "<tr><td valign='top' style='font-weight:bold;'>Gardens:</td><td>" + strGardens + "</td></tr>";
            }

            string strFencing = "";
            if (Convert.ToString(dsTab3.Tables[0].Rows[0]["Fencing"]) != "")
                strFencing = Convert.ToString(dsTab3.Tables[0].Rows[0]["Fencing"]);
            if (strFencing != "")
            {
                strFencing = strFencing.Replace("@", ", ");
                strFencing = strFencing.TrimEnd(' ');
                strFencing = strFencing.TrimEnd(',');
                strPageContents += "<tr><td valign='top' style='font-weight:bold;'>Fencing:</td><td>" + strFencing + "</td></tr>";
            }

            string strDrivewayPaving = "";
            if (Convert.ToString(dsTab3.Tables[0].Rows[0]["DrivewayPaving"]) != "")
                strDrivewayPaving = Convert.ToString(dsTab3.Tables[0].Rows[0]["DrivewayPaving"]);
            if (strDrivewayPaving != "")
            {
                strDrivewayPaving = strDrivewayPaving.Replace("@", ", ");
                strDrivewayPaving = strDrivewayPaving.TrimEnd(' ');
                strDrivewayPaving = strDrivewayPaving.TrimEnd(',');
                strPageContents += "<tr><td valign='top' style='font-weight:bold;'>Driveway & Paving:</td><td>" + strDrivewayPaving + "</td></tr>";
            }

            string strOutbuildings = "";
            if (Convert.ToString(dsTab3.Tables[0].Rows[0]["Outbuildings"]) != "")
                strOutbuildings = Convert.ToString(dsTab3.Tables[0].Rows[0]["Outbuildings"]);
            if (strOutbuildings != "")
            {
                strOutbuildings = strOutbuildings.Replace("@", ", ");
                strOutbuildings = strOutbuildings.TrimEnd(' ');
                strOutbuildings = strOutbuildings.TrimEnd(',');
                strPageContents += "<tr><td valign='top' style='font-weight:bold;'>Outbuildings:</td><td>" + strOutbuildings + "</td></tr>";
            }
            strPageContents += "<tr><td style='font-weight:bold;'></td><td>" + Convert.ToString(dsTab3.Tables[0].Rows[0]["AncillaryImprovements"]) + "</td></tr>";



            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strPageContents += "<tr><td style='font-weight:bold;'>AREAS:</td><td></td></tr>";
            strPageContents += "<tr><td colspan='2'></td></tr>";

            if (Convert.ToString(dsTab5.Tables[0].Rows[0]["LivingArea"]) != "" && Convert.ToString(dsTab5.Tables[0].Rows[0]["LivingArea"]) != "0")
                strPageContents += "<tr><td style='font-weight:bold;'>Main Living Area:</td><td>" + Convert.ToString(dsTab5.Tables[0].Rows[0]["LivingArea"]) + " " + Convert.ToString(dsTab5.Tables[0].Rows[0]["SqmEq"]) + "</td></tr>";
            if (Convert.ToString(dsTab5.Tables[0].Rows[0]["Garage"]) != "" && Convert.ToString(dsTab5.Tables[0].Rows[0]["Garage"]) != "0")
                strPageContents += "<tr><td style='font-weight:bold;'>Garage:</td><td>" + Convert.ToString(dsTab5.Tables[0].Rows[0]["Garage"]) + " sqm</td></tr>";
            if (Convert.ToString(dsTab5.Tables[0].Rows[0]["Carport"]) != "" && Convert.ToString(dsTab5.Tables[0].Rows[0]["Carport"]) != "0")
                strPageContents += "<tr><td style='font-weight:bold;'>Carport:</td><td>" + Convert.ToString(dsTab5.Tables[0].Rows[0]["Carport"]) + " sqm</td></tr>";
            if (Convert.ToString(dsTab5.Tables[0].Rows[0]["CarSpaces"]) != "" && Convert.ToString(dsTab5.Tables[0].Rows[0]["CarSpaces"]) != "0")
                strPageContents += "<tr><td style='font-weight:bold;'>Car Spaces:</td><td>" + Convert.ToString(dsTab5.Tables[0].Rows[0]["CarSpaces"]) + " sqm</td></tr>";
            if (Convert.ToString(dsTab5.Tables[0].Rows[0]["Balcony"]) != "" && Convert.ToString(dsTab5.Tables[0].Rows[0]["Balcony"]) != "0")
                strPageContents += "<tr><td style='font-weight:bold;'>Balcony:</td><td>" + Convert.ToString(dsTab5.Tables[0].Rows[0]["Balcony"]) + " sqm</td></tr>";
            if (Convert.ToString(dsTab5.Tables[0].Rows[0]["Verandah"]) != "" && Convert.ToString(dsTab5.Tables[0].Rows[0]["Verandah"]) != "0")
                strPageContents += "<tr><td style='font-weight:bold;'>Verandah:</td><td>" + Convert.ToString(dsTab5.Tables[0].Rows[0]["Verandah"]) + " sqm</td></tr>";
            if (Convert.ToString(dsTab5.Tables[0].Rows[0]["Alfresco"]) != "" && Convert.ToString(dsTab5.Tables[0].Rows[0]["Alfresco"]) != "0")
                strPageContents += "<tr><td style='font-weight:bold;'>Alfresco:</td><td>" + Convert.ToString(dsTab5.Tables[0].Rows[0]["Alfresco"]) + " sqm</td></tr>";
            if (Convert.ToString(dsTab5.Tables[0].Rows[0]["Pergola"]) != "" && Convert.ToString(dsTab5.Tables[0].Rows[0]["Pergola"]) != "0")
                strPageContents += "<tr><td style='font-weight:bold;'>Pergola:</td><td>" + Convert.ToString(dsTab5.Tables[0].Rows[0]["Pergola"]) + " sqm</td></tr>";

            strPageContents += "</table>";
            page = document.Pages.AddNewPage();
            htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strPageContents, "");
            page.AddElement(htmlToPdfURL2);
            #endregion

            #region Comments

            strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='margin-left:120px;margin-right:80px;font-family:Verdana; font-size:18px;'>";
            //strPageContents += "<tr><td style='width:300px;'></td><td style='width:350px;'></td></tr>";
            //strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='margin-left:80px;margin-right:50px;font-family:Verdana; font-size:18px;'>";
            strPageContents += "<tr><td></td><td></td></tr>";
            strPageContents += "<tr><td colspan='2' style='font-weight:bold;'>GENERAL COMMENTS:</td></tr>";
            strPageContents += "<tr><td colspan='2' style='font-weight:bold;'>&nbsp;</td></tr>";

            //<tr><td colspan='2' style='text-align:justify;'>"
            //<tr><td colspan='2'>&nbsp;</td></tr>";

            string instructions = string.Empty;
            string standard = string.Empty;
            string lastSaleofProperty = string.Empty;
            string defects = string.Empty;
            string methodology = string.Empty;
            string closing = string.Empty;

            if (dsTab6.Tables[0].Rows.Count > 0)
            {
                var _instructions = dsTab6.Tables[0].Rows[0]["Instructions"];
                if (_instructions != null && _instructions != DBNull.Value)
                {
                    instructions = _instructions.ToString().Trim();
                }
            }

            if (dsTab6.Tables[0].Rows.Count > 0)
            {
                var _standard = dsTab6.Tables[0].Rows[0]["standard"];
                if (_standard != null && _standard != DBNull.Value)
                {
                    standard = _standard.ToString().Trim();
                }
            }

            if (dsTab6.Tables[0].Rows.Count > 0)
            {
                var _lastSaleofProperty = dsTab6.Tables[0].Rows[0]["LastSaleofProperty"];
                if (_lastSaleofProperty != null && _lastSaleofProperty != DBNull.Value)
                {
                    lastSaleofProperty = _lastSaleofProperty.ToString().Trim();
                }
            }

            if (dsTab6.Tables[0].Rows.Count > 0)
            {
                var _defects = dsTab6.Tables[0].Rows[0]["Defects"];
                if (_defects != null && _defects != DBNull.Value)
                {
                    defects = _defects.ToString().Trim();
                }
            }

            if (dsTab6.Tables[0].Rows.Count > 0)
            {
                var _methodology = dsTab6.Tables[0].Rows[0]["Methodology"];
                if (_methodology != null && _methodology != DBNull.Value)
                {
                    methodology = _methodology.ToString().Trim();
                }
            }

            if (dsTab6.Tables[0].Rows.Count > 0)
            {
                var _Closing = dsTab6.Tables[0].Rows[0]["Closing"];
                if (_Closing != null && _Closing != DBNull.Value)
                {
                    closing = _Closing.ToString().Trim();
                }
            }

            // if (txtTab6Instructions.Text.Trim() != "")
            if (!string.IsNullOrEmpty(instructions))
            {
                //strPageContents += "<tr><td colspan='2' style='font-weight:bold;'>Instructions:</td></tr>";
                strPageContents += "<tr style='text-align:justify;'><td colspan='2'>" + instructions.Trim().Replace("\r", "<br />") + "</td></tr>";
                strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            }
            //if (txtTab6Standard.Text.Trim() != "")
            if (!string.IsNullOrEmpty(standard))
            {
                //strPageContents += "<tr><td colspan='2' style='font-weight:bold;'>Property Comment:</td></tr>";
                strPageContents += "<tr style='text-align:justify;'><td colspan='2'>" + standard.Trim().Replace("\r", "<br />") + "</td></tr>";
                strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            }

            //if (txtTab6LastSaleofProperty.Text.Trim() != "")
            if (!string.IsNullOrEmpty(lastSaleofProperty))
            {
                //strPageContents += "<tr><td colspan='2' style='font-weight:bold;'>Last Sale Date of Property:</td></tr>";
                strPageContents += "<tr style='text-align:justify;'><td colspan='2'>" + lastSaleofProperty.Trim().Replace("\r", "<br />") + "</td></tr>";
                strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            }
            //if (txtTab6Defects.Text.Trim() != "")
            if (!string.IsNullOrEmpty(defects))
            {
                //strPageContents += "<tr><td colspan='2' style='font-weight:bold;'>Defects & Effect On Value:</td></tr>";
                strPageContents += "<tr style='text-align:justify;'><td colspan='2'>" + defects.Trim().Replace("\r", "<br />") + "</td></tr>";
                strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            }
            //if (txtTab6Methodology.Text.Trim() != "")
            if (!string.IsNullOrEmpty(methodology))
            {
                //string strTab6Methodology = txtTab6Methodology.Text.Trim().Replace("\r\r\rSale 1:{must be an inferior within 10% of assessed value}", "");
                //strTab6Methodology = strTab6Methodology.Trim().Replace("\r\rSale 2:{must be a comparable value}", "");
                //strTab6Methodology = strTab6Methodology.Trim().Replace("\r\rSale 3:{must be a superior within 10% of assessed value}", "");

                //strPageContents += "<tr><td colspan='2' style='font-weight:bold;'>Methodology & Sales Evidence:</td></tr>";
                strPageContents += "<tr style='text-align:justify;'><td colspan='2'>" + methodology.Trim().Replace("\r", "<br />") + "</td></tr>";
                strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            }
            // if (txtTab6Closing.Text.Trim() != "")
            if (!string.IsNullOrEmpty(closing))
            {
                strPageContents += "<tr style='text-align:justify;'><td colspan='2'>" + closing.Trim().Trim().Replace("{marketvalue replace}", Convert.ToString(dsTab1.Tables[0].Rows[0]["MarketValue"])).Replace("\r", "<br />").Replace("{MARKET VALUE:}", "<br><br><br><b>MARKET VALUE: $" + Convert.ToString(dsTab1.Tables[0].Rows[0]["MarketValue"])) + "</b></td></tr>";
            }

            strPageContents += "</table>";

            page = document.Pages.AddNewPage();
            //htmlToPdfURL2 = new HtmlToPdfElement(0, 0, 0, 0, strPageContents, "", 1100, 5000);
            htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strPageContents, "");
            htmlToPdfURL2.AvoidTextBreak = true;
            htmlToPdfURL2.OptimizePdfPageBreaks = true;
            page.AddElement(htmlToPdfURL2);

            System.IO.File.WriteAllText(logFilePath, "3rd step");

            #endregion

            #region Sales Evidance
            if (dsTab7.Tables[0].Rows.Count > 0)
            {
                strPageContents = "<table width='100%' cellpadding='0' cellspacing='0' border='0' style='width:100%;font-family:Verdana; font-size:18px;'>";
                strPageContents += "<tr><td style='font-weight:bold;padding-left:125px'>SALES EVIDENCE:</td></tr>";
                strPageContents += "</table>";
                int n = 0;
                for (int j = 0; j < dsTab7_U.Tables[0].Rows.Count; j++)
                {
                    strPageContents += "<table width='100%' cellpadding='0' cellspacing='1' border='0' style='width:100%;font-family:Verdana; font-size:18px;'>";
                    strPageContents += "<tr><td align='center'  style='font-weight:bold;'>" + dsTab7_U.Tables[0].Rows[j]["SalesCategory"].ToString() + "</td></tr>";
                    strPageContents += "</table>";

                    n++;

                    for (int i = 0; i < dsTab7.Tables[0].Rows.Count; i++)
                    {

                        if (Convert.ToString(dsTab7.Tables[0].Rows[i]["SalesCategory"]).Trim() == dsTab7_U.Tables[0].Rows[j]["SalesCategory"].ToString().Trim())
                        {
                            string ImageUrl = System.Configuration.ConfigurationManager.AppSettings["ImageURL"].ToString() + "Tab7Files/" +
                                Convert.ToString(dsTab7.Tables[0].Rows[i]["ImageName"]);

                            //System.Drawing.Image imgImage = System.Drawing.Image.FromFile(this.Server.MapPath("~/Tab7Files/" + Convert.ToString(dsTab7.Tables[0].Rows[i]["ImageName"])));
                            //Int32 imgWidth = imgImage.Width;
                            //Int32 imgHeight = imgImage.Height;

                            //if (imgWidth > 800) imgWidth = 800;
                            //if (imgHeight > 800) imgHeight = 800;

                            strPageContents += "<table width='100%' cellpadding='0' cellspacing='0' border='0' style='width:100%;font-family:Verdana; font-size:18px;'>";
                            //strPageContents += "<tr><td align='center'><img style='width:" + imgWidth.ToString() + "px;height:" + imgHeight.ToString() + "px;' src='" + ImageUrl + "' /></td></tr>";
                            //strPageContents += "<tr><td align='center'><img style='width:" + imgWidth.ToString() + "px;height:" + imgHeight.ToString() + "px;' src='" + ImageUrl + "' /></td></tr>";
                            strPageContents += "<tr><td align='center' style='padding-left:" + padding + "px;padding-right:" + padding + "px'><div align='center' style='width:100%;height:100%;'><img width='100%' src='" + ImageUrl + "' /></div></td></tr>";
                            strPageContents += "</table>";


                        }
                    }
                }
                page = document.Pages.AddNewPage();
                htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strPageContents, "");
                page.AddElement(htmlToPdfURL2);
                strPageContents = "";
            }
            #endregion

            #region VALUATION RATIONALE with Valuer details

            strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='margin-left:120px;margin-right:80px;font-family:Verdana; font-size:18px;'>";
            strPageContents += "<tr><td style='width:300px;'></td><td style='width:350px;'></td></tr>";
            strPageContents += "<tr><td colspan='2' style='font-weight:bold;'>VALUATION RATIONALE:</td></tr>";
            strPageContents += "<tr><td colspan='2'>The " + valuationApproach + " Approach is considered the most appropriate method of valuation.</td></tr>";
            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";

            strPageContents += "<tr><td colspan='2' style='font-weight:bold;'>VALUATION:</td></tr>";
            strPageContents += "<tr><td colspan='2'>Based on the above approach, we have assessed the market value of the subject property at :</td></tr>";

            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strPageContents += "<tr><td colspan='2' align='center' style='font-weight:bold;'>VALUATION “" + Convert.ToString(dsTab1.Tables[0].Rows[0]["ValueComponent"]) + "”:</td></tr>";
            strPageContents += "<tr><td colspan='2' align='center' style='font-weight:bold;'>$" + Convert.ToString(dsTab1.Tables[0].Rows[0]["MarketValue"]) + "</td></tr>";
            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";

            strPageContents += "<tr><td colspan='2'>Our Valuation in on the basis the property is input taxed and free of GST. We are not privy to the financial circumstances of the current owner(s) nor previous transactions upon the property which may impact upon the status of the property in relation to GST. Should the property not qualify as GST free, our assessment is inclusive of GST.</td></tr>";
            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strPageContents += "<tr><td colspan='2' style='font-weight:bold;'>" + companyName.Trim() + "</td></tr>";
            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";

            DataSet ds = new JobsController().JobsSelectByJobId(Convert.ToInt64(lblJobId.Text.Trim()));

            var ValuersSignatureText = System.Configuration.ConfigurationManager.AppSettings["ImageURL"].ToString() + "ValuerLogo/" + Convert.ToString(ds.Tables[0].Rows[0]["ValuersSignatureImage"]);

            strPageContents += "<tr><td colspan='2' style='font-weight:bold;'><img src='" + ValuersSignatureText.Trim() + "'></td></tr>";
            strPageContents += "<tr><td colspan='2' style='font-weight:bold;'>" + Convert.ToString(ds.Tables[0].Rows[0]["ValuersName"]).Trim() + "</td></tr>";
            strPageContents += "<tr><td colspan='2' style='font-weight:bold;'>" + Convert.ToString(ds.Tables[0].Rows[0]["ValuersTitle"]).Trim() + "</td></tr>";
            strPageContents += "<tr><td colspan='2' style='font-weight:bold;'>" + Convert.ToString(ds.Tables[0].Rows[0]["ValuersMembershipStatus"]).Trim() + " " + Convert.ToString(ds.Tables[0].Rows[0]["ValuersMembershipBody"]).Trim() + "</td></tr>";
            strPageContents += "<tr><td colspan='2'></td></tr>";
            strPageContents += "<tr><td colspan='2'></td></tr>";
            strPageContents += "<tr><td colspan='2'></td></tr>";
            strPageContents += "<tr><td colspan='2' style='font-size:14px;'><b>ADDRESS: </b>" + companyAddress.Trim() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>TELEPHONE:</b> Office: " + companyPhone.Trim() + "</td></tr>";
            strPageContents += "<tr><td colspan='2'></td></tr>";
            strPageContents += "<tr><td colspan='2'></td></tr>";
            strPageContents += "<tr><td colspan='2'></td></tr>";
            strPageContents += "<tr><td colspan='2'></td></tr>";
            strPageContents += "<tr><td colspan='2' style='font-weight:bold;'>EXPERT QUALIFICATIONS:</td></tr>";
            strPageContents += "<tr><td colspan='2'></td></tr>";
            strPageContents += "<tr><td>Name:</td><td style='width:300px;'>" + Convert.ToString(ds.Tables[0].Rows[0]["ValuersName"]).Trim() + "</td></tr>";
            strPageContents += "<tr><td colspan='2'></td></tr>";
            strPageContents += "<tr><td colspan='2'></td></tr>";
            strPageContents += "<tr><td>Title:</td><td>" + Convert.ToString(ds.Tables[0].Rows[0]["ValuersTitle"]).Trim() + "</td></tr>";
            strPageContents += "<tr><td colspan='2'></td></tr>";
            strPageContents += "<tr><td colspan='2'></td></tr>";
            strPageContents += "<tr><td valign='top'>Qualifications:</td><td>" + Convert.ToString(ds.Tables[0].Rows[0]["ValuersQualifications"]).Trim() + "</td></tr>";
            strPageContents += "<tr><td colspan='2'></td></tr>";
            strPageContents += "<tr><td colspan='2'></td></tr>";
            strPageContents += "<tr><td valign='top'>Experience:</td><td>" + Convert.ToString(ds.Tables[0].Rows[0]["ValuersExperience"]).Trim() + "</td></tr>";

            strPageContents += "</table>";


            page = document.Pages.AddNewPage();
            htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strPageContents, "");
            page.AddElement(htmlToPdfURL2);

            System.IO.File.WriteAllText(logFilePath, "4th step");
            #endregion

            #region TERMS AND CONDITIONS with Valuer details

            //strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='width:730px;margin-left:120px;font-family:Verdana; font-size:18px;'>";
            strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='margin-right:80px;margin-left:120px;font-family:Verdana; font-size:18px;'>";

            if (ddlPurpose.SelectedItem.Text == "Family Law")
            {
                strPageContents += "<tr><td colspan='2' style='font-weight:bold;'>CERTIFICATION</td></tr>";
                strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
                strPageContents += "<tr><td colspan='2' style='text-align:justify;'>" + Convert.ToString(ds.Tables[0].Rows[0]["FamilyLawCertification"]).Trim().Replace("\r", "<br />").Replace("{ValuerMembershipBody}", Convert.ToString(ds.Tables[0].Rows[0]["ValuersMembershipStatus"]).Trim() + " <u>" + Convert.ToString(ds.Tables[0].Rows[0]["ValuersMembershipBody"]).Trim()) + "</u></td></tr>";
                strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            }
            else
            {
                strPageContents += "<tr><td colspan='2' style='font-weight:bold;'>TERMS AND CONDITIONS</td></tr>";
                strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
                strPageContents += "<tr><td colspan='2' style='text-align:justify;'>" + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedTermsandCondition"]).Trim().Replace("\r", "<br />").Replace("{ValuerMembershipBody}", Convert.ToString(ds.Tables[0].Rows[0]["ValuersMembershipStatus"]).Trim() + " <u>" + Convert.ToString(ds.Tables[0].Rows[0]["ValuersMembershipBody"]).Trim()) + "</u></td></tr>";
                strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            }


            strPageContents += "</table>";


            page = document.Pages.AddNewPage();
            htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strPageContents, "");
            page.AddElement(htmlToPdfURL2);

            System.IO.File.WriteAllText(logFilePath, "5th step");

            #endregion

            #region CERTIFICATIONS & QUALIFICATIONS

            strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='margin-right:80px;margin-left:120px;font-family:Verdana; font-size:18px;'>";
            //strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='width:730px;margin-left:120px;font-family:Verdana; font-size:18px;'>";
            strPageContents += "<tr><td colspan='2' style='font-weight:bold;'>CERTIFICATIONS & QUALIFICATIONS</td></tr>";
            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strPageContents += "<tr><td colspan='2' style='text-align:justify;'>" + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedCertificationQualification"]).Trim().Replace("\r", "<br />") + "</u></td></tr>";
            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";

            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strPageContents += "<tr><td colspan='2' style='font-weight:bold;'>" + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedName"]).Trim() + "</td></tr>";
            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strPageContents += "<tr><td colspan='2' style='font-weight:bold;'><img src='" + ValuersSignatureText + "'></td></tr>";
            strPageContents += "<tr><td colspan='2' style='font-weight:bold;'>" + Convert.ToString(ds.Tables[0].Rows[0]["ValuersName"]).Trim() + "</td></tr>";
            strPageContents += "<tr><td colspan='2' style='font-weight:bold;'>" + Convert.ToString(ds.Tables[0].Rows[0]["ValuersTitle"]).Trim() + "</td></tr>";
            strPageContents += "<tr><td colspan='2' style='font-weight:bold;'>" + Convert.ToString(ds.Tables[0].Rows[0]["ValuersMembershipStatus"]).Trim() + " " + Convert.ToString(ds.Tables[0].Rows[0]["ValuersMembershipBody"]).Trim() + "</td></tr>";
            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";

            string _companyAddress = string.Empty;

            _companyAddress = Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedAddress"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedSuburb"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedState"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedPostcode"]);

            strPageContents += "<tr><td colspan='2' style='font-size:14px;'><b>ADDRESS: </b>" + _companyAddress.Trim() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>TELEPHONE:</b> Office: " + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedPhone1"]).Trim() + "</td></tr>";
            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strPageContents += "<tr><td colspan='2'>&nbsp;</td></tr>";

            strPageContents += "</table>";


            page = document.Pages.AddNewPage();
            htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strPageContents, "");
            page.AddElement(htmlToPdfURL2);

            System.IO.File.WriteAllText(logFilePath, "6th step");

            #endregion

            #region Appendix:- Title Details

            if (dsTitlePhoto != null && dsTitlePhoto.Tables.Count > 0 && dsTitlePhoto.Tables[0].Rows.Count > 0)
            {
                strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='width:980px;margin-right:80px;margin-left:120px;font-family:Verdana; font-size:27px;'>";
                //strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='width:730px;margin-left:120px;font-family:Verdana; font-size:27px;'>";
                strPageContents += "<tr><td align='left'>Appendix:-</td></tr>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td align='center' style='height:600px;'>Title Details</td></tr>";
                strPageContents += "</table>";


                page = document.Pages.AddNewPage();
                htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strPageContents, "");
                page.AddElement(htmlToPdfURL2);

                for (int i = 0; i < dsTitlePhoto.Tables[0].Rows.Count; i++)
                {
                    if (dsTitlePhoto.Tables[0].Rows[i]["ImageName"] != DBNull.Value)
                    {
                        string ImageUrl = System.Configuration.ConfigurationManager.AppSettings["ImageURL"].ToString() + "Tab8Files/" +
                            Convert.ToString(dsTitlePhoto.Tables[0].Rows[i]["ImageName"]);

                        System.IO.File.WriteAllText(logFilePath, "7th step");

                        System.Drawing.Image imgImage = System.Drawing.Image.FromFile(this.Server.MapPath("~/Tab8Files/" + Convert.ToString(dsTitlePhoto.Tables[0].Rows[i]["ImageName"])));
                        Int32 imgWidth = imgImage.Width;
                        Int32 imgHeight = imgImage.Height;

                        System.IO.File.WriteAllText(logFilePath, "8th step");

                        //if (imgWidth >= 700) imgWidth = 775;
                        //if (imgHeight >= 975) imgHeight = 990;

                        //  if (imgWidth > 700) imgWidth = 700;
                        //   if (imgHeight > 700) imgHeight = 700;
                        strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='width:100%;'>";
                        //strPageContents += "<tr><td align='center'><img style='width:" + imgWidth.ToString() + "px;height:" + imgHeight.ToString() + "px;' src='" + ImageUrl + "' /></td></tr>";
                        strPageContents += "<tr><td align='center' style='padding-left:" + padding + "px;padding-right:" + padding + "px'><div align='center' style='width:100%;height:100%;'><img width='100%' height='496px' src='" + ImageUrl + "' /></div></td></tr>";
                        strPageContents += "<tr><td>&nbsp;</td></tr>";
                        strPageContents += "</table>";

                        page = document.Pages.AddNewPage();
                        htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strPageContents, "");
                        page.AddElement(htmlToPdfURL2);
                    }
                }
            }
            #endregion

            #region Appendix:- Zoinig Details

            if (dsZoningPhoto != null && dsZoningPhoto.Tables.Count > 0 && dsZoningPhoto.Tables[0].Rows.Count > 0)
            {
                strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='width:980px; margin-left:120px;font-family:Verdana; font-size:27px;'>";
                //strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='width:730px;margin-left:120px;font-family:Verdana; font-size:27px;'>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td align='center' style='height:600px;'>Zoning Details</td></tr>";
                strPageContents += "</table>";


                page = document.Pages.AddNewPage();
                htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strPageContents, "");
                page.AddElement(htmlToPdfURL2);

                for (int i = 0; i < dsZoningPhoto.Tables[0].Rows.Count; i++)
                {
                    if (dsZoningPhoto.Tables[0].Rows[i]["ImageName"] != DBNull.Value)
                    {
                        string ImageUrl = System.Configuration.ConfigurationManager.AppSettings["ImageURL"].ToString() + "Tab8Files/" +
                            Convert.ToString(dsZoningPhoto.Tables[0].Rows[i]["ImageName"]);

                        System.Drawing.Image imgImage = System.Drawing.Image.FromFile(this.Server.MapPath("~/Tab8Files/" + Convert.ToString(dsZoningPhoto.Tables[0].Rows[i]["ImageName"])));
                        Int32 imgWidth = imgImage.Width;
                        Int32 imgHeight = imgImage.Height;

                        //if (imgWidth > 700) imgWidth = 700;
                        //if (imgHeight > 700) imgHeight = 700;
                        strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='width:100%;'>";
                        //strPageContents += "<tr><td align='center'><img style='width:" + imgWidth.ToString() + "px;height:" + imgHeight.ToString() + "px;' src='" + ImageUrl + "' /></td></tr>";
                        //strPageContents += "<tr><td align='center'><img style='width:" + imgWidth.ToString() + "px;height:" + imgHeight.ToString() + "px;' src='" + ImageUrl + "' /></td></tr>";
                        strPageContents += "<tr><td align='center' style='padding-left:" + padding + "px;padding-right:" + padding + "px'><div align='center' style='width:100%;height:100%;'><img width='100%' height='496px' src='" + ImageUrl + "' /></div></td></tr>";
                        strPageContents += "<tr><td>&nbsp;</td></tr>";
                        strPageContents += "</table>";

                        page = document.Pages.AddNewPage();
                        htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strPageContents, "");
                        page.AddElement(htmlToPdfURL2);
                        System.IO.File.WriteAllText(logFilePath, "9th step");
                    }
                }

            }

            #endregion

            #region Appendix:-  Overlay Details

            if (dsOverlayPhoto != null && dsOverlayPhoto.Tables.Count > 0 && dsOverlayPhoto.Tables[0].Rows.Count > 0)
            {
                strPageContents = "<table cellpadding='0' cellspacing='5' border='0' style='width:980px; margin-left:120px;font-family:Verdana; font-size:27px;'>";
                //strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='width:730px;margin-left:120px;font-family:Verdana; font-size:27px;'>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td align='center' style='height:600px;'>Overlay Details</td></tr>";
                strPageContents += "</table>";


                page = document.Pages.AddNewPage();
                htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strPageContents, "");
                page.AddElement(htmlToPdfURL2);

                System.IO.File.WriteAllText(logFilePath, "10th step");

                for (int i = 0; i < dsOverlayPhoto.Tables[0].Rows.Count; i++)
                {
                    if (dsOverlayPhoto.Tables[0].Rows[i]["ImageName"] != DBNull.Value)
                    {
                        string ImageUrl = System.Configuration.ConfigurationManager.AppSettings["ImageURL"].ToString() + "Tab8Files/" +
                            Convert.ToString(dsOverlayPhoto.Tables[0].Rows[i]["ImageName"]);

                        System.Drawing.Image imgImage = System.Drawing.Image.FromFile(this.Server.MapPath("~/Tab8Files/" + Convert.ToString(dsOverlayPhoto.Tables[0].Rows[i]["ImageName"])));
                        Int32 imgWidth = imgImage.Width;
                        Int32 imgHeight = imgImage.Height;

                        //if (imgWidth >= 700) imgWidth = 775;
                        //if (imgHeight >= 975) imgHeight = 990;
                        strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='width:100%;'>";
                        //strPageContents += "<tr><td align='center'><img style='width:" + imgWidth.ToString() + "px;height:" + imgHeight.ToString() + "px;' src='" + ImageUrl + "' /></td></tr>";
                        //strPageContents += "<tr><td align='center'><img style='width:" + imgWidth.ToString() + "px;height:" + imgHeight.ToString() + "px;' src='" + ImageUrl + "' /></td></tr>";
                        strPageContents += "<tr><td align='center' style='padding-left:" + padding + "px;padding-right:" + padding + "px'><div align='center' style='width:100%;height:100%;'><img width='100%' height='496px' src='" + ImageUrl + "' /></div></td></tr>";
                        strPageContents += "<tr><td>&nbsp;</td></tr>";
                        strPageContents += "</table>";

                        page = document.Pages.AddNewPage();
                        htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strPageContents, "");
                        page.AddElement(htmlToPdfURL2);
                    }
                }
            }

            System.IO.File.WriteAllText(logFilePath, "11th step");
            #endregion


            #region Appendix:-  Other Details

            if (dsOthersPhoto != null && dsOthersPhoto.Tables.Count > 0 && dsOthersPhoto.Tables[0].Rows.Count > 0)
            {
                strPageContents = "<table cellpadding='0' cellspacing='5' border='0' style='width:980px;margin-left:120px;font-family:Verdana; font-size:27px;'>";
                //strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='width:730px;margin-left:120px;font-family:Verdana; font-size:27px;'>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td align='center' style='height:600px;'>Other Details</td></tr>";
                strPageContents += "</table>";


                page = document.Pages.AddNewPage();
                htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strPageContents, "");
                page.AddElement(htmlToPdfURL2);

                for (int i = 0; i < dsOthersPhoto.Tables[0].Rows.Count; i++)
                {
                    if (dsOthersPhoto.Tables[0].Rows[i]["ImageName"] != DBNull.Value)
                    {
                        string ImageUrl = System.Configuration.ConfigurationManager.AppSettings["ImageURL"].ToString()
                            + "Tab8Files/" + Convert.ToString(dsOthersPhoto.Tables[0].Rows[i]["ImageName"]);

                        strPageContents = "<table width='100%' cellpadding='0' cellspacing='0' border='0' style='width:100%;'>";
                        strPageContents += "<tr><td>&nbsp;</td></tr>";

                        System.Drawing.Image imgImage = System.Drawing.Image.FromFile(this.Server.MapPath("~/Tab8Files/" + Convert.ToString(dsOthersPhoto.Tables[0].Rows[i]["ImageName"])));
                        Int32 imgWidth = imgImage.Width;
                        Int32 imgHeight = imgImage.Height;

                        //if (imgWidth > 700) imgWidth = 700;
                        //if (imgHeight > 700) imgHeight = 700;
                        strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='width:100%;'>";
                        //strPageContents += "<tr><td align='center'><img style='width:" + imgWidth.ToString() + "px;height:" + imgHeight.ToString() + "px;' src='" + ImageUrl + "' /></td></tr>";
                        //strPageContents += "<tr><td align='center'><img style='width:" + imgWidth.ToString() + "px;height:" + imgHeight.ToString() + "px;' src='" + ImageUrl + "' /></td></tr>";
                        strPageContents += "<tr><td align='center' style='padding-left:" + padding + "px;padding-right:" + padding + "px'><div align='center' style='width:100%;height:100%;'><img width='100%' height='496px' src='" + ImageUrl + "' /></div></td></tr>";
                        strPageContents += "<tr><td>&nbsp;</td></tr>";
                        strPageContents += "</table>";

                        page = document.Pages.AddNewPage();
                        htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strPageContents, "");
                        page.AddElement(htmlToPdfURL2);

                        System.IO.File.WriteAllText(logFilePath, "12th step");
                    }
                }
            }

            #endregion


            #region Appendix:-  Photos (Primary/External/Internal)

            DataTable dtAllPhotos = new DataTable();
            dtAllPhotos.Columns.Add("ImageName");
            for (int i = 0; i < dsPrimaryPhoto.Tables[0].Rows.Count; i++)
            {
                DataRow dr = dtAllPhotos.NewRow();
                dr["ImageName"] = dsPrimaryPhoto.Tables[0].Rows[i]["ImageName"];
                dtAllPhotos.Rows.Add(dr);
            }
            for (int i = 0; i < dsExternalPhoto.Tables[0].Rows.Count; i++)
            {
                DataRow dr = dtAllPhotos.NewRow();
                dr["ImageName"] = dsExternalPhoto.Tables[0].Rows[i]["ImageName"];
                dtAllPhotos.Rows.Add(dr);
            }
            for (int i = 0; i < dsInternalPhoto.Tables[0].Rows.Count; i++)
            {
                DataRow dr = dtAllPhotos.NewRow();
                dr["ImageName"] = dsInternalPhoto.Tables[0].Rows[i]["ImageName"];
                dtAllPhotos.Rows.Add(dr);
            }

            if (dtAllPhotos.Rows.Count > 0)
            {
                strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='width:980px;margin-left:120px;font-family:Verdana; font-size:27px;'>";
                //strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='width:730px;margin-left:120px;font-family:Verdana; font-size:27px;'>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td align='center' style='height:600px;'>Photos</td></tr>";
                strPageContents += "</table>";


                page = document.Pages.AddNewPage();
                htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strPageContents, "");
                page.AddElement(htmlToPdfURL2);

                System.IO.File.WriteAllText(logFilePath, "13th step");
            }

            System.IO.File.AppendAllText(logFilePath, "13th step_Counnt" + dtAllPhotos.Rows.Count.ToString() + Environment.NewLine);

            int m = 0;
            string ImageContents = "";
            for (int i = 0; i < dtAllPhotos.Rows.Count; i++)
            {
                m++;
                if (dtAllPhotos.Rows[i]["ImageName"] != DBNull.Value)
                {
                    string ImageUrl = System.Configuration.ConfigurationManager.AppSettings["ImageURL"].ToString() + "Tab8Files/" +
                            Convert.ToString(dtAllPhotos.Rows[i]["ImageName"]);

                    //System.Drawing.Image imgImage = System.Drawing.Image.FromFile(this.Server.MapPath("~/Tab8Files/" + Convert.ToString(dtAllPhotos.Rows[i]["ImageName"])));
                    //Int32 imgWidth = imgImage.Width;
                    //Int32 imgHeight = imgImage.Height;

                    //if (imgWidth > 690) imgWidth = 690;
                    //if (imgHeight > 690) imgHeight = 690;


                    ImageContents += "<table  cellpadding='0' cellspacing='0' border='0' style='width:100%;'>";
                    //ImageContents += "<tr><td align='center'><img style='width:" + imgWidth.ToString() + "px;height:" + imgHeight.ToString() + "px;' src='" + ImageUrl + "' /></td></tr>";
                    ImageContents += "<tr><td align='center' style='padding-left:" + padding + "px;padding-right:" + padding + "px'><div align='center' style='width:100%;height:100%;'><img width='100%' height='496px' src='" + ImageUrl + "' /></div></td></tr>";
                    ImageContents += "</table>";

                    System.IO.File.AppendAllText(logFilePath, "13th step_" + ImageContents + Environment.NewLine);

                    if (m == 2)
                    {
                        page = document.Pages.AddNewPage();
                        htmlToPdfURL2 = new HtmlToPdfElement(0, 0, ImageContents, "");
                        page.AddElement(htmlToPdfURL2);
                        ImageContents = "";
                        m = 0;
                    }
                    else
                    {
                        if (i == dtAllPhotos.Rows.Count - 1)
                        {
                            page = document.Pages.AddNewPage();
                            htmlToPdfURL2 = new HtmlToPdfElement(0, 0, ImageContents, "");
                            page.AddElement(htmlToPdfURL2);
                            ImageContents = "";
                        }
                    }

                    System.IO.File.AppendAllText(logFilePath, "13th step_" + i.ToString() + Environment.NewLine);
                }
            }
            #endregion

            System.IO.File.WriteAllText(logFilePath, "14th step");

            #region Appendix:-   Defect Photos

            if (dsDefectPhoto != null && dsDefectPhoto.Tables.Count > 0 && dsDefectPhoto.Tables[0].Rows.Count > 0)
            {
                strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='width:980px;margin-left:120px;font-family:Verdana; font-size:27px;'>";
                //strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='width:730px;margin-left:120px;font-family:Verdana; font-size:27px;'>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td>&nbsp;</td></tr>";
                strPageContents += "<tr><td align='center' style='height:500px;'>Defect Photos</td></tr>";
                strPageContents += "</table>";


                page = document.Pages.AddNewPage();
                htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strPageContents, "");
                page.AddElement(htmlToPdfURL2);

                m = 0;
                ImageContents = "";
                for (int i = 0; i < dsDefectPhoto.Tables[0].Rows.Count; i++)
                {
                    m++;
                    if (dsDefectPhoto.Tables[0].Rows[i]["ImageName"] != DBNull.Value)
                    {
                        string ImageUrl = System.Configuration.ConfigurationManager.AppSettings["ImageURL"].ToString() + "Tab8Files/" +
                                Convert.ToString(dsDefectPhoto.Tables[0].Rows[i]["ImageName"]);

                        System.Drawing.Image imgImage = System.Drawing.Image.FromFile(this.Server.MapPath("~/Tab8Files/" + Convert.ToString(dsDefectPhoto.Tables[0].Rows[i]["ImageName"])));
                        Int32 imgWidth = imgImage.Width;
                        Int32 imgHeight = imgImage.Height;

                        //if (imgWidth > 690) imgWidth = 690;
                        //if (imgHeight > 690) imgHeight = 690;

                        ImageContents += "<table  cellpadding='0' cellspacing='0' border='0' style='width:100%;'>";
                        //ImageContents += "<tr><td align='center'><img style='width:" + imgWidth.ToString() + "px;height:" + imgHeight.ToString() + "px;' src='" + ImageUrl + "' /></td></tr>";
                        ImageContents += "<tr><td align='center' style='padding-left:" + padding + "px;padding-right:" + padding + "px'><div align='center' style='width:100%;height:100%;'><img width='100%' height='496px' src='" + ImageUrl + "' /></div></td></tr>";
                        ImageContents += "</table>";

                        if (m == 2)
                        {
                            page = document.Pages.AddNewPage();
                            htmlToPdfURL2 = new HtmlToPdfElement(0, 0, ImageContents, "");
                            page.AddElement(htmlToPdfURL2);
                            ImageContents = "";
                            m = 0;
                        }
                        else
                        {
                            if (i == dsDefectPhoto.Tables[0].Rows.Count - 1)
                            {
                                page = document.Pages.AddNewPage();
                                htmlToPdfURL2 = new HtmlToPdfElement(0, 0, ImageContents, "");
                                page.AddElement(htmlToPdfURL2);
                                ImageContents = "";
                            }
                        }

                        System.IO.File.WriteAllText(logFilePath, "15th step");
                    }
                }


            }

            #endregion

            #region Add Documents 



            using (var context = new marketvalDBEntities())
            {
                var sectionsData = from p in context.AMS_ReportSections
                               join q in context.AMS_Tab8_Attachments on p.AMS_ReportSectionsId equals q.SectionId
                               where p.JobId == ParamJobId && q.JobId == ParamJobId
                                   select new { Id = q.Id, p.SectionName, ImageUrl = q.ImageName, p.CreatedOn };



                //this.GridViewSections.DataSource = sections.ToList();
                //this.GridViewSections.DataBind();

                List<string> sectionsAdded = new List<string>();

                foreach (var sect in sectionsData)
                {
                    if (sectionsData != null && sectionsData.Count() > 0)
                    {
                        if (!sectionsAdded.Contains(sect.SectionName))
                        {
                            strPageContents = "<table cellpadding='0' cellspacing='5' border='0' style='width:980px;margin-left:120px;font-family:Verdana; font-size:27px;'>";
                            strPageContents += "<tr><td>&nbsp;</td></tr>";
                            strPageContents += "<tr><td>&nbsp;</td></tr>";
                            strPageContents += "<tr><td>&nbsp;</td></tr>";
                            strPageContents += "<tr><td>&nbsp;</td></tr>";
                            strPageContents += "<tr><td align='center' style='height:600px;'>" + sect.SectionName + "</td></tr>";
                            strPageContents += "</table>";

                            sectionsAdded.Add(sect.SectionName);
                        }
                        

                        page = document.Pages.AddNewPage();
                        htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strPageContents, "");
                        page.AddElement(htmlToPdfURL2);

                        //string ImageUrl = System.Configuration.ConfigurationManager.AppSettings["ImageURL"].ToString()
                        //             + "Tab8Files/" + sect.ImageUrl;

                        strPageContents = "<table width='100%' cellpadding='0' cellspacing='0' border='0' style='width:100%;'>";
                        strPageContents += "<tr><td>&nbsp;</td></tr>";

                        //System.Drawing.Image imgImage = System.Drawing.Image.FromFile(sect.ImageUrl);
                        //Int32 imgWidth = imgImage.Width;
                        //Int32 imgHeight = imgImage.Height;

                        var siteUrl = System.Configuration.ConfigurationManager.AppSettings["ImageURL"].ToString();


                        strPageContents = "<table  cellpadding='0' cellspacing='5' border='0' style='width:100%;'>";                        
                        strPageContents += "<tr><td align='center' style='padding-left:" + padding + "px;padding-right:" + padding + "px'><div align='center' style='width:100%;height:100%;'><img width='100%' height='496px' src='" + sect.ImageUrl.Replace("~",siteUrl) + "' /></div></td></tr>";
                        strPageContents += "<tr><td>&nbsp;</td></tr>";
                        strPageContents += "</table>";

                        page = document.Pages.AddNewPage();
                        htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strPageContents, "");
                        page.AddElement(htmlToPdfURL2);

                        System.IO.File.WriteAllText(logFilePath, "12th step");
                    }
                }
            }

            #endregion
        }

        private string GetCompanyDetails()
        {
            string strCompany = "";

            JobsController objJobsController = new JobsController();
            DataSet ds = new DataSet();
            try
            {
                ds = objJobsController.JobsSelectByJobId(Convert.ToInt64(lblJobId.Text.Trim()));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    strCompany += "<tr><td align='center' style='color:#4D4E50;font-size:20px;'><b>" + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedName"]) + "</b></td></tr>";
                    strCompany += "<tr><td align='center' style='color:Gray;'><b>" + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedAddress"]) + "</b></td></tr>";
                    strCompany += "<tr><td align='center' style='color:Gray;'><b>" + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedSuburb"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedState"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedPostcode"]) + "</b></td></tr>";
                    strCompany += "<tr><td align='center' style='color:Gray;'><b>Phone:- " + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedPhone1"]) + "</b></td></tr>";

                    lblCompanyAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedAddress"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedSuburb"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedState"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedPostcode"]);
                    lblCompanyPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedPhone1"]);

                    lblCompanyLogo.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedLogo"]);
                    lblCompanyUrl.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedURL"]);
                    //lblPropertyAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]) + " " +
                    //lblPropertyAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " +
                    //    Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " +
                    //    Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " +
                    //    Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" +
                    //    Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" +
                    //    Convert.ToString(ds.Tables[0].Rows[0]["Postcode"]);
                    lblCompanyTermsandCondition.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedTermsandCondition"]);
                    lblCompanyCertificationQualification.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedCertificationQualification"]);
                    lblCompanyFamilyLawCertification.Text = Convert.ToString(ds.Tables[0].Rows[0]["FamilyLawCertification"]);
                    lblCompanyName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedName"]);

                    lblValuerName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuersName"]);
                    lblValuersAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuersAddress"]);
                    lblValuersSuburb.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuersSuburb"]);
                    lblValuersState.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuersState"]);
                    lblValuersPostcode.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuersPostcode"]);
                    lblValuersPhone1.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuersPhone1"]);
                    lblValuersTitle.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuersTitle"]);
                    lblValuersQualifications.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuersQualifications"]);
                    lblValuersExperience.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuersExperience"]);
                    lblValuersMembershipStatus.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuersMembershipStatus"]);
                    lblValuersMembershipBody.Text = Convert.ToString(ds.Tables[0].Rows[0]["ValuersMembershipBody"]);
                    lblValuersSignature.Text = System.Configuration.ConfigurationManager.AppSettings["ImageURL"].ToString() + "ValuerLogo/" + Convert.ToString(ds.Tables[0].Rows[0]["ValuersSignatureImage"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objJobsController = null;
                ds = null;
            }

            return strCompany;
        }
        private string GetCompanyUrl()
        {
            string strCompany = "";

            JobsController objJobsController = new JobsController();
            DataSet ds = new DataSet();
            try
            {
                ds = objJobsController.JobsSelectByJobId(Convert.ToInt64(lblJobId.Text.Trim()));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    strCompany += "<tr><td align='center' style='color:#4D4E50;font-size:20px;'><b>" + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedName"]) + "</b></td></tr>";
                    strCompany += "<tr><td align='center' style='color:Gray;'><b>" + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedAddress"]) + "</b></td></tr>";
                    strCompany += "<tr><td align='center' style='color:Gray;'><b>" + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedSuburb"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedState"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedPostcode"]) + "</b></td></tr>";
                    strCompany += "<tr><td align='center' style='color:Gray;'><b>Phone:- " + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedPhone1"]) + "</b></td></tr>";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objJobsController = null;
                ds = null;
            }

            return strCompany;
        }

        private string GetPrimaryPhoto()
        {
            string ImageUrl = string.Empty;
            ReportController objReportController = new ReportController();
            DataSet ds = new DataSet();
            try
            {

                ds = Tab8GetImages("PrimaryPhoto");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ImageUrl = "Tab8Files/" + ds.Tables[0].Rows[0]["ImageName"].ToString();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
                ds = null;
            }
            return ImageUrl;
        }
        private void AddTab2Land(Document document, PdfFont font)
        {
            //set the license key
            //LicensingManager.LicenseKey = "put your license key here";

            //create a PDF document

            document.Margins = new Margins();

            //Add a first page to the document. 
            PdfPage page = document.Pages.AddNewPage();

            // add a font to the document that can be used for the texts elements 


            // add header and footer before renderng the content
            AddHtmlHeader(document);
            AddHtmlFooter(document, font);

            //string strImage = "http://localhost/amsproject/Tab7Files/06042013160811_SalesDetails.jpg";

            string strHtml = "<table width='800px' cellpadding='0' cellspacing='5' border='0' style='font-family:Verdana; font-size:17px;'>";
            strHtml += "<tr><td style='width:250px;'>CLIENT:</td><td>Gary Watt</td></tr>";
            strHtml += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strHtml += "<tr><td>INSTRUCTIONS:</td><td>Instructions were received to determine the current fair market value of the subject property for purchase purposes as at the date of valuation.</td></tr>";
            strHtml += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strHtml += "<tr><td>PROPERTY ADDRESS:</td><td>346-348 Cormack Road, Wingfield SA 5013</td></tr>";
            strHtml += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strHtml += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strHtml += "<tr><td>DATE OF VALUATION:</td><td>25th March 2013</td></tr>";
            strHtml += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strHtml += "<tr><td colspan='2'>&nbsp;</td></tr>";
            strHtml += "<tr><td>TITLE DETAILS:</td><td></td></tr>";
            strHtml += "<tr><td>Lot No:</td><td>401</td></tr>";
            strHtml += "<tr><td>Deposited Plan:</td><td>73313</td></tr>";
            strHtml += "<tr><td>Volume:</td><td>5987</td></tr>";
            strHtml += "<tr><td>Folio:</td><td>797</td></tr>";
            strHtml += "<tr><td>Encumbrances:</td><td>Refer to Certificate of Title</td></tr>";
            strHtml += "<tr><td>Registered Proprietors:</td><td>Refer to Certificate of Title</td></tr>";
            strHtml += "<tr><td>Site Total:</td><td>7,839 sqm</td></tr>";
            strHtml += "<tr><td colspan='2'></td></tr>";
            strHtml += "<tr><td colspan='2'></td></tr>";
            strHtml += "<tr><td colspan='2'>ZOINIG/PLANNING INSTRUMENT:</td></tr>";
            strHtml += "<tr><td>Local Government Area:</td><td>Port Adelaide & Enfield</td></tr>";
            strHtml += "<tr><td>Zoinig:</td><td>Zoned General Industry (1)\\46</td></tr>";
            strHtml += "<tr><td>Effect:</td><td>Current land use complies with intentions of zoinig.</td></tr>";
            strHtml += "<tr><td colspan='2'></td></tr>";
            strHtml += "<tr><td colspan='2'></td></tr>";
            strHtml += "<tr><td>LOCATION:</td><td></td></tr>";
            strHtml += "<tr><td>Shops:</td><td>Within 2 kilometre</td></tr>";
            strHtml += "<tr><td>Transport:</td><td>Bus: Within 1 Kilometre</td></tr>";
            strHtml += "<tr><td>CBD:</td><td>Approximately 11 kilometres</td></tr>";
            strHtml += "</table>";

            HtmlToPdfElement htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strHtml, "");
            page.AddElement(htmlToPdfURL2);


        }
        private void AddTab1Summary1(Document document, PdfFont font)
        {

            //Add a first page to the document. 
            PdfPage page = document.Pages.AddNewPage();
            //string strHtml1 = "<table width='1000px' cellpadding='0' cellspacing='0' border='0px'>";
            //strHtml1 += "<tr><td style='background-color:#4D4E50; height:100px; border-top:solid 4px Red;'>&nbsp;</td></tr>";
            //strHtml1 += "</table>";

            //HtmlToPdfElement textElement1 = new HtmlToPdfElement(0, 0, strHtml1, "");
            //page1.CustomHeaderTemplate.AddElement(textElement1);

            string strImage = "http://localhost/amsproject/Tab7Files/06042013160811_SalesDetails.jpg";

            string strHtml = "<table width='1000px' cellpadding='0' cellspacing='0' border='1px'>";
            strHtml += "<tr><td align='center'><b>VALUATION</b></td></tr>";
            strHtml += "<tr><td align='center'><b>For Pre Purchase Purposes</b></td></tr>";
            strHtml += "<tr><td align='center'><img src='" + strImage + "'></td></tr>";
            strHtml += "</table>";

            HtmlToPdfElement htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strHtml, "");
            page.AddElement(htmlToPdfURL2);
            document.Pages.Insert(0, page);
            document.Pages.Remove(2);
            ////Custom Footer Template in all pages
            //strHtml = "<table width='1000px' cellpadding='0' cellspacing='0' border='0px'>";
            //strHtml += "<tr><td align='left'>Residential Valuation For Pre Purchase Purposes</td><td align='right'>Page 1</td></tr>";
            //strHtml += "<tr><td align='left'>Prepared on behalf of Gary Watt</td><td align='right'></td></tr>";
            //strHtml += "<tr><td align='left'>Our Ref: 10107</td><td align='right'>As at 25th March 2013</td></tr>";
            //strHtml += "</table>";

            //HtmlToPdfElement textElement = new HtmlToPdfElement(0, 0, strHtml, "");
            //page1.CustomFooterTemplate.AddElement(textElement);


            //PdfPage page2 = document.Pages.AddNewPage();
            //page2.CustomHeaderTemplate.AddElement(textElement);
            //page2.CustomFooterTemplate.AddElement(textElement);
            //page2.AddElement(htmlToPdfURL2);



            //TextElement textElement = new TextElement(0, 0, "This where the PDF page client area starts", font);
            //page.AddElement(textElement);
        }

        private void AddHtmlHeader(Document document)
        {
            //string headerAndFooterHtmlUrl = ConfigurationManager.AppSettings["URL"].ToString() + "EmailTemplates/HeaderAndFooterHtml.htm";

            //create a template to be added in the header and footer
            document.HeaderTemplate = document.AddTemplate(document.Pages[0].ClientRectangle.Width, 125);

            // create a HTML to PDF converter element to be added to the header template
            string strHtml = "<table width='100%' cellpadding='0' cellspacing='10' border='0x'>";
            strHtml += "<tr><td align='left' style='padding-left:120px;font-weight:bold;font-size:16px;font-family:verdana;'>" + lblPropertyAddress.Text.Trim() + "</td><td align='right' style='padding-right:50px;'><img src='" + System.Configuration.ConfigurationManager.AppSettings["ImageURL"].ToString() + "CompanyLogo/" + lblCompanyLogo.Text.Trim() + "' /></td></tr>";
            strHtml += "<tr><td colspan='2'></td></tr>";
            strHtml += "<tr><td colspan='2'></td></tr>";
            strHtml += "<tr><td colspan='2'></td></tr>";
            strHtml += "</table>";

            HtmlToPdfElement headerHtmlToPdf = new HtmlToPdfElement(0, 0, strHtml, "");
            document.HeaderTemplate.AddElement(headerHtmlToPdf);

            //// add a line to the bottom of the header area
            //LineElement lineElement = new LineElement(0, document.HeaderTemplate.ClientRectangle.Bottom - 1, document.HeaderTemplate.ClientRectangle.Right, document.HeaderTemplate.ClientRectangle.Bottom - 1);
            //document.HeaderTemplate.AddElement(lineElement);
        }

        private void AddHtmlFooter(Document document, PdfFont footerPageNumberFont)
        {

            //string headerAndFooterHtmlUrl = ConfigurationManager.AppSettings["URL"].ToString() + "EmailTemplates/HeaderAndFooterHtml.htm";

            ////create a template to be added in the header and footer

            //document.FooterTemplate = document.AddTemplate(850, 100);
            //// create a HTML to PDF converter element to be added to the header template
            //HtmlToPdfElement footerHtmlToPdf = new HtmlToPdfElement(headerAndFooterHtmlUrl);
            //document.FooterTemplate.AddElement(footerHtmlToPdf);

            //// add page number to the footer

            // add a line to the bottom of the header area
            //LineElement lineElement = new LineElement(0, 1, document.FooterTemplate.ClientRectangle.Right, 1);
            //document.FooterTemplate.AddElement(lineElement);


            document.FooterTemplate = document.AddTemplate(document.Pages[0].ClientRectangle.Width, 100);
            string strHtml = "<table cellpadding='0' cellspacing='5' border='0x' style='margin-left:125px;width:830px;border-top:solid 1px silver;font-family:Verdana; font-size:14px;'>";
            strHtml += "<tr><td align='left'>Our Ref: " + lblJobId.Text.Trim() + "</td><td align='right'></td></tr>";
            strHtml += "</table>";
            HtmlToPdfElement footerHtmlToPdf = new HtmlToPdfElement(0, 30, strHtml, "");
            document.FooterTemplate.AddElement(footerHtmlToPdf);
            TextElement pageNumberText = new TextElement(document.FooterTemplate.ClientRectangle.Width - 120, 42,
                                "Page &p; of &P; pages", footerPageNumberFont);
            document.FooterTemplate.AddElement(pageNumberText);

        }

        public void SetFile(FileUpload fileUploader, string OroginalFilePath, string filePath)
        {
            // Check file size (mustn't be 0)
            HttpPostedFile myFile = fileUploader.PostedFile;
            int nFileLen = myFile.ContentLength;
            if ((nFileLen > 0))// && (System.IO.Path.GetExtension(myFile.FileName).ToLower() == ".jpg"))
            {
                // Read file into a data stream
                byte[] myData = new Byte[nFileLen];
                myFile.InputStream.Read(myData, 0, nFileLen);
                myFile.InputStream.Dispose();

                // Save the stream to disk as temporary file. 
                // make sure the path is unique!
                System.IO.FileStream newFile = new System.IO.FileStream(OroginalFilePath.Replace(System.IO.Path.GetExtension(myFile.FileName).ToLower(), "_temp" + System.IO.Path.GetExtension(myFile.FileName).ToLower()), System.IO.FileMode.Create);
                newFile.Write(myData, 0, myData.Length);

                // run ALL the image optimisations you want here..... 
                // make sure your paths are unique
                // you can use these booleans later 
                // if you need the results for your own labels or so.
                // don't call the function after the file has been closed.
                //bool success = ResizeImageAndUpload(newFile, thumbPath, 100, 100);
                bool success = ResizeImageAndUpload(newFile, filePath, 680, 680);
                //Label1.Text = "<a target='0' href='Tab7Files/" + fileUploader.FileName + "'>View Original</a><br>";
                //Label1.Text += "<a target='0' href='Tab7Files/" + Id + ".jpg'>View Resized</a>";
                // tidy up and delete the temp file.
                newFile.Close();

                // don't delete if you want to keep original files on server 
                // (in this example its for a real estate website
                // the company might want the large originals 
                // for a printing module later.
                System.IO.File.Delete(OroginalFilePath);
                System.IO.File.Delete(newFile.Name);
            }
        }

        public void SetImageFile(HttpPostedFile myFile, string OroginalFilePath, string filePath)
        {
            // Check file size (mustn't be 0)
            int nFileLen = myFile.ContentLength;
            if ((nFileLen > 0))// && (System.IO.Path.GetExtension(myFile.FileName).ToLower() == ".jpg"))
            {
                // Read file into a data stream
                byte[] myData = new Byte[nFileLen];
                myFile.InputStream.Read(myData, 0, nFileLen);
                myFile.InputStream.Dispose();

                // Save the stream to disk as temporary file. 
                // make sure the path is unique!
                using (System.IO.FileStream newFile = new System.IO.FileStream(OroginalFilePath.Replace(System.IO.Path.GetExtension(myFile.FileName).ToLower(), "_temp" + System.IO.Path.GetExtension(myFile.FileName).ToLower()), System.IO.FileMode.Create))
                {
                    newFile.Write(myData, 0, myData.Length);

                    // run ALL the image optimisations you want here..... 
                    // make sure your paths are unique
                    // you can use these booleans later 
                    // if you need the results for your own labels or so.
                    // don't call the function after the file has been closed.
                    //bool success = ResizeImageAndUpload(newFile, thumbPath, 100, 100);
                    bool success = ResizeImageAndUpload(newFile, filePath, 680, 680);
                    //Label1.Text = "<a target='0' href='Tab7Files/" + fileUploader.FileName + "'>View Original</a><br>";
                    //Label1.Text += "<a target='0' href='Tab7Files/" + Id + ".jpg'>View Resized</a>";
                    // tidy up and delete the temp file.
                    newFile.Close();

                    // don't delete if you want to keep original files on server 
                    // (in this example its for a real estate website
                    // the company might want the large originals 
                    // for a printing module later.
                    System.IO.File.Delete(OroginalFilePath);
                    System.IO.File.Delete(newFile.Name);
                }
            }
        }

        public bool ResizeImageAndUpload(System.IO.FileStream newFile, string folderPathAndFilenameNoExtension, double maxHeight, double maxWidth)
        {
            try
            {
                // Declare variable for the conversion
                float ratio;

                // Create variable to hold the image
                using (System.Drawing.Image thisImage = System.Drawing.Image.FromStream(newFile))
                {
                    // Get height and width of current image
                    int width = (int)thisImage.Width;
                    int height = (int)thisImage.Height;

                    // Ratio and conversion for new size
                    if (width > maxWidth)
                    {
                        ratio = (float)width / (float)maxWidth;
                        width = (int)(width / ratio);
                        height = (int)(height / ratio);
                    }

                    // Ratio and conversion for new size
                    if (height > maxHeight)
                    {
                        ratio = (float)height / (float)maxHeight;
                        height = (int)(height / ratio);
                        width = (int)(width / ratio);
                    }

                    // Create "blank" image for drawing new image
                    using (Bitmap outImage = new Bitmap(width, height))
                    {
                        using (Graphics outGraphics = Graphics.FromImage(outImage))
                        {
                            using (SolidBrush sb = new SolidBrush(System.Drawing.Color.White))
                            {
                                // Fill "blank" with new sized image
                                outGraphics.FillRectangle(sb, 0, 0, outImage.Width, outImage.Height);
                                outGraphics.DrawImage(thisImage, 0, 0, outImage.Width, outImage.Height);
                                //sb.Dispose();
                                //outGraphics.Dispose();
                                //thisImage.Dispose();

                                // Save new image as jpg
                                if (System.IO.Path.GetExtension(folderPathAndFilenameNoExtension).ToLower() == ".jpeg" || System.IO.Path.GetExtension(folderPathAndFilenameNoExtension).ToLower() == ".jpg")
                                    outImage.Save(folderPathAndFilenameNoExtension, System.Drawing.Imaging.ImageFormat.Jpeg);
                                if (System.IO.Path.GetExtension(folderPathAndFilenameNoExtension).ToLower() == ".png")
                                    outImage.Save(folderPathAndFilenameNoExtension, System.Drawing.Imaging.ImageFormat.Png);
                                if (System.IO.Path.GetExtension(folderPathAndFilenameNoExtension).ToLower() == ".gif")
                                    outImage.Save(folderPathAndFilenameNoExtension, System.Drawing.Imaging.ImageFormat.Gif);
                            }
                        }
                        //outImage.Dispose();
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }




        protected void lbtnTab8AddDocuments_Click(object sender, EventArgs e)
        {
            HideTab8InnerTables();
            tblTab8AddDocuments.Visible = true;
            lbtnTab8AddDocuments.Font.Bold = true;
            FillTab8OthersPhoto();
        }


        protected void btnAddSection_Click(object sender, EventArgs e)
        {
            List<AMS_ReportSections> sections = null;


            string sectionName = this.txtSectionName.Text;

            if (!string.IsNullOrEmpty(sectionName.Trim()))
            {
                using (var context = new marketvalDBEntities())
                {
                    AMS_ReportSections section = new AMS_ReportSections();

                    section.JobId = Convert.ToInt32(Request.QueryString["JobId"]);
                    section.SectionName = sectionName;
                    section.CreatedBy = Convert.ToInt32(Session["UserId"]);
                    section.CreatedOn = DateTime.Now;

                    context.AMS_ReportSections.Add(section);
                    context.SaveChanges();

                    //sections = context.AMS_ReportSections.ToList();
                }
            }

            this.txtSectionName.Text = string.Empty;
            lblMessage.Text = "Section has been added successfully.";
            this.lblMessage.Visible = true;

            this.dropDownSection.Items.Clear();
            FillDocumentDetails();



            updatePanelSectionsGrid.Update();
            updatePanelDdlSection.Update();
        }

        protected void AjaxFileUpload1_UploadCompleteAll(object sender, AjaxControlToolkit.AjaxFileUploadCompleteAllEventArgs e)
        {

        }

        protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            var temp = selectedSectionId;
            ReportController objReportController = new ReportController();
            Int64 JobId = Convert.ToInt64(Request.QueryString["JobId"]);

            int sectionId = 0;
            if (Session["SectionId"] != null)
            {
                sectionId = Convert.ToInt32(Session["SectionId"]);
            }

            /////////////////////////////////////////////////////////
            if (Path.GetExtension(e.FileName).ToLower() == ".pdf")
            {

                string filePath = string.Empty;

                filePath = Server.MapPath("~/Tab8Files/" + Path.GetFileName(e.FileName));
                fuTab8AddDocs.SaveAs(filePath);

                PdfToImageConverter pdfToImageConverter = new PdfToImageConverter();
                pdfToImageConverter.LicenseKey = "+dLI2cjI2cvAydnIydfJ2crI18jL18DAwMA="; // license key
                pdfToImageConverter.ImagesFormat = ImageFormat.Jpeg; // image format
                pdfToImageConverter.ColorSpace = PdfToImageColorSpace.RGB; // image color space
                pdfToImageConverter.StartPageNumber = 1; // start page number
                pdfToImageConverter.EndPageNumber = pdfToImageConverter.GetPageCount(filePath); // end page number
                pdfToImageConverter.Resolution = 400; // image resolution    
                System.Drawing.Image[] objImage = null;
                objImage = pdfToImageConverter.ConvertToImages(filePath);
                for (int ii = 0; ii < objImage.Count(); ii++)
                {
                    string TimeTicks = DateTime.Now.Ticks.ToString();
                    string strFileName1 = TimeTicks + "_Attachment_" + e.FileName + "_" + ii + ".jpg";

                    string tempFileName = "~/Tab8Files/" + strFileName1;
                    string outputPageImage = Server.MapPath(tempFileName);
                    objImage[ii].Save(outputPageImage);
                    objReportController.Tab8_AttachmentsEdit(0, JobId, tempFileName, "OthersPhoto", Convert.ToInt64(Session["UserId"]), "ADD", sectionId);
                    //lblTab8Error.Text = "FIle path ..... " + outputPageImage;
                }
            }
            ///////////////////////////////////////////////////////////
            else
            {

                string ticks = DateTime.Now.Ticks.ToString();
                string extension = Path.GetExtension(e.FileName);
                string strFileName = ticks + "_Attachment" + extension;
                string tempFileName = "~/Tab8Files/" + strFileName;
                strFileName = Server.MapPath("~/Tab8Files/" + strFileName);
                fuTab8AddDocs.SaveAs(strFileName);

                objReportController.Tab8_AttachmentsEdit(0, JobId, tempFileName, "OthersPhoto", Convert.ToInt64(Session["UserId"]), "ADD", sectionId);
            }

            if (JobId > 0)
            {
                lblTab8Error.Text = "Photo uploaded successfully.";
                FillTab8OthersPhoto(JobId);
            }
            else
            {
                lblTab8Error.Text = "Photo doesnt uploaded successfully. Please try again.";
                return;
            }

        }


        int selectedSectionId = 0;
        protected void dropDownSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSectionId = Convert.ToInt32(this.dropDownSection.SelectedValue);
            Session["SectionId"] = selectedSectionId;
        }

        protected void btnDeleteDocs_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnDelete = sender as ImageButton;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;
            ReportController objReportController = new ReportController();
            try
            {
                if (objReportController.Tab8_AttachmentsEdit(Convert.ToInt64(((Label)row.FindControl("lblId")).Text), 0, "", "", 0, "DELETE") > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Document details deleted.');", true);
                    File.Delete(Server.MapPath(((Label)row.FindControl("lblImageName")).Text));
                    FillDocumentDetails();
                    updatePanelSectionsGrid.Update();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Document does not deleted.');", true);
                    return;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
            }
        }

        protected void btnDeleteSection_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnDelete = sender as ImageButton;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;
            ReportController objReportController = new ReportController();
            try
            {
                //if (objReportController.Tab8_AttachmentsEdit(Convert.ToInt64(((Label)row.FindControl("lblId")).Text), 0, "", "", 0, "DELETE") > 0)
                bool isDeleted = false;
                var sectionId = Convert.ToInt64(((Label)row.FindControl("lblId")).Text);
                using (var context = new marketvalDBEntities())
                {
                    var sectionData = context.AMS_ReportSections.Where(t => t.AMS_ReportSectionsId == sectionId).FirstOrDefault();
                    if (sectionData != null)
                    {
                        context.AMS_ReportSections.Remove(sectionData);
                        context.SaveChanges();
                        isDeleted = true;
                    }

                }
                if(isDeleted)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Document details deleted.');", true);
                    //File.Delete(Server.MapPath(((Label)row.FindControl("lblImageName")).Text));
                    FillDocumentDetails();
                    updatePanelSectionsGrid.Update();
                    updatePanelDdlSection.Update();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Document does not deleted.');", true);
                    return;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                objReportController = null;
            }
        }

        protected void buttonDocumentsGrid_Click(object sender, EventArgs e)
        {
            LoadDocumentsListing();
        }
    }
}
