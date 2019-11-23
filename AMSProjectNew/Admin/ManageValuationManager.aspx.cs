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
    public partial class ManageValuationManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillValuationManager();

            }
        }
        private void FillValuationManager()
        {
            ValuationManagerController valuationManagerController = new ValuationManagerController();
            DataSet ds = new DataSet();
            try
            {
                lblTotal.Text = "Total 0 Valuation Manager found";
                gvValuationManager.Visible = false;

                ds = valuationManagerController.ValuationManagerSelectAll(0, 0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvValuationManager.DataSource = ds.Tables[0].DefaultView;
                    gvValuationManager.DataBind();
                    lblTotal.Text = "Total " + ds.Tables[0].Rows.Count.ToString() + " Valuation Manager found";
                    gvValuationManager.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                valuationManagerController = null;
                ds = null;
            }
        }
        protected void btnNewEntry_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ManageValuationManagerEdit.aspx", false);
        }               
        protected void gvValuationManager_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvValuationManager.PageIndex = e.NewPageIndex;
            FillValuationManager();
        }
        protected void gvValuationManager_RowDataBound(object sender, GridViewRowEventArgs e)
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
            ValuationManagerController valuationManagerController = new ValuationManagerController();
            try
            {
                Int64 Id = Convert.ToInt64(((Label)row.FindControl("lblId")).Text);
                if (valuationManagerController.ValuationManagerEdit(Id, Id, "", "", "", "", "", "", "", "", "", "", "", 0, 0, 0, "DELETE") > 0)
                {
                    FillValuationManager();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Valuation Manager details deleted.');", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Valuation Manager details does not deleted.');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                valuationManagerController = null;
            }
        }
    }
}
