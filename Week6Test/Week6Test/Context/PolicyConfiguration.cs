using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6Test.Models;

namespace Week6Test.Context
{
    public class PolicyConfiguration : IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            builder.ToTable("Policy");
            builder.HasKey(n => n.Number);     
            builder.Property(sd => sd.StipulationDate).HasColumnType("datetime2").IsRequired();
            builder.Property(ia => ia.InsuranceAmount).IsRequired();
            builder.Property(mi => mi.MonthlyInstallment).IsRequired();


            builder.HasOne(c => c.Client).WithMany(p => p.Policies).HasForeignKey(ccf => ccf.ClientCF);

            //Per gestire la gerarchia
            builder.HasDiscriminator<string>("policy_type")
                   .HasValue<Policy>("policy")
                   .HasValue<CarRCPolicy>("car_rc_policy")
                   .HasValue<TheftPolicy>("theft_policy")
                   .HasValue<LifePolicy>("life_policy");

        }
    }
}
