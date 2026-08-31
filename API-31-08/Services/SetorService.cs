using API_31_08.Infra;
using API_31_08.Models;

namespace API_31_08.Services;

public interface ISetorService
{
    Task<List<Setor>> ListarAsync();
    Task<Setor?> ObterPorIdAsync(int id);
    Task<Setor> CriarAsync(Setor setor);
    Task<bool> AtualizarAsync(int id, Setor setor);
    Task<(bool Removido, string? Erro)> ExcluirAsync(int id);
}

public class SetorService : ISetorService
{
    private readonly AppDbContext _context;
    public SetorService(AppDbContext context)
    {
        _context = context;
    }
    public Task<List<Setor>> ListarAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Setor?> ObterPorIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Setor> CriarAsync(Setor setor)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AtualizarAsync(int id, Setor setor)
    {
        throw new NotImplementedException();
    }

    public Task<(bool Removido, string? Erro)> ExcluirAsync(int id)
    {
        throw new NotImplementedException();
    }
}