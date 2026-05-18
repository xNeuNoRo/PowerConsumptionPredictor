using PowerConsumptionPredictor.BusinessLogic;

var builder = WebApplication.CreateBuilder(args);

// Agregar los controladores con vistas
builder.Services.AddControllersWithViews();

// Agregamos toda la capa de logica de negocio al container de .NET
builder.Services.AddBusinessLogic();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

// Ejecutamos la app
await app.RunAsync();
