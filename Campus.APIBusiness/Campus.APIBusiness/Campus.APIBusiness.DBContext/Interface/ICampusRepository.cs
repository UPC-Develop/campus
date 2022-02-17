using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace Campus.APIBusiness.DBContext.Interface
{
    public interface ICampusRepository
    {
        public BaseResponse List_Campus(Int32 active);
    }
}
