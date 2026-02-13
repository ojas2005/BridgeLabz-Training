using System.Text.RegularExpressions;

public class EmailValidationService
{
    private readonly Regex _pattern;
    public EmailValidationService()
    {
        string rule = @"^[a-zA-Z0-9._]+@[a-zA-Z]+\.[a-zA-Z]{2,6}$";
        _pattern = new Regex(rule,RegexOptions.Compiled); //when using regex for multiple email validation we can use it in compile time mode rather than its default interpreted mode
        //we initialised regex in constructor cause validating emails one by one using IsMatch is more expensive and its better to use constructor in such cases
    }
    public void Validate(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new InvalidEmailException("kindly do not enter empty emails");
        if (!_pattern.IsMatch(email))
            throw new InvalidEmailException("invalid email format");
    }
}

