using ConfigarutionPorject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigarutionPorject.DAL.Configration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
         
            builder.HasKey(p => p.Id);

        
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(300);

            builder.Property(p => p.Price)
                   .IsRequired()
                   .HasColumnType("decimal(20,2)");

            builder.HasOne(p => p.Category)          
                   .WithMany(b => b.Products)    
                   .HasForeignKey(p => p.CategoryId) 
                   .OnDelete(DeleteBehavior.Cascade); 

        }
    }
}
