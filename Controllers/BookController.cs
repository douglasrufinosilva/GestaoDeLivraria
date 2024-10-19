using GestaoDeLivraria.Communication.Requests;
using GestaoDeLivraria.Communication.Responses;
using GestaoDeLivraria.Enums;
using GestaoDeLivraria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeLivraria.Controllers;
[Route("[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private static List<Book> books = new List<Book>()
    {
        new Book { Id = 1, Author = "Douglas", Title = "Teste" , Gender =  Genders.Ficção, Price = 19.90m, Stock = 20 },
        new Book { Id = 2, Author = "Rufino", Title = "livro" , Gender = Genders.Misterio, Price = 49.90m, Stock = 10 }
    };

    [HttpGet("generos")]
    [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
    public IActionResult GetGenders()
    {
        var genders = Enum.GetNames(typeof(Genders)).ToList();

        return Ok(genders);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        if (books.Count == 0)
        {
            return NoContent();
        }

        return Ok(books);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseCreatedBookJson), StatusCodes.Status201Created)]

    public IActionResult Create([FromBody] Book request)
    {
        Book book = new Book()
        {
            Author = request.Author,
            Title = request.Title,
            Gender = request.Gender,
            Price = request.Price,
            Stock = request.Stock,
            Id = request.Id
        };

        books.Add(book);

        ResponseCreatedBookJson response = new ResponseCreatedBookJson
        {
            Id = book.Id,
            Title = book.Title
        };

        return Created(string.Empty, response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public IActionResult DeleteBook([FromRoute] int id)
    {
        var book = books.FirstOrDefault(book => book.Id == id);

        if(book == null)
        {
            return NotFound($"Livro com o ID {id} não encontrado.");
        }

        books.Remove(book);

        return NoContent();
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public IActionResult UpdateBook([FromRoute] int id, [FromBody] RequestUpdateBookJson request)
    {
        var book = books.FirstOrDefault(book => book.Id == id);

        if(book == null)
        {
            return NotFound($"Livro com o ID {id} não encontrado.");
        }

        book.Title = request.Title;
        book.Author = request.Author;
        book.Gender = request.Gender;
        book.Price = request.Price;
        book.Stock = request.Stock;

        return NoContent();
    }
}