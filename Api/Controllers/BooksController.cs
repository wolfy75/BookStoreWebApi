using System.Net.Mime;
using Api.Context;
using Api.Entities;
using Api.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class BooksController : ControllerBase
{
   private readonly BookStoreDbContext bookStoreDbContext;

   public BooksController(BookStoreDbContext bookStoreDbContext)
   {
      this.bookStoreDbContext = bookStoreDbContext;
   }

   [HttpGet(Name = "GetBooks")]
   [Consumes(MediaTypeNames.Application.Json)]
   [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
   public async Task<IActionResult> GetBooks()
   {
      var books = await bookStoreDbContext.Books.ToListAsync();

      return Ok(books);
   }

   [HttpGet]
   [Route("{authorId:int}", Name = "GetBooksByAuthorId")]
   [Consumes(MediaTypeNames.Application.Json)]
   [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
   public async Task<IActionResult> GetBooksByAuthorId(int authorId)
   {
      var books = await bookStoreDbContext.Books
         .Where(book => book.Authors.Any(author => author.Id == authorId))
         .ToListAsync();

      return Ok(books);
   }

   [HttpPost(Name = "CreateBook")]
   [Consumes(MediaTypeNames.Application.Json)]
   [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
   public async Task<IActionResult> CreateBook(CreateBookRequest createBookRequest)
   {
      var authors = await bookStoreDbContext.Authors.Where(author => createBookRequest.AuthorIds.Contains(author.Id)).ToListAsync();

      var bookToCreate = new Book
      {
         Title = createBookRequest.Title,
         NumberOfPages = createBookRequest.NumberOfPages,
         DateOfPublish = createBookRequest.DateOfPublish,
         PublisherId = createBookRequest.PublisherId,
         Authors = authors
      };

      bookStoreDbContext.Books.Add(bookToCreate);
      await bookStoreDbContext.SaveChangesAsync();

      return Ok(bookToCreate);
   }

   [HttpPut(Name = "UpdateBook")]
   [Consumes(MediaTypeNames.Application.Json)]
   [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
   public async Task<IActionResult> UpdateBook(UpdateBookRequest updateBookRequest)
   {
      var authors = await bookStoreDbContext.Authors.Where(author => updateBookRequest.AuthorIds.Contains(author.Id)).ToListAsync();
      
      var bookToUpdate = bookStoreDbContext.Books.Include(b => b.Authors).SingleOrDefault(book => book.Id == updateBookRequest.Id); 

      bookToUpdate.Title = updateBookRequest.Title;
      bookToUpdate.NumberOfPages = updateBookRequest.NumberOfPages;
      bookToUpdate.DateOfPublish = updateBookRequest.DateOfPublish;
      bookToUpdate.PublisherId = updateBookRequest.PublisherId;
      bookToUpdate.Authors = authors;

      bookStoreDbContext.Books.Update(bookToUpdate);
      await bookStoreDbContext.SaveChangesAsync();
      
      return NoContent();
   }
   
   [HttpDelete]
   [Route("{id:int}", Name = "DeleteBook")]
   [Consumes(MediaTypeNames.Application.Json)]
   [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
   public async Task<IActionResult> DeleteBook(int id)
   {
      var bookToDelete = await bookStoreDbContext.Books.FindAsync(id);
      bookStoreDbContext.Books.Remove(bookToDelete);
      await bookStoreDbContext.SaveChangesAsync();
        
      return NoContent();
   }
}