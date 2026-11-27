using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudUsuarios.Models;

[Table("Usuarios")]
public class Usuario
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El perfil es obligatorio")]
    [StringLength(20)]
    public string Perfil { get; set; } = string.Empty;

    [Required(ErrorMessage = "El correo es obligatorio")]
    [EmailAddress(ErrorMessage = "Formato de correo no válido")]
    [StringLength(100)]
    [Display(Name = "Correo electronico")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "La edad es obligatoria")]
    [Range(1, 120, ErrorMessage = "La edad debe estar entre 1 y 120")]
    public int Edad { get; set; }

    [Display(Name = "Esta activo?")]
    public bool Activo { get; set; }

    [Display(Name = "Fecha de registro")]
    public DateTime FechaRegistro { get; set; } = DateTime.Now;

    [Range(0, 9999999.99, ErrorMessage = "El balance no puede ser negativo")]
    [Column(TypeName = "decimal(10,2)")]
    [Display(Name = "Balance actual")]
    public decimal Balance { get; set; }
}
