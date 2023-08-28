using Microsoft.AspNetCore.Builder;
using Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<ConsoleLoggerMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMiddleware<ConsoleLoggerMiddleware>();



app.Run(async context =>
{
    Console.WriteLine("HelloWorld");
    await context.Response.WriteAsync("HelloWorld");
});


app.Run();




