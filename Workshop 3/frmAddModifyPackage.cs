//Date: October 11, 2021
//Projetc: PROJ - 009 - 003 – Project Workshop 3, Desktop Application

//Group 1, Team 1:
//Osama Malik		SAIT Student ID 880863
//Tracy Crape		SAIT Student ID 420488
//Adesola Oyatunji	SAIT Student ID 838997

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
{   //Author: Osama Malik
    //Received help in logical grouping, organization of form and display of list of products from Priya.
    public partial class frmAddModifyPackage : Form
    {
        //Initialize the variables for the operation of the form
        public bool isAdd; //true when add, and false when modify
        public Package package = null;
        public int productID = 0;
        public int productsupplierId = 0;
        public List<int> listOfProducts = new List<int>();
        int ListBoxindex = -1;
        List<ProductSupplierDetails> list = new List<ProductSupplierDetails>();
        BindingSource bs = new BindingSource();  //Create an empty binding source.

        //Get the details from the required tables.
        List<ProductsSupplierDTO> productSuppliers = ProductsSupplierManager.GetProductsSuppliers();
        List<ProductsDTO> products = ProductManager.GetProducts();
        List<SupplierDTO> supplierlist = SupplierManager.GetSuppliers();
        public frmAddModifyPackage()
        {
            InitializeComponent();
        }

        //Method called whenever the form loads
        private void frmAddModifyItem_Load(object sender, EventArgs e)
        {
            //set the combobox for the products.
            cbProducts.DataSource = products;
            cbProducts.DisplayMember = "ProdName";
            cbProducts.ValueMember = "ProdName";

            
            if (isAdd) //Add
            {
                this.Text = "Add Package"; //Set the title of the form
                txtPkgID.ReadOnly = true;
                txtPkgID.PlaceholderText = "auto-generated";       
            }
            else //Modify
            {
                this.Text = "Modify Package"; //Set the title of the form
                PopulateListWithDetails();     //Function to load the list of products of the selected package.
                bs.DataSource = list;          //Set the binding source to the list of productsupplierDetails.
                listBoxSelectedProducts.DataSource = bs;    //set the datasource of the listbox to binding source.
                listBoxSelectedProducts.DisplayMember = "ProductWithSupplier";  //Set the display memeber of the list box.
                 listBoxSelectedProducts.ValueMember = "ProductSupplierID";     //SEt hte value member of the list box.
                if (package == null)
                {

                    MessageBox.Show("There is no current package selected", "Modify Error");
                    this.DialogResult = DialogResult.Cancel;
                    //this.Close(); // close this form
                }
                //Display Current Package
                txtPkgID.ReadOnly = true;
                txtPkgID.Text = package.PackageId.ToString();
                txtName.Text = package.PkgName;
                if (package.PkgStartDate.HasValue)
                {
                    txtStartDate.Text = package.PkgStartDate?.ToString("d");
                }
                else
                    txtStartDate.Text = "";
                if (package.PkgStartDate.HasValue)
                {
                    txtEndDate.Text = package.PkgEndDate?.ToString("d");
                }
                else
                txtEndDate.Text = "";
                txtDescription.Text = package.PkgDesc?.ToString();
                txtBasePrice.Text = package.PkgBasePrice.ToString();
                txtCommission.Text = package.PkgAgencyCommission.ToString();


            }

        }
     
        //Method called when teh user selects a product from the product combobox.
        private void cbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ProductId = products.ElementAt(cbProducts.SelectedIndex).ProductId; //Geth the product id from the combobox
            productID = GetProductId(ProductId);    //Set the product id to the retrieved one.
        }
        //Method called when teh user selects a Supplier from the product combobox.
        private void cbSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = products.ElementAt(cbProducts.SelectedIndex).ProductId;
            productsupplierId = GetProductSupplierID(id);
        }
        private void listBoxSelectedProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxindex = listBoxSelectedProducts.SelectedIndex; //Store the current selected item index in a variable.
        }

        private void btnAddProducts_Click(object sender, EventArgs e)
        {
            AddProductToList(); //Function called to add the product the product list
            ListBoxSetUp();     //Update the listbox with the newly added product.
            listOfProducts.Add(productsupplierId);  //Add the productsupplier id to the  
      }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            listOfProducts.Remove(Convert.ToInt32(listBoxSelectedProducts.SelectedValue));
            list.RemoveAt(ListBoxindex);
            ListBoxSetUp();
        }

        private void btnAccept_Click(object sender, EventArgs e)  //Fucntion called when the accept button is clicked
        {
            //Check for all the validations. //Erros are displayed form the validator class
            //Except for one, All these validator functions come from the validator class as taught during the course by the instructor. They are reused here
            if (Validator.IsPresent(txtName) && Validator.IsTextWithInLength(txtName, 50) &&
                Validator.IsPresent(txtStartDate) && Validator.IsDateFormat(txtEndDate) &&
                Validator.IsPresent(txtEndDate) && Validator.IsDateFormat(txtEndDate) &&
                Validator.IsPresent(txtDescription) && Validator.IsTextWithInLength(txtDescription, 50) &&
                Validator.IsPresent(txtBasePrice) && Validator.IsNonNegativeDecimal(txtBasePrice) &&
                Validator.IsPresent(txtCommission) && Validator.IsNonNegativeDecimal(txtCommission) //Add validators here
                )
            {
                if (isAdd)  //IF the add operation is to be performed
                {
                    package = new Package();  //create a new package
                }
                //Fill the details from the from to the package.
                //Below lines of code are executed for both add and modify operations.

                package.PkgName = txtName.Text;
                package.PkgStartDate = Convert.ToDateTime(txtEndDate.Text);
                package.PkgEndDate = Convert.ToDateTime(txtEndDate.Text);
                package.PkgBasePrice = Convert.ToDecimal(txtBasePrice.Text);
                package.PkgDesc = txtDescription.Text;
                package.PkgAgencyCommission = Convert.ToDecimal(txtCommission.Text);
                this.DialogResult = DialogResult.OK;

            }
        }

        //------------------------------------------------------------List of Functions------------------------------------------------------------//

        //Function called to setup the listbox
        private void ListBoxSetUp()
        {
            bs.DataSource = list;
            listBoxSelectedProducts.DataSource = bs;
            listBoxSelectedProducts.DisplayMember = "ProductWithSupplier";
            listBoxSelectedProducts.ValueMember = "ProductSupplierID";
            bs.ResetBindings(false);
        }
        /// <summary>
        /// Function called to get the product supplier id
        /// </summary>
        /// <param name="id"> PRoductID to get the suppliers.</param>
        /// <returns></returns>
        private int GetProductSupplierID(int id)
        {
            var supplier = productSuppliers.FindAll(s => s.ProductId == id).ToList(); //Get all the suppliers who provide the product with the provided product id.

            var suppliersFound = supplier.Join(                 //Create a variable with the supplier name, supplier id, supplier id and the product supplier id
                supplierlist,
                sf => sf.SupplierId,
                s => s.SupplierId,
                (sf, s) => new
                {
                    SupplierName = s.SupName,
                    SupplierId = s.SupplierId,
                    ProductSupplierId = sf.ProductSupplierId
                }
                ).ToList();
            return suppliersFound.ElementAt(cbSuppliers.SelectedIndex).ProductSupplierId; //retrun the product supplier id of the supplier selected.
        }
        /// <summary>
        /// Function Called when adding product to List
        /// </summary>
        private void AddProductToList()
        {
            var details = productSuppliers                  //Create a variable with requrired details only from the supplier list and prodcuts.
                               .Join(
                                   supplierlist,
                                   prdSup => prdSup.SupplierId,
                                   sup => sup.SupplierId,
                                   (prdsup, sup) => new
                                   {
                                       ProductSupplierId = prdsup.ProductSupplierId,
                                       SupplierId = sup.SupplierId,
                                       SupplierName = sup.SupName,
                                       ProductId = prdsup.ProductId
                                   })
                               .Join(
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
            var a = details.Find(i => i.ProductSupplierId == productsupplierId); //Get the details for the selected productsupplierid(global variable.)
            list.Add(                                           //Add the found  variable to the list of productsupplierdetails. (this list is used to populate the listbox through binding source)
                new ProductSupplierDetails
                {
                    ProductSupplierId = a.ProductSupplierId,
                    ProductId = a.ProductId,
                    ProductName = a.ProductName,
                    SupplierId = a.SupplierId,
                    SupplierName = a.SupplierName
                }
                );
        }
        //
        /// <summary>
        /// Function called to fill the listbox when modifying a package
        /// When modifying, list of products for the given package is provided.
        /// </summary>
        private void PopulateListWithDetails()
        {
            var details = productSuppliers                                                  //Create a variable with requrired details only from the supplier list and prodcuts.
                                .Join(
                                    supplierlist,
                                    prdSup => prdSup.SupplierId,
                                    sup => sup.SupplierId,
                                    (prdsup, sup) => new
                                    {
                                        ProductSupplierId = prdsup.ProductSupplierId,
                                        SupplierId = sup.SupplierId,
                                        SupplierName = sup.SupName,
                                        ProductId = prdsup.ProductId
                                    })
                                .Join(
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

            foreach (int pkgprodsupID in listOfProducts)                                
            {
                var a = details.Find(i => i.ProductSupplierId == pkgprodsupID);         //Get the details for the selected productsupplierid(global variable.)
                list.Add(                                                                //Add the found  variable to the list of productsupplierdetails.
                    new ProductSupplierDetails
                    {
                        ProductSupplierId = a.ProductSupplierId,
                        ProductId = a.ProductId,
                        ProductName = a.ProductName,
                        SupplierId = a.SupplierId,
                        SupplierName = a.SupplierName
                    }
                    );
            }
        }
        //Function called to get the product id when product combobox is selected
        /// <summary>
        /// Populates the Supplier combobox with only the suppliers that are providing that product.
        /// </summary>
        /// <param name="ProductId">Product id to find the suppliers providing this product.</param>
        /// <returns></returns>
        private int GetProductId(int ProductId)
        {
            var supplier = productSuppliers.FindAll(s => s.ProductId == ProductId).ToList();  //Get all the suppliers with the selected product from the product supplier.

            var suppliersFound = supplier.Join(                                               //Create a variable with details of supplier.
                supplierlist,
                sf => sf.SupplierId,
                s => s.SupplierId,
                (sf, s) => new
                {
                    SupplierName = s.SupName,
                    SupplierId = s.SupplierId
                }
                ).ToList();

            cbSuppliers.DataSource = suppliersFound;                                          //Set the variable as the datasource for the supplier combobox.
            cbSuppliers.DisplayMember = "SupplierName";
            cbSuppliers.ValueMember = "SupplierId";

            return Convert.ToInt32(productSuppliers.Find(ps => ps.ProductId == ProductId).ProductId);   //Return the product id after the operation.
        }

        
    }
}
