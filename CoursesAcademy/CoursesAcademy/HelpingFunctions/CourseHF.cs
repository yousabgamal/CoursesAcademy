using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursesAcademy.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CoursesAcademy.HelpingFunctions
{
    internal class CourseHF
    {
        public static bool GetAllCourses(CoursesAcademyDBContext context)
        {
            bool statusFlag = true;
            if (context != null)
            {
                try
                {
                    var coursesData = context.Courses.ToList();
                    Console.WriteLine($"{"Course Id",-9}|{"Course name",-27}|{"Description",-52}|{"Total students take course"}");
                    Console.WriteLine(new string('-', 117));
                    foreach (var course in coursesData)
                    {
                        Console.WriteLine($"{course.Id,-9}|{course.Name,-27}|{course.Description,-52}|{course.StudentTakeCourses.Count()}");
                    }
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
        public static bool GetCourseById(CoursesAcademyDBContext context , int courseId)
        {
            bool statusFlag = true;
            if (context != null)
            {
                try
                {
                    var course = context.Courses.FirstOrDefault(c => c.Id == courseId);
                    Console.WriteLine($"{"Course Id",-9}|{"Course name",-27}|{"Description",-52}|{"Total students take course"}");
                    Console.WriteLine(new string('-', 117));
                    Console.WriteLine($"{course.Id,-9}|{course.Name,-27}|{course.Description,-52}|{course.StudentTakeCourses.Count()}");
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
