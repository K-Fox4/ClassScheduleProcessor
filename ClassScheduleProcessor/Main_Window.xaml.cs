using System;
using System.Collections.Generic;
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
using ClassScheduleProcessor.windows;

namespace ClassScheduleProcessor
{
    /// <summary>
    /// Interaction logic for Main_Window.xaml
    /// </summary>
    public partial class Main_Window : Window
    {
        private bool IsAboutOpen;
        private About aboutWindow;
        private bool IsProcessFilesOpen;
        private ProcessFiles processFilesWindow;
        private bool IsDataViewerOpen;
        private DataViewer dataViewerWindow;
        public Main_Window()
        {
            InitializeComponent();

            // Initialize instance variables
            this.IsAboutOpen = false;
            this.aboutWindow = new About();
            this.IsProcessFilesOpen = false;
            this.processFilesWindow = new ProcessFiles();
            this.IsDataViewerOpen = false;
            this.dataViewerWindow = new DataViewer();
        }

        protected override void OnClosed(EventArgs e)
        {
            // Call parent class method
            base.OnClosed(e);

            // Shutdown app to close all windows
            Application.Current.Shutdown();
        }

        private void About_Button_Click(object sender, RoutedEventArgs e)
        {
            // If About window is closed, create instance of it for displaying
            if (this.aboutWindow.IsWindowClosed)
            {
                this.IsAboutOpen = false;
                this.aboutWindow = new About();
            }

            // If About window is not open at all, just display it
            if (!this.IsAboutOpen)
            {
                this.aboutWindow.Show();
                this.IsAboutOpen = true;
            }
        }

        private void ProcessScheduleFiles_Buton_Click(object sender, RoutedEventArgs e)
        {
            // If Process Schedule Files window is closed, create instance of it for displaying
            if (this.processFilesWindow.IsWindowClosed)
            {
                this.IsProcessFilesOpen = false;
                this.processFilesWindow = new ProcessFiles();
            }

            // If Process Schedule Files window is not open at all, just display it
            if (!this.IsProcessFilesOpen)
            {
                this.processFilesWindow.Show();
                this.IsProcessFilesOpen = true;
            }
        }

        private void ViewScheduleData_Button_Click(object sender, RoutedEventArgs e)
        {
            // If Data Viewer window is closed, create instance of it for displaying
            if (this.dataViewerWindow.IsWindowClosed)
            {
                this.IsDataViewerOpen = false;
                this.dataViewerWindow = new DataViewer();
            }

            // If Data Viewer window is not open at all, just display it
            if (!this.IsDataViewerOpen)
            {
                this.dataViewerWindow.Show();
                this.IsDataViewerOpen = true;
            }
        }
    }
}
