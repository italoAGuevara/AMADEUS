namespace Login.API.UsesCases.Auth.RefreshToken
{
    public record RefreshTokenRequest(string Token);

    public class RefreshTokenEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/refreshtoken",
                async (RefreshTokenRequest request, ISender sender) =>
                {
                    var command = request.Adapt<RefreshTokenCommand>();

                    var response = await sender.Send(command);

                    return Results.Created("/refreshtoken", response);
                })
             .WithName("refreshtoken")
             .Produces<RefreshTokenResponse>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("refresh token")
             .WithDescription("refresh token");
        }
    }
}
