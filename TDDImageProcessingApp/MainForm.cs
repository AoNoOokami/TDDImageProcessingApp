using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TDDImageProcessingApp
{
    public partial class MainForm : Form
    {
        // use interface to load file
        private FileManager _fileManager;
        private IBitmapUtil _bitmapUtil;
        private IEdgeFilters edgeFilters;
        private IImageFilters imageFilters;

        // use business logic to interact with the view layer
        private BusinessLogic _businessLogic;
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
            _fileManager = new FileManager();
           //todo delete or replace BusinessLogig with imageControler => do discuss
            //  imageController = new ImageController();
            _bitmapUtil = new BitmapUtil();
            edgeFilters = new EdgeFilters();
            imageFilters = new ImageFilters();

            _businessLogic = new BusinessLogic(_fileManager, _bitmapUtil, edgeFilters, imageFilters);
            InitializeComponent();
            cmbEdgeDetection.SelectedIndex = 0;
            cmbFilters.SelectedIndex = 0;
            cmbEdgeDetection.Enabled = false;
            cmbFilters.Enabled = false;
        }
        private void BtnOpenOriginalClick(object sender, EventArgs e)
        {
            // open the file dialog to load an image
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image file.";
            ofd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
            ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // open the file from the bussiness logic through an interface to load an image
                originalBitmap = _businessLogic.LoadImage(ofd.FileName);
                //businessLogic.OriginalBitmap = originalBitmap;
            }

            // calling the method from business logic to resize the image
            previewBitmap = _businessLogic.CopyToSquareCanvas(originalBitmap, picPreview.Width);
            // set the resized image in the preview window
            picPreview.Image = previewBitmap;
            bitmapResult = originalBitmap;

            if (cmbEdgeDetection.SelectedItem.ToString() != "None")
            {
                cmbFilters.Enabled = false;
            }
            else
            {
                cmbFilters.Enabled = true;
                cmbEdgeDetection.Enabled = true;
            }
            bitmapResult = _businessLogic.ApplyImageFilter(cmbFilters.SelectedItem.ToString(), _bitmapUtil);
            bitmapResult = _businessLogic.EdgeDetection(cmbEdgeDetection.SelectedItem.ToString(), _bitmapUtil);

            if (bitmapResult != null) { 
                picPreview.Image = bitmapResult;
            }

        }
        private void BtnSaveNewImageClick(object sender, EventArgs e)
        {
/*            // TODO à supprimer ajouter juste pour le test de cette méthode
            resultBitmap = businessLogic.OriginalBitmap; */

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Specify a file name and file path";
            sfd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
            sfd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileExtension = Path.GetExtension(sfd.FileName).ToUpper();
                ImageFormat imgFormat = ImageFormat.Png;

                if (fileExtension == "BMP")
                {
                    imgFormat = ImageFormat.Bmp;
                }
                else if (fileExtension == "JPG")
                {
                    imgFormat = ImageFormat.Jpeg;
                }

                _businessLogic.SaveImage(sfd.FileName, resultBitmap, imgFormat);

                MessageBox.Show("The image has been saved in " + sfd.FileName.ToString(), "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //TODO move NEXT methods in Bussiness Logic
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

            bitmapResult = _businessLogic.EdgeDetection(cmbEdgeDetection.SelectedItem.ToString(), _bitmapUtil);

            if (bitmapResult != null)
            {
                picPreview.Image = bitmapResult;
                resultBitmap = bitmapResult;
            }
        }

        // event handler for Image Filters
        private void CmbImageFiltersSelectedItemEventHandler(object sender, EventArgs e)
        {
            selectedSource = previewBitmap;
            bitmapResult = _businessLogic.ApplyImageFilter(cmbFilters.SelectedItem.ToString(), _bitmapUtil);

            if (bitmapResult != null)
            {
                picPreview.Image = bitmapResult;
                resultBitmap = bitmapResult;
            }

        }
    }
}
