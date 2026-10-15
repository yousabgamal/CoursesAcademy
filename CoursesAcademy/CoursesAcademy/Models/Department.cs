using System;
using System.Collections.Generic;

namespace CoursesAcademy.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly HiringDate { get; set; }

    public int? InstId { get; set; }

    public virtual Instructor? Inst { get; set; }

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
