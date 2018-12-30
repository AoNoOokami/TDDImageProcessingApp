using System;
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
        private FileManipulation fileManipulation;
        private ImageController imageController;

        // use business logic to interact with the view layer
        private BusinessLogic businessLogic;
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
            fileManipulation = new FileManipulation();
            imageController = new ImageController();
            businessLogic = new BusinessLogic(fileManipulation, imageController);
            InitializeComponent();
            cmbEdgeDetection.SelectedIndex = 0;
            cmbFilters.SelectedIndex = 0;
        }
        // todo finish the implementation of the loadImage with interfaces
        private void BtnOpenOriginalClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image file.";
            ofd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
            ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                originalBitmap = businessLogic.FileManipulation.LoadImage(ofd.FileName);
                businessLogic.OriginalBitmap = originalBitmap;
            }
            previewBitmap = originalBitmap.CopyToSquareCanvas(picPreview.Width);
            picPreview.Image = previewBitmap;
        }

        //TODO to finish
        private void BtnSaveNewImageClick(object sender, EventArgs e)
        {
            // TODO à supprimer ajouter juste pour le test de cette méthode
            resultBitmap = businessLogic.OriginalBitmap; 

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

                businessLogic.FileManipulation.SaveImage(sfd.FileName, resultBitmap, imgFormat);

                MessageBox.Show("The image has been saved in " + sfd.FileName.ToString(), "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //TODO move NEXT methods in Bussiness Logic
/*        private void CmbEdgeDetectionSelectedItemEventHandler(object sender, EventArgs e)
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

        }*/

/*        private void ApplyEdgeDetection(bool b)
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
        }*/

        private void CmbFiltersSelectedItemEventHandler(object sender, EventArgs e)
        {
            
        }
    }
}
