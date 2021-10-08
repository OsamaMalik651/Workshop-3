
namespace Workshop_3
{
    partial class fromAddModifyPckgPrdSupplier
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbPrdSuppID = new System.Windows.Forms.ComboBox();
            this.cbPckgID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxProductName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Supplier Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(70, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Package Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnAccept
            // 
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(171, 200);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(126, 52);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "&Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(344, 200);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(126, 52);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbPrdSuppID
            // 
            this.cbPrdSuppID.FormattingEnabled = true;
            this.cbPrdSuppID.Location = new System.Drawing.Point(280, 39);
            this.cbPrdSuppID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbPrdSuppID.Name = "cbPrdSuppID";
            this.cbPrdSuppID.Size = new System.Drawing.Size(332, 31);
            this.cbPrdSuppID.TabIndex = 1;
            this.cbPrdSuppID.SelectedIndexChanged += new System.EventHandler(this.cbPrdSuppID_SelectedIndexChanged);
            // 
            // cbPckgID
            // 
            this.cbPckgID.FormattingEnabled = true;
            this.cbPckgID.Location = new System.Drawing.Point(280, 140);
            this.cbPckgID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbPckgID.Name = "cbPckgID";
            this.cbPckgID.Size = new System.Drawing.Size(332, 31);
            this.cbPckgID.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(70, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Product Name:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBoxProductName
            // 
            this.txtBoxProductName.Location = new System.Drawing.Point(280, 91);
            this.txtBoxProductName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxProductName.Name = "txtBoxProductName";
            this.txtBoxProductName.ReadOnly = true;
            this.txtBoxProductName.Size = new System.Drawing.Size(192, 31);
            this.txtBoxProductName.TabIndex = 4;
            // 
            // fromAddModifyPckgPrdSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(64)))), ((int)(((byte)(80)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(638, 297);
            this.Controls.Add(this.txtBoxProductName);
            this.Controls.Add(this.cbPckgID);
            this.Controls.Add(this.cbPrdSuppID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(656, 344);
            this.Name = "fromAddModifyPckgPrdSupplier";
            this.Text = "fromAddModifyPckgPrdSupplier";
            this.Load += new System.EventHandler(this.fromAddModifyPckgPrdSupplier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbPrdSuppID;
        private System.Windows.Forms.ComboBox cbPckgID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxProductName;
    }
}