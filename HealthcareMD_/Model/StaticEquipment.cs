using System;

namespace Model
{
   public class StaticEquipment
   {
      public int id { get; set; }
      public string name { get; set; }
      public int amount { get; set; }

        public int roomId { get; set; }

        public StaticEquipment(int id, string name, int amount, int roomId) { 
            this.id = id;
            this.name = name;
            this.amount = amount;
            this.roomId = roomId;
        }

        public StaticEquipment(string name, int amount, int roomId)
        {
            this.name = name;
            this.amount = amount;
            this.roomId = roomId;
        }

        public Room room;
      
      /// <summary>
      /// Property for Room
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Room Room
      {
         get
         {
            return room;
         }
         set
         {
            if (this.room == null || !this.room.Equals(value))
            {
               if (this.room != null)
               {
                  Room oldRoom = this.room;
                  this.room = null;
                  oldRoom.RemoveStaticEquipment(this);
               }
               if (value != null)
               {
                  this.room = value;
                  this.room.AddStaticEquipment(this);
               }
            }
         }
      }
   
   }
}