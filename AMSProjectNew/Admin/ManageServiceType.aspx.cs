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
    public partial class ManageServiceType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblPopupError.Text = "";
            if (!IsPostBack)
            {
                lblPopupId.Text = "0";
                FillService();
            }
        }
        public void FillService()
        {
            CommonController commonController = new CommonController();
            DataSet ds = new DataSet();
            try
            {
                lblTotal.Text = "Total 0 records found";
                gvService.Visible = false;

                ds = commonController.ServiceTypeSelectAll(0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvService.DataSource = ds.Tables[0].DefaultView;
                    gvService.DataBind();
                    gvService.Visible = true;
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
            txtService.Text = ((Label)row.FindControl("lblServiceName")).Text;
            mdlPopUp.Show();
        }
        protected void gvService_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvService.PageIndex = e.NewPageIndex;
            FillService();
        }
        protected void gvService_RowDataBound(object sender, GridViewRowEventArgs e)
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
                if (commonController.ServiceTypeEdit(Id, "", "DELETE") > 0)
                {
                    FillService();
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Service Type deleted.');", true);
                }
                else
                {
                    lblPopupError.Text = "Service Type does not deleted.";
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
            txtService.Text = "";
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

                Int64 Id = commonController.ServiceTypeEdit(Convert.ToInt64(lblPopupId.Text.Trim()), txtService.Text.Trim(), Option);
                if (Id > 0)
                {
                    lblPopupId.Text="0";
                    txtService.Text = "";
                    FillService();
                    mdlPopUp.Hide();
                }
                else if (Id == -1)
                {
                    lblPopupError.Text = "Service type already exist.";
                    mdlPopUp.Show();
                    return;
                }
                else
                {
                    lblPopupError.Text = "Service type does not added/updated.";
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
