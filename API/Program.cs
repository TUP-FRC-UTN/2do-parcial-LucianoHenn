using API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<prog3Context>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("ConexionDatabase"))
);

//builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ContextBD>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ConexionDatabase")));
builder.Services.AddEntityFrameworkNpgsql()
.AddDbContext<prog3Context>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ConexionDatabase")));


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

app.UseCors(builder =>
       builder.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials());

app.Run();

