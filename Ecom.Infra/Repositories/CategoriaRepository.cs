using Ecom.Core.Entities;
using Ecom.Core.Interfaces;
using Ecom.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infra.Repositories
{
    public class CategoriaRepository : GenericRepository<CAT_Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
