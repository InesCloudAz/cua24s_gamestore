using GameStore.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationInsightsTelemetry(options =>
{
    options.ConnectionString = builder.Configuration["ApplicationInsights:ConnectionString"];
});

// Lägg till tjänster för MVC och GameService
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<GameService>();

var app = builder.Build();

// Konfigurera HTTP-anrop
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Games}/{action=Index}/{id?}");

app.Run();
