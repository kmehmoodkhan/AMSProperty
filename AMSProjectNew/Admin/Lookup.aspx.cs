using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;

namespace AMSProjectNew.Admin
{
    public partial class Lookup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtPropertyName.Focus();
            if (!IsPostBack)
            {
                hdnListType.Value = "VA";
                lblName.Text = "Valuation Approach";
                hdnId.Value = "0";
                FillPropertyType();
            }
        }

        protected void lbtnValuationApproach_Click(object sender, EventArgs e)
        { hdnListType.Value = "VA"; lblName.Text = "Valuation Approach"; FillPropertyType(); }
        protected void lbtnValuationPurpose_Click(object sender, EventArgs e)
        { hdnListType.Value = "PR"; lblName.Text = "Valuation Purpose"; FillPropertyType(); }
        protected void lbtnPropertyType_Click(object sender, EventArgs e)
        { hdnListType.Value = "PT"; lblName.Text = "Property Type"; FillPropertyType(); }
        protected void lbtnPropertyIdentification_Click(object sender, EventArgs e)
        { hdnListType.Value = "PI"; lblName.Text = "Property Identification"; FillPropertyType(); }
        protected void lbtnTitleSearch_Click(object sender, EventArgs e)
        { hdnListType.Value = "TS"; lblName.Text = "Title Search"; FillPropertyType(); }
        protected void lbtnPlan_Click(object sender, EventArgs e)
        { hdnListType.Value = "PL"; lblName.Text = "Plan"; FillPropertyType(); }
        protected void lbtnRegisteredProprietors_Click(object sender, EventArgs e)
        { hdnListType.Value = "RP"; lblName.Text = "Registered Proprietors"; FillPropertyType(); }
        protected void lbtnEncumbrances_Click(object sender, EventArgs e)
        { hdnListType.Value = "EB"; lblName.Text = "Encumbrances"; FillPropertyType(); }
        protected void lbtnZoningEffect_Click(object sender, EventArgs e)
        { hdnListType.Value = "ZE"; lblName.Text = "Zoning Effect"; FillPropertyType(); }
        protected void lbtnSiteLayout_Click(object sender, EventArgs e)
        { hdnListType.Value = "SL"; lblName.Text = "Site Layout"; FillPropertyType(); }
        protected void lbtnServices_Click(object sender, EventArgs e)
        { hdnListType.Value = "SC"; lblName.Text = "Services"; FillPropertyType(); }
        protected void lbtnEnvironmentalHazards_Click(object sender, EventArgs e)
        { hdnListType.Value = "EH"; lblName.Text = "Environmental Hazards"; FillPropertyType(); }
        protected void lbtnPestInfestation_Click(object sender, EventArgs e)
        { hdnListType.Value = "PN"; lblName.Text = "Pest Infestation"; FillPropertyType(); }
        protected void lbtnPropertyStyle_Click(object sender, EventArgs e)
        { hdnListType.Value = "PS"; lblName.Text = "Property Style"; FillPropertyType(); }
        protected void lbtnExternalWalls_Click(object sender, EventArgs e)
        { hdnListType.Value = "EW"; lblName.Text = "External Walls"; FillPropertyType(); }
        protected void lbtnRoof_Click(object sender, EventArgs e)
        { hdnListType.Value = "RF"; lblName.Text = "Roof"; FillPropertyType(); }
        protected void lbtnWallLinings_Click(object sender, EventArgs e)
        { hdnListType.Value = "EL"; lblName.Text = "Wall Linings"; FillPropertyType(); }
        protected void lbtnMainFlooring_Click(object sender, EventArgs e)
        { hdnListType.Value = "MF"; lblName.Text = "Main Flooring"; FillPropertyType(); }
        protected void lbtnWindowFrames_Click(object sender, EventArgs e)
        { hdnListType.Value = "WF"; lblName.Text = "Window Frames"; FillPropertyType(); }
        protected void lbtnInternalCondition_Click(object sender, EventArgs e)
        { hdnListType.Value = "IC"; lblName.Text = "Internal Condition"; FillPropertyType(); }
        protected void lbtnExternalCondition_Click(object sender, EventArgs e)
        { hdnListType.Value = "EC"; lblName.Text = "External Condition"; FillPropertyType(); }
        protected void lbtnStreetAppeal_Click(object sender, EventArgs e)
        { hdnListType.Value = "SA"; lblName.Text = "Street Appeal"; FillPropertyType(); }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CommonController commonController = new CommonController();
            try
            {
                string Option = "ADD";
                if (hdnId.Value != "0")
                    Option = "EDIT";

                Int64 LookupId = commonController.LookupTypeEdit(Convert.ToInt64(hdnId.Value.Trim()), hdnListType.Value, txtPropertyName.Text.Trim(), Option);
                if (LookupId > 0)
                {
                    hdnId.Value = "0";
                    txtPropertyName.Text = "";
                    FillPropertyType();

                }
                else if (LookupId == -1)
                {
                    lblError.Text = "Property type already exist.";

                    return;
                }
                else
                {
                    lblError.Text = "Property type does not added/updated.";

                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                commonController = null;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtPropertyName.Text = "";
            hdnId.Value = "0";
        }

        public void FillPropertyType()
        {
            CommonController commonController = new CommonController();
            DataSet ds = new DataSet();
            try
            {

                gvPropertyType.Visible = false;

                ds = commonController.getlist(hdnListType.Value);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvPropertyType.DataSource = ds.Tables[0].DefaultView;
                    gvPropertyType.DataBind();
                    gvPropertyType.Visible = true;

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
        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnEdit = sender as ImageButton;
            GridViewRow row = (GridViewRow)btnEdit.NamingContainer;
            hdnId.Value = ((Label)row.FindControl("lblId")).Text;
            txtPropertyName.Text = ((Label)row.FindControl("lblPropertyName")).Text;

        }
        protected void gvPropertyType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPropertyType.PageIndex = e.NewPageIndex;
            FillPropertyType();
        }
        protected void gvPropertyType_RowDataBound(object sender, GridViewRowEventArgs e)
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


        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnDelete = sender as ImageButton;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;
            CommonController commonController = new CommonController();
            try
            {
                Int64 LookupId = Convert.ToInt64(((Label)row.FindControl("lblId")).Text);
                if (commonController.LookupTypeEdit(LookupId, "", "", "DELETE") > 0)
                {
                    FillPropertyType();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Property Type deleted.');", true);
                }
                else
                {
                    lblError.Text = "Property Type does not deleted.";
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                commonController = null;
            }
        }

    }
}
