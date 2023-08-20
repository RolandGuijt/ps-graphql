using CarvedRock.Api.Data;
using CarvedRock.Api.GraphQL;
using CarvedRock.Api.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder();

builder.Services.AddDbContext<CarvedRockDbContext>(options =>
                options.UseSqlite(builder.Configuration["ConnectionStrings:CarvedRock"]));

builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductReviewRepository>();

builder.Services.AddGraphQLServer()
    .AddEnumType<ProductTypeEnum>()
    .AddMutationType<CarvedRockMutation>()
    .AddQueryType<CarvedRockQuery>()
    .AddSubscriptionType<CarvedRockSubscription>()
    .AddInMemorySubscriptions();

builder.Services.AddCors();

var app = builder.Build();

app.UseWebSockets();

app.UseRouting();
app.UseCors(builder =>
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.MapGraphQL();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CarvedRockDbContext>();
    db.Database.Migrate();
}

app.Run();
