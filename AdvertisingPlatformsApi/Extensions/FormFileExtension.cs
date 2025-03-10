namespace AdvertisingPlatformsApi.Extensions;

public static class FormFileExtension
{
    /// <summary>
    /// метод расширения для IFIleForm
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public static List<string> ReadAllLines(this IFormFile file)
    {
        var result = new List<string>();
        using (var reader = new StreamReader(file.OpenReadStream()))
        {
            while (reader.Peek() >= 0)
                result.Add(reader.ReadLine().Trim()); 
        }
        return result;
    }
}