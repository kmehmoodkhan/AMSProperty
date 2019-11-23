using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BusinessLayer;

namespace AMSProjectNew.Clients
{
    public partial class Reports_Buildings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["JobId"] != null && Convert.ToString(Request.QueryString["JobId"]) !="")
                {
                    FillJobOrderDetails();
                    FillTab3BuildingandImprovements();
                }
            }
        }
        private void FillJobOrderDetails()
        {
            JobsController objJobsController = new JobsController();
            DataSet ds = new DataSet();
            try
            {
                string JobId = CommonController.Decrypt(Request.QueryString["JobId"].ToString());
                ds = objJobsController.JobsSelectByJobId(Convert.ToInt64(JobId));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblCompanyLogo.Text = "<img class='img-responsive' src='" + System.Configuration.ConfigurationManager.AppSettings["URL"].ToString() + "CompanyLogo/" + Convert.ToString(ds.Tables[0].Rows[0]["ValuationCompanyAssignedLogo"]) + "' />";

                    lblJobId.Text = Convert.ToString(ds.Tables[0].Rows[0]["JobId"]);
                    if (Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]) != "")
                    {
                        lblAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["UnitLot"]) + "/" + Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                    }
                    else
                    {
                        lblAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetNumber"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetName"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["StreetType"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["Suburb"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["State"]) + "&nbsp;&nbsp;" + Convert.ToString(ds.Tables[0].Rows[0]["PostCode"]);
                    }

                    lblClientName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CustomerFullName"]);
                    if (Convert.ToString(ds.Tables[0].Rows[0]["IsClientReportEdit"]) == "2")
                        Response.Redirect("Reports-Finish.aspx?Done=Yes&JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
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
        }
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
                    txtTab3YearBuilt.Value = Convert.ToString(ds.Tables[0].Rows[0]["YearBuilt"]);
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
                        if (strPergolaVerandah[i].ToString() == "Gable Roof Pergola") chkPVGable.Checked = true;
                        if (strPergolaVerandah[i].ToString() == "Timber Verandah") chkPVTimber.Checked = true;
                        if (strPergolaVerandah[i].ToString() == "Outdoor Kitchen") chkPVOutdoor.Checked = true;
                        if (strPergolaVerandah[i].ToString() == "Flat Roof Pergola") chkPVFlat.Checked = true;
                        if (strPergolaVerandah[i].ToString() == "Gazebo") chkPVGazebo.Checked = true;
                        if (strPergolaVerandah[i].ToString() == "Built in BBQ Area") chkPVBuilt.Checked = true;
                        if (strPergolaVerandah[i].ToString() == "Iron Verandah") chkPVIron.Checked = true;
                    }
                    //chkTab3Shedding
                    string[] strShedding = Convert.ToString(ds.Tables[0].Rows[0]["Shedding"]).Split('@');
                    for (int i = 0; i < strShedding.Length; i++)
                    {
                        if (strShedding[i].ToString() == "Single Iron Garage") chkSHSingleIron.Checked = true;
                        if (strShedding[i].ToString() == "Single Garage") chkSHSingleGarage.Checked = true;
                        if (strShedding[i].ToString() == "Shedding") chkSHShedding.Checked = true;
                        if (strShedding[i].ToString() == "Double Iron Garage") chkSHDoubleIron.Checked = true;
                        if (strShedding[i].ToString() == "Double Garage") chkSHDoubleGarage.Checked = true;
                        if (strShedding[i].ToString() == "Garden Shed") chkSHGarden.Checked = true;
                        if (strShedding[i].ToString() == "Triple Iron Garage") chkSHTripleIron.Checked = true;
                        if (strShedding[i].ToString() == "Triple Garage") chkSHTripleGarage.Checked = true;
                        if (strShedding[i].ToString() == "Tool Shed") chkSHTool.Checked = true;
                    }
                    //chkTab3Pools
                    string[] strPools = Convert.ToString(ds.Tables[0].Rows[0]["Pools"]).Split('@');
                    for (int i = 0; i < strPools.Length; i++)
                    {
                        if (strPools[i].ToString() == "Inground Pool") chkPInground.Checked = true;
                        if (strPools[i].ToString() == "Out Door Spa") chkPOutDoor.Checked = true;
                        if (strPools[i].ToString() == "Pool Fencing") chkPPool.Checked = true;
                        if (strPools[i].ToString() == "Above Ground Pool") chkPAbove.Checked = true;
                        if (strPools[i].ToString() == "Indoor Inground Pool") chkPIndoor.Checked = true;
                    }
                    //chkTab3Gardens
                    string[] strGardens = Convert.ToString(ds.Tables[0].Rows[0]["Gardens"]).Split('@');
                    for (int i = 0; i < strGardens.Length; i++)
                    {
                        if (strGardens[i].ToString() == "Basic Gardens") chkGBasic.Checked = true;
                        if (strGardens[i].ToString() == "Established Gardens") chkGEstablished.Checked = true;
                        if (strGardens[i].ToString() == "Landscaped Gardens") chkGLandscaped.Checked = true;
                    }
                    //chkTab3Fencing
                    string[] strFencing = Convert.ToString(ds.Tables[0].Rows[0]["Fencing"]).Split('@');
                    for (int i = 0; i < strFencing.Length; i++)
                    {
                        if (strFencing[i].ToString() == "Iron Fencing") chkFIron.Checked = true;
                        if (strFencing[i].ToString() == "Brush Fencing") chkFBrush.Checked = true;
                        if (strFencing[i].ToString() == "Automatic-Gate") chkFAutomatic.Checked = true;
                        if (strFencing[i].ToString() == "Timber Fencing") chkFTimber.Checked = true;
                        if (strFencing[i].ToString() == "Security Entrance") chkFSecurity.Checked = true;
                        if (strFencing[i].ToString() == "Courtyard Fencing") chkFCourtyard.Checked = true;
                    }
                    //chkTab3DrivewayPaving
                    string[] strDrivewayPaving = Convert.ToString(ds.Tables[0].Rows[0]["DrivewayPaving"]).Split('@');
                    for (int i = 0; i < strDrivewayPaving.Length; i++)
                    {
                        if (strDrivewayPaving[i].ToString() == "Concrete Driveway") chkDPConcreteDriveway.Checked = true;
                        if (strDrivewayPaving[i].ToString() == "Concrete Paving") chkDPConcretePaving.Checked = true;
                        if (strDrivewayPaving[i].ToString() == "Timber Decking") chkDPTimber.Checked = true;
                        if (strDrivewayPaving[i].ToString() == "Brick Driveway") chkDPBrickDriveway.Checked = true;
                        if (strDrivewayPaving[i].ToString() == "Brick Paving") chkDPBrickPaving.Checked = true;
                        if (strDrivewayPaving[i].ToString() == "Gravel Driveway") chkDPGravelPaving.Checked = true;
                        if (strDrivewayPaving[i].ToString() == "Gravel Paving") chkDPGravelDriveway.Checked = true;
                        if (strDrivewayPaving[i].ToString() == "Stone Paving") chkDPStonePaving.Checked = true;
                    }
                    //chkTab3Outbuildings
                    string[] strOutbuildings = Convert.ToString(ds.Tables[0].Rows[0]["Outbuildings"]).Split('@');
                    for (int i = 0; i < strOutbuildings.Length; i++)
                    {
                        if (strOutbuildings[i].ToString() == "Outbuilding") chkOOutbuilding.Checked = true;
                        if (strOutbuildings[i].ToString() == "Storeroom") chkOStore.Checked = true;
                        if (strOutbuildings[i].ToString() == "Studio") chkOStudio.Checked = true;
                        if (strOutbuildings[i].ToString() == "Self-Contained Flat") chkOSelf.Checked = true;
                        if (strOutbuildings[i].ToString() == "Bungalow") chkOBunglow.Checked = true;
                    }

                    txtTab3AncillaryImprovements.Value = Convert.ToString(ds.Tables[0].Rows[0]["AncillaryImprovements"]);
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
            ReportController objReportController = new ReportController();
            Int64 JobId = Convert.ToInt64(lblJobId.Text);
            try
            {
                //chk Tab3 Pergola Verandah
                string strPergolaVerandah = "";
                if (chkPVGable.Checked == true) strPergolaVerandah += "Gable Roof Pergola" + "@";
                if (chkPVTimber.Checked == true) strPergolaVerandah += "Timber Verandah" + "@";
                if (chkPVOutdoor.Checked == true) strPergolaVerandah += "Outdoor Kitchen" + "@";
                if (chkPVFlat.Checked == true) strPergolaVerandah += "Flat Roof Pergola" + "@";
                if (chkPVGazebo.Checked == true) strPergolaVerandah += "Gazebo" + "@";
                if (chkPVBuilt.Checked == true) strPergolaVerandah += "Built in BBQ Area" + "@";
                if (chkPVIron.Checked == true) strPergolaVerandah += "Iron Verandah" + "@";


                //chkTab3Shedding
                string strShedding = "";
                if (chkSHSingleIron.Checked == true) strShedding += "Single Iron Garage" + "@"; ;
                if (chkSHSingleGarage.Checked == true) strShedding += "Single Garage" + "@";
                if (chkSHShedding.Checked == true) strShedding += "Shedding" + "@";
                if (chkSHDoubleIron.Checked == true) strShedding += "Double Iron Garage" + "@";
                if (chkSHDoubleGarage.Checked == true) strShedding += "Double Garage" + "@";
                if (chkSHGarden.Checked == true) strShedding += "Garden Shed" + "@";
                if (chkSHTripleIron.Checked == true) strShedding += "Triple Iron Garage" + "@";
                if (chkSHTripleGarage.Checked == true) strShedding += "Triple Garage" + "@";
                if (chkSHTool.Checked == true) strShedding += "Tool Shed" + "@";

                //chkTab3Pools
                string strPools = "";
                if (chkPInground.Checked == true) strPools += "Inground Pool" + "@";
                if (chkPOutDoor.Checked == true) strPools += "Out Door Spa" + "@";
                if (chkPPool.Checked == true) strPools += "Pool Fencing" + "@";
                if (chkPAbove.Checked == true) strPools += "Above Ground Pool" + "@";
                if (chkPIndoor.Checked == true) strPools += "Indoor Inground Pool" + "@";
                
                //chkTab3Gardens
                string strGardens = "";
                if (chkGBasic.Checked == true) strGardens += "Basic Gardens" + "@";
                if (chkGEstablished.Checked == true) strGardens += "Established Gardens" + "@";
                if (chkGLandscaped.Checked == true) strGardens += "Landscaped Gardens" + "@";

                //chkTab3Fencing
                string strFencing = "";
                if (chkFIron.Checked == true) strFencing+= "Iron Fencing" + "@";
                if (chkFBrush.Checked == true) strFencing+= "Brush Fencing" + "@";
                if (chkFAutomatic.Checked == true) strFencing+= "Automatic-Gate" + "@";
                if (chkFTimber.Checked == true) strFencing+= "Timber Fencing" + "@";
                if (chkFSecurity.Checked == true) strFencing+= "Security Entrance" + "@";
                if (chkFCourtyard.Checked == true) strFencing += "Courtyard Fencing" + "@";

                //chkTab3DrivewayPaving
                string strDrivewayPaving = "";
                if (chkDPConcreteDriveway.Checked == true) strDrivewayPaving += "Concrete Driveway" + "@";
                if (chkDPConcretePaving.Checked == true) strDrivewayPaving += "Concrete Paving" + "@";
                if (chkDPTimber.Checked == true) strDrivewayPaving += "Timber Decking" + "@";
                if (chkDPBrickDriveway.Checked == true) strDrivewayPaving += "Brick Driveway" + "@";
                if (chkDPBrickPaving.Checked == true) strDrivewayPaving += "Brick Paving" + "@";
                if (chkDPGravelPaving.Checked == true) strDrivewayPaving += "Gravel Driveway" + "@";
                if (chkDPGravelDriveway.Checked == true) strDrivewayPaving += "Gravel Paving" + "@";
                if (chkDPStonePaving.Checked == true) strDrivewayPaving += "Stone Paving" + "@";

                //chkTab3Outbuildings
                string strOutbuildings = "";
                if (chkOOutbuilding.Checked == true) strOutbuildings += "Outbuilding" + "@";
                if (chkOStore.Checked == true) strOutbuildings += "Storeroom" + "@";
                if (chkOStudio.Checked == true) strOutbuildings += "Studio" + "@";
                if (chkOSelf.Checked == true) strOutbuildings += "Self-Contained Flat" + "@";
                if (chkOBunglow.Checked == true) strOutbuildings += "Bungalow" + "@";


                JobId = objReportController.Tab3_BuildingImprovementsEdit(JobId, "", "0",
                    txtTab3YearBuilt.Value.Trim(), ddlTab3ExternalWalls.SelectedValue, ddltab3Roof.SelectedValue,
                    ddlTab3InteriorLinings.SelectedValue, ddlTab3MainFlooring.SelectedValue, ddlTab3WindowFrames.SelectedValue,
                    ddlTab3InternalCondition.SelectedValue, ddlTab3ExternalCondition.SelectedValue, ddlTab3StreetAppeal.SelectedValue,
                    strPergolaVerandah, strShedding, strPools, strGardens, strFencing, strDrivewayPaving, strOutbuildings,
                    Convert.ToInt64(Session["UserId"]), "ADD", txtTab3AncillaryImprovements.Value.Trim());

                if (JobId > 0)
                {
                    Response.Redirect("Reports-Rooms.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
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
    }
}
