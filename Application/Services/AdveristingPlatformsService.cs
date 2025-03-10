using System.Text;
using Application.Interfaces;

namespace Application.Services;

/// <summary>
/// сервис получения платформ
/// по введенной локации
/// </summary>
/// <param name="platforms"></param>
public class AdveristingPlatformsService(IStorageService platforms) : IAdveristingPlatformsService
{
    public async Task<List<string>> GetPlatforms(string location)
    {
        var result = new List<string>();

        var locationSplit = location.Split("/");
        locationSplit= locationSplit
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .ToArray();

        var strBuilder = new StringBuilder();

        for (int i = 0; i < locationSplit.Length; i++)
        {
            strBuilder.Append(string.Concat("/",locationSplit[i]));
            var platform = platforms.GetPlatforms(strBuilder.ToString());
            
            if(platform != null)
                result.Add(platform);
        }
        
        return result;
    }
}