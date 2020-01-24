using System;
using System.Collections.Generic;

namespace StudentMongoDB
{
    public class StudentConsole
    {
        public void StudentTask()
        {
            // Repository studentRepository = new Repository("Student");
            GenericRepository<Student> studentRepository = new GenericRepository<Student>("Student");
            while (true)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("|    For GetAllStudents     select 1|");
                Console.WriteLine("|    For get by id          select 2|");
                Console.WriteLine("|    For insert             select 3|");
                Console.WriteLine("|    For update             select 4|");
                Console.WriteLine("|    For Delete             select 5|");
                Console.WriteLine("|    For Quit               select 0|");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("    Enter the Option:");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 0)
                {
                    break;
                }
                switch (option)
                {
                    case 1:
                    {
                        IEnumerable<Student> allStudent = studentRepository.GetAll();
                        Console.WriteLine("Student Table: ");
                        foreach (var i in allStudent)
                        {
                            Console.WriteLine("ID: "+i.Id + "\tName: " + i.Name + "\tDept: " + i.Dept);
                        }

                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("Enter the id:");
                        string id = (Console.ReadLine());
                        Student newStudent = studentRepository.GetById(id);
                        Console.WriteLine("ID: "+newStudent.Id + "\tName: " + newStudent.Name + "\tDept: " + newStudent.Dept);
                        break;
                    }
                    case 3:
                    {
                        Student student = GetStudent();
                        studentRepository.Insert(student);
                        Console.WriteLine(student.Name+" Added");
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("Enter The Id (For Update): ");
                        string id = Console.ReadLine();
                        Student student = GetStudent();
                        Student newStudent = studentRepository.Update(student, id);
                        Console.WriteLine(student.Name+" Updated");
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("Enter The Id (For Delete): ");
                        string id = Console.ReadLine();
                        Student student = studentRepository.Delete(id);
                        Console.WriteLine(student.Name+" Deleted");
                        break;
                    }
                    default:
                        Console.WriteLine("invalid input");
                        break;
                }
            }
        }
        private static Student GetStudent()
        {  
            Console.WriteLine("Please enter student id : ");  
            string id = (Console.ReadLine()); 
            
            Console.WriteLine("Please enter student name : ");  
            string name = Console.ReadLine();

            Console.WriteLine("Please enter dept name : ");  
            string dept = Console.ReadLine();

            Student student = new Student(id, name, dept);
            return student;  
        }
    }
}