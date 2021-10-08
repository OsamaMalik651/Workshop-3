using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertsData;

namespace Workshop_3
{
    public partial class fromAddModifyPckgPrdSupplier : Form
    {
        List<PackagesDTO> packages = PackageManager.GetPackages();
        List<ProductsSupplierDTO> productSupplier = ProductsSupplierManager.GetProductsSuppliers();
        List<SupplierDTO> suppliers = SupplierManager.GetSuppliers();
        List<ProductsDTO> products = ProductManager.GetProducts();

        public bool isAdd; //true when add, and false when modify
        public PackagesProductsSupplier PckgPrdSupplier = null;

        public fromAddModifyPckgPrdSupplier()
        {
            InitializeComponent();
        }

        private void fromAddModifyPckgPrdSupplier_Load(object sender, EventArgs e)
        {
            //Populate Product Supplier ID and Package Id in the comboboxes.

            var supplierDetails = productSupplier.Join(
                suppliers,
                prdsup => prdsup.SupplierId,
                sup => sup.SupplierId,
                (prdsup, sup) => new
                {
                    ProductSupplierId = prdsup.ProductSupplierId,
                    SupplierId = sup.SupplierId,
                    SupplierName = sup.SupName,
                    ProductId = prdsup.ProductId
                }).Join(
                products,
                prdsup => prdsup.ProductId,
                prd => prd.ProductId,
                (prdsup, prd) => new
                {
                    ProductSupplierId = prdsup.ProductSupplierId,
                    SupplierId = prdsup.SupplierId,
                    SupplierName = prdsup.SupplierName,
                    ProductId = prdsup.ProductId,
                    ProductName = prd.ProdName,
                }).ToList();


            cbPckgID.DataSource = packages;
            cbPckgID.DisplayMember = "PkgName";
            cbPckgID.ValueMember = "PackageId";

            cbPrdSuppID.DataSource = supplierDetails;
            cbPrdSuppID.DisplayMember = "SupplierName";
            cbPrdSuppID.ValueMember = "ProductSupplierId";

            cbPrdSuppID.SelectedIndex = 0;
            cbPckgID.SelectedIndex = 0;

            if (isAdd) //Add
            {
                this.Text = "Add Product";
                /* txtProductID.Text = "auto-generated";*/

            }

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                PckgPrdSupplier = new PackagesProductsSupplier();
            }
            PckgPrdSupplier.ProductSupplierId = Convert.ToInt32(cbPrdSuppID.SelectedValue);
            PckgPrdSupplier.PackageId = Convert.ToInt32(cbPckgID.SelectedValue);
            this.DialogResult = DialogResult.OK;
        }

        private void cbPrdSuppID_SelectedIndexChanged(object sender, EventArgs e)
        {
            var supplierDetails = productSupplier.Join(
                suppliers,
                prdsup => prdsup.SupplierId,
                sup => sup.SupplierId,
                (prdsup, sup) => new
                {
                    ProductSupplierId = prdsup.ProductSupplierId,
                    SupplierId = sup.SupplierId,
                    SupplierName = sup.SupName,
                    ProductId = prdsup.ProductId
                }).Join(
                products,
                prdsup => prdsup.ProductId,
                prd => prd.ProductId,
                (prdsup, prd) => new
                {
                    ProductSupplierId = prdsup.ProductSupplierId,
                    SupplierId = prdsup.SupplierId,
                    SupplierName = prdsup.SupplierName,
                    ProductId = prdsup.ProductId,
                    ProductName = prd.ProdName,
                }).ToList();

            txtBoxProductName.Text = supplierDetails.ElementAt(cbPrdSuppID.SelectedIndex).ProductName;
         
        }
    }
}
