using System;

namespace Model
{
    public class BasicRenovation
    {
        private int id;
        private int roomId;
        private string description;
        private DateTime date;

        public int Id { get { return id; } set { id = value; } }
        public int RoomId { get { return roomId; } set { roomId = value; } }
        public string Description { get { return description; } set { description = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
        public BasicRenovation(int id, int roomId, string description, DateTime date) { 
            this.id = id;
            this.description = description;
            this.date = date;
            this.roomId = roomId;
        }
    }
}
