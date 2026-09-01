using API_31_08.Models;
using API_31_08.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;

namespace API_31_08.Controllers;

[ApiController]
[Route("api/funcionario/{FuncionarioId:int}/[controller]")]
public class EnderecoController :  ControllerBase
{
   private readonly IEnderecoService _service;
   
   public EnderecoController(IEnderecoService enderecoService) => _service = enderecoService;

   [HttpGet]
   public async Task<ActionResult<List<Endereco>?>> ListarPorFuncionario(int funcionarioId)
   {
      var enderecos = await _service.ListarPorFuncionarioAsync(funcionarioId);
      return enderecos is null ? NotFound() : Ok(enderecos);
   }

   [HttpGet("{id}", Name = "ObterEndereco")]
   public async Task<ActionResult<Endereco>> Obter(int funcionarioId, int id)
   {
      var endereco = await _service.ObterAsync(id);
      
      if(endereco is null || endereco.FuncionarioId != funcionarioId)
         return NotFound();
      return Ok(endereco);
   }
   
}