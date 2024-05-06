using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public List<EntityUser> GetUsers()
        {
            var returnEntity = new List<EntityUser>();
            using (var db = GetSqlConnection())
            {
                const string sql = @"usp_ObtenerDepartamentos";


                returnEntity = db.Query<EntityUser>(sql,
                    commandType: CommandType.StoredProcedure).ToList();
            }
            return returnEntity;
        }
        public EntityBaseResponse ValidUser(string userName, string Contrasena)
        {
            var response = new EntityBaseResponse();
            var returnEntity = new List<EntityUser>();
            try
            {
                using (var db = GetSqlConnection())
                {
                    var user = new EntityUser();
                    const string sql = @"usp_ValidaUsuario";
                    var p = new DynamicParameters();
                    p.Add(name: "@Usuario", value: userName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@Contrasena", value: Contrasena, dbType: DbType.String, direction: ParameterDirection.Input);

                    user = db.Query<EntityUser>(
                                sql: sql,
                                param: p,
                                commandType: CommandType.StoredProcedure
                            ).FirstOrDefault();
                    if (user != null)
                    {
                        response.IsSuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = user;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = null;
                    }
                }
            }

            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorCode = "0001";
                response.ErrorMessage = ex.Message;
                response.Data = null;
            }

            return response;
        }
    }
}
