
namespace Workshop_3
{
    partial class frmAddModifyPackage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPackageID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPkgID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtBasePrice = new System.Windows.Forms.TextBox();
            this.txtCommission = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbProducts = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbSuppliers = new System.Windows.Forms.ComboBox();
            this.listBoxSelectedProducts = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddProducts = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPackageID
            // 
            this.lblPackageID.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPackageID.ForeColor = System.Drawing.Color.White;
            this.lblPackageID.Location = new System.Drawing.Point(29, 54);
            this.lblPackageID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPackageID.Name = "lblPackageID";
            this.lblPackageID.Size = new System.Drawing.Size(146, 35);
            this.lblPackageID.TabIndex = 0;
            this.lblPackageID.Text = "PackageID:";
            this.lblPackageID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 107);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 164);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Start Date:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(29, 215);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "End Date:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(718, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 32);
            this.label4.TabIndex = 0;
            this.label4.Text = "Description:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(718, 158);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 35);
            this.label5.TabIndex = 0;
            this.label5.Text = "Base Price:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(615, 215);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(252, 32);
            this.label6.TabIndex = 0;
            this.label6.Text = "Agency Commission:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPkgID
            // 
            this.txtPkgID.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPkgID.Location = new System.Drawing.Point(199, 51);
            this.txtPkgID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPkgID.Name = "txtPkgID";
            this.txtPkgID.Size = new System.Drawing.Size(377, 31);
            this.txtPkgID.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtName.Location = new System.Drawing.Point(199, 108);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(377, 31);
            this.txtName.TabIndex = 1;
            this.txtName.Tag = "Name";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtStartDate.Location = new System.Drawing.Point(199, 161);
            this.txtStartDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(377, 31);
            this.txtStartDate.TabIndex = 2;
            this.txtStartDate.Tag = "Start Date";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEndDate.Location = new System.Drawing.Point(199, 212);
            this.txtEndDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(377, 31);
            this.txtEndDate.TabIndex = 3;
            this.txtEndDate.Tag = "End Date";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDescription.Location = new System.Drawing.Point(888, 51);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(526, 84);
            this.txtDescription.TabIndex = 4;
            this.txtDescription.Tag = "Description";
            // 
            // txtBasePrice
            // 
            this.txtBasePrice.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBasePrice.Location = new System.Drawing.Point(888, 154);
            this.txtBasePrice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBasePrice.Name = "txtBasePrice";
            this.txtBasePrice.Size = new System.Drawing.Size(224, 31);
            this.txtBasePrice.TabIndex = 5;
            this.txtBasePrice.Tag = "Base Price";
            // 
            // txtCommission
            // 
            this.txtCommission.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCommission.Location = new System.Drawing.Point(888, 212);
            this.txtCommission.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCommission.Name = "txtCommission";
            this.txtCommission.Size = new System.Drawing.Size(224, 31);
            this.txtCommission.TabIndex = 6;
            this.txtCommission.Tag = "Commision";
            // 
            // btnAccept
            // 
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAccept.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(534, 722);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(172, 54);
            this.btnAccept.TabIndex = 12;
            this.btnAccept.Text = "&Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(802, 722);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(172, 54);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(679, 52);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 38);
            this.label7.TabIndex = 3;
            this.label7.Text = "Select Supplier:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbProducts
            // 
            this.cbProducts.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbProducts.FormattingEnabled = true;
            this.cbProducts.Location = new System.Drawing.Point(289, 48);
            this.cbProducts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbProducts.Name = "cbProducts";
            this.cbProducts.Size = new System.Drawing.Size(342, 31);
            this.cbProducts.TabIndex = 7;
            this.cbProducts.Tag = "Product";
            this.cbProducts.SelectedIndexChanged += new System.EventHandler(this.cbProducts_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(29, 52);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(231, 29);
            this.label8.TabIndex = 3;
            this.label8.Text = "Select Product:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbSuppliers
            // 
            this.cbSuppliers.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbSuppliers.FormattingEnabled = true;
            this.cbSuppliers.Location = new System.Drawing.Point(888, 48);
            this.cbSuppliers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbSuppliers.Name = "cbSuppliers";
            this.cbSuppliers.Size = new System.Drawing.Size(526, 31);
            this.cbSuppliers.TabIndex = 8;
            this.cbSuppliers.Tag = "Supplier";
            this.cbSuppliers.SelectedIndexChanged += new System.EventHandler(this.cbSuppliers_SelectedIndexChanged);
            // 
            // listBoxSelectedProducts
            // 
            this.listBoxSelectedProducts.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxSelectedProducts.FormattingEnabled = true;
            this.listBoxSelectedProducts.ItemHeight = 27;
            this.listBoxSelectedProducts.Location = new System.Drawing.Point(289, 122);
            this.listBoxSelectedProducts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listBoxSelectedProducts.Name = "listBoxSelectedProducts";
            this.listBoxSelectedProducts.Size = new System.Drawing.Size(738, 139);
            this.listBoxSelectedProducts.TabIndex = 9;
            this.listBoxSelectedProducts.SelectedIndexChanged += new System.EventHandler(this.listBoxSelectedProducts_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(29, 122);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(231, 29);
            this.label10.TabIndex = 6;
            this.label10.Text = "Selected Products";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnAddProducts
            // 
            this.btnAddProducts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddProducts.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddProducts.Location = new System.Drawing.Point(1101, 122);
            this.btnAddProducts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddProducts.Name = "btnAddProducts";
            this.btnAddProducts.Size = new System.Drawing.Size(230, 64);
            this.btnAddProducts.TabIndex = 10;
            this.btnAddProducts.Text = "Add Product";
            this.btnAddProducts.UseVisualStyleBackColor = true;
            this.btnAddProducts.Click += new System.EventHandler(this.btnAddProducts_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemove.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRemove.Location = new System.Drawing.Point(1101, 193);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(230, 64);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "Remove Product";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPkgID);
            this.groupBox1.Controls.Add(this.lblPackageID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtStartDate);
            this.groupBox1.Controls.Add(this.txtEndDate);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.txtCommission);
            this.groupBox1.Controls.Add(this.txtBasePrice);
            this.groupBox1.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(55, 25);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(1436, 308);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Package";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbProducts);
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.cbSuppliers);
            this.groupBox2.Controls.Add(this.btnAddProducts);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.listBoxSelectedProducts);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(55, 362);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(1436, 325);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Products";
            // 
            // frmAddModifyPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(64)))), ((int)(((byte)(80)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1556, 798);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximumSize = new System.Drawing.Size(1574, 845);
            this.MinimumSize = new System.Drawing.Size(1574, 845);
            this.Name = "frmAddModifyPackage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddItem";
            this.Load += new System.EventHandler(this.frmAddModifyItem_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPackageID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPkgID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtBasePrice;
        private System.Windows.Forms.TextBox txtCommission;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbProducts;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbSuppliers;
        private System.Windows.Forms.ListBox listBoxSelectedProducts;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAddProducts;
        private System.Windows.Forms.Button btnRemove;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}