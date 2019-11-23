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
using System.Collections.Generic;

namespace AMSProjectNew
{
    public partial class Paging : System.Web.UI.Page
    {
        private int PageSize = 10;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetCustomersPageWise(1);
            }
        }

        private void GetCustomersPageWise(int pageIndex)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CustomerId");
            dt.Columns.Add("ContactName");
            dt.Columns.Add("CompanyName");

            for (int i = 0; i < 1000; i++)
            {
                DataRow dr = dt.NewRow();
                dr["CustomerId"] = i.ToString();
                dr["ContactName"] = "Haresh"+i.ToString();
                dr["CompanyName"] = "Comp" + i.ToString();

                dt.Rows.Add(dr);
            }
            int recordCount = 1000;
            this.PopulatePager(recordCount, pageIndex);

            //string constring = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(constring))
            //{
            //    using (SqlCommand cmd = new SqlCommand("GetCustomersPageWise", con))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
            //        cmd.Parameters.AddWithValue("@PageSize", PageSize);
            //        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
            //        cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
            //        con.Open();
            //        IDataReader idr = cmd.ExecuteReader();
            //        rptCustomers.DataSource = idr;
            //        rptCustomers.DataBind();
            //        idr.Close();
            //        con.Close();
            //        int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
            //        this.PopulatePager(recordCount, pageIndex);
            //    }
            //}
        }

        private void PopulatePager(int recordCount, int currentPage)
        {
            double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(PageSize));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            List<ListItem> pages = new List<ListItem>();
            if (pageCount > 0)
            {
                for (int i = 1; i <= pageCount; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
            }
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.GetCustomersPageWise(pageIndex);
        }
    }
}
