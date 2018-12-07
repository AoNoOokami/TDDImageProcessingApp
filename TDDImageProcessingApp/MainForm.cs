using System.Windows.Forms;

namespace TDDImageProcessingApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            cmbEdgeDetection.SelectedIndex = 0;
            cmbFilters.SelectedIndex = 0;
        }
    }
}
