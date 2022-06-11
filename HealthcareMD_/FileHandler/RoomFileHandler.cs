using System;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HealthcareMD_;

namespace FileHandler
{
   public class RoomFileHandler
   {
      private String filePath = "data/rooms.txt";

        public RoomFileHandler()
        {
           // filePath = "data/rooms.txt";
            
        }
      public ObservableCollection<Room> Read()
      {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            ObservableCollection<Room> rooms = new ObservableCollection<Room>();
            foreach (var s in lines)
            {
                if (s.Equals("")) break;
                string[] ss = s.Split(',');
                int id = Int32.Parse(ss[0]);
                int floor = Int32.Parse(ss[1]);
                String type = ss[2];
                RoomType type1;
                switch (type)
                {
                    case "operatingRoom":
                        type1 = RoomType.operatingRoom;
                        break;
                    case "laboratory":
                        type1 = RoomType.laboratory;
                        break;
                    case "magacin":
                        type1 = RoomType.magacin;
                        break;
                    default:
                        type1 = RoomType.operatingRoom;
                        break;
                }
                if (ss.Length > 3)
                {
                    ObservableCollection<int> equipmentIds = new ObservableCollection<int>();
                    int equipmentId = 0;
                    for (int i = 3; i < ss.Length; i++)
                    {
                        equipmentId = Int32.Parse(ss[i]);
                        equipmentIds.Add(equipmentId);
                    }
                    Room room = new Room(id, floor, type1, equipmentIds);
                    rooms.Add(room);
                }
                else
                {
                    ObservableCollection<int> equipmentIds = new ObservableCollection<int>();
                    Room room = new Room(id, floor, type1, equipmentIds);
                    rooms.Add(room);
                }
            }
            return rooms;
        }
      
      public void Write(ObservableCollection<Room> rooms)
      {
            /*string[] lines = System.IO.File.ReadAllLines(filePath);
            string[] newLines = new string[lines.Length + 1];
            for (int i = 0; i < lines.Length; i++)
            {
                newLines[i] = lines[i];
            }
            String rt = "";
            switch (newRoom.type)
            {
                case RoomType.operatingRoom:
                    rt = "operatingRoom";
                    break;
                case RoomType.laboratory:
                    rt = "laboratory";
                    break;
                default:
                    rt = "operatingRoom";
                    break;
            }
            newLines[lines.Length] = newRoom.id.ToString() + "," + newRoom.floor.ToString() + "," + rt;
            System.IO.File.WriteAllText(filePath, "");
            System.IO.File.WriteAllLines(filePath, newLines);*/
            string[] newLines = new string[rooms.Count];
            int i = 0;
            foreach (Room room in rooms) { 
                string id = room.id.ToString();
                string floor = room.floor.ToString();
                string rt = "";
                string equipmentIdss = "";
                switch (room.type)
                {
                    case RoomType.operatingRoom:
                        rt = "operatingRoom";
                        break;
                    case RoomType.laboratory:
                        rt = "laboratory";
                        break;
                    case RoomType.magacin:
                        rt = "magacin";
                        break;
                    default:
                        rt = "operatingRoom";
                        break;
                }
                if (room.equipmentIds.Count != 0)
                {
                    foreach (int equipmentId in room.equipmentIds)
                    {
                        string eid = equipmentId.ToString();
                        equipmentIdss = equipmentIdss + eid + ",";
                    }
                    equipmentIdss = equipmentIdss.Substring(0, equipmentIdss.Length - 1);
                    newLines[i] = id + "," + floor + "," + rt + "," + equipmentIdss;
                }
                else {
                    newLines[i] = id + "," + floor + "," + rt;
                }
                i++;

            }
            System.IO.File.WriteAllText(filePath, "");
            System.IO.File.WriteAllLines(filePath, newLines);
        }
   
   }
}