using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareMD.Controller;
using System.Windows;
using System.Windows.Controls;
using HealthcareMD.DoctorView;

namespace HealthcareMD.ViewModel
{
    internal class DrugViewModel
    {
        private int drugId;
        private string name;
        public string Name { get { return name; } set { name = value; } }
        private string type;
        public string Type { get { return type; } set { type = value; } }
        private string status;
        public string Status { get { return status; } set { status = value; } }
        private string description;
        public string Description { get { return description; } set { description = value; } }
        private ObservableCollection<string> ingredients;
        public ObservableCollection<string> Ingredients { get { return ingredients; } set { ingredients = value; } }


        private DrugController drugController;
        private DoctorHomeViewModel callerWindow;

        public DrugViewModel(DoctorHomeViewModel callerWindow,int drugId)
        {
            this.drugId = drugId;
            this.callerWindow=callerWindow;
            var app = Application.Current as App;
            drugController = app.drugController;
            Drug drug = drugController.GetById(drugId);
            ingredients = new ObservableCollection<string>(drug.Ingredients);
            name=drug.Name.ToUpper();
            type=drug.Type;
            status = drug.StatusString;
            description = drug.Description;
        
        }
        

    }
}
