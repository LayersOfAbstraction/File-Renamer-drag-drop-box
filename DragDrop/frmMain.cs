using FTDC_Utilities;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmMain : Form
    {
        #region Declarations
        string[] _dropppedFiles;
        string _strSourcePath;
        string _strTargetPath;
        string _strfileName = string.Empty;
        string _strDestFile = string.Empty;
        public static DataTable _dt;
        frmSettings _objFrmSettings = new frmSettings();

        #endregion

        #region Initializers
        public frmMain()
        {
            InitializeComponent();
            readLabelMsg();            
        }

        private void readLabelMsg()
        {
            label2.Text = 
            "1. Please click and drag files into big drag drop box below." +
            "\n" +
            "\n2. After files have been dragged into box click " +
            "\n 'New Setting' (optional)." +
            "\n" +
            "\n3. Type your folder path into the text box next to convert button." +
            "\n" +
            "\n4. Press button to rename files in the big drag drop box.";
        }     
        #endregion

        #region Form actions
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
        #endregion

        #region Button Actions


        private void btnConvert_Click(object sender, EventArgs e)
        {           
            _strTargetPath = txtFolderPath.Text;
            FileAttributes attr;
            foreach(string FileOrDirectory in _dropppedFiles)
            {
                attr = File.GetAttributes(FileOrDirectory);
                if ((attr & FileAttributes.Directory) != FileAttributes.Directory)
                    RenameFile(_strTargetPath);

                else
                    RenameFolder(_strTargetPath);
            }                     
        }        

        private void btnSetting_Click(object sender, EventArgs e)
        {
                _objFrmSettings.ShowDialog();            
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Methods

        private string getFileName(string path)
        {
            return Path.GetFileName(path);
        }

        private string getDirectoryName(string path)
        {
            return Path.GetDirectoryName(path);
        }

        private void RenameFile(string targetDirectory)
        {
            //Get file regardless of specific extension.
            foreach (string file in _dropppedFiles)
            {
                if (!lstDragDrop.Items.Contains(_dropppedFiles.Length))
                {
                    //GET file extension.
                    var extension = Path.GetExtension(file);
                    //GET Creation Date and time from file.
                    _strfileName = ReadSecondDataColumn()
                        + GetExplorerFileDate(file).ToString("yyyy'-'MM'-'dd hh'\u0589'mm'\u0589'ss tt", CultureInfo.InvariantCulture);
                    _strfileName += extension;
                    _strSourcePath = getDirectoryName(file);
                                                            
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

        static DateTime GetExplorerFileDate(string filename)
        {
            DateTime now = DateTime.Now;
            TimeSpan localOffset = now - now.ToUniversalTime();
            return File.GetLastWriteTimeUtc(filename) + localOffset;
        }

        public void RenameFolder(string targetDirectory)
        {
            //Get file regardless of specific extension.
            foreach (string file in _dropppedFiles)
            {
                if (!lstDragDrop.Items.Contains(_dropppedFiles.Length))
                {
                    //BUG! Can't read the second column.
                    _strfileName = ReadSecondDataColumn();
                    _strSourcePath = getDirectoryName(file);
                    //GET Creation Date and time from file.                                        
                    _strDestFile = Path.Combine(targetDirectory, _strfileName);
                    //Copy file with extension to output directory.
                    Directory.Move(file, _strDestFile);
                    Thread.Sleep(1000); // give the file creation a chance to release any lock
                    MessageBox.Show("Success");
                }
                else
                {
                    Debug.WriteLine("Source path does not exist!");
                }
            }
        }

        public string ReadSecondDataColumn()
        {
            string currentCellValue = string.Empty;
            foreach (DataRow dr in _dt.Rows)
            {
                currentCellValue += dr[1].ToString() + "_";
            }
            return currentCellValue;
        }

        private void Populate_grid_View_with_dummy_data()
        {
            _dt.Columns.Add("Description", typeof(string));
            _dt.Columns.Add("Data", typeof(string));
            string[] row0 = { "Address", "76 Douglas St Wakecorn" };
            string[] row1 = { "Property name", "Wakecorn University" };
            string[] row2 = { "Building", "C Block" };
            string[] row3 = { "Room", "C2.18" };

            _dt.Rows.Add(row0);
            _dt.Rows.Add(row1);
            _dt.Rows.Add(row2);
            _dt.Rows.Add(row3);
        }
        #endregion


    }
}
