using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddCarvedRockClient()
    .ConfigureHttpClient(client => 
        client.BaseAddress = new Uri(builder.Configuration["CarvedRockApiUri"]));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();