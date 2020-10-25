using Domain.Entity;
using Domain.Interfaces;
using Infra.Configuration;
using MongoDB.Driver;
using System.IO.Compression;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class ConnectRepository : IConnectRepository
    {
        private readonly IMongoCollection<Products> _dataset;

        public ConnectRepository(ProductsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _dataset = database.GetCollection<Products>("Products");
        }
        public async Task ConnectProducts()
        {
            string zipPath1 = @"C:\Users\HP\Desktop\Project ONeGreen\OneGreen\Arquivo\Dado1.rar";
            string zipPath2 = @"C:\Users\HP\Desktop\Project ONeGreen\OneGreen\Arquivo\Dado2.rar";
            string zipDestiny = @"C:\Users\HP\Desktop\Project ONeGreen\OneGreen\Arquivo";

            ZipFile.ExtractToDirectory(zipPath1, zipDestiny);
            ZipFile.ExtractToDirectory(zipPath2, zipDestiny);
        }
    }
}
