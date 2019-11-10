using System;

namespace FlipKar
{
    class Program
    {
        static void Main(string[] args)
        {
            FlipKar flipKar = new FlipKar();

            String input = null;
            string branchName, cartype;
            do
            {
                Console.WriteLine("Type printview for Viewing the branch");

                Console.WriteLine("Type addbranch for adding a branch");
                Console.WriteLine("Type addvehicle to Adding Vehicle");
                Console.WriteLine("Type rentcar to renting car");
                Console.Write("Type exit for Exiting the window\n");

                input = Console.ReadLine();
                input = input.ToLower();

                if (input.Equals("exit")) break;

                switch(input)
                {
                    case "addbranch":
                        Console.WriteLine("Input Branch Name");
                        branchName = Console.ReadLine();
                        flipKar.AddBranch(branchName);
                        break;
                    case "addvehicle":
                        branchName = Console.ReadLine();
                        cartype = Console.ReadLine();
                        int count = Convert.ToInt32(Console.ReadLine());
                        int price = Convert.ToInt32(Console.ReadLine());
                        flipKar.AddVehicle(branchName, new Vehicle(cartype, price, count));
                        break;
                    case "printview":
                        DateTime startdate = new DateTime();
                        DateTime endtime = new DateTime().AddDays(30);
                        flipKar.PrintSystemViewForTimeSlot(startdate, endtime);
                        break;
                    case "rentcar":
                        cartype = Console.ReadLine();
                        startdate = new DateTime().AddHours(12);
                        int hours = Convert.ToInt32(Console.ReadLine());
                        flipKar.RentVehicle(cartype, startdate, hours);
                        break;

                }
            } while (true);
        }
    }
}
