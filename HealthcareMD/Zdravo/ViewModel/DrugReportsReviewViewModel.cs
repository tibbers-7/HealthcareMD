using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HealthcareMD.Controller;
using HealthcareMD.Model;


namespace HealthcareMD.ViewModel
{
    public class DrugReportsReviewViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<DrugReport> reports;
        private DrugController drugController;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<DrugReport> Reports
        {
            get
            {
                return reports;
            }
            set
            {
                if (reports == value)
                    return;
                reports = new ObservableCollection<DrugReport>(drugController.GetAllReports());
                NotifyPropertyChanged("Reports");
            }
        }
        public DrugReportsReviewViewModel() {
            var app = Application.Current as App;
            drugController = app.drugController;
            this.reports = new ObservableCollection<DrugReport>(drugController.GetAllReports());
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
