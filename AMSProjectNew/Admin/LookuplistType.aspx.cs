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
    public partial class LookuplistType : System.Web.UI.Page
    {
        public string type
        {
            get
            {
                if (!String.IsNullOrEmpty(listtype.Value.ToString()))
                {
                    return listtype.Value.ToString();
                }
                else
                {
                    return Request.QueryString["type"].ToString().ToUpper();
                }
            }
            set { listtype.Value = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblPopupError.Text = "";
            
            if (!IsPostBack)
            {
                if (this.type != "")
                {                    
                    FillPropertyType(this.type);
                    lblname.Text = this.type;
                }
                lblPopupId.Text = "0";
                
            }
        }
        public void FillPropertyType(string typelist)
        {
            CommonController commonController = new CommonController();
            DataSet ds = new DataSet();
            try
            {
                
                gvPropertyType.Visible = false;

                ds = commonController.getlist(typelist);
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
            lblPopupId.Text = ((Label)row.FindControl("lblId")).Text;           
            txtPropertyName.Text = ((Label)row.FindControl("lblPropertyName")).Text;
            
        }
        protected void gvPropertyType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPropertyType.PageIndex = e.NewPageIndex;
            FillPropertyType(this.type);
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
                if (commonController.LookupTypeEdit(LookupId, "","", "DELETE") > 0)
                {
                    FillPropertyType(this.type);
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "fun33", "alert('Property Type deleted.');", true);
                }
                else
                {
                    lblPopupError.Text = "Property Type does not deleted.";
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
            txtPropertyName.Text = "";
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CommonController commonController = new CommonController();
            try
            {
                string Option = "ADD";
                if (lblPopupId.Text != "0")
                    Option = "EDIT";

                Int64 LookupId = commonController.LookupTypeEdit(Convert.ToInt64(lblPopupId.Text.Trim()),this.type, txtPropertyName.Text.Trim(), Option);
                if (LookupId > 0)
                {
                    lblPopupId.Text = "0";                    
                    txtPropertyName.Text = "";
                    FillPropertyType(this.type);
                    
                }
                else if (LookupId == -1)
                {
                    lblPopupError.Text = "Property type already exist.";
                    
                    return;
                }
                else
                {
                    lblPopupError.Text = "Property type does not added/updated.";
                    
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Lookup.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtPropertyName.Text = "";
        }

    }
}