using System;
using System.Collections.Generic;

namespace Students_database.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;
}
