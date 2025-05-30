using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Models;

public class InfoSystem
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
}