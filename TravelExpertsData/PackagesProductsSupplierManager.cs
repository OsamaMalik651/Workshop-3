using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{   //Author: Sola Oyatunji and Osama Malik
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
        public static PackagesProductsSupplier GetPackagesProductsSupplier( int pckProdSupplierPackageID, int pckgProdSupplierID)
        {
            PackagesProductsSupplier packagesProductsSupplier = null;
            using (TravelExperContext db = new TravelExperContext())
            {
                packagesProductsSupplier = db.PackagesProductsSuppliers.Find( pckProdSupplierPackageID, pckgProdSupplierID);
            }
            return packagesProductsSupplier;
        }

        //Osama Malik
        /// <summary> 
        /// Method to Add Package Product suppliers to the database.
        /// </summary>
        /// <param name="PackageProductSuppliersList"> list of Package Product Suppliers to Add.</param>
        public static void Add(List<PackagesProductsSupplier> PackageProductSuppliersList)
        {
            using(TravelExperContext db = new TravelExperContext())
            {
                db.PackagesProductsSuppliers.AddRange(PackageProductSuppliersList);
                db.SaveChanges();            
            }
            
        }

       /// <summary>
       /// Deletes an entry in Package Product supplier table
       /// </summary>
       /// <param name="selectedPackagesProductsSupplier">PackageProductSupplier to delete</param>
        public static void RemoveSupplier(PackagesProductsSupplier selectedPackagesProductsSupplier) //This function will be removed afterwards
        {
            using (TravelExperContext db = new TravelExperContext())
            {
                db.PackagesProductsSuppliers.Remove(selectedPackagesProductsSupplier);
                db.SaveChanges();
            }
        }
        //OsamaMalik
        /// <summary>
        /// Method to Remove multiple Entries from Package Product supplier table
        /// </summary> 
        /// <param name="packageID"> Package Id to remove all product suppliers attached to it.</param>
        public static void RemoveAllEntries(int packageID)
        {
            TravelExperContext db = new TravelExperContext();
            List<PackagesProductsSupplier> pkgprdsupToDelete = db.PackagesProductsSuppliers.Where(p => p.PackageId == packageID).ToList();
            db.PackagesProductsSuppliers.RemoveRange(pkgprdsupToDelete);
            db.SaveChanges();

        }
    }
}
