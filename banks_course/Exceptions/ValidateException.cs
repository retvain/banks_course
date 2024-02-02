namespace banks_course.Exceptions;

public class ValidateException(string message) : Exception(message)
{
    public static ValidateException BecauseDateIsNotValid(string date)
    {
        var errorMessage = $"Date - ({date}) is not valid. Insert date in YYYY-MM-DD format:";
        return new ValidateException(errorMessage);
    }
    
    public static ValidateException BecauseDateIsEmpty()
    {
        const string errorMessage = "Date is empty. Insert date in YYYY-MM-DD format:";
        return new ValidateException(errorMessage);
    }
}