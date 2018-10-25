﻿using System.Data;
using Dapper;
using Restneer.Core.Domain.Model.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Restneer.Core.Infrastructure.Repository
{
    public class ApiUserRepository : IApiUserRepository
    {
        readonly IDbConnection _connection;
        public IConfiguration Configuration { get; set; }
        public ILogger<IApiUserRepository> Logger { get; set; }

        public ApiUserRepository(
            IDbConnection connection, 
            ILogger<IApiUserRepository> logger, 
            IConfiguration configuration
        )
        {
            _connection = connection;
            Logger = logger;
            Configuration = configuration;
        }

        public async Task<ApiUserEntity> Authenticate(string email, string encryptedPassword)
        {
            try 
            {
                var sql = @"SELECT api_user.id,
                                   api_user.email,
                                   api_role.id
                            FROM api_user 
                            INNER JOIN api_role ON api_role.id = api_user.api_role_id
                            WHERE api_user.email = LOWER(@Email)
                            AND api_user.password = @Password
                            AND api_user.status = 1
                            LIMIT 1";
                var result = await _connection.QueryAsync<ApiUserEntity, ApiRoleEntity, ApiUserEntity>(
                    sql,
                    map: (apiUser, apiRole) => {
                        apiUser.ApiRole = apiRole;
                        return apiUser;
                    },
                    param: new
                    {
                        Email = email,
                        Password = encryptedPassword
                    }
                );
                return result.FirstOrDefault();
            } catch {
                throw;
            }

        }
    }
}
