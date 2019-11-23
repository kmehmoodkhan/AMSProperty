using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;

namespace AMSProjectNew.Admin
{
    public partial class ManageValuationCompany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["TDSelected"] != null && Convert.ToString(Session["TDSelected"]) != "")
                {
                    SetNotSelectedTD();
                    SetSelectedTD();
                }
                else
                {
                    SetNotSelectedTD();
                    Session["TDSelected"] = "ALL";
                    SetSelectedTD();
                }
                FillValuationCompany();
            }
        }
        
        private void FillValuationCompany()
        {
            ValuationCompanyController valuationCompanyController = new ValuationCompanyController();
            DataSet ds = new DataSet();
            try
            {
                if (hdnStatus.Value == "")
                    hdnStatus.Value = "0";

                lblTotal.Text = "Total 0 valuation company found";
                gvValuationCompany.Visible = false;

                ds = valuationCompanyController.ValuationCompanySelectAll(0, 0, Convert.ToInt64(hdnStatus.Value));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvValuationCompany.DataSource = ds.Tables[0].DefaultView;
                    gvValuationCompany.DataBind();
                    lblTotal.Text = "Total " + ds.Tables[0].Rows.Count.ToString() + " valuation company found";
                    gvValuationCompany.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                valuationCompanyController = null;
                ds = null;
            }
        }
        

        protected void btnNewCompany_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ManageValuationCompanyEdit.aspx", false);
        }               
        
        protected void gvValuationCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvValuationCompany.PageIndex = e.NewPageIndex;
            FillValuationCompany();
        }        
       
        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnDelete = sender as ImageButton;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;           
            ValuationCompanyController valuationCompanyController = new ValuationCompanyController();
            try
            {
                Int64 Id = Convert.ToInt64(((Label)row.FindControl("lblId")).Text);
                if (valuationCompanyController.ValuationCompanyEdit(Id, Id, "", "", "", "", "", "", "", "", "", "", "", "", 0, 0, 0, "", DateTime.Now, DateTime.Now, "DELETE",false,"","","","","","") > 0)
                {
                        FillValuationCompany();
                        ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Valuation company details deleted.');", true);
                        return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Valuation company details does not deleted.');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                valuationCompanyController = null;
            }
        }
                
        protected void lbtnALL_Click(object sender, EventArgs e)
        {
            SetNotSelectedTD();
            Session["TDSelected"] = "ALL";
            SetSelectedTD();
            hdnStatus.Value = "0";
            FillValuationCompany();
        }

        protected void lbtnNEW_Click(object sender, EventArgs e)
        {
            SetNotSelectedTD();
            Session["TDSelected"] = "NEW";            
            SetSelectedTD();
            hdnStatus.Value = "1";
            FillValuationCompany();
        }

        protected void lbtnACTIVE_Click(object sender, EventArgs e)
        {
            SetNotSelectedTD();
            Session["TDSelected"] = "ACTIVE";
            SetSelectedTD();
            hdnStatus.Value = "2";
            FillValuationCompany();
        }

        protected void lbtnUNVERIFIED_Click(object sender, EventArgs e)
        {
            SetNotSelectedTD();
            Session["TDSelected"] = "UNVERIFIED";
            SetSelectedTD();
            hdnStatus.Value = "3";
            FillValuationCompany();
        }

        protected void lbtnINACTIVE_Click(object sender, EventArgs e)
        {
            SetNotSelectedTD();
            Session["TDSelected"] = "INACTIVE";
            SetSelectedTD();
            hdnStatus.Value = "4";
            FillValuationCompany();
        }
        public void SetNotSelectedTD()
        {
            tdAll.Attributes.Add("class", "TDNotSelected");
            tdNEW.Attributes.Add("class", "TDNotSelected");
            tdACTIVE.Attributes.Add("class", "TDNotSelected");
            tdUNVERIFIED.Attributes.Add("class", "TDNotSelected");
            tdINACTIVE.Attributes.Add("class", "TDNotSelected");
        }
        public void SetSelectedTD()
        {
            if (Session["TDSelected"] != null && Convert.ToString(Session["TDSelected"]) == "ALL")
            {                
                tdAll.Attributes.Add("class", "TDSelected");
                hdnStatus.Value = "0";
            }
            else if (Session["TDSelected"] != null && Convert.ToString(Session["TDSelected"]) == "NEW")
            {
                hdnStatus.Value = "1";
                tdNEW.Attributes.Add("class", "TDSelected");
            }
            else if (Session["TDSelected"] != null && Convert.ToString(Session["TDSelected"]) == "ACTIVE")
            {
                hdnStatus.Value = "2";
                tdACTIVE.Attributes.Add("class", "TDSelected");
            }
            else if (Session["TDSelected"] != null && Convert.ToString(Session["TDSelected"]) == "UNVERIFIED")
            {
                hdnStatus.Value = "3";
                tdUNVERIFIED.Attributes.Add("class", "TDSelected");
            }
            else if (Session["TDSelected"] != null && Convert.ToString(Session["TDSelected"]) == "INACTIVE")
            {
                hdnStatus.Value = "4";
                tdINACTIVE.Attributes.Add("class", "TDSelected");
            }
            else
            {
                hdnStatus.Value = "0";
                tdAll.Attributes.Add("class", "TDSelected");
            }
        }
    }
}
