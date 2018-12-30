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

        private IEdgeFilters egteFilters;
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

        public BusinessLogic(IFileManager fileManager, ImageController imageController, IBitmapUtil bitmapUtil)
        {
            this.fileManager = fileManager;
            this.bitmapUtil = bitmapUtil; 
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
