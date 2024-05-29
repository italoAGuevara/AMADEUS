namespace Login.API.UsesCases.Auth.Signin
{
    public record SinginCommand(string Email, string Password)
        : ICommand<SinginResponse>;

    public record SinginResponse(string Token);

    public class SigninCommandValidator : AbstractValidator<SinginCommand>
    {
        public SigninCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Email).MinimumLength(10).WithMessage("Email must have minimum 10 characters");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("Email must have maximum 10 characters");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email does not have a valid format");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.Password).MinimumLength(8).WithMessage("Password must have minimum 8 characters");
            RuleFor(x => x.Password).MaximumLength(100).WithMessage("Password must have maximum 10 characters");
        }
    }

    public class SinginCommandHandler: ICommandHandler<SinginCommand, SinginResponse>
    { 
        private readonly ILogger<SinginCommandHandler> logger;
        private readonly ApplicationDbContext dbContext;
        private readonly AppSettings _appSettings;

        public SinginCommandHandler(
            IOptions<AppSettings> appSettings,
            ILogger<SinginCommandHandler> logger, 
            ApplicationDbContext dbContext)
        {
            _appSettings = appSettings.Value;
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public async Task<SinginResponse> Handle(SinginCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("CreatePostCommandHandler.Handle called with {@Query}", command.Email);
            var passHasher = new PasswordHasher<ApplicationUser>();

            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == command.Email, cancellationToken);

            if(user == null) throw new BadRequestException("Wrong credentials.");


            if (EncriptPassword.HashPassword(command.Password) != user.PasswordHash)
                throw new BadRequestException("Wrong credentials.");

            var token = TokenHelper.GenerateToken(user, _appSettings);

            var userToken = new Token
            {
                UserId = user.Id,
                ExpirationTime = DateTime.UtcNow.AddDays(30),
                BodyToken = token,
            };

            var previousToken = await dbContext.Tokens.FirstOrDefaultAsync(x => x.UserId == user.Id, cancellationToken);

            if(previousToken != null)
            {
                dbContext.Tokens.Remove(previousToken);
            }

            dbContext.Tokens.Add(userToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new SinginResponse(token);
        }
    }
}
