﻿using CarvedRock.Api.Data;
using CarvedRock.Api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

builder.Services.AddDbContextPool<CarvedRockDbContext>(options =>
                options.UseSqlite(builder.Configuration["ConnectionStrings:CarvedRock"]));

builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductReviewRepository>();

builder.Services.AddGraphQLServer()    
    .AddTypes()
    .AddInMemorySubscriptions();

builder.Services.AddCors();

var app = builder.Build();

app.UseWebSockets();

app.UseRouting();
app.UseCors(b =>
    b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.MapGraphQL();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CarvedRockDbContext>();
    db.Database.Migrate();
}

await app.RunWithGraphQLCommandsAsync(args);
