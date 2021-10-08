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
            DisplayPackages();
        }

        //Section of Code to set up data grid view and associated function to prepare Data grid for Data source change.
        private void dgViewSetup()
        {
            //DataGridView styling
            dgView.EnableHeadersVisualStyles = false;
            dgView.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 12, FontStyle.Bold);
            dgView.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#b4cde4");
            dgView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgView.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#d6b7c6");
            
            dgView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgView.BackgroundColor = ColorTranslator.FromHtml("#355F73");

            //Adding Modify and Delete button rows

        }
        private void setModifyDeleteColumns()
        {
            DataGridViewButtonColumn modifyColumn = new DataGridViewButtonColumn();
            modifyColumn.HeaderText = "";
            modifyColumn.UseColumnTextForButtonValue = true;
            modifyColumn.Text = "Modify";
            dgView.Columns.Add(modifyColumn);
            setDeleteColumn();

        }
        private void setDeleteColumn()
        {
            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.HeaderText = "";
            deleteColumn.UseColumnTextForButtonValue = true;
            deleteColumn.Text = "Delete";
            dgView.Columns.Add(deleteColumn);
        }
        private void updateColumns()
        {
            dgView.AutoGenerateColumns = true;
            dgView.Columns.Clear();
            dgView.DataSource = null;
        }

        //Section of code for the button click events.
        private void btnPackages_Click(object sender, EventArgs e)
        {
            updateColumns();
            DisplayPackages();
        }
        private void btnProducts_Click(object sender, EventArgs e)
        {
            updateColumns();
            DisplayProducts();
        }
        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            updateColumns();
            DisplaySupplier();
        }
        private void btnProductSupplers_Click(object sender, EventArgs e)
        {
            updateColumns();
            DisplayProductsSupplier();
        }
        private void btnPackProdSup_Click(object sender, EventArgs e)
        {
            updateColumns();
            DisplayPackagesProductsSupplier();
        }


        //Section of code for the Display functions for each table
        private void DisplayPackages()
        {
            updateColumns();
            //Get Packages
            packages = PackageManager.GetPackages();

            //Set DataGridView Data source to packages.
            dgView.DataSource = packages.ToList();

            dgViewSetup();
            setModifyDeleteColumns();

            //Format Data Grid View
            dgView.Columns[0].HeaderText = "Package Id";
            dgView.Columns[0].Width =   120;


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
            updateColumns();
            //Get Products
            products = ProductManager.GetProducts();
            //Set DataGridView Data source to packages.
            dgView.DataSource = products.ToList();

            dgViewSetup();
            setModifyDeleteColumns();

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
            updateColumns();
            //Get Suppliers
            suppliers = SupplierManager.GetSuppliers();
            //Set DataGridView Data source to Suppliers.
            dgView.DataSource = suppliers.ToList();

            dgViewSetup();
            setModifyDeleteColumns();

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
            updateColumns();
            //Get other tables to display relevant details in the Grid view
            products = ProductManager.GetProducts();
            suppliers = SupplierManager.GetSuppliers();
            
            //get ProductName, ProductID from Products table and Supplier Name from Supplier Table and merge them in a new variable. 
            var tabledata = ProductsSupplierManager.GetProductsSuppliers()
                .Join(
                products,
                prdsup => prdsup.ProductId,
                prd => prd.ProductId,
                (prdsup, prd) => new
                {
                    ProductId = prd.ProductId,
                    ProductName = prd.ProdName,
                    SupplierId = prdsup.SupplierId,
                    ProductSupplierId =prdsup.ProductSupplierId
                })
                .Join(
                suppliers,
                prdsup => prdsup.SupplierId,
                sup => sup.SupplierId,
                (prdsup,sup) => new
                {
                    ProductSupplierId = prdsup.ProductSupplierId,
                    ProductName = prdsup.ProductName,
                    SupplierName = sup.SupName,
                    ProductId = prdsup.ProductId
                }).OrderBy(pn=> pn.ProductName)
                .ToList();

       
            //Set tabledata Data source to products supplier.
            dgView.DataSource = tabledata.Select(td => new
            {
                //Column1 = td.ProductSupplierId,
                Column1 = td.ProductName,
                Column2 = td.SupplierName
            }).ToList();
            dgViewSetup();
            setDeleteColumn();

            // Format Data Grid View
            dgView.Columns[0].HeaderText = "Product Name";
            dgView.Columns[0].Width = 150;


            dgView.Columns[1].HeaderText = "Products Supplier Name";
            dgView.Columns[1].Width = 280;

          
            DeleteIndex = 2;

            selectedTable = "ProductsSupplier";

        }
        private void DisplayPackagesProductsSupplier()
        {
            updateColumns();
            //Get Packages Product Suppliers (Sola Oyatunji)
            //packagesproductssuppliers = PackagesProductsSupplierManager.GetPackagesProductsSupplier();
            packages = PackageManager.GetPackages();
            productssuppliers = ProductsSupplierManager.GetProductsSuppliers();
            suppliers = SupplierManager.GetSuppliers();

            var pkgprod = PackagesProductsSupplierManager.GetPackagesProductsSupplier().Join(
                packages,
                prd=> prd.PackageId,
                pkg=> pkg.PackageId,
                (prd,pkg) => new
                {
                    /*PackageID = prd.PackageId,*/
                    ProductsSupplierID = prd.ProductSupplierId,
                    PackageName = pkg.PkgName,
                    PackageId = pkg.PackageId
                }
                ).Join(
                productssuppliers,
                prdsup => prdsup.ProductsSupplierID,
                psup => psup.ProductSupplierId,
                (prdsup, psup) => new
                {
                    ProductsSupplierID = prdsup.ProductsSupplierID,
                    PackageName = prdsup.PackageName,
                    PackageId = prdsup.PackageId,
                    SupplierId =psup.SupplierId,
                }).Join(
                suppliers,
                prdsup => prdsup.SupplierId,
                sup => sup.SupplierId,
                (prdsup, sup) => new {
                    ProductsSupplierID = prdsup.ProductsSupplierID,
                    PackageName = prdsup.PackageName,
                    PackageId = prdsup.PackageId,
                    SupplierId = prdsup.SupplierId,
                    SupplierName = sup.SupName
                }).OrderBy(pps=> pps.PackageName)
                .ToList();


            //Set DataGridView Data source to Package products supplier.
            dgView.DataSource = pkgprod.Select(pd => new
            {
                Column1 = pd.PackageName,
                Column2 = pd.SupplierName,
                Column5 = pd.ProductsSupplierID
            }).ToList();
            /*  dgView.DataSource = pkgprod;*/
            dgViewSetup();
            setDeleteColumn();

            // Format Data Grid View
            dgView.Columns[0].HeaderText = "Package Name";
            dgView.Columns[0].Width = 220;
            
            dgView.Columns[1].HeaderText = "Supplier Name";
            dgView.Columns[1].Width = 220;

            this.dgView.Columns[2].Visible = false;

          
            DeleteIndex = 3;
            selectedTable = "PackagesProductsSupplier";
        }

        //Function for the selection of appropriate selection of tables to modify and delete 
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

            else if (selectedTable == "ProductsSupplier")
            {
                if (e.ColumnIndex == DeleteIndex)
                {
                    productssuppliers = ProductsSupplierManager.GetProductsSuppliers();
                    suppliers = SupplierManager.GetSuppliers();
                    string supname = dgView.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                    int supplierId = suppliers.Find(sup => sup.SupName == supname).SupplierId;
                    int productsSupplierID = productssuppliers.Find(sup => sup.SupplierId == supplierId).ProductSupplierId;
                    selectedProductsSupplier = ProductsSupplierManager.GetProductSupplier(productsSupplierID);
                    DeleteProductsSuppliers(selectedProductsSupplier);
                }
            }
            else if (selectedTable == "PackagesProductsSupplier")
            {
                if (e.ColumnIndex == DeleteIndex)
                {
                    packagesproductssuppliers = PackagesProductsSupplierManager.GetPackagesProductsSupplier();
                    int productsSupplierID = Convert.ToInt32(dgView.Rows[e.RowIndex].Cells[2].Value.ToString().Trim());
                    int packageSupplierId = packagesproductssuppliers.Find(i => i.ProductSupplierId == productsSupplierID).PackageId;
                    selectedPackagesProductsSupplier = PackagesProductsSupplierManager.GetPackagesProductsSupplier(packageSupplierId, productsSupplierID);
                }
                
                if (e.ColumnIndex == DeleteIndex)
                {
                    DeletePackagesProductsSupplier(selectedPackagesProductsSupplier);
                }
            }

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
                    List<int> listOfProducts = addForm.listOfProducts;
                    try
                    {
                        PackageManager.AddPackage(packageToAdd, listOfProducts);
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
                modifyPackage.listOfProducts = PackagesProductsSupplierManager.GetPackagesProductsSupplier().Where(i => i.PackageId ==package.PackageId).Select(i=> i.ProductSupplierId).ToList();
                
                DialogResult result = modifyPackage.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.packageToAdd = modifyPackage.package;
                List<int> listofProducts = modifyPackage.listOfProducts;
                    try
                    {
                        PackageManager.ModifyPackage(packageToAdd, listofProducts);
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
                DialogResult answer = MessageBox.Show($"Are you sure to delete {selectedPackage.PkgName}?",
                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.Yes)              //Confirmed deletion
                {
                    if (selectedTable != null)
                    {
                        
                        try
                        {
                            PackagesProductsSupplierManager.RemoveAllEntries(selectedPackage.PackageId);
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
                modifyProduct.product = product;
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
                DialogResult answer = MessageBox.Show($"Are you sure to delete {selectedProduct.ProdName}?",
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
                    MessageBox.Show("Deletion canceled");
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
                modifySupplier.supplier = selectedSupplier;
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
                DialogResult answer = MessageBox.Show($"Are you sure to delete {selectedSupplier.SupName}?",
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
                    MessageBox.Show("Deletion canceled");
                }
            }

            //Section of Code with ADD and Delete Products Supplier Functions.
            private void AddProducstsSupplier()
            {
                frmAddModifyProductsSupplier addProductsSupplier = new frmAddModifyProductsSupplier();
                addProductsSupplier.isAdd = true;
                DialogResult result = addProductsSupplier.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.productssupplierToAdd = addProductsSupplier.productssupplier;
               
                    try
                    {
                        ProductsSupplierManager.AddProductsSupplier(productssupplierToAdd);
                        DisplayProductsSupplier();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show($"Error when adding product: {ex.Message}",
                                        ex.GetType().ToString());
                    }

                }
            }
            private void DeleteProductsSuppliers(ProductsSupplier selectedProductsSupplier)
            {
                if (selectedProductsSupplier == null) //No selected Products Supplier
                {
                    MessageBox.Show("There is no Products Supplier selected", "Delete Error");
                    return;
                }
                // get confirmation before delete
                DialogResult answer = MessageBox.Show($"Are you sure to delete selected record?",
                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (answer == DialogResult.Yes)              //Confirmed deletion
                {
                    try
                    {
                        ProductsSupplierManager.RemoveProductsSupplier(selectedProductsSupplier);      //Delete the Products Supplier from the database     
                        DisplayProductsSupplier();                                                      //Display the updated Products Supplier table.

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show($"Error when deleting Products Supplier: {ex.Message}", ex.GetType().ToString()); //Display error if unable to delete the products supplier.
                    }
                }
                else
                {
                    MessageBox.Show("Deletion canceled");
                }
            }

        //Section of Code with ADD and Delete Packages Products Supplier Functions.
        private void AddPackagesProductsSupplier()
        {
            fromAddModifyPckgPrdSupplier addPckgPrdSupplierForm = new fromAddModifyPckgPrdSupplier();
            addPckgPrdSupplierForm.isAdd = true;
            DialogResult result = addPckgPrdSupplierForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.packagesproductsupplierToAdd = addPckgPrdSupplierForm.PckgPrdSupplier;
                try
                {
                    List<PackagesProductsSupplier> pkgprdsupplierlist = new List<PackagesProductsSupplier>();
                    pkgprdsupplierlist.Add(packagesproductsupplierToAdd);
                    PackagesProductsSupplierManager.Add(pkgprdsupplierlist);
                    DisplayPackagesProductsSupplier();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error when adding Package Product Supplier: {ex.Message}",
                                    ex.GetType().ToString());
                }
            }
        }
        private void DeletePackagesProductsSupplier(PackagesProductsSupplier selectedPackagesProductsSupplier)
        {
            if (selectedPackagesProductsSupplier == null) //No selected Package product supplier
            {
                MessageBox.Show("There is no item selected", "Delete Error");
                return;
            }
            // get confirmation before delete
            DialogResult answer = MessageBox.Show("Are you sure to delete selected record?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)              //Confirmed deletion
            {
                try
                {
                    PackagesProductsSupplierManager.RemoveSupplier(selectedPackagesProductsSupplier);       //Delete the record from the database     
                    DisplayPackagesProductsSupplier();                                                      //Display the updated Supplier table.

                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Error when deleting Package Product Supplier: {ex.Message}", ex.GetType().ToString()); //Display error if unable to delete the product.
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
                        case ("ProductsSupplier"):
                        AddProducstsSupplier();
                            break;
                    case ("PackagesProductsSupplier"):
                        AddPackagesProductsSupplier();
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
