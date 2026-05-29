using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace di.repaso._2026.Backend.Modelo;

[Table("jugadores")]
[Index("NombreEquipo", Name = "Nombre_equipo")]
public partial class Jugadore
{
    [Key]
    [Column("codigo")]
    public int Codigo { get; set; }

    [StringLength(30)]
    public string? Nombre { get; set; }

    [StringLength(20)]
    public string? Procedencia { get; set; }

    [StringLength(4)]
    public string? Altura { get; set; }

    public int? Peso { get; set; }

    [StringLength(5)]
    public string? Posicion { get; set; }

    [Column("Nombre_equipo")]
    [StringLength(20)]
    public string? NombreEquipo { get; set; }

    [InverseProperty("JugadorNavigation")]
    public virtual ICollection<Estadistica> Estadisticas { get; set; } = new List<Estadistica>();

    [ForeignKey("NombreEquipo")]
    [InverseProperty("Jugadores")]
    public virtual Equipo? NombreEquipoNavigation { get; set; }
}
