namespace Validation;

public class ValidationTemplate
{
    public string TemplateName { get; set; }
    public List<string> ValidatorsToExecute { get; set; } = new List<string>();
}
