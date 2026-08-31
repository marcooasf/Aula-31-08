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
    private readonly AppDbContext _repository;
    public SetorService(AppDbContext repository)
    {
        _repository = repository;
    }
    public Task<List<Setor>> ListarAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Setor?> ObterPorIdAsync(int id)
    {
        
    }

    public async Task<Setor> CriarAsync(Setor setor)
    {
        await _repository.AddAsync(setor);
    }

    public async Task<bool> AtualizarAsync(int id, Setor setor)
    {
        var existente = await _repository.ObterPorIdAsync(setor.Id);
        if (existente == null) return false;
    }

    public async Task<(bool Removido, string? Erro)> ExcluirAsync(int id)
    {
        var setor = await _repository.ObterPorIdAsync(id);
        if (setor is null) return (false, null);

        if (setor.Funcionario.Any())
            return (false, "Não é possivel remover um setor que possui funcionario.");
    }
}