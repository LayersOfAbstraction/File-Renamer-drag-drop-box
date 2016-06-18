using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private string getFileName(string path)
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
            string[] dropppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);

            //LOOP through all droppped items and display them
            foreach (string file in dropppedFiles)
            {
                string filename = getFileName(file);
                MessageBox.Show("You dropped " + filename);
                listBox1.Items.Add(filename);
                FileInfo fi = new FileInfo(filename);
                {
                    if (!File.Exists("NewName"))
                    {
                        getDirectoryName(file);
                        fi.MoveTo("NewName");
                        //File.Move(filename, getDirectoryName(file));
                    }
                }
            }

        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        
    }
}
