using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    internal class Person
    {
        private static List<Person> personList;
        private static int top = 0;
        string name, address;
        int salary;
        public string Name
        {
            get { return name; }
            set {
                if (value != null) name = value;
                else name = "Unknown";
            }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public int Salary
        {
            get { return salary; }
            set { 
                if (value >= 0) salary = value;
            }
        }
        public Person() { }
        public Person(string name, string address, int salary)
        {
            Name = name;
            Address = address;
            Salary = salary;
        }
        public void inputPersonInfo()
        {
            personList = new List<Person>();
            Console.WriteLine("Enter infomation of person: ");
            string name, address;
            int salary;
            while (true)
            {
                Console.Write(" - Name: ");
                name = Console.ReadLine();
                if (name != "") break;
                Console.WriteLine("[!] Name mustn't be empty");
            }
            while (true)
            {
                Console.Write(" - Address: ");
                address = Console.ReadLine();
                if (address != "") break;
                Console.WriteLine("[!] Name mustn't be empty");
            }
            while (true)
            {
                try
                {
                    Console.Write(" - Salary: ");
                    salary = int.Parse(Console.ReadLine());
                }
                catch
                {
                    throw new Exception("[!] Salary must be a number");
                }
                if (salary > 0) break;
            }
            Name = name;
            Address = address;
            Salary = salary;
        }
        public void showPersonInfo()
        {
            Console.WriteLine("Information Entered: ");
            Console.WriteLine("Name    : " + Name);
            Console.WriteLine("Address : " + Address);
            Console.WriteLine("Salary  : " + Salary);
        }
        public static List<Person> sortBySalary(List<Person> personList)
        {
            if (personList.Count == 0) throw new Exception("Can't sort an empty list");
            else
            {
                for (int i = 0; i < personList.Count - 1; i++)
                {
                    for (int j = i + 1; j < personList.Count; j++)
                    {
                        if (personList[i].Salary > personList[j].Salary)
                        {
                            var t = personList[i];
                            personList[i] = personList[j];
                            personList[j] = t;
                        }
                    }
                }

                return personList;
            }
        }
    }
}
