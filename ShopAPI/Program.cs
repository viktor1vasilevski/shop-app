using Data.Context;
using EntityModels.Models;
using Main.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    try
    {
        var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

        // Apply any pending migrations
        dbContext.Database.Migrate();

        var roleExists = dbContext.Roles.Any(u => u.Name == "Admin");
        if (!roleExists)
        {
            var role = new Role 
            { 
                Name = "Admin",
                Created = DateTime.Now,
                CreatedBy = "Admin"
            };

            dbContext.Roles.Add(role);
            dbContext.SaveChanges();
        }

        // Check if admin user exists
        var adminExists = dbContext.Users.Any(u => u.Role.Name == "Admin");

        if (!adminExists)
        {
            // Create the admin user if it doesn't exist


            var adminRoleId = dbContext.Roles.FirstOrDefault(x => x.Name == "Admin").Id;

            var saltKey = PasswordHelper.GenerateSalt();
            var adminUser = new User
            {
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@example.com",
                Username = "admin",
                IsActive = true,
                Password = PasswordHelper.HashPassword("Admin@123", saltKey),
                SaltKey = Convert.ToBase64String(saltKey),
                CreatedBy = "Admin",
                Created = DateTime.Now,
                LastModifiedBy =  null,
                LastModified = null,
                RoleId = adminRoleId,
            };

            dbContext.Users.Add(adminUser);
            dbContext.SaveChanges();

        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error during admin user setup: {ex.Message}");
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
