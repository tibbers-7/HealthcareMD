/*using Repository;
using System;
using System.Threading.Tasks;
using Model;
using HealthcareMD_.ViewModel;
using System.Windows;
using HealthcareMD_.Model;
using System.Collections.ObjectModel;

namespace Service
{
    public class TimeService
    {
        private RelocationRepository relocationRepo = new RelocationRepository();
        private RoomRepository roomRepo = new RoomRepository();
        private EquipmentRepository eqRepo = new EquipmentRepository();
        private EquipmentRelocationViewModel viewModel = new EquipmentRelocationViewModel();
        private OrderRepository orderRepo= new OrderRepository();
        private SplittingRoomRepository splittingRoomRepo = new SplittingRoomRepository();
        private MergingRoomsRepository mergingRoomsRepository = new MergingRoomsRepository();

        public async void ThreadFunction()
        {
            while (true)
            {

                try
                {
                    foreach (Relocation relocation in relocationRepo.GetAll())
                    {
                        if (DateTime.Compare(relocation.Date, DateTime.Now) <= 0)
                        {
                            roomRepo.RelocateEquipment(relocation);
                            viewModel.Refresh();
                            relocationRepo.Delete(relocation);
                        }
                    }
                    foreach(Order order in orderRepo.getAllOrders())
                    {
                        if ((DateTime.Now-order.OrderDateTime).TotalHours>=72)
                        {
                            //prebacivanje u magacin
                            StaticEquipment equipment = new StaticEquipment(order.Name, order.Quantity, 7);
                            eqRepo.Create(equipment);
                            Room r = roomRepo.GetById(7);
                            r.equipmentIds.Add(equipment.id);
                            roomRepo.UpdateEquipment(7, r.equipmentIds);
                            orderRepo.deleteOrder(order);
                        }
                    }

                    foreach(SplittingRoom splittingRoom in splittingRoomRepo.GetAll())
                    {
                        if(DateTime.Compare(splittingRoom.EndDate, DateTime.Now) <= 0)
                        {
                            //ovo moze u posebnu fju
                            Room selectedRoom = roomRepo.GetById(splittingRoom.SelectedRoomId);
                            Room stockRoom = roomRepo.GetById(7);
                            ObservableCollection<int> equipmentIds = stockRoom.equipmentIds;
                            foreach (int equipmentId in selectedRoom.equipmentIds)
                            {
                                equipmentIds.Add(equipmentId);
                                eqRepo.UpdateRoomId(equipmentId, 7);
                            }
                            roomRepo.UpdateEquipment(7, equipmentIds);
                            //
                            roomRepo.DeleteById(selectedRoom.id);

                            //sledeca fja
                            Room firstNewRoom = new Room(splittingRoom.FirstRoomId, selectedRoom.floor, splittingRoom.FirstRoomType);
                            roomRepo.Create(firstNewRoom);
                            Room secondNewRoom = new Room(splittingRoom.SecondRoomId, selectedRoom.floor, splittingRoom.SecondRoomType);
                            roomRepo.Create(secondNewRoom);
                            //
                            //obrisati splitting
                            splittingRoomRepo.Delete(splittingRoom);
                        }
                    }

                    foreach(MergingRooms mergingRooms in mergingRoomsRepository.GetAll())
                    {
                        if (DateTime.Compare(mergingRooms.EndDate, DateTime.Now) <= 0)
                        {
                            Room firstRoomSelected = roomRepo.GetById(mergingRooms.FirstSelectedRoomId);
                            Room secondRoomSelected = roomRepo.GetById(mergingRooms.SecondSelectedRoomId);
                            Room stockRoom = roomRepo.GetById(7);
                            ObservableCollection<int> equipmentIds = stockRoom.equipmentIds;
                            foreach (int equipmentId in firstRoomSelected.equipmentIds)
                            {
                                equipmentIds.Add(equipmentId);
                                eqRepo.UpdateRoomId(equipmentId, 7);
                            }
                            foreach (int equipmentId in secondRoomSelected.equipmentIds)
                            {
                                equipmentIds.Add(equipmentId);
                                eqRepo.UpdateRoomId(equipmentId, 7);
                            }
                            roomRepo.UpdateEquipment(7, equipmentIds);
                            roomRepo.DeleteById(firstRoomSelected.id);
                            roomRepo.DeleteById(secondRoomSelected.id);

                            Room newRoom = new Room(mergingRooms.NewRoomId, firstRoomSelected.floor, mergingRooms.NewRoomType);
                            roomRepo.Create(newRoom);   
                            
                            mergingRoomsRepository.Delete(mergingRooms);
                        }
                    }
                }
                catch (Exception e)
                {

                }

                await Task.Delay(TimeSpan.FromMilliseconds(1000));
                //Thread.Sleep(60 * 1000);
            }

        }
    }
}

*/