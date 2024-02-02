namespace banks_course.Exceptions;

public class ParseException(string message) : Exception(message)
{
    public static ParseException BecauseErrorParsingDate(string source)
    {
        var errorMessage = $"Can't read date from ({source}).";
        return new ParseException(errorMessage);
    }
    
    public static ParseException BecauseErrorParsingEmptyDate()
    {
        const string errorMessage = "Can't read date, string is empty.";
        return new ParseException(errorMessage);
    }
}