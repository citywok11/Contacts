using Contacts.Client;
using Contacts.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IContactsService, ContactsService>();

builder.Services.AddHttpClient<IContactsService, ContactsService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7228/");
});

await builder.Build().RunAsync();
