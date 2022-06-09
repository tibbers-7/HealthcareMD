using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareMD.Model
{
    public class MergingRooms
    {
        private int firstSelectedRoomId;
        private int secondSelectedRoomId;
        private string description;
        private DateTime startDate;
        private DateTime endDate;
        private int newRoomId;
        private RoomType newRoomType;

        public MergingRooms(int firstSelectedRoomId, int secondSelectedRoomId,  DateTime startDate, DateTime endDate, string description, int newRoomId, RoomType newRoomType)
        {
            this.firstSelectedRoomId = firstSelectedRoomId;
            this.secondSelectedRoomId = secondSelectedRoomId;
            this.startDate = startDate;
            this.endDate = endDate;
            this.newRoomId = newRoomId;
            this.newRoomType = newRoomType;
            this.description = description;
        }

        public int FirstSelectedRoomId { get { return firstSelectedRoomId; } set { firstSelectedRoomId = value; } }
        public int SecondSelectedRoomId { get { return secondSelectedRoomId; } set { secondSelectedRoomId = value; } }
        public string Description { get { return description; } set { description = value; } }
        public DateTime StartDate { get { return startDate; } set { startDate = value; } }
        public DateTime EndDate { get { return endDate; } set { endDate = value; } }
        public int NewRoomId { get { return newRoomId; } set { newRoomId = value; } }
        public RoomType NewRoomType { get { return newRoomType; } set { newRoomType = value; } }
        
    }
}
