using FTDC_Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmSettings : Form
    {
        #region Declarations

        protected string FileName;
        protected bool Modified;
        DataTable _dt = new DataTable();
        Setting _objSetting = null;
        OpenFileDialog openFD = new OpenFileDialog();
        SaveFileDialog saveFD = new SaveFileDialog();        
        
        #endregion

        #region Initializers
        public frmSettings()
        {            
            InitializeComponent();
            lblMessage.Text = "Please create or open a setting file. Opening a setting file will \n" +
                              "display it's data in the grid. \n" +
                              "\n" +
                              "Or you can type out the values in the grid below and create one \n" +
                              "and save it for reuse later. \n" +
                              "\n" +
                              "Use the 'Description' column to describe anything in the \n" +
                              "'Data' column as which will get written to the filename \n" +
                              "even after you have closed this window until \n" +
                              "you either display a new file or close this program.";
            _objSetting = new Setting(_dt);
            gvSettings.DataSource = _dt;
            //Populate_grid_View_with_dummy_data();            
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

        private void gvSettings_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Modified = true;
        }

        #endregion

        #region Buttons

        private void mnuQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (SaveIfModified())
                frmMain._dt = _dt;
                Close();
        }
        #endregion Buttons

        #region File menu strip actions
        private void mmuSaveAs_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            saveFD.FileName = FileName;

            try
            {                
                saveFD.Title = "Save a CSV File as desired.";
                saveFD.Filter = "CSV|*.csv";
                saveFD.FileName = "default";
                txtFilePath.Text = openFD.FileName;
                
                if (saveFD.ShowDialog(this) == DialogResult.OK)
                    _dt = _objSetting.ProcessSettingFileCMD(saveFD.FileName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(String.Format("Error writing to {0}.\r\n\r\n{1}", FileName, ex.Message));
            }

            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private bool SaveIfModified()
        {
            if (!Modified)
            {
                return true;
            }

            DialogResult result = MessageBox.Show("The current file or text in the grid has changed. Save changes to file?", "Save Changes", MessageBoxButtons.YesNoCancel);
            if(result == DialogResult.Yes)
            {
                if(FileName != null)
                {
                    _objSetting.ProcessSettingFileCMD(FileName);
                }
            }
            //TO DO: implment other code when writing data table to csv.
            return false;
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                _dt.Clear();
                openFD.Title = "Open a CSV File";
                openFD.Filter = "CSV|*.csv";
                if (SaveIfModified())
                {
                    if (openFD.ShowDialog(this) == DialogResult.OK)
                    {
                        txtFilePath.Text = openFD.FileName;

                        _dt = _objSetting.ProcessSettingFileCMD(openFD.FileName);
                        if (_dt.Rows.Count > 0)
                        {
                            gvSettings.DataSource = _dt;
                        }
                    }
                }
                FileName = openFD.FileName;
                Modified = false;
                lblMessage.Text = "";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(String.Format("Error reading from {0}.\r\n\r\n{1}", FileName, ex.Message));
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion
    }
}
