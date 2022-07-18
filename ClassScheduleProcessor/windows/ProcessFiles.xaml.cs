using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using ClassScheduleProcessor.structure.functional;

namespace ClassScheduleProcessor.windows
{
    /// <summary>
    /// Interaction logic for ProcessFiles.xaml
    /// </summary>
    public partial class ProcessFiles : Window
    {
        private string FileName;
        public bool IsWindowClosed;
        private FileProcessor classScheduleFileProcessor;
        public ProcessFiles()
        {
            InitializeComponent();

            // Initialize instance variables
            this.IsWindowClosed = false;
            this.FileName = "";
            this.classScheduleFileProcessor = new FileProcessor();
        }

        protected override void OnClosed(EventArgs e)
        {
            // Call parent class method
            base.OnClosed(e);

            // Update boolean
            this.IsWindowClosed = true;
        }

        private void FileLocation_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Update the file location based on the input and make the process button visible
            this.FileName = FileLocation_Textbox.Text;
            Process_Button.Visibility = Visibility.Visible;
        }

        private void Browse_Button_Click(object sender, RoutedEventArgs e)
        {
            // Restrict the visibility of process button, just in case
            Process_Button.Visibility = Visibility.Hidden;

            // Windows OS standard open file dialog box processing
            OpenFileDialog openDialogBox = new OpenFileDialog();
            if (openDialogBox.ShowDialog() == true) // Result could be true, false, or null
            {
                this.FileName = openDialogBox.FileName;
            }

            // Update the display and visibility of process button
            FileLocation_Textbox.Text = this.FileName;
            Process_Button.Visibility = Visibility.Visible;
        }

        private void Process_Button_Click(object sender, RoutedEventArgs e)
        {
            // If file name entered is not a file in the local machine, throw the error message
            if (!File.Exists(this.FileName))
            {
                MessageBox.Show("Input file is not a valid file in local machine. Please select a valid file from local machine.", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                FileLocation_Textbox.Text = "";
                return;
            }

            // If file is not txt file, throw the error message
            if (System.IO.Path.GetExtension(this.FileName) != ".txt")
            {
                MessageBox.Show("Input file is not 'txt' file to process. Please select a valid class schedule 'txt' file from local machine.", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                FileLocation_Textbox.Text = "";
                return;
            }

            // Read the text line in the txt file and process them
            try
            {
                // Update cursor to wait
                Process_Button.Cursor = Cursors.Wait;

                // Read the txt file and process the data records
                string[] dataRecords = File.ReadAllLines(this.FileName);
                foreach (string dataRecord in dataRecords)
                {
                    if (dataRecord.Trim() != "")
                    {
                        classScheduleFileProcessor.processAndUploadRecord(dataRecord);
                    }
                }

                // Update the cursor and display appropriate message
                Process_Button.Cursor = Cursors.Arrow;
                MessageBox.Show("Data records are successfully processed!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Reset the UI controls, once all the data is processed
                FileLocation_Textbox.Text = "";
                Process_Button.Visibility = Visibility.Hidden;

                // Close the current window
                this.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Issue with the input txt file. Please check if you have entered a valid class schedule file.", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                FileLocation_Textbox.Text = "";
                return;
            }
        }
    }
}
