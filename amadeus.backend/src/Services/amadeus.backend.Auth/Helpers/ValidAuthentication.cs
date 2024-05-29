namespace Login.API.Helpers
{
    public class ValidAuthentication
    {
       //private readonly AppSettings _appSettings;
       private readonly ApplicationDbContext _dbContext;
        //private readonly ILogger<ValidAuthentication> _logger;

        public ValidAuthentication(
          //     IOptions<AppSettings> appSettings, 
          //  ILogger<ValidAuthentication> logger, 
            ApplicationDbContext dbContext
            )
        {
            //   _appSettings = appSettings.Value;
            //_logger = logger;
             _dbContext = dbContext;
        }

        public async Task<bool> CheckAsync(string token, string rolePermited)
        {

            // Use the scoped service
            var tokenEntity = await _dbContext
                .Tokens
                .FirstOrDefaultAsync(x => x.BodyToken == token && x.ExpirationTime >= DateTime.UtcNow);

            if (tokenEntity is null) throw new IOException("Invalid token.");

            var query = (from userRoles in _dbContext.UserRoles
                         join roles in _dbContext.Roles
                         on userRoles.RoleId equals roles.Id
                         where userRoles.UserId == tokenEntity.UserId && roles.Name.Contains(rolePermited)
                         select new
                         {
                             UserId = userRoles.UserId,
                             RoleId = userRoles.RoleId,
                             RoleName = roles.Name
                         });
            var sql = query.ToQueryString();
            Console.WriteLine($"Generated SQL Query: {sql}");

            var roleExist = await (from userRoles in _dbContext.UserRoles
                                    join roles in _dbContext.Roles
                                    on userRoles.RoleId equals roles.Id
                                    where userRoles.UserId == tokenEntity.UserId && roles.Name.Contains(rolePermited)
                                    select new
                                    {
                                        RoleName = roles.Name
                                    }).FirstOrDefaultAsync();

            if (roleExist is null) throw new IOException("Invalid user, user NOT allow.");

            return true;
        }
    }
}
