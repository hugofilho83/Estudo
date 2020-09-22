using Application.Interfaces.Generic;
using Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductApp : IGenericApp<Product>
    {
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
    }
}
