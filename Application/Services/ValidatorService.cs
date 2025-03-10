using Application.Interfaces;
using Application.Models;

namespace Application.Services;

/// <summary>
/// класс для примитивной валидации
/// входящих данных
/// </summary>
public class ValidatorService : IValidatorService
{
    /// <summary>
    /// получает на вход строки с
    /// загружаемого файла
    /// и валидирует их
    /// </summary>
    /// <param name="lineFile"></param>
    /// <returns></returns>
    public ValidationResult ValidateUploadFile(List<string> lineFile)
    {
        var result = new ValidationResult();

        if (lineFile == null || lineFile.Count == 0)
        {
            result.ErrorMessge = "Файл не может быть пустым!";
            result.IsValidate = false;
        }

        for (int i = 0; i < lineFile.Count(); i++)
        {
            var splitLine = lineFile[i].Split(":");
            if (splitLine.Length != 2)
            {
                result.ErrorMessge += $"\nОшибка в строке: {i + 1}, строка должна содержать \"имя площадки:имя_локации,имя_локации\"";
                result.IsValidate = false;
            }

            var locations = splitLine[1].Split(",");
            if (locations.Length == 0)
            {
                result.ErrorMessge += $"\nОшибка в строке: {i + 1}, не указаны лдокации";
                result.IsValidate = false;
            }

            foreach (var location in locations)
            {
                if (!location.Contains("/") || !location.StartsWith("/"))
                {
                    result.ErrorMessge += $"\nОшибка в строке: {i + 1}, неверно указаны имена локаций";
                    result.IsValidate = false;
                }
            }
        }
        
        return result;
    }

    /// <summary>
    /// получает на вход параметр location
    /// и валидирует его
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    public ValidationResult ValidateLocationParameter(string location)
    {
        var result = new ValidationResult();

        if (string.IsNullOrWhiteSpace(location))
        {
            result.ErrorMessge = "Локация не может быть пустой!";
            result.IsValidate = false;
        }

        if (!location.Contains("/") || !location.StartsWith("/"))
        {
            result.ErrorMessge += "Неверно указано имя локации";
            result.IsValidate = false;
        }
        
        return result;
    }
}