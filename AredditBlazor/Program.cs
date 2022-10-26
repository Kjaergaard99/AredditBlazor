using AredditBlazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

<<<<<<< HEAD
await builder.Build().RunAsync();
=======
await builder.Build().RunAsync();
// simpel �ndring daniel ikke kan finde ud af -- trash cunt - enig hader ham
>>>>>>> refs/remotes/origin/master
