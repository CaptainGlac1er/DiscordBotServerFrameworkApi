namespace GlacierByte.Discord.Server.Api;
using System.Threading.Tasks;

public interface IFileService {
    public Task<T> getFileData<T>(string keyId);
    
    public Task setFileData<T>(string keyId, T data);
}