using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using api_msg.Models;

namespace api_msg.Context;

public partial class ApiContext : DbContext
{
    public ApiContext()
    {
    }

    public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
    {
        
    }

    public virtual DbSet<Mensagem> Mensagems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();// Adquirindo as configurações do arquivo appsettings.json utilizando a interface
                 //IConfiguration que traz as funcionalidades de leitura de arquivos de configuração

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultString"));


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mensagem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mensagem_pkey");

            entity.ToTable("mensagem");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Msg)
                .HasMaxLength(500)
                .HasColumnName("msg");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Mensagems)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_mensagens_id_user");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pkey");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.Numero)
                .HasMaxLength(11)
                .HasColumnName("numero");
            entity.Property(e => e.Senha)
                .HasMaxLength(16)
                .HasColumnName("senha");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
