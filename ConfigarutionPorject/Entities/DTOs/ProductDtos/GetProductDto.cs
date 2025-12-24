namespace ConfigarutionPorject.Entities.DTOs.ProductDtos
{
    public class GetProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

    }
}
