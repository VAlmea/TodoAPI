namespace ToDo.Services.Exceptions
{
    public class UserNotFoundException : BaseNotFoundException
    {
        public UserNotFoundException() : base()
        {
            CustomCode = 404001;
            //CustomMessage = localizer.GetString(CustomCode.ToString());
        }
    }
}