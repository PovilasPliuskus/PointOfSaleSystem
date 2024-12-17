using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.FullOrder;
using PointOfSaleSystem.API.RequestBodies.Tax;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Services
{
    public class TaxService : ITaxService
    {
        private readonly ITaxRepository _taxRepository;

        public TaxService(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }

        public void CreateTax(Tax request)
        {
            _taxRepository.Create(request);
        }

        public Tax GetTax(Guid id)
        {
            return _taxRepository.Get(id);
        }

        public List<Tax> GetAllTaxes()
        {
            return _taxRepository.GetAll();
        }

        public void UpdateTax(UpdateTaxRequest request)
        {
            _taxRepository.Update(request);
        }

        public void DeleteTax(Guid id)
        {
            _taxRepository.Delete(id);
        }
    }
}