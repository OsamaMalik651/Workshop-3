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

    public partial class frmAddModifyProducts : Form

    {
        public bool isAdd; //true when add, and false when modify
        public Product product = null;
        public frmAddModifyProducts()
        {
            InitializeComponent();
        }

        private void frmAddModifyProducts_Load(object sender, EventArgs e)
        {
            txtProductID.ReadOnly = true;
            if (isAdd) //Add
            {
                this.Text = "Add Product";
                txtProductID.Text = "auto-generated";

            }
            else //Modify
            {
                this.Text = "Modify Product";
                if (product == null)
                {

                    MessageBox.Show("There is no current product selected", "Modify Error");
                    this.DialogResult = DialogResult.Cancel;
                    //this.Close(); // close this form
                }
                //Display Current Product
                txtProductID.ReadOnly = true;
                txtProductID.Text = product.ProductId.ToString();
                txtProductName.Text = product.ProdName;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

        }
    }
}
