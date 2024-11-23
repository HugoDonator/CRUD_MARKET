using CRUDMARKET.INFRASTRUCTURE.Context;
using CRUDMARKET.DOMAIN.Entities;
using CRUDMARKET.INFRASTRUCTURE.Core;

namespace CRUDMARKET.INFRASTRUCTURE.Repositories
{
    public class AlmacenRepository : BaseRepository<Almacen>
    {
        public AlmacenRepository(AppDbContext context) : base(context) { }
    }
}

