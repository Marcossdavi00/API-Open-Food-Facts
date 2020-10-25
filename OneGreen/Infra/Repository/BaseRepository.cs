using AutoMapper.Configuration;
using Domain.Entity;
using Domain.Interfaces;
using Infra.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class BaseRepository : IProductsRepository
    {

        private readonly IMongoCollection<Products> _dataset;

        public BaseRepository(ProductsDatabaseSettings settings)
        {

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _dataset = database.GetCollection<Products>("Products");
        }

        public async Task<Products> Create(Products products)
        {
            try
            {
                await _dataset.InsertOneAsync(products);

                return products;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Delete(int code)
        {
            try
            {
                var result = await _dataset.DeleteOneAsync<Products>(p => p.code == code);
                if (result == null)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<IList<Products>> FindAllGet()
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

        public async Task<Products> GetId(int code)
        {
            try
            {
                var result =  await _dataset.Find<Products>(p => p.code == code).FirstOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Products> Update(Products product, string id)
        {
            try
            {
                var result = await _dataset.ReplaceOneAsync(p => p.id == id, product);
                return product;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
