using ConfigarutionPorject.Entities.BaseEntitiy;
using System.ComponentModel.DataAnnotations;

namespace ConfigarutionPorject.Entities
{
    public class Category: BaseEntity
    {
      
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Product> Products { get; set; }

    }
}
