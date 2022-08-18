// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var nameConnect = "MyBlog";
Console.WriteLine("Hello, World!");
var builder = new HostBuilder()
              .ConfigureServices((hostContext, services) =>
              {
                  services.AddHttpClient(nameConnect, x =>
                  {
                      x.BaseAddress = new Uri("http://jsonplaceholder.typicode.com");
                      x.DefaultRequestHeaders.Add("Accept", "application/json");
                  });
                  services.AddTransient<MyHttpClient>();
              }).UseConsoleLifetime();

var host = builder.Build();

using (var serviceScope = host.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    try
    {
        var myService = services.GetRequiredService<MyHttpClient>();
        await myService.Run(nameConnect);
        Console.WriteLine("Write file");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
