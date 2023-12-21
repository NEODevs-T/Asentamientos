using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blazored.LocalStorage;
using Radzen;
using Asentamientos;
using Asentamientos.Services;
using Asentamientos.Components;
using Asentamientos.Models;
using Asentamientos.Interface;
using Asentamientos.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<DialogService>();//para calendario de radzen
builder.Services.AddScoped<NotificationService>();//para notificaciones de radzen
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<IMaestra, MaestraData>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(hc=>new HttpClient { BaseAddress = new Uri("http://neo.paveca.com.ve/apineomaster") });
builder.Services.AddHttpClient();




var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
