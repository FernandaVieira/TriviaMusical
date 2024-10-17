using TriviaMusical.Components;
using TriviaMusical.Data;
using TriviaMusical.Hubs;
using Microsoft.EntityFrameworkCore;
using TriviaMusical.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionar a string de conexão ao DbContext
builder.Services.AddDbContext<TriviaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TriviaDatabase")));

builder.Services.AddScoped<MusicaService>(); // Registra MusicaService como um serviço

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapHub<GameHub>("/gamehub");

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
