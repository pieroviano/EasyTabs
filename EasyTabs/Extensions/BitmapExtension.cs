using System;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace EasyTabs;

/// <summary>
/// BitmapExtension class.
/// </summary>
public static class BitmapExtension
{
    /// <summary>
    /// Resizes the image
    /// </summary>
    /// <param name="imgToResize">The image to resize.</param>
    /// <param name="percentX">The X percentage.</param>
    /// <param name="percentY">The Y percentage.</param>
    /// <returns></returns>
    public static Image ResizeImage(this Image imgToResize, double percentX, double percentY)
    {
        // Get the image current width
        int sourceWidth = imgToResize.Width;
        // Get the image current height
        int sourceHeight = imgToResize.Height;
        // New Width and Height
        int destWidth = (int)Math.Ceiling(sourceWidth * percentX);
        int destHeight = (int)Math.Ceiling(sourceHeight * percentY);
        Bitmap b = new Bitmap(destWidth, destHeight);
        Graphics g = Graphics.FromImage(b);
        g.InterpolationMode = InterpolationMode.Low;
        // Draw image with new width and height
        g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
        g.Dispose();
        return b;
    }
}