using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using src.Requests;
using src.Responses;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class BooksController : ControllerBase
{
    [HttpGet(Name = "GetBooks")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Book>>> GetBooks()
    {
        return null;
    }
    
    [HttpGet]
    [Route("{id:int}", Name = "GetBooksByAuthorId")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public async Task<ActionResult<string>> GetBooksByAuthorId(int authorId)
    {
        return null;
    }
    
    [HttpPost(Name = "CreateBook")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
    public ActionResult<string> CreateBook(CreateBookRequest createBookRequest)
    {
        return null;
    }
    
    [HttpPut(Name = "UpdateBook")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateBook(UpdateBookRequest updateBookRequest)
    {
        return NoContent();
    }
}