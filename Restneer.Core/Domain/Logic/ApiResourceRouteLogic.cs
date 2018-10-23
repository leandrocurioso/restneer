﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Domain.Model.ValueObject;
using Restneer.Core.Infrastructure.Repository;

namespace Restneer.Core.Domain.Logic
{
    public class ApiResourceRouteLogic : AbstractLogic
    {
        readonly ApiResourceRouteRepository _apiResourceRouteRepository;

        public ApiResourceRouteLogic(ApiResourceRouteRepository apiResourceRouteRepository, IConfiguration configuration)
            : base(configuration)
        {
            _apiResourceRouteRepository = apiResourceRouteRepository;
        }

        public virtual async Task<IEnumerable<ApiResourceRouteEntity>> List(QueryParamValueObject<ApiResourceRouteEntity> model)
        {
            try
            {
                return await _apiResourceRouteRepository.List(model);
            }
            catch
            {
                throw;
            }
        }
    }
}