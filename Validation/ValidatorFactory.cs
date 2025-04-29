namespace Validation;

// Factory para criar validadores
public class ValidatorFactory
{
    private readonly Dictionary<string, Func<IValidator>> _validators;

    public ValidatorFactory()
    {
        _validators = new Dictionary<string, Func<IValidator>>
        {
            { "AgeValidator", () => new AgeValidator() },
            { "AntiFraudValidator", () => new AntiFraudValidator() },
            { "DocumentValidator", () => new DocumentValidator() }
        };
    }

    public IValidator GetValidator(string validatorName)
    {
        if (_validators.TryGetValue(validatorName, out var factory))
        {
            return factory();
        }

        throw new ArgumentException($"Validador não encontrado: {validatorName}");
    }
}