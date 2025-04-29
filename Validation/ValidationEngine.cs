namespace Validation;

// Motor de validação - combina e executa as validações
public class ValidationEngine
{
    private readonly ValidatorFactory _validatorFactory;
    private readonly Dictionary<string, ValidationTemplate> _templates;

    public ValidationEngine()
    {
        _validatorFactory = new ValidatorFactory();
        _templates = new Dictionary<string, ValidationTemplate>();
    }

    public void RegisterTemplate(ValidationTemplate template)
    {
        _templates[template.TemplateName] = template;
    }

    public async Task<ValidationResult> ValidateAsync(string templateName, object data)
    {
        if (!_templates.TryGetValue(templateName, out var template))
        {
            return ValidationResult.Failure($"Template não encontrado: {templateName}");
        }

        var errors = new List<string>();
        bool isValid = true;

        foreach (var validatorName in template.ValidatorsToExecute)
        {
            try
            {
                var validator = _validatorFactory.GetValidator(validatorName);
                var result = await validator.ValidateAsync(data);

                if (!result.IsValid)
                {
                    isValid = false;
                    errors.AddRange(result.Errors);
                    errors.Add(result.Message);
                }
            }
            catch (Exception ex)
            {
                isValid = false;
                errors.Add($"Erro ao executar validador {validatorName}: {ex.Message}");
            }
        }

        if (isValid)
            return ValidationResult.Success();
        else
            return ValidationResult.Failure("Validação falhou", errors);
    }
}