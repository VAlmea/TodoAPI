using System.Net;
using ToDo.Services.Exceptions;

namespace ToDo.Services.Exceptions
{
    public class BaseUnauthorizedException : CustomBaseException
    {
        public BaseUnauthorizedException() : base()
        {
            HttpCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}