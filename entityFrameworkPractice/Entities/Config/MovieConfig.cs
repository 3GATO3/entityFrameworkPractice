using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace entityFrameworkPractice.Entities.Config
{
    public class MovieConfig: IEntityTypeConfiguration<Movie>
    {
        public void Configure (EntityTypeBuilder<Movie> builder)
        {
            builder.Property(a => a.Premiere).HasColumnType("date");
        }
        
    }
}
