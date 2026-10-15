using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursesAcademy.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CoursesAcademy.HelpingFunctions
{
    internal class StudentTakeCoursesHF
    {
        public static bool GetCoursesById(CoursesAcademyDBContext context, int studentId)
        {
            bool statusFlag = true;
            if (context != null)
            {
                try
                {
                    var studentData = context.StudentTakeCourses.AsNoTracking().Where(sc => sc.StdId == studentId).ToList();
                    Console.WriteLine($"{"Student Id",-10}|{"Student name",-20}|{"Course name",-27}|{"Grade"}");
                    Console.WriteLine(new string('-', 65));
                    foreach (var data in studentData)
                    {
                        Console.WriteLine($"{data.StdId,-10}|{data.Std.Fname + " " + data.Std.Lname,-20}|{data.Crs.Name,-27}|{data.Grade}");
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
    }
}
