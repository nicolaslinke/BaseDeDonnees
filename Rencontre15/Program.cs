using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Rencontre15.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<SeriesTVContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("BDSeriesTV")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Series}/{action=Index}/{id?}"
        );
});

app.MapRazorPages();

app.Run();
