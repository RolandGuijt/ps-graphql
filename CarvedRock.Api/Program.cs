using CarvedRock.Api.Data;
using CarvedRock.Api.GraphQL;
using CarvedRock.Api.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder();

builder.Services.AddDbContext<CarvedRockDbContext>(options =>
                options.UseSqlServer(builder.Configuration["ConnectionStrings:CarvedRock"]));

builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductReviewRepository>();

builder.Services.AddGraphQLServer()
    .AddEnumType<ProductTypeEnum>()
    .AddMutationType<CarvedRockMutation>()
    .AddMutationConventions(applyToAllMutations: true)
    .AddQueryType<CarvedRockQuery>();

builder.Services.AddCors();

var app = builder.Build();

app.UseWebSockets();

app.UseRouting();
app.UseCors(builder =>
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.MapGraphQL();
