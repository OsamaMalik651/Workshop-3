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
    public partial class frmAddModifyProductsSupplier : Form
    {
       
        //Variable to 
        public bool isAdd; //true when add, and false when modify
        public bool prodsupID, prodsupName;
        public ProductsSupplier productssupplier = null;
        private List<ProductsSupplierDTO> productssuppliers;
        private List<ProductsDTO> products;
        private List<SupplierDTO> suppliers;
       

        public frmAddModifyProductsSupplier()
        {
            InitializeComponent();
        }

        private void frmAddModifyProductsSupplier_Load(object sender, EventArgs e)
        { 
            productssuppliers = ProductsSupplierManager.GetProductsSuppliers();
            products = ProductManager.GetProducts();
            suppliers = SupplierManager.GetSuppliers();

            cbProduct.DataSource = products;
            cbProduct.DisplayMember = "ProdName";
            cbProduct.ValueMember = "ProductId";
            cbProduct.DropDownWidth = 200;

            cbSupplier.DataSource = suppliers;
            cbSupplier.DisplayMember = "SupName";
            cbSupplier.ValueMember = "SupplierId";
            cbSupplier.DropDownWidth = 400;

            txtProductsSupplierId.ReadOnly = true;
            txtProductsSupplierId.Text = "Auto-Generated";

            if (isAdd) //Add
            {
                this.Text = "Add Products Supplier";


            }
            else //Modify
            {
                this.Text = "Modify Products Supplier";
                if (productssupplier == null)
                {
                    MessageBox.Show("There is no current products supplier selected", "Modify Error");
                    this.DialogResult = DialogResult.Cancel;
                    //this.Close(); // close this form
                }
                //Display Current Products Supplier
                txtProductsSupplierId.ReadOnly = true;
                txtProductsSupplierId.Text = productssupplier.SupplierId.ToString();
                cbProduct.SelectedValue = productssupplier.ProductId;
                cbSupplier.SelectedValue = productssupplier.SupplierId;

            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

            if (isAdd)
            {
                productssupplier = new ProductsSupplier();
            }

            /*productssupplier.ProductSupplierId = Convert.ToInt32(txtProductsSupplierId.Text);*/
            productssupplier.ProductId = Convert.ToInt32(cbProduct.SelectedValue.ToString());
            productssupplier.SupplierId = Convert.ToInt32(cbSupplier.SelectedValue.ToString());

            this.DialogResult = DialogResult.OK;
        }
    }
}

