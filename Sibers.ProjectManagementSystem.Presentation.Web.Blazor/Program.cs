using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Sibers.ProjectManagementSystem.Data.Entities;
using Sibers.ProjectManagementSystem.Data.Repositories.Base;
using Sibers.ProjectManagementSystem.Data.Repositories.Defaults;
using Sibers.ProjectManagementSystem.Presentation.Web.Blazor;
using Sibers.ProjectManagementSystem.Presentation.Web.Blazor.Infrastructure.Extensions;
using Sibers.ProjectManagementSystem.Services.WebApiClients;
using Sibers.ProjectManagementSystem.Services.WebApiClients.Base;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddApi<IClient<Project>, DefaultClient<Project>>("api/Project");
builder.Services.AddApi<IClient<Employee>, DefaultClient<Employee>>("api/Employee");
builder.Services.AddApi<IClient<RoleInProject>, DefaultClient<RoleInProject>>("api/RoleInProject");
builder.Services.AddMudServices();

await builder.Build().RunAsync();
