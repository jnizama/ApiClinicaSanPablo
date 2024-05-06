using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntity;
using Dapper;
using System.Data;

namespace DBContext
{
    public class ImageRepository : BaseRepository, IImageRepository
    {
        public EntityBaseResponse GetImages(string tipo, int id)
        {
            var response = new EntityBaseResponse();

            try
            {
                using(var db = GetSqlConnection())
                {
                    var images = new List<EntityImage>();
                    var sql = tipo.Equals("P") ? "usp_Listar_Images_X_Proyecto" : "usp_Listar_Images_X_Departamento";
                    var p = new DynamicParameters();

                    if (tipo.Equals("P"))
                    {
                        p.Add(name: "@IDPROYECTO", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    } else
                    {
                        p.Add(name: "@IDDEPARTAMENTO", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    }

                    images = db.Query<EntityImage>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).ToList();
                    
                    if (images.Count > 0)
                    {
                        response.IsSuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = images;
                    } else
                    {
                        response.IsSuccess = false;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = null;
                    }
                }
            } catch(Exception ex) 
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
