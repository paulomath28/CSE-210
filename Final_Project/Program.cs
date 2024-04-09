using System;
using System.Collections.Generic;
using System.IO;

namespace SmartSchoolSystem
{
    class Person
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    class Student : Person
    {
        public int Enrollment { get; set; }
        public int Grade { get; set; }
        public List<string> Classes { get; set; }
        public string GuardianName { get; set; }
    }

    class Teacher : Person
    {
        public string Subject { get; set; }
        public List<int> Grades { get; set; }
    }

    class Program
    {
        static List<Student> students = new List<Student>();
        static List<Teacher> teachers = new List<Teacher>();

        static void Main(string[] args)
        {
            LoadStudentsDataFromFile("students.txt");

            while (true)
            {
                Console.WriteLine("Welcome to Smart School System");
                Console.WriteLine("1. Add New Student");
                Console.WriteLine("2. Search Student");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Register Teacher");
                Console.WriteLine("6. Update Teacher");
                Console.WriteLine("7. Delete Teacher");
                Console.WriteLine("8. Exit");

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
                        RegisterTeacher();
                        break;
                    case 6:
                        UpdateTeacher();
                        break;
                    case 7:
                        DeleteTeacher();
                        break;
                    case 8:
                        SaveStudentsDataToFile("students.txt");
                        SaveTeachersDataToFile("teachers.txt");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        static void LoadStudentsDataFromFile(string filename)
        {
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    List<string> classes = new List<string>(data[3].Split(';'));
                    Student student = new Student
                    {
                        Enrollment = Convert.ToInt32(data[0]),
                        FullName = data[1],
                        Grade = Convert.ToInt32(data[2]),
                        Classes = classes,
                        GuardianName = data[4],
                        Address = data[5],
                        PhoneNumber = data[6],
                        Email = data[7]
                    };
                    students.Add(student);
                }
            }
        }

        static void SaveStudentsDataToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Student student in students)
                {
                    writer.WriteLine($"{student.Enrollment},{student.FullName},{student.Grade},{string.Join(";", student.Classes)},{student.GuardianName},{student.Address},{student.PhoneNumber},{student.Email}");
                }
            }
        }

        // Method for manipulating students

        static void AddStudent()
        {
            Console.WriteLine("Enter Enrollment:");
            int enrollment = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Full Name:");
            string fullName = Console.ReadLine();

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

            Student newStudent = new Student
            {
                Enrollment = enrollment,
                FullName = fullName,
                Grade = grade,
                Classes = classes,
                GuardianName = guardianName,
                Address = address,
                PhoneNumber = phoneNumber,
                Email = email
            };
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
                Console.WriteLine("Enter New Full Name:");
                student.FullName = Console.ReadLine();

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

        // Methods for manipulating teachers

        static void RegisterTeacher()
        {
            Console.WriteLine("Enter Full Name of Teacher:");
            string fullName = Console.ReadLine();

            Console.WriteLine("Enter Subject:");
            string subject = Console.ReadLine();

            Console.WriteLine("Enter Grades (separated by ';'):");
            string[] gradesArray = Console.ReadLine().Split(';');
            List<int> grades = new List<int>();
            foreach (string grade in gradesArray)
            {
                if (int.TryParse(grade, out int parsedGrade))
                {
                    grades.Add(parsedGrade);
                }
                else
                {
                    Console.WriteLine($"Invalid grade: {grade}");
                }
            }

            Teacher newTeacher = new Teacher
            {
                FullName = fullName,
                Subject = subject,
                Grades = grades
            };
            teachers.Add(newTeacher);
            Console.WriteLine("Teacher registered successfully.");
        }

        static void SaveTeachersDataToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Teacher teacher in teachers)
                {
                    writer.WriteLine($"{teacher.FullName},{teacher.Subject},{string.Join(";", teacher.Grades)}");
                }
            }
        }

        static void UpdateTeacher()
        {
            Console.WriteLine("Enter Full Name of Teacher to update:");
            string fullName = Console.ReadLine();

            Teacher teacher = teachers.Find(t => t.FullName == fullName);
            if (teacher != null)
            {
                Console.WriteLine("Enter New Full Name:");
                teacher.FullName = Console.ReadLine();

                Console.WriteLine("Enter New Subject:");
                teacher.Subject = Console.ReadLine();

                Console.WriteLine("Enter New Grades (separated by ';'):");
                string[] gradesArray = Console.ReadLine().Split(';');
                List<int> grades = new List<int>();
                foreach (string grade in gradesArray)
                {
                    if (int.TryParse(grade, out int parsedGrade))
                    {
                        grades.Add(parsedGrade);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid grade: {grade}");
                    }
                }
                teacher.Grades = grades;

                Console.WriteLine("Teacher updated successfully.");
            }
            else
            {
                Console.WriteLine("Teacher not found.");
            }
        }

        static void DeleteTeacher()
        {
            Console.WriteLine("Enter Full Name of Teacher to delete:");
            string fullName = Console.ReadLine();

            Teacher teacher = teachers.Find(t => t.FullName == fullName);
            if (teacher != null)
            {
                teachers.Remove(teacher);
                Console.WriteLine("Teacher deleted successfully.");
            }
            else
            {
                Console.WriteLine("Teacher not found.");
            }
        }
    }
}
