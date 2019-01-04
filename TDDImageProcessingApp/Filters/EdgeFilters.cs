﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace TDDImageProcessingApp
{
    public class EdgeFilters : IEdgeFilters
    {

        public Bitmap Sobel3x3Filter(Bitmap sourceBitmap,
        bool grayscale = true)
        {
            Bitmap resultBitmap = EdgeFilters.ConvolutionFilter(sourceBitmap,
            Matrix.Sobel3x3Horizontal,
            Matrix.Sobel3x3Vertical,
            1.0, 0, grayscale);

            return resultBitmap;
        }

        public Bitmap Laplacian3x3Filter(Bitmap sourceBitmap,
        bool grayscale = true)
        {
            Bitmap resultBitmap = EdgeFilters.ConvolutionFilter(sourceBitmap, 
                Matrix.Laplacian3x3, 1.0, 0, grayscale);

            return resultBitmap;
        }
        // use the convolution matrix to prepare the image processing
        private static Bitmap ConvolutionFilter(Bitmap sourceBitmap,
        double[,] filterMatrix,
        double factor = 1,
        int bias = 0,
        bool grayscale = false)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
            sourceBitmap.Width, sourceBitmap.Height),
            ImageLockMode.ReadOnly,
            PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            if (grayscale == true)
            {
                ApplyGreyScale(pixelBuffer);
            }

            int filterWidth = filterMatrix.GetLength(1);

            int filterOffset = (filterWidth - 1) / 2;
            for (int offsetY = filterOffset; offsetY <
            sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX < sourceBitmap.Width - filterOffset; offsetX++)
                {
                    double blue = 0;
                    double green = 0;
                    double red = 0;

                    int byteOffset = offsetY * sourceData.Stride + offsetX * 4;

                    for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                        filterX <= filterOffset; filterX++)
                        {
                            int calcOffset = byteOffset + (filterX * 4) + (filterY * sourceData.Stride);

                            blue += (double)(pixelBuffer[calcOffset]) * filterMatrix[filterY + filterOffset, filterX + filterOffset];

                            green += (double)(pixelBuffer[calcOffset + 1]) *
                            filterMatrix[filterY + filterOffset,
                            filterX + filterOffset];

                            red += (double)(pixelBuffer[calcOffset + 2]) *
                            filterMatrix[filterY + filterOffset,
                            filterX + filterOffset];
                        }
                    }

                    blue = factor * blue + bias;
                    green = factor * green + bias;
                    red = factor * red + bias;

                    if (blue > 255)
                        blue = 255;
                    else if (blue < 0)
                        blue = 0;

                    if (green > 255)
                        green = 255;
                    else if (green < 0)
                        green = 0;

                    if (red > 255)
                        red = 255;
                    else if (red < 0)
                        red = 0;

                    resultBuffer[byteOffset] = (byte)(blue);
                    resultBuffer[byteOffset + 1] = (byte)(green);
                    resultBuffer[byteOffset + 2] = (byte)(red);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
            resultBitmap.Width, resultBitmap.Height),
            ImageLockMode.WriteOnly,
            PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        // use a convolution matrix to prepare the image processing
        // with cartesian coordinate system
        public static Bitmap ConvolutionFilter(Bitmap sourceBitmap,
        double[,] xFilterMatrix,
        double[,] yFilterMatrix,
        double factor = 1,
        int bias = 0,
        bool grayscale = false)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
            sourceBitmap.Width, sourceBitmap.Height),
            ImageLockMode.ReadOnly,
            PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            if (grayscale == true)
            {
                ApplyGreyScale(pixelBuffer);
            }

            int filterOffset = 1;
            for (int offsetY = filterOffset; offsetY < sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                sourceBitmap.Width - filterOffset; offsetX++)
                {

                    double greenX = 0.0;

                    double redX = 0.0;
                    double blueX = greenX = redX = 0;

                    double greenY = 0.0;

                    double redY = 0.0;
                    double blueY = greenY = redY = 0;


                    double greenTotal = 0.0;

                    double redTotal = 0.0;
                    double blueTotal = greenTotal = redTotal = 0.0;

                    int byteOffset = offsetY * sourceData.Stride + offsetX * 4;

                    for (int filterY = -filterOffset;
                    filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                        filterX <= filterOffset; filterX++)
                        {
                            int calcOffset = byteOffset + (filterX * 4) + (filterY * sourceData.Stride);

                            blueX += (double)(pixelBuffer[calcOffset]) *
                            xFilterMatrix[filterY + filterOffset,
                            filterX + filterOffset];

                            greenX += (double)(pixelBuffer[calcOffset + 1]) *
                            xFilterMatrix[filterY + filterOffset,
                            filterX + filterOffset];

                            redX += (double)(pixelBuffer[calcOffset + 2]) *
                            xFilterMatrix[filterY + filterOffset,
                            filterX + filterOffset];

                            blueY += (double)(pixelBuffer[calcOffset]) *
                            yFilterMatrix[filterY + filterOffset,
                            filterX + filterOffset];

                            greenY += (double)(pixelBuffer[calcOffset + 1]) *
                            yFilterMatrix[filterY + filterOffset,
                            filterX + filterOffset];

                            redY += (double)(pixelBuffer[calcOffset + 2]) *
                            yFilterMatrix[filterY + filterOffset,
                            filterX + filterOffset];
                        }
                    }

                    blueTotal = Math.Sqrt((blueX * blueX) + (blueY * blueY));
                    greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY));
                    redTotal = Math.Sqrt((redX * redX) + (redY * redY));

                    if (blueTotal > 255)
                        blueTotal = 255;
                    else if (blueTotal < 0)
                        blueTotal = 0;

                    if (greenTotal > 255)
                        greenTotal = 255;
                    else if (greenTotal < 0)
                        greenTotal = 0;

                    if (redTotal > 255)
                        redTotal = 255;
                    else if (redTotal < 0)
                        redTotal = 0;

                    resultBuffer[byteOffset] = (byte)(blueTotal);
                    resultBuffer[byteOffset + 1] = (byte)(greenTotal);
                    resultBuffer[byteOffset + 2] = (byte)(redTotal);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height),
            ImageLockMode.WriteOnly,
            PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        public static void ApplyGreyScale(byte[] pixelBuffer)
        {
            float rgb = 0;
            for (int k = 0; k < pixelBuffer.Length; k += 4)
            {
                rgb = pixelBuffer[k] * 0.11f;
                rgb += pixelBuffer[k + 1] * 0.59f;
                rgb += pixelBuffer[k + 2] * 0.3f;

                pixelBuffer[k] = (byte)rgb;
                pixelBuffer[k + 1] = pixelBuffer[k];
                pixelBuffer[k + 2] = pixelBuffer[k];
                pixelBuffer[k + 3] = 255;
            }

        }
    }
}