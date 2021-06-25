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
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(cf => cf.CF);
            builder.Property(cf => cf.CF).HasMaxLength(16).IsFixedLength();
            builder.Property(fn => fn.FirstName).HasMaxLength(20).IsRequired();
            builder.Property(ln => ln.LastName).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Address).HasMaxLength(50).IsRequired();

        }
    }
}
