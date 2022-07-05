namespace GlacierByte.Discord.Server.Api;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class LongTermFileService : IFileService {
    private readonly string BasePath;
    public LongTermFileService(string basePath) {
        BasePath = basePath;
    }

    public async Task<T> getFileData<T>(string keyId) {
        using(StreamReader fileOpened = new StreamReader($"{BasePath}/keyId")) {
            var data = await fileOpened.ReadToEndAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
    
    public async void setFileData<T>(string keyId, T data) {
        string jsonData = JsonConvert.SerializeObject(data);
        using(StreamWriter fileOpened = new StreamWriter($"{BasePath}/keyId")) {
            await fileOpened.WriteAsync(jsonData);
        }
    }
}