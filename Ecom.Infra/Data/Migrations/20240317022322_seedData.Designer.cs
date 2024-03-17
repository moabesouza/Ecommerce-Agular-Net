﻿// <auto-generated />
using System;
using Ecom.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecom.Infra.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240317022322_seedData")]
    partial class seedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ecom.Core.Entities.CAT_Categoria", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("cat_ds_descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cat_nm_nome")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("CAT_Categoria");

                    b.HasData(
                        new
                        {
                            id = 1,
                            cat_ds_descricao = "limpeza",
                            cat_nm_nome = "Produtos de Limpeza"
                        },
                        new
                        {
                            id = 2,
                            cat_ds_descricao = "Carnes frescas e processadas",
                            cat_nm_nome = "Carnes"
                        },
                        new
                        {
                            id = 3,
                            cat_ds_descricao = "Leite, queijo, manteiga, etc.",
                            cat_nm_nome = "Laticínios"
                        },
                        new
                        {
                            id = 4,
                            cat_ds_descricao = "Frutas e vegetais frescos",
                            cat_nm_nome = "Frutas e Vegetais"
                        },
                        new
                        {
                            id = 5,
                            cat_ds_descricao = "Pães, bolos, doces, etc.",
                            cat_nm_nome = "Padaria"
                        },
                        new
                        {
                            id = 6,
                            cat_ds_descricao = "Refrigerantes, sucos, água, etc.",
                            cat_nm_nome = "Bebidas"
                        },
                        new
                        {
                            id = 7,
                            cat_ds_descricao = "Arroz, feijão, cereais matinais, etc.",
                            cat_nm_nome = "Cereais e Grãos"
                        },
                        new
                        {
                            id = 8,
                            cat_ds_descricao = "Alimentos enlatados e conservas",
                            cat_nm_nome = "Enlatados"
                        },
                        new
                        {
                            id = 9,
                            cat_ds_descricao = "Sabonetes, shampoos, produtos de cuidados pessoais, etc.",
                            cat_nm_nome = "Produtos de Higiene Pessoal"
                        },
                        new
                        {
                            id = 10,
                            cat_ds_descricao = "Fraldas, produtos de higiene para bebês, etc.",
                            cat_nm_nome = "Cuidados com o Bebê"
                        },
                        new
                        {
                            id = 11,
                            cat_ds_descricao = "Salgadinhos, biscoitos, petiscos, etc.",
                            cat_nm_nome = "Snacks e Petiscos"
                        },
                        new
                        {
                            id = 12,
                            cat_ds_descricao = "Itens diversos de mercearia",
                            cat_nm_nome = "Mercearia"
                        },
                        new
                        {
                            id = 13,
                            cat_ds_descricao = "Alimentos congelados, como pizzas, vegetais, etc.",
                            cat_nm_nome = "Congelados"
                        },
                        new
                        {
                            id = 14,
                            cat_ds_descricao = "Chocolate, sobremesas prontas, etc.",
                            cat_nm_nome = "Doces e Sobremesas"
                        },
                        new
                        {
                            id = 15,
                            cat_ds_descricao = "Produtos específicos para limpeza doméstica",
                            cat_nm_nome = "Produtos de Limpeza Doméstica"
                        },
                        new
                        {
                            id = 16,
                            cat_ds_descricao = "Sal, pimenta, molhos, etc.",
                            cat_nm_nome = "Condimentos e Temperos"
                        },
                        new
                        {
                            id = 17,
                            cat_ds_descricao = "Café, chá, achocolatados, etc.",
                            cat_nm_nome = "Café, Chá e Bebidas Quentes"
                        },
                        new
                        {
                            id = 18,
                            cat_ds_descricao = "Decorações, balões, etc.",
                            cat_nm_nome = "Artigos de Festa"
                        },
                        new
                        {
                            id = 19,
                            cat_ds_descricao = "Papel higiênico, guardanapos, etc.",
                            cat_nm_nome = "Produtos de Papelaria"
                        },
                        new
                        {
                            id = 20,
                            cat_ds_descricao = "Utensílios de cozinha, panelas, etc.",
                            cat_nm_nome = "Artigos de Cozinha"
                        });
                });

            modelBuilder.Entity("Ecom.Core.Entities.PRD_Produto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("Categoriaid")
                        .HasColumnType("int");

                    b.Property<string>("prd_ds_descricao")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("prd_id_categoria")
                        .HasColumnType("int");

                    b.Property<string>("prd_nm_nome")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("prd_vl_valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.HasIndex("Categoriaid");

                    b.ToTable("PRD_Produto");

                    b.HasData(
                        new
                        {
                            id = 1,
                            prd_ds_descricao = "Sabão em pó para lavar roupas",
                            prd_id_categoria = 1,
                            prd_nm_nome = "Sabão em Pó",
                            prd_vl_valor = 9.99m
                        },
                        new
                        {
                            id = 2,
                            prd_ds_descricao = "Carne bovina moída fresca",
                            prd_id_categoria = 2,
                            prd_nm_nome = "Carne Moída",
                            prd_vl_valor = 15.99m
                        },
                        new
                        {
                            id = 3,
                            prd_ds_descricao = "Leite integral pasteurizado",
                            prd_id_categoria = 3,
                            prd_nm_nome = "Leite Integral",
                            prd_vl_valor = 3.49m
                        },
                        new
                        {
                            id = 4,
                            prd_ds_descricao = "Maçãs frescas selecionadas",
                            prd_id_categoria = 4,
                            prd_nm_nome = "Maçã",
                            prd_vl_valor = 2.49m
                        },
                        new
                        {
                            id = 5,
                            prd_ds_descricao = "Pão francês fresco e crocante",
                            prd_id_categoria = 5,
                            prd_nm_nome = "Pão Francês",
                            prd_vl_valor = 1.29m
                        },
                        new
                        {
                            id = 6,
                            prd_ds_descricao = "Refrigerante sabor cola",
                            prd_id_categoria = 6,
                            prd_nm_nome = "Refrigerante Coca-Cola",
                            prd_vl_valor = 5.99m
                        },
                        new
                        {
                            id = 7,
                            prd_ds_descricao = "Arroz integral de qualidade",
                            prd_id_categoria = 7,
                            prd_nm_nome = "Arroz Integral",
                            prd_vl_valor = 4.79m
                        },
                        new
                        {
                            id = 8,
                            prd_ds_descricao = "Atum enlatado em óleo",
                            prd_id_categoria = 8,
                            prd_nm_nome = "Atum Enlatado",
                            prd_vl_valor = 2.99m
                        },
                        new
                        {
                            id = 9,
                            prd_ds_descricao = "Shampoo para cabelos normais a secos",
                            prd_id_categoria = 9,
                            prd_nm_nome = "Shampoo Dove",
                            prd_vl_valor = 8.49m
                        },
                        new
                        {
                            id = 10,
                            prd_ds_descricao = "Fralda descartável para bebês",
                            prd_id_categoria = 10,
                            prd_nm_nome = "Fralda Pampers",
                            prd_vl_valor = 39.99m
                        },
                        new
                        {
                            id = 11,
                            prd_ds_descricao = "Salgadinho de milho sabor queijo",
                            prd_id_categoria = 11,
                            prd_nm_nome = "Salgadinho Doritos",
                            prd_vl_valor = 6.49m
                        },
                        new
                        {
                            id = 12,
                            prd_ds_descricao = "Azeite de oliva extravirgem",
                            prd_id_categoria = 12,
                            prd_nm_nome = "Azeite de Oliva",
                            prd_vl_valor = 12.99m
                        },
                        new
                        {
                            id = 13,
                            prd_ds_descricao = "Pizza de mussarela congelada",
                            prd_id_categoria = 13,
                            prd_nm_nome = "Pizza Congelada",
                            prd_vl_valor = 8.99m
                        },
                        new
                        {
                            id = 14,
                            prd_ds_descricao = "Chocolate ao leite cremoso",
                            prd_id_categoria = 14,
                            prd_nm_nome = "Chocolate Ao Leite",
                            prd_vl_valor = 3.29m
                        },
                        new
                        {
                            id = 15,
                            prd_ds_descricao = "Desinfetante para limpeza de superfícies",
                            prd_id_categoria = 15,
                            prd_nm_nome = "Desinfetante Pinho Sol",
                            prd_vl_valor = 7.99m
                        },
                        new
                        {
                            id = 16,
                            prd_ds_descricao = "Molho de pimenta picante",
                            prd_id_categoria = 16,
                            prd_nm_nome = "Molho de Pimenta Tabasco",
                            prd_vl_valor = 10.99m
                        },
                        new
                        {
                            id = 17,
                            prd_ds_descricao = "Café solúvel instantâneo",
                            prd_id_categoria = 17,
                            prd_nm_nome = "Café Solúvel Nescafé",
                            prd_vl_valor = 11.49m
                        },
                        new
                        {
                            id = 18,
                            prd_ds_descricao = "Balão decorativo para festas",
                            prd_id_categoria = 18,
                            prd_nm_nome = "Balão de Aniversário",
                            prd_vl_valor = 3.99m
                        },
                        new
                        {
                            id = 19,
                            prd_ds_descricao = "Papel higiênico macio e resistente",
                            prd_id_categoria = 19,
                            prd_nm_nome = "Papel Higiênico Neve",
                            prd_vl_valor = 6.79m
                        },
                        new
                        {
                            id = 20,
                            prd_ds_descricao = "Panela de pressão em alumínio",
                            prd_id_categoria = 20,
                            prd_nm_nome = "Panela de Pressão Tramontina",
                            prd_vl_valor = 89.99m
                        });
                });

            modelBuilder.Entity("Ecom.Core.Entities.PRD_Produto", b =>
                {
                    b.HasOne("Ecom.Core.Entities.CAT_Categoria", "Categoria")
                        .WithMany("Produto")
                        .HasForeignKey("Categoriaid");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Ecom.Core.Entities.CAT_Categoria", b =>
                {
                    b.Navigation("Produto");
                });
#pragma warning restore 612, 618
        }
    }
}
