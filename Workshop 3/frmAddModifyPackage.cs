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
{
    public partial class frmAddModifyPackage : Form
    {
        public bool isAdd; //true when add, and false when modify
        public Package package = null;
        public int productID = 0;
        public int productsupplierId = 0;
        public List<int> listOfProducts = new List<int>();
        int ListBoxindex = -1;
        List<ProductSupplierDetails> list = new List<ProductSupplierDetails>();
        BindingSource bs = new BindingSource();

        List<ProductsSupplierDTO> productSuppliers = ProductsSupplierManager.GetProductsSuppliers();
        List<ProductsDTO> products = ProductManager.GetProducts();
        List<SupplierDTO> supplierlist = SupplierManager.GetSuppliers();
        public frmAddModifyPackage()
        {
            InitializeComponent();
        }

        private void frmAddModifyItem_Load(object sender, EventArgs e)
        {
            cbProducts.DataSource = products;
            cbProducts.DisplayMember = "ProdName";
            cbProducts.ValueMember = "ProdName";

            if (isAdd) //Add
            {
                this.Text = "Add Package";
                txtPkgID.ReadOnly = true;
                txtPkgID.PlaceholderText = "auto-generated";       
            }
            else //Modify
            {
                this.Text = "Modify Package";
                PopulateListWithDetails();
                bs.DataSource = list;
                listBoxSelectedProducts.DataSource = bs;
                listBoxSelectedProducts.DisplayMember = "ProductWithSupplier";
                 listBoxSelectedProducts.ValueMember = "ProductSupplierID";
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
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if(Validator.IsPresent(txtName) && Validator.IsTextWithInLength(txtName,50)&&
                Validator.IsPresent(txtStartDate) && Validator.IsDateFormat(txtEndDate)&&
                Validator.IsPresent(txtEndDate) && Validator.IsDateFormat(txtEndDate)&&
                Validator.IsPresent(txtDescription) && Validator.IsTextWithInLength(txtDescription,50)&&
                Validator.IsPresent(txtBasePrice) && Validator.IsNonNegativeDecimal(txtBasePrice) &&
                Validator.IsPresent(txtCommission) && Validator.IsNonNegativeDecimal(txtDescription) //Add validators here
                )   
            {
                if (isAdd)
                {
                    package = new Package();
                }
                
                package.PkgName = txtName.Text;
                package.PkgStartDate = Convert.ToDateTime(txtEndDate.Text);
                package.PkgEndDate = Convert.ToDateTime(txtEndDate.Text);
                package.PkgBasePrice = Convert.ToDecimal(txtBasePrice.Text);
                package.PkgDesc = txtDescription.Text;
                package.PkgAgencyCommission = Convert.ToDecimal(txtCommission.Text);
                this.DialogResult = DialogResult.OK;

            }
        }

        private void cbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ProductId = products.ElementAt(cbProducts.SelectedIndex).ProductId; 
            productID = GetProductId(ProductId);
        }
        private void cbSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = products.ElementAt(cbProducts.SelectedIndex).ProductId;
            productsupplierId = GetProductSupplierID(id);
        }
        private void listBoxSelectedProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxindex = listBoxSelectedProducts.SelectedIndex;
        }

        private void btnAddProducts_Click(object sender, EventArgs e)
        {
            AddProductToList();
            ListBoxSetUp();
            listOfProducts.Add(productsupplierId);
      }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            listOfProducts.Remove(Convert.ToInt32(listBoxSelectedProducts.SelectedValue));
            list.RemoveAt(ListBoxindex);
            ListBoxSetUp();
        }

        //------------------------------------------------------------List of Functions------------------------------------------------------------//

        private void ListBoxSetUp()
        {
            bs.DataSource = list;
            listBoxSelectedProducts.DataSource = bs;
            listBoxSelectedProducts.DisplayMember = "ProductWithSupplier";
            listBoxSelectedProducts.ValueMember = "ProductSupplierID";
            bs.ResetBindings(false);
        }
        //Function called to get product supplier id
        private int GetProductSupplierID(int id)
        {
            var supplier = productSuppliers.FindAll(s => s.ProductId == id).ToList();

            var suppliersFound = supplier.Join(
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
            return suppliersFound.ElementAt(cbSuppliers.SelectedIndex).ProductSupplierId;
        }
        //Function Called when adding product to List
        private void AddProductToList()
        {
            var details = productSuppliers
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
            var a = details.Find(i => i.ProductSupplierId == productsupplierId);
            list.Add(
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
        //Function called to fill the listbox when modifying a package
        private void PopulateListWithDetails()
        {
            var details = productSuppliers
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
                var a = details.Find(i => i.ProductSupplierId == pkgprodsupID);
                list.Add(
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
        private int GetProductId(int ProductId)
        {
            var supplier = productSuppliers.FindAll(s => s.ProductId == ProductId).ToList();

            var suppliersFound = supplier.Join(
                supplierlist,
                sf => sf.SupplierId,
                s => s.SupplierId,
                (sf, s) => new
                {
                    SupplierName = s.SupName,
                    SupplierId = s.SupplierId
                }
                ).ToList();

            cbSuppliers.DataSource = suppliersFound;
            cbSuppliers.DisplayMember = "SupplierName";
            cbSuppliers.ValueMember = "SupplierId";

            return Convert.ToInt32(productSuppliers.Find(ps => ps.ProductId == ProductId).ProductId);
        }

        
    }
}
