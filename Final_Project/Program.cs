using System;
using System.Collections.Generic;
using System.IO;

namespace SmartSchoolSystem
{
    class Student
    {
        public int Enrollment { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public List<string> Classes { get; set; }
        public string GuardianName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Student(int enrollment, string name, int grade, List<string> classes, string guardianName, string address, string phoneNumber, string email)
        {
            Enrollment = enrollment;
            Name = name;
            Grade = grade;
            Classes = classes;
            GuardianName = guardianName;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public override string ToString()
        {
            return $"Enrollment: {Enrollment}\nName: {Name}\nGrade: {Grade}\nClasses: {string.Join(", ", Classes)}\nGuardian Name: {GuardianName}\nAddress: {Address}\nPhone Number: {PhoneNumber}\nEmail: {Email}\n";
        }
    }

    class Program
    {
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            LoadDataFromFile("students.txt");

            while (true)
            {
                Console.WriteLine("Welcome to Smart School System");
                Console.WriteLine("1. Add New Student");
                Console.WriteLine("2. Search Student");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        SearchStudent();
                        break;
                    case 3:
                        UpdateStudent();
                        break;
                    case 4:
                        DeleteStudent();
                        break;
                    case 5:
                        SaveDataToFile("students.txt");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        static void LoadDataFromFile(string filename)
        {
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    List<string> classes = new List<string>(data[3].Split(';'));
                    Student student = new Student(Convert.ToInt32(data[0]), data[1], Convert.ToInt32(data[2]), classes, data[4], data[5], data[6], data[7]);
                    students.Add(student);
                }
            }
        }

        static void SaveDataToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Student student in students)
                {
                    writer.WriteLine($"{student.Enrollment},{student.Name},{student.Grade},{string.Join(";", student.Classes)},{student.GuardianName},{student.Address},{student.PhoneNumber},{student.Email}");
                }
            }
        }

        static void AddStudent()
        {
            Console.WriteLine("Enter Enrollment:");
            int enrollment = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Grade:");
            int grade = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Classes (separated by ';'):");
            string[] classesArray = Console.ReadLine().Split(';');
            List<string> classes = new List<string>(classesArray);

            Console.WriteLine("Enter Guardian Name:");
            string guardianName = Console.ReadLine();

            Console.WriteLine("Enter Address:");
            string address = Console.ReadLine();

            Console.WriteLine("Enter Phone Number:");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Email:");
            string email = Console.ReadLine();

            Student newStudent = new Student(enrollment, name, grade, classes, guardianName, address, phoneNumber, email);
            students.Add(newStudent);
            Console.WriteLine("Student added successfully.");
        }

        static void SearchStudent()
        {
            Console.WriteLine("Enter Enrollment to search:");
            int enrollment = Convert.ToInt32(Console.ReadLine());

            Student student = students.Find(s => s.Enrollment == enrollment);
            if (student != null)
            {
                Console.WriteLine(student);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        static void UpdateStudent()
        {
            Console.WriteLine("Enter Enrollment to update:");
            int enrollment = Convert.ToInt32(Console.ReadLine());

            Student student = students.Find(s => s.Enrollment == enrollment);
            if (student != null)
            {
                Console.WriteLine("Enter New Name:");
                student.Name = Console.ReadLine();

                Console.WriteLine("Enter New Grade:");
                student.Grade = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter New Classes (separated by ';'):");
                string[] classesArray = Console.ReadLine().Split(';');
                student.Classes = new List<string>(classesArray);

                Console.WriteLine("Enter New Guardian Name:");
                student.GuardianName = Console.ReadLine();

                Console.WriteLine("Enter New Address:");
                student.Address = Console.ReadLine();

                Console.WriteLine("Enter New Phone Number:");
                student.PhoneNumber = Console.ReadLine();

                Console.WriteLine("Enter New Email:");
                student.Email = Console.ReadLine();

                Console.WriteLine("Student updated successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        static void DeleteStudent()
        {
            Console.WriteLine("Enter Enrollment to delete:");
            int enrollment = Convert.ToInt32(Console.ReadLine());

            Student student = students.Find(s => s.Enrollment == enrollment);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine("Student deleted successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}
