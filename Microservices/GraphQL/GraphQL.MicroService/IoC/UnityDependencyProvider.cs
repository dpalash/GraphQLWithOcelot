using Framework.Core.IoC;
using GraphQL.Core.Interfaces.Repositories;
using GraphQL.Core.Interfaces.Services;
using GraphQL.Core.Services;
using GraphQL.Repository.Repositories;
using Unity;
using Unity.Lifetime;

namespace GraphQL.MicroService.IoC
{
    public class UnityDependencyProvider : IDependencyProvider
    {
        public void RegisterDependencies(IUnityContainer container)
        {
            container.RegisterType<IAuthorRepository, AuthorRepository>(new SingletonLifetimeManager());
            container.RegisterType<IAuthorService, AuthorService>();
        }
    }
}
