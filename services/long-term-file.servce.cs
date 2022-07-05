namespace GlacierByte.Discord.Server.Api;
using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class LongTermFileService : IFileService, ISharedService {
    private readonly string BasePath;
    public LongTermFileService(string basePath) {
        BasePath = basePath;
    }

    public async Task<T> getFileData<T>(string keyId) {
        using(StreamReader fileOpened = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}\\{BasePath}\\{keyId}")) {
            var data = await fileOpened.ReadToEndAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
    
    public async Task setFileData<T>(string keyId, T data) {
        string jsonData = JsonConvert.SerializeObject(data);
        string path = $"{AppDomain.CurrentDomain.BaseDirectory}\\{BasePath}";
        Directory.CreateDirectory(path);
        Console.WriteLine($"writting to file {path}\\{keyId}");
        using(StreamWriter fileOpened = new StreamWriter($"{path}\\{keyId}", false)) {
            await fileOpened.WriteAsync(jsonData);
        }
    }
}