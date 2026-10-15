using System;
using System.Collections.Generic;

namespace CoursesAcademy.Models;

public partial class InstructorTeachCourse
{
    public int InstId { get; set; }

    public int CrsId { get; set; }

    public int? Evaluation { get; set; }

    public virtual Course Crs { get; set; } = null!;

    public virtual Instructor Inst { get; set; } = null!;
}
