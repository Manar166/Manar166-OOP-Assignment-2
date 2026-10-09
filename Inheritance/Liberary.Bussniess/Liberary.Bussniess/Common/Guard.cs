namespace SwiftBite.Common;

// DRY: one place for "check the rule, throw if broken"
public static class Guard
{
    public static void Against(bool brokenRule, string message)
    {
        if (brokenRule) throw new DomainException(message);
    }

    public static string NotEmpty(string? value,  string fieldName)
    {
        Against(string.IsNullOrWhiteSpace(value), $"{fieldName} is required.");
        return value!.Trim();
    }
}
