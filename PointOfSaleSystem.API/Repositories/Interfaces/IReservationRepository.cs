using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Models.Enums;
using PointOfSaleSystem.API.Services;

namespace PointOfSaleSystem.API.Repositories.Interfaces
{
    public interface IReservationRepository
    {
        void Create(ReservationEntity reservation);
        ReservationEntity Get(Guid id);
        List<ReservationEntity> GetAll();
        void Update(ReservationEntity reservation);
        bool IsTimeTaken (Guid serviceId, DateTime reservationDate);
    }
}
