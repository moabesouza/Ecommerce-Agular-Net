using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Entities
{
    public class CAT_Categoria : BaseEntity<int>
    {
        public string cat_nm_nome {get; set;}
        public string cat_ds_descricao { get; set; }

        public virtual ICollection <PRD_Produto> Produto { get; set; }

    }
}
