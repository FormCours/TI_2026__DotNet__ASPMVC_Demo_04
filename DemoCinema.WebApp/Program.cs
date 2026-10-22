using DemoCinema.WebApp.Tools;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Définir la configuration de l'injection de dépendences (DI)
// Trois config possible 
// - Singleton : Une seul instance
// - Scoped : Une instance par requete (Traitement de celle-ci)
// - Transient : Une nouvelle instance à chaque appel

// Ecriture en typeof
/* 
builder.Services.AddSingleton(typeof(DemoSingletonTool));
builder.Services.AddScoped(typeof(DemoScopedTool));
builder.Services.AddTransient(typeof(DemoTransientTool));
*/
// Ecriture en générique
builder.Services.AddSingleton<DemoSingletonTool>();
builder.Services.AddScoped<DemoScopedTool>();
builder.Services.AddTransient<DemoTransientTool>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
