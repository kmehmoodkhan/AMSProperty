using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using ExpertPdf.HtmlToPdf;
using ExpertPdf.HtmlToPdf.PdfDocument;
using System.Drawing;

namespace AMSProjectNew
{
    /// <summary>
    /// Summary description for CreatePdf
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CreatePdf : System.Web.Services.WebService
    {

        [WebMethod]
        public byte[] CreatePdfFile(string strHtml)
        {
            PdfConverter pdfConverter = new PdfConverter();
            //pdfConverter.LicenseKey = "ACsxIDExIDYgOC4wIDMxLjEyLjk5OTk=";
            pdfConverter.LicenseKey = "+dLI2cjI2cvAydnIydfJ2crI18jL18DAwMA=";
            
            // call the converter and get a Document object from URL
            Document pdfDocument = pdfConverter.GetPdfDocumentObjectFromHtmlString(strHtml);

            // get the conversion summary object from the event arguments
            ConversionSummary conversionSummary = pdfConverter.ConversionSummary;

            // the PDF page where the previous conversion ended
            PdfPage lastPage = pdfDocument.Pages[conversionSummary.LastPageIndex];
            // the last rectangle in the last PDF page where the previous conversion ended
            RectangleF lastRectangle = conversionSummary.LastPageRectangle;

            byte[] pdfBytes = null;

            try
            {
                pdfBytes = pdfDocument.Save();
            }
            finally
            {
                // close the Document to realease all the resources
                pdfDocument.Close();
            }
            return pdfBytes;
        }
    }
}
