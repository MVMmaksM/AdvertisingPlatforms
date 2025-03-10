namespace Application.Interfaces;

/// <summary>
/// объяление методов
/// для сервиса хранилища данных 
/// </summary>
public interface IStorageService
{
    string GetPlatforms(string location);
    void AddPlatform(List<string> platforms);
}