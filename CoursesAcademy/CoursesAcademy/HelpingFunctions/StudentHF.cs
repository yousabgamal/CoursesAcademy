using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursesAcademy.Contexts;
using CoursesAcademy.Models;
using Microsoft.EntityFrameworkCore;

namespace CoursesAcademy.HelpingFunctions
{
    public class StudentHF
    {
        public static bool GetAllStudents(CoursesAcademyDBContext context)
        {
            bool statusFlag = true;
            if (context != null) 
            {
                try
                {
                    var studentsData = context.Students.AsNoTracking().ToList();
                    Console.WriteLine($"{"Student Id",-5}|{"Student Name",-15}|{"Department Id",-10}|{"Department name"}");
                    Console.WriteLine(new string('-', 56));
                    foreach (var student in studentsData)
                    {
                        Console.WriteLine($"{student.Id,-10}|{student.Fname + " " + student.Lname,-15}|{student.DptId,-13}|{student.Dpt.Name}");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error: {ex.InnerException?.Message ?? ex.Message}");
                    statusFlag = false;
                }
            }
            else
            {
                statusFlag = false;
            }
            return statusFlag;
        }
        public static bool GetStudentById(CoursesAcademyDBContext context , int studentId)
        {
            bool statusFlag = true;
            if (context != null) 
            {
                try
                {
                    var student = context.Students.AsNoTracking().FirstOrDefault(s => s.Id == studentId);
                    Console.WriteLine($"{"Id",-5}|{"Name",-20}|{"Department Id"}");
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine($"{student.Id,-5}|{student.Fname + " " + student.Lname,-20}|{student.DptId}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error: {ex.InnerException?.Message ?? ex.Message}");
                    statusFlag = false;
                }
            }
            else
            {
                statusFlag = false;
            }
            return statusFlag;
        }
        public static bool UpdateStudentById(CoursesAcademyDBContext context , int studentId , string fName , string lName)
        {
            bool statusFlag = true;
            if (context != null) 
            {
                try
                {
                    var student = context.Students.FirstOrDefault(s => s.Id == studentId);
                    student.Fname = fName;
                    student.Lname = lName;
                    context.SaveChanges();
                    Console.WriteLine($"{"Id",-5}|{"Name",-20}|{"Department Id"}");
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine($"{student.Id,-5}|{student.Fname + " " + student.Lname,-20}|{student.DptId}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error: {ex.InnerException?.Message ?? ex.Message}");
                    statusFlag = false;
                }
            }
            else
            {
                statusFlag = false;
            }
            return statusFlag;
        }
        public static bool RemoveStudentById(CoursesAcademyDBContext context , int studentId)
        {
            bool statusFlag = true;
            if (context != null) 
            {
                try
                {
                    var student = context.Students.FirstOrDefault(s => s.Id == studentId);
                    var enrollments = context.StudentTakeCourses.Where(e => e.StdId == studentId).ToList();
                    context.StudentTakeCourses.RemoveRange(enrollments);
                    context.Students.Remove(student);
                    context.SaveChanges();
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error: {ex.InnerException?.Message ?? ex.Message}");
                    statusFlag = false;
                }
            }
            else
            {
                statusFlag = false;
            }
            return statusFlag;
        }
        public static bool AddNewStudent(CoursesAcademyDBContext context, string fName, string lName , int age)
        {
            bool statusFlag = true;
            if (context != null)
            {
                try
                {
                    var student = context.Students.Add(new Student
                    {
                        Fname = fName,
                        Lname = lName,
                        Age = age
                    });
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.InnerException?.Message ?? ex.Message}");
                    statusFlag = false;
                }
            }
            else
            {
                statusFlag = false;
            }
            return statusFlag;
        }
    }
}
