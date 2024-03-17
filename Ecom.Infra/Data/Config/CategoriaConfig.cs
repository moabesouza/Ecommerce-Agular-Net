using Ecom.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infra.Data.Config
{
    public class CategoriaConfig : IEntityTypeConfiguration<CAT_Categoria>
    {
        public void Configure(EntityTypeBuilder<CAT_Categoria> builder)
        {
            builder.Property(x => x.id).IsRequired();
            builder.Property(x => x.cat_nm_nome).HasMaxLength(50);

        }
    }
}
