using BookWepApi.Data;
using BookWepApi.Middleware;
using BookWepApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Database Connection
builder.Services.AddDbContext<BooksDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Register Repository
builder.Services.AddScoped<IBookRepositories, BookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
// Register Middleware
// Global Exception Handling with Middleware
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();
