using Microsoft.AspNetCore.Builder;
using MongoDbJäsenrekisteri;
using MongoDbJäsenrekisteri.Models;
using MongoDbJäsenrekisteri.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JasenrekisteriSettings>(builder.Configuration.GetSection("JasenrekisteriSettings"));
builder.Services.AddSingleton<JasenService>();


// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

//app.MapGet("/", () => "Jasenrekisteri");
//app.MapGet("/api/jasenet/", async (JasenService jasenService) => await jasenService.Get());

//app.MapGet("/api/jasenet/{id}", async (JasenService jasenService, string id) =>
//{
//    var jasen = await jasenService.Get(id);
//    return jasen is null ? Results.NotFound() : Results.Ok(jasen);
//});



//app.MapPost("/api/jasenet", async (JasenService jasenService, Jasen jasen) =>
//{
//    await jasenService.Create(jasen);
//    return Results.Ok();
//});

//app.MapPut("/api/jasenet/{id}", async (JasenService jasenService, string id, Jasen updatedJasen) =>
//{
//    var jasen = await jasenService.Get(id);
//    if (jasen is null) return Results.NotFound();

//    updatedJasen.Id = jasen.Id;
//    await jasenService.Update(id, updatedJasen);
//    return Results.Ok();
//});
//app.MapDelete("/api/jasenet/{id}", async (JasenService jasenService, string id) =>
//{
//    var jasen = await jasenService.Get(id);
//    if (jasen is null) return Results.NotFound();

//    await jasenService.Remove(jasen.Id);
//    return Results.NoContent();
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

app.UseCors("AllowAllOrigins");

app.Run();
