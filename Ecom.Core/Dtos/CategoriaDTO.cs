using System.ComponentModel.DataAnnotations;

namespace Ecom.Core.Dtos
{
    public class CategoriaDTO
    {
        [Required]
        public string cat_nm_nome { get; set; }
        public string cat_ds_descricao { get; set; }
    }

    public class ListingCategoriaDTO : CategoriaDTO
    {
        public int id { get; set; }
    }

    public class UpdateCategoriaDTO : CategoriaDTO
    {
        public int id { get; set; }
    }
}
