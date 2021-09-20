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
        private bool productssupplierId;
        private bool productId;
        private bool supplierId;

        public frmAddModifyProductsSupplier()
        {
            InitializeComponent();
        }

        private void frmAddModifyProductsSupplier_Load(object sender, EventArgs e)
        {
            productssuppliers = ProductsSupplierManager.GetProductsSuppliers();
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
                //txtProductId.Text = productssupplier.ProductId;
                //txtSupplierId.Text = productssupplier.SupName;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            prodsupID = prodsupName = false;

            if (isAdd)
            {  
                //Check whether the entered products supplier id is already present in the database
                bool IDpresent = productssuppliers.Exists(e => e.ProductSupplierId == Convert.ToInt32(txtProductsSupplierId.Text));
                if (IDpresent)
                {
                    label4.Text = "Products Supplier Id already present";
                    txtProductsSupplierId.Focus();
                    txtProductsSupplierId.SelectAll();
                }
                else
                    prodsupID = true;
                
                //if (IDPresent)
                //{
                //    label5.Text = "Product Id already present";
                //    label5.ForeColor = Color.Red;
                //}
                //else
                //{ productId = true; }

                //productId = new ProductId();


                if (productId)
                {
                    productssupplier.ProductId = Convert.ToInt32(txtProductId.Text);
                    productssupplier.ProductId = Convert.ToInt32(txtProductId.Text);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    productssupplier.ProductId = Convert.ToInt32(txtProductId.Text);
                    productssupplier.ProductId = Convert.ToInt32(txtProductId.Text);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}

