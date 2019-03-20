using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee ricky = new Employee { EmployeeID = 1, Name = "Ricky", Rating = 3 };
            Employee mike = new Employee { EmployeeID = 2, Name = "Mike", Rating = 4 };
            Employee marie = new Employee { EmployeeID = 3, Name = "Marie", Rating = 3 };
            Employee kenny = new Employee { EmployeeID = 4, Name = "Kenny", Rating = 5 };
            Employee olive = new Employee { EmployeeID = 5, Name = "Olive", Rating = 2 };

            Supervisor ronny = new Supervisor { EmployeeID = 6, Name = "Ronny", Rating = 5 };
            Supervisor dave = new Supervisor { EmployeeID = 7, Name = "Dave", Rating = 3 };

            ronny.AddSubordinate(ricky);
            ronny.AddSubordinate(mike);
            ronny.AddSubordinate(marie);

            dave.AddSubordinate(kenny);
            dave.AddSubordinate(olive);

            Console.WriteLine("\n--- Employee can see their Performance Summary ---");
            ricky.PerformanceSummary();

            Console.WriteLine("\n--- Supervisor can also see their subordinates Performance Summary ---");
            ronny.PerformanceSummary();

            Console.WriteLine("\nSubordinate Performance Record:");
            foreach(Employee employee in ronny.ListSubordinates)
            {
                employee.PerformanceSummary();
            }

        }

        public interface IEmployee
        {
            int EmployeeID { get; set; }
            string Name { get; set; }
            int Rating { get; set; }
            void PerformanceSummary();
        }

        public class Employee : IEmployee
        {
            public int EmployeeID { get; set; }
            public string Name { get; set; }
            public int Rating { get; set; }

            public void PerformanceSummary()
            {
                Console.WriteLine($"\nPerformance summary of employee: {Name} is {Rating} out of 5");
            }
        }

        public class Supervisor : IEmployee
        {
            public int EmployeeID { get; set; }
            public string Name { get; set; }
            public int Rating { get; set; }

            public List<IEmployee> ListSubordinates = new List<IEmployee>();

            public void PerformanceSummary()
            {
                Console.WriteLine($"\nPerformance summary of supervisor: {Name} is {Rating} out of 5");
            }

            public void AddSubordinate(IEmployee employee)
            {
                ListSubordinates.Add(employee);
            }
        }
    }
}
