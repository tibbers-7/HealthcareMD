using System;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HealthcareMD;

namespace Controller
{
   public class RoomController
   {
      private Service.RoomService roomService;

        public RoomController() {
            roomService = new Service.RoomService();
        }
      
      public void Create(int id, int floor, RoomType type, ObservableCollection<int> equipmentIds)
      {
            var newRoom = new Room (id, floor, type, equipmentIds);
            roomService.Create(newRoom);
      }
      
      public ObservableCollection<Room> GetAll()
      {
            return roomService.GetAll();
      }
      
      public Model.Room GetById(int id)
      {
            return roomService.GetById(id);
        }
      
      public void Update(int id, RoomType type)
      {
            roomService.Update(id, type);
        }
      
      public void DeleteAll()
      {
            roomService.DeleteAll();
      }
      
      public void DeleteById(int id)
      {
            roomService.DeleteById(id);
      }

        internal ObservableCollection<int> getAllIds()
        {
            return roomService.getAllIds();
        }
    }
}