using ASPNETCoreWebApplication.Model;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Net.Http.Json;
using System.Text;

public class MyHttpClient
{
    private readonly ILogger _logger;
    private IHttpClientFactory _httpFactory { get; set; }
    public MyHttpClient(ILogger<MyHttpClient> logger,IHttpClientFactory httpFactory)
    {
        _logger = logger;
        _httpFactory = httpFactory;
    }

    public async Task Run(string nameConnect)
    {
        var client = _httpFactory.CreateClient(nameConnect);
        //id = 4 по id = 13.
        ConcurrentBag<ResponseBlog> responseBlog = new ConcurrentBag<ResponseBlog>();
        List<Task> tasks = new List<Task>();
        for (int id = 4; id < 14; id++)
        {
            var url =$"posts/{id}";
            tasks.Add(Task.Run(async () =>
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);
                var res = await response.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<ResponseBlog>();
                if (res !=null) responseBlog.Add(res);
               
            }));
        }
        Task.WhenAll(tasks).Wait();
        var nl = Environment.NewLine;
        var path = "result.txt";
        if (File.Exists(path)) File.Delete(path);
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var item in  responseBlog.AsParallel().AsOrdered())
        {
            stringBuilder.Append($"{item.userId}{nl}{item.id}{nl}{item.title}{nl}{item.body}{nl}");
        }
        await File.AppendAllTextAsync(path, stringBuilder.ToString());
    }
}
