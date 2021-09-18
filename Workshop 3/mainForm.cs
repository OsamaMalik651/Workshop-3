﻿using TravelExpertsData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Made by Osama Malik, Tracy Crape and Adisola.
namespace Workshop_3
{
    public partial class mainForm : Form
    {

        string selectedTable = null; //Variable to keep track of the selected table
        private int ModifyIndex; // index for the Modify button column
        private int DeleteIndex; // index for the Delete button column
        

        List<PackagesDTO> packages;
        List<ProductsDTO> products;
        List<SupplierDTO> suppliers;
        List<ProductsSupplierDTO> productssuppliers;
        List<PackagesProductsSupplierDTO> packagesproductssuppliers;
              
        private Package selectedPackage;
        private Product selectedProduct;
        private Supplier selectedSupplier;
        private ProductsSupplier selectedProductsSupplier;
        private PackagesProductsSupplier selectedPackagesProductsSupplier;
        
        private Package packageToAdd;
        private Product productToAdd;
        private Supplier supplierToAdd;
        private ProductsSupplier productssupplierToAdd;
        private PackagesProductsSupplier packagesproductsupplierToAdd;
       

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            /*DisplayPackages();*/
        }

        //Section of Code to set up data grid view and associated funtion to prepare Datagrid for Data source change.
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
        private void deleteCoulumns()
        {
            dgView.AutoGenerateColumns = true;
            dgView.Columns.Clear();
            dgView.DataSource = null;
        }

        //Section of code for the button click events.
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
        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            deleteCoulumns();
            DisplaySupplier();
        }
        private void btnProductSupplers_Click(object sender, EventArgs e)
        {
            deleteCoulumns();
            DisplayProductsSupplier();
        }


        //Section of code for the Display functions for each table
        private void DisplayPackages()
        {
            deleteCoulumns();
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
        private void DisplayProducts()
        {
            deleteCoulumns();
            //Get Products
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
        private void DisplaySupplier()
        {
            deleteCoulumns();
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



        //Function for the selection of appropriate selection of tables to modify and delete 

        private void btnPackProdSup_Click(object sender, EventArgs e)
        {
            deleteCoulumns();
            DisplayPackagesProductsSupplier();
        }
        private void DisplayPackagesProductsSupplier()
        {
            //Get Packages Product Suppliers (Sola Oyatunji)
            packagesproductssuppliers = PackagesProductsSupplierManager.GetPackagesProductsSupplier();
            //Set DataGridView Datasourse to Package products supplier.
            dgView.DataSource = packagesproductssuppliers.ToList();

            dgViewSetup();

            // Format Data Grid View
            dgView.Columns[0].HeaderText = "Products Supplier Id";
            dgView.Columns[0].Width = 120;


            dgView.Columns[1].HeaderText = "Package Id";
            dgView.Columns[1].Width = 180;

            ModifyIndex = 2;
            DeleteIndex = 3;
        }

        private void dgView_CellClick(object sender,
        DataGridViewCellEventArgs e)
        {
            if (selectedTable == "Packages")
            {
                if (e.ColumnIndex == ModifyIndex || e.ColumnIndex == DeleteIndex)
                {
                    int packageID = Convert.ToInt32(
                    dgView.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                    selectedPackage = PackageManager.GetPackages(packageID);
                    
                }
                if (e.ColumnIndex == ModifyIndex)
                {
                   
                    ModifyPackage(selectedPackage);
                }
                else if (e.ColumnIndex == DeleteIndex)
                {
                
                    DeletePackage(selectedPackage);
                }
                

            }
            else if (selectedTable == "Products")
            {
                if (e.ColumnIndex == ModifyIndex || e.ColumnIndex == DeleteIndex)
                {
                    int productID = Convert.ToInt32(
                    dgView.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                    selectedProduct = ProductManager.GetProduct(productID);
                }
                if (e.ColumnIndex == ModifyIndex)
                {
                    ModifyProduct(selectedProduct);
                }
                else if (e.ColumnIndex == DeleteIndex)
                {    
                    DeleteProduct(selectedProduct);
                }
                    
            }

            else if (selectedTable == "Supplier")
            {
                if (e.ColumnIndex == ModifyIndex || e.ColumnIndex == DeleteIndex)
                {
                    int supplierID = Convert.ToInt32(dgView.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                    selectedSupplier = SupplierManager.GetSupplier(supplierID);
                }
                if (e.ColumnIndex == ModifyIndex)
                {
                    ModifySupplier(selectedSupplier);
                }
                else if (e.ColumnIndex == DeleteIndex)
                {
                    DeleteSupplier(selectedSupplier);
                }

            }

        }

      
=======
            //else if (selectedTable == "Product Suppliers")
            //{
            //    if (e.ColumnIndex == ModifyIndex || e.ColumnIndex == DeleteIndex)
            //    {
            //        int productsSupplierID = Convert.ToInt32(
            //        dgView.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
            //        selectedProductsSupplier = ProductsSupplierManager.GetProductSupplier(productsSupplierID);
            //    }
            //    if (e.ColumnIndex == ModifyIndex)
            //    {
            //        label1.Text = $"Modify {selectedProductsSupplier.ProdSupName}";
            //        ModifyProductsSupplier(selectedProductsSupplier.ProductsSupplierId);
            //    }
            //    else if (e.ColumnIndex == DeleteIndex)
            //        label1.Text = $"Delete {selectedProductsSupplier.ProdSupName}";
            //}
            //else if (selectedTable == "Package Products Supplier")
            //{
            //    if (e.ColumnIndex == ModifyIndex || e.ColumnIndex == DeleteIndex)
            //    {
            //        int productID = Convert.ToInt32(
            //        dgView.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
            //        selectedPackagesProductsSupplier = PackagesProductsSupplierManager.GetPackagesProductsSupplier(PackagesProductsSupplierID);
            //    }
            //    if (e.ColumnIndex == ModifyIndex)
            //    {
            //        label1.Text = $"Modify {selectedPackagesProductsSupplier.ProdName}";
            //        ModifyPackagesProductsSupplier(selectedPackagesProductsSupplier.PackagesProductsSupplierId);
            //    }
            //    else if (e.ColumnIndex == DeleteIndex)
            //        label1.Text = $"Delete {selectedPackagesProductsSupplier.ProdName}";
            //}

        }

        //Section of code with Add,Modify and Delete package functions.
        private void AddPackage()
        {
            frmAddModifyPackage addForm = new frmAddModifyPackage
            {
                isAdd = true
            };
            DialogResult result = addForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.packageToAdd = addForm.package;
                try
                {
                    PackageManager.AddPackage(packageToAdd);
                    DisplayPackages();
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Error when adding package: {ex.Message}",
                                    ex.GetType().ToString());
                }

            }

        }
        private void ModifyPackage(Package package)
        {
            frmAddModifyPackage modifyPackage = new frmAddModifyPackage();
            modifyPackage.isAdd = false;
            modifyPackage.package = this.selectedPackage;
            DialogResult result = modifyPackage.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.packageToAdd = modifyPackage.package;
                try
                {
                    PackageManager.ModifyPackage(packageToAdd);
                    DisplayPackages();
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Error when modifying package: {ex.Message}",
                                    ex.GetType().ToString());
                }

            }
        }

        private void DeletePackage(Package package)

        {
            if (selectedPackage == null) //No selected product
            {
                MessageBox.Show("There is no package selected", "Delete Error");
                return;
            }
        // get confirmation before delete
            DialogResult answer = MessageBox.Show($"Are you sure to delete {selectedPackage}?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

               if (answer == DialogResult.Yes)              //Confirmed deletion

    
        {
            if (selectedTable != null)
            {
                try
                {
                    PackageManager.RemovePackage(selectedPackage);      //Delete the product from the database     
                    DisplayPackages();                                  //Display the updated products table.

                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Error when deleting customer: {ex.Message}", ex.GetType().ToString()); //Display error if unable to delete the product.
                }
            }
            else
            {
                MessageBox.Show("Deletion cancelled");
            }
    }

        //Section of code with Add, Modify and Delete Product Functions.
        private void AddProduct()
        {
            frmAddModifyProducts addProduct = new frmAddModifyProducts();
            addProduct.isAdd = true;
            DialogResult result = addProduct.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.productToAdd = addProduct.product;
                try
                {
                    ProductManager.AddProduct(productToAdd);
                    DisplayProducts();
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Error when adding product: {ex.Message}",
                                    ex.GetType().ToString());
                }

            }

        }
        private void ModifyProduct(Product product)
        {
            frmAddModifyProducts modifyProduct = new frmAddModifyProducts();
            modifyProduct.isAdd = false;
            modifyProduct.product = this.selectedProduct;
            DialogResult result = modifyProduct.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.productToAdd = modifyProduct.product;
                try
                {
                    ProductManager.ModifyProduct(productToAdd);
                    DisplayProducts();
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Error when modifying product: {ex.Message}",
                                    ex.GetType().ToString());
                }

            }
        }
        private void DeleteProduct(Product product)
        {
            if (selectedProduct == null) //No selected product
            {
                MessageBox.Show("There is no product selected", "Delete Error");
                return;
            }
            // get confirmation before delete
            DialogResult answer = MessageBox.Show($"Are you sure to delete {selectedProduct}?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)              //Confirmed deletion
            {
                try
                {
                    ProductManager.RemoveProduct(selectedProduct);      //Delete the product from the database     
                    DisplayProducts();                                  //Display the updated products table.

                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Error when deleting customer: {ex.Message}", ex.GetType().ToString()); //Display error if unable to delete the product.
                }
            }
            else
            {
                MessageBox.Show("Deletion cancelled");
            }

        }

        //Section of Code with ADD,Modify and Delete Supplier Functions.
        private void AddSupplier()
        {
            frmAddModifySuppliers addSupplier = new frmAddModifySuppliers();
            addSupplier.isAdd = true;
            DialogResult result = addSupplier.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.supplierToAdd = addSupplier.supplier;
                try
                {

                    SupplierManager.AddSupplier(supplierToAdd);
                    DisplaySupplier();
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Error when adding supplier: {ex.Message}",
                                    ex.GetType().ToString());
                }

            }

        }
        private void ModifySupplier(Supplier selectedSupplier)
        {
            frmAddModifySuppliers modifySupplier = new frmAddModifySuppliers();
            modifySupplier.isAdd = false;
            modifySupplier.supplier = this.selectedSupplier;
            DialogResult result = modifySupplier.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.supplierToAdd = modifySupplier.supplier;
                try
                {
                    SupplierManager.ModifySupplier(supplierToAdd);
                    DisplaySupplier();
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Error when modifying package: {ex.Message}",
                                    ex.GetType().ToString());
                }
            }

        }

        private void DeleteSupplier(Supplier selectedSupplier)
        {
            if (selectedSupplier == null) //No selected Supplier
            {
                MessageBox.Show("There is no supplier selected", "Delete Error");
                return;
            }
            // get confirmation before delete
            DialogResult answer = MessageBox.Show($"Are you sure to delete {selectedSupplier}?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)              //Confirmed deletion
            {
                try
                {
                    SupplierManager.RemoveSupplier(selectedSupplier);      //Delete the Supplier from the database     
                    DisplaySupplier();                                  //Display the updated Supplier table.

                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Error when deleting Supplier: {ex.Message}", ex.GetType().ToString()); //Display error if unable to delete the product.
                }
            }
            else
            {
                MessageBox.Show("Deletion cancelled");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }

        private void btnAdd_Click(object sender, EventArgs e)
            {
                if (selectedTable != null)
                {
                    switch (selectedTable)
                    {
                        case ("Packages"):
                            AddPackage();
                            break;
                        //Add case below
                        case ("Products"):
                            AddProduct();
                            break;
                        //
                        case ("Supplier"):
                            AddSupplier();
                            break;
                    }

                }
                else
                {
                    MessageBox.Show("Please select a table to add the record!");
                }
            }

       

        private void label1_Click(object sender, EventArgs e)
            {

            }
        }

    }
