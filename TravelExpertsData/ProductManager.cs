using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Made by Osama Malik
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
        
        
        /// <summary>
        /// Method to add new product in the database.
        /// </summary>
        /// <param name="newProduct">Product to be added.</param>
        public static void AddProduct(Product newProduct)
        {
            using (TravelExperContext db = new TravelExperContext())
            {
                db.Products.Add(newProduct);
                db.SaveChanges();
            }
        }
       
        
        /// <summary>
        /// Method to modify a product in the database.
        /// </summary>
        /// <param name="newProduct">Product with new details.</param>
        public static void ModifyProduct(Product newProduct)
        {
            Product oldProduct;
            using (TravelExperContext db = new TravelExperContext())
            {
                oldProduct = db.Products.Find(newProduct.ProductId);
                CopyProdcutData(oldProduct, newProduct);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// function to copy new details to the existing product.
        /// </summary>
        /// <param name="oldProduct">Product with existing details.</param>
        /// <param name="newProduct">Product with updated details.</param>
        private static void CopyProdcutData(Product oldProduct,Product newProduct)
        {
            if (oldProduct != null && newProduct != null)
            {
                /*oldProduct.ProductId = newProduct.ProductId;*/
                oldProduct.ProdName = newProduct.ProdName;
            }
        }

        /// <summary>
        /// Method to remove the product from the database.
        /// </summary>
        /// <param name="selectedProduct">Product to be deleted.</param>
        public static void RemoveProduct(Product selectedProduct)
        {
            using(TravelExperContext db = new TravelExperContext())
            {
                db.Products.Remove(selectedProduct);
                db.SaveChanges();
            }
        }
    }
}
