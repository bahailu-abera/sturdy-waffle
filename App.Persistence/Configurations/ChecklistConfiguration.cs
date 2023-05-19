using App.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configurations;

public class ChecklistConfiguration : IEntityTypeConfiguration<Checklist>
{
    public void Configure(EntityTypeBuilder<Checklist> builder)
    {
        builder.ToTable("Checklists");
        builder.HasKey(c => c.Id);
        // Configure other properties or relationships
    }
}