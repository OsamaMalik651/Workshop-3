using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{/// <summary>
/// Repository of methods that retrieves data and change Products Table
/// </summary>
    public static class ProductManager
    {
        /// <summary>
        /// Method to retrieve all the packages from the Travel Experts Database.
        /// </summary>
        /// <returns>List of objects that corresponds to a list of states</returns>
        public static List<ProductsDTO> GetProducts()
        {
            List<ProductsDTO> packages = null;
            using (TravelExperContext db = new TravelExperContext())
            {
                packages = db.Products.Select(p => new ProductsDTO
                {
                    ProductId = p.ProductId,
                    ProdName =p.ProdName
                }).ToList();
            }
            return packages;
        }
        /// <summary>
        /// Method to Retrieve a single product from the database
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public static Product GetProduct(int productID)
        {
            Product selectedPropduct = null;

            using (TravelExperContext db = new TravelExperContext())
            {
                selectedPropduct = db.Products.Find(productID);
            }
            return selectedPropduct;
        }
    }
}
