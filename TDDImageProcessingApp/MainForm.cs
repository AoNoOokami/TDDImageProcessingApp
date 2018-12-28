using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TDDImageProcessingApp
{
    public partial class MainForm : Form
    {
        // use interface to load file
        private FileManipulation _fileManipulation;
        // original image loaded by the user
        private Bitmap originalBitmap;
        // previewBitmap show in the main form
        private Bitmap previewBitmap = null;
        // resultBitmap image after applying edge detection
        private Bitmap resultBitmap = null;
        // bitmapResult is the image that will be saved
        private Bitmap bitmapResult = null;

        public MainForm()
        {
            InitializeComponent();
            cmbEdgeDetection.SelectedIndex = 0;
            cmbFilters.SelectedIndex = 0;
        }
        // todo finish the implementation of the loadImage with interfaces
        private void BtnOpenOriginalClick(object sender, EventArgs e)
        {
            _fileManipulation = new FileManipulation();
            originalBitmap = _fileManipulation.LoadImage();

            if (originalBitmap != null)
            {
                previewBitmap = originalBitmap.CopyToSquareCanvas(picPreview.Width);
                picPreview.Image = previewBitmap;
                bitmapResult = originalBitmap;
            }
        }
    }
}
