using Dominio;
using Logica;
using UserInterface.Components;
using MudBlazor.Services;
using Repositorio;
using Controladores;
    
using Logica;
using SQLitePCL;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMudServices();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<SqlContext>();

//scoped
builder.Services.AddScoped<IRepositorio<Dato>,DatoRepo>();
builder.Services.AddScoped<IRepositorio<Item>,ItemRepo>();
builder.Services.AddScoped<IRepositorio<Recibo>,ReciboRepo>();
builder.Services.AddScoped<ControladorDatos>();
builder.Services.AddScoped<ControladorItems>();
builder.Services.AddScoped<ControladorRecibos>();

//singleton
builder.Services.AddSingleton<DatoFactory>();
builder.Services.AddSingleton<ReciboFactory>();
builder.Services.AddSingleton<ItemFactory>();


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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();