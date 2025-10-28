using LibraryAPI.Domain.Interfaces;
using LibraryAPI.Infrastructure;
using LibraryAPI.Infrastructure.Repositories;
using LibraryAPI.Services;
using LibraryAPI.Services.Interfaces;
using LibraryAPI.Web.Exceptions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAuthorRepository,AuthorRepository>();
builder.Services.AddScoped<IBooksRepository,BooksRepository>();
builder.Services.AddScoped<IAuthorService,AuthorService>();
builder.Services.AddScoped<IBookService,BookService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
