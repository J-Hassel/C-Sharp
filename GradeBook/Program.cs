using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<int, Student> students = new Dictionary<int, Student>();     //key = studentID, value = Student object


            while(true)
            {
                // menu selection processing
                printMenu();
                input = Console.ReadLine();
                switch (input)
                {
                    case "A":
                    case "a":
                        addStudent(ref students);
                        break;

                    case "D":
                    case "d":
                        deleteStudent(ref students);
                        break;

                    case "P":
                    case "p":
                        printStudents(ref students);
                        break;

                    case "Q":
                    case "q":
                        return;                   
                }
            }

            
        }

        public static void addStudent(ref Dictionary<int, Student> students)
        {   // getting student information, then creating a new student and storing it in the data structure
            string fName, lName, major;
            int hw, proj, t1, t2, fin;

            Console.Write("First Name: ");
            fName = Console.ReadLine();

            Console.Write("Last Name: ");
            lName = Console.ReadLine();

            Console.Write("Major: ");
            major = Console.ReadLine();

            Console.Write("Homework Grade: ");
            hw = Int32.Parse(Console.ReadLine());

            Console.Write("Project Grade: ");
            proj = Int32.Parse(Console.ReadLine());

            Console.Write("Test 1 Grade: ");
            t1 = Int32.Parse(Console.ReadLine());

            Console.Write("Test 2 Grade: ");
            t2 = Int32.Parse(Console.ReadLine());

            Console.Write("Final Grade: ");
            fin = Int32.Parse(Console.ReadLine());

            Student stud = new Student(fName, lName, major, hw, proj, t1, t2, fin);
            students.Add(stud.getID(), stud);
        }

        public static void deleteStudent(ref Dictionary<int, Student> students)
        {   //removing 
            Console.Write("Enter the ID of the student to delete: ");
            int id = Int32.Parse(Console.ReadLine());

            students.Remove(id);
        }

        public static void printStudents(ref Dictionary<int, Student> students)
        {
            Console.WriteLine(string.Format("\n\n    {0, -10}{1, -24}{2, -30}{3}","ID", "Name", "Major", "Average"));
            Console.WriteLine("----------------------------------------------------------------------------");
            
            foreach(var key in students)
                key.Value.print();
        }

        public static void printMenu()
        {
            Console.WriteLine("\n\nA => Add Student");
            Console.WriteLine("D => Delete Student");
            Console.WriteLine("P => Print Students");
            Console.WriteLine("Q => Quit");
            Console.Write("  => ");

        }
    }

    public class Student
    {
        static int counter = 0;
        private string firstName, lastName, major;
        private int studentID, homework, project, test1, test2, final;
        double average;

        public Student()
        {
            studentID = ++counter;
            firstName = "Jon";
            lastName = "Smith";
            major = "Undeclared";
            homework = 0;
            project = 0;
            test1 = 0;
            test2 = 0;
            final = 0;
            average = 0;
        }

        public Student(string fName, string lName, string maj)
        {
            studentID = ++counter;
            firstName = fName;
            lastName = lName;
            major = maj;
            homework = 0;
            project = 0;
            test1 = 0;
            test2 = 0;
            final = 0;
            average = 0;
        }

        public Student(string fName, string lName, string maj, int hw, int proj, int t1, int t2, int fin)
        {
            studentID = ++counter;
            firstName = fName;
            lastName = lName;
            major = maj;
            homework = hw;
            project = proj;
            test1 = t1;
            test2 = t2;
            final = fin;
            average = calculateAverage();
        }

        public int getID() { return studentID; }

        public void setFirstName(string name) { firstName = name; }

        public string getFirstName() { return firstName; }

        public void setLastName(string name) { lastName = name; }

        public string getLastName() { return lastName; }

        public void setMajor(string maj) { major = maj; }

        public string getMajor() { return major; }

        public void setHomework(int grade) { homework = grade; }

        public int getHomework() { return homework; }

        public void setProject(int grade) { project = grade; }

        public int getProject() { return project; }

        public void setTest1(int grade) { test1 = grade; }

        public int getTest1() { return test1; }

        public void setTest2(int grade) { test1 = grade; }

        public int getTest2() { return test2; }

        public void setFinal(int grade) { test1 = grade; }

        public int getFinal() { return final; }

        public void setAverage(double grade) { average = grade; }

        public double getAverage() { return average; }

        public double calculateAverage()
        {
            return (0.10 * homework) + (0.10 * project) + (0.20 * test1) + (0.20 * test2) + (0.40 * final);
        }

        public void print()
        {
            Console.WriteLine(string.Format("    {0, -10}{1} {2, -20}{3, -30}{4}", studentID, firstName, lastName, major, average));
        }
    }
}
