using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Sibers.ProjectManagementSystem.Data.Entities;
using Sibers.ProjectManagementSystem.Data.Repositories.Base;
using Sibers.ProjectManagementSystem.Data.Repositories.Defaults;
using Sibers.ProjectManagementSystem.Presentation.Web.Blazor;
using Sibers.ProjectManagementSystem.Presentation.Web.Blazor.Infrastructure.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddApi<ICrudRepository<Project>, DefaultWebRepository<Project>>("api/Project");
builder.Services.AddApi<ICrudRepository<Employee>, DefaultWebRepository<Employee>>("api/Employee");
builder.Services.AddApi<ICrudRepository<RoleInProject>, DefaultWebRepository<RoleInProject>>("api/RoleInProject");
builder.Services.AddMudServices();

await builder.Build().RunAsync();
