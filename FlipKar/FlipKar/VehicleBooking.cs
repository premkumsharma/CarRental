using System;
using System.Collections.Generic;
using System.Text;

namespace FlipKar
{
    public class VehicleBooking
    {
        public Vehicle Vehicle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDateTime { get; set; }
        public double TotalCost { get; set; }

        public VehicleBooking(Vehicle vehicle,DateTime start,DateTime endTime,double totalCost)
        {
            Vehicle = vehicle;
            StartDate = start;
            EndDateTime = endTime;
            TotalCost = totalCost;
        }
    }
}
