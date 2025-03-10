using System.Collections.Concurrent;
using Application.Interfaces;

namespace Application.Services;

/// <summary>
/// класс - хранилище
/// </summary>
public class MemoryStorageService : IStorageService
{
    private readonly ConcurrentDictionary<string, string> _advertistingPlatforms;

    public MemoryStorageService()
    {
        _advertistingPlatforms = new ConcurrentDictionary<string, string>();
    }
    
    /// <summary>
    /// метод получения платформы
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    public string? GetPlatformsByLocation(string location) =>
        _advertistingPlatforms.TryGetValue(location, out var result) ? result : null;

    /// <summary>
    /// метод для добавления платформ и локаций
    /// </summary>
    /// <param name="platforms"></param>
    public void AddPlatform(List<string> platforms)
    {
        _advertistingPlatforms.Clear();
        
        platforms.ForEach(p =>
        {
            var splitPlatorms = p.Split(':');
            if (splitPlatorms.Length == 2)
            {
                var locations = splitPlatorms[1]
                    .Split(",")
                    .ToList();
                
                locations.ForEach(l =>
                {
                    _advertistingPlatforms.TryAdd(l, splitPlatorms[0]);
                });
            }
        });
    }
}