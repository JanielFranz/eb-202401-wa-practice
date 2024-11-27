using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using si730ebu2019126668.API.Inventory.Domain.Model.Aggregates;
using si730ebu2019126668.API.Inventory.Domain.Model.Commands;
using si730ebu2019126668.API.Inventory.Domain.Model.Queries;
using si730ebu2019126668.API.Inventory.Domain.Services;
using si730ebu2019126668.API.Inventory.Interfaces.REST.Resources;
using si730ebu2019126668.API.Inventory.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace si730ebu2019126668.API.Inventory.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Things Endpoints")]
public class ThingsController
    (IThingCommandService thingCommandService, IThingQueryService thingQueryService)
    : ControllerBase
{

    [HttpGet("{thingId:int}")]
    [SwaggerOperation("Get Thing", "Get a Thing by its ID")]
    [SwaggerResponse(StatusCodes.Status200OK, "The Thing was found", typeof(Thing))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The Thing was not found")]

    public async Task<IActionResult> GetThingById([FromRoute] int thingId)
    {
        var getThingByIdQuery = new GetThingByIdQuery(thingId);
        var thing = await thingQueryService.Handle(getThingByIdQuery);
        if (thing is null) return NotFound();
        var thingResource = ThingResourceFromEntityAssembler.ToResourceFromEntity(thing);
        return Ok(thingResource);
    }
    
    
    
    
    
    
    [HttpPost]
    [SwaggerOperation("Create Thing", "Create a new Thing")]
    [SwaggerResponse(StatusCodes.Status201Created, "The Thing was created", typeof(Thing))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Thing was not created")]
    public async Task<IActionResult> CreateThing([FromBody] CreateThingResource resource)
    {
        var createThingCommand = CreateThingCommandFromResourceAssembler.ToCommandFromResource(resource);
        var thing = await thingCommandService.Handle(createThingCommand);

        if (thing is null) return BadRequest();

        var thingResource = ThingResourceFromEntityAssembler.ToResourceFromEntity(thing);

        return CreatedAtAction(nameof(GetThingById), new { thingId = thing.Id }, thingResource);
    }
}