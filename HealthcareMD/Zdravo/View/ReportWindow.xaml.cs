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
using HealthcareMD.ViewModel;

namespace HealthcareMD.DoctorWindows
{
    /// <summary>
    /// Interaction logic for AppointmentReport.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        private ReportViewModel viewModel;
        private int operation;
        public DataGrid table;
        private PatientChartViewModel callerWindow;
        public ReportWindow(int appointmentId,int reportId, int operation, PatientChartViewModel callerWindow)
        { 
            InitializeComponent();
            this.operation = operation;
            this.callerWindow = callerWindow;
            if(reportId==0)
            {
                date_tb.IsReadOnly = true;
            }
            viewModel = new ReportViewModel(appointmentId,reportId);
            DataContext = viewModel;
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
                viewModel.AcceptClick(operation);
                if (callerWindow != null) callerWindow.RefreshTables();
                this.Close();
        }
    }
}
