using System;
using System.Collections.Generic;

namespace EmpSkillLibrary.Models;

public partial class Employee
{
    public string EmpId { get; set; } = null!;
<<<<<<< HEAD

    public string EmpName { get; set; } = null!;

=======
    public string? EmpName { get; set; }
>>>>>>> 60fdf2143fccfdf94a75b90043f90213a432568e
    public virtual ICollection<EmpSkill> EmpSkills { get; set; } = new List<EmpSkill>();
}
