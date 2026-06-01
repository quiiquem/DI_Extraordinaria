using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using di.repaso._2026.MVVM.Base;
using Microsoft.EntityFrameworkCore;

namespace di.repaso._2026.Backend.Modelo;

[Table("equipos")]
public partial class Equipo : ValidatableViewModel
{
    [Key]
    [StringLength(20)]
    [MaxLength(20, ErrorMessage = "No puede ser más largo de 20 carácteres")]
    [Required(ErrorMessage ="El nombre del equipo es obligatorio")]
    public string Nombre { get; set; } = null!;

    [StringLength(20)]
    [MaxLength(20, ErrorMessage ="No puede ser más largo de 20 carácteres")]
    [Required(ErrorMessage = "La ciudad es obligatorio")]
    public string? Ciudad { get; set; }

    [StringLength(4)]
    [Required(ErrorMessage = "La conferencia es obligatorio")]
    public string? Conferencia { get; set; }

    [StringLength(9)]
    [Required(ErrorMessage = "La división es obligatoria")]
    public string? Division { get; set; }

    [InverseProperty("NombreEquipoNavigation")]
    public virtual ICollection<Jugadore> Jugadores { get; set; } = new List<Jugadore>();

    [InverseProperty("EquipoLocalNavigation")]
    public virtual ICollection<Partido> PartidoEquipoLocalNavigations { get; set; } = new List<Partido>();

    [InverseProperty("EquipoVisitanteNavigation")]
    public virtual ICollection<Partido> PartidoEquipoVisitanteNavigations { get; set; } = new List<Partido>();
}
