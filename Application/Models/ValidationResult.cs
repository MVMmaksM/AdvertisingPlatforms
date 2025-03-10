namespace Application.Models;

/// <summary>
/// класс для результата валидации
/// </summary>
public class ValidationResult
{
    public string ErrorMessge { get; set; } = string.Empty;
    public bool IsValidate { get; set; } = true;
}