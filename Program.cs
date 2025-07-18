﻿// using Microsoft.OpenApi.Models;

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen(options =>
// {
//     options.SwaggerDoc("v1", new OpenApiInfo
//     {
//         Version = "v1",
//         Title = "EzaMetric Backend API",
//         Description = "A simple ASP.NET Core Web API for EzaMetric - Hello World Test",
//         Contact = new OpenApiContact
//         {
//             Name = "EzaMetric Team"
//         }
//     });
// });

// // Add CORS support
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowAll", policy =>
//     {
//         policy.AllowAnyOrigin()
//               .AllowAnyMethod()
//               .AllowAnyHeader();
//     });
// });

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI(options =>
//     {
//         options.SwaggerEndpoint("/swagger/v1/swagger.json", "EzaMetric Backend API v1");
//         options.RoutePrefix = string.Empty;
//         options.DocumentTitle = "EzaMetric API Documentation";
//     });
// }

// // Use CORS
// app.UseCors("AllowAll");

// app.UseHttpsRedirection();
// app.UseAuthorization();
// app.MapControllers();

// app.Run();

using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "EzaMetric Backend API",
        Description = "A simple ASP.NET Core Web API for EzaMetric - Hello World Test",
        Contact = new OpenApiContact
        {
            Name = "EzaMetric Team"
        }
    });
});

// Add CORS support for production
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Enable Swagger in production for Railway (for testing)
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "EzaMetric Backend API v1");
    options.RoutePrefix = string.Empty;
    options.DocumentTitle = "EzaMetric API Documentation";
});

// Use CORS
app.UseCors("AllowAll");

// Remove HTTPS redirection for Railway
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

// Railway configuration - use PORT environment variable
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Run($"http://0.0.0.0:{port}");