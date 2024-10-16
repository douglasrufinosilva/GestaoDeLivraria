using GestaoDeLivraria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeLivraria.Controllers;
[Route("[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpGet("generos")]
    [ProducesResponseType(typeof(List<Gender>), StatusCodes.Status200OK)]
    public IActionResult GetGenders()
    {
        var genders = Enum.GetNames(typeof(Gender)).ToList();
        return Ok(genders);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        List<Book> books = new List<Book>()
        {
            new Book { Id = 1, Author = "Douglas", Title = "Teste" , Gender = Gender.Romance, Price = 19.90m, Stock = 20 },
            new Book { Id = 2, Author = "Rufino", Title = "livro" , Gender = Gender.Terror, Price = 49.90m, Stock = 10 }
        };

        if(books.Count == 0)
        {
            return NoContent();
        }

        return Ok(books);
    }
}
