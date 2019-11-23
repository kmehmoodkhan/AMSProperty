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
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using CuteWebUI;

namespace AMSProjectNew
{
    public partial class FileUploading : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            HttpFileCollection fileCollection = Request.Files;
            for (int i = 0; i < fileCollection.Count; i++)
            {
                HttpPostedFile uploadfile = fileCollection[i];
                string fileName = Path.GetFileName(uploadfile.FileName);
                if (uploadfile.ContentLength > 0)
                {
                    uploadfile.SaveAs(Server.MapPath("~/UploadFiles/") + fileName);
                    lblMessage.Text += fileName + "Saved Successfully<br>";
                }
            }
        }
        public static Bitmap CreateThumbnail(string lcFilename, int lnWidth, int lnHeight)
        {
            System.Drawing.Bitmap bmpOut = null;
            try
            {
                Bitmap loBMP = new Bitmap(lcFilename);
                ImageFormat loFormat = loBMP.RawFormat;

                decimal lnRatio;
                int lnNewWidth = 0;
                int lnNewHeight = 0;

                //*** If the image is smaller than a thumbnail just return it
                if (loBMP.Width < lnWidth && loBMP.Height < lnHeight)
                    return loBMP;

                if (loBMP.Width > loBMP.Height)
                {
                    lnRatio = (decimal)lnWidth / loBMP.Width;
                    lnNewWidth = lnWidth;
                    decimal lnTemp = loBMP.Height * lnRatio;
                    lnNewHeight = (int)lnTemp;
                }
                else
                {
                    lnRatio = (decimal)lnHeight / loBMP.Height;
                    lnNewHeight = lnHeight;
                    decimal lnTemp = loBMP.Width * lnRatio;
                    lnNewWidth = (int)lnTemp;
                }
                bmpOut = new Bitmap(lnNewWidth, lnNewHeight);
                Graphics g = Graphics.FromImage(bmpOut);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.FillRectangle(Brushes.White, 0, 0, lnNewWidth, lnNewHeight);
                g.DrawImage(loBMP, 0, 0, lnNewWidth, lnNewHeight);

                loBMP.Dispose();
            }
            catch
            {
                return null;
            }

            return bmpOut;
        }
        protected void btnTab8ExternalPhoto_Click(object sender, EventArgs e)
        {
            ListBoxEvents.Items.Clear();

            foreach (AttachmentItem item in Attachments1External.Items)
            {
                item.CopyTo(Server.MapPath("~/Tab8Files/") + item.FileName);
                string strFileName = Server.MapPath("~/Tab8Files/") + DateTime.Now.ToString("MMddyyHHmffffff") + "_Attachment" + Path.GetExtension(item.FileName);
                File.Move(Server.MapPath("~/Tab8Files/") + item.FileName,  strFileName);

                System.Drawing.Bitmap bmpOut = CreateThumbnail(strFileName, 680, 680);
                bmpOut.Save(strFileName);

                ////System.Drawing.Image imgOriginal = System.Drawing.Image.FromFile(strFileName);
                //FileStream fs = new FileStream(strFileName, FileMode.Open);
                //Stream strm =  fs;
                
                ////Based on scalefactor image size will vary
                //GenerateThumbnails(0.5, strm, strFileName);
                ////string targetPath = Server.MapPath("Images/" + filename);

               /* 

                string strFileName = "";
                

                
                string strFileName1 = DateTime.Now.ToString("MMddyyHHmffffff") + "_Attachment";
                strFileName = Server.MapPath("~/Tab8Files/" + strFileName);
                
                objImageUpload.Width = 680;
                objImageUpload.Height = 680;
                System.Drawing.Image imgOriginal = System.Drawing.Image.FromFile(strFileName);
                //pass in whatever value you want
                System.Drawing.Image imgActual = objImageUpload.ImageScale(imgOriginal);
                imgOriginal.Dispose();
                imgActual.Save(strFileName);
                imgActual.Dispose();
                */ 

            }
            Attachments1External.DeleteAllAttachments();

        }

        //void ButtonTellme_Click(object sender, EventArgs e)
        //{
        //    BusinessLayer.ImageUpload objImageUpload = new BusinessLayer.ImageUpload();
        //    ListBoxEvents.Items.Clear();
        //    foreach (AttachmentItem item in Attachments1.Items)
        //    {
        //        item.CopyTo(Server.MapPath("~/Tab8Files/") + item.FileName);

        //        string strFileName = DateTime.Now.ToString("MMddyyHHmffffff") + "_Attachment" + Path.GetExtension(item.FileName);
        //        File.Move(Server.MapPath("~/Tab8Files/") + item.FileName, strFileName);

        //        System.Drawing.Image imgOriginal = System.Drawing.Image.FromFile(strFileName);
        //        //pass in whatever value you want
        //        System.Drawing.Image imgActual = objImageUpload.ImageScale(imgOriginal);
        //        imgOriginal.Dispose();
        //        imgActual.Save(strFileName);
        //        imgActual.Dispose();
        //    }
        //}

        
    }
}
