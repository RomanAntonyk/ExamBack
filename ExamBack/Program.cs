using ExamBack.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(setup =>
{
    setup.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    });
});

// Add services to the container.
string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));
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

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
