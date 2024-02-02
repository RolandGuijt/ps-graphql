using CarvedRock.Api.Data;
using CarvedRock.Api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<CarvedRockDbContext>(options =>
    options.UseSqlite(builder.Configuration["ConnectionStrings:CarvedRock"]));

builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductReviewRepository>();

builder.Services
    .AddGraphQLServer()
    .AddTypes();

var app = builder.Build();

app.MapGraphQL();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CarvedRockDbContext>();
    db.Database.Migrate();
}

app.RunWithGraphQLCommands(args);
