using Microsoft.EntityFrameworkCore;
using LibraryManagementAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlite("Data Source= LibraryManagementDB.db"));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


builder.Services.AddControllers();

var app = builder.Build();

//CORS middleware
app.UseCors("AllowAllOrigins");

//Map controllers (API endpoints)
app.MapControllers();

app.Run();