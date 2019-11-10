using System;
using System.Collections.Generic;
using System.Text;

namespace FlipKar
{
    public class FlipKarBranch
    {
        public string Name { get; set; }
        Dictionary<Vehicle, int> Vehicles;

        Dictionary<Vehicle, List<VehicleBooking>> VehicleBookings;

        public FlipKarBranch(string name)
        {
            Name = name;
            Vehicles = new Dictionary<Vehicle, int>();
            VehicleBookings = new Dictionary<Vehicle, List<VehicleBooking>>();
        }

        public bool SetVehicle(Vehicle vehicle )
        {
            if (Vehicles.ContainsKey(vehicle))
                Vehicles[vehicle]++;
            else
            Vehicles.Add(vehicle, 1);
            return true;
        }

        private void AddDefaultRent()
        {
            }
        public VehicleBooking RentVehicle(string vehicleType, DateTime startDateTime,int hours)
        {
            Vehicle vehicle = new Vehicle(vehicleType,0,0);
            if (Vehicles.ContainsKey(vehicle))
            {
                int totalVehicle = Vehicles[vehicle];
                DateTime endTime = startDateTime.AddHours(hours);
                int totalBooked = GetCountOfBookedVehicle(vehicle, startDateTime, endTime);
                int minCost = Int32.MinValue;
                if(totalVehicle >= totalBooked)
                {
                    double totalCost = vehicle.PricePerHour * hours;
                    return new VehicleBooking(vehicle, startDateTime, endTime,totalCost);                    
                }
            }
            return null;
        }
        public void AddBooking(VehicleBooking vehicleBooking)
        {
            if (VehicleBookings.ContainsKey(vehicleBooking.Vehicle))
            {
                VehicleBookings[vehicleBooking.Vehicle].Add(vehicleBooking);
            }
            else
            {
                List<VehicleBooking> bookings = new List<VehicleBooking>();
                bookings.Add(vehicleBooking);
                VehicleBookings.Add(vehicleBooking.Vehicle, bookings);
            }
        }

        public void PrintSystemViewForTimeSlot(DateTime startDate, DateTime endTime)
        {
            foreach (var vehicle in Vehicles)
            {
                 int bookedVehicle = GetCountOfBookedVehicle(vehicle.Key, startDate, endTime);
                if (vehicle.Value == bookedVehicle)
                {
                    Console.WriteLine("All " + vehicle.Key.VehicleType.ToString() + " are booked");
                }
                else
                    Console.WriteLine((vehicle.Key.VehicleCount - bookedVehicle) + " " + vehicle.Key.VehicleType.ToString() + " is available for " + vehicle.Key.PricePerHour);

            }
        }
        private int GetCountOfBookedVehicle(Vehicle vehicle,DateTime startDate,DateTime endTime)
        {
            int count = 0;
            if(VehicleBookings.ContainsKey(vehicle))
            {
                foreach (var booking in VehicleBookings[vehicle])
                    if (booking.StartDate >= startDate && booking.EndDateTime <= endTime)
                        count++;
            }

            return count;
        }
    }
}
