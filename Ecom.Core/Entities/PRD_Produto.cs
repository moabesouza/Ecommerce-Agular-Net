using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecom.Core.Entities
{
    public class PRD_Produto:BaseEntity<int>
    {
        public string prd_nm_nome { get; set; }
        public string prd_ds_descricao { get; set; }
        public string prd_nm_imagem { get; set; }
        public decimal prd_vl_valor { get; set; }
        public int prd_id_categoria { get; set; }

     
        public virtual CAT_Categoria Categoria { get; set; }
    }
}
