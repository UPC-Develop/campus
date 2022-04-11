using System;
using System.Runtime.Serialization;

namespace Campus.APIBusiness.DBContext.Repository
{
    [Serializable]
    internal class CampusNotFoundException : System.Exception
    {
        public CampusNotFoundException()
        {
        }

        public CampusNotFoundException(string message) : base(message)
        {
        }

        public CampusNotFoundException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected CampusNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}