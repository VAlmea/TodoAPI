namespace ToDo.Services.Exceptions
{
    public class UnauthorizedException : BaseUnauthorizedException
    {
        public UnauthorizedException() : base()
        {
            CustomCode = 401001;
            //CustomMessage = localizer.GetString(CustomCode.ToString());
        }
    }
}