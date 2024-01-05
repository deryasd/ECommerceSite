namespace ECommerceSite.Services.Catalog.API.Dtos
{
    public class AddressCreateDtos
    {
        public string Country { get;  set; }
        public string City { get;  set; }
        public string? Township { get;  set; }
        public string? Neighbourhood { get;  set; }
        public string? Street { get;  set; }
        public string? Gait { get;  set; }
        public string? Block { get;  set; }
        public int Number { get;  set; }
        public int? ZipCode { get;  set; }
    }
}
