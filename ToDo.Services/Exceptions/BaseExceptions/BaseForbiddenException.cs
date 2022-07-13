using System.Net;

namespace ToDo.Services.Exceptions
{
    public class BaseForbiddenException : CustomBaseException
    {
        public BaseForbiddenException() : base()
        {
            HttpCode = (int)HttpStatusCode.Forbidden;
        }

        public BaseForbiddenException(string message) : base(message)
        {
            HttpCode = (int)HttpStatusCode.Forbidden;
        }
    }
}