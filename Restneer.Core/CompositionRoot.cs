﻿using System.Data;
using Restneer.Core.Application.Boot;
using Restneer.Core.Application.UseCase;
using Restneer.Core.Domain.Logic;
using Restneer.Core.Infrastructure.Connection;
using Restneer.Core.Infrastructure.Connection.MySql;
using Restneer.Core.Infrastructure.Repository;
using Restneer.Core.Infrastructure.Utility;
using SimpleInjector;

namespace Restneer.Core
{
    public static class CompositionRoot
    {
        public static void Register(Container container)
        {
            try
            {
                RegisterFactory(container);
                RegisterGeneral(container);
                RegisterRepository(container);
                RegisterLogic(container);
                RegisterUseCase(container);
            }
            catch
            {
                throw;
            }
        }

        static void RegisterFactory(Container container)
        {
            try
            {
                container.Register<ISqlConnectionFactory, MySqlConnectionFactory>(Lifestyle.Singleton);
            }
            catch
            {
                throw;
            }
        }

        static void RegisterGeneral(Container container)
        {
            try
            {
                container.Register<IDbConnection>(() => 
                                                  container.GetInstance<ISqlConnectionFactory>().Fabricate(), Lifestyle.Scoped);

                container.Register<RestneerCacheBoot>(Lifestyle.Singleton);

                container.Register<Sha256Utility>(Lifestyle.Singleton);

                container.Register<JwtUtility>(Lifestyle.Singleton);
            }
            catch
            {
                throw;
            }
        }

        static void RegisterRepository(Container container)
        {
            try
            {
                container.Register<ApiResourceRouteRepository>(Lifestyle.Scoped);
                container.Register<ApiRoleResourceRouteRepository>(Lifestyle.Scoped);
                container.Register<ApiUserRepository>(Lifestyle.Scoped);

            }
            catch
            {
                throw;
            }
        }

        static void RegisterLogic(Container container)
        {
            try
            {
                container.Register<ApiResourceRouteLogic>(Lifestyle.Scoped);
                container.Register<ApiRoleResourceRouteLogic>(Lifestyle.Scoped);
                container.Register<ApiUserLogic>(Lifestyle.Scoped);
            }
            catch
            {
                throw;
            }
        }

        static void RegisterUseCase(Container container)
        {
            try
            {
                container.Register<ApiUserUseCase>(Lifestyle.Scoped);
            }
            catch
            {
                throw;
            }
        }
    }
}