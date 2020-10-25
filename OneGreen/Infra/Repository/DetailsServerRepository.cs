using Domain.Entity;
using Domain.Interfaces;
using Infra.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class DetailsServerRepository : IDetailsServerRepository
    {
        private readonly IMongoCollection<DetailsServer> _dataset;
        public DetailsServerRepository(ProductsDatabaseSettings settings)
        {
            
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _dataset = database.GetCollection<DetailsServer>("DetailsServer");
        }
        public async Task<IList<DetailsServer>> DetailsGet()
        {
            try
            {
                return _dataset.Find(p => true).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DetailsServer> DetailsInsert(DetailsServer situacao)
        {
            try
            {
                await _dataset.InsertOneAsync(situacao);

                return situacao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
