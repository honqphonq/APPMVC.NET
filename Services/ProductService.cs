using APPMVC.NET.Models;
using System.Collections.Generic;

namespace APPMVC.NET.Services
{
    public class ProductService : List<Product>
    {
        public ProductService()
        {
            this.AddRange(new Product[]
            {
                new Product { Id = 1, Name = "Iphone X",Price=1000},
                new Product { Id = 2, Name = "Samsung Xr",Price=1300},
                new Product { Id = 3, Name = "Sony Xs",Price=1400},
                new Product { Id = 3, Name = "Huawei Xsmax",Price=1500}
            });
        }
    }
}
