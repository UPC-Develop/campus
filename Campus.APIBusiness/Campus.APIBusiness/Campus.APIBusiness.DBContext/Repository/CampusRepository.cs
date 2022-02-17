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
        public BaseResponse List_Campus(Int32 campus_id, int active)
        {

            var list_CampusEntity = new List<List_CampusEntity>();
            var returnEntity = new BaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_List_Campus";

                    var p = new DynamicParameters();

                    p.Add(name: "@campus_id", value: campus_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@active", value: active, dbType: DbType.Int16, direction: ParameterDirection.Input);

                    list_CampusEntity = db.Query<List_CampusEntity>(sql: sql, param: p, commandType: CommandType.StoredProcedure).ToList();

        
                    if (list_CampusEntity.Count > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = list_CampusEntity;
                    }
                    else
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = null;
                    }
                }
            }
            catch (Exception ex)
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
