using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Models;

public class Employee
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Position { get; set; } = string.Empty;

    [Required]
    [StringLength(128)]
    public string Department { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Place { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string InfoSystem { get; set; } = string.Empty;

    [Required]
    [StringLength(30)]
    public string Login { get; set; } = string.Empty;

    //[Required]
    //[Phone]
    //[RegularExpression(@"^\+7\d{10}$", ErrorMessage = "Номер телефона должен быть в формате +7XXXXXXXXXX")]
    //public string Phone { get; set; } = string.Empty;

    [Phone]
    [StringLength(20)]
    [RegularExpression(@"^\d{3}-\d{2}-\d{2}$", ErrorMessage = "Неверный формат номера XXX-XX-XX")]
    public string PhoneOut { get; set; } = string.Empty;

    [Phone]
    [StringLength(10)]
    public string PhoneIn { get; set; } = string.Empty;

    //[Required]
    //[EmailAddress]
    //public string Email { get; set; } = string.Empty;
} 