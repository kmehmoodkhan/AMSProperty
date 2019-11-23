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
using System.IO;

namespace AMSProjectNew.Clients
{
    public partial class Reports_Rooms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["JobId"] != null && Convert.ToString(Request.QueryString["JobId"]) !="")
                {
                    FillJobOrderDetails();
                    FillTab4RoomsandFixtures();
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
                        if (strRooms1[i].ToString() == "Kitchen") chkKitchen.Checked = true;
                        if (strRooms1[i].ToString() == "Kitchen/Meals/Family") chkKitchenMealsFamily.Checked = true;
                        if (strRooms1[i].ToString() == "Kitchenette") chkKitchenette.Checked = true;
                        if (strRooms1[i].ToString() == "Kitchen/Meals") chkKitchenMeals.Checked = true;
                    }
                    //chkTab3Shedding
                    string[] strRooms2 = Convert.ToString(ds.Tables[0].Rows[0]["Rooms2"]).Split('@');
                    for (int i = 0; i < strRooms2.Length; i++)
                    {
                        if (strRooms2[i].ToString() == "Lounge") chkLounge.Checked = true;
                        if (strRooms2[i].ToString() == "Lounge/Dining") chkLoungeDinning.Checked = true;
                        if (strRooms2[i].ToString() == "Family Room") chkFamilyRoom.Checked = true;
                        if (strRooms2[i].ToString() == "Dining") chkDinning.Checked = true;
                        if (strRooms2[i].ToString() == "Living Room") chkLivingRoom.Checked = true;
                        if (strRooms2[i].ToString() == "Rumpus") chkRumpus.Checked = true;
                    }
                    //chkTab3Pools
                    string[] strRooms3 = Convert.ToString(ds.Tables[0].Rows[0]["Rooms3"]).Split('@');
                    for (int i = 0; i < strRooms3.Length; i++)
                    {
                        if (strRooms3[i].ToString() == "Cellar") chkCellar.Checked = true;
                        if (strRooms3[i].ToString() == "Study") chkStudy.Checked = true;
                        if (strRooms3[i].ToString() == "Utility") chkUtility.Checked = true;
                        if (strRooms3[i].ToString() == "Sunroom") chkSunroom.Checked = true;
                        if (strRooms3[i].ToString() == "Storeroom") chkStoreRoom.Checked = true;
                        if (strRooms3[i].ToString() == "Studio") chkStudio.Checked = true;
                    }
                    //chkTab3Gardens
                    string[] strRooms4 = Convert.ToString(ds.Tables[0].Rows[0]["Rooms4"]).Split('@');
                    for (int i = 0; i < strRooms4.Length; i++)
                    {
                        if (strRooms4[i].ToString() == "Entry Hall") chkEntryHall.Checked = true;
                        if (strRooms4[i].ToString() == "Hallway") chkHallway.Checked = true;
                    }

                    if (Convert.ToString(ds.Tables[0].Rows[0]["Bedroom"]) != "0")
                    {
                        ddlTab4Bedroom.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Bedroom"]);
                        chkBedroom.Checked = true;
                    }

                    if (Convert.ToString(ds.Tables[0].Rows[0]["Bathroom"]) != "0")
                    {
                        ddlTab4Bathroom.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Bathroom"]);
                        chkBathroom.Checked = true;
                    }

                    if (Convert.ToString(ds.Tables[0].Rows[0]["Ensuite"]) != "0")
                    {
                        ddlTab4Ensuite.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Ensuite"]);
                        chkEnsuite.Checked = true;
                    }

                    if (Convert.ToString(ds.Tables[0].Rows[0]["Toilet"]) != "0")
                    {
                        ddlTab4Toilet.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Toilet"]);
                        chkToilet.Checked = true;
                    }


                    if (Convert.ToString(ds.Tables[0].Rows[0]["Laundry"]) != "")
                        chkLaundry.Checked = true;

                    Tab4Text1.Value = Convert.ToString(ds.Tables[0].Rows[0]["Text1"]);

                    //chkTab3Fencing
                    string[] strHeatingCooling = Convert.ToString(ds.Tables[0].Rows[0]["HeatingCooling"]).Split('@');
                    for (int i = 0; i < strHeatingCooling.Length; i++)
                    {
                        if (strHeatingCooling[i].ToString() == "Ducted Reverse Cycle") chkDuctedReverseCycle.Checked = true;
                        if (strHeatingCooling[i].ToString() == "Wall Air Conditioner") chkWallAirConditioner.Checked = true;
                        if (strHeatingCooling[i].ToString() == "Oil Heater") chkOilHeater.Checked = true;
                        if (strHeatingCooling[i].ToString() == "Split System Air Conditioning") chkSplitSystemAirConditioning.Checked = true;
                        if (strHeatingCooling[i].ToString() == "Ceiling Fans") chkCellingFans.Checked = true;
                        if (strHeatingCooling[i].ToString() == "Combustion Heater") chkCombutionHeater.Checked = true;
                        if (strHeatingCooling[i].ToString() == "R/C Wall Air Conditioner") chkRCWallAirConditioner.Checked = true;
                        if (strHeatingCooling[i].ToString() == "Ducted Gas Heating") chkDuctedGasHeating.Checked = true;
                        if (strHeatingCooling[i].ToString() == "Fireplace") chkFireplace.Checked = true;
                        if (strHeatingCooling[i].ToString() == "Ducted Evaporative") chkDuctedEvaporative.Checked = true;
                        if (strHeatingCooling[i].ToString() == "Gas Heater") chkGasHeater.Checked = true;
                        if (strHeatingCooling[i].ToString() == "Under Floor Heating") chkUnderFloorHeating.Checked = true;
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
        protected void btnTab4Next_Click(object sender, EventArgs e)
        {
            ReportController objReportController = new ReportController();
            Int64 JobId = Convert.ToInt64(lblJobId.Text);
            try
            {

                string strRooms1 = "";
                if (chkKitchen.Checked == true) strRooms1 += "Kitchen@";
                if (chkKitchenMealsFamily.Checked == true) strRooms1 += "Kitchen/Meals/Family@";
                if (chkKitchenette.Checked == true) strRooms1 += "Kitchenette@";
                if (chkKitchenMeals.Checked == true) strRooms1 += "Kitchen/Meals@"; 

                
                string strRooms2 = "";
                if (chkLounge.Checked == true) strRooms2 += "Lounge@";
                if (chkLoungeDinning.Checked == true) strRooms2 += "Lounge/Dining@";
                if (chkFamilyRoom.Checked == true) strRooms2 += "Family Room@";
                if (chkDinning.Checked == true) strRooms2 += "Dining@";
                if (chkLivingRoom.Checked == true) strRooms2 += "Living Room@";
                if (chkRumpus.Checked == true) strRooms2 += "Rumpus@"; 

                
                string strRooms3 = "";
                if (chkCellar.Checked == true) strRooms3 += "Cellar@";
                if (chkStudy.Checked == true) strRooms3 += "Study@";
                if (chkUtility.Checked == true) strRooms3 += "Utility@";
                if (chkSunroom.Checked == true) strRooms3 += "Sunroom@";
                if (chkStoreRoom.Checked == true) strRooms3 += "Storeroom@";
                if (chkStudio.Checked == true) strRooms3 += "Studio@";


                string strRooms4 = "";
                if (chkEntryHall.Checked == true) strRooms4 += "Entry Hall@";
                if (chkHallway.Checked == true) strRooms4 += "Hallway@";

                
                string strBedroom = ddlTab4Bedroom.SelectedValue;
                string strBathroom = ddlTab4Bathroom.SelectedValue;
                string strEnsuite = ddlTab4Ensuite.SelectedValue;
                string strToilet = ddlTab4Toilet.SelectedValue;
                string strLaundry = ddlTab4Toilet.SelectedValue;
                if (chkLaundry.Checked)
                    strLaundry = "Laundry";

                //chkTab4HeatingCooling
                string strHeatingCooling = "";
                if (chkDuctedReverseCycle.Checked == true) strHeatingCooling += "Ducted Reverse Cycle@";
                if (chkWallAirConditioner.Checked == true) strHeatingCooling += "Wall Air Conditioner@";
                if (chkOilHeater.Checked == true) strHeatingCooling += "Oil Heater@";
                if (chkSplitSystemAirConditioning.Checked == true) strHeatingCooling += "Split System Air Conditioning@";
                if (chkCellingFans.Checked == true) strHeatingCooling += "Ceiling Fans@";
                if (chkCombutionHeater.Checked == true) strHeatingCooling += "Combustion Heater@";
                if (chkRCWallAirConditioner.Checked == true) strHeatingCooling += "R/C Wall Air Conditioner@";
                if (chkDuctedGasHeating.Checked == true) strHeatingCooling += "Ducted Gas Heating@";
                if (chkFireplace.Checked == true) strHeatingCooling += "Fireplace@";
                if (chkDuctedEvaporative.Checked == true) strHeatingCooling += "Ducted Evaporative@";
                if (chkGasHeater.Checked == true) strHeatingCooling += "Gas Heater@";
                if (chkUnderFloorHeating.Checked == true) strHeatingCooling += "Under Floor Heating@";



                JobId = objReportController.Tab4_RoomsFixturesEdit(JobId, strRooms1, strRooms2, strRooms3, strRooms4,
                    strBedroom, strBathroom, strEnsuite, strToilet, strLaundry, Tab4Text1.Value.Trim(), strHeatingCooling,
                    0, "ADD");

                if (JobId > 0)
                {
                    
                    //CommonController objCommonController = new CommonController();
                    //StreamReader sr = new StreamReader(Server.MapPath("~/EmailTemplates/ReportEditByClientToAdmin.html"));
                    //string strMsg = sr.ReadToEnd();
                    //strMsg = strMsg.Replace("{JobId}", JobId.ToString());

                    //objCommonController.SendReportEditByClientToAdmin(strMsg);
            
                    Response.Redirect("Reports-Comments.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);
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
        protected void btnTab4Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports-Buildings.aspx?JobId=" + Convert.ToString(Request.QueryString["JobId"]), false);   
        }
    }
}
