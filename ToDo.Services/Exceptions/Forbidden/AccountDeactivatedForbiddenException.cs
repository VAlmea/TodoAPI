namespace ToDo.Services.Exceptions
{
    public class AccountDeactivatedForbiddenException : BaseForbiddenException
    {
        public AccountDeactivatedForbiddenException() : base()
        {
            CustomCode = 403002;
            //CustomMessage = localizer.GetString(CustomCode.ToString());
        }
    }
}