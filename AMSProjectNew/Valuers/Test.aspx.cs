using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Xml;
using System.Drawing;

using ExpertPdf.HtmlToPdf;
using ExpertPdf.HtmlToPdf.PdfDocument;
namespace AMSProjectNew.Valuers
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmitReports_Click(object sender, EventArgs e)
        {
            //PdfDocument document = new PdfDocument();

            //using (StreamReader reader = new StreamReader(Server.MapPath("~") + "/EmailTemplates/Test.htm"))
            //{
            //    String line = reader.ReadToEnd();
            //    Text2PDF(line);
            //}
            
        }
        //protected void Text2PDF(string PDFText)
        //{
        //    //HttpContext context = HttpContext.Current;
        //    StringReader reader = new StringReader(PDFText);

        //    //Create PDF document
        //    Document document = new Document(PageSize.A4);
        //    HTMLWorker parser = new HTMLWorker(document);

        //    string PDF_FileName = Server.MapPath("~") + "/PDF_File.pdf";
        //    if (File.Exists(PDF_FileName))
        //        File.Delete(PDF_FileName);
        //    PdfWriter.GetInstance(document, new FileStream(PDF_FileName, FileMode.Create));
        //    document.Open();

        //    try
        //    {
        //        parser.Parse(reader);
        //    }
        //    catch (Exception ex)
        //    {
        //        //Display parser errors in PDF.
        //        Paragraph paragraph = new Paragraph("Error!" + ex.Message);
        //        Chunk text = paragraph.Chunks[0] as Chunk;
        //        if (text != null)
        //        {
        //            text.Font.Color = BaseColor.RED;
        //        }
        //        document.Add(paragraph);
        //    }
        //    finally
        //    {
        //        document.Close();
        //        DownLoadPdf(PDF_FileName);
        //    }
        //}
        //private void DownLoadPdf(string PDF_FileName)
        //{
        //    WebClient client = new WebClient();
        //    Byte[] buffer = client.DownloadData(PDF_FileName);
        //    Response.ContentType = "application/pdf";
        //    Response.AddHeader("content-length", buffer.Length.ToString());
        //    Response.BinaryWrite(buffer);
        //}
    }
}
