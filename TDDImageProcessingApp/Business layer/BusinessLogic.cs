using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDImageProcessingApp
{
    public class BusinessLogic
    {
        private IFileManager fileManager;

        private IBitmapUtil bitmapUtil;

        private IEdgeFilters edgeFilters;
        private IImageFilters imageFilters;

        // original image loaded by the user
        private Bitmap originalBitmap;
        // previewBitmap show in the main form
        private Bitmap previewBitmap = null;
        // resultBitmap image after applying a filter
        private Bitmap imageFilterResult = null;
        // the selectedSource is used like a temporary image before the save
        private Bitmap selectedSource = null;
        // resultBitmap image after applying edge detection
        private Bitmap resultBitmap = null;
        // bitmapResult is the image that will be saved
        private Bitmap bitmapResult = null;

        public BusinessLogic(IFileManager fileManager, IBitmapUtil bitmapUtil, IEdgeFilters edgeFilters, IImageFilters imageFilters)
        {
            this.fileManager = fileManager;
            this.bitmapUtil = bitmapUtil;
            this.edgeFilters = edgeFilters;
            this.imageFilters = imageFilters; 

        }

        public BusinessLogic(IImageFilters imageFilters)
        {
            this.imageFilters = imageFilters;
        }

        public BusinessLogic(IFileManager fileManager)
        {
            this.fileManager = fileManager;
        }

        public Bitmap CopyToSquareCanvas(Bitmap sourceBitmap, int canvasWidthLenght)
        {

            previewBitmap = bitmapUtil.CopyToSquareCanvas(sourceBitmap, canvasWidthLenght); 
            return previewBitmap; 
        }

        public Bitmap LoadImage(string filename)
        {
            originalBitmap = fileManager.LoadImage(filename);
            return originalBitmap;
        }

        public void SaveImage(string filename, Bitmap resultBitmap, ImageFormat imgFormat)
        {
            fileManager.SaveImage(filename, resultBitmap, imgFormat);
        }

        public Bitmap ApplyImageFilter(string selectedItem)
        {
            //var selectedItem = filter.GetSelectedItem();
            bitmapResult = null;
            selectedSource = previewBitmap;

            if (imageFilterResult != null)
                selectedSource = originalBitmap;

            if (selectedSource != null)
            {
                switch (selectedItem)
                {
                    case "None":
                        bitmapResult = selectedSource;
                        imageFilterResult = null;
                        break;
                    case "Rainbow":
                        bitmapResult = imageFilters.RainbowFilter(selectedSource);
                        imageFilterResult = bitmapResult;
                        break;
                    case "Black & white":
                        bitmapResult = imageFilters.BlackWhite(selectedSource);
                        imageFilterResult = bitmapResult;
                        break;
                }
            }

            return bitmapResult; 
        }

        public Bitmap EdgeDetection(string selectedItem)
        {
            bitmapResult = null;
            selectedSource = previewBitmap;

            if (imageFilterResult != null)
                selectedSource = imageFilterResult;

            if (selectedSource != null)
            {
                // retrieve selected edge filter
                switch (selectedItem)
                {
                    case "None":
                        bitmapResult = selectedSource;
                        break;
                    case "Laplacian 3x3":
                        bitmapResult = edgeFilters.Laplacian3x3Filter(selectedSource, false);
                        break;
                    case "Sobel 3x3":
                        bitmapResult = edgeFilters.Sobel3x3Filter(selectedSource, false);
                        break;
                }
             }

            return bitmapResult;
        }

        public IFileManager FileManager
        {
            get => fileManager;
            set => fileManager = value;
        }

/*        public Bitmap LoadOriginalFile(string filename)
        {

        }*/

        public Bitmap OriginalBitmap
        {
            get => originalBitmap;
            set => originalBitmap = value;
        }

        public Bitmap BitmapResult
        {
            get => bitmapResult;
            set => bitmapResult = value;
        }

        public Bitmap ResultBitmap
        {
            get => resultBitmap;
            set => resultBitmap = value;
        }
    }
}
