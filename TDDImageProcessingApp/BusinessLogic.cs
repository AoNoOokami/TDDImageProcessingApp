using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDImageProcessingApp
{
    class BusinessLogic
    {
        private FileManipulation fileManipulation;
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

        public BusinessLogic(FileManipulation fileManipulation)
        {
            this.fileManipulation = fileManipulation;
        }

        public FileManipulation FileManipulation
        {
            get => fileManipulation;
            set => fileManipulation = value;
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
    }
}
