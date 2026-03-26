using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class GitHubReleaseDownloader
{
    private static readonly HttpClient client = new HttpClient();
    
    public static async Task DownloadLatestRelease()
    {
        var repoOwner = "Minecraft-PE-0-6-1";
        var repoName = "minecraft-pe-0.6.1-on-all";
        var releaseUrl = $"https://api.github.com/repos/{repoOwner}/{repoName}/releases/latest";

        client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
        
        var response = await client.GetStringAsync(releaseUrl);
        var release = JObject.Parse(response);
        var asset = release["assets"].First;

        if (asset != null)
        {
            var downloadUrl = asset["url"];
            var fileName = asset["name"].ToString();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            var downloadResponse = await client.GetByteArrayAsync(downloadUrl);
            await File.WriteAllBytesAsync(filePath, downloadResponse);

            Console.WriteLine($"Downloaded: {fileName}");
        }
        else
        {
            Console.WriteLine("No assets found for the latest release.");
        }
    }
}