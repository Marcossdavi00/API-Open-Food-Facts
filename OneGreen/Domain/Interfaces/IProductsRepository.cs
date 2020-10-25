using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductsRepository
    {
        Task<Products> Update(Products products, string id);
        Task<bool> Delete(int code);
        Task<Products> GetId(int code);
        Task<IList<Products>> FindAllGet();
        Task<Products> Create(Products products);
    }
}
