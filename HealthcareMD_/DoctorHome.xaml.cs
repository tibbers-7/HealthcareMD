using System;
using System.Windows;
using System.Windows.Controls;
using HealthcareMD_.ViewModel;
using System.Windows.Threading;
using Model;
using System.Windows.Media;

namespace HealthcareMD_
{
    public partial class DoctorHome : Window
    {

        private DoctorHomeViewModel viewModel;
        private int doctorId;
        

        public DoctorHome(int doctorId)
        {
            this.doctorId = doctorId;
            viewModel = new DoctorHomeViewModel(this,doctorId);
            DataContext = viewModel;
            InitializeComponent();

        }



        public void UpcomingRow_DoubleClick(object sender, RoutedEventArgs e)
        {
            object item = UpcomingTable.SelectedItem;
            viewModel.AppointmentShow(int.Parse((UpcomingTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
        }

        public void PassedRow_DoubleClick(object sender, RoutedEventArgs e)
        {
            object item = PassedTable.SelectedItem;
            viewModel.AppointmentShow(int.Parse((PassedTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
        }

        public void PassedGotFocus(object sender, RoutedEventArgs e)
        {
            UpcomingTable.SelectedItem = null;
            PatientTable.SelectedItem = null;
            DrugsTable.SelectedItem = null;
            VacationTable.SelectedItem = null;
            TodaysApptsList.SelectedItem = null;
            VacationsList.SelectedItem = null;
        }

        public void UpcomingGotFocus(object sender, RoutedEventArgs e)
        {
            PassedTable.SelectedItem = null;
            PatientTable.SelectedItem = null;
            DrugsTable.SelectedItem = null;
            VacationTable.SelectedItem = null;
            TodaysApptsList.SelectedItem = null;
            VacationsList.SelectedItem = null;
        }

        public void PatientsGotFocus(object sender, RoutedEventArgs e)
        {
            PassedTable.SelectedItem = null;
            UpcomingTable.SelectedItem = null;
            DrugsTable.SelectedItem = null;
            VacationTable.SelectedItem = null;
            TodaysApptsList.SelectedItem = null;
            VacationsList.SelectedItem = null;
        }
        public void DrugsGotFocus(object sender, RoutedEventArgs e)
        {
            PassedTable.SelectedItem = null;
            PatientTable.SelectedItem = null;
            UpcomingTable.SelectedItem = null;
            VacationTable.SelectedItem = null;
            TodaysApptsList.SelectedItem = null;
            VacationsList.SelectedItem = null;
        }
        public void VacationsGotFocus(object sender, RoutedEventArgs e)
        {
            PassedTable.SelectedItem = null;
            PatientTable.SelectedItem = null;
            DrugsTable.SelectedItem = null;
            UpcomingTable.SelectedItem = null;
            TodaysApptsList.SelectedItem = null;
            VacationsList.SelectedItem = null;
        }
        public void VacationsListGotFocus(object sender, RoutedEventArgs e)
        {
            PassedTable.SelectedItem = null;
            PatientTable.SelectedItem = null;
            DrugsTable.SelectedItem = null;
            UpcomingTable.SelectedItem = null;
            VacationTable.SelectedItem = null;
            TodaysApptsList.SelectedItem = null;
            viewModel.selectedAppt = null;
        }
        public void TodaysApptsGotFocus(object sender, RoutedEventArgs e)
        {
            PassedTable.SelectedItem = null;
            PatientTable.SelectedItem = null;
            DrugsTable.SelectedItem = null;
            UpcomingTable.SelectedItem = null;
            VacationTable.SelectedItem = null;
            VacationsList.SelectedItem=null;
            viewModel.selectedVacation = null;
        }
        public void PatientRow_DoubleClick(object sender, RoutedEventArgs e)
        {
            object item = PatientTable.SelectedItem;
            viewModel.PatientShow(int.Parse((PatientTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
        }
        public void DrugRow_DoubleClick(object sender, RoutedEventArgs e)
        {
            object item = DrugsTable.SelectedItem;
            viewModel.DrugShow(int.Parse((DrugsTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
        }

        public void VacationRow_DoubleClick(object sender, RoutedEventArgs e)
        {
            object item = VacationTable.SelectedItem;
            viewModel.VacationShow(int.Parse((VacationTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
        }
        public void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            
           this.Close();
            
        }

        public void Referral_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ShowReferral();
        }

        public void VacationButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ScheduleVacation();
            

        }

        public void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.RefreshAppointments();
        }


        public void NewAppointment_Click(object sender, RoutedEventArgs e)
        {
            viewModel.NewAppointment();
            Plot.InvalidatePlot(true);
        }

        public void TodaysAppts_DoubleClick(object sender, RoutedEventArgs e)
        {
            ListViewItem item = sender as ListViewItem;
            Appointment appointment = (Appointment)item.Content;
            viewModel.AppointmentShow(appointment.Id);
        }

        public void Vacations_DoubleClick(object sender, RoutedEventArgs e)
        {
            ListViewItem item = sender as ListViewItem;
            VacationString vacation = (VacationString)item.Content;
            viewModel.VacationShow(vacation.Id);
            
        }


        public void Update_Click(object sender, RoutedEventArgs e)
        {
            viewModel.UpdateAppointment();
        }

        public void Report_Click(object sender, RoutedEventArgs e)
        {
            object item = PassedTable.SelectedItem;
            if (item!=null)
            {
                int id = int.Parse((PassedTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                viewModel.ReportShow(id);
            }
            else MessageBox.Show("Niste odabrali pregled!");
        }

        public void Prescription_Click(object sender, RoutedEventArgs e)
        {
            viewModel.PrescriptionShow();
        }

        public void RejectDrug_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ReportDrug();
            
        }

        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            viewModel.DeleteAppt();
        }

        private void PatientReportClick(object sender, RoutedEventArgs e)
        {
            viewModel.PatientReportForm();
        }
    }
}
