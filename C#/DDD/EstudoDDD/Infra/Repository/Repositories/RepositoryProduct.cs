using Domain.Interfaces.InterfaceProduct;
using Entitites.Entities;
using Infrastructure.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryProduct : RepositoryGenerics<Product>, IProduct
    {

    }
}
