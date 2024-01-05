namespace ECommerceSite.Services.Catalog.Dtos
{
    public class StorageDtos
    {
        public int StorageId { get;  set; }
        public string Name { get;  set; }
        public string PhoneNumber { get;  set; }
        public int AdressId { get;  set; }
        public AddressDtos Address { get;  set; }
    }
}
