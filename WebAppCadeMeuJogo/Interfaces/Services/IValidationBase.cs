namespace WebAppCadeMeuJogo.Interfaces.Services
{
    public interface IValidationBase<T> where T:class
    {
        bool IsValid(T obj);
    }
}
