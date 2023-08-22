

using CarvedRock.Api.Data;
using CarvedRock.Api.GraphQL;
using CarvedRock.Api.Repositories;
using HotChocolate;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder();

builder.Services.AddDbContext<CarvedRockDbContext>(options =>
                options.UseSqlite(builder.Configuration["ConnectionStrings:CarvedRock"]));

builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductReviewRepository>();

builder.Services.AddGraphQLServer()
    .AddQueryType<CarvedRockQuery>()
    .AddMutationType<CarvedRockMutation>()
    .AddSubscriptionType<CarvedRockSubscription>()
    .AddInMemorySubscriptions()
    .RegisterService<ProductRepository>(ServiceKind.Resolver)
    .RegisterService<ProductReviewRepository>(ServiceKind.Resolver);

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
