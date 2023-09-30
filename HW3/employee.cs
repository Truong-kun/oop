using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    internal class employee
    {
        public string name, phone;
        double salary;
        public employee(string name, string phone, double salary)
        {
            this.name = name;
            this.salary = salary;
            this.phone = phone;
        }
    }
}
