using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

/// <summary>
/// Class contaning method to resize an image and save in JPEG format
/// </summary>
public class ImageHandler
{
    /// <summary>
    /// Method to resize, convert and save the image.
    /// </summary>
    /// <param name="image">Bitmap image.</param>
    /// <param name="maxWidth">resize width.</param>
    /// <param name="maxHeight">resize height.</param>
    /// <param name="quality">quality setting value.</param>
    /// <param name="filePath">file path.</param>      
    public static void ResizeAndSaveImage(HttpPostedFile image, int maxWidth, int maxHeight, string filePath)
    {
        using (Image OriginalImage = Image.FromStream(image.InputStream))
        {
            OriginalImage.Save(filePath);
        }
        return;
        using (Image OriginalImage = Image.FromStream(image.InputStream))
        {
            float ratio;
            // Get height and width of current image
            int width = OriginalImage.Width;
            int height = OriginalImage.Height;

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

            // Convert other formats (including CMYK) to RGB.
            using (Bitmap newImage = new Bitmap(width, height))
            {
                using (Graphics outGraphics = Graphics.FromImage(newImage))
                {
                    using (SolidBrush sb = new SolidBrush(System.Drawing.Color.White))
                    {
                        // Fill "blank" with new sized image
                        outGraphics.FillRectangle(sb, 0, 0, newImage.Width, newImage.Height);
                        outGraphics.DrawImage(OriginalImage, 0, 0, newImage.Width, newImage.Height);

                        if (System.IO.Path.GetExtension(filePath).ToLower() == ".jpeg" || System.IO.Path.GetExtension(filePath).ToLower() == ".jpg")
                            newImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        if (System.IO.Path.GetExtension(filePath).ToLower() == ".png")
                            newImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                        if (System.IO.Path.GetExtension(filePath).ToLower() == ".gif")
                            newImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Gif);
                        if (System.IO.Path.GetExtension(filePath).ToLower() == ".bmp")
                            newImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                }
            }
        }
    }
}