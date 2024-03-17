using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecom.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CAT_Categoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cat_nm_nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cat_ds_descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAT_Categoria", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PRD_Produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prd_nm_nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    prd_ds_descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    prd_vl_valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    prd_id_categoria = table.Column<int>(type: "int", nullable: false),
                    Categoriaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRD_Produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_PRD_Produto_CAT_Categoria_Categoriaid",
                        column: x => x.Categoriaid,
                        principalTable: "CAT_Categoria",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "CAT_Categoria",
                columns: new[] { "id", "cat_ds_descricao", "cat_nm_nome" },
                values: new object[,]
                {
                    { 1, "limpeza", "Produtos de Limpeza" },
                    { 2, "Carnes frescas e processadas", "Carnes" },
                    { 3, "Leite, queijo, manteiga, etc.", "Laticínios" },
                    { 4, "Frutas e vegetais frescos", "Frutas e Vegetais" },
                    { 5, "Pães, bolos, doces, etc.", "Padaria" },
                    { 6, "Refrigerantes, sucos, água, etc.", "Bebidas" },
                    { 7, "Arroz, feijão, cereais matinais, etc.", "Cereais e Grãos" },
                    { 8, "Alimentos enlatados e conservas", "Enlatados" },
                    { 9, "Sabonetes, shampoos, produtos de cuidados pessoais, etc.", "Produtos de Higiene Pessoal" },
                    { 10, "Fraldas, produtos de higiene para bebês, etc.", "Cuidados com o Bebê" },
                    { 11, "Salgadinhos, biscoitos, petiscos, etc.", "Snacks e Petiscos" },
                    { 12, "Itens diversos de mercearia", "Mercearia" },
                    { 13, "Alimentos congelados, como pizzas, vegetais, etc.", "Congelados" },
                    { 14, "Chocolate, sobremesas prontas, etc.", "Doces e Sobremesas" },
                    { 15, "Produtos específicos para limpeza doméstica", "Produtos de Limpeza Doméstica" },
                    { 16, "Sal, pimenta, molhos, etc.", "Condimentos e Temperos" },
                    { 17, "Café, chá, achocolatados, etc.", "Café, Chá e Bebidas Quentes" },
                    { 18, "Decorações, balões, etc.", "Artigos de Festa" },
                    { 19, "Papel higiênico, guardanapos, etc.", "Produtos de Papelaria" },
                    { 20, "Utensílios de cozinha, panelas, etc.", "Artigos de Cozinha" }
                });

            migrationBuilder.InsertData(
                table: "PRD_Produto",
                columns: new[] { "id", "Categoriaid", "prd_ds_descricao", "prd_id_categoria", "prd_nm_nome", "prd_vl_valor" },
                values: new object[,]
                {
                    { 1, null, "Sabão em pó para lavar roupas", 1, "Sabão em Pó", 9.99m },
                    { 2, null, "Carne bovina moída fresca", 2, "Carne Moída", 15.99m },
                    { 3, null, "Leite integral pasteurizado", 3, "Leite Integral", 3.49m },
                    { 4, null, "Maçãs frescas selecionadas", 4, "Maçã", 2.49m },
                    { 5, null, "Pão francês fresco e crocante", 5, "Pão Francês", 1.29m },
                    { 6, null, "Refrigerante sabor cola", 6, "Refrigerante Coca-Cola", 5.99m },
                    { 7, null, "Arroz integral de qualidade", 7, "Arroz Integral", 4.79m },
                    { 8, null, "Atum enlatado em óleo", 8, "Atum Enlatado", 2.99m },
                    { 9, null, "Shampoo para cabelos normais a secos", 9, "Shampoo Dove", 8.49m },
                    { 10, null, "Fralda descartável para bebês", 10, "Fralda Pampers", 39.99m },
                    { 11, null, "Salgadinho de milho sabor queijo", 11, "Salgadinho Doritos", 6.49m },
                    { 12, null, "Azeite de oliva extravirgem", 12, "Azeite de Oliva", 12.99m },
                    { 13, null, "Pizza de mussarela congelada", 13, "Pizza Congelada", 8.99m },
                    { 14, null, "Chocolate ao leite cremoso", 14, "Chocolate Ao Leite", 3.29m },
                    { 15, null, "Desinfetante para limpeza de superfícies", 15, "Desinfetante Pinho Sol", 7.99m },
                    { 16, null, "Molho de pimenta picante", 16, "Molho de Pimenta Tabasco", 10.99m },
                    { 17, null, "Café solúvel instantâneo", 17, "Café Solúvel Nescafé", 11.49m },
                    { 18, null, "Balão decorativo para festas", 18, "Balão de Aniversário", 3.99m },
                    { 19, null, "Papel higiênico macio e resistente", 19, "Papel Higiênico Neve", 6.79m },
                    { 20, null, "Panela de pressão em alumínio", 20, "Panela de Pressão Tramontina", 89.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRD_Produto_Categoriaid",
                table: "PRD_Produto",
                column: "Categoriaid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRD_Produto");

            migrationBuilder.DropTable(
                name: "CAT_Categoria");
        }
    }
}
