namespace ToDo.Data.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}