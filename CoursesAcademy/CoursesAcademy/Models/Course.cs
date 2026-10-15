using System;
using System.Collections.Generic;

namespace CoursesAcademy.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Duration { get; set; }

    public string Description { get; set; } = null!;

    public int? TopicId { get; set; }

    public virtual ICollection<InstructorTeachCourse> InstructorTeachCourses { get; set; } = new List<InstructorTeachCourse>();

    public virtual ICollection<StudentTakeCourse> StudentTakeCourses { get; set; } = new List<StudentTakeCourse>();

    public virtual Topic? Topic { get; set; }
}
