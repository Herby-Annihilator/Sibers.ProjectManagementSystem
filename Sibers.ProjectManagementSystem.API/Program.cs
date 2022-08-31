using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Sibers.ProjectManagementSystem.Data.DbContexts;
using Sibers.ProjectManagementSystem.Data.DbContexts.Extensions;
using Sibers.ProjectManagementSystem.Data.Entities;
using Sibers.ProjectManagementSystem.Data.Repositories;
using Sibers.ProjectManagementSystem.Data.Repositories.Base;
using Sibers.ProjectManagementSystem.Data.Repositories.Defaults;
using Sibers.ProjectManagementSystem.Data.UnitsOfWork.Base;
using Sibers.ProjectManagementSystem.Data.UnitsOfWork.Defaults;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
string migrationAssembly = "Sibers.ProjectManagementSystem.Data.MSSQL";

// Add services to the container.

builder.Services.AddDbContext<ProjectManagementSystemDbContext>(optionsBuilder =>
{
    optionsBuilder.UseSqlServer(configuration.GetConnectionString("MSSQL"),
        sql => sql.MigrationsAssembly(migrationAssembly));
});

builder.Services.AddScoped<ICrudRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<ICrudRepository<Project>, ProjectRepository>();
builder.Services.AddScoped<ICrudRepository<RoleInProject>, RoleInProjectRepository>();
builder.Services.AddScoped<IUnitOfWork<ProjectManagementSystemDbContext>, UnitOfWork<ProjectManagementSystemDbContext>>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();
bool seedData = false;
if (configuration["SeedData"].ToLower() == "yes")
    seedData = true;
app.Services.CreateScope().ServiceProvider.GetRequiredService<ProjectManagementSystemDbContext>().EnsureSeedData(seedData);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
                                        //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
    .AllowCredentials()); // allow credentials

app.Run();
