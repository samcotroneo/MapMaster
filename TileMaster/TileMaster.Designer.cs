namespace TileMaster
{
    partial class TileMaster
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
            this.FolderPathTBox = new System.Windows.Forms.TextBox();
            this.ImgPathTBox = new System.Windows.Forms.TextBox();
            this.ProcessButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ColorPickButton = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.ImagePathPicker = new System.Windows.Forms.Button();
            this.OutputPathPicker = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.ImageError = new System.Windows.Forms.Label();
            this.OutputError = new System.Windows.Forms.Label();
            this.ProcessingError = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.ProcessingLabel = new System.Windows.Forms.Label();
            this.ProgressLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // FolderPathTBox
            // 
            this.FolderPathTBox.Location = new System.Drawing.Point(12, 91);
            this.FolderPathTBox.Name = "FolderPathTBox";
            this.FolderPathTBox.Size = new System.Drawing.Size(360, 20);
            this.FolderPathTBox.TabIndex = 1;
            // 
            // ImgPathTBox
            // 
            this.ImgPathTBox.Location = new System.Drawing.Point(12, 36);
            this.ImgPathTBox.Name = "ImgPathTBox";
            this.ImgPathTBox.Size = new System.Drawing.Size(360, 20);
            this.ImgPathTBox.TabIndex = 2;
            // 
            // ProcessButton
            // 
            this.ProcessButton.Location = new System.Drawing.Point(333, 128);
            this.ProcessButton.Name = "ProcessButton";
            this.ProcessButton.Size = new System.Drawing.Size(75, 44);
            this.ProcessButton.TabIndex = 3;
            this.ProcessButton.Text = "Process Image";
            this.ProcessButton.UseVisualStyleBackColor = true;
            this.ProcessButton.Click += new System.EventHandler(this.ProcessButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Image Path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tile Output Folder:";
            // 
            // ColorPickButton
            // 
            this.ColorPickButton.BackColor = System.Drawing.Color.White;
            this.ColorPickButton.Location = new System.Drawing.Point(12, 144);
            this.ColorPickButton.Name = "ColorPickButton";
            this.ColorPickButton.Size = new System.Drawing.Size(23, 23);
            this.ColorPickButton.TabIndex = 6;
            this.ColorPickButton.UseVisualStyleBackColor = false;
            this.ColorPickButton.Click += new System.EventHandler(this.ColorPickButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Background Colour:";
            // 
            // ImagePathPicker
            // 
            this.ImagePathPicker.Location = new System.Drawing.Point(383, 35);
            this.ImagePathPicker.Name = "ImagePathPicker";
            this.ImagePathPicker.Size = new System.Drawing.Size(25, 20);
            this.ImagePathPicker.TabIndex = 8;
            this.ImagePathPicker.Text = "...";
            this.ImagePathPicker.UseVisualStyleBackColor = true;
            this.ImagePathPicker.Click += new System.EventHandler(this.ImagePathPicker_Click);
            // 
            // OutputPathPicker
            // 
            this.OutputPathPicker.Location = new System.Drawing.Point(383, 91);
            this.OutputPathPicker.Name = "OutputPathPicker";
            this.OutputPathPicker.Size = new System.Drawing.Size(25, 20);
            this.OutputPathPicker.TabIndex = 9;
            this.OutputPathPicker.Text = "...";
            this.OutputPathPicker.UseVisualStyleBackColor = true;
            this.OutputPathPicker.Click += new System.EventHandler(this.OutputPathPicker_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // ImageError
            // 
            this.ImageError.AutoSize = true;
            this.ImageError.ForeColor = System.Drawing.Color.Red;
            this.ImageError.Location = new System.Drawing.Point(12, 56);
            this.ImageError.Name = "ImageError";
            this.ImageError.Size = new System.Drawing.Size(81, 13);
            this.ImageError.TabIndex = 10;
            this.ImageError.Text = "Invalid file path.";
            this.ImageError.Visible = false;
            // 
            // OutputError
            // 
            this.OutputError.AutoSize = true;
            this.OutputError.ForeColor = System.Drawing.Color.Red;
            this.OutputError.Location = new System.Drawing.Point(9, 111);
            this.OutputError.Name = "OutputError";
            this.OutputError.Size = new System.Drawing.Size(94, 13);
            this.OutputError.TabIndex = 11;
            this.OutputError.Text = "Invalid folder path.";
            this.OutputError.Visible = false;
            // 
            // ProcessingError
            // 
            this.ProcessingError.AutoSize = true;
            this.ProcessingError.ForeColor = System.Drawing.Color.Red;
            this.ProcessingError.Location = new System.Drawing.Point(278, 144);
            this.ProcessingError.Name = "ProcessingError";
            this.ProcessingError.Size = new System.Drawing.Size(49, 13);
            this.ProcessingError.TabIndex = 12;
            this.ProcessingError.Text = "ERROR!";
            this.ProcessingError.Visible = false;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(12, 214);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(396, 23);
            this.ProgressBar.TabIndex = 13;
            this.ProgressBar.Visible = false;
            // 
            // ProcessingLabel
            // 
            this.ProcessingLabel.AutoSize = true;
            this.ProcessingLabel.Location = new System.Drawing.Point(12, 195);
            this.ProcessingLabel.Name = "ProcessingLabel";
            this.ProcessingLabel.Size = new System.Drawing.Size(68, 13);
            this.ProcessingLabel.TabIndex = 14;
            this.ProcessingLabel.Text = "Processing...";
            this.ProcessingLabel.Visible = false;
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Location = new System.Drawing.Point(201, 219);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(0, 13);
            this.ProgressLabel.TabIndex = 15;
            this.ProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ProgressLabel.Visible = false;
            // 
            // TileMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 249);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.ProcessingLabel);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.ProcessingError);
            this.Controls.Add(this.OutputError);
            this.Controls.Add(this.ImageError);
            this.Controls.Add(this.OutputPathPicker);
            this.Controls.Add(this.ImagePathPicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ColorPickButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProcessButton);
            this.Controls.Add(this.ImgPathTBox);
            this.Controls.Add(this.FolderPathTBox);
            this.Name = "TileMaster";
            this.Text = "Tile Master";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox FolderPathTBox;
        private System.Windows.Forms.TextBox ImgPathTBox;
        private System.Windows.Forms.Button ProcessButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ColorPickButton;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ImagePathPicker;
        private System.Windows.Forms.Button OutputPathPicker;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label OutputError;
        private System.Windows.Forms.Label ImageError;
        private System.Windows.Forms.Label ProcessingError;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Label ProcessingLabel;
        private System.Windows.Forms.ProgressBar ProgressBar;
    }
}

