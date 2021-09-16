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
    public partial class frmAddModifyItem : Form
    {
        public string selectedTable;
        public bool isAdd; //true when add, and false when modify
        public Package package = null;
        public frmAddModifyItem()
        {
            InitializeComponent();
        }

        private void frmAddModifyItem_Load(object sender, EventArgs e)
        {
            this.Text = selectedTable;

        }
    }
}
