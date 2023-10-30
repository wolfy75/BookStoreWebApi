using System.Net.Mime;
using Api.Context;
using Api.Entities;
using Api.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PublishersController : ControllerBase
{
    public PublishersController(BookStoreDbContext bookStoreDbContext)
    {
    }

    [HttpGet(Name = "GetPublishers")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(List<Publisher>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Publisher>>> GetPublishers()
    {
        return null;
    }
    
    [HttpGet]
    [Route("{id:int}", Name = "GetPublisherById")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(Publisher), StatusCodes.Status200OK)]
    public async Task<ActionResult<string>> GetPublisherById(int publisherId)
    {
        return null;
    }

    [HttpPost(Name = "CreatePublisher")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(Publisher), StatusCodes.Status201Created)]
    public ActionResult<string> CreatePublisher(CreatePublisherRequest createPublisherRequest)
    {
        return null;
    }

    [HttpPut(Name = "UpdatePublisher")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdatePublisher(UpdatePublisherRequest updatePublisherRequest)
    {
        return NoContent();
    }

    [HttpDelete]
    [Route("{id:int}", Name = "DeletePublisher")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeletePublisher(int id)
    {
        return NoContent();
    }
}