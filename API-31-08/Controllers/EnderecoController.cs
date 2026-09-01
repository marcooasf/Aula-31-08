using API_31_08.Models;
using API_31_08.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;

namespace API_31_08.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnderecoController
{
   private readonly IEnderecoService _enderecoService;
   
   public EnderecoController(IEnderecoService enderecoService) => _enderecoService = enderecoService;

   /*[HttpGet]
   public async Task<ActionResult<List<Endereco>?>> ListarPorFuncionario(int funcionarioId) =>
   Ok(await _enderecoService.ListarPorFuncionarioAsync(funcionarioId));*/
   
}