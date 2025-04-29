namespace Validation;

public class AntiFraudValidator : IValidator
{
    public string Name => "AntiFraudValidator";

    public async Task<ValidationResult> ValidateAsync(object data)
    {
        if (data is not PersonData person)
            return ValidationResult.Failure("Dados inválidos para validação antifraude");

        // Simula uma verificação antifraude com API externa
        bool fraudCheckResult = await SimulateAntiFraudApiCallAsync(person);
        
        if (!fraudCheckResult)
            return ValidationResult.Failure("Verificação antifraude falhou", new List<string> { "Possível tentativa de fraude detectada" });

        return ValidationResult.Success();
    }

    private Task<bool> SimulateAntiFraudApiCallAsync(PersonData person)
    {
        // Simulação de chamada para API externa de antifraude
        // Em um cenário real, aqui seria feita uma requisição HTTP para um serviço de antifraude
        
        // Simulando alguma lógica para determinar se é fraude ou não
        bool isSuspicious = person.Name.Contains("Test") || person.Age > 120;
        
        return Task.FromResult(!isSuspicious);
    }
}