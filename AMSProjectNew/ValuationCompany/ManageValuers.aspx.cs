using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;

namespace AMSProjectNew.ValuationCompany
{
    public partial class ManageValuers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillValuers();

            }
        }
        private void FillValuers()
        {
            ValuersController valuersController = new ValuersController();
            DataSet ds = new DataSet();
            try
            {
                lblTotal.Text = "Total 0 Valuers found";
                gvValuers.Visible = false;

                ds = valuersController.ValuersSelectAll(0, Convert.ToInt64(Session["UserId"]),0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvValuers.DataSource = ds.Tables[0].DefaultView;
                    gvValuers.DataBind();
                    lblTotal.Text = "Total " + ds.Tables[0].Rows.Count.ToString() + " Valuers found";
                    gvValuers.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                valuersController = null;
                ds = null;
            }
        }
        protected void btnNewEntry_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ValuationCompany/ManageValuersEdit.aspx", false);
        }               
        protected void gvValuers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvValuers.PageIndex = e.NewPageIndex;
            FillValuers();
        }
        protected void gvValuers_RowDataBound(object sender, GridViewRowEventArgs e)
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
            ValuersController valuersController = new ValuersController();
            try
            {
                Int64 Id = Convert.ToInt64(((Label)row.FindControl("lblId")).Text);
                if (valuersController.ValuersEdit(Id, Id, "", "", "", "", "", "", "", "", "", "", "", "",0, 0, 0, "DELETE",0,"","","","","") > 0)
                {
                    FillValuers();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Valuer details does not deleted.');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                valuersController = null;
            }
        }
    }
}
