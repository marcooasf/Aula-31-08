using API_31_08.Models;
using API_31_08.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_31_08.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FuncionarioController : ControllerBase
{
    private readonly IFuncionarioService _service;

    public FuncionarioController(IFuncionarioService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Funcionario>>> Listar([FromQuery] int? setorId)
    {
        return Ok(await _service.ListarAsync(setorId));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<Funcionario>>> BuscarPorId(int id)
    {
        var funcionario = await _service.ObterPorIdAsync(id);
        return funcionario is null ? NotFound() : Ok(funcionario);
    }

    [HttpPost]
    public async Task<ActionResult<Funcionario>> Criar(Funcionario funcionario)
    {
        var (criado, erro) = await _service.CriarAsync(funcionario);
        if(erro is not null) return BadRequest(new{mensagem = erro});
        return CreatedAtAction(nameof(BuscarPorId), new { id = criado!.Id }, criado);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Funcionario>> Atualizar(Funcionario funcionario, int id)
    {
        var (atualizado, erro) = await _service.AtualizarAsync(id, funcionario);
        if (atualizado) NoContent();
        return erro is null ? NotFound() : BadRequest(new{mensagem = erro});
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Funcionario>> Remover(int id)
    {
        var removido = await _service.RemoverAsync(id);
        return removido ? NoContent() : NotFound();
    }
}