using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE.Core.Domain;

namespace TE.Data.Configurations
{
    internal class CandidatConfig : IEntityTypeConfiguration<Candidature>
    {
        public void Configure(EntityTypeBuilder<Candidature> builder)
        {
            builder.HasOne(p => p.MyEnseignant)
                 .WithMany(p => p.Candidatures)
                 .HasForeignKey(p => p.EnseignantFk);

            builder.HasOne(p => p.MyConcours)
                 .WithMany(p => p.Candidatures)
                 .HasForeignKey(p => p.ConcoursFk);
            builder.HasKey(r => new
            {
                r.ConcoursFk,
                r.EnseignantFk
            });
        }
    }
}
