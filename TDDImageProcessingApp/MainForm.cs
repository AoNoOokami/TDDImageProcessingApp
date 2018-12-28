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
        // resultBitmap image after applying a filter
        private Bitmap imageFilterResult = null;
        // the selectedSource is used like a temporary image before the save
        private Bitmap selectedSource = null;
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

        //TODO to finish
        private void BtnSaveNewImageClick(object sender, EventArgs e)
        {
            // TODO delet juste for test before the filters
            resultBitmap = originalBitmap; 
            if (resultBitmap != null)
            {
                _fileManipulation.SaveImage(resultBitmap);
            }
        }

        private void CmbEdgeDetectionSelectedItemEventHandler(object sender, EventArgs e)
        {
            // if cmbEdgeDetection is 'None', method couldn't be applied
            if (cmbEdgeDetection.SelectedItem.ToString() != "None")
            {
                cmbFilters.Enabled = false;
            }
            else
            {
                cmbFilters.Enabled = true;
            }
            ApplyEdgeDetection(true);

        }

        private void ApplyEdgeDetection(bool b)
        {
            if (imageFilterResult != null)
                selectedSource = imageFilterResult;

            // retrieve selected edge filter
            switch (cmbEdgeDetection.SelectedItem.ToString())
            {
                case "None":
                    bitmapResult = selectedSource;
                    break;  
                case "Laplacian 3x3":
                    bitmapResult = selectedSource.Laplacian3x3Filter(false);
                    break;
                case "Sobel 3x3":
                    bitmapResult = selectedSource.Sobel3x3Filter(false);
                    break;
            }
        }

        private void CmbFiltersSelectedItemEventHandler(object sender, EventArgs e)
        {
            
        }
    }
}
