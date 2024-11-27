using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using si730ebu2019126668.API.Observability.Domain.Model.Aggregates;
using si730ebu2019126668.API.Observability.Domain.Services;
using si730ebu2019126668.API.Observability.Interfaces.REST.Resources;
using si730ebu2019126668.API.Observability.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace si730ebu2019126668.API.Observability.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Things Endpoints")]
public class ThingStatesController(IThingStateCommandService thingStateCommandService) : ControllerBase
{

    [HttpPost]
    [SwaggerOperation("Create Thing", "Create a new Thing State")]
    [SwaggerResponse(StatusCodes.Status201Created, "The Thing State was created", typeof(ThingState))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Thing State was not created")]
    public async Task<IActionResult> CreateThingState([FromBody] CreateThingStateResource resource)
    {
        var createThingStateCommand = CreateThingStateCommandFromResourceAssembler.ToCommandFromResource(resource);
        var thingState = await thingStateCommandService.Handle(createThingStateCommand);

        if (thingState is null) return BadRequest();

        var thingStateResource = ThingStateResourceFromEntityAssembler.ToResourceFromEntity(thingState);

        return Ok(thingStateResource);
    }
}