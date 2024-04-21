using System;
using System.Collections.Generic;
using System.Text;

namespace RegularExamOOP
{
    public class RealEstate
    {

        public RealEstate(string address, double price)
        {
            this.Address = address;
            this.Price = price;
        }

        private string address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        private double price;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                if (value > 1000000)
                {
                    throw new ArgumentException("Invalid real estate price!"); 
                }
              
            }
        }

        public override string ToString()
        {
            return $"Real Estate on {address} street costs {price:f2}.";
        }
    }
}