﻿using System;
using System.Collections.Generic;

namespace ApplyJobLibrary.Models;

public partial class Employee
{
    public string EmpId { get; set; } = null!;
    public string? EmpName { get; set; }
    public virtual ICollection<ApplyJob> ApplyJobs { get; set; } = new List<ApplyJob>();
}
