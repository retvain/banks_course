namespace banks_course.Exceptions;

public class ValidateException : Exception
{
    public ValidateException(string message) : base(message)
    {
    }
    
    public static ValidateException BecauseDateIsNotValid(string date)
    {
        string errorMessage = $"Date - ({date}) is not valid. Please insert date in format YYYY-MM-DD";
        return new ValidateException(errorMessage);
    }
    
    public static ValidateException BecauseDateIsEmpty()
    {
        string errorMessage = $"Date is empty. Please insert date in format YYYY-MM-DD";
        return new ValidateException(errorMessage);
    }
}