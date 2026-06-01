using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace di.repaso._2026.Backend.Modelo;

public partial class NbaContext : DbContext
{
    public NbaContext()
    {
    }

    public NbaContext(DbContextOptions<NbaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<Estadistica> Estadisticas { get; set; }

    public virtual DbSet<Jugadore> Jugadores { get; set; }

    public virtual DbSet<Partido> Partidos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;database=nba;user=root;password=mysql");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.Nombre).HasName("PRIMARY");
        });

        modelBuilder.Entity<Estadistica>(entity =>
        {
            entity.HasKey(e => new { e.Temporada, e.Jugador }).HasName("PRIMARY");

            entity.HasOne(d => d.JugadorNavigation).WithMany(p => p.Estadisticas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("estadisticas_ibfk_1");
        });

        modelBuilder.Entity<Jugadore>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PRIMARY");

            entity.HasOne(d => d.NombreEquipoNavigation).WithMany(p => p.Jugadores).HasConstraintName("jugadores_ibfk_1");
        });

        modelBuilder.Entity<Partido>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PRIMARY");

            entity.HasOne(d => d.EquipoLocalNavigation).WithMany(p => p.PartidoEquipoLocalNavigations).HasConstraintName("partidos_ibfk_1");

            entity.HasOne(d => d.EquipoVisitanteNavigation).WithMany(p => p.PartidoEquipoVisitanteNavigations).HasConstraintName("partidos_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
