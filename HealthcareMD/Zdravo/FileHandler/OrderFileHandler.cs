using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Model;

namespace FileHandler
{
    public class OrderFileHandler
    {
        private string filepath = "data/equipmentOrders.txt";

        public ObservableCollection<Order> Load()
        {
            // TODO: implement
            string[] lines = System.IO.File.ReadAllLines(filepath);
            ObservableCollection<Order> loadedOrders = new ObservableCollection<Order>();
            foreach (var line in lines)
            {
                if (line.Equals("")) break;
                string[] parameters = line.Split('|');
                string name=parameters[0];
                int quantity=int.Parse(parameters[1]);
                DateTime orderDateTime=Convert.ToDateTime(parameters[2]);
                string note=parameters[3];
                Order loadedOrder=new Order(name, quantity, orderDateTime, note);
                var razlika = DateTime.Now - orderDateTime;
                if (!(razlika.Hours > 72))
                {
                    loadedOrders.Add(loadedOrder);
                }
            }
            return loadedOrders;
        }
        public void addNewOrder(Order newOrder)
        {
            string[] lines = System.IO.File.ReadAllLines(filepath);
            string[] newLines = new string[lines.Length + 1];
            for (int i = 0; i < lines.Length; i++)
            {
                newLines[i] = lines[i];
            }
            newLines[lines.Length] = newOrder.Name + "|" + newOrder.Quantity.ToString() + "|" + newOrder.OrderDateTime.ToString() + "|" + newOrder.Note;
            System.IO.File.WriteAllText(filepath, "");
            System.IO.File.WriteAllLines(filepath, newLines);
        }
        public void write(ObservableCollection<Order> orders)
        {
            string[] newLines = new string[orders.Count];
            for(int i = 0; i < orders.Count; i++)
            {
                newLines[i] = orders[i].Name + "|" + orders[i].Quantity.ToString() + "|" + orders[i].OrderDateTime.ToString() +"|"+ orders[i].Note;
            }
            System.IO.File.WriteAllText(filepath, "");
            System.IO.File.WriteAllLines(filepath, newLines);
        }
    }
}
