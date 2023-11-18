using MediatR;
using MyShop.API.Infrastructure;
using MyShop.Application.TodoLists.Queries.GetWeatherForecasts;

namespace MyShop.API.Endpoints;

public class WeatherForecasts : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
           //.RequireAuthorization()
            .MapGet(GetWeatherForecasts);
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts(ISender sender)
    {
        return await sender.Send(new GetWeatherForecastsQuery());
    }
}
