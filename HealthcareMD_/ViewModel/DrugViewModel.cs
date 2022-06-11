using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareMD_.Controller;
using System.Windows;
using System.Windows.Controls;
using HealthcareMD_.DoctorView;
using Tools;

namespace HealthcareMD_.ViewModel
{
    internal class DrugViewModel : BindableBase
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

        public MyICommand CloseCommand { get; set; }

        private DrugController drugController;
        private DrugWindow callerWindow;

        public DrugViewModel(DrugWindow callerWindow,int drugId)
        {
            this.drugId = drugId;
            this.callerWindow=callerWindow;
            var app = Application.Current as App;
            drugController = app.drugController;

            CloseCommand=new MyICommand(Close);
            Drug drug = drugController.GetById(drugId);
            ingredients = new ObservableCollection<string>(drug.Ingredients);
            name=drug.Name.ToUpper();
            type=drug.Type;
            status = drug.StatusString;
            description = drug.Description;
        
        }

        internal void Close()
        {
            callerWindow.Close();
        }
        

    }
}
