namespace Login.API.UsesCases.Auth.Signup
{
    public record SingupCommand(string Email, string Password, string UserName)
        : ICommand<SingupResponse>;

    public record SingupResponse(string Token);

    public class SignupCommandValidator : AbstractValidator<SingupCommand>
    {
        public SignupCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Email).MinimumLength(10).WithMessage("Email must have minimum 10 characters");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("Email must have maximum 10 characters");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email does not have a valid format");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.Password).MinimumLength(8).WithMessage("Password must have minimum 8 characters");
            RuleFor(x => x.Password).MaximumLength(100).WithMessage("Password must have maximum 10 characters");
            RuleFor(x => x.Password).Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one non-alphanumeric character.");
        }
    }

    public class SingupCommandHandler : ICommandHandler<SingupCommand, SingupResponse>
    {
        private readonly ILogger<SingupCommandHandler> logger;
        private readonly ApplicationDbContext dbContext;
        private readonly AppSettings _appSettings;

        public SingupCommandHandler(
            IOptions<AppSettings> appSettings,
            ILogger<SingupCommandHandler> logger,
            ApplicationDbContext dbContext)
        {
            _appSettings = appSettings.Value;
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public async Task<SingupResponse> Handle(SingupCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("SingupCommandHandler.Handle called with {@Query}", command.Email);
            var passHasher = new PasswordHasher<ApplicationUser>();

            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == command.Email, cancellationToken);

            if (user != null) throw new BadRequestException("User with email already exist.");

            user = new ApplicationUser
            {
                PasswordHash = EncriptPassword.HashPassword(command.Password),
                Email = command.Email,
                UserName = command.UserName,
                NormalizedEmail = command.Email.ToUpper(),
                NormalizedUserName = command.UserName.ToUpper()
            };

         

            var token = TokenHelper.GenerateToken(user, _appSettings);

            var userToken = new Token
            {
                UserId = user.Id,
                ExpirationTime = DateTime.UtcNow.AddDays(30),
                BodyToken = token,
            };


            var role = await dbContext.Roles.FirstOrDefaultAsync(x => x.Name == EnumRoles.User.ToString());
            dbContext.UserRoles.Add(
                new IdentityUserRole<string> 
                { 
                    RoleId = role.Id,
                    UserId = user.Id
                }
            );

            dbContext.Users.Add(user);
            dbContext.Tokens.Add(userToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new SingupResponse(token);
        }
    }
}
