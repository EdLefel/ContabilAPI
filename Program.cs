using System.Globalization;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.EntityFrameworkCore;
using SimpleCrudApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

/*
NÃO IMPLEMENTADO -> INVIÁVEL . *1

builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

// Registro do PdfService
builder.Services.AddSingleton<PdfService>();
*/

builder.Services.AddControllers();
var cultureInfo = new CultureInfo("pt-BR"); // ou a cultura que você está utilizando

CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// Configure the DbContext to use MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors("AllowAll");
//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
