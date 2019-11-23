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
    public partial class ManageValuationType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblPopupError.Text = "";
            if (!IsPostBack)
            {
                lblPopupId.Text = "0";
                FillValuationType();
            }
        }
        public void FillValuationType()
        {
            CommonController commonController = new CommonController();
            DataSet ds = new DataSet();
            try
            {
                lblTotal.Text = "Total 0 records found";
                gvValuationType.Visible = false;

                ds = commonController.ValuationTypeSelectAll(0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvValuationType.DataSource = ds.Tables[0].DefaultView;
                    gvValuationType.DataBind();
                    gvValuationType.Visible = true;
                    lblTotal.Text = "Total " + ds.Tables[0].Rows.Count.ToString() + " records found";
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
            lblPopupId.Text = ((Label)row.FindControl("lblId")).Text;
            txtValuationType.Text = ((Label)row.FindControl("lblValuationTypeName")).Text;
            mdlPopUp.Show();
        }
        protected void gvValuationType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvValuationType.PageIndex = e.NewPageIndex;
            FillValuationType();
        }
        protected void gvValuationType_RowDataBound(object sender, GridViewRowEventArgs e)
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
                Int64 Id = Convert.ToInt64(((Label)row.FindControl("lblId")).Text);
                if (commonController.ValuationTypeEdit(Id, "", "DELETE") > 0)
                {
                    FillValuationType();
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Valuation Type deleted.');", true);
                }
                else
                {
                    lblPopupError.Text = "Valuation Type does not deleted.";
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

        protected void btnNewEntry_Click(object sender, EventArgs e)
        {
            lblPopupId.Text = "0";
            txtValuationType.Text = "";
            mdlPopUp.Show();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {            
            CommonController commonController = new CommonController();
            try
            {
                string Option = "ADD";
                if (lblPopupId.Text != "0")
                    Option = "EDIT";

                Int64 Id = commonController.ValuationTypeEdit(Convert.ToInt64(lblPopupId.Text.Trim()), txtValuationType.Text.Trim(), Option);
                if (Id > 0)
                {
                    lblPopupId.Text="0";
                    txtValuationType.Text = "";
                    FillValuationType();
                    mdlPopUp.Hide();
                }
                else if (Id == -1)
                {
                    lblPopupError.Text = "Valuation type already exist.";
                    mdlPopUp.Show();
                    return;
                }
                else
                {
                    lblPopupError.Text = "Valuation type does not added/updated.";
                    mdlPopUp.Show();
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
