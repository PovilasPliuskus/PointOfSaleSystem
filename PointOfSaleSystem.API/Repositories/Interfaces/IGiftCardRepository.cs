using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.FullOrder;
using PointOfSaleSystem.API.RequestBodies.Order;
using PointOfSaleSystem.API.RequestBodies.Tax;

namespace PointOfSaleSystem.API.Repositories.Interfaces
{
    public interface ITaxRepository
    {
        public void Create(Tax tax);
        public Tax Get(Guid id);
        public List<Tax> GetAll();
        public void Update(UpdateTaxRequest request);
        public void Delete(Guid id);
    }
}
