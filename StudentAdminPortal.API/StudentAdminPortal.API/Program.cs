using StudentAdminPortal.API.DataModels;
using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
//Add migration
ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

builder.Services.AddDbContext<StudentAdminContext>(options => options.UseSqlServer(configuration.GetConnectionString("StudentAdminPortalDb")));
builder.Services.AddScoped<IStudentRepository,SqlStudentRepository>();

//auto mapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);
// Add scoped


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
