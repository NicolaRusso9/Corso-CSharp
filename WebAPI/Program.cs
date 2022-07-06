using CorsoCSharp.EFCore.AutoGenModels;
using Microsoft.AspNetCore.Mvc.Formatters;
using WebAPI.Repositories;
using Swashbuckle.AspNetCore.SwaggerUI;         // Import swagger
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<NorthwindContext>();


// Needed to add serialization 
builder.Services.AddControllers(options =>
{
    Console.WriteLine("Default output formatter:");
    foreach (IOutputFormatter formatter in options.OutputFormatters)
    {
        OutputFormatter? mediaFormatter = formatter as OutputFormatter;
        if(mediaFormatter == null)
        {
            Console.WriteLine($"{formatter.GetType().Name}");
        }
        else
        {
            Console.WriteLine("{0}, Media types: {1}",
                arg0: mediaFormatter.GetType().Name,
                arg1: string.Join(", ", mediaFormatter.SupportedMediaTypes));
        }
    }
})
.AddXmlDataContractSerializerFormatters()
.AddXmlSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enable logging
builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
    options.RequestBodyLogLimit = 4096; // default is 32k
    options.ResponseBodyLogLimit = 4096;// default is 32k
});

builder.Services.AddScoped<ICustomerRepository, CustomerRepositories>();        // register customerRpositories for use at runtime as a scoped dependency

// Add swagger
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v2", new()
        { Title = "Northwind Service API", Version = "v2" });
    }
);

builder.WebHost.UseUrls("https://localhost:5002/");             // configurazione url
builder.Services.AddCors();                                     // CORS = Cross origin resource sharing. Abilitandolo solo richieste dalla stessa origine sono consentite. Sotto segue configurazione avanzata

//builder.Services.AddHealthChecks().AddDbContextCheck<NorthwindContext>();

var app = builder.Build();

// Configure http request pipeline  - https://localhost:5001/swagger/index.html to test
if (builder.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "Northwind Service API version 1");

        c.SupportedSubmitMethods(new[] { SubmitMethod.Get, SubmitMethod.Post, SubmitMethod.Put, SubmitMethod.Delete });
    });
}

// Configurazione avanzata cors per accettare richieste solo da client identificati
app.UseCors(configurePolicy: options=>
{
    options.WithMethods("GET", "POST", "PUT", "DELETE");
    options.WithOrigins("https://localhost:5001");      // Allow request from MVC in this project or all program that run on localhost:5001
});



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<SecurityHeadersMiddleware>();         // security header
app.UseHttpLogging();// Enable logging

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
