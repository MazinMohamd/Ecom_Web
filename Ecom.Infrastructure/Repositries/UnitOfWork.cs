using Ecom.Core.Interfaces;
using Ecom.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Repositries
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ICategoryRepository categoryRepository { get; }

        public IPhotoRepository photoRepository { get; }

        public IProductRepository productRepository { get; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            categoryRepository= new CategoryRepository(context);
            photoRepository = new PhotoRepository(context);
            productRepository= new ProductRepository(context);


        }
    }
}
