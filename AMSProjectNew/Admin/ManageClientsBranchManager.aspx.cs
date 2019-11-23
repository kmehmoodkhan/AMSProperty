
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
    public partial class ManageClientsBranchManagerBranchManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillClientsBranchManager();

            }
        }
        private void FillClientsBranchManager()
        {
            ClientsBranchManagerController clientsBranchManagerController = new ClientsBranchManagerController();
            DataSet ds = new DataSet();
            try
            {
                lblTotal.Text = "Total 0 Clients Branch Manager found";
                gvClientsBranchManager.Visible = false;

                ds = clientsBranchManagerController.ClientsBranchManagerSelectAll(0, 0, 0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvClientsBranchManager.DataSource = ds.Tables[0].DefaultView;
                    gvClientsBranchManager.DataBind();
                    lblTotal.Text = "Total " + ds.Tables[0].Rows.Count.ToString() + " Clients Branch Manager found";
                    gvClientsBranchManager.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                clientsBranchManagerController = null;
                ds = null;
            }
        }
        protected void btnNewEntry_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ManageClientsBranchManagerEdit.aspx", false);
        }               
        protected void gvClientsBranchManager_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvClientsBranchManager.PageIndex = e.NewPageIndex;
            FillClientsBranchManager();
        }
        protected void gvClientsBranchManager_RowDataBound(object sender, GridViewRowEventArgs e)
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
            ClientsBranchManagerController clientsBranchManagerController = new ClientsBranchManagerController();
            try
            {
                Int64 Id = Convert.ToInt64(((Label)row.FindControl("lblId")).Text);
                if (clientsBranchManagerController.ClientsBranchManagerEdit(Id, Id, 0, "", "", "", "", "", "", "", "", "", "", "", "", 0, 0, 0, "DELETE") > 0)
                {
                    FillClientsBranchManager();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Client details does not deleted.');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                clientsBranchManagerController = null;
            }
        }
    }
}
