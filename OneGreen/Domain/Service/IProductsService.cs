using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Service
{
    public interface IProductsService
    {
        Task<Products> Update(Products products, string id);
        Task<bool> Delete(int code);
        Task<Products> GetId(int code);
        Task<IList<Products>> FindAllGet();
        Task<Products> Create(Products products);
    }
}
