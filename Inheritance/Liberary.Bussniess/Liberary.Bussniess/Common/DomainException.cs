namespace SwiftBite.Common;

// Thrown when a business rule is broken. RuleId links the error back to the SRS (e.g. "BR-12").
public class DomainException : Exception
{


    public DomainException(string message)
        : base($" {message}") { }
}
