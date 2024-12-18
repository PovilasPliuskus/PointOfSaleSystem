using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.FullOrder;
using PointOfSaleSystem.API.RequestBodies.Tax;
using PointOfSaleSystem.API.ResponseBodies.FullOrder;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface ITaxService
    {
        public void CreateTax(AddTaxRequest fullOrder);
        public Tax GetTax(Guid id);
        public List<Tax> GetAllTaxes();
        public void UpdateTax(UpdateTaxRequest request);
        public void DeleteTax(Guid id);
    }
}
