using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using Radzen;
using Asentamientos.Services;
using Asentamientos.Components;
using Asentamientos.Data;
using Asentamientos.Interface;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

//* Radzen
builder.Services.AddScoped<DialogService>();//para calendario de radzen
builder.Services.AddScoped<NotificationService>();//para notificaciones de radzen

//* Autenticador
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddCascadingAuthenticationState();

//* Blazored
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddHttpClient();

//*Data
builder.Services.AddScoped(hc => new HttpClient { BaseAddress = new Uri("http://neo.paveca.com.ve/apineomaster") });
builder.Services.AddScoped<IMaestra, MaestraData>();
builder.Services.AddScoped<IProductosVData,ProductosVData>();
builder.Services.AddScoped<ISeccionesVData,SeccionesVData>();
builder.Services.AddScoped<IRangoData,RangoData>();

//* Services
builder.Services.AddScoped<INotifiRadzenServices,NotifiRadzenServices>();


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
