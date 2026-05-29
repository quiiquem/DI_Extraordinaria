using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace di.repaso._2026.Backend.Modelo;

[Table("equipos")]
public partial class Equipo
{
    [Key]
    [StringLength(20)]
    public string Nombre { get; set; } = null!;

    [StringLength(20)]
    public string? Ciudad { get; set; }

    [StringLength(4)]
    public string? Conferencia { get; set; }

    [StringLength(9)]
    public string? Division { get; set; }

    [InverseProperty("NombreEquipoNavigation")]
    public virtual ICollection<Jugadore> Jugadores { get; set; } = new List<Jugadore>();

    [InverseProperty("EquipoLocalNavigation")]
    public virtual ICollection<Partido> PartidoEquipoLocalNavigations { get; set; } = new List<Partido>();

    [InverseProperty("EquipoVisitanteNavigation")]
    public virtual ICollection<Partido> PartidoEquipoVisitanteNavigations { get; set; } = new List<Partido>();
}
