using Application.Interfaces;
using Domain.Interfaces.InterfaceProduct;
using Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.OpenApp
{
    public class AppProduct : IProductApp
    {
        private IProduct product;

        public AppProduct(IProduct product)
        {
            this.product = product;
        }

        public async Task Add(Product objeto)
        {
            await this.product.Add(objeto);
        }

        public async Task Delete(Product objeto)
        {
            await this.product.Delete(objeto);
        }

        public async Task<Product> GetEntityById(int Id)
        {
            return await this.product.GetEntityById(Id);
        }

        public async Task<List<Product>> List()
        {
            return await this.product.List();
        }

        public async Task Update(Product objeto)
        {
            await this.product.Update(objeto);
        }
    }
}
