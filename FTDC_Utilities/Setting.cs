using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using CsvFile;
using System.Diagnostics;

namespace FTDC_Utilities
{

    public class Setting
    {
        #region Variables

       
        DataTable _dt = null;
        DataColumn _dclColumnDescription = new DataColumn("Description", typeof(string));
        DataColumn _dclColumnData = new DataColumn("Data", typeof(string));

        #endregion

        #region Constructor

        public Setting(DataTable dt)
        {
            _dt = dt;
        }

        #endregion

        #region Mutator Methods

       
        public DataTable ProcessSettingFileCMD(string filePath)
        {
            //READ            
            if (_dt.Rows.Count <= 0)
            {
                ReadFile(filePath);
            }


            //WRITE
            else if (_dt.Rows.Count > 0)
            {
                WriteToCsvFile(filePath);
                //WriteFile(filePath);
            }
            
            return _dt;
        }
        #endregion

        #region CRUD Methods
        
        /// <summary>
        /// Only the csvFileReader class is being used in this method.
        /// </summary>
        /// <param name="filePath">Get's passed into our </param>
        private void ReadFile(string filePath)
        {
            _dt = new DataTable();
            List<string> columns = new List<string>();

            using (var reader = new CsvFileReader(filePath))
            {
                _dt.Columns.Add(_dclColumnDescription);
                _dt.Columns.Add(_dclColumnData);
                while (reader.ReadRow(columns))
                {
                    _dt.Rows.Add(columns.ToArray());
                }
            }
        }

        /// <summary>
        /// This method handles the Create, Update. Deleting is left to the
        /// end user. They just have to use the Windows file system.
        /// 
        /// Lowly coupled and highly cohesive!
        /// </summary>
        /// <param name="dt">get's passed to our public mutator fuction ProcessSettingFileCMD</param>
        /// <param name="filePath"></param>
        private void WriteToCsvFile(string filePath)
        {
            StringBuilder fileContent = new StringBuilder();
                        
            foreach (var col in _dt.Columns)
                //
                fileContent.Append(col.ToString() + ",");
            fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);

            foreach (DataRow dr in _dt.Rows)
            {
                foreach (var column in dr.ItemArray)
                    fileContent.Append("\"" + column.ToString() + "\",");

                fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
            }

            System.IO.File.WriteAllText(filePath, fileContent.ToString());

        }
        #endregion
    }
}