using Microsoft.EntityFrameworkCore;
using MyFirstProject.Shared.Models;
using CsvHelper;
using System.Globalization;
using System.IO;
using MyFirstProject.WebApi.Context;
using MyFirstProject.WebApi.Repository;

var builder = WebApplication.CreateBuilder(args);

var isDevelopment = builder.Environment.IsDevelopment();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();



builder.Services.AddScoped<ITodoItemRepository, TodoItemRepository>();
builder.Services.AddScoped<IWeatherMeteo, WeatherMeteoRepository>();


// use in-memory database
builder.Services.AddDbContext<TodoItemContext>(opt =>
opt.UseInMemoryDatabase("TodoList"));

builder.Services.AddDbContext<NYCrashItemContext>(opt =>
opt.UseInMemoryDatabase("NyCrashList"));



builder.Services.AddDbContext<TodoItemContext>(options =>
{
    if (isDevelopment)
    {
        options.UseInMemoryDatabase("MyInMemoryDb");
    }
    else
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

// create database if not exists
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<TodoItemContext>();
        context.Database.EnsureCreated();

        // Check if any TodoItems exist, if not, add some
        if (!context.TodoItems.Any())
        {
            //Create a Loop to populate 100 items
            for (int i = 0; i < 100; i++)
            {
                context.TodoItems.Add(new TodoItem { Name = $"Task {i}", IsComplete = i % 2 == 0 });
            }
            context.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }

    //NY Crash Items
    var contextNY = services.GetRequiredService<NYCrashItemContext>();
    contextNY.Database.EnsureCreated();

   

    // Check if any NYCrashItems exist, if not, add some
    if (!contextNY.NYCrashItems.Any())
    {
        //Reads the CSV file and populates the database 
        // REMOVER a parte do PATH para deixar o copilot tentar acertar ou sugerir o caminho
        using (var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "new_york_sample_data.csv")))
        {

            var csvConfig = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                 MissingFieldFound = null
            };

            using (var csv = new CsvReader(reader, csvConfig))
            {

                var records = csv.GetRecords<NYCrashItem>().ToList();
                contextNY.NYCrashItems.AddRange(records);
                contextNY.SaveChanges();
            }

        }
       
    }
}

app.Run();

public  partial class Program { }