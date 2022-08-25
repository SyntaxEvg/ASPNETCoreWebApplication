// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.ServiceProcess;

//string query = "My system drive is %SystemDrive% and my system root is %SystemRoot%";
//var str = Environment.ExpandEnvironmentVariables(query);
//Console.WriteLine("ExpandEnvironmentVariables: {0}  {1}", Environment.NewLine, str);


ProcessStartInfo startInfo = new ProcessStartInfo(@"sc.exe", @"query");
// можно даже скрыть окно запущенного процесса
startInfo.WindowStyle = ProcessWindowStyle.Hidden;
// указываем что программа должна выводить резульат в поток привязанный к свойству StandardOutput
startInfo.RedirectStandardOutput = true;
startInfo.UseShellExecute = false;
startInfo.CreateNoWindow = true;
// запускаем процесс
Process procCommand = Process.Start(startInfo);
// получаем ответ запущенного процесса
StreamReader srIncoming = procCommand.StandardOutput;
string result = srIncoming.ReadToEnd();
Console.WriteLine(result);



ServiceController[] services1 = ServiceController.GetServices();

// try to find service name
foreach (ServiceController service in services1)
{
    Console.WriteLine(service.DisplayName);

}

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
