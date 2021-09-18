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
        public frmAddModifyPackage()
        {
            InitializeComponent();
        }

        private void frmAddModifyItem_Load(object sender, EventArgs e)
        {
            if(isAdd) //Add
            {
                this.Text = "Add Package";
                txtPkgID.ReadOnly = true;
                txtPkgID.PlaceholderText = "auto-generated";

            }
            else //Modify
            {
                this.Text = "Modify Package";
                if(package == null)
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
            if(Validator.IsDateFormat(txtStartDate) && Validator.IsDateFormat(txtEndDate))//Add validators here
            {
                if (isAdd)
                {
                    package = new Package();
                }

                /*  package.PackageId = Convert.ToInt32(txtPkgID.Text);*/
                
                package.PkgName = txtName.Text;
                package.PkgStartDate = Convert.ToDateTime(txtEndDate.Text);
                package.PkgEndDate = Convert.ToDateTime(txtEndDate.Text);
                package.PkgBasePrice = Convert.ToDecimal(txtBasePrice.Text);
                package.PkgDesc = txtDescription.Text;
                package.PkgAgencyCommission = Convert.ToDecimal(txtCommission.Text);
                this.DialogResult = DialogResult.OK;

            }
        }
    }
}
