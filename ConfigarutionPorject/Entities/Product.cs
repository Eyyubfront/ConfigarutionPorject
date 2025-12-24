using ConfigarutionPorject.Entities.BaseEntitiy;

namespace ConfigarutionPorject.Entities
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
      
        public int CategoryId { get; set; }
        public Category Category { get; set; }

       
    }
}
