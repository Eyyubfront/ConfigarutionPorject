
using ConfigarutionPorject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigarutionPorject.DAL.Configration
{
    public class CategoryConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasKey(p => p.Id);


            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(540);

            builder.Property(p => p.Description)
                   .IsRequired()
                   .HasMaxLength(350);
                  


        }
    }
}
