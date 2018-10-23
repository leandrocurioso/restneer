﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Domain.Model.ValueObject;
using Restneer.Core.Infrastructure.Repository;

namespace Restneer.Core.Domain.Logic
{
    public class ApiRoleResourceRouteLogic : AbstractLogic
    {
        readonly ApiRoleResourceRouteRepository _apiRoleResourceRouteRepository;

        public ApiRoleResourceRouteLogic(ApiRoleResourceRouteRepository apiRoleResourceRouteRepository, IConfiguration configuration)
            : base(configuration)
        {
            _apiRoleResourceRouteRepository = apiRoleResourceRouteRepository;
        }

        public virtual async Task<IEnumerable<ApiRoleResourceRouteEntity>> List(QueryParamValueObject<ApiRoleResourceRouteEntity> model)
        {
            try
            {
                return await _apiRoleResourceRouteRepository.List(model);
            }
            catch
            {
                throw;
            }
        }
    }
}