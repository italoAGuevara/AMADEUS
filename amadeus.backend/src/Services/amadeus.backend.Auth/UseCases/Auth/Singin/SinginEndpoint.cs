namespace Login.API.UsesCases.Auth.Signin
{
    public record SigninRequest(string Email, string Password);
    public record SigninResponse(string Token);

    public class SinginEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/auth",
                async (SigninRequest request, ISender sender) =>
                {
                    var command = request.Adapt<SinginCommand>();

                    var result = await sender.Send(command);

                    var response = result.Adapt<SigninResponse>();

                    return Results.Created("/auth", response);
                })
             .WithName("Singin")
             .Produces<SigninResponse>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("Singin")
             .WithDescription("Singin");
        }    
    
    }
}
