using System;
using System.Collections.Generic;
using System.Text;

namespace FlipKar
{
    public class FlipKar
    {
        public string Name { get; set; }
        Dictionary<string, FlipKarBranch> Branches;

        public FlipKar()
        {
            Branches = new Dictionary<string, FlipKarBranch>();
            AddBranch("koramangala");
            AddBranch("jayanagar");
            AddDefaultVehicle();
            AddDefultRentVehicle();
        }
        public bool AddBranch(string branchName)
        {
            Branches.Add(branchName,new FlipKarBranch(branchName));
            return true;
        }
        public void AddVehicle(string branchName,Vehicle vehicle)
        {
            Branches[branchName].SetVehicle(vehicle);

        }
        void AddDefultRentVehicle()
        {
            RentVehicle("suv", new DateTime(2019, 2, 20, 22, 0, 0), 2);
            RentVehicle("suv", new DateTime(2019, 2, 20, 22, 0, 0), 2);
            RentVehicle("suv", new DateTime(2019, 2, 20, 22, 0, 0), 2);


        }
        public bool RentVehicle(string vehicleType, DateTime startDateTime, int hours)
        {
            double minCost = 0;
            VehicleBooking vehicleBooking = null;
            FlipKarBranch bookingbranch = null;
            foreach (var branch in Branches)
            {
                var booking = branch.Value.RentVehicle(vehicleType, startDateTime, hours);
                if (minCost > booking?.TotalCost)
                {
                    vehicleBooking = booking;
                    minCost = booking.TotalCost;
                    bookingbranch = branch.Value;
                }
            }
            if(bookingbranch != null)
            {

                bookingbranch.AddBooking(vehicleBooking);
                return true;

            }
            Console.WriteLine("No Vehicle");

            return false;

        }

        public void PrintSystemViewForTimeSlot(DateTime startDate,DateTime endTime)
        {
            foreach (var branch in Branches)
            {
                Console.WriteLine("BranchName :" + branch.Value.Name);
                Console.WriteLine("");

                branch.Value.PrintSystemViewForTimeSlot(startDate,endTime);
            }
        }
        private void AddDefaultVehicle()
        {

            AddVehicle("koramangala", new Vehicle("suv", 1, 12));

            AddVehicle("koramangala", new Vehicle("sedan", 3, 10));


            AddVehicle("jayanagar", new Vehicle("suv", 1, 15));
            AddVehicle("jayanagar", new Vehicle("sedan", 3, 11));
            AddVehicle("jayanagar", new Vehicle("bike", 3, 30));
            AddVehicle("jayanagar", new Vehicle("bike", 5, 30));
            AddVehicle("jayanagar", new Vehicle("hatchback", 4, 18));

            AddVehicle("jayanagar", new Vehicle("hatchback", 4, 9));

        }

    }
}
