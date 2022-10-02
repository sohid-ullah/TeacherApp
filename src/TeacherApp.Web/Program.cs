using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Serilog;
using Serilog.Events;
using TeacherApp.Business.DbContexts;
using TeacherApp.Business;
using TeacherApp.Web;

var builder = WebApplication.CreateBuilder(args);

//Necessary variables for upcoming use 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

var assemblyName = Assembly.GetExecutingAssembly().FullName;

/**Adding dbcontexts for migrations**/
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Host.UseSerilog((ctx, lc) => lc.MinimumLevel.Debug().MinimumLevel
.Override("Microsoft", LogEventLevel.Warning).Enrich.FromLogContext().ReadFrom
.Configuration(builder.Configuration));

builder.Services.AddControllersWithViews();
builder.Services.AddMvc();


//Hosts 
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new WebModule());
    containerBuilder.RegisterModule(new BusinessModule(connectionString, assemblyName));
});

//App 
try
{
    var app = builder.Build();
    Log.Information("Application Starting up");


    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
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
        pattern: "{controller=teachers}/{action=Index}/{id?}");

    app.MapRazorPages();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}