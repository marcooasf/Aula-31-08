using API_31_08.Infra;
using API_31_08.Models;
using Microsoft.EntityFrameworkCore;

namespace API_31_08.Repositories;

public interface IEnderecoRepository
{
    Task<List<Endereco>> ListarPorFuncionarioAsync(int funcionarioId);
    Task<Endereco?> ObterPorIdAsync(int id);
    Task AdicionarAsync(Endereco endereco);
    Task AtualizarAsync(Endereco endereco);
    Task RemoverAsync(Endereco endereco);
}

public class EnderecoRepository : IEnderecoRepository
{
    public readonly AppDbContext _context;
    public EnderecoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Endereco>> ListarPorFuncionarioAsync(int funcionarioId)
    {
        return await _context.Enderecos
            .Where(e => e.FuncionarioId == funcionarioId)
            .AsNoTracking()
            .ToListAsync();
    }
    
    public async Task<Endereco?> ObterPorIdAsync(int id)
    {
        return await _context.Enderecos.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task AdicionarAsync(Endereco endereco)
    {
        _context.Enderecos.Add(endereco);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Endereco endereco)
    {
        _context.Enderecos.Update(endereco);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(Endereco endereco)
    {
        _context.Enderecos.Remove(endereco);
        await _context.SaveChangesAsync();
    }
}