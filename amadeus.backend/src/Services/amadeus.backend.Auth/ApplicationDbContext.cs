

namespace Login.API
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        private readonly IConfiguration _configuration;
        public DbSet<Token> Tokens {  get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Token>().HasKey(t => t.Id);
            modelBuilder.Entity<Token>().Property(x => x.TmStmp).HasDefaultValue(DateTime.UtcNow);

            Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        //private readonly IConfigurationManager _configurationManager = configurationManager;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AMADEUS"));
        }      
        

        private void Seed(ModelBuilder modelBuilder)
        {
            List<IdentityRole> roles =
            [
                new IdentityRole(){ Name="Administrator", NormalizedName="ADMINISTRATOR" },
                new IdentityRole(){ Name="User", NormalizedName="USER" },
            ];    

            List<ApplicationUser> users =
            [
                new ApplicationUser()
                {
                    UserName="admin1",
                    NormalizedUserName="ADMIN1",
                    Email="admi1@mail.com",
                    NormalizedEmail="ADMN1@MAIL.COM",

                }
            ];


            List<IdentityUserRole<string>> userRoles =
            [
                new IdentityUserRole<string>
                {
                    UserId = users[0].Id,
                    RoleId = roles[0].Id
                },
            ];

            users[0].PasswordHash = EncriptPassword.HashPassword("admin1234");

            modelBuilder.Entity<ApplicationUser>().HasData(users);
            modelBuilder.Entity<IdentityRole>().HasData(roles);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
}
