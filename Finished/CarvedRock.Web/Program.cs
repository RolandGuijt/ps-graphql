using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddCarvedRockClient()
    .ConfigureHttpClient(client => 
        client.BaseAddress = new Uri("https://localhost:5001/graphql"))
    .ConfigureWebSocketClient(client => client.Uri = new Uri("ws://localhost:5001/graphql"));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();