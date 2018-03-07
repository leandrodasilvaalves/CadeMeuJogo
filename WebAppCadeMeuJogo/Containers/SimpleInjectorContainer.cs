using SimpleInjector;
using SimpleInjector.Diagnostics;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
using WebAppCadeMeuJogo.Interfaces.Context;
using WebAppCadeMeuJogo.Interfaces.Services;
using WebAppCadeMeuJogo.Models.Context;
using WebAppCadeMeuJogo.Services;

namespace WebAppCadeMeuJogo.Containers
{
    public static class SimpleInjectorContainer
    {
        public static void RegisterComponents()
        {

            var container = new Container();

            //Registrando as Implementações
            container.Register<ICadeMeuJogoContext, CadeMeuJogoContext>();
            container.Register<ICategoriaValidation, CategoriaValidation>();
            container.Register<IAmigoValidation, AmigoValidation>();

            Registration registration = container.GetRegistration(typeof(CadeMeuJogoContext)).Registration;
            registration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent,
                "Reason of suppression");

            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

       
    }
}