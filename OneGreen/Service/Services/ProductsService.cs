using Domain.Entity;
using Domain.Interfaces;
using Domain.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _repository;

        public ProductsService(IProductsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Products> Create(Products products)
        {
            return await _repository.Create(products);
        }

        public async Task<bool> Delete(int code)
        {
            return await _repository.Delete(code);
        }

        public async Task<IList<Products>> FindAllGet()
        {
            return await _repository.FindAllGet();
        }

        public async Task<Products> GetId(int code)
        {
            return await _repository.GetId(code);
        }

        public async Task<Products> Update(Products products, string id)
        {
            return await _repository.Update(products, id);
        }
    }
}
