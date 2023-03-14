using Core;
using Infraestructure;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
string connectionString = configuration.GetSection("ConnectionStrings:ClientsDB").Value;

builder.Services.AddAutoMapper(typeof(CoreMappingProfile));
// Add services to the container.
//builder.Services.AddScoped<ISysusersService, SysusersService>();

//Repositories
builder.Services.AddScoped(typeof(IApiRepository<>), typeof(ApiRepository<>));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
