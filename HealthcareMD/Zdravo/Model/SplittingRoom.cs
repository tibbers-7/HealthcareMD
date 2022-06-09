using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareMD.Model
{
    public class SplittingRoom
    {
        private int selectedRoomId;
        private string description;
        private DateTime startDate;
        private DateTime endDate;
        private int firstRoomId;
        private int secondRoomId;
        private RoomType firstRoomType;
        private RoomType secondRoomType;

        public SplittingRoom(int selectedRoomId, string description, DateTime startDate, DateTime endDate, int firstRoomId, RoomType firstRoomType, int secondRoomId, RoomType secondRoomType) { 
            this.firstRoomId = firstRoomId;
            this.secondRoomId = secondRoomId;
            this.startDate = startDate;
            this.endDate = endDate;
            this.firstRoomType = firstRoomType;
            this.secondRoomType = secondRoomType;
            this.selectedRoomId = selectedRoomId;
            this.description = description;
        }

        public int SelectedRoomId { get { return selectedRoomId; } set { selectedRoomId = value; } }
        public string Description { get { return description; } set { description = value; } }
        public DateTime StartDate { get { return startDate; } set { startDate = value; } }
        public DateTime EndDate { get { return endDate; } set { endDate = value; } }
        public int FirstRoomId { get { return firstRoomId; } set { firstRoomId = value; } }
        public RoomType FirstRoomType { get { return firstRoomType; } set { firstRoomType = value; } }
        public int SecondRoomId { get { return secondRoomId; } set { secondRoomId = value; }}
        public RoomType SecondRoomType { get { return secondRoomType; } set { secondRoomType = value; } }
    }
}
