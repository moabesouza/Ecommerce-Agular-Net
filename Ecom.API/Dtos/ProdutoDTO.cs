using System.ComponentModel.DataAnnotations;

namespace Ecom.API.Dtos
{
    public class BaseProdutoDTO
    {
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        public string prd_nm_nome { get; set; }

        [StringLength(500, ErrorMessage = "A descrição do produto deve ter no máximo {1} caracteres.")]
        public string prd_ds_descricao { get; set; }

        [Required(ErrorMessage = "O preço do produto é obrigatório.")]
        [Range(1, 9999, ErrorMessage = "O preço do produto deve estar entre {1} e {2}.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "O preço do produto deve ser um número válido.")]//@"[0-9]*\.?[0-9]+
        public decimal prd_vl_valor { get; set; }
    }

    public class ProdutoDTO : BaseProdutoDTO
    {
        public int id { get; set; }
        public string prd_nm_categoria { get; set; } // nome categoria
    }

    public class CadastrarProdutoDTO : BaseProdutoDTO
    {       
        public int prd_id_categoria { get; set; } // id categoria

        public IFormFile prd_nm_imagem { get; set; }
    }
}
