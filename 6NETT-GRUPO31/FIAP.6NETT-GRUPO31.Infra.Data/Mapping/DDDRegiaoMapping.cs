using FIAP._6NETT_GRUPO31.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP._6NETT_GRUPO31.Infra.Data.Mapping
{
    public class DDDRegiaoMapping : IEntityTypeConfiguration<DDDRegiao>
    {
        public void Configure(EntityTypeBuilder<DDDRegiao> builder)
        {
            builder.HasKey(x => x.IdDDDRegiao);

            builder.ToTable("TAB_DDD_REGIAO");

            builder.Property(x => x.Ddd).HasColumnType("varchar(2)");


        }
    }
}
