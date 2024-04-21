using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Xml;

namespace RegularExamOOP
{
    public class Agency
    {
        private List<RealEstate> realEstates;

        public Agency(string name)
        {
            this.Name = name;
            this.realEstates = new List<RealEstate>();
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 6)
                {
                    throw new ArgumentException("Invalid agency name!");
                }
                name = value;
            }
        }

        public void AddRealEstate(RealEstate realEstate)
        {
            realEstates.Add(realEstate);
        }

        public bool SellRealEstate(RealEstate realEstate)
        {
            RealEstate searchedHousing = realEstates.FirstOrDefault(x => x.Price == realEstate.Price && x.Address == realEstate.Address);
            if (searchedHousing != null)
            {
                return realEstates.Remove(searchedHousing);
            }
            return false;
        }
        public double CalculateTotalPrice()
        {
            double totalPrice = realEstates.Sum(x => x.Price);
            return totalPrice;
        }
        public RealEstate GetRealEstateWithHighestPrice()
        {
            RealEstate housingHighest = realEstates.OrderByDescending(x => x.Price).FirstOrDefault();
            return housingHighest;
        }

        public RealEstate GetRealEstateWithLowestPrice()
        {
            RealEstate housingLowest = realEstates.OrderBy(x => x.Price).FirstOrDefault();
            return housingLowest;
        }

        public void RenameAgency(string newName)
        {
            this.Name = newName;
        }

        public void SellAllRealEstates()
        {
            realEstates.Clear();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (realEstates.Count > 0)
            {
                sb.AppendLine($"Agency {Name} has {realEstates.Count} real estate/s:");
                foreach (var housing in realEstates)
                {
                    sb.AppendLine($"Real Estate on {housing.Address} street costs {housing.Price:f2}.");
                }
                return sb.ToString();
            }
            return $"Agency {Name} has no available real estates.";

        }

    }
}


