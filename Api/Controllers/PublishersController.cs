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
public class PublishersController : ControllerBase
{
    private readonly BookStoreDbContext bookStoreDbContext;
    public PublishersController(BookStoreDbContext bookStoreDbContext)
    {
        this.bookStoreDbContext = bookStoreDbContext;
    }

    [HttpGet(Name = "GetPublishers")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(List<Publisher>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Publisher>>> GetPublishers()
    {
        var publishers = await bookStoreDbContext.Publishers.ToListAsync();

        return publishers;
    }
    
    [HttpGet]
    [Route("{publisherId:int}", Name = "GetPublisherById")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(Publisher), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPublisherById(int publisherId)
    {
        var publisher = await bookStoreDbContext.Publishers.FindAsync(publisherId);
        if (publisher is null)
        {
            return NotFound();
        }
        
        return Ok(publisher);
    }

    [HttpPost(Name = "CreatePublisher")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(Publisher), StatusCodes.Status201Created)]
    public async Task<ActionResult<Publisher>> CreatePublisher(CreatePublisherRequest createPublisherRequest)
    {
        var publisher = new Publisher
        {
            Name = createPublisherRequest.Name
        };

        bookStoreDbContext.Publishers.Add(publisher);

        var numberOfRowsInserted = await bookStoreDbContext.SaveChangesAsync();

        return publisher;
    }

    [HttpPut(Name = "UpdatePublisher")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdatePublisher(UpdatePublisherRequest updatePublisherRequest)
    {
        var publisherToUpdate = await bookStoreDbContext.Publishers.FindAsync(updatePublisherRequest.Id);
        publisherToUpdate.Name = updatePublisherRequest.Name;
        await bookStoreDbContext.SaveChangesAsync();
        
        return NoContent();
    }

    [HttpDelete]
    [Route("{id:int}", Name = "DeletePublisher")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeletePublisher(int id)
    {
        var publisherToDelete = await bookStoreDbContext.Publishers.FindAsync(id);
        bookStoreDbContext.Publishers.Remove(publisherToDelete);
        await bookStoreDbContext.SaveChangesAsync();
        
        return NoContent();
    }
}