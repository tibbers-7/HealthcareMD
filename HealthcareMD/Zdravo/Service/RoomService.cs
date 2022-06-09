using System;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HealthcareMD.Repository;
using Repository;
using HealthcareMD;
using System.Windows;
using HealthcareMD.Controller;

namespace Service
{
   public class RoomService
   {
      private Repository.RoomRepository roomRepo;
        private AppointmentController appointmentController;

        public RoomService() {
            var app=Application.Current as App;
            roomRepo = new Repository.RoomRepository();
            appointmentController = app.appointmentController;
        }
      
      public void Create(Room newRoom)
      {
            roomRepo.Create(newRoom);
      }
      
      public ObservableCollection<Room> GetAll()
      {
            return roomRepo.GetAll();
      }

        public ObservableCollection<int> getAllIds()
        {
            ObservableCollection<int> ids = new ObservableCollection<int>();
            foreach (Room room in roomRepo.GetAll())
            {
                ids.Add(room.id);
            }

            return ids;
        }

        public Model.Room GetById(int id)
      {
            return roomRepo.GetById(id);
      }
      
      public void Update(int id, RoomType type)
      {
            roomRepo.Update(id, type);
      }
      
      public void DeleteAll()
      {
            roomRepo.DeleteAll();
      }
      
      public void DeleteById(int id)
      {
            roomRepo.DeleteById(id);
        }

        public bool IsAvailableAppt1(int roomId, TimeOnly time, DateOnly date) {
            bool available = true;
            int cmp;
            DateTime dateTimeNew = date.ToDateTime(time);
            ObservableCollection<Appointment> appointments = new ObservableCollection<Appointment>(appointmentController.GetAll());
            foreach (Appointment appointment in appointments) {
                if (appointment.Room == roomId) {
                    DateTime dateTimeAppt = appointment.Date.ToDateTime(appointment.Time);
                    cmp = DateTime.Compare(dateTimeNew, dateTimeAppt);
                    if (cmp == 0) {
                        available = false;
                    }
                }
            }
            return available;
        }

        public bool IsAvailableAppt(int roomId, DateTime date)
        {
            bool available = true;
            //int cmp;
            ObservableCollection<Appointment> appointments = new ObservableCollection<Appointment>(appointmentController.GetAll());
            foreach (Appointment appointment in appointments)
            {
                if (appointment.Room == roomId)
                {
                    DateTime dateTimeAppt = appointment.Date.ToDateTime(appointment.Time);
                    DateTime dateAppt = dateTimeAppt.Date;
                    //cmp = DateTime.Compare(date, dateTimeAppt);
                    //cmp = date.Date.CompareTo(appointment.Date);
                    /*DateOnly dateOnlyAppt = appointment.Date;
                    string dateAppt = dateOnlyAppt.ToString();*/
                    if (dateAppt.Equals(date)) {
                        available = false;
                    }
                    /*if (true)
                    {
                        available = false;
                    }*/
                }
            }
            return available;
        }

    }
}