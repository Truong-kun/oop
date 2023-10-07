using System.Text;

namespace HW4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var bank = new Bank();
            Console.WriteLine(" - Thêm tài khoản:");
            bank.addAccount("001", "654", "Trường", 500, 5);
            bank.addAccount("002", "123", "Hải", 0, 5);
            bank.GenerateReport();

            Console.WriteLine("\n - Các thao tác với tài khoản:");
            bank.depositAccount("001", 500);
            bank.withdrawAccount("001", 100);
            bank.transferMoney("001", "002", 200);
            bank.GenerateReport();

            Console.WriteLine("\n - Tính lãi suất cho các tài khoản:");
            bank.CalculateInterestForAllAccounts();
            bank.GenerateReport();
        }
    }
}