using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebHeladeria.Models;

public partial class Empleado
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es requerido")]
    [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
    public string Nombres { get; set; } = null!;

    [Required(ErrorMessage = "El primer apellido es requerido")]
    [StringLength(100, ErrorMessage = "El primer apellido no puede exceder 100 caracteres")]
    public string PrimerApellido { get; set; } = null!;

    [StringLength(100, ErrorMessage = "El segundo apellido no puede exceder 100 caracteres")]
    public string? SegundoApellido { get; set; }

    [Required(ErrorMessage = "El teléfono es requerido")]
    [StringLength(15, ErrorMessage = "El teléfono no puede exceder 15 caracteres")]
    [RegularExpression(@"^\d{7,15}$", ErrorMessage = "El teléfono debe contener solo números (7-15 dígitos)")]
    public string Telefono { get; set; } = null!;

    [Required(ErrorMessage = "La dirección es requerida")]
    [StringLength(250, ErrorMessage = "La dirección no puede exceder 250 caracteres")]
    public string Direccion { get; set; } = null!;

    [Required(ErrorMessage = "Debe seleccionar un cargo")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un cargo válido")]
    public int IdCargo { get; set; }

    public string? UsuarioRegistro { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public short? Estado { get; set; }

    public virtual Cargo IdCargoNavigation { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}