using System;

namespace ToDo.Services.Exceptions
{
    public class CustomBaseException : Exception
    {
        public int HttpCode { get; set; }
        public int CustomCode { get; set; }
        public string CustomMessage { get; set; }

        public CustomBaseException() : base()
        {
        }

        public CustomBaseException(string message) : base(message)
        {
        }
    }
}