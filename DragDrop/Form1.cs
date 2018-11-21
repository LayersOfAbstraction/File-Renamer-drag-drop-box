using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragDropForm
{
    public partial class Form1 : Form
    {
        static string[] _dropppedFiles;
        string _strSourcePath;
        string _strTargetPath;
        string _strfileName = string.Empty;
        string _strDestFile = string.Empty;

        public Form1()
        {
            InitializeComponent();
            readLabelMsg();
        }


        private void readLabelMsg()
        {
            label2.Text = "1. Please click and drag files into big drag drop box below." +
            "\n2. Type your folder path into the text box next to convert button." +
            "\n3. Press button to convert files in the big drag drop box.";
        }

        private string getFileName( string path)
        {
            return Path.GetFileName(path);
        }

        private string getDirectoryName(string path)
        {
            return Path.GetDirectoryName(path);
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            //TAKE dropped items and store in array.
            _dropppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);

            //LOOP through all droppped items and display them
            foreach (string file in _dropppedFiles)
            {
                lstDragDrop.Items.Add(file);
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            _strTargetPath = txtFolderPath.Text;
            RenameFile(_strTargetPath);
        }

        public void RenameFile(string targetDirectory)
        {
            //Get file regardless of specific extension.
            foreach(string file in _dropppedFiles)
            {
                if (!lstDragDrop.Items.Contains(_dropppedFiles.Length))
                {
                    //GET file extension.
                    var extension = Path.GetExtension(file);
                    _strfileName = File.GetCreationTime(file).ToString("yyyy'-'MM'-'dd hh'\u0589'mm'\u0589'ss tt", CultureInfo.InvariantCulture);
                    _strfileName += extension;
                    _strSourcePath = getDirectoryName(file);                  
                    //GET Creation Date and time from file.                                        
                    _strDestFile = Path.Combine(targetDirectory, _strfileName);
                    //Copy file with extension to output directory.
                    File.Copy(file, _strDestFile, true);
                }

                else
                {
                    Debug.WriteLine("Source path does not exist!");
                }
            }
        }
    }
}
