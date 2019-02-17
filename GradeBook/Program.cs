using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Student> students = new List<Student>();


            while(true)
            {
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
                        printStudents(students);
                        break;

                    case "Q":
                    case "q":
                        return;                   
                }
            }

            
        }

        public static void addStudent(ref List<Student> students)
        {
            Console.WriteLine("addStudent");
        }

        public static void deleteStudent(ref List<Student> students)
        {
            Console.WriteLine("deleteStudent");
        }

        public static void printStudents(List<Student> students)
        {
            Console.WriteLine(string.Format("\n    {0, -10}{1, -14}{2, -20}{3}","ID", "Name", "Major", "Average"));
            Console.WriteLine("--------------------------------------------------------");
            
            foreach(var student in students)
                student.print();
        }

        public static void printMenu()
        {
            Console.WriteLine("A => Add Student");
            Console.WriteLine("D => Delete Student");
            Console.WriteLine("P => Print Students");
            Console.WriteLine("Q => Quit");
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
        }

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
            Console.WriteLine(string.Format("    {0, -10}{1} {2, -10}{3, -20}{4}", studentID, firstName, lastName, major, average));
        }
    }
}
