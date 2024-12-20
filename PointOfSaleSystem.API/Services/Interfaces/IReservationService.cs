using PointOfSaleSystem.API.Models;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface IReservationService
    {
        void CreateReservation(Reservation reservation);
        Reservation GetReservation(Guid id);
        List<Reservation> GetAllReservations();
        void UpdateReservation(Reservation reservation);
    }
}
