using System;
using System.Collections.Generic;
using System.Text;
using Campus.APIBusiness.DBContext.Interface;
using DBEntity;
using Campus.APIBusiness.DBEntity.Model;
using Dapper;
using System.Data;
using DBContext;
using System.Linq;


namespace Campus.APIBusiness.DBContext.Repository
{
    public class CampusRepository : BaseRepository, ICampusRepository
    {
        public BaseResponse List_Campus(Int32 active)
        {

            var campusEntity = new List<CampusEntity>();
            var returnEntity = new BaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_List_Campus";

                    var p = new DynamicParameters();

                    p.Add(name: "@active", value: active, dbType: DbType.Int16, direction: ParameterDirection.Input);

                    campusEntity = db.Query<CampusEntity>(sql: sql, param: p, commandType: CommandType.StoredProcedure).ToList();

        
                    if (campusEntity.Count > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = string.Empty;
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = campusEntity;
                    }
                    else
                    {
                        throw new CampusNotFoundException("No se encuentra sedes para el parametro");
                    }
                }
            }
            catch (CampusNotFoundException ex)
            {
                returnEntity.isSuccess = false;
                returnEntity.errorCode = "0001";
                returnEntity.errorMessage = ex.Message;
                returnEntity.data = null;
            }
            return returnEntity;

        }
    }
}
