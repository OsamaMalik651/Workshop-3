using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    /// <summary>
    /// Tracy Crape - repository of methods that retrieve data and change Supplier table
    /// </summary>
    public static class ProductsSupplierManager
    {
        /// <summary>
        /// Tracy Crape - Retrieves data of ProductsSupplier based on id
        /// </summary>
        /// <param name="id">productsupplierid</param>
        /// <returns>ProductsSupplier object or null if not found</returns>
        public static List<ProductsSupplierDTO> GetProductsSuppliers()
        {
            List<ProductsSupplierDTO> productssuppliers;
            using (TravelExperContext db = new TravelExperContext())
            {
                productssuppliers = db.ProductsSuppliers.Select(e => new ProductsSupplierDTO
                { 
                    ProductSupplierId= e.ProductSupplierId,
                    ProductId= e.ProductId,
                    SupplierId= e.SupplierId,
                }).ToList();
                return productssuppliers;
            }
        }

        public static List<ProductsSupplierDTO> GetProductsSupplier()
        {
            throw new NotImplementedException();
        }

        public static ProductsSupplier GetProductSupplier(int productsSupplierID)
        {
            throw new NotImplementedException();
        }

        public static void AddProductsSupplier(ProductsSupplier productssupplierToAdd)
        {
            throw new NotImplementedException();
        }

        public static void ModifyProductsSupplier(ProductsSupplier productssupplierToAdd)
        {
            throw new NotImplementedException();
        }

        public static void RemoveProductsSupplier(ProductsSupplier selectedProductsSupplier)
        {
            throw new NotImplementedException();
        }
    }
}
