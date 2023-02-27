using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class PunctuationConfiguration : IEntityTypeConfiguration<Punctuation>
    {
        public void Configure(EntityTypeBuilder<Punctuation> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Player);
            builder.Property(b => b.DepartureDate);
            builder.Property(b => b.Points);
        }
    }
}
