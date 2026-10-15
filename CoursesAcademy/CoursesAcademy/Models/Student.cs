using System;
using System.Collections.Generic;

namespace CoursesAcademy.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public int Age { get; set; }

    public string? Address { get; set; }

    public int? DptId { get; set; }

    public virtual Department? Dpt { get; set; }

    public virtual ICollection<StudentTakeCourse> StudentTakeCourses { get; set; } = new List<StudentTakeCourse>();
}
