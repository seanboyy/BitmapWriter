﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMPFinalBoss
{
    public partial class Steganography : Form
    {
        Stegano stegano;
        public Steganography()
        {
            InitializeComponent();
            openFileDialog1.FileOk += new CancelEventHandler(openFileDialog1_FileOk);
        }

        private void Steganography_Load(object sender, EventArgs e)
        {
            InitializeOpenDialog();
            InitializeSaveDialog();
            InitializePicatureBox();
        }

        private void InitializeOpenDialog()
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Bitmap Images(*.bmp)|*.bmp";
            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "Open Image";
        }

        private void InitializeSaveDialog()
        {
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Bitmap Images(*.bmp)|*.bmp";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.Title = "Save Image";
        }

        private void InitializePicatureBox()
        {
            pictureBox1 = new PictureBox();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the file dialog and proceed only if a file is selected
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Display the path. This is for debugging only (ELIMINATE IN FINAL VERSION)
                textBox1.Text = openFileDialog1.FileName;
                // Create a stegano object for this file. NOTE - we are not reading/writing anything with the stegano class yet
                stegano = new Stegano(openFileDialog1.FileName);
                // Set the loaded image as pictureBox1.Image
                // Create a new image from the file
                Image selectedBMP = Image.FromFile(openFileDialog1.FileName);
                // Set the picturebox's size to match the image
                pictureBox1.Size = new Size(selectedBMP.Width, selectedBMP.Height);
                // Set the pictureBox1.Image 
                pictureBox1.Image = selectedBMP;



                //pictureBox1.ImageLocation = openFileDialog1.FileName;
                //pictureBox1.Image = stegano.Bitmap; 
                //pictureBox1.Load();
                Controls.Add(pictureBox1);
                //textBox1.Text = stegano.Decode(numericUpDown1.Value);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stegano.Bitmap = null;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if(stegano.Bitmap != null)
            {
                stegano.Encode(textBox1.Text, numericUpDown1.Value);
            }
        }
    }
}
