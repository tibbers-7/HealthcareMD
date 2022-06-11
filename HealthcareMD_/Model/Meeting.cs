using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Model
{
    public class Meeting
    {
        private int id;
        public int Id => id;

        private string description;

        public string Description=> description;

        private string date;
        public string Date => date;

        private string time;

        public string Time => time;

        private ObservableCollection<String> users;
        public ObservableCollection<String> Users => users;

        public Meeting(int id,string description,string date,string time, ObservableCollection<String> users)
        {
            this.id = id;
            this.description = description;
            this.date = date;
            this.time= time;
            this.users = users;
        }
    }
}
