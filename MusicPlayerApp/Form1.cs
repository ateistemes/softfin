using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayerApp
{
    public partial class MusicPlayerApp : Form
    {
        public MusicPlayerApp()
        {
            InitializeComponent();
        }

        //Create Global Variables of String Type Array to save the titles or name of the Tracks and path of the track
        String[] paths, files;
        List<String> pathList = new List<string>();

        private void btnSelectSongs_Click(object sender, EventArgs e)
        {
            //Code to SElect Songs
            OpenFileDialog ofd = new OpenFileDialog();
            //Code to select multiple files
            ofd.Multiselect = true;
            if(ofd.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                files = ofd.SafeFileNames; //Save the names of the track in files array
                paths = ofd.FileNames; //Save the paths of the tracks in path array
                pathList.Add(ofd.FileName);
                //Display the music titles in listbox
                for (int i = 0; i < files.Length; i++)
                {
                    listBoxSongs.Items.Add(files[i]); //Display Songs in Listbox
                    //pathList.Add(files[i]);
                }
            }
        }

        private void listBoxSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if paths array is not null and contains elements
            
            if (paths != null && paths.Length > 0)
            {
                // Check if the selected index is within the valid range
                int ind = listBoxSongs.SelectedIndex;
                if (ind >= 0 && ind < pathList.Count)
                {
                    // Play the selected music
                    
                    axWindowsMediaPlayerMusic.URL = pathList[ind];
                    
                }
                else
                {
                    MessageBox.Show("Invalid selected index.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No songs available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Code to Close the App
            this.Close();
        }
    }
}
