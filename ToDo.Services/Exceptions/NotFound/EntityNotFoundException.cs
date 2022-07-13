namespace ToDo.Services.Exceptions
{
    public class EntityNotFoundException : BaseNotFoundException
    {
        public EntityNotFoundException(string message) : base()
        {
            CustomCode = 404008;
            CustomMessage = message + " ";
        }
    }
}