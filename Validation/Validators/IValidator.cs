using System.ComponentModel.DataAnnotations;

namespace Validation;

// Interfaces - Definindo contratos para validação
public interface IValidator
{
    string Name { get; }
    
    Task<ValidationResult> ValidateAsync(object data);
}