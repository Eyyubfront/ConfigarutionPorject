namespace ConfigarutionPorject.Entities.BaseEntitiy
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        private DateTime UpdatedAt { get; set; }
    }
}
