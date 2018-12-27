using System;
using System.Drawing;
using System.Windows.Forms;

namespace TDDImageProcessingApp
{
    public partial class MainForm : Form
    {
        // original image loaded by the user
        private LoadImage originalBitmap ;
        // previewBitmap show in the main form
        private Bitmap previewBitmap = null;


        private LoadImage loadOriginalImage; 
        public MainForm()
        {
            InitializeComponent();
            cmbEdgeDetection.SelectedIndex = 0;
            cmbFilters.SelectedIndex = 0;
        }
// todo finish the implementation of the loadImage with interfaces
        private void BtnOpenOriginalClick(object sender, EventArgs e)
        {
            originalBitmap = new LoadImage();

        }
    }
}
