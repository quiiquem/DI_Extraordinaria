using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using di.repaso._2026.MVVM.Base;
using Microsoft.EntityFrameworkCore;

namespace di.repaso._2026.Backend.Modelo;

[Table("jugadores")]
[Index("NombreEquipo", Name = "Nombre_equipo")]
public partial class Jugadore : ValidatableViewModel
{
    [Key]
    [Column("codigo")]
    public int Codigo { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [MaxLength(30, ErrorMessage = "El máximo de carácteres es de 30.")]
    [StringLength(30)]
    public string? Nombre { get; set; }

    [MaxLength(20, ErrorMessage = "El máximo de carácteres es de 20.")]
    [StringLength(20)]
    public string? Procedencia { get; set; }

    [Required(ErrorMessage ="La altura es obligatoria.")]
    [MaxLength(4, ErrorMessage ="Máximo 4 carácteres.")]
    [StringLength(4)]
    public string? Altura { get; set; }

    [Required(ErrorMessage = "El peso es obligatorio.")]
    [Range(minimum:100, maximum:350, ErrorMessage ="El peso indicado no está permitido")]
    public int? Peso { get; set; }


    [StringLength(5)]
    [Required(ErrorMessage = "La posición es obligatoria")]
    public string? Posicion { get; set; }

    [Required(ErrorMessage = "El equipo es obligatorio")]
    [Column("Nombre_equipo")]
    [StringLength(20)]
    public string? NombreEquipo { get; set; }

    [InverseProperty("JugadorNavigation")]
    public virtual ICollection<Estadistica> Estadisticas { get; set; } = new List<Estadistica>();

    [ForeignKey("NombreEquipo")]
    [InverseProperty("Jugadores")]
    public virtual Equipo? NombreEquipoNavigation { get; set; }
}
