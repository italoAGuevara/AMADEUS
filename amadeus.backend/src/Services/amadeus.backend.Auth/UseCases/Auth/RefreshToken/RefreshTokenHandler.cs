
namespace Login.API.UsesCases.Auth.RefreshToken
{
    public record RefreshTokenCommand(string Token) : ICommand<RefreshTokenResponse>;
    public record RefreshTokenResponse(string Token);

    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(x => x.Token).NotEmpty().WithMessage("The token is required.");
            RuleFor(x => x.Token).MinimumLength(20).WithMessage("Lenght token invalid");
        }
    }
    public class RefreshTokenCommandHandler : ICommandHandler<RefreshTokenCommand, RefreshTokenResponse>
    {
        private readonly ILogger<RefreshTokenCommandHandler> logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly AppSettings _appSettings;

        public RefreshTokenCommandHandler(
            IOptions<AppSettings> appSettings,
            ILogger<RefreshTokenCommandHandler> logger,
            ApplicationDbContext dbContext)
        {
            _appSettings = appSettings.Value;
            this.logger = logger;
            _dbContext = dbContext;
        }

        public async Task<RefreshTokenResponse> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("RefreshTokenHandler.Handle called with {@Query}", command.Token);

            var tokenEntity = await _dbContext.Tokens.FirstOrDefaultAsync(x => x.BodyToken == command.Token,cancellationToken);

            if (tokenEntity is null) throw new IOException("Invalid token.");

            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == tokenEntity.UserId ,cancellationToken);

            if (user is null) throw new IOException("Invalid token.");

            tokenEntity.BodyToken =  TokenHelper.GenerateToken(user, _appSettings);
            tokenEntity.TmStmp = DateTime.UtcNow;
            tokenEntity.ExpirationTime = DateTime.UtcNow.AddDays(30);

            
            _dbContext.Update(tokenEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new RefreshTokenResponse(tokenEntity.BodyToken);
        }
    }
}
