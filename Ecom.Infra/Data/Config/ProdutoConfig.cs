using Ecom.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infra.Data.Configuration
{
    public class ProdutoConfig : IEntityTypeConfiguration<PRD_Produto>
    {
        public void Configure(EntityTypeBuilder<PRD_Produto> builder)
        {
            builder.Property(x => x.id).IsRequired();
            builder.Property(x => x.prd_nm_nome).HasMaxLength(50);
            builder.Property(x => x.prd_nm_nome).HasColumnType("decimal(18, 2)");
            builder.HasOne(x => x.Categoria).WithMany(x => x.Produto).HasForeignKey(x => x.prd_id_categoria);

        }
    }
}
