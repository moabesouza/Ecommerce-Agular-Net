using System.ComponentModel.DataAnnotations;

namespace Ecom.API.Dtos
{
    public class CategoriaDTO
    {
        [Required]
        public string cat_nm_nome { get; set; }
        public string cat_ds_descricao { get; set; }
    }

    public class ListingCategoryDTO : CategoriaDTO
    {
        public int cat_id_categoria { get; set; }
    }
}
