using Application.Models;

namespace Application.Interfaces;

/// <summary>
/// объявление методов
/// для сервиса валидации
/// </summary>
public interface IValidatorService
{
    ValidationResult ValidateLinesUploadFile(List<string> lineFile);
    ValidationResult ValidateLocationParameter(string location);
}