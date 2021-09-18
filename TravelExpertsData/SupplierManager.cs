using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    /// <summary>
    /// repositroy of methods that retrieve data and change Supplier table
    /// </summary>
    public static class SupplierManager
    {
        /// <summary>
        /// Retrieves data of supplier based on id
        /// </summary>
        /// <param name="id">supplier id</param>
        /// <returns>Supplier object or null if not found</returns>
        public static List<SupplierDTO> GetSuppliers()
        {
            List<SupplierDTO> suppliers;
            using (TravelExperContext db = new TravelExperContext())
            {
                suppliers = db.Suppliers.Select(s => new SupplierDTO
                {
                    SupplierId = s.SupplierId,
                    SupName = s.SupName,

                }).ToList();
                return suppliers;
            }

        }
        public static Supplier GetSupplier(int supplierId)
        {
            Supplier selectedSupplier = null;
            using (TravelExperContext db = new TravelExperContext())
            {
                selectedSupplier = db.Suppliers.Find(supplierId);
            }
            return selectedSupplier;
        }

        public static void AddSupplier(Supplier supplierToAdd)
        {

            using (TravelExperContext db = new TravelExperContext())
            {
                db.Suppliers.Add(supplierToAdd);
                db.SaveChanges();
            }
        }

        public static void ModifySupplier(Supplier supplierToAdd)
        {
            Supplier oldSupplier;
            using (TravelExperContext db = new TravelExperContext())
            {
                oldSupplier = db.Suppliers.Find(supplierToAdd.SupplierId);
                CopySupplierData(oldSupplier, supplierToAdd);
                db.SaveChanges();
            }
        }

        private static void CopySupplierData(Supplier oldSupplier, Supplier supplierToAdd)
        {
            if (oldSupplier != null && supplierToAdd != null)
            {

                oldSupplier.SupName = supplierToAdd.SupName;
            }
        }

        public static void RemoveSupplier(Supplier selectedSupplier)
        {
            using (TravelExperContext db = new TravelExperContext())
            {
                db.Suppliers.Remove(selectedSupplier);
                db.SaveChanges();
            }
        }
    }
}
