using AutoMapper;
using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Models.Enums;
using PointOfSaleSystem.API.Repositories.Interfaces;

namespace PointOfSaleSystem.API.Services
{
    public class ReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public void CreateReservation(ReservationEntity reservation)
        {
            var entity = _mapper.Map<ReservationEntity>(reservation);
            bool isTaken = _reservationRepository.IsTimeTaken(reservation.ServiceId, reservation.ReservationDate);
            if (isTaken)
            {
                throw new Exception("The selected time is already taken for this service.");
            }
            _reservationRepository.Create(entity);
        }

        public ReservationEntity GetReservation(Guid id)
        {
            var entity = _reservationRepository.Get(id);
            return _mapper.Map<ReservationEntity>(entity);
        }

        public List<ReservationEntity> GetAllReservations()
        {
            var entities = _reservationRepository.GetAll();
            return _mapper.Map<List<ReservationEntity>>(entities);
        }

        public void UpdateReservation(ReservationEntity reservation)
        {
            var entity = _mapper.Map<ReservationEntity>(reservation);
            if (reservation == null)
            {
                throw new Exception($"Reservation with ID {reservation.Id} not found.");
            }

            if (reservation.Status == ReservationStateEnum.Completed)
            {
                throw new Exception("Cannot update a completed reservation.");
            }
            _reservationRepository.Update(entity);
        }
    }
}
