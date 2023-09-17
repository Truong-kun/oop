using System.Text;

namespace HW2
{
    internal class Program
    {
        static List<Person> personList = new List<Person>();
        static void showPersonList()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"| {"Name",25} | {"Address",20} | {"Salary",10} |");
            Console.WriteLine("-----------------------------------------------------------------");
            foreach (var p in personList)
            {
                Console.WriteLine($"| {p.Name,25} | {p.Address,20} | {p.Salary,10} |");
            }
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Console.Write("Nhập số người muốn nhập thông tin: ");
            int n;
            while (true)
            {
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out n)) break;
                Console.WriteLine("[!] Số người phải lớn hơn 0");
            }
            for (int i = 0; i < n; i++)
            {
                var person = new Person();
                person.inputPersonInfo();
                personList.Add(person);
            }
            Console.WriteLine("\t\t\tPERSON LIST\n");
            showPersonList();
            personList = Person.sortBySalary(personList);
            Console.WriteLine("\t\t\tSORTED PERSON LIST\n");
            showPersonList();
        }
    }
}