using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class ProductSupplierDetails
    {
        public int ProductSupplierId { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }

        public string ProductWithSupplier => ProductName + " provided by " + SupplierName;

    }
}
