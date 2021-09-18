using TravelExpertsData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Workshop_3
{
    public partial class mainForm : Form
    {
        private int ModifyIndex ; // index for the Modify button column
        private int DeleteIndex ; // index for the Delete button column
        string selectedTable = null;
        List<PackagesDTO> packages;
        List<ProductsDTO> products;
        List<SupplierDTO> suppliers;
        List<ProductsSupplierDTO> productssuppliers;
        private Package selectedPackage;
        private Product selectedProduct;
        

        private Package packageToAdd;

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            DisplayPackages();
        }


        private void DisplayPackages()
        {

            //Get Packages
            packages = PackageManager.GetPackages();

            //Set DataGridView Datasourse to packages.
            dgView.DataSource = packages.ToList();
            dgViewSetup();

            //Format Data Grid View
            dgView.Columns[0].HeaderText = "Package Id";
            dgView.Columns[0].Width = 120;


            dgView.Columns[1].HeaderText = "Package Name";
            dgView.Columns[1].Width = 180;


            dgView.Columns[2].HeaderText = "Package Start Date";
            dgView.Columns[2].Width = 150;


            dgView.Columns[3].HeaderText = "Package End Date";
            dgView.Columns[3].Width = 150;


            dgView.Columns[4].HeaderText = "Package Description";
            dgView.Columns[4].Width = 350;

            dgView.Columns[5].HeaderText = "Package Base Price";
            dgView.Columns[5].Width = 150;
            dgView.Columns[5].DefaultCellStyle.Format = "c";


            dgView.Columns[6].HeaderText = "Package Agency Commission";
            dgView.Columns[6].Width = 150;
            dgView.Columns[6].DefaultCellStyle.Format = "c";

            ModifyIndex = 7;
            DeleteIndex = 8;

            selectedTable = "Packages";

        }

        private void dgViewSetup()
        {
            //DataGridView styling
            dgView.EnableHeadersVisualStyles = false;
            dgView.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dgView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgView.AlternatingRowsDefaultCellStyle.BackColor = Color.BlanchedAlmond;
            dgView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //Adding Modify and Delete button rows

            DataGridViewButtonColumn modifyColumn = new DataGridViewButtonColumn();
            modifyColumn.HeaderText = "";
            modifyColumn.UseColumnTextForButtonValue = true;
            modifyColumn.Text = "Modify";
            dgView.Columns.Add(modifyColumn);


            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.HeaderText = "";
            deleteColumn.UseColumnTextForButtonValue = true;
            deleteColumn.Text = "Delete";
            dgView.Columns.Add(deleteColumn);

        }

        private void btnPackages_Click(object sender, EventArgs e)
        {
            deleteCoulumns();
            DisplayPackages();
        }
        private void btnProducts_Click(object sender, EventArgs e)
        {
            deleteCoulumns();
            DisplayProducts();
        }

        private void DisplayProducts()
        {
            //Get Packages
            products = ProductManager.GetProducts();
            //Set DataGridView Datasourse to packages.
            dgView.DataSource = products.ToList();

            dgViewSetup();

            //Format Data Grid View
            dgView.Columns[0].HeaderText = "Product Id";
            dgView.Columns[0].Width = 120;


            dgView.Columns[1].HeaderText = "Product Name";
            dgView.Columns[1].Width = 180;

            ModifyIndex = 2;
            DeleteIndex = 3;

            selectedTable = "Products";

        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            deleteCoulumns();
            DisplaySupplier();
        }
        private void DisplaySupplier()
        {
            //Get Suppliers
            suppliers = SupplierManager.GetSuppliers();
            //Set DataGridView Datasourse to Suppliers.
            dgView.DataSource = suppliers.ToList();

            dgViewSetup();

            //Format Data Grid View
            dgView.Columns[0].HeaderText = "Supplier Id";
            dgView.Columns[0].Width = 120;


            dgView.Columns[1].HeaderText = "Supplier Name";
            dgView.Columns[1].Width = 180;

            ModifyIndex = 2;
            DeleteIndex = 3;

            selectedTable = "Supplier";

        }
        private void btnProductSupplers_Click(object sender, EventArgs e)
        {
            deleteCoulumns();
            DisplayProductsSupplier();
        }
        private void DisplayProductsSupplier()
         {
            //Get Product Suppliers
            productssuppliers = ProductsSupplierManager.GetProductsSupplier();
             //Set DataGridView Datasourse to products supplier.
             dgView.DataSource = productssuppliers.ToList();

             dgViewSetup();

            // Format Data Grid View
             dgView.Columns[0].HeaderText = "Products Supplier Id";
             dgView.Columns[0].Width = 120;


             dgView.Columns[1].HeaderText = "Product Id";
             dgView.Columns[1].Width = 180;

             dgView.Columns[2].HeaderText = "Supplier Id";
             dgView.Columns[2].Width = 180;

             ModifyIndex = 3;
             DeleteIndex = 4;

             selectedTable = "Products Supplier";

         }

        private void dgView_CellClick(object sender,
        DataGridViewCellEventArgs e)
        {
            if(selectedTable == "Packages")
            {
                if (e.ColumnIndex == ModifyIndex || e.ColumnIndex == DeleteIndex)
                {
                    int packageID = Convert.ToInt32(
                    dgView.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                    selectedPackage = PackageManager.GetPackages(packageID);
                }
                if (e.ColumnIndex == ModifyIndex)
                    label1.Text = $"Modify {selectedPackage.PkgName}";
                else if (e.ColumnIndex == DeleteIndex)
                    label1.Text = $"Delete {selectedPackage.PkgName}";
            }
            else if(selectedTable == "Products"){
                if (e.ColumnIndex == ModifyIndex || e.ColumnIndex == DeleteIndex)
                {
                    int productID = Convert.ToInt32(
                    dgView.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                    selectedProduct = ProductManager.GetProduct(productID);
                }
                if (e.ColumnIndex == ModifyIndex)
                    label1.Text = $"Modify {selectedProduct.ProdName}";
                else if (e.ColumnIndex == DeleteIndex)
                    label1.Text = $"Delete {selectedProduct.ProdName}";
            }
            
        }

        private void deleteCoulumns()
        {
            dgView.AutoGenerateColumns = true;
            dgView.Columns.Clear();
            dgView.DataSource = null;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModifyItem addForm = new frmAddModifyItem();
            if (selectedTable == null)
            {
                MessageBox.Show("Please select a table to Add new Item");
                return;
            }
            else {
                addForm.selectedTable = selectedTable;
            }
            DialogResult result = addForm.ShowDialog();

            /*if(selectedTable == "Packages")
            {
                if (result == DialogResult.OK)
                {
                    this.packageToAdd = addForm.Package; // new customer data
                    try
                    {
                        CustomerManager.Add(customer);
                        DisplayCustomer();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error when adding customer: {ex.Message}",
                                        ex.GetType().ToString());
                    }
                }
            }
            if (result == DialogResult.OK)
            {
                this.customer = addForm.customer; // new customer data
                try
                {
                    CustomerManager.Add(customer);
                    DisplayCustomer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error when adding customer: {ex.Message}",
                                    ex.GetType().ToString());
                }
            }*/

        }
    }
}
