using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee List from 3rd party organization system.");
            Console.WriteLine("------------------------------------------------------");

            ITarget adapter = new EmployeeAdapter();

            foreach(string employee in adapter.GetEmployees())
            {
                Console.WriteLine(employee);
            }
        }
    }

    class ThirdPartyEmployee
    {
        public List<string> GetEmployeeList()
        {
            List<string> EmployeeList = new List<string>();
            EmployeeList.Add("Peter");
            EmployeeList.Add("Paul");
            EmployeeList.Add("Puru");
            EmployeeList.Add("Preethi");
            return EmployeeList;
        }
    }

    interface ITarget
    {
        List<string> GetEmployees();
    }

    class EmployeeAdapter : ThirdPartyEmployee, ITarget
    {
        public List<string> GetEmployees()
        {
            return GetEmployeeList();
        }
    }
}
