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
            using(TravelExperContext db = new TravelExperContext())
            {
                suppliers = db.Suppliers.Select(s => new SupplierDTO
                {
                    SupplierId= s.SupplierId,
                    SupName = s.SupName,
                    
                }).ToList();
                return suppliers;
            }
            
        }
    }
}
