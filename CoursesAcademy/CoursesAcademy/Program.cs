using CoursesAcademy.Contexts;
using CoursesAcademy.HelpingFunctions;
using CoursesAcademy.Models;

namespace CoursesAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using CoursesAcademyDBContext context = new CoursesAcademyDBContext();
            bool statusFlag = true;
            int studentId, studentAge, courseId;
            string studentFName, studenLName;
            while (true) 
            {
                Console.WriteLine("Welcome to COURSES ACADEMY program :)");
                Console.WriteLine("Please choose the operation...");
                Console.WriteLine("\t1. Student operations");
                Console.WriteLine("\t2. Course operations");
                Console.WriteLine("\t0. Exit the program");
                var programInput = Console.ReadLine();
                switch (programInput)
                {
                    case "1":
                        while (true)
                        {
                            Console.WriteLine("Please choose the operation..." +
                                              "\n\t1. Get all students" +
                                              "\n\t2. Get student by Id" +
                                              "\n\t3. Update student by Id" +
                                              "\n\t4. Delete student by Id" +
                                              "\n\t5. Add new student" +
                                              "\n\t6. Courses taken by student" +
                                              "\n\t0. Back");
                            var studentInput = Console.ReadLine();
                            if (studentInput == "0") break;
                            else
                            {
                                switch (studentInput)
                                {
                                    case "1":
                                        statusFlag = StudentHF.GetAllStudents(context);
                                        if (statusFlag == false) Console.WriteLine("Error while trying to fetch data from DB!!");
                                        else Console.WriteLine("Data fetched successfully from the DB");
                                        break;
                                    case "2":
                                        Console.Write("Enter student Id: ");
                                        studentId = Convert.ToInt32(Console.ReadLine());
                                        statusFlag = StudentHF.GetStudentById(context , studentId);
                                        if (statusFlag == false) Console.WriteLine("Error while trying to fetch data from DB!!");
                                        else Console.WriteLine("Data fetched successfully from the DB");
                                        break;
                                    case "3":
                                        Console.Write("Enter student Id: ");
                                        studentId = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Enter student new FName: ");
                                        studentFName = Console.ReadLine();
                                        Console.Write("Enter student new LName: ");
                                        studenLName = Console.ReadLine();
                                        statusFlag = StudentHF.UpdateStudentById(context, studentId , studentFName , studenLName);
                                        if (statusFlag == false) Console.WriteLine("Error while trying to Update data into the DB!!");
                                        else Console.WriteLine("Data Updated successfully into the DB");
                                        break;
                                    case "4":
                                        Console.Write("Enter student Id: ");
                                        studentId = Convert.ToInt32(Console.ReadLine());
                                        statusFlag = StudentHF.RemoveStudentById(context , studentId);
                                        if (statusFlag == false) Console.WriteLine("Error while trying to delete data from DB!!");
                                        else Console.WriteLine("Data deleted successfully from the DB");
                                        break;
                                    case "5":
                                        Console.Write("Enter student FName: ");
                                        studentFName = Console.ReadLine();
                                        Console.Write("Enter student LName: ");
                                        studenLName = Console.ReadLine();
                                        Console.Write("Enter student age: ");
                                        studentAge = Convert.ToInt16(Console.ReadLine());
                                        statusFlag = StudentHF.AddNewStudent(context , studentFName , studenLName , studentAge);
                                        if (statusFlag == false) Console.WriteLine("Error while trying to add data into the DB!!");
                                        else Console.WriteLine("Data added successfully into the DB");
                                        break;
                                    case "6":
                                        Console.Write("Enter student Id: ");
                                        studentId = Convert.ToInt32(Console.ReadLine());
                                        statusFlag = StudentTakeCoursesHF.GetCoursesById(context, studentId);
                                        if (statusFlag == false) Console.WriteLine("Error while trying to fetch data from DB!!");
                                        else Console.WriteLine("Data fetched successfully from the DB");
                                        break;
                                    default:
                                        Console.WriteLine("Invalid input please try again!!");
                                        break;
                                }
                            }
                        }
                        break;
                    case "2":
                        while (true)
                        {
                            Console.WriteLine("Please choose the operation..." +
                                              "\n\t1. Get all courses" +
                                              "\n\t2. Get course by Id" +
                                              "\n\t0. Back");
                            var studentInput = Console.ReadLine();
                            if (studentInput == "0") break;
                            else
                            {
                                switch (studentInput)
                                {
                                    case "1":
                                        statusFlag = CourseHF.GetAllCourses(context);
                                        if (statusFlag == false) Console.WriteLine("Error while trying to fetch data from DB!!");
                                        else Console.WriteLine("Data fetched successfully from the DB");
                                        break;
                                    case "2":
                                        Console.Write("Enter course Id: ");
                                        courseId = Convert.ToInt32(Console.ReadLine());
                                        statusFlag = CourseHF.GetCourseById(context, courseId);
                                        if (statusFlag == false) Console.WriteLine("Error while trying to fetch data from DB!!");
                                        else Console.WriteLine("Data fetched successfully from the DB");
                                        break;
                                    default:
                                        Console.WriteLine("Invalid input please try again!!");
                                        break;
                                }
                            }
                        }
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid input please try again!!");
                        break;
                }
            }
        }
    }
}
