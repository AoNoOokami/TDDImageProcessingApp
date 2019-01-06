namespace TDDImageProcessingApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btnOpenOriginal = new System.Windows.Forms.Button();
            this.cmbFilters = new System.Windows.Forms.ComboBox();
            this.cmbEdgeDetection = new System.Windows.Forms.ComboBox();
            this.btnSaveNewImage = new System.Windows.Forms.Button();
            this.imageFilterLabel = new System.Windows.Forms.Label();
            this.edgeDetectionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // picPreview
            // 
            this.picPreview.BackColor = System.Drawing.Color.Silver;
            this.picPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picPreview.Location = new System.Drawing.Point(16, 15);
            this.picPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(799, 738);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 14;
            this.picPreview.TabStop = false;
            // 
            // btnOpenOriginal
            // 
            this.btnOpenOriginal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenOriginal.Location = new System.Drawing.Point(12, 774);
            this.btnOpenOriginal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpenOriginal.Name = "btnOpenOriginal";
            this.btnOpenOriginal.Size = new System.Drawing.Size(200, 57);
            this.btnOpenOriginal.TabIndex = 16;
            this.btnOpenOriginal.Text = "Load Image";
            this.btnOpenOriginal.UseVisualStyleBackColor = true;
            this.btnOpenOriginal.Click += new System.EventHandler(this.BtnOpenOriginalClick);
            // 
            // cmbFilters
            // 
            this.cmbFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilters.FormattingEnabled = true;
            this.cmbFilters.Items.AddRange(new object[] {
            "None",
            "Rainbow",
            "Black & white"});
            this.cmbFilters.SelectedIndex = 0;
            this.cmbFilters.Location = new System.Drawing.Point(229, 785);
            this.cmbFilters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbFilters.Name = "cmbFilters";
            this.cmbFilters.Size = new System.Drawing.Size(175, 37);
            this.cmbFilters.TabIndex = 21;
            // 
            // cmbEdgeDetection
            // 
            this.cmbEdgeDetection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEdgeDetection.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEdgeDetection.FormattingEnabled = true;
            this.cmbEdgeDetection.Items.AddRange(new object[] {
            "None",
            "Laplacian 3x3",
            "Sobel 3x3"});
            this.cmbEdgeDetection.SelectedIndex = 0;
            this.cmbEdgeDetection.Location = new System.Drawing.Point(427, 785);
            this.cmbEdgeDetection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbEdgeDetection.Name = "cmbEdgeDetection";
            this.cmbEdgeDetection.Size = new System.Drawing.Size(175, 37);
            this.cmbEdgeDetection.TabIndex = 22;
            this.cmbEdgeDetection.SelectedIndexChanged += new System.EventHandler(this.CmbEdgeDetectionSelectedItemEventHandler);
            // 
            // btnSaveNewImage
            // 
            this.btnSaveNewImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNewImage.Location = new System.Drawing.Point(619, 774);
            this.btnSaveNewImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveNewImage.Name = "btnSaveNewImage";
            this.btnSaveNewImage.Size = new System.Drawing.Size(200, 57);
            this.btnSaveNewImage.TabIndex = 23;
            this.btnSaveNewImage.Text = "Save Image";
            this.btnSaveNewImage.UseVisualStyleBackColor = true;
            this.btnSaveNewImage.Click += new System.EventHandler(this.BtnSaveNewImageClick);
            // 
            // imageFilterLabel
            // 
            this.imageFilterLabel.AutoSize = true;
            this.imageFilterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageFilterLabel.Location = new System.Drawing.Point(225, 757);
            this.imageFilterLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.imageFilterLabel.Name = "imageFilterLabel";
            this.imageFilterLabel.Size = new System.Drawing.Size(106, 25);
            this.imageFilterLabel.TabIndex = 24;
            this.imageFilterLabel.Text = "Image filter";
            this.cmbFilters.SelectedIndexChanged += new System.EventHandler(this.CmbImageFiltersSelectedItemEventHandler);
            // 
            // edgeDetectionLabel
            // 
            this.edgeDetectionLabel.AutoSize = true;
            this.edgeDetectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edgeDetectionLabel.Location = new System.Drawing.Point(421, 757);
            this.edgeDetectionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.edgeDetectionLabel.Name = "edgeDetectionLabel";
            this.edgeDetectionLabel.Size = new System.Drawing.Size(142, 25);
            this.edgeDetectionLabel.TabIndex = 25;
            this.edgeDetectionLabel.Text = "Edge detection";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 843);
            this.Controls.Add(this.edgeDetectionLabel);
            this.Controls.Add(this.imageFilterLabel);
            this.Controls.Add(this.btnSaveNewImage);
            this.Controls.Add(this.cmbEdgeDetection);
            this.Controls.Add(this.cmbFilters);
            this.Controls.Add(this.btnOpenOriginal);
            this.Controls.Add(this.picPreview);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnOpenOriginal;
        private System.Windows.Forms.ComboBox cmbFilters;
        private System.Windows.Forms.ComboBox cmbEdgeDetection;
        private System.Windows.Forms.Button btnSaveNewImage;
        private System.Windows.Forms.Label imageFilterLabel;
        private System.Windows.Forms.Label edgeDetectionLabel;
    }
}

