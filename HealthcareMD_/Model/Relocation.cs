using System;

namespace Model
{
    public class Relocation
    {
        private int _equipmentId;
        private int _roomId;
        private DateTime _date;
        private int _amount;

        public int EquipmentId { get { return _equipmentId; } set { _equipmentId = value; } }
        public int RoomId { get { return _roomId; } set { _roomId = value; } }
        public DateTime Date { get { return _date; } set { _date = value; } }
        public int Amount { get { return _amount; } set { _amount = value; } }

        public Relocation(int _equipmentId, int _roomId, DateTime _date, int _amount) { 
            this._equipmentId = _equipmentId;
            this._roomId = _roomId;
            this._date = _date;
            this._amount = _amount;
        }

    }
}
