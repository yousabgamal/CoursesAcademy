using System;
using System.Collections.Generic;

namespace CoursesAcademy.Models;

public partial class Instructor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Bonus { get; set; }

    public decimal Salary { get; set; }

    public decimal HourRate { get; set; }

    public string? Address { get; set; }

    public int? DptId { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual Department? Dpt { get; set; }

    public virtual ICollection<InstructorTeachCourse> InstructorTeachCourses { get; set; } = new List<InstructorTeachCourse>();
}
