var builder = WebApplication.CreateBuilder(args);

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

// Add services to the container.
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(_cors);

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
