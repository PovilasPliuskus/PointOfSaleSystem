using PointOfSaleSystem.API.Context;
using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Models.Enums;
using PointOfSaleSystem.API.Repositories.Interfaces;

namespace PointOfSaleSystem.API.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly PointOfSaleSystemContext _context;

        public ReservationRepository(PointOfSaleSystemContext context)
        {
            _context = context;
        }

        public void Create(ReservationEntity reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }

        public ReservationEntity Get(Guid id)
        {
            return _context.Reservations.FirstOrDefault(r => r.Id == id)
                ?? throw new Exception($"Reservation with Id {id} not found.");
        }

        public List<ReservationEntity> GetAll()
        {
            return _context.Reservations.ToList();
        }

        public void Update(ReservationEntity reservation)
        {
            var existing = Get(reservation.Id);
            existing.ReservationDate = reservation.ReservationDate;
            existing.Status = reservation.Status;
            _context.SaveChanges();
        }
        public bool IsTimeTaken (Guid serviceId, DateTime reservationDate)
        {
            return _context.Reservations.Any(r => 
            r.ServiceId == serviceId &&
            r.ReservationDate == reservationDate &&
            r.Status != ReservationStateEnum.Cancelled);
        }
    }
}
