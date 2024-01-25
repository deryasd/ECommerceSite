namespace ECommerceSite.Services.Basket.Dtos
{
    public class BasketDto
    {
        public string UserId { get; set; }
        public double Discount { get; set; }
        public List<BasketItemDto> basketItems { get; set; }

        public double TotalPrice
        {
            get => basketItems .Sum(x =>( x.Price * Discount) * x.Quantity);
        }

    }
}
