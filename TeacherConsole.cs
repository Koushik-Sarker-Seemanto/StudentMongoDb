using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentMongoDB
{
    public class TeacherConsole
    {
        public void TeacherTask()
        {
            //var teacherRepository = new GenericRepository<Teacher>(new AppDbContext(new DbContextOptions<AppDbContext>() ));
            //Repository teacherRepository = new Repository("Teacher");
            GenericRepository<Teacher> teacherRepository = new GenericRepository<Teacher>("Teacher");
            while (true)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("|    For GetAllTeachers     select 1|");
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
                if (option == 1)
                {
                    IEnumerable<Teacher> allTeachers = teacherRepository.GetAll();
                    // IEnumerable<Teacher> allTeachers = teacherRepository.GetAllStudents<Teacher>();
                    Console.WriteLine("Teacher Table: ");
                    foreach (var i in allTeachers)
                    {
                        Console.WriteLine("ID: "+i.Id + "\tName: " + i.Name + "\tDept: " + i.Dept+"\tType: "+i.Type);
                    }
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter the id:");
                    string id = (Console.ReadLine());
                    Teacher newTeacher = teacherRepository.GetById(id);
                    // Teacher newTeacher = teacherRepository.GetStudentById<Teacher>(id);
                    Console.WriteLine("ID: "+newTeacher.Id + "\tName: " + newTeacher.Name + "\tDept: " + newTeacher.Dept+"\tType: "+newTeacher.Type);
                }
                else if (option == 3)
                {
                    Teacher teacher = GetTeacher();
                    Teacher newTeacher = teacherRepository.Insert(teacher);
                    Console.WriteLine(newTeacher.Name+" Inserted");
                    // teacherRepository.InsertStudent<Teacher>(teacher);
                }
                else if (option == 4)
                {
                    Console.WriteLine("Enter The Id (For Update): ");
                    string id = Console.ReadLine();
                    Teacher teacher = GetTeacher();
                    Teacher newTeacher = teacherRepository.Update(teacher, id);
                    Console.WriteLine(newTeacher.Name+" Updated");
                    // teacherRepository.UpdateStudent<Teacher>(teacher, id);
                }
                else if (option == 5)
                {
                    Console.WriteLine("Enter The Id (For Delete): ");
                    string id = Console.ReadLine();
                    Teacher teacher = teacherRepository.Delete(id);
                    Console.WriteLine(teacher.Name + " deleted");
                    // teacherRepository.DeleteStudent<Teacher>(id);
                }
                else
                {
                    Console.WriteLine("invalid input");
                }
            }
        }
        private static Teacher GetTeacher()
        {  
            Console.WriteLine("Please enter Teacher id : ");  
            string id = (Console.ReadLine()); 
            
            Console.WriteLine("Please enter Teacher name : ");  
            string name = Console.ReadLine();

            Console.WriteLine("Please enter dept name : ");  
            string dept = Console.ReadLine();
            
            Console.WriteLine("Please enter Type : ");  
            string type = Console.ReadLine();

            Teacher teacher = new Teacher(id, name, dept, type);
            return teacher;  
        }
    }
}