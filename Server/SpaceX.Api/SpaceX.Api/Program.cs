using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using SpaceX.Api.Middleware;
using SpaceX.Api.Service;
using System.Reflection;
using TakeNotes.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy1", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
        .WithMethods("GET")
        .WithHeaders(HeaderNames.ContentType);
    });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Description = "A simple ASP.NET WEB API application to fetch SpaceX future and past launches",
        Title = "SpaceX",
        Contact = new OpenApiContact { Name = "Nishanth Aradhya", Email = "nishanth.aradhya@gmail.com" }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    c.DocumentFilter<CustomDocumentFilter>();
});
builder.Logging.AddFilter("System", LogLevel.Debug);
builder.Services.AddTransient<ILaunchService, LaunchService>();
builder.Services.AddHttpClient<ILaunchService, LaunchService>(con => con.BaseAddress=new Uri("https://api.spacexdata.com/v3"));
var app = builder.Build();

app.UseCors("Policy1");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

