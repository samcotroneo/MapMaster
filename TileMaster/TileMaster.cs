using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TileMaster
{
    public partial class TileMaster : Form
    {
        public TileMaster()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //focus first text box
            ActiveControl = ImgPathTBox;
        }

        #region Variables

        //size for output image tiles
        private readonly int standardTileSize = 256;

        //layers of zoom
        private int zoom;

        //image to tile
        private Bitmap src;

        //orientation of image
        private bool landscape;

        //ratio between width and height
        private int ratio;

        #endregion

        #region UI Handling

        #region Interactions

        private async void ProcessButton_Click(object sender, EventArgs e)
        {
            //make sure paths exist
            if (!Directory.Exists(ImgPathTBox.Text.Substring(0, ImgPathTBox.Text.LastIndexOf("\\"))))
            {
                ImageError.Visible = true;
                return;
            }

            ImageError.Visible = false;

            if (!Directory.Exists(FolderPathTBox.Text))
            {
                OutputError.Visible = true;
                return;
            }

            OutputError.Visible = false;

            ProcessingError.Visible = await Task.Run(() => ProcessSequence());
        }

        private bool ProcessSequence()
        {
            //disable UI
            UpdateProgressBar(0f);
            ToggleUI(false);

            //process that image
            if (!LoadImage())
            {
                ToggleUI(true);
                return true;
            }
                

            if (!CreateFolders())
            {
                ToggleUI(true);
                return true;
            }

            if (!ProcessImage())
            {
                ToggleUI(true);
                return true;
            }

            ToggleUI(true);
            return false;
        }

        private void ColorPickButton_Click(object sender, EventArgs e)
        {
            //pick colour of background of image
            if (colorDialog.ShowDialog() == DialogResult.OK) ColorPickButton.BackColor = colorDialog.Color;
        }

        private void ToggleUI(bool state)
        {
            //disable or enable UI before or after processing image
            Invoke((MethodInvoker)delegate {
                //running on the UI thread
                ProcessButton.Enabled = state;
                FolderPathTBox.Enabled = state;
                ImgPathTBox.Enabled = state;
                OutputPathPicker.Enabled = state;
                ImagePathPicker.Enabled = state;
                ColorPickButton.Enabled = state;

                ProcessingLabel.Visible = !state;
                ProgressBar.Visible = !state;
                ProgressLabel.Visible = !state;

                ProgressLabel.BringToFront();
            });
        }

        private void UpdateProgressBar(float percentage)
        {
            //update visual progress of image processing
            Invoke((MethodInvoker)delegate {
                //running on the UI thread
                ProgressLabel.Text = Math.Round((double)percentage, 2, MidpointRounding.AwayFromZero) + "%";
                ProgressBar.Value = (int)Math.Floor(percentage);
            });
        }
        #endregion

        #region File Folder Explorer

        //pick image file
        private void ImagePathPicker_Click(object sender, EventArgs e)
        {
            string filePath = "";
            OpenFileDialog fileBrowserDialog = new OpenFileDialog();
            if (fileBrowserDialog.ShowDialog() == DialogResult.OK) filePath = fileBrowserDialog.FileName;

            ImgPathTBox.Text = filePath;
        }

        //pick output path
        private void OutputPathPicker_Click(object sender, EventArgs e)
        {
            string folderPath = "";
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) folderPath = folderBrowserDialog.SelectedPath;

            FolderPathTBox.Text = folderPath;
        }

        #endregion

        #endregion

        #region Create Folder Structure

        private bool CreateFolders()
        {
            try
            {
                //create folders for each zoom layer
                string pathString = FolderPathTBox.Text;

                for (int i = 0; i < zoom; i++)
                {
                    string subFolder = "" + i;
                    int numOfFolders = 0;
                    if (landscape)
                        numOfFolders = (int)Math.Pow(2, i);
                    else
                        numOfFolders = (int)Math.Ceiling(Math.Pow(2, i) / ratio);
                    if(!CreateSubFolders(pathString, numOfFolders, subFolder))
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        private bool CreateSubFolders(string folderPath, int numberOfFolders, string subFolderName)
        {
            try
            {
                //create sub folders in zoom folders for each column of tiles
                string newFolder = folderPath + "\\" + subFolderName;
                Directory.CreateDirectory(newFolder);

                for (int i = 0; i < numberOfFolders; i++)
                {
                    string newerFolder = newFolder + "\\" + i;
                    Directory.CreateDirectory(newerFolder);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Image Math

        private bool LoadImage()
        {
            try
            {
                //load default image
                string fileName = ImgPathTBox.Text;
                src = Image.FromFile(fileName) as Bitmap;

                //get orientation of image
                landscape = false;
                if (src.Width - src.Height > 0) landscape = true;

                //determine zoom
                bool done = false;
                int maxColumns = 0;
                int newWidth = 0;
                for (int i = 0; !done; i++)
                {
                    int check = (int) (standardTileSize * Math.Pow(2, i));
                    if (check >= src.Width)
                    {
                        newWidth = check;
                        maxColumns = (int) Math.Pow(2, i);
                        done = true;
                        zoom = i + 1;
                    }
                }

                done = false;
                int maxRows = 0;
                int newHeight = 0;
                for (int i = 0; !done; i++)
                {
                    int check = (int) (standardTileSize * Math.Pow(2, i));
                    if (check >= src.Height)
                    {
                        newHeight = check;
                        maxRows = (int) Math.Pow(2, i);
                        done = true;
                        if (i + 1 > zoom) zoom = i + 1;
                    }
                }

                //resize image if needed for nice tiling
                if (src.Width != newWidth || src.Height != newHeight)
                    src = ChangeDimensions(src, newWidth, newHeight, true, ColorPickButton.BackColor);

                //determine ratio between height and width
                ratio = src.Height / src.Width;
                if (landscape) ratio = src.Width / src.Height;
            }
            catch
            {
                return false;
            }

            return true;
        }

        private bool ProcessImage()
        {
            try
            {
                //progress calc
                int currentProcess = 0;
                int numberOfProcess = 0;
                for(int c = 0; c < zoom; c++)
                    numberOfProcess += (int)Math.Pow(2, c) * (int)Math.Ceiling(Math.Pow(2, c) / ratio);

                //loop through zoom layers
                for (int i = 0; i < zoom; i++)
                {
                    //get number of columns of tiles in current zoom layer
                    int loops = 0;
                    if (landscape)
                        loops = (int)Math.Pow(2, i);
                    else
                        loops = (int)Math.Ceiling(Math.Pow(2, i) / ratio);
                    //loop through columns
                    for (int j = 0; j < loops; j++)
                    {
                        //get number of tiles in column for zoom layer
                        int halfLoops = 0;
                        if (landscape)
                            halfLoops = (int)Math.Ceiling(Math.Pow(2, i) / ratio);
                        else
                            halfLoops = (int)Math.Pow(2, i);
                        //loop through tiles
                        for (int k = 0; k < halfLoops; k++)
                        {
                            //determine output folder (created by CreateFolders)
                            string savePath = FolderPathTBox.Text + "\\" + i + "\\" + j + "\\" + k + ".png";
                            //special case for squaring the most zoomed out version of base image (1 tile in - square shaped)
                            if (i == 0)
                            {
                                //resize original image and make it square
                                if (landscape)
                                    ChangeDimensions(ResizeImage(src, standardTileSize, standardTileSize / ratio),
                                            standardTileSize, standardTileSize, false, ColorPickButton.BackColor)
                                        .Save(savePath);
                                else
                                    ChangeDimensions(ResizeImage(src, standardTileSize / ratio, standardTileSize),
                                            standardTileSize, standardTileSize, false, ColorPickButton.BackColor)
                                        .Save(savePath);

                                break;
                            }

                            //get size of tile to cut from base image and create a rect to reflect that
                            int size = 256 * (int)Math.Pow(2, zoom - i - 1);
                            Rectangle cropRect = new Rectangle(size * j, size * k, size, size);

                            //create a new bitmap image and draw the a tile from the original image of the size and position of the rest created
                            using (Bitmap target = new Bitmap(cropRect.Width, cropRect.Height))
                            {
                                using (Graphics g = Graphics.FromImage(target))
                                {
                                    g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height),
                                        cropRect,
                                        GraphicsUnit.Pixel);
                                }

                                //save tile to the folder created earlier
                                ResizeImage(target, standardTileSize, standardTileSize).Save(savePath);
                            }

                            //update progress bar
                            currentProcess++;
                            UpdateProgressBar(((float)currentProcess / (float)numberOfProcess) * 100);
                        }
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Image Manipulation

        private static Bitmap ResizeImage(Image image, int width, int height)
        {
            //create new bitmap to draw to
            Rectangle destRect = new Rectangle(0, 0, width, height);
            Bitmap destImg = new Bitmap(width, height);
            destImg.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            //draw to new bitmap - resize using high quality settings
            using (Graphics g = Graphics.FromImage(destImg))
            {
                g.CompositingMode = CompositingMode.SourceCopy;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    g.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImg;
        }

        private static Bitmap ChangeDimensions(Image image, int width, int height, bool centered, Color backColor)
        {
            //create new bitmap to draw to
            Bitmap destImg = new Bitmap(width, height);
            Rectangle destRect;
            if (centered)
                destRect = new Rectangle((width - image.Width) / 2, (height - image.Height) / 2, image.Width,
                    image.Height);
            else
                destRect = new Rectangle(0, 0, image.Width, image.Height);

            //draw to new bitmap and fill extra space with a colour
            using (Graphics g = Graphics.FromImage(destImg))
            {
                g.Clear(backColor);
                using (ImageAttributes wrapMode = new ImageAttributes())
                {
                    g.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImg;
        }

        #endregion
    }
}