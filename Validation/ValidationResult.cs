namespace Validation;

public class ValidationResult
{
    public bool IsValid { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; } = new List<string>();

    public static ValidationResult Success() => new ValidationResult { IsValid = true, Message = "Validação bem-sucedida" };
    public static ValidationResult Failure(string message, List<string> errors = null) => 
        new ValidationResult { IsValid = false, Message = message, Errors = errors ?? new List<string>() };
}