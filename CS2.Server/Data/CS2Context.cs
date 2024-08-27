using System;
using System.Collections.Generic;
using CS2.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace CS2.Server.Data;

public partial class CS2Context : DbContext
{
    public CS2Context(DbContextOptions<CS2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("players");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.TeamId, "teamId_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IngameName)
                .HasMaxLength(45)
                .HasColumnName("ingame_name");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Nationality)
                .HasMaxLength(45)
                .HasColumnName("nationality");
            entity.Property(e => e.PlayerName)
                .HasMaxLength(45)
                .HasColumnName("player_name");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.TeamId).HasColumnName("teamId");

            entity.HasOne(d => d.Team).WithMany(p => p.Players)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("teamId");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("teams");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Region)
                .HasMaxLength(45)
                .HasColumnName("region");
            entity.Property(e => e.TeamName)
                .HasMaxLength(45)
                .HasColumnName("team_name");
            entity.Property(e => e.TournamentWins).HasColumnName("tournament_wins");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
