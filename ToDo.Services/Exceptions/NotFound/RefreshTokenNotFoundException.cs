namespace ToDo.Services.Exceptions
{
    public class RefreshTokenNotFoundException : BaseNotFoundException
    {
        public RefreshTokenNotFoundException() : base()
        {
            CustomCode = 404003;
            //CustomMessage = localizer.GetString(CustomCode.ToString());
        }
    }
}