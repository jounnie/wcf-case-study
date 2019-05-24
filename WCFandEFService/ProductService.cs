using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFandEFService
{
    public class ProductService : IProductService
    {
        public Product GetProduct(int id)
        {
           

            NorthwindEntities context = new NorthwindEntities();
            var productEntity = (from p
                                in context.ProductEntities
                                where p.ProductID == id
                                select p).FirstOrDefault();

            if (productEntity != null)
                return TranslateProductEntityToProduct(productEntity);
            else
                throw new Exception("Invalid product id");
        }

        private Product TranslateProductEntityToProduct(
            ProductEntity productEntity)
        {
            Product product = new Product();

            product.ProductID = productEntity.ProductID;
            product.ProductName = productEntity.ProductName;
            product.QuantityPerUnit = productEntity.QuantityPerUnit;
            product.UnitPrice = (decimal)productEntity.UnitPrice;
            product.Discontinued = productEntity.Discontinued;

            return product;
        }

    }
}
