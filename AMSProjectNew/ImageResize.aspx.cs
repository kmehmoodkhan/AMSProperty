using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;
using CuteWebUI;

namespace AMSProjectNew
{
    public partial class ImageResize : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tblResize.Visible = false;
                //downloadfile();
            }
        }


        public void InsertMsg(string msg)
        {
            ListBoxEvents.Items.Insert(0, msg);
            ListBoxEvents.SelectedIndex = 0;
        }

        protected override void OnInit(EventArgs e)
        {
            Attachments1.InsertButton.Style["display"] = "none";
        }
        public void Attachments1_AttachmentAdded(object sender, AttachmentItemEventArgs args)
        {
            InsertMsg(args.Item.FileName + " has been uploaded.");
        }
        public void ButtonDeleteAll_Click(object sender, EventArgs e)
        {
            InsertMsg("Attachments1.DeleteAllAttachments();");
            Attachments1.DeleteAllAttachments();
        }
        public void ButtonTellme_Click(object sender, EventArgs e)
        {
            ListBoxEvents.Items.Clear();
            foreach (AttachmentItem item in Attachments1.Items)
            {
                InsertMsg(item.FileName + ", " + item.FileSize + " bytes.");

                //Copies the uploaded file to a new location.
                //item.CopyTo("c:\\temp\\"+item.FileName);
                //You can also open the uploaded file's data stream.
                //System.IO.Stream data = item.OpenStream();
            }
        }

        public void Uploader_FileUploaded(object sender, UploaderEventArgs args)
        {
            if (GetVisibleItemCount() >= 3)
                return;
            using (System.IO.Stream stream = args.OpenStream())
            {
                Attachments1.Upload(args.FileSize, "ChangeName-" + args.FileName, stream);
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (GetVisibleItemCount() >= 3)
            {
                Uploader1.InsertButton.Enabled = false;
            }
            else
            {
                Uploader1.InsertButton.Enabled = true;
            }
        }
        public int GetVisibleItemCount()
        {
            int count = 0;
            foreach (AttachmentItem item in Attachments1.Items)
            {
                if (item.Visible)
                    count++;
            }
            return count;
        }

        public void downloadfile()
        {
            string url = "http://203.122.236.124/FinalReports/08192015094437_Valuation%20Report%2011109.pdf";
            //Create a stream for the file
            Stream stream = null;

            //This controls how many bytes to read at a time and send to the client
            int bytesToRead = 10000;

            // Buffer to read bytes in chunk size specified above
            byte[] buffer = new Byte[bytesToRead];

            // The number of bytes read
            try
            {
                //Create a WebRequest to get the file
                HttpWebRequest fileReq = (HttpWebRequest)HttpWebRequest.Create(url);

                //Create a response for this request
                HttpWebResponse fileResp = (HttpWebResponse)fileReq.GetResponse();

                if (fileReq.ContentLength > 0)
                    fileResp.ContentLength = fileReq.ContentLength;

                //Get the Stream returned from the response
                stream = fileResp.GetResponseStream();

                // prepare the response to the client. resp is the client Response
                var resp = HttpContext.Current.Response;

                //Indicate the type of data being sent
                resp.ContentType = "application/octet-stream";
                string fileName = "Test.pdf";
                //Name the file 
                //resp.AddHeader("Content-Disposition", "attachment; filename=\"" + fileName + "\"");
                //resp.AddHeader("Content-Length", fileResp.ContentLength.ToString());

                int length;
                do
                {
                    // Verify that the client is connected.
                    if (resp.IsClientConnected)
                    {
                        // Read data into the buffer.
                        length = stream.Read(buffer, 0, bytesToRead);

                        // and write it out to the response's output stream
                        resp.OutputStream.Write(buffer, 0, length);

                        // Flush the data
                        resp.Flush();

                        //Clear the buffer
                        buffer = new Byte[bytesToRead];
                        File.WriteAllBytes(Server.MapPath("~/Tab7Files/2011109.pdf"), buffer);
                    }
                    else
                    {
                        // cancel the download if client has disconnected
                        length = -1;
                    }
                } while (length > 0); //Repeat until no data is read
            }
            finally
            {
                if (stream != null)
                {
                    //Close the input stream
                    stream.Close();
                }
            }
        }
        protected void ButtonUpload_Click(object sender, EventArgs e)
        {
            if (fileUploader.FileName.ToString() != "")
            {
                string UploadPath = Server.MapPath("~/Tab7Files/");
                fileUploader.SaveAs(UploadPath + fileUploader.FileName);
                string NewFileName = DateTime.Now.ToString("ddMMyyyyfffff") + Path.GetExtension(fileUploader.FileName);
                HiddenField1.Value = NewFileName;
                File.Move(UploadPath + fileUploader.FileName, UploadPath + NewFileName);
                Image1.ImageUrl = "~/Tab7Files/" + NewFileName;

                System.Drawing.Image img = System.Drawing.Image.FromStream(fileUploader.PostedFile.InputStream);
                int height = img.Height;
                int width = img.Width;

                lblWidth.Text = width.ToString();
                lblHeight.Text = height.ToString();
                tblResize.Visible = true;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            /*string UploadPath = Server.MapPath("~/Tab7Files/") + HiddenField1.Value;
            System.Drawing.Image img = System.Drawing.Image.FromFile(UploadPath);
            int height = img.Height;
            int width = img.Width;

            ASPJPEGLib.IASPJpeg objJpeg;
            objJpeg = new ASPJPEGLib.ASPJpeg();

            // Compute path to source image
            String strPath = UploadPath;// Server.MapPath("../images/apple.jpg");

            // Open source image
            objJpeg.Open(strPath);

            // Decrease image size by 50%
            if(width>500)
                objJpeg.Width = 500;// objJpeg.OriginalWidth / 2;
            if(height>800)
                objJpeg.Height = 800;// objJpeg.OriginalHeight / 2;

            // Create thumbnail and save it to disk
            objJpeg.Save(Server.MapPath("~/Tab7Files/new_" + HiddenField1.Value));
            Image2.ImageUrl = "~/Tab7Files/new_" + HiddenField1.Value;

            //OriginalImage.Src = "../images/apple.jpg";
            //SmallImage.Src = "apple_small.jpg";
             */

            System.Drawing.Bitmap bmpUploadedImage = new System.Drawing.Bitmap(Server.MapPath("~/Tab7Files/" + HiddenField1.Value));
            int height = Convert.ToInt16(txtHeight.Text.Trim());
            int width = Convert.ToInt16(txtWidth.Text.Trim());

            System.Drawing.Image objImage = ScaleImage(bmpUploadedImage, width, height);
            objImage.Save(Server.MapPath("~/Tab7Files/new_" + HiddenField1.Value));
            Image2.ImageUrl = "~/Tab7Files/new_" + HiddenField1.Value;



        }
        public static System.Drawing.Image ScaleImage(System.Drawing.Image image, int maxImageWidth, int maxImageHeight)
        {

            /* we will resize image based on the height/width ratio by passing expected height as parameter. Based on Expected height and current image height, new ratio will be arrived and using the same we will do the resizing of image width. */

            //var ratio = (double)maxImageHeight / image.Height;
            var newWidth = maxImageWidth;// (int)(image.Width * ratio);
            var newHeight = maxImageHeight;// (int)(image.Height * ratio);
            var newImage = new Bitmap(newWidth, newHeight);
            using (var g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }
        protected void ButtonUpload1_Click(object sender, EventArgs e)
        {
            //Path to store uploaded files on server - make sure your paths are unique
            string Id = DateTime.Now.ToString("ddmmyyyyhhssmm");
            string filePath = "~\\Tab7Files\\" + Id;// +"-" + DropDownListImage.SelectedValue.ToString();
            string thumbPath = "~\\Tab7Files\\" + Id;// +"-" + DropDownListImage.SelectedValue.ToString() + "_thumb";
            if (File.Exists(Server.MapPath("~/Tab7Files/" + fileUploader.FileName)))
                File.Delete(Server.MapPath("~/Tab7Files/" + fileUploader.FileName));

            fileUploader.PostedFile.SaveAs(Server.MapPath("~/Tab7Files/" + fileUploader.FileName));

            // Check that there is a file
            if (fileUploader.PostedFile != null)
            {
                // Check file size (mustn't be 0)
                HttpPostedFile myFile = fileUploader.PostedFile;
                int nFileLen = myFile.ContentLength;
                if ((nFileLen > 0) &&
            (System.IO.Path.GetExtension(myFile.FileName).ToLower() == ".jpg"))
                {
                    // Read file into a data stream
                    byte[] myData = new Byte[nFileLen];
                    myFile.InputStream.Read(myData, 0, nFileLen);
                    myFile.InputStream.Dispose();

                    // Save the stream to disk as temporary file. 
                    // make sure the path is unique!
                    System.IO.FileStream newFile
                            = new System.IO.FileStream
                (Server.MapPath(filePath + "_temp.jpg"),
                                            System.IO.FileMode.Create);
                    newFile.Write(myData, 0, myData.Length);

                    // run ALL the image optimisations you want here..... 
                    // make sure your paths are unique
                    // you can use these booleans later 
                    // if you need the results for your own labels or so.
                    // don't call the function after the file has been closed.
                    bool success = ResizeImageAndUpload(newFile, thumbPath, 100, 100);
                    success = ResizeImageAndUpload(newFile, filePath, 500, 500);
                    //Label1.Text = "<a target='0' href='Tab7Files/" + fileUploader.FileName + "'>View Original</a><br>";
                    //Label1.Text += "<a target='0' href='Tab7Files/" + Id + ".jpg'>View Resized</a>";
                    // tidy up and delete the temp file.
                    newFile.Close();

                    // don't delete if you want to keep original files on server 
                    // (in this example its for a real estate website
                    // the company might want the large originals 
                    // for a printing module later.
                    System.IO.File.Delete(Server.MapPath(filePath + "_temp.jpg"));
                }
            }
        }
        public bool ResizeImageAndUpload(System.IO.FileStream newFile, string folderPathAndFilenameNoExtension,
            double maxHeight, double maxWidth)
        {
            try
            {
                // Declare variable for the conversion
                float ratio;

                // Create variable to hold the image
                System.Drawing.Image thisImage = System.Drawing.Image.FromStream(newFile);

                // Get height and width of current image
                int width = (int)thisImage.Width;
                int height = (int)thisImage.Height;

                // Ratio and conversion for new size
                if (width > maxWidth)
                {
                    ratio = (float)width / (float)maxWidth;
                    width = (int)(width / ratio);
                    height = (int)(height / ratio);
                }

                // Ratio and conversion for new size
                if (height > maxHeight)
                {
                    ratio = (float)height / (float)maxHeight;
                    height = (int)(height / ratio);
                    width = (int)(width / ratio);
                }

                // Create "blank" image for drawing new image
                Bitmap outImage = new Bitmap(width, height);
                Graphics outGraphics = Graphics.FromImage(outImage);
                SolidBrush sb = new SolidBrush(System.Drawing.Color.White);

                // Fill "blank" with new sized image
                outGraphics.FillRectangle(sb, 0, 0, outImage.Width, outImage.Height);
                outGraphics.DrawImage(thisImage, 0, 0, outImage.Width, outImage.Height);
                sb.Dispose();
                outGraphics.Dispose();
                thisImage.Dispose();

                // Save new image as jpg
                outImage.Save(Server.MapPath(folderPathAndFilenameNoExtension + ".jpg"),
                System.Drawing.Imaging.ImageFormat.Jpeg);
                outImage.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
