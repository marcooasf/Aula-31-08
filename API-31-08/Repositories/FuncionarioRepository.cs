using API_31_08.Infra;
using API_31_08.Models;
using Microsoft.EntityFrameworkCore;

namespace API_31_08.Repositories;

public interface IFuncionarioRepository
{
    Task<List<Funcionario>> ListarAsync();
    Task<List<Funcionario>> ListarPorSetorAsync(int setorId);
    Task<Funcionario?> ObterPorIdAsync(int id);
    Task AdicionarAsync(Funcionario Funcionario);
    Task<bool> ExisteAsync(int id);
    Task AtualizarAsync(Funcionario Funcionario);
    Task RemoverAsync(Funcionario Funcionario);
}

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly AppDbContext _context;
    public FuncionarioRepository(AppDbContext dbContext)
    {
        _context = dbContext;
    }

    private IQueryable<Funcionario> ComRelacionamento() =>
        _context.Funcionarios
            .Include(f => f.Setor)
            .Include(f => f.Enderecos);
    
    public async Task<List<Funcionario>> ListarAsync()
    {
        return await ComRelacionamento().AsNoTracking().ToListAsync();
    }

    public async Task<List<Funcionario>> ListarPorSetorAsync(int setorId)
    {
        return await ComRelacionamento()
            .Where(f => f.SetorId == setorId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Funcionario?> ObterPorIdAsync(int id)
    {
        return await ComRelacionamento().FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task AdicionarAsync(Funcionario Funcionario)
    {
        _context.Funcionarios.Add(Funcionario);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExisteAsync(int id)
    {
        return await ComRelacionamento().AnyAsync(f => f.Id == id);
    }

    public async Task AtualizarAsync(Funcionario Funcionario)
    {
        _context.Funcionarios.Update(Funcionario);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(Funcionario Funcionario)
    {
        _context.Funcionarios.Remove(Funcionario);
        await _context.SaveChangesAsync();
    }
}