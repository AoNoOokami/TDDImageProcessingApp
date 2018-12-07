﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDImageProcessingApp;

namespace TDDImageProcessingAppTest
{
    [TestClass]
    public class EdgeFilterTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        /* @author : Alicia
         * Filter tested : Sobel3x3Filter in EdgeFilters class without Grayscale.
         * Byte per byte image comparison: we have a reference image to compare with filtered image */
        [TestMethod]
        public void Sobel3x3FilterTest()
        {
            // Custom image used for test
            Bitmap TestImg = Properties.Resources.cherry;
            // Method result for comparison
            Bitmap Result;
            // Reference image for comparison
            Bitmap Reference = Properties.Resources.cherry_sobel;

            Result = EdgeFilters.Sobel3x3Filter(TestImg, false);

            Assert.IsTrue(CompareBitmap(Result, Reference));
        }

        /* @author : Alicia
         * Byte per byte bitmap comparison.
         * If images are the same, return true. If not, return false.*/
        public bool CompareBitmap(Bitmap bmp1, Bitmap bmp2)
        {
            if (bmp1 == null || bmp2 == null)
                return false;
            if (object.Equals(bmp1, bmp2))
                return true;
            if (!bmp1.Size.Equals(bmp2.Size) || !bmp1.PixelFormat.Equals(bmp2.PixelFormat))
                return false;

            int bytes = bmp1.Width * bmp1.Height * (Image.GetPixelFormatSize(bmp1.PixelFormat) / 8);

            bool result = true;
            byte[] b1bytes = new byte[bytes];
            byte[] b2bytes = new byte[bytes];

            BitmapData bitmapData1 = bmp1.LockBits(new Rectangle(0, 0, bmp1.Width - 1, bmp1.Height - 1), ImageLockMode.ReadOnly, bmp1.PixelFormat);
            BitmapData bitmapData2 = bmp2.LockBits(new Rectangle(0, 0, bmp2.Width - 1, bmp2.Height - 1), ImageLockMode.ReadOnly, bmp2.PixelFormat);

            Marshal.Copy(bitmapData1.Scan0, b1bytes, 0, bytes);
            Marshal.Copy(bitmapData2.Scan0, b2bytes, 0, bytes);

            for (int n = 0; n <= bytes - 1; n++)
            {
                if (b1bytes[n] != b2bytes[n])
                {
                    result = false;
                    break;
                }
            }

            bmp1.UnlockBits(bitmapData1);
            bmp2.UnlockBits(bitmapData2);

            return result;
        }
    }
}
