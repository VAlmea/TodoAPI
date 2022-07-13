using System.Net;

namespace ToDo.Services.Exceptions
{
    public class BaseBadRequestException : CustomBaseException
    {
        public BaseBadRequestException() : base()
        {
            HttpCode = (int)HttpStatusCode.BadRequest;
        }

        public BaseBadRequestException(string message) : base(message)
        {
            HttpCode = (int)HttpStatusCode.BadRequest;
            CustomMessage = message;
        }
    }
}