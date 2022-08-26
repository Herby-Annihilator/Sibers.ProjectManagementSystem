using Microsoft.EntityFrameworkCore;
using Sibers.ProjectManagementSystem.Data.DbContexts;
using Sibers.ProjectManagementSystem.Data.DbContexts.Extensions;
using Sibers.ProjectManagementSystem.Data.Repositories.Base;
using Sibers.ProjectManagementSystem.Data.Repositories.Defaults;
using Sibers.ProjectManagementSystem.Data.UnitsOfWork.Base;
using Sibers.ProjectManagementSystem.Data.UnitsOfWork.Defaults;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
string migrationAssembly = "Sibers.ProjectManagementSystem.Data.MSSQL";

// Add services to the container.

builder.Services.AddDbContext<ProjectManagementSystemDbContext>(optionsBuilder =>
{
    optionsBuilder.UseSqlServer(configuration.GetConnectionString("MSSQL"),
        sql => sql.MigrationsAssembly(migrationAssembly));
});
builder.Services.AddScoped(typeof(ICrudRepository<>), typeof(DefaultCrudRepository<>));
builder.Services.AddScoped<IUnitOfWork<ProjectManagementSystemDbContext>, UnitOfWork<ProjectManagementSystemDbContext>>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
bool seedData = false;
if (configuration["SeedData"] == "yes")
    seedData = true;
app.Services.GetRequiredService<ProjectManagementSystemDbContext>().EnsureSeedData(seedData);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
