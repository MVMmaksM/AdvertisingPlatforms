namespace Application.Interfaces;

/// <summary>
/// объявление методов для скрвиса работы с
/// рекламными площадками
/// </summary>
public interface IAdveristingPlatformsService
{
    Task<List<string>> GetPlatforms(string location);
}