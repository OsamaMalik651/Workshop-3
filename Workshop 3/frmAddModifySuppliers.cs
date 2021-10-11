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

//Made by Osama Malik
namespace Workshop_3
{
    public partial class frmAddModifySuppliers : Form
    {
        //Variable initializtion for the operation of forms.
        public bool isAdd; //true when add, and false when modify
        public Supplier supplier= null;
        private List<SupplierDTO> suppliers;
        public frmAddModifySuppliers()
        {
            InitializeComponent();
        }

        private void frmAddModifySuppliers_Load(object sender, EventArgs e)
        {
            txtSupplierID.ReadOnly = true;
            suppliers = SupplierManager.GetSuppliers();
            
                if (isAdd) //Add
                {
                    this.Text = "Add Supplier";
                    txtSupplierID.Text = "auto-generated";
                    txtSupplierName.Focus();
                }
                else //Modify
                {
                    this.Text = "Modify Supplier";
                    if (supplier == null)
                    {

                        MessageBox.Show("There is no current supplier selected", "Modify Error");
                        this.DialogResult = DialogResult.Cancel;
                        //this.Close(); // close this form
                    }
                    //Display Current Product
                    txtSupplierID.ReadOnly = true;
                    txtSupplierID.Text = supplier.SupplierId.ToString();
                    txtSupplierName.Text = supplier.SupName;
                }
            
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtSupplierName) && Validator.IsTextWithInLength(txtSupplierName, 250))
            {
                if (isAdd)
                {
                    supplier = new Supplier();
                }   
                //find the max supplier id and add one to it as the database column in not an autoincrementing one.
                suppliers = SupplierManager.GetSuppliers();
                var supplierID = suppliers.Max(x => x.SupplierId) + 1;
                supplier.SupplierId = supplierID;
                supplier.SupName = txtSupplierName.Text;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
