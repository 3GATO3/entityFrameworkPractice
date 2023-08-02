using entityFrameworkPractice.Entities;
using entityFrameworkPractice.src.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace entityFrameworkPractice.src.Domain.Entities.Config
{
    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(a => a.Premiere).HasColumnType("date");
        }

    }
}
