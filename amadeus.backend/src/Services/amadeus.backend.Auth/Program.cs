using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var appSettingSection = builder.Configuration.GetSection("Config");
var appSettings = appSettingSection.Get<AppSettings>();

//services
builder.Services.Configure<AppSettings>(appSettingSection);

string _cors = "all";
builder.Services.AddCors(options =>
    {
        options.AddPolicy(_cors, builder =>
          builder.SetIsOriginAllowed(origin =>
          {
              var uri = new Uri(origin);
              return uri.Host == "localhost" ||
                      uri.Host == "localhost:4200";
          })
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddScoped<ValidAuthentication>();

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LogginBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.WebHost.UseUrls("http://localhost:5002");

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

app.UseCors(_cors);

//http pipelines
app.MapCarter();

app.UseExceptionHandler(options => { });

app.Run();
