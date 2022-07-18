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

namespace ClassScheduleProcessor.windows
{
    /// <summary>
    /// Interaction logic for DataRecord.xaml
    /// </summary>
    public partial class DataRecord : Window
    {
        private CS_DBDataSet.Class_Schedules_RecordsRow record;
        private Enrollment enrollment;
        private double courseFunding = 0;

        private double ratePerWsch = 53.17; // This is the amount from the THECB recommendations

        /*
         
        Weight factors as found in the 2022-23 Appropriations Bill

         float multipliers_2022[22][5] = 
	    {
		    { 1.00, 1.80, 4.60, 13.79, -1.0 }, 
            { 1.44, 2.78, 7.70, 22.58, -1.0 },
		    { 1.43, 2.73, 7.22, 9.37, -1.0 }, 
            { 1.42, 1.92, 2.40, 8.67, -1.0 },
		    { 1.74, 2.35, 8.09, 14.72, -1.0 }, 
            { 1.88, 2.91, 6.73, 19.43, -1.0 },
		    { 1.09, 1.83, 3.40, 11.93, -1.0 }, 
            { -1.0, -1.0, -1.0, -1.0, 5.29 },
		    { 1.61, 1.89, 2.35, 26.37, -1.0 }, 
            { 2.37, 1.84, 3.17, 14.47, -1.0 },
		    { -1.0, -1.0, -1.0, -1.0, -1.0 },
		    { 1.33, 3.23, -1.0, -1.0, -1.0 }, 
            { 1.49, 1.47, -1.0, -1.0, -1.0 },
		    { 0.94, 1.58, 2.70, 12.15, 3.08 }, 
            { 6.44, 4.05, 42.85, 43.58, 4.63 },
		    { 1.12, 1.81, 3.40, 32.95, -1.0 }, 
            { -1.0, -1.0, -1.0, -1.0, 6.65 },
		    { 2.11, 2.28, -1.0, -1.0, -1.0 }, 
            { 1.88, 2.36, 4.34, 12.45, -1.0 },
		    { 1.29, 2.04, 2.66, 10.72, -1.0 }, 
            { 1.0, -1.0, -1.0, -1.0, -1.0 },
		    { -1.0, -1.0, -1.0, -1.0, 23.76 }
	    };

        And category is constant, which is 5.

        So, I'm avoiding the usage of unnecessary 2D array
        and saving the multiplier to constant variable directly.
        */
        private double multipliers = 1.88;

        public DataRecord(CS_DBDataSet.Class_Schedules_RecordsRow record)
        {
            InitializeComponent();

            // Initialize instance variables
            this.record = record;

            // Fill the fields
            this.fillDirectDataFields();
            this.fillEnrollmentFields();
            this.fillFundingField();
        }

        private void fillDirectDataFields()
        {
            // Fill available data
            Major_Tbox.Text = this.record.Subject_prefix;
            Course_Tbox.Text = this.record.Course_number;
            CRN_Tbox.Text = this.record.Section_number;
            Credit_Hours_Tbox.Text = Convert.ToString(this.record.Credit_Hours);
            Year_Tbox.Text = this.record.Semester_Year;
            Semester_Tbox.Text = this.record.Semester;
            T_Instruction_Tbox.Text = this.record.Type_of_Instruction;
            M_Instruction_Tbox.Text = this.record.Instruction_mode;
        }

        private void fillEnrollmentFields()
        {
            // Map to enrollment sub fields using Enrollment class
            this.enrollment = new Enrollment(this.record.Enrollment);

            // Fill enrollment sub fields
            LD_Tbox.Text = Convert.ToString(this.enrollment.ld);
            UD_Tbox.Text = Convert.ToString(this.enrollment.ud);
            Master_Tbox.Text = Convert.ToString(this.enrollment.master);
            Doctor_R_Tbox.Text = Convert.ToString(this.enrollment.doctorRS);
            Doctor_P_Tbox.Text = Convert.ToString(this.enrollment.doctorPP);
        }

        private void fillFundingField()
        {
            // Calculate funding
            if (this.enrollment.ld > 0)
            {
                this.courseFunding += this.enrollment.ld * this.record.Credit_Hours * this.ratePerWsch * this.multipliers;
            }

            if (this.enrollment.ud > 0)
            {
                this.courseFunding += this.enrollment.ud * this.record.Credit_Hours * this.ratePerWsch * this.multipliers;
            }

            if (this.enrollment.master > 0)
            {
                this.courseFunding += this.enrollment.master * this.record.Credit_Hours * this.ratePerWsch * this.multipliers;
            }

            if (this.enrollment.doctorRS > 0)
            {
                this.courseFunding += this.enrollment.doctorRS * this.record.Credit_Hours * this.ratePerWsch * this.multipliers;
            }

            if (this.enrollment.doctorPP > 0)
            {
                this.courseFunding += this.enrollment.doctorPP * this.record.Credit_Hours * this.ratePerWsch * this.multipliers;
            }

            this.courseFunding = Math.Round(this.courseFunding, 2);

            // Fill the field
            Funding_Tbox.Text = String.Format("$ {0}", Convert.ToString(this.courseFunding));
        }

        // All the below methods are implemented to avoid build errors

        private void Major_Tbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Do nothing
        }

        private void Subject_Tbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Do nothing
        }

        private void CRN_Tbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Do nothing
        }

        private void Credit_Hours_Tbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Do nothing
        }

        private void Year_Tbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Do nothing
        }

        private void Semester_Tbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Do nothing
        }

        private void T_Instruction_Tbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Do nothing
        }

        private void M_Instruction_Tbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Do nothing
        }

        private void LD_Tbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Do nothing
        }

        private void UD_Tbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Do nothing
        }

        private void Master_Tbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Do nothing
        }

        private void Doctor_R_Tbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Do nothing
        }

        private void Doctor_P_Tbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Do nothing
        }

        private void Funding_Tbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Do nothing
        }
    }
}
