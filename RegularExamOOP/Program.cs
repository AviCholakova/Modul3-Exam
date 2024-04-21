using System;
using System.Collections.Generic;

namespace RegularExamOOP
{
    public class Program
    {
        static Dictionary<int, RealEstate> realEstates = new Dictionary<int, RealEstate>();
        static Dictionary<string, Agency> agencies = new Dictionary<string, Agency>();

        static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "STOP")
            {
                string[] splittedInput = input.Split(' ');
                string command = splittedInput[0];

                switch (command)
                {
                    case "AddRealEstate":
                        AddRealEstate(splittedInput[1], double.Parse(splittedInput[2]), splittedInput[3]);
                        break;
                    case "SellRealEstate":
                        SellRealEstate(splittedInput[1], double.Parse(splittedInput[2]), splittedInput[3]);
                        break;
                    case "CalculateTotalPrice":
                        CalculateTotalPrice(splittedInput[1]);
                        break;
                    case "GetRealEstateWithHighestPrice":
                        GetRealEstateWithHighestPrice(splittedInput[1]);
                        break;
                    case "GetRealEstateWithLowestPrice":
                        GetRealEstateWithLowestPrice(splittedInput[1]);
                        break;
                    case "RenameAgency":
                        RenameAgency(splittedInput[1], splittedInput[2]);
                        break;
                    case "SellAllRealEstates":
                        SellAllRealEstates(splittedInput[1]);
                        break;
                    case "AgencyInfo":
                        AgencyInfo(splittedInput[1]);
                        break;
                    case "CreateAgency":
                        CreateAgency(splittedInput[1]);
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }

        }

        private static void AddRealEstate(string address, double price, string name)
        {
            try
            {
                RealEstate realEstate = new RealEstate(address, price);
                if (!agencies.ContainsKey(name))
                {
                    Console.WriteLine("Could not add this real estate to your agency.");
                    return;
                }
                Agency agency = agencies[name];
                agency.AddRealEstate(realEstate);
                Console.WriteLine($"You added real estate on {address} street to agency {agency.Name}.");

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SellRealEstate(string address, double price, string name)
        {
            try
            {
                if (!agencies.ContainsKey(name))
                {
                    Console.WriteLine("Could not sell this real estate from your agency.");
                    return;
                }

                RealEstate realEstate = new RealEstate(address, price);
                Agency agency = agencies[name];
                if (agency.SellRealEstate(realEstate))
                {
                    Console.WriteLine($"You sold real estate on {address} street from agency {name}.");
                }
                else
                {
                    Console.WriteLine($"Did not sell real estate on {address} street from perfumery {name}.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void CalculateTotalPrice(string name)
        {
            try
            {
                if (!agencies.ContainsKey(name))
                {
                    Console.WriteLine("Could not calculate total price.");
                    return;
                }
                Agency agency = agencies[name];

                Console.WriteLine($"Total price: {agency.CalculateTotalPrice():F2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void RenameAgency(string name, string newName)
        {

            if (!agencies.ContainsKey(name))
            {
                Console.WriteLine($"Could not rename the agency {name}.");
                return;
            }
            Agency agency = agencies[name];

            try
            {
                agency.RenameAgency(newName);
                agencies.Remove(name);
                agencies.Add(newName, agency);
                Console.WriteLine($"You renamed your agency from {name} to {newName}.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SellAllRealEstates(string name)
        {

            if (!agencies.ContainsKey(name))
            {
                Console.WriteLine($"Could not sell all real estates from agency {name}.");
                return;
            }
            Agency agency = agencies[name];

            agency.SellAllRealEstates();
            Console.WriteLine($"You sold all real estates from agency {name}.");
        }

        private static void AgencyInfo(string name)
        {
            if (!agencies.ContainsKey(name))
            {
                Console.WriteLine($"Could not get agency {name}.");
                return;
            }
            Agency agency = agencies[name];
            Console.WriteLine(agency.ToString());
        }

        private static void GetRealEstateWithLowestPrice(string name)
        {

            if (!agencies.ContainsKey(name))
            {
                Console.WriteLine($"Could not get real estate with lowest price from agency {name}.");
                return;
            }
            Agency agency = agencies[name];

            Console.WriteLine($"Real estate from agency {name} has lowest price: {agency.GetRealEstateWithLowestPrice().Price:F2}");
        }

        private static void GetRealEstateWithHighestPrice(string name)
        {

            if (!agencies.ContainsKey(name))
            {
                Console.WriteLine($"Could not get real estate with highest price from agency {name}.");
                return;
            }
            Agency agency = agencies[name];

            Console.WriteLine($"Real estate from agency {name} has highest price: {agency.GetRealEstateWithHighestPrice().Price:F2}");
        }


        private static void CreateAgency(string name)
        {

            try
            {
                Agency agency = new Agency(name);
                agencies.Add(name, agency);
                Console.WriteLine($"You created agency {name}.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
}


