namespace Login.API.UsesCases.Auth.Signout
{
    public record SingoutCommand(string Token)
            : ICommand<SingoutResponse>;
    public record SingoutResponse(bool IsSuccess);


    public class SingoutCommandValidator : AbstractValidator<SingoutCommand>
    {
        public SingoutCommandValidator()
        {
            RuleFor(x => x.Token).NotEmpty().WithMessage("The token is required.");
            RuleFor(x => x.Token).MinimumLength(20).WithMessage("Lenght token invalid");
        }
    }

    public class SingoutCommandHandler : ICommandHandler<SingoutCommand, SingoutResponse>
    {
        private readonly ILogger<SingoutCommandHandler> logger;
        private readonly ApplicationDbContext _dbContext;

        public SingoutCommandHandler(ILogger<SingoutCommandHandler> logger, ApplicationDbContext dbContext)
        {
            this.logger = logger;
            _dbContext = dbContext;
        }

        public async Task<SingoutResponse> Handle(SingoutCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("SingoutCommandHandler.Handle called with {@Query}", command.Token);

            var token = await _dbContext.Tokens.FirstOrDefaultAsync(x => x.BodyToken == command.Token,cancellationToken);

            if (token is null)
            {
                return new SingoutResponse(true);
            }

            _dbContext.Remove(token);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new SingoutResponse(true);
        }
    }
}
