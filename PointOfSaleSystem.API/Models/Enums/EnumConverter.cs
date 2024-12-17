namespace PointOfSaleSystem.API.Models.Enums
{
    public static class EnumConverter
    {
        public static OrderStatusEnum ToOrderStatusEnum(this FullOrderStatusEnum fullOrderStatus)
        {
            return fullOrderStatus switch
            {
                FullOrderStatusEnum.None => OrderStatusEnum.None,
                FullOrderStatusEnum.Open => OrderStatusEnum.Open,
                FullOrderStatusEnum.Closed => OrderStatusEnum.Closed,
                FullOrderStatusEnum.Cancelled => OrderStatusEnum.Cancelled,
                FullOrderStatusEnum.Refunded => OrderStatusEnum.Refunded,
                _ => throw new ArgumentOutOfRangeException(nameof(fullOrderStatus), fullOrderStatus, null)
            };
        }
    }
}