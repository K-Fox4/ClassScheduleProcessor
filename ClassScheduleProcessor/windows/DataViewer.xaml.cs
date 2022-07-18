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
using ClassScheduleProcessor.structure.constants;
using ClassScheduleProcessor.structure.functional;

namespace ClassScheduleProcessor.windows
{
    /// <summary>
    /// Interaction logic for DataViewer.xaml
    /// </summary>
    public partial class DataViewer : Window
    {
        public bool IsWindowClosed;
        private DataRecord dataRecordWindow;

        private List<string> yearList;
        private List<string> semesterList;
        private List<string> courseList;
        private List<string> majorList;
        private List<CS_DBDataSet.Class_Schedules_RecordsRow> recordsList;

        private Option yearSelected;
        private Option semesterSelected;
        private Option courseSelected;
        private Option majorSelected;
        private CS_DBDataSet.Class_Schedules_RecordsRow recordSelected = null;

        // Constant values
        private string classScheduleRecordsTName = "Class_Schedules_Records";
        private string yearCName = "Semester_Year";
        private string semesterCName = "Semester";
        private string courseNumberCName = "Course_number";
        private string majorCName = "Subject_prefix";
        public DataViewer()
        {
            InitializeComponent();

            // Initialize instance variables
            this.IsWindowClosed = false;
            this.yearSelected = new Option(String.Empty);
            this.semesterSelected = new Option(String.Empty);
            this.courseSelected = new Option(String.Empty);
            this.majorSelected = new Option(String.Empty);
        }

        protected override void OnClosed(EventArgs e)
        {
            // Call parent class method
            base.OnClosed(e);

            // Update boolean
            this.IsWindowClosed = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Load the filter options
            this.yearList = DBWorker.getUniqueColumnData(this.yearCName, this.classScheduleRecordsTName);
            this.semesterList = DBWorker.getUniqueColumnData(this.semesterCName, this.classScheduleRecordsTName);
            this.courseList = DBWorker.getUniqueColumnData(this.courseNumberCName, this.classScheduleRecordsTName);
            this.majorList = DBWorker.getUniqueColumnData(this.majorCName, this.classScheduleRecordsTName);

            // Display filters
            Year_Combobox.ItemsSource = this.yearList;
            Semester_Combobox.ItemsSource = this.semesterList;
            Course_Combobox.ItemsSource = this.courseList;
            Major_Combobox.ItemsSource = this.majorList;
        }

        private void Year_Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Set the filter value
            this.yearSelected.value = (string)Year_Combobox.SelectedItem;
            this.yearSelected.isSelected = true;
        }

        private void Semester_Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Set the filter value
            this.semesterSelected.value = (string)Semester_Combobox.SelectedItem;
            this.semesterSelected.isSelected = true;
        }

        private void Major_Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Set the filter value
            this.majorSelected.value = (string)Major_Combobox.SelectedItem;
            this.majorSelected.isSelected = true;
        }

        private void Course_Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Set the filter value
            this.courseSelected.value = (string)Course_Combobox.SelectedItem;
            this.courseSelected.isSelected = true;
        }

        private void Fetch_Records_Button_Click(object sender, RoutedEventArgs e)
        {
            // Get the data records from DB
            this.recordsList = DBWorker.fetchCSRecords(this.classScheduleRecordsTName, this.yearSelected, this.semesterSelected, this.majorSelected, this.courseSelected);
            
            // Display it on the screen
            class_Schedules_RecordsDataGrid.ItemsSource = this.recordsList;
        }

        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            // Reset all fields
            Year_Combobox.SelectedItem = null;
            Semester_Combobox.SelectedItem = null;
            Major_Combobox.SelectedItem = null;
            Course_Combobox.SelectedItem = null;
            class_Schedules_RecordsDataGrid.ItemsSource = new List<CS_DBDataSet.Class_Schedules_RecordsRow>();

            this.yearSelected = new Option(String.Empty);
            this.semesterSelected = new Option(String.Empty);
            this.courseSelected = new Option(String.Empty);
            this.majorSelected = new Option(String.Empty);
            this.recordSelected = null;
        }

        private void class_Schedules_RecordsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Save the selected record
            this.recordSelected = (CS_DBDataSet.Class_Schedules_RecordsRow)class_Schedules_RecordsDataGrid.SelectedItem;
        }

        private void View_Record_Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.recordSelected == null)
            {
                MessageBox.Show("No data record is selected !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            this.dataRecordWindow = new DataRecord(this.recordSelected);
            this.dataRecordWindow.Show();
        }
    }
}
