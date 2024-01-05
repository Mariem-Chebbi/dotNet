using Microsoft.EntityFrameworkCore;
using TE.Core.Domain;
using TE.Core.Interfaces;
using TE.Core.Services;
using TE.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IService<Enseignant>, Service<Enseignant>>();
builder.Services.AddScoped<IService<Candidature>, Service<Candidature>>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<DbContext, TEContext>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
