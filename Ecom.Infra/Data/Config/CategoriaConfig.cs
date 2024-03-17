using Ecom.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecom.Infra.Data.Config
{
    public class CategoriaConfig : IEntityTypeConfiguration<CAT_Categoria>
    {
        public void Configure(EntityTypeBuilder<CAT_Categoria> builder)
        {
            builder.Property(x => x.id).IsRequired();
            builder.Property(x => x.cat_nm_nome).HasMaxLength(50);
            builder.HasData(
                new CAT_Categoria { id = 1, cat_nm_nome = "Produtos de Limpeza", cat_ds_descricao = "limpeza" },
                new CAT_Categoria { id = 2, cat_nm_nome = "Carnes", cat_ds_descricao = "Carnes frescas e processadas" },
                new CAT_Categoria { id = 3, cat_nm_nome = "Laticínios", cat_ds_descricao = "Leite, queijo, manteiga, etc." },
                new CAT_Categoria { id = 4, cat_nm_nome = "Frutas e Vegetais", cat_ds_descricao = "Frutas e vegetais frescos" },
                new CAT_Categoria { id = 5, cat_nm_nome = "Padaria", cat_ds_descricao = "Pães, bolos, doces, etc." },
                new CAT_Categoria { id = 6, cat_nm_nome = "Bebidas", cat_ds_descricao = "Refrigerantes, sucos, água, etc." },
                new CAT_Categoria { id = 7, cat_nm_nome = "Cereais e Grãos", cat_ds_descricao = "Arroz, feijão, cereais matinais, etc." },
                new CAT_Categoria { id = 8, cat_nm_nome = "Enlatados", cat_ds_descricao = "Alimentos enlatados e conservas" },
                new CAT_Categoria { id = 9, cat_nm_nome = "Produtos de Higiene Pessoal", cat_ds_descricao = "Sabonetes, shampoos, produtos de cuidados pessoais, etc." },
                new CAT_Categoria { id = 10, cat_nm_nome = "Cuidados com o Bebê", cat_ds_descricao = "Fraldas, produtos de higiene para bebês, etc." },
                new CAT_Categoria { id = 11, cat_nm_nome = "Snacks e Petiscos", cat_ds_descricao = "Salgadinhos, biscoitos, petiscos, etc." },
                new CAT_Categoria { id = 12, cat_nm_nome = "Mercearia", cat_ds_descricao = "Itens diversos de mercearia" },
                new CAT_Categoria { id = 13, cat_nm_nome = "Congelados", cat_ds_descricao = "Alimentos congelados, como pizzas, vegetais, etc." },
                new CAT_Categoria { id = 14, cat_nm_nome = "Doces e Sobremesas", cat_ds_descricao = "Chocolate, sobremesas prontas, etc." },
                new CAT_Categoria { id = 15, cat_nm_nome = "Produtos de Limpeza Doméstica", cat_ds_descricao = "Produtos específicos para limpeza doméstica" },
                new CAT_Categoria { id = 16, cat_nm_nome = "Condimentos e Temperos", cat_ds_descricao = "Sal, pimenta, molhos, etc." },
                new CAT_Categoria { id = 17, cat_nm_nome = "Café, Chá e Bebidas Quentes", cat_ds_descricao = "Café, chá, achocolatados, etc." },
                new CAT_Categoria { id = 18, cat_nm_nome = "Artigos de Festa", cat_ds_descricao = "Decorações, balões, etc." },
                new CAT_Categoria { id = 19, cat_nm_nome = "Produtos de Papelaria", cat_ds_descricao = "Papel higiênico, guardanapos, etc." },
                new CAT_Categoria { id = 20, cat_nm_nome = "Artigos de Cozinha", cat_ds_descricao = "Utensílios de cozinha, panelas, etc." }
            );
        }
    }
}
