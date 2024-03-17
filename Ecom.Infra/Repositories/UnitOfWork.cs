using Ecom.Core.Interfaces;
using Ecom.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public ICategoriaRepository CategoriaRepository { get; }
        public IProdutoRepository ProdutoRepository { get; }
    

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            CategoriaRepository = new CategoriaRepository(context);
            ProdutoRepository = new ProdutoRepository(context);
        }
    }
}
