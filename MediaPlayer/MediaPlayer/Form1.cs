﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = true, ValidateNames = true, Filter = "WMV |* .wmv | WAV | * wav | MP3 | * .mp3 | MP4 | * .mp4 | MKV | * .mkv" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    List<MediaFile> files = new List<MediaFile>();
                    foreach(string fileName in ofd.FileNames)
                    {
                        FileInfo fi = new FileInfo(fileName);
                        files.Add(new MediaFile() { FileName = Path.GetFileNameWithoutExtension(fi.FullName), Path = fi.FullName });
                    }
                    ListFile.DataSource = files;
                    
                }
            }
        }

        private void ListFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            MediaFile file = ListFile.SelectedItem as MediaFile;
            if(file != null)
            {
                axWindowsMediaPlayer.URL = file.Path;
                axWindowsMediaPlayer.Ctlcontrols.play();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListFile.ValueMember = "Path";
            ListFile.DisplayMember = "FileName";
        }
    }
}
