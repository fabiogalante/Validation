namespace Validation;

// Validadores concretos
public class AgeValidator : IValidator
{
    public string Name => "AgeValidator";

    public Task<ValidationResult> ValidateAsync(object data)
    {
        if (data is not PersonData person)
            return Task.FromResult(ValidationResult.Failure("Dados inválidos para validação de idade"));

        if (person.Age < 18)
            return Task.FromResult(ValidationResult.Failure("Pessoa menor de idade", new List<string> { "Idade mínima requerida: 18 anos" }));

        return Task.FromResult(ValidationResult.Success());
    }
}