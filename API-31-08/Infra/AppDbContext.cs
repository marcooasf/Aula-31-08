using API_31_08.Models;
using Microsoft.EntityFrameworkCore;

namespace API_31_08.Infra;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Setor> Setores => Set<Setor>();
    public DbSet<Funcionario> Funcionarios => Set<Funcionario>();
    public DbSet<Endereco> Enderecos => Set<Endereco>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Setor>()
            .HasMany(s => s.Funcionarios)
            .WithOne(s => s.Setor)
            .HasForeignKey(s => s.SetorId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Funcionario>()
            .HasMany(s => s.Enderecos)
            .WithOne(s => s.Funcionario)
            .HasForeignKey(s => s.FuncionarioId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}