using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    internal abstract class GroceryBill
    {
        protected employee clerk;
        protected List<BillLine> billLines;
        public GroceryBill(employee clerk)
        {
            this.clerk = clerk;
            billLines = new List<BillLine>();
        }
        public void addItem(Item item, int quantity)
        {
            billLines.Add(new BillLine(item, quantity));
        }
        public abstract double getTotal();
        public abstract void printReceipt();
    }
    class BillLine
    {
        Item Item;
        int quantity;
        public BillLine(Item item, int quantity)
        {
            this.Item = item;
            this.quantity = quantity;
        }
        public Item getItem()
        {
            return Item;
        }
        public int getQuantity()
        {
            return quantity;
        }
    }
    class DiscountBill : GroceryBill
    {
        double discount;
        bool referred;
        public double TotalPrice
        {
            get
            {
                double total = 0;
                foreach (BillLine line in billLines)
                {
                    total += line.getQuantity() * line.getItem().getPrice();
                }
                return total;
            }
        }
        public DiscountBill(employee clerk, bool referred) : base(clerk)
        {
            this.referred = referred;
        }
        public int getDiscountCount()
        {
            if (referred)
            {
                int count = 0;
                foreach (BillLine line in billLines)
                {
                    if (line.getItem().getDiscount() != 0) count++;
                }
                return count;
            }
            return 0;
        }
        public double getDiscountAmount()
        {
            double total = 0;
            foreach (BillLine line in billLines)
            {
                double discount = line.getItem().getDiscount();
                if (discount != 0) total += discount * line.getQuantity();
            }
            return total;
        }
        public double getDiscountPercent()
        {
            return getDiscountAmount() / TotalPrice * 100;
        }
        public override double getTotal()
        {
            return TotalPrice - getDiscountAmount();
        }
        public override void printReceipt()
        {
            Console.WriteLine("\t\t\tRECEIPT\n");
            Console.WriteLine($"Created clerk: {clerk.name, -20}\n");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"| {"Grocery Name", 15} | {"Quantity", 8} | {"Price", 8} |");
            Console.WriteLine("-----------------------------------------");
            foreach (BillLine line in billLines)
            {
                Console.WriteLine($"| {line.getItem().Name,15} | {line.getQuantity(),8} | {line.getItem().getPrice(),8} |");
            }
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($" - Total :                     {TotalPrice,8}");
            Console.WriteLine($" - Discount (%) :              {Math.Round(getDiscountPercent(), 0),8}%");
            Console.WriteLine($" - Total Discount :            {getDiscountAmount(),8}");
            Console.WriteLine($"                               {getTotal(),8}");
        }
    }
}
