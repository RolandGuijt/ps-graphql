using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CarvedRock.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddCarvedRockClient()
    .ConfigureHttpClient(client => 
        client.BaseAddress = new Uri("https://localhost:5001/graphql"))
    .ConfigureWebSocketClient(client => client.Uri = new Uri("ws://localhost:5001/graphql"));

await builder.Build().RunAsync();