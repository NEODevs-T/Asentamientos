using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using Radzen;
using Asentamientos.Services;
using Asentamientos.Data;
using Asentamientos.Interface;
using Asentamientos.Logic;
using Asentamientos.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

//* Radzen
builder.Services.AddScoped<DialogService>();//para calendario de radzen
builder.Services.AddScoped<NotificationService>();//para notificaciones de radzen
builder.Services.AddScoped<ContextMenuService>();//para notificaciones de radzen
builder.Services.AddScoped<TooltipService>();

//* Autenticador
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddCascadingAuthenticationState();

//* Blazored
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddHttpClient();

//* Data
builder.Services.AddScoped(hc => new HttpClient { BaseAddress = new Uri("http://neo.paveca.com.ve/apineomaster") });
builder.Services.AddScoped<IMaestraData, MaestraData>();
builder.Services.AddScoped<IGlobalData,GlobalData>();
builder.Services.AddScoped<IProductosVData,ProductosVData>();
builder.Services.AddScoped<ISeccionesVData,SeccionesVData>();
builder.Services.AddScoped<IRangoData,RangoData>();
builder.Services.AddScoped<IAsentamientoData,AsentamientoData>();
builder.Services.AddScoped<IValoresDeAsentamientosVData,ValoresDeAsentamientosVData>();
builder.Services.AddScoped<IVaribleData,VariableData>();
builder.Services.AddScoped<ICorteDiscrepancia,CorteDiscrepaciaData>();
builder.Services.AddScoped<ILibroNovedades,LibroNovedadesData>();

//* Logic
builder.Services.AddScoped<IRolLogic,RolLogic>();
builder.Services.AddScoped<IRotacionLogic,RotacionLogic>();

//* Services
builder.Services.AddScoped<INotifiRadzenServices,NotifiRadzenServices>();

//* Host
builder.Services.AddSingleton<IWebHostEnvironment>(builder.Environment);


builder.Services.AddHttpContextAccessor();

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
