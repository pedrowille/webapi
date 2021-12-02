using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using webapi.Models;

namespace webapi.Controllers
{
[ApiController]
[Route("[controller]")]
public class ProdutosController : ControllerBase
{
 [HttpGet]   
public List<Produtos> GetProdutos()
{
    return new Produtos().SelecionarProdutos();
}
}
}