using Juguetes.BL.Data;
using Juguetes.BL.Models;

namespace Juguetes.BL.Repositories.Implements
{
    public class ProductoRepository : GenericRepository<Productos>, IProductoRepository
    {
        public ProductoRepository( JuguetesContext juguetesContext) : base(juguetesContext)
        {

        }
    }
}
