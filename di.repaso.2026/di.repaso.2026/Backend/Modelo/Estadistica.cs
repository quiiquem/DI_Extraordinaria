using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace di.repaso._2026.Backend.Modelo;

[PrimaryKey("Temporada", "Jugador")]
[Table("estadisticas")]
[Index("Jugador", Name = "jugador")]
public partial class Estadistica
{
    [Key]
    [Column("temporada")]
    [StringLength(5)]
    public string Temporada { get; set; } = null!;

    [Key]
    [Column("jugador")]
    public int Jugador { get; set; }

    [Column("Puntos_por_partido")]
    public float? PuntosPorPartido { get; set; }

    [Column("Asistencias_por_partido")]
    public float? AsistenciasPorPartido { get; set; }

    [Column("Tapones_por_partido")]
    public float? TaponesPorPartido { get; set; }

    [Column("Rebotes_por_partido")]
    public float? RebotesPorPartido { get; set; }

    [ForeignKey("Jugador")]
    [InverseProperty("Estadisticas")]
    public virtual Jugadore JugadorNavigation { get; set; } = null!;
}
