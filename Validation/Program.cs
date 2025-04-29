// See https://aka.ms/new-console-template for more information



/*
 *
 * Componentes principais do sistema:
   
   Interface IValidator: Define o contrato para todos os validadores
   ValidationResult: Classe para representar o resultado das validações
   ValidationTemplate: Define quais validadores serão executados para cada caso
   ValidatorFactory: Fábrica que cria os validadores conforme necessário
   ValidationEngine: O motor que orquestra a execução dos validadores
   
   Validadores implementados:
   
   AgeValidator: Verifica se a pessoa é maior de idade
   AntiFraudValidator: Simula uma validação antifraude, com chamada a API externa
   DocumentValidator: Valida documentos, também com chamada a API externa
   
   Como funciona:
   
   Você registra diferentes templates de validação (ex: "Cadastro", "Pagamento")
   Em cada template, você define quais validadores devem ser executados
   Ao executar a validação, o motor busca o template e executa os validadores especificados
   As chamadas a APIs externas são simuladas, mas poderiam ser implementadas com HttpClient
 */

using Validation;



// Configurando o motor de validação
var engine = new ValidationEngine();
        
// Registrando templates
engine.RegisterTemplate(new ValidationTemplate
{
    TemplateName = "Cadastro",
    ValidatorsToExecute = new List<string> { "AgeValidator", "DocumentValidator" }
});
        
engine.RegisterTemplate(new ValidationTemplate
{
    TemplateName = "Pagamento",
    ValidatorsToExecute = new List<string> { "AgeValidator", "AntiFraudValidator", "DocumentValidator" }
});
        
// Dados de exemplo
var person = new PersonData
{
    Name = "João Silva",
    Age = 25,
    DocumentNumber = "12345678"
};
        
// Executando validação com template "Cadastro"
var resultCadastro = await engine.ValidateAsync("Cadastro", person);
Console.WriteLine($"Resultado validação Cadastro: {resultCadastro.IsValid}");
if (!resultCadastro.IsValid)
{
    Console.WriteLine("Erros:");
    foreach (var error in resultCadastro.Errors)
    {
        Console.WriteLine($"- {error}");
    }
}
        
// Executando validação com template "Pagamento"
var resultPagamento = await engine.ValidateAsync("Pagamento", person);
Console.WriteLine($"Resultado validação Pagamento: {resultPagamento.IsValid}");
if (!resultPagamento.IsValid)
{
    Console.WriteLine("Erros:");
    foreach (var error in resultPagamento.Errors)
    {
        Console.WriteLine($"- {error}");
    }
}