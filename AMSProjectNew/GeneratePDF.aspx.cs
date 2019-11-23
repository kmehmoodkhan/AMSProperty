using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using ExpertPdf.PdfCreator;
using System.IO;
using System.Data;
using BusinessLayer;
using System.Configuration;

namespace AMSProjectNew
{
    public partial class GeneratePDF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GeneratePDF1();
            }
        }
        public void GeneratePDF1()
        {
            ExpertPdf.HtmlToPdf.PdfConverter pdfConverter = new ExpertPdf.HtmlToPdf.PdfConverter();
            pdfConverter.LicenseKey = "+dLI2cjI2cvAydnIydfJ2crI18jL18DAwMA=";
            //set the license key
            LicensingManager.LicenseKey = "+dLI2cjI2cvAydnIydfJ2crI18jL18DAwMA=";

            //create a PDF document
            Document document = new Document();
            document.Margins = new Margins(0, 0, 0, 0);

            // add header and footer before renderng the content
            // add a font to the document that can be used for the texts elements 
            PdfFont font = document.Fonts.Add(new System.Drawing.Font(new System.Drawing.FontFamily("Verdana"), 8, System.Drawing.GraphicsUnit.Point));
            //AddHtmlHeader(document);
            //AddHtmlFooter(document, font);


            //set the license key
            //LicensingManager.LicenseKey = "put your license key here";
            //ExpertPdf.HtmlToPdf.PdfConverter pdfConverter = new ExpertPdf.HtmlToPdf.PdfConverter();


            //create a PDF document

            document.Margins = new Margins(0, 0, 0, 0);


            //Add a first page to the document. 
            PdfPage page = document.Pages.AddNewPage();

            // add a font to the document that can be used for the texts elements 
            //TextElement pageNumberText = new TextElement(document.FooterTemplate.ClientRectangle.Width - 100, 30,
            //                    "Page &p; of &P; pages", font);


            // add header and footer before renderng the content
            //AddHtmlHeader(document);
            //AddHtmlFooter(document, font);

            #region First Page Header + Footer
            /*
            //First page Header and Footer 
            
            //create a template to be added in the header and footer
            document.Pages[0].CustomHeaderTemplate = document.AddTemplate(document.Pages[0].ClientRectangle.Width, 100);
            //document.Pages[0].CustomFooterTemplate = document.AddTemplate(document.Pages[0].ClientRectangle.Width, 100);
            // create a HTML to PDF converter element to be added to the header template

            string strHFImageUrl = System.Configuration.ConfigurationManager.AppSettings["ImageURL"].ToString() + "CompanyLogo/";

            string strHeaderHtml = "";

            strHeaderHtml += "<table width='1020px' cellpadding='0' cellspacing='0' border='0x'>";
            strHeaderHtml += "<tr><td align='center'><img style='width:100%;' src='http://vc.adelaidepropertyvaluers.net.au/CompanyLogo/12242015083421Adelaide.png' /></td></tr>";
            strHeaderHtml += "</table>";


            string strFooterHtml = "<table width='1020px' cellpadding='0' cellspacing='0' border='0x' style='font-family:Verdana; font-size:17px;'>";
            //strFooterHtml += "<tr><td align='center' style='font-size:25px; color:#4D4E50;font-weight:bold;'>Adelaide Valuation</td></tr>";
            //strFooterHtml += "<tr><td align='center' style='font-size:18px;color:grey;font-weight:bold;'>Test address  Phone:- 125 987 9632</td></tr>";
            //strFooterHtml += "<tr><td align='center' style='height:15px;'></td></tr>";
            strFooterHtml += "<tr><td align='center'><img  src='http://vc.adelaidepropertyvaluers.net.au/CompanyLogo/12242015103836Adelaide%20-%20Logo%202016.png' /></td></tr>";
            strFooterHtml += "<tr><td align='center'><img style='width:100%;' src='http://vc.adelaidepropertyvaluers.net.au/CompanyLogo/12242015083421Adelaide.png' /></td></tr>";
            strFooterHtml += "</table>";

            //HtmlToPdfElement headerHtmlToPdf = new HtmlToPdfElement(-6, -9, strHeaderHtml, "");
            //HtmlToPdfElement footerHtmlToPdf = new HtmlToPdfElement(-6, 42, strFooterHtml, "");

            HtmlToPdfElement headerHtmlToPdf = new HtmlToPdfElement(-6, 0, strHeaderHtml, "");
            HtmlToPdfElement footerHtmlToPdf = new HtmlToPdfElement(-6, 0, "", "");

            document.Pages[0].CustomHeaderTemplate.Height = 60;
            document.Pages[0].CustomFooterTemplate.Height = 250;

            document.Pages[0].CustomHeaderTemplate.AddElement(headerHtmlToPdf);
            document.Pages[0].CustomFooterTemplate.AddElement(footerHtmlToPdf);


            string strPageContents = "<table width='1000px' cellpadding='0' cellspacing='5' border='0' style='font-family:Verdana; font-size:17px; font-weight:bold;'>";

            string strProperty = "";
            strPageContents += "<tr><td align='center' style='height:10px;'></td></tr>";
            strPageContents += "<tr><td align='center' style='font-size:20px;'><b>VALUATION</b></td></tr>";
            strPageContents += "<tr><td align='center' style='height:10px;'></td></tr>";
            strPageContents += "<tr><td align='center' style='font-size:20px; color:grey;'><b>For Test Purposes</b></td></tr>";
            strPageContents += "<tr><td align='center' style='height:20px;'></td></tr>";


            string strImageName = "http://vc.adelaidepropertyvaluers.net.au/Tab8Files/12242015204714_Attachment.jpg";

            //strPageContents += "<tr><td align='center'><img src='" + GetPrimaryPhoto() + "' /></td></tr>";

            //string strImageUrl = System.Configuration.ConfigurationManager.AppSettings["ImageURL"].ToString() + strImageName;
            ////string strImageUrl = "../" + strImageName;

            //System.Drawing.Image imgImage1 = System.Drawing.Image.FromFile(strImageName);
            //Int32 imgWidth1 = imgImage1.Width;
            //Int32 imgHeight1 = imgImage1.Height;

            //if (imgWidth1 > 700) imgWidth1 = 700;
            //if (imgHeight1 > 550) imgHeight1 = 550;



            //strPageContents += "<tr><td align='center'><img style='width:" + imgWidth1.ToString() + "px;height:" + imgHeight1.ToString() + "px;' src='" + strImageUrl + "' /></td></tr>";
            strPageContents += "<tr><td align='center'><img src='" + strImageName + "' /></td></tr>";



            strPageContents += "<tr><td align='center' style='height:40px;'></td></tr>";
            strPageContents += "<tr><td align='center'><b>Property:</b></td></tr>";
            strProperty = "Street Nuber, name, Type, Melborne, MB, 23456";
            //strProperty = Convert.ToString(dsTab1.Tables[0].Rows[0]["StreetNumber"]) + " " +
            //    Convert.ToString(dsTab1.Tables[0].Rows[0]["StreetName"]) + " " +
            //    Convert.ToString(dsTab1.Tables[0].Rows[0]["StreetType"]) + ", " +
            //    Convert.ToString(dsTab1.Tables[0].Rows[0]["Suburb"]) + " " +
            //    Convert.ToString(dsTab1.Tables[0].Rows[0]["State"]) + " " +
            //    Convert.ToString(dsTab1.Tables[0].Rows[0]["Postcode"]);
            strPageContents += "<tr><td align='center' style='color:Gray;'><b>" + strProperty + "</b></td></tr>";

            strPageContents += "<tr><td align='center' style='height:30px;'>&nbsp;</td></tr>";

            strPageContents += "<tr><td align='center'><b>Client Name:</b></td></tr>";
            strPageContents += "<tr><td align='center' style='color:Gray;'><b>Tet Client</b></td></tr>";
            strPageContents += "<tr><td align='center' style='height:30px;'>&nbsp;</td></tr>";

            //strPageContents += "<tr><td align='center' style='height:15px;'></td></tr>";
            strPageContents += "<tr><td align='center'><b>Date of Inspection: <br><span style='color:Gray;'>10 Dec 2015</span></b></td></tr>";
            strPageContents += "<tr><td align='center' style='height:30px;'>&nbsp;</td></tr>";
            strPageContents += "<tr><td align='center'><b>Date of Valuation: <br><span style='color:Gray;'>10 Dec 2015</span></b></td></tr>";
            //strPageContents += "<tr><td align='center' style='height:25px;'>&nbsp;</td></tr>";
            //strPageContents += GetCompanyDetails();
            strPageContents += "</table>";
            strPageContents += strFooterHtml;


            HtmlToPdfElement htmlToPdfURL2 = new HtmlToPdfElement(0, 0, strPageContents, "");
            page.AddElement(htmlToPdfURL2);

            */
            #endregion
            System.Drawing.Image imgImage1 = System.Drawing.Image.FromFile(Server.MapPath("~/CompanyLogo/Cover_Logo.png"));
            Int32 imgWidth1 = imgImage1.Width;
            Int32 imgHeight1 = imgImage1.Height;

            //imgWidth1 = imgWidth1 + Convert.ToInt32(Math.Round((imgWidth1 * 0.10), 0));
            //imgHeight1 = imgHeight1 + Convert.ToInt32(Math.Round((imgHeight1 * 0.10), 0));

            string strPageContents = "";
            strPageContents = "<table width='1050px' cellpadding='0' cellspacing='0' border='0' style='width:1050px;'>";
            strPageContents += "<tr>";
            strPageContents += "<td><img style='height:1360px;' src='http://localhost:10004/CompanyLogo/sidebar.png' /></td><td style='width:50px;'>&nbsp;</td>";
            strPageContents += "<td style='width:500px;' valign='top' align='left'>";
            strPageContents += "<table cellpadding='0' cellspacing='5' style='padding-left:40px;font-family:Trebuchet MS; font-size:28px;color:gray;'><tr><td align='left'><br><br><br><img style='height:" + imgHeight1.ToString() + "px;width:" + imgWidth1.ToString() + "px' src='http://localhost:10004/CompanyLogo/Cover_Logo.png' /></td></tr>";
            strPageContents += "<tr><td style='color:#1494C7;'><br><br><br><b>PROPERTY:</b></td></tr>";
            strPageContents += "<tr><td>444 Property Street, Unley</td></tr>";
            strPageContents += "<tr><td>South Australia, 5061</td></tr>";
            strPageContents += "<tr><td></td></tr>";
            strPageContents += "<tr><td style='color:#1494C7;'><b>INSTRUCTED BY:</b></td></tr>";
            strPageContents += "<tr><td>Gary Watt</td></tr>";
            strPageContents += "<tr><td></td></tr>";
            strPageContents += "<tr><td style='color:#1494C7;'><b>VALUATION DATE:</b></td></tr>";
            strPageContents += "<tr><td>1 December 2015</td></tr>";
            strPageContents += "</table></td></tr>";
            strPageContents += "<tr><td colspan='3' align='center' style='font-family:Trebuchet MS; font-size:30px;height:60px;background-color:#2194C8;color:white;'>adelaidepropertyvaluers.net.au</td></tr>";
            strPageContents += "</table>";
            HtmlToPdfElement htmlToPdfURL2 = new HtmlToPdfElement(-6, -12, strPageContents, "");
            page.AddElement(htmlToPdfURL2);

            string pdfName = "Test_PDF.pdf";
            string strPath = Server.MapPath("FinalReportsTemp/") + pdfName;
            if (File.Exists(strPath))
                File.Delete(strPath);
            document.Save(strPath);
            Response.Write("<a target='0' href='" + System.Configuration.ConfigurationManager.AppSettings["URL"].ToString() + "FinalReportsTemp/Test_PDF.pdf'>" + System.Configuration.ConfigurationManager.AppSettings["URL"].ToString() + "FinalReportsTemp/Test_PDF.pdf</a>");
            //byte[] pdfBytes = null;

            //try
            //{
            //    pdfBytes = pdfDocument.Save();
            //}
            //finally
            //{
            //    // close the Document to realease all the resources
            //    pdfDocument.Close();
            //}

            //// send the PDF document as a response to the browser for download
            //System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            //response.Clear();
            //response.AddHeader("Content-Type", "binary/octet-stream");
            //response.AddHeader("Content-Disposition",
            //    "attachment; filename=ConversionResult.pdf; size=" + pdfBytes.Length.ToString());
            //response.Flush();
            //response.BinaryWrite(pdfBytes);
            //response.Flush();
            //response.End();
        }

        
    }
}
