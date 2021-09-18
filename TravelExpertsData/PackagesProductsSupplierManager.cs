using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    /// <summary>
    /// Sola Oyatunji(repository of methods that retrieves data and change product product supplier table)
    /// </summary>
    public static class PackagesProductsSupplierManager
    {
        /// <summary>
        /// Sola Oyatunji - Retrieves data of PackagesProductsSupplier based on id
        /// </summary>
        /// <param name="id">packagesproductsupplierid</param>
        /// <returns>PackagesProductsSupplier object or null if not found</returns>
        public static List<PackagesProductsSupplierDTO> GetPackagesProductsSupplier()
        {
            List<PackagesProductsSupplierDTO> packagesproductssuppliers;
            using (TravelExperContext db = new TravelExperContext())
            {
                packagesproductssuppliers = db.PackagesProductsSuppliers.Select(e => new PackagesProductsSupplierDTO
                {
                    ProductSupplierId = e.ProductSupplierId,
                    PackageId = e.PackageId,
                }).ToList();
                return packagesproductssuppliers;
            }
        }


    }
}
