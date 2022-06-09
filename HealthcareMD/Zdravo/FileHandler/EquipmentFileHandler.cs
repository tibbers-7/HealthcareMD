using Model;
using System;
using System.Collections.ObjectModel;

namespace FileHandler
{
    public class EquipmentFileHandler
    {
        private String filePath = "data/sEquipment.txt";

        public ObservableCollection<StaticEquipment> Read() {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            ObservableCollection<StaticEquipment> equipment = new ObservableCollection<StaticEquipment>();
            foreach (var s in lines)
            {
                if (s.Equals("")) break;
                string[] ss = s.Split(',');
                int id = Int32.Parse(ss[0]);
                int amount = Int32.Parse(ss[2]);
                int roomId = Int32.Parse(ss[3]);
                StaticEquipment seq = new StaticEquipment(id, ss[1], amount, roomId);
                equipment.Add(seq);
            }
            return equipment;
        }

        public void Write(ObservableCollection<StaticEquipment> equipment) {
            string[] newLines = new string[equipment.Count];
            int i = 0;
            foreach (StaticEquipment eq in equipment)
            {
                string _id = eq.id.ToString();
                string _amount = eq.amount.ToString();
                string _roomId = eq.roomId.ToString(); ;
                newLines[i] = _id + "," + eq.name + "," + _amount + "," + _roomId;
                i++;
            }
            System.IO.File.WriteAllText(filePath, "");
            System.IO.File.WriteAllLines(filePath, newLines);
        }
    }
}
