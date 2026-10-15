using System;
using System.Collections.Generic;

namespace CoursesAcademy.Models;

public partial class StudentTakeCourse
{
    public int StdId { get; set; }

    public int CrsId { get; set; }

    public int? Grade { get; set; }

    public virtual Course Crs { get; set; } = null!;

    public virtual Student Std { get; set; } = null!;
}
