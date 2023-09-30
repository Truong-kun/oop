using System.Text;

namespace HW3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var coca = new Item("Coca", 10000, 1000);
            var milk = new Item("Milk", 33000, 3000);
            var pie = new Item("Pie", 45000, 8000);

            var clerk = new employee("Trường", "0943371083", 12000000);

            var bill = new DiscountBill(clerk, true);
            bill.addItem(pie, 1);
            bill.addItem(milk, 2);
            bill.addItem(coca, 5);

            bill.printReceipt();
        }
    }
}