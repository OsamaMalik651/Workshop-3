using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{/// <summary>
/// Repository of methods that retrieves data and change Packages Table
/// </summary>
    public static class PackageManager
    {
        /// <summary>
        /// Method to retrieve all the packages from the Travel Experts Database.
        /// </summary>
        /// <returns>List of objects that corresponds to a list of states</returns>
        public static List<PackagesDTO> GetPackages()
        {
            List<PackagesDTO> packages = null;
            using(TravelExperContext db = new TravelExperContext())
            {
                packages = db.Packages.Select(p => new PackagesDTO
                {
                    PackageId = p.PackageId,
                    PkgName = p.PkgName,
                    PkgStartDate = p.PkgStartDate,
                    PkgEndDate = p.PkgEndDate,
                    PkgDesc = p.PkgDesc,
                    PkgBasePrice = p.PkgBasePrice,
                    PkgAgencyCommission = p.PkgAgencyCommission
                })
                .ToList();
            }
            return packages;
        }
        /// <summary>
        /// Method to Retrieve a single package from the database
        /// </summary>
        /// <param name="packageID"></param>
        /// <returns></returns>
        public static Package GetPackages(int packageID)
        {
            Package selectedPackage = null;

            using(TravelExperContext db = new TravelExperContext())
            {
                selectedPackage = db.Packages.Find(packageID);
            }
            return selectedPackage;
        }

        public static void AddPackage(Package newPackage)
        {
            using(TravelExperContext db = new TravelExperContext())
            {
                db.Packages.Add(newPackage);
                db.SaveChanges();
            }
        }


        public static void ModifyPackage(Package newPackage)
        {
            Package oldPackage;
            using(TravelExperContext db = new TravelExperContext())
            {
                oldPackage = db.Packages.Find(newPackage.PackageId);
                CopyPackageData(oldPackage, newPackage);
                db.SaveChanges();
            }
        }

        private static void CopyPackageData(Package oldPackage, Package newPackage)
        {
            if(oldPackage!= null && newPackage!= null)
            {
                oldPackage.PkgName = newPackage.PkgName;
                oldPackage.PkgStartDate = newPackage.PkgStartDate;
                oldPackage.PkgEndDate = newPackage.PkgEndDate;
                oldPackage.PkgDesc = newPackage.PkgDesc;
                oldPackage.PkgBasePrice = newPackage.PkgBasePrice;
                oldPackage.PkgAgencyCommission = newPackage.PkgAgencyCommission;
            }
        }
    }//Class


}//NameSpace
