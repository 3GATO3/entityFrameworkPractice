using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace entityFrameworkPractice.Entities.Config
{
    public class ActorConfig: IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(C => C.BirthDate).HasColumnType("date");
            builder.Property(C => C.Fortune).HasPrecision(18, 2);
        }

    }
}
