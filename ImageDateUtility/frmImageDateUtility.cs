/**
 * This program is for changing the EXIF date and the file create,mod,access times of JPG images.
 * 
 * Do not use this program for illegal, immoral, or otherwise nefarious purposes.
 * 
 * @author benkillin
 * @date 22 Nov 2011
 * 
##    Copyright (C) 2011 benkillin
##
##    This program is free software: you can redistribute it and/or modify
##    it under the terms of the GNU General Public License as published by
##    the Free Software Foundation, either version 3 of the License, or
##    (at your option) any later version.
##
##    This program is distributed in the hope that it will be useful,
##    but WITHOUT ANY WARRANTY; without even the implied warranty of
##    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
##    GNU General Public License for more details.
##
##   You should have received a copy of the GNU General Public License
##   along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows;
using System.Drawing.Imaging;
using System.Threading;

namespace ImageDateUtility
{
    public partial class frmImageDateUtility : Form
    {
        public const int EXIF_DATE_TIME = 306;
        public const int EXIF_DATE_TIME_ORIGINAL = 36867;
        public const int EXIF_DATE_TIME_DIGITIZED = 36868;

        private string path;
        private string exifDateString;
        private DateTime date;
        private DateTime time;
        private DateTime combinedTime;
        private DialogResult result;

        public frmImageDateUtility()
        {
            InitializeComponent();
        }

        private void btnSelectSourceBatch_Click(object sender, EventArgs e)
        {
            result = dlgFolderBrowser.ShowDialog();

            txtBatchFilePath.Text = dlgFolderBrowser.SelectedPath;
        }

        private void btnStartBatch_Click(object sender, EventArgs e)
        {
            if (result.ToString().ToUpper().Equals("OK"))
            {
                DialogResult confirmResult = MessageBox.
                    Show("ARE YOU SURE YOU WISH TO PROCESS THE PHOTOS IN THE DIRECTORY BELOW?\n\n" +
                    this.path
                    + "\n\nDoing so will re-encode the JPG files with a new file timestamp and modified EXIF data, meaning a slight loss of image information due to JPG compression (meaning the picture quality will degrade slightly). So don't do this more than once on a given directory and only do it on copies, not the original photos from your camera.",
                    "Are you sure?", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (confirmResult.ToString().ToUpper().Equals("YES"))
                {
                    path = dlgFolderBrowser.SelectedPath;
                    date = dtpBatchDate.Value;
                    time = dtpBatchTime.Value;
                    combinedTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second, time.Millisecond);

                    Thread t = new Thread(new ThreadStart(processPhotos));
                    t.Start();
                }
            }
            else
            {
                MessageBox.Show("Error: Selecting the batch processing folder was unsuccessful.\nPlease click the 'Select Source Directory' button and select a directory to start processing photos from.", "Error processing photos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// The worker function for patch processing. This is to be started as a separate thread.
        /// </summary>
        private void processPhotos()
        {
            Random r = new Random((int)DateTime.Now.Ticks);
            List<string> files = new List<string>();

            files.AddRange(Directory.GetFiles(path, "*.jpg"));
            files.AddRange(Directory.GetFiles(path, "*.jpeg"));
            
            this.BeginInvoke((Action)(() => progressBar1.Value = 0));
            this.BeginInvoke((Action)(() => progressBar1.Step = 1));
            this.BeginInvoke((Action)(() => progressBar1.Maximum = files.Count + 1));
            this.BeginInvoke((Action)(() => progressBar1.PerformStep())); // do one progress bar step immediately to indicate we have started processing

            foreach (string file in files)
            {
                exifDateString = combinedTime.ToString("yyyy:MM:dd HH:mm:ss");

                // set EXIF data to specified time
                // http://www.media.mit.edu/pia/Research/deepview/exif.html
                //0x0132 	DateTime 	ascii string 	20 	Date/Time of image was last modified. Data format is "YYYY:MM:DD HH:MM:SS"+0x00, total 20bytes. In usual, it has the same value of DateTimeOriginal(0x9003)
                //0x9003 	DateTimeOriginal 	ascii string 	20 	Date/Time of original image taken. This value should not be modified by user program.
                //0x9004 	DateTimeDigitized 	ascii string 	20 	Date/Time of image digitized. Usually, it contains the same value of DateTimeOriginal(0x9003).
                // http://archive.msdn.microsoft.com/changexifwithcsharp
                Image iOrig = new Bitmap(file);
                ImageFormat ifOrig = iOrig.RawFormat;
                PropertyItem exifDateTimeProp = iOrig.GetPropertyItem(EXIF_DATE_TIME);
                PropertyItem exifDateTimeOrigProp = iOrig.GetPropertyItem(EXIF_DATE_TIME_ORIGINAL);
                PropertyItem exifDateTimeDigiProp = iOrig.GetPropertyItem(EXIF_DATE_TIME_DIGITIZED);

                exifDateTimeProp.Value = System.Text.Encoding.UTF8.GetBytes(exifDateString);
                exifDateTimeOrigProp.Value = System.Text.Encoding.UTF8.GetBytes(exifDateString);
                exifDateTimeDigiProp.Value = System.Text.Encoding.UTF8.GetBytes(exifDateString);

                iOrig.SetPropertyItem(exifDateTimeProp);
                iOrig.SetPropertyItem(exifDateTimeOrigProp);
                iOrig.SetPropertyItem(exifDateTimeDigiProp);

                Image iSave = new Bitmap(iOrig.Width, iOrig.Height, iOrig.PixelFormat);
                Graphics gSave = Graphics.FromImage(iSave);

                gSave.DrawImage(iOrig, 0, 0, iOrig.Width, iOrig.Height);

                foreach (PropertyItem i in iOrig.PropertyItems)
                    iSave.SetPropertyItem(i);

                // WHAT THE FUCK?!
                // You *HAVE* to dispose these two objects, iOrig and gSave, BEFORE you save iSave otherwise
                // you'll get an unexplained GDI+ exception... THANK YOU MICROSOFT! >:(
                iOrig.Dispose();
                gSave.Dispose();

                iSave.Save(file, ifOrig);

                iSave.Dispose();


                // set file create, mod, and access time to the specified time
                // (this has to be done after the EXIF modification because that will modify the file, of course)

                File.SetCreationTime(file, combinedTime);
                File.SetLastWriteTime(file, combinedTime);
                File.SetLastAccessTime(file, combinedTime);


                if (chkRandomize.Checked)
                { // randomize the time to between 0800 and 1600 to make it believable:
                    int hour = r.Next(8, 17);
                    int minute = r.Next(60);
                    int second = r.Next(60);
                    int millisecond = r.Next(1000);

                    combinedTime = new DateTime(combinedTime.Year, combinedTime.Month, combinedTime.Day, hour, minute, second, millisecond);
                }


                // do progressbar step after we finished a file to give accurate feedback
                this.BeginInvoke((Action)(() => progressBar1.PerformStep()));
            }


            MessageBox.Show("Finished Processing.", "Success");
            this.BeginInvoke((Action)(() => progressBar1.Value = 0));
        }
    }
}
