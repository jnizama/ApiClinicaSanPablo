using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using DBEntity;

namespace DBContext
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public EntityBaseResponse GetProject(int id)
        {
            var response = new EntityBaseResponse();

            try
            {
                using(var db = GetSqlConnection())
                {
                    var project = new EntityProject();

                    const string sql = "usp_ObtenerProyecto";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDPROYECTO", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    
                    project = db.Query<EntityProject>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    if( project != null )
                    {
                        var repoImages = new ImageRepository();
                        project.Images = repoImages.GetImages("P", project.IdProyecto).Data as List<EntityImage>;
                        
                        response.IsSuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = project;
                    } else
                    {
                        response.IsSuccess = false;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = null;
                    }
                }
            } catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorCode = "0001";
                response.ErrorMessage = ex.Message;
                response.Data = null;
            }

            return response;
        }

        public EntityBaseResponse GetProjects()
        {
            var response = new EntityBaseResponse();

            try
            {
                using(var db = GetSqlConnection())
                {
                    var projects = new List<EntityProject>();

                    const string sql = "usp_ListarProyectos";
                    projects = db.Query<EntityProject>(
                            sql: sql,
                            commandType: CommandType.StoredProcedure
                        ).ToList(); 

                    if(projects.Count > 0)
                    {
                        var repoImages = new ImageRepository();
                        foreach(var project in projects)
                        {
                            project.Images = repoImages.GetImages("P", project.IdProyecto).Data as List<EntityImage>;
                        }

                        response.IsSuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = projects;
                    } else
                    {
                        response.IsSuccess = false;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = null;
                    }
                }
            } catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorCode = "0001";
                response.ErrorMessage = ex.Message;
                response.Data = null;
            }

            return response;
        }

        public EntityBaseResponse Insert(EntityProject project)
        {
            throw new NotImplementedException();
        }
    }
}