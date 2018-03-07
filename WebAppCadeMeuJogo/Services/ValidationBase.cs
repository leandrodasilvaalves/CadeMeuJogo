using System;
using WebAppCadeMeuJogo.Interfaces.Services;

namespace WebAppCadeMeuJogo.Services
{
    public class ValidationBase<T> : IValidationBase<T> where T : class
    {
        public virtual bool IsValid(T obj)
        {
            throw new NotImplementedException();
        }
    }
}