using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace entityFrameworkPractice.Entities.Config
{
    public class GenreConfig:IEntityTypeConfiguration<Genre>
    {
        public void Configure (EntityTypeBuilder<Genre> builder)
        {
            var sciFi = new Genre { Id = 5, Name = "Science Fiction" };
            var animation = new Genre { Id = 6, Name = "Animation" };
            builder.HasData(sciFi, animation);

            builder.HasIndex(m=> m.Name).IsUnique();

        }
    }
}
