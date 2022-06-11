using Model;
using System.Collections.ObjectModel;
using HealthcareMD_;

namespace Repository
{
    public class RoomRepository
   {
      private FileHandler.RoomFileHandler fileHandler;
        public ObservableCollection<Room> rooms;

        public RoomRepository()
        {
            fileHandler = new FileHandler.RoomFileHandler();
            rooms = new ObservableCollection<Room>();
            rooms = fileHandler.Read();
            /*var room1 = new Room() { id = 1, floor = 1, type = RoomType.operatingRoom };
            var eq1 = new StaticEquipment {id = 1, name = "sto", amount = 1, roomId = 1};
            var eq2 = new StaticEquipment { id = 2, name = "stolica", amount = 1, roomId = 1 };
            room1.AddEquipment(eq1);
            room1.AddEquipment(eq2);

            rooms.Add(room1);

            var room2 = new Room() { id = 2, floor = 1, type = RoomType.operatingRoom };
            var eq3 = new StaticEquipment { id = 3, name = "hanzaplast", amount = 1, roomId = 2 };
            var eq4 = new StaticEquipment { id = 2, name = "bensedin", amount = 1, roomId = 2 };
            room2.AddEquipment(eq3);
            room2.AddEquipment(eq4);

            rooms.Add(room2);*/

        }
      
      public void Create(Room newRoom)
      {
            rooms.Add(newRoom);
            fileHandler.Write(rooms);
      }
      
      public ObservableCollection<Room> GetAll()
      {
            return rooms;
      }
      
      public void DeleteAll()
      {
            
      }

        //internal Room GetById(int id)
        //{
        //    foreach (Room r in rooms)
        //    {
        //        if (r.id==id) return r;
        //    }

        //    return null;
        //}

        public void DeleteById(int id)
      {
            int selected = -1;
            int i = 0;
            foreach (Room room in rooms) {
                if (room.id == id) {
                    selected = i;
                }
                i++;
            }
            if (selected >= 0) {
                rooms.RemoveAt(selected);
            }
            fileHandler.Write(rooms);
        }
      
      public Model.Room GetById(int id)
      {
            foreach (Room room in rooms)
            {
                if (room.id == id)
                {
                    return room;
                }
            }
            return null;
        }
      
      public void Update(int id, RoomType type)
      {
            foreach (Room room in rooms)
            {
                if (room.id == id)
                {
                    room.type = type;
                    //return;
                }
            }
            fileHandler.Write(rooms);
        }

        public void UpdateEquipment(int id, ObservableCollection<int> equipmentIds)
        {
            foreach (Room room in rooms)
            {
                if (room.id == id)
                {
                    room.equipmentIds = equipmentIds;
                    //return;
                }
            }
            fileHandler.Write(rooms);
        }

        public void RelocateEquipment(Relocation relocation)
        {
            EquipmentRepository eqRepo = new EquipmentRepository();
            StaticEquipment eq = eqRepo.GetById(relocation.EquipmentId);
            Room from = GetById(eq.roomId);
            Room destination = GetById(relocation.RoomId);
            if (eq.amount > relocation.Amount)
            {
                int newAmount = eq.amount - relocation.Amount;
                //eq.amount = newAmount;
                //eq.amount = eq.amount - relocation.Amount;
                eqRepo.UpdateAmount(eq.id, newAmount);
                ObservableCollection<int> ids = destination.equipmentIds;
                bool found = false;
                foreach (int id in ids)
                {
                    if (eq.name.Equals(eqRepo.GetById(id).name))
                    {
                        int newAm = eqRepo.GetById(id).amount + relocation.Amount;
                        //eqRepo.GetById(id).amount = eqRepo.GetById(id).amount + relocation.Amount;
                        eqRepo.UpdateAmount(id, newAm);
                        found = true;
                    }
                }
                if (!found)
                {
                    int newId = eqRepo.GenerateId();
                    StaticEquipment newEq = new StaticEquipment(newId, eq.name, relocation.Amount, relocation.RoomId);
                    eqRepo.Create(newEq);
                    ids.Add(newId);
                    UpdateEquipment(destination.id, ids);
                }
            }
            else if (eq.amount == relocation.Amount)
            {
                ObservableCollection<int> idss = from.equipmentIds;
                idss.Remove(eq.id);
                UpdateEquipment(from.id, idss);

                ObservableCollection<int> ids = destination.equipmentIds;
                bool found = false;
                foreach (int id in ids)
                {
                    if (eq.name.Equals(eqRepo.GetById(id).name))
                    {
                        int newAm = eqRepo.GetById(id).amount + relocation.Amount;
                        eqRepo.UpdateAmount(id, newAm);
                        eqRepo.DeleteById(relocation.EquipmentId);
                        found = true;
                    }
                }
                if (!found)
                {
                    //eq.roomId = destination.id;
                    eqRepo.UpdateRoomId(eq.id, destination.id);
                    ids.Add(eq.id);
                    UpdateEquipment(destination.id, ids);
                }
            }
        }

    }
}