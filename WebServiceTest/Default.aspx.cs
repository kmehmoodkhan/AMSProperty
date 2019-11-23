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

namespace WebServiceTest
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CreatePdfService.CreatePdf objCreatePdf = new WebServiceTest.CreatePdfService.CreatePdf();
                byte[] pdfBytes = null;
                pdfBytes = objCreatePdf.CreatePdfFile("Hello");

                // send the PDF document as a response to the browser for download
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.Clear();
                response.AddHeader("Content-Type", "binary/octet-stream");
                response.AddHeader("Content-Disposition",
                    "attachment; filename=ConversionResult.pdf; size=" + pdfBytes.Length.ToString());
                response.Flush();
                response.BinaryWrite(pdfBytes);
                response.Flush();
                response.End();
            }
        }
    }
}
