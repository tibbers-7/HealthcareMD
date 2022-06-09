using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using HealthcareMD;

namespace Model
{
   public class Room  
    {
      public int id { get; set; }
      public int floor { get; set; }
      public RoomType type { get; set; }

       public ObservableCollection<StaticEquipment> equipment { get; set; }

      public System.Collections.Generic.List<StaticEquipment> staticEquipment;
        public ObservableCollection<int> equipmentIds { get; set; }

        public Room(int id, int floor, RoomType type, ObservableCollection<int> equipmentIds)
        {
            this.id = id;
            this.floor = floor;
            this.type = type;
            this.equipmentIds = equipmentIds;
        }

        public Room(int id, int floor, RoomType type)
        {
            this.id = id;
            this.floor = floor;
            this.type = type;
            this.equipmentIds = new ObservableCollection<int>();
        }

        /// <summary>
        /// Property for collection of StaticEquipment
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<StaticEquipment> StaticEquipment
      {
         get
         {
            if (staticEquipment == null)
               staticEquipment = new System.Collections.Generic.List<StaticEquipment>();
            return staticEquipment;
         }
         set
         {
            RemoveAllStaticEquipment();
            if (value != null)
            {
               foreach (StaticEquipment oStaticEquipment in value)
                  AddStaticEquipment(oStaticEquipment);
            }
         }
      }
      
      /// <summary>
      /// Add a new StaticEquipment in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddStaticEquipment(StaticEquipment newStaticEquipment)
      {
         if (newStaticEquipment == null)
            return;
         if (this.staticEquipment == null)
            this.staticEquipment = new System.Collections.Generic.List<StaticEquipment>();
         if (!this.staticEquipment.Contains(newStaticEquipment))
         {
            this.staticEquipment.Add(newStaticEquipment);
            newStaticEquipment.Room = this;
         }
      }
      
      /// <summary>
      /// Remove an existing StaticEquipment from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveStaticEquipment(StaticEquipment oldStaticEquipment)
      {
         if (oldStaticEquipment == null)
            return;
         if (this.staticEquipment != null)
            if (this.staticEquipment.Contains(oldStaticEquipment))
            {
               this.staticEquipment.Remove(oldStaticEquipment);
               oldStaticEquipment.Room = null;
            }
      }
      
      /// <summary>
      /// Remove all instances of StaticEquipment from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllStaticEquipment()
      {
         if (staticEquipment != null)
         {
            System.Collections.ArrayList tmpStaticEquipment = new System.Collections.ArrayList();
            foreach (StaticEquipment oldStaticEquipment in staticEquipment)
               tmpStaticEquipment.Add(oldStaticEquipment);
            staticEquipment.Clear();
            foreach (StaticEquipment oldStaticEquipment in tmpStaticEquipment)
               oldStaticEquipment.Room = null;
            tmpStaticEquipment.Clear();
         }
      }

        public void AddEquipment(StaticEquipment eq) {
            if (equipment == null)
            {
                equipment = new ObservableCollection<StaticEquipment>();
                equipment.Add(eq);
            }
            else {
                equipment.Add(eq);
            }
            
        }

        public void fromCSV(string[] values)
        {
            id = int.Parse(values[0]);
            floor = int.Parse(values[1]);


        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                id.ToString(),
                floor.ToString(),
            };
            return csvValues;
        }

    }
}