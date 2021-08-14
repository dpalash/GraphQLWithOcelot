using Framework.Core.IoC;
using Normal.Core.Interfaces.Repositories;
using Normal.Core.Interfaces.Services;
using Normal.Core.Services;
using Normal.Repository.DBContext;
using Normal.Repository.Repositories;
using Unity;
using Unity.Lifetime;

namespace Normal.MicroService.IoC
{
    public class UnityDependencyProvider : IDependencyProvider
    {
        public void RegisterDependencies(IUnityContainer container)
        {
            container.RegisterType<IAuthenticationDbContext, AuthenticationDbContext>(new SingletonLifetimeManager());
            container.RegisterType<IAuthenticationManagementRepository, AuthenticationManagementRepository>();
            container.RegisterType<IFileUploadService, FileUploadService>();
        }
    }
}
