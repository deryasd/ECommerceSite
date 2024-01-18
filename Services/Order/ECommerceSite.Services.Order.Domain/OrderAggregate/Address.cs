
using ECommerceSite.Services.Order.Domain.Core;

namespace ECommerceSite.Services.Order.Domain.OrderAggregate
{
    public class Address : ValueObject
    {
        public string Country { get; private set; }
        public string City { get; private set; }
        public string? Township { get; private set; }
        public string? Neighbourhood { get;  private set; }
        public string? Street { get; private set; }
        public string? Gait { get; private set; }
        public string? Block { get;private set; }
        public int Number { get;private set; }
        public int? ZipCode { get; private set; }

        public Address(string country, string city, string? township, string? neighbourhood, string? street, string? gait, string? block, int number, int? zipCode)
        {
            Country = country;
            City = city;
            Township = township;
            Neighbourhood = neighbourhood;
            Street = street;
            Gait = gait;
            Block = block;
            Number = number;
            ZipCode = zipCode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Country;
            yield return City;
            yield return Township;
            yield return Neighbourhood;
            yield return Street;
            yield return Gait;
            yield return Block;
            yield return Number;
            yield return ZipCode;
        }
    }
}