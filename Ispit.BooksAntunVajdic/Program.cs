using Ispit.BooksAntunVajdic.Data;
using Ispit.BooksAntunVajdic.Mapping;
using Ispit.BooksAntunVajdic.Models.UserModels;
using Ispit.BooksAntunVajdic.Services.Implementations;
using Ispit.BooksAntunVajdic.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IBookService, BookService>();    
builder.Services.AddSingleton<IIdentitySetup, IdentitySetup>();
builder.Services.AddDefaultIdentity<ApplicationUser>(
    options => {
        options.SignIn.RequireConfirmedAccount = true;
        options.Password.RequiredLength = 6;
        options.Password.RequiredUniqueChars = 0;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;


        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = false;
    }


    )
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();
var identitySetup = app.Services.GetRequiredService<IIdentitySetup>();
app.Run();
