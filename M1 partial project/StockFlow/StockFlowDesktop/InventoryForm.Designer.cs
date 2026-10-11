namespace StockFlowDesktop
{
    partial class InventoryForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblCode = new Label();
            lblName = new Label();
            lblBrand = new Label();
            lblPrice = new Label();
            txtCode = new TextBox();
            txtName = new TextBox();
            txtBrand = new TextBox();
            txtPrice = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            dgvItems = new DataGridView();
            lblInventory = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.MidnightBlue;
            lblTitle.Location = new Point(30, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(459, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "StockFlow Inventory Management";
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Location = new Point(35, 100);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(62, 15);
            lblCode.TabIndex = 1;
            lblCode.Text = "Item Code";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(35, 145);
            lblName.Name = "lblName";
            lblName.Size = new Size(66, 15);
            lblName.TabIndex = 2;
            lblName.Text = "Item Name";
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Location = new Point(35, 190);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(38, 15);
            lblBrand.TabIndex = 3;
            lblBrand.Text = "Brand";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(35, 235);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(58, 15);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Unit Price";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(150, 100);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(250, 23);
            txtCode.TabIndex = 5;
            // 
            // txtName
            // 
            txtName.Location = new Point(150, 145);
            txtName.Name = "txtName";
            txtName.Size = new Size(250, 23);
            txtName.TabIndex = 6;
            // 
            // txtBrand
            // 
            txtBrand.Location = new Point(150, 190);
            txtBrand.Name = "txtBrand";
            txtBrand.Size = new Size(250, 23);
            txtBrand.TabIndex = 7;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(150, 235);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(250, 23);
            txtPrice.TabIndex = 8;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(150, 290);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 35);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add Item";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(260, 290);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 35);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(370, 290);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 35);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(480, 290);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 35);
            btnClear.TabIndex = 12;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // dgvItems
            // 
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AllowUserToDeleteRows = false;
            dgvItems.AllowUserToResizeColumns = false;
            dgvItems.AllowUserToResizeRows = false;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Location = new Point(35, 355);
            dgvItems.MultiSelect = false;
            dgvItems.Name = "dgvItems";
            dgvItems.ReadOnly = true;
            dgvItems.RowHeadersVisible = false;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.Size = new Size(900, 220);
            dgvItems.TabIndex = 13;
            dgvItems.CellClick += dgvItems_CellClick;
            dgvItems.CellContentClick += dgvItems_CellContentClick;
            // 
            // lblInventory
            // 
            lblInventory.AutoSize = true;
            lblInventory.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInventory.Location = new Point(35, 330);
            lblInventory.Name = "lblInventory";
            lblInventory.Size = new Size(149, 21);
            lblInventory.TabIndex = 14;
            lblInventory.Text = "Product Inventory";
            // 
            // InventoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(984, 611);
            Controls.Add(lblInventory);
            Controls.Add(dgvItems);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtPrice);
            Controls.Add(txtBrand);
            Controls.Add(txtName);
            Controls.Add(txtCode);
            Controls.Add(lblPrice);
            Controls.Add(lblBrand);
            Controls.Add(lblName);
            Controls.Add(lblCode);
            Controls.Add(lblTitle);
            Name = "InventoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StockFlow - Inventory Management";
            Load += InventoryForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCode;
        private Label lblName;
        private Label lblBrand;
        private Label lblPrice;
        private TextBox txtCode;
        private TextBox txtName;
        private TextBox txtBrand;
        private TextBox txtPrice;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvItems;
        private Label lblInventory;
    }
}
