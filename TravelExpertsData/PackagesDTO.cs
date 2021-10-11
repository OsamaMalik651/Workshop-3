//Date: October 11, 2021
//Projetc: PROJ - 009 - 003 – Project Workshop 3, Desktop Application

//Group 1, Team 1:
//Osama Malik		SAIT Student ID 880863
//Tracy Crape		SAIT Student ID 420488
//Adesola Oyatunji	SAIT Student ID 838997

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class PackagesDTO
    {
        public int PackageId { get; set; }
    
        public string PkgName { get; set; }
       
        public DateTime? PkgStartDate { get; set; }
   
        public DateTime? PkgEndDate { get; set; }
       
        public string PkgDesc { get; set; }
       
        public decimal PkgBasePrice { get; set; }
       
        public decimal? PkgAgencyCommission { get; set; }

        //newly added
       /* public virtual ICollection<PackagesProductsSupplier> PackagesProductsSuppliers { get; set; }*/


    }
}
