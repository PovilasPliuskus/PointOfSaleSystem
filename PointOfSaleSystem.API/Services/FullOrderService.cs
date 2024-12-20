﻿using AutoMapper;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Enums;
using PointOfSaleSystem.API.Repositories;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.FullOrder;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.ResponseBodies.FullOrder;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Services
{
    public class FullOrderService : IFullOrderService
    {
        private readonly IFullOrderRepository _fullOrderRepository;
        private readonly IEstablishmentProductRepository _establishmentProductRepository;
        private readonly IEstablishmentServiceRepository _establishmentServiceRepository;
        private readonly IMapper _mapper;

        public FullOrderService(IFullOrderRepository fullOrderRepository,
            IEstablishmentProductRepository establishmentProductRepository,
            IEstablishmentServiceRepository establishmentServiceRepository,
            IMapper mapper)
        {
            _fullOrderRepository = fullOrderRepository;
            _establishmentProductRepository = establishmentProductRepository;
            _establishmentServiceRepository = establishmentServiceRepository;
            _mapper = mapper;
        }

        public void CreateFullOrder(FullOrder fullOrder, UserInfo userInfo)
        {
            _fullOrderRepository.Create(fullOrder);
        }

        public GetFullOrderResponse GetFullOrder(Guid id, UserInfo userInfo)
        {
            FullOrder fullOrder = _fullOrderRepository.Get(id);

            CurrencyEnum fullOrderCurrency = GetFullOrderCurrency(fullOrder);

            decimal totalPrice = GetFullOrderTotalPrice(fullOrder);

            GetFullOrderResponse response = _mapper.Map<GetFullOrderResponse>(fullOrder);

            response.Currency = fullOrderCurrency;
            response.TotalPrice = totalPrice;

            return response;
        }

        public List<GetFullOrderResponse> GetAllFullOrders(UserInfo userInfo)
        {
            List<FullOrder> fullOrders = [];

            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                fullOrders = _fullOrderRepository.GetAll();
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                fullOrders = _fullOrderRepository.GetAllByEmployeeId(Guid.Parse(userInfo.Id));
            }
            else
            {
                fullOrders = _fullOrderRepository.GetFullOrderByEmployeeId(Guid.Parse(userInfo.Id));
            }

            List<GetFullOrderResponse> fullResponse = [];

            foreach (FullOrder fullOrder in fullOrders)
            {
                CurrencyEnum fullOrderCurrency = GetFullOrderCurrency(fullOrder);

                decimal totalPrice = GetFullOrderTotalPrice(fullOrder);

                GetFullOrderResponse response = _mapper.Map<GetFullOrderResponse>(fullOrder);

                response.Currency = fullOrderCurrency;
                response.TotalPrice = totalPrice;

                fullResponse.Add(response);
            }

            return fullResponse;
        }

        public void UpdateFullOrder(UpdateFullOrderRequest request, UserInfo userInfo)
        {
            _fullOrderRepository.Update(request);
        }

        public void DeleteFullOrder(Guid id, UserInfo userInfo)
        {
            _fullOrderRepository.Delete(id);
        }

        public void RefundFullOrder(Guid id, UserInfo userinfo)
        {
            _fullOrderRepository.RefundFullOrder(id);
        }

        private CurrencyEnum GetFullOrderCurrency(FullOrder fullOrder)
        {
            Order? order = fullOrder.Orders.FirstOrDefault();
            
            if (order is null ||
                (order.EstablishmentProductId is null && order.EstablishmentServiceId is null))
            {
                return CurrencyEnum.None;
            }

            List<EstablishmentProduct> establishmentProducts = _establishmentProductRepository.GetAll();

            foreach (var product in establishmentProducts)
            {
                if (product.Id == order.EstablishmentProductId)
                {
                    return product.Currency;
                }
            }

            List<Models.EstablishmentService> establishmentServices = _establishmentServiceRepository.GetAll();

            foreach(var service in establishmentServices)
            {
                if (service.Id == order.EstablishmentServiceId)
                {
                    return service.Currency;
                }
            }

            return CurrencyEnum.None;
        }

        private decimal GetFullOrderTotalPrice(FullOrder fullOrder)
        {
            decimal totalPrice = 0;

            foreach (Order order in fullOrder.Orders)
            {
                if (order.EstablishmentProductId is not null)
                {
                    EstablishmentProduct establishmentProduct = _establishmentProductRepository.Get((Guid)order.EstablishmentProductId);
                    totalPrice += establishmentProduct.Price * order.Count;
                }

                if (order.EstablishmentServiceId is not null)
                {
                    Models.EstablishmentService establishmentService = _establishmentServiceRepository.Get((Guid)order.EstablishmentServiceId);
                    totalPrice += establishmentService.Price * order.Count;
                }
            }

            return totalPrice;
        }
    }
}
