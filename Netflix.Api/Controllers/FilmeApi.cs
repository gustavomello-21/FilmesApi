using Microsoft.AspNetCore.Mvc;
using Netflix.Api.Models;
using Netflix.Api.Services;

namespace Netflix.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeApi : ControllerBase
{
    private readonly IFilmeService _filmeService;

    public FilmeApi(IFilmeService filmeService)
    {
        _filmeService = filmeService;
    }

    [HttpPost]
    public IActionResult Create(Filme filme)
    {
        if(_filmeService.SalvarFilme(filme))
        {
            return Ok();
        }
        else
        {
            return BadRequest("Falha ao salvar");
        }
    }

    [HttpGet]
    public IEnumerable<Filme> Get()
    {
        return _filmeService.ListarFilmes();
    }

    [HttpPut]
    public IActionResult Update(filme Filme)
    {
        if (_filmeService.AlterarFilme(filme))
        {
            return Ok();
        }
        else
        {
            return BadRequest("Falha ao atualizar o filme");
        }
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var filme = _filmeService.ObterFilme(id);

        if (filme == null)
        {
            return NotFound("falha ao encontrar o filme");
        }
        else
        {
            return Ok(filme);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        if (_filmeService.DeletarFilme(id))
        {
            return Ok("Livro deletado");
        }
        else
        {
            return BadRequest("");
        }
    }
}
