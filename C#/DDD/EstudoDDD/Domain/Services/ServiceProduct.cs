using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceProduct: IServiceProduct
    {

        private readonly IProduct _product;

        public ServiceProduct(IProduct product)
        {
            _product = product;
        }

        public async Task AddProduct(Product product)
        {
            var validarNome = product.ValidationPropertyString(product.Nome, "Nomes");
            var validarPreco = product.ValidationPropertyDecimal(product.Preco, "Preço");


            if(validarNome && validarPreco)
            {
                product.Ativo = true;

                await _product.Add(product);
            }
        }

        public async Task UpdateProduct(Product product)
        {
            var validarNome = product.ValidationPropertyString(product.Nome, "Nomes");
            var validarPreco = product.ValidationPropertyDecimal(product.Preco, "Preço");


            if (validarNome && validarPreco)
            {
                product.Ativo = true;

                await _product.Update(product);
            }
        }
    }
}
