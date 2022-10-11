using Juguetes.BL.Models;
using Juguetes.BL.Repositories;

namespace Juguetes.BL.Services.Implements
{
    public class ProductoService : GenericService<Productos>, IProductoService
    {
        public ProductoService(IProductoRepository productoRepository) : base(productoRepository)
        {

        }
    }
}
