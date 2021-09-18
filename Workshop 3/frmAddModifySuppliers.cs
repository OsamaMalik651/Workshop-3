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
        //Variable to 
        public bool isAdd; //true when add, and false when modify
        public bool supID, supName;
        public Supplier supplier= null;
        private List<SupplierDTO> suppliers;
        public frmAddModifySuppliers()
        {
            InitializeComponent();
        }

        private void frmAddModifySuppliers_Load(object sender, EventArgs e)
        {
            suppliers = SupplierManager.GetSuppliers();
            if (isAdd) //Add
            {
                this.Text = "Add Supplier";

            }
            else //Modify
            {
                this.Text = "Modify Product";
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
            label3.Text="";
            label4.Text = "";
            supID = supName = false;

            if (isAdd)
            {  //Check whether the entered supplier id is already present in the database
                bool IDpresent = suppliers.Exists(s => s.SupplierId == Convert.ToInt32(txtSupplierID.Text));
                if (IDpresent)
                {
                    label3.Text = "Supplier Id already present";
                    txtSupplierID.Focus();
                    txtSupplierID.SelectAll();
                }
                else
                    supID = true;
                bool supPresent = suppliers.Exists(s => s.SupName == txtSupplierName.Text);
                if (supPresent)
                {
                    label4.Text = "Supplier already present";
                    label4.ForeColor = Color.Red;
                }
                else
                { supName = true; }

                supplier = new Supplier();
                if(supID && supName) { 
                supplier.SupplierId = Convert.ToInt32(txtSupplierID.Text);
                supplier.SupName = txtSupplierName.Text;
                this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                supplier.SupplierId = Convert.ToInt32(txtSupplierID.Text);
                supplier.SupName = txtSupplierName.Text;
                this.DialogResult = DialogResult.OK;
            }





        }
    }
}
