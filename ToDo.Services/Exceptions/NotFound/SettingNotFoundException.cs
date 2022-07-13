namespace ToDo.Services.Exceptions
{
    public class SettingNotFoundException : BaseNotFoundException
    {
        public SettingNotFoundException() : base()
        {
            CustomCode = 404008;
            //CustomMessage = localizer.GetString(CustomCode.ToString());
        }
    }
}