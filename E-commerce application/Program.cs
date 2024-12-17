using E_commerce_application.Context;
using E_commerce_application.Implementations;
using E_commerce_application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ShipShop API",
        Version = "first version",
        Description = " API  provides a range of benefits that contribute to improving business operations," +
        " facilitating access to products," +
        " and providing convenient shopping experiences for customers. ",
        Contact = new OpenApiContact
        {
            Name = "Yasmeen Saleh",
            Email = "yasmeensaleh147@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/yasmeen-saleh-0a9968257/")

        }
    });
    //enabling xml comments
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
//Services
builder.Services.AddDbContext<CommerceDbContext>(con => con.UseSqlServer("Data Source=DESKTOP-40R4L6L\\SQLEXPRESS;Initial Catalog=CommerceDb;Integrated Security=True;Trust Server Certificate=True"));
builder.Services.AddScoped<IAuthanticationService, AuthanticationService>();
builder.Services.AddScoped<ILookupService, LookupService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();    
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICartService,CartService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ITransactionsService, TransactionsService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();



//Configure Serilog 
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
//string loggerPath = configuration.GetSection("LoggerPath").Value;
Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).
                WriteTo.File(Path.Combine(Directory.GetCurrentDirectory(), "Logs/MELogging.txt"), rollingInterval: RollingInterval.Day).
                CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

try
{
    Log.Information("Start Running The API");
    Log.Information("App Runs Successfully");
    app.Run();

}
catch (Exception ex)
{
    Log.Information("An Error Occurred");
    Log.Error($"Error {ex.Message} was Prevent Application from run successfully");
}


