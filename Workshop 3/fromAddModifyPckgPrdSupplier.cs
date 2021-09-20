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
        public bool isAdd; //true when add, and false when modify
        public PackagesProductsSupplier PckgPrdSupplier = null;
        public fromAddModifyPckgPrdSupplier()
        {
            InitializeComponent();
        }

        private void fromAddModifyPckgPrdSupplier_Load(object sender, EventArgs e)
        {
            //Populate Product Supplier ID and Package Id in the comboboxes.
            List<PackagesDTO> packages = PackageManager.GetPackages();
            List<ProductsSupplierDTO> productsSuppliers = ProductsSupplierManager.GetProductsSupplier();
            
            cbPrdSuppID.DataSource = productsSuppliers;
            cbPrdSuppID.DisplayMember = "ProductSupplierId";
            cbPrdSuppID.ValueMember = "ProductSupplierId";

            cbPckgID.DataSource = packages;
            cbPckgID.DisplayMember = "PackageId";
            cbPckgID.ValueMember = "PackageId";


            if (isAdd) //Add
            {
                this.Text = "Add Product";
               /* txtProductID.Text = "auto-generated";*/

            }
            else //Modify
            {
                this.Text = "Modify Product";
                if (PckgPrdSupplier == null)
                {

                    MessageBox.Show("There is no current item selected", "Modify Error");
                    this.DialogResult = DialogResult.Cancel;
                    //this.Close(); // close this form
                }
                //Display Current Item
                cbPrdSuppID.SelectedValue = PckgPrdSupplier.ProductSupplierId;
                cbPckgID.SelectedValue = PckgPrdSupplier.PackageId;
                
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
    }
}
