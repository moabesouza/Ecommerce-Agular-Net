using AutoMapper;
using Ecom.Core.Interfaces;
using Ecom.Infra.Data;
using Microsoft.Extensions.FileProviders;
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
        private readonly IUnitOfWork _uOW;
        private readonly IFileProvider _fileProvider;
        private readonly IMapper _mapper;

        public ICategoriaRepository CategoriaRepository { get; }
        public IProdutoRepository ProdutoRepository { get; }
    

        public UnitOfWork(AppDbContext context, IFileProvider fileProvider, IMapper mapper)
        {
            _context = context;
          
            _fileProvider = fileProvider;
            _mapper = mapper;

            CategoriaRepository = new CategoriaRepository(_context);
            ProdutoRepository = new ProdutoRepository(_context, _fileProvider, _mapper);
        }
    }
}
