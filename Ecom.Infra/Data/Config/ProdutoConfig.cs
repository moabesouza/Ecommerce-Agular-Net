using Ecom.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecom.Infra.Data.Configuration
{
    public class ProdutoConfig : IEntityTypeConfiguration<PRD_Produto>
    {
        public void Configure(EntityTypeBuilder<PRD_Produto> builder)
        {
            builder.Property(x => x.id).IsRequired();
            builder.Property(x => x.prd_nm_nome).HasMaxLength(50);
            builder.Property(x => x.prd_ds_descricao).HasMaxLength(500);          
            builder.Property(x => x.prd_vl_valor).HasColumnType("decimal(18, 2)");
            builder.HasOne(x => x.Categoria).WithMany(p => p.Produto).HasForeignKey(p => p.prd_id_categoria);
            builder.HasData(
                new PRD_Produto { id = 1, prd_nm_nome = "Sabão em Pó", prd_ds_descricao = "Sabão em pó para lavar roupas", prd_vl_valor = 9.99m, prd_id_categoria = 1, prd_nm_imagem = "https://" },
                new PRD_Produto { id = 2, prd_nm_nome = "Carne Moída", prd_ds_descricao = "Carne bovina moída fresca", prd_vl_valor = 15.99m, prd_id_categoria = 2, prd_nm_imagem = "https://" },
                new PRD_Produto { id = 3, prd_nm_nome = "Leite Integral", prd_ds_descricao = "Leite integral pasteurizado", prd_vl_valor = 3.49m, prd_id_categoria = 3, prd_nm_imagem = "https://" },
                new PRD_Produto { id = 4, prd_nm_nome = "Maçã", prd_ds_descricao = "Maçãs frescas selecionadas", prd_vl_valor = 2.49m, prd_id_categoria = 4, prd_nm_imagem = "https://" },
                new PRD_Produto { id = 5, prd_nm_nome = "Pão Francês", prd_ds_descricao = "Pão francês fresco e crocante", prd_vl_valor = 1.29m, prd_id_categoria = 5, prd_nm_imagem = "https://" },
                new PRD_Produto { id = 6, prd_nm_nome = "Refrigerante Coca-Cola", prd_ds_descricao = "Refrigerante sabor cola", prd_vl_valor = 5.99m, prd_id_categoria = 6, prd_nm_imagem = "https://" },
                new PRD_Produto { id = 7, prd_nm_nome = "Arroz Integral", prd_ds_descricao = "Arroz integral de qualidade", prd_vl_valor = 4.79m, prd_id_categoria = 7, prd_nm_imagem = "https://" },
                new PRD_Produto { id = 8, prd_nm_nome = "Atum Enlatado", prd_ds_descricao = "Atum enlatado em óleo", prd_vl_valor = 2.99m, prd_id_categoria = 8, prd_nm_imagem = "https://" },
                new PRD_Produto { id = 9, prd_nm_nome = "Shampoo Dove", prd_ds_descricao = "Shampoo para cabelos normais a secos", prd_vl_valor = 8.49m, prd_id_categoria = 9, prd_nm_imagem = "https://" },
                new PRD_Produto { id = 10, prd_nm_nome = "Fralda Pampers", prd_ds_descricao = "Fralda descartável para bebês", prd_vl_valor = 39.99m, prd_id_categoria = 10, prd_nm_imagem = "https://" },
                new PRD_Produto { id = 11, prd_nm_nome = "Salgadinho Doritos", prd_ds_descricao = "Salgadinho de milho sabor queijo", prd_vl_valor = 6.49m, prd_id_categoria = 11, prd_nm_imagem = "https://" },
                new PRD_Produto { id = 12, prd_nm_nome = "Azeite de Oliva", prd_ds_descricao = "Azeite de oliva extravirgem", prd_vl_valor = 12.99m, prd_id_categoria = 12, prd_nm_imagem = "https://" },
                new PRD_Produto { id = 13, prd_nm_nome = "Pizza Congelada", prd_ds_descricao = "Pizza de mussarela congelada", prd_vl_valor = 8.99m, prd_id_categoria = 13, prd_nm_imagem = "https://" },
                new PRD_Produto { id = 14, prd_nm_nome = "Chocolate Ao Leite", prd_ds_descricao = "Chocolate ao leite cremoso", prd_vl_valor = 3.29m, prd_id_categoria = 14 , prd_nm_imagem = "https://" },
                new PRD_Produto { id = 15, prd_nm_nome = "Desinfetante Pinho Sol", prd_ds_descricao = "Desinfetante para limpeza de superfícies", prd_vl_valor = 7.99m, prd_id_categoria = 15, prd_nm_imagem = "https://" },
                new PRD_Produto { id = 16, prd_nm_nome = "Molho de Pimenta Tabasco", prd_ds_descricao = "Molho de pimenta picante", prd_vl_valor = 10.99m, prd_id_categoria = 16, prd_nm_imagem = "https://" },
                new PRD_Produto { id = 17, prd_nm_nome = "Café Solúvel Nescafé", prd_ds_descricao = "Café solúvel instantâneo", prd_vl_valor = 11.49m, prd_id_categoria = 17, prd_nm_imagem = "https://" },
                new PRD_Produto { id = 18, prd_nm_nome = "Balão de Aniversário", prd_ds_descricao = "Balão decorativo para festas", prd_vl_valor = 3.99m, prd_id_categoria = 18, prd_nm_imagem = "https://" },
                new PRD_Produto { id = 19, prd_nm_nome = "Papel Higiênico Neve", prd_ds_descricao = "Papel higiênico macio e resistente", prd_vl_valor = 6.79m, prd_id_categoria = 19, prd_nm_imagem = "https://" },
                new PRD_Produto { id = 20, prd_nm_nome = "Panela de Pressão Tramontina", prd_ds_descricao = "Panela de pressão em alumínio", prd_vl_valor = 89.99m, prd_id_categoria = 20, prd_nm_imagem = "https://" }
            );
        }
    }
}
