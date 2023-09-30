using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    internal class Item
    {
        string name;
        double price, discount;
        public Item(string name, double price, double discount)
        {
            this.name = name;
            this.price = price;
            this.discount = discount;
        }
        public string Name
        {
            get { return name; }
        }
        public double getPrice()
        {
            return price;
        }
        public double getDiscount()
        {
            return discount;
        }
    }
}
