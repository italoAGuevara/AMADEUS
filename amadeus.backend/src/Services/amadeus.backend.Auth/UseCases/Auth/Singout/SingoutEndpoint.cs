
using Microsoft.AspNetCore.Mvc;

namespace Login.API.UsesCases.Auth.Signout
{
    public record SingoutRequest(string Token);
    public record SingnoutResponse(bool IsSuccess);


    public class SingoutEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/singout",
                async (SingoutRequest request, ISender sender) =>
                {
                    var command = request.Adapt<SingoutCommand>();

                    var result = await sender.Send(command);

                    var response = result.Adapt<SingoutResponse>();

                    return Results.Created("/singout", response);
                })
             .WithName("singout")
             .Produces<SingoutResponse>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("sing out")
             .WithDescription("sing out");
        }
    }
}
