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
}

