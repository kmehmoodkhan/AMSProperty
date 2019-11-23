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
    public partial class ManageUrgency : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblPopupError.Text = "";
            if (!IsPostBack)
            {
                lblPopupId.Text = "0";
                FillUrgency();
            }
        }
        public void FillUrgency()
        {
            CommonController commonController = new CommonController();
            DataSet ds = new DataSet();
            try
            {
                lblTotal.Text = "Total 0 records found";
                gvUrgency.Visible = false;

                ds = commonController.UrgencySelectAll(0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvUrgency.DataSource = ds.Tables[0].DefaultView;
                    gvUrgency.DataBind();
                    gvUrgency.Visible = true;
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
            txtUrgency.Text = ((Label)row.FindControl("lblUrgencyName")).Text;
            mdlPopUp.Show();
        }
        protected void gvUrgency_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUrgency.PageIndex = e.NewPageIndex;
            FillUrgency();
        }
        protected void gvUrgency_RowDataBound(object sender, GridViewRowEventArgs e)
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
                if (commonController.UrgencyEdit(Id, "", "DELETE") > 0)
                {
                    FillUrgency();
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Purpose Type deleted.');", true);
                }
                else
                {
                    lblPopupError.Text = "Purpose Type does not deleted.";
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
            txtUrgency.Text = "";
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

                Int64 Id = commonController.UrgencyEdit(Convert.ToInt64(lblPopupId.Text.Trim()), txtUrgency.Text.Trim(), Option);
                if (Id > 0)
                {
                    lblPopupId.Text="0";
                    txtUrgency.Text = "";
                    FillUrgency();
                    mdlPopUp.Hide();
                }
                else if (Id == -1)
                {
                    lblPopupError.Text = "Purpose type already exist.";
                    mdlPopUp.Show();
                    return;
                }
                else
                {
                    lblPopupError.Text = "Purpose type does not added/updated.";
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
