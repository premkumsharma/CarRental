using System;
using System.Collections.Generic;
using System.Text;

namespace FlipKar
{
    public class Vehicle
    {
        public string VehicleType { get; set; }
        public double PricePerHour { get; set; }
        public int VehicleCount { get; set; }
        public Vehicle(string type,int count,int price)
        {
            this.VehicleType = type;
            PricePerHour = price;
            VehicleCount = count;

        }

        public override int GetHashCode()
        {
                switch(this.VehicleType)
            {
                case "suv": return 1;
                case "sedan": return 2;
                case "bike":return 3;
            }

            return 0;
        }

    }

    public enum VehicleType
    {
        Suv,
        Sedan,
        Bike
    }

}
