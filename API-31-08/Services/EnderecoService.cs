using API_31_08.Models;
using API_31_08.Repositories;

namespace API_31_08.Services;
public interface IEnderecoService
{
    Task<List<Endereco?>> ListarPorFuncionarioAsync(int funcionarioId);
    Task<Endereco?> ObterPorIdAsync(int id);
    Task<Endereco?> CriarAsync(int funcionarioId, Endereco endereco);
    Task<Endereco?> AtualizarAsync(int id, Endereco endereco);
    Task<bool> RemoverAsync(int id);
}

public class EnderecoService : IEnderecoService
{
    public readonly IEnderecoRepository _repository;
    public readonly IFuncionarioRepository _funcionarioRepository;
    
    public EnderecoService(IEnderecoRepository repository,  IFuncionarioRepository funcionarioRepository)
    {
        _repository = repository;
        _funcionarioRepository = funcionarioRepository;
    }
    
    public async Task<List<Endereco?>> ListarPorFuncionarioAsync(int funcionarioId)
    {
        if(!await _funcionarioRepository.ExisteAsync(funcionarioId)) return null;
        return await _repository.ListarPorFuncionarioAsync(funcionarioId);
    }

    public Task<Endereco?> ObterPorIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Endereco?> CriarAsync(int funcionarioId, Endereco endereco)
    {
        throw new NotImplementedException();
    }

    public Task<Endereco?> AtualizarAsync(int id, Endereco endereco)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoverAsync(int id)
    {
        throw new NotImplementedException();
    }
}