using Bingo.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Bingo
{
    public partial class Setup_Automatic_Winner_Checking : Form
    {
        public Setup_Automatic_Winner_Checking()
        {
            InitializeComponent();
        }
        private void Setup_Automatic_Winner_Checking_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.automaticWinnerCheckCSVFilePath != "")
            {
                inputFileNameLabel.Text = Properties.Settings.Default.automaticWinnerCheckCSVFilePath;
            }
        }
        private void selectInputCSVButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "csv files (*.csv)|*.csv";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Properties.Settings.Default.automaticWinnerCheckCSVFilePath = openFileDialog1.FileName;
            if (Path.GetExtension(Properties.Settings.Default.automaticWinnerCheckCSVFilePath) != ".csv")
            {
                MessageBox.Show("Incorrect file type selected. Program only supports writing to .csv files");
                Properties.Settings.Default.automaticWinnerCheckCSVFilePath = "";
            }

            string[] lines = null;
            try
            {
                lines = File.ReadAllLines(Properties.Settings.Default.automaticWinnerCheckCSVFilePath);
            }
            catch
            {
                MessageBox.Show("Something went wrong with selected csv file in settings for automatic game checking. A new or different file will need to be selected for automatic winner checikng.", "Error?");
            }

            if (Properties.Settings.Default.automaticWinnerCheckCSVFilePath == "")
            {
                inputFileNameLabel.Text = "No File Selected";
                return;
            }
            inputFileNameLabel.Text = Properties.Settings.Default.automaticWinnerCheckCSVFilePath;
            Properties.Settings.Default.Save();
        }

    }
}
