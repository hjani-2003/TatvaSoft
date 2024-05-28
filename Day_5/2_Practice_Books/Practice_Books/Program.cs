using Microsoft.EntityFrameworkCore;
using Practice_Books.Services;
using Practice_Books.Data;
using Practice_Books.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibDbContext>(db => db.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<BookServices>();
builder.Services.AddScoped<DepartmentServices>();

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

SeedDatabase(app);

app.Run();

void SeedDatabase(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<LibDbContext>();
        context.Database.Migrate(); // Apply pending migrations

        if (!context.Book.Any())
        {
            context.Book.AddRange(
                new Books { Id = 1, Title = "1984", Author = "George Orwell", Genre = "Dystopian", DepartmentId = 1},
                new Books { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction", DepartmentId = 2 },
                new Books { Id = 3, Title = "Sapiens", Author = "Yuval Noah Harari", Genre = "History", DepartmentId = 3},
                new Books { Id = 4, Title = "Valley of Peace", Author = "Po Xhang", Genre = "Fiction", DepartmentId = 2},
                new Books { Id = 5, Title = "Dan Brown", Author = "I don't know", Genre = "Mystery", DepartmentId = 1}
            );
        }
        if (!context.Department.Any())
        {
            // Seed Departments
            context.Department.AddRange(
                new Department { Id = 1, Name = "School of Theatre and Arts" },
                new Department { Id = 2, Name = "School of Literature" },
                new Department { Id = 3, Name = "School of History" }
            );
        }

        context.SaveChanges();
    }
}