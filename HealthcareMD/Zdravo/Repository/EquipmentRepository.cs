using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHandler;

namespace Repository
{
    public class EquipmentRepository
    {
        private EquipmentFileHandler equipmentFileHandler;
        private ObservableCollection<StaticEquipment> equipment;

        public EquipmentRepository()
        {
            this.equipmentFileHandler = new EquipmentFileHandler();
            this.equipment = equipmentFileHandler.Read();
        }
        public ObservableCollection<StaticEquipment> GetAll()
        {
            return equipmentFileHandler.Read();
        }

        public StaticEquipment GetById(int id)
        {
            foreach (StaticEquipment eq in equipment)
            {
                if (eq.id == id)
                {
                    return eq;
                }
            }
            return null;
        }

        public void UpdateAmount(int id, int amount)
        {
            foreach (StaticEquipment e in equipment)
            {
                if (id == e.id)
                {
                    e.amount = amount;
                }
            }
            equipmentFileHandler.Write(equipment);
        }

        public void UpdateRoomId(int id, int newRoomId)
        {
            foreach (StaticEquipment e in equipment)
            {
                if (id == e.id)
                {
                    e.roomId = newRoomId;
                }
            }
            equipmentFileHandler.Write(equipment);
        }

        public void Create(StaticEquipment newEquipment)
        {
            equipment.Add(newEquipment);
            equipmentFileHandler.Write(equipment);
        }

        public int GenerateId()
        {
            ObservableCollection<int> ids = new ObservableCollection<int>();
            int maxId = -5;
            foreach (StaticEquipment eq in equipment)
            {
                if (eq.id > maxId)
                {
                    maxId = eq.id;
                }
            }

            return maxId + 1;
        }

        public void DeleteById(int id)
        {
            int selected = -1;
            int i = 0;
            foreach (StaticEquipment eq in equipment)
            {
                if (eq.id == id)
                {
                    selected = i;
                }
                i++;
            }
            if (selected >= 0)
            {
                equipment.RemoveAt(selected);
            }
            equipmentFileHandler.Write(equipment);
        }
    }
}
