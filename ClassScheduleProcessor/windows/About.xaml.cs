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

namespace ClassScheduleProcessor.windows
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public bool IsWindowClosed;
        public About()
        {
            InitializeComponent();

            // Initialize instance variables
            this.IsWindowClosed = false;
        }

        protected override void OnClosed(EventArgs e)
        {
            // Call parent class method
            base.OnClosed(e);

            // Update boolean
            this.IsWindowClosed = true;
        }

        private void About_Content_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Not needed, as this field is Read-Only
        }
    }
}
