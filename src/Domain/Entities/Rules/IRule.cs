namespace Domain.Entities.Rules;

public interface IRule<T>
{
    Task Run(T target);
}