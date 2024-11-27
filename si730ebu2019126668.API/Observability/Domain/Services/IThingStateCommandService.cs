
using si730ebu2019126668.API.Observability.Domain.Model.Aggregates;
using si730ebu2019126668.API.Observability.Domain.Model.Commands;

namespace si730ebu2019126668.API.Observability.Domain.Services;

public interface IThingStateCommandService
{
    Task<ThingState?> Handle(CreateThingStateCommand command);
}