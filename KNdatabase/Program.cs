using KNdatabase.Data;
using KNdatabase.Models.Repository;
using KNdatabase.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//add connection string
builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDBConnection")));

builder.Services.AddDbContext<AuthenDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDBconnection")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AuthenDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

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

app.MapControllerRoute(
    name: "student",
    pattern: "{controller=Student}/{action=ListAll}/{id?}");

app.Run();
