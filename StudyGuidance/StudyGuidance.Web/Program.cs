using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StudyGuidance.Web;
using MudBlazor.Services;
using BlazorAnimation;
using StudyGuidance.Web.ApiClient;
using Microsoft.AspNetCore.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.Configure<AnimationOptions>(Guid.NewGuid().ToString(), c => { });

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IJobApiClient, JobApiClient>();
builder.Services.AddScoped<IQuizApiClient, QuizApiClient>();
builder.Services.AddScoped<IRecruiterApiClient, RecruiterApiClient>();
builder.Services.AddScoped<IStudyCourseApiClient, StudyCourseApiClient>();

builder.Services.AddBlazorBootstrap();

await builder.Build().RunAsync();
