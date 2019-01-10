using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDImageProcessingApp
{
    public class ImageController
    {
        // use the interfaces in the business logic
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

        // constructor with all interfaces to be instantiated in the view
        public ImageController(IFileManager fileManager, IBitmapUtil bitmapUtil, IEdgeFilters edgeFilters, IImageFilters imageFilters)
        {
            this.fileManager = fileManager;
            this.bitmapUtil = bitmapUtil;
            this.edgeFilters = edgeFilters;
            this.imageFilters = imageFilters; 
        }

        public ImageController(IFileManager fileManager)
        {
            this.fileManager = fileManager;
        }
        // use the interface bitmapUtil to resize the image to fit the window
        public Bitmap CopyToSquareCanvas(Bitmap sourceBitmap, int canvasWidthLenght)
        {
            previewBitmap = bitmapUtil.CopyToSquareCanvas(sourceBitmap, canvasWidthLenght); 
            return previewBitmap; 
        }
        // use to load the original image to be opened
        public Bitmap LoadImage(string filename)
        {
            originalBitmap = fileManager.LoadImage(filename);
            return originalBitmap;
        }
        // use to save the filtered image
        public void SaveImage(string filename, Bitmap resultBitmap, ImageFormat imgFormat)
        {
            fileManager.SaveImage(filename, resultBitmap, imgFormat);
        }
        // apply an image filter with the interface IImageFilters
        public Bitmap ApplyImageFilter(string selectedItem, IBitmapUtil bitmapUtiltest)
        {
            bitmapResult = null;
            selectedSource = bitmapUtiltest.SetBitmap(previewBitmap);
            // if the image has already been filtered, the original image is reused
            if (imageFilterResult != null)
                selectedSource = originalBitmap;

            if (selectedSource != null)
            {
                // retrieve selected image filter
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
        // apply an edge detection with the interface IEdgeFilters
        public Bitmap EdgeDetection(string selectedItem, IBitmapUtil bitmapUtiltest)
        {
            bitmapResult = null;
            selectedSource = bitmapUtiltest.SetBitmap(previewBitmap);
            // check if the image was already transformed
            if (imageFilterResult != null)
                selectedSource = imageFilterResult;
            else
                selectedSource = originalBitmap;

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

        public Bitmap OriginalBitmap
        {
            get => originalBitmap;
            set => originalBitmap = value;
        }

        public Bitmap ImageFilterResult
        {
            set => imageFilterResult = value;
        }

        /*        // getters and setters
                public IFileManager FileManager
                {
                    get => fileManager;
                    set => fileManager = value;
                }
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

                public Bitmap SelectedSource
                {
                    get => selectedSource;
                    set => selectedSource = value;
                }

                public Bitmap PreviewBitmap
                {
                    get => previewBitmap;
                    set => previewBitmap = value;
                }*/
    }
}
