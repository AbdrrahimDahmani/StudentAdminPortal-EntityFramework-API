using InspectionAPI.DataModels;
using Microsoft.EntityFrameworkCore;

var myAllowSpecificOrigin = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InspectionContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options=>
            options.AddPolicy(myAllowSpecificOrigin,policy=>
                policy.WithOrigins("https://localhost:4200") // note the port is included 
                .AllowAnyHeader()
                .AllowAnyMethod()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(myAllowSpecificOrigin);
app.UseAuthorization();

app.MapControllers();

app.Run();
