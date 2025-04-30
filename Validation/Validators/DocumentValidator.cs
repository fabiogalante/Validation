namespace Validation;

public class DocumentValidator : IValidator
{
    public string Name => "DocumentValidator";

    public async Task<ValidationResult> ValidateAsync(object data)
    {
        if (data is not PersonData person)
            return ValidationResult.Failure("Dados inválidos para validação de documentos");

        if (string.IsNullOrEmpty(person.DocumentNumber))
            return ValidationResult.Failure("Número de documento não fornecido");

        // Simula verificação com API externa de documentos
        bool documentIsValid = await SimulateDocumentValidationApiCallAsync(person.DocumentNumber);
        
        if (!documentIsValid)
            return ValidationResult.Failure("Documento inválido", new List<string> { "O documento informado não foi validado" });

        return ValidationResult.Success();
    }

    private Task<bool> SimulateDocumentValidationApiCallAsync(string documentNumber)
    {
        // Simulação de chamada para API externa de validação de documentos
        // Em produção, aqui seria uma chamada HTTP real para um serviço externo
        
        // Simples validação fictícia para o exemplo
        bool isValid = !string.IsNullOrEmpty(documentNumber) && documentNumber.Length >= 8;
        
        return Task.FromResult(isValid);
    }
}