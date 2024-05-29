
namespace Login.API.UsesCases.Auth.Signup
{
    public record SingupRequest(string Email, string Password, string UserName);
    public record SingnupResponse(string Token);

    public class SingupEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/singup",
                async (SingupRequest request, ISender sender) =>
                {
                    var command = request.Adapt<SingupCommand>();

                    var result = await sender.Send(command);

                    var response = result.Adapt<SingupResponse>();

                    return Results.Created("/singup", response);
                })
             .WithName("singup")
             .Produces<SingupResponse>(StatusCodes.Status201Created)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("singup")
             .WithDescription("singup");
        }
    }
}
