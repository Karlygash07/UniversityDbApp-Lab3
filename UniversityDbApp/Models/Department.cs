using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityDbApp.Models;

public class Department
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
