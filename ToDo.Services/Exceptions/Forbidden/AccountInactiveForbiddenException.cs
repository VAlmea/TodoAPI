namespace ToDo.Services.Exceptions
{
    public class AccountInactiveForbiddenException : BaseForbiddenException
    {
        public AccountInactiveForbiddenException() : base()
        {
            CustomCode = 403001;
            //CustomMessage = localizer.GetString(CustomCode.ToString());
        }
    }
}