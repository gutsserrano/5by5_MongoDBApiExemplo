using MongoDB.Driver;
using MongoDBApiExemplo.Models;
using MongoDBApiExemplo.Utils;

namespace MongoDBApiExemplo.Services
{
    public class AddressService
    {
        private readonly IMongoCollection<Address> _address;
        public AddressService(IMongoDBApiDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _address = database.GetCollection<Address>(settings.AddressCollectionName);
        }

        public List<Address> Get() => _address.Find(address => true).ToList();

        public Address Get(string id) => _address.Find<Address>(address => address.Id == id).FirstOrDefault();

        public Address Create(Address address)
        {
            _address.InsertOne(address);
            return address;
        }
    }
}
