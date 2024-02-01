namespace banks_course.Services.Contracts;

public interface IValidator<in T>
{
    public void Validate(T value);
}