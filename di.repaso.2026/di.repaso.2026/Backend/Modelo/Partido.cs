using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace di.repaso._2026.Backend.Modelo;

[Table("partidos")]
[Index("EquipoLocal", Name = "equipo_local")]
[Index("EquipoVisitante", Name = "equipo_visitante")]
public partial class Partido
{
    [Key]
    [Column("codigo")]
    public int Codigo { get; set; }

    [Column("equipo_local")]
    [StringLength(20)]
    public string? EquipoLocal { get; set; }

    [Column("equipo_visitante")]
    [StringLength(20)]
    public string? EquipoVisitante { get; set; }

    [Column("puntos_local")]
    public int? PuntosLocal { get; set; }

    [Column("puntos_visitante")]
    public int? PuntosVisitante { get; set; }

    [Column("temporada")]
    [StringLength(5)]
    public string? Temporada { get; set; }

    [ForeignKey("EquipoLocal")]
    [InverseProperty("PartidoEquipoLocalNavigations")]
    public virtual Equipo? EquipoLocalNavigation { get; set; }

    [ForeignKey("EquipoVisitante")]
    [InverseProperty("PartidoEquipoVisitanteNavigations")]
    public virtual Equipo? EquipoVisitanteNavigation { get; set; }
}
