using Microsoft.EntityFrameworkCore;
using Infrastructure.Mappers;
using Infrastructure.Context;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(op => op.UseNpgsql(connection));
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(ProfileService));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<MovieService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
