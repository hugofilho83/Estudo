using Application.Interfaces;
using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.OpenApp
{
    public class AppProduct : IProductApp
    {
        private IProduct _product;
        private IServiceProduct _serviceProduct;

        public AppProduct(IProduct product, IServiceProduct serviceProduct)
        {
            _product = product;
            _serviceProduct = serviceProduct;
        }

        public async Task Add(Product objeto)
        {
            await _product.Add(objeto);
        }

        public async Task Delete(Product objeto)
        {
            await _product.Delete(objeto);
        }

        public async Task<Product> GetEntityById(int Id)
        {
            return await _product.GetEntityById(Id);
        }

        public async Task<List<Product>> List()
        {
            return await _product.List();
        }

        public async Task Update(Product objeto)
        {
            await _product.Update(objeto);
        }
    }
}
