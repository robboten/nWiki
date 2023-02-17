using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Wiki.Api.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WikiApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WikiApiContext") ?? throw new InvalidOperationException("Connection string 'WikiApiContext' not found.")));

// Add services to the container.
builder.Services.AddCors(opt=> {
    opt.AddDefaultPolicy(policy => {
      //  policy.AllowAnyOrigin();
        policy.WithOrigins("https://localhost:7220").AllowAnyHeader().AllowAnyMethod();
    });
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<WikiApiContext>();


    //db.Database.EnsureDeleted();
    //db.Database.Migrate();

    try
    {
        //await SeedData.InitAsync(app);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        throw;
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
