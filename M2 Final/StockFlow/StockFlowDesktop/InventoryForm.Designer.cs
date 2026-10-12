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
            lblCategory = new Label();
            lblReorderLevel = new Label();
            pnlSidebar = new Panel();
            btnReports = new Button();
            btnSales = new Button();
            btnStock = new Button();
            btnCategories = new Button();
            btnProducts = new Button();
            btnDashboard = new Button();
            lblSidebarTitle = new Label();
            pnlMainContent = new Panel();
            pnlReports = new Panel();
            dgvReports = new DataGridView();
            lblReportResults = new Label();
            btnReportExport = new Button();
            btnReportRefresh = new Button();
            cmbReportType = new ComboBox();
            lblReportType = new Label();
            lblReportsSubtitle = new Label();
            lblReportsTitle = new Label();
            pnlSales = new Panel();
            dgvSalesHistory = new DataGridView();
            lblSalesHistory = new Label();
            dgvSaleItems = new DataGridView();
            btnSalesClear = new Button();
            btnSalesComplete = new Button();
            btnSalesRemoveItem = new Button();
            btnSalesAddItem = new Button();
            txtSalesUnitPrice = new TextBox();
            numSalesQuantity = new NumericUpDown();
            cmbSalesProduct = new ComboBox();
            lblSalesTotalValue = new Label();
            lblSalesTotalTitle = new Label();
            lblCurrentSale = new Label();
            lblSalesUnitPrice = new Label();
            lblSalesQuantity = new Label();
            lblSalesProduct = new Label();
            lblSalesSubtitle = new Label();
            lblSalesTitle = new Label();
            pnlStock = new Panel();
            dgvStockHistory = new DataGridView();
            btnStockClear = new Button();
            btnStockSave = new Button();
            txtStockReason = new TextBox();
            numStockQuantity = new NumericUpDown();
            cmbStockType = new ComboBox();
            cmbStockProduct = new ComboBox();
            lblStockHistory = new Label();
            lblStockReason = new Label();
            lblStockQuantity = new Label();
            lblStockType = new Label();
            lblStockProduct = new Label();
            lblStockSubtitle = new Label();
            lblStockTitle = new Label();
            pnlCategories = new Panel();
            dgvCategories = new DataGridView();
            btnCategoryClear = new Button();
            btnCategoryDelete = new Button();
            btnCategoryUpdate = new Button();
            btnCategoryAdd = new Button();
            txtCategoryDescription = new TextBox();
            txtCategoryName = new TextBox();
            lblCategoryList = new Label();
            lblCategoryDescription = new Label();
            lblCategoryName = new Label();
            lblCategoriesTitle = new Label();
            pnlDashboard = new Panel();
            pnlTotalStockUnits = new Panel();
            lblTotalStockUnitsValue = new Label();
            lblTotalStockUnitsTitle = new Label();
            panel3 = new Panel();
            lblLowStockValue = new Label();
            lblLowStockTitle = new Label();
            panel2 = new Panel();
            lblSalesRevenueValue = new Label();
            lblSalesRevenueTitle = new Label();
            panel1 = new Panel();
            lblInventoryValueValue = new Label();
            lblInventoryValueTitle = new Label();
            pnlTotalProducts = new Panel();
            lblTotalProductsValue = new Label();
            lblTotalProductsTitle = new Label();
            lblDashboardSubtitle = new Label();
            lblDashboardTitle = new Label();
            txtReorderLevel = new TextBox();
            cmbCategory = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            pnlSidebar.SuspendLayout();
            pnlMainContent.SuspendLayout();
            pnlReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReports).BeginInit();
            pnlSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSalesHistory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSaleItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSalesQuantity).BeginInit();
            pnlStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStockHistory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStockQuantity).BeginInit();
            pnlCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
            pnlDashboard.SuspendLayout();
            pnlTotalStockUnits.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            pnlTotalProducts.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.MidnightBlue;
            lblTitle.Location = new Point(30, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(263, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Product Management";
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Location = new Point(30, 100);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(62, 15);
            lblCode.TabIndex = 1;
            lblCode.Text = "Item Code";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(30, 145);
            lblName.Name = "lblName";
            lblName.Size = new Size(66, 15);
            lblName.TabIndex = 2;
            lblName.Text = "Item Name";
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Location = new Point(30, 190);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(38, 15);
            lblBrand.TabIndex = 3;
            lblBrand.Text = "Brand";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(30, 235);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(58, 15);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Unit Price";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(130, 97);
            txtCode.Name = "txtCode";
            txtCode.ReadOnly = true;
            txtCode.Size = new Size(250, 23);
            txtCode.TabIndex = 5;
            // 
            // txtName
            // 
            txtName.Location = new Point(130, 142);
            txtName.Name = "txtName";
            txtName.Size = new Size(250, 23);
            txtName.TabIndex = 6;
            // 
            // txtBrand
            // 
            txtBrand.Location = new Point(130, 187);
            txtBrand.Name = "txtBrand";
            txtBrand.Size = new Size(250, 23);
            txtBrand.TabIndex = 7;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(130, 232);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(250, 23);
            txtPrice.TabIndex = 8;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(30, 290);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 38);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add Item";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(150, 290);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(110, 38);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(270, 290);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 38);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(390, 290);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(110, 38);
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
            dgvItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Location = new Point(30, 385);
            dgvItems.MultiSelect = false;
            dgvItems.Name = "dgvItems";
            dgvItems.ReadOnly = true;
            dgvItems.RowHeadersVisible = false;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.Size = new Size(800, 230);
            dgvItems.TabIndex = 13;
            dgvItems.CellClick += dgvItems_CellClick;
            dgvItems.CellContentClick += dgvItems_CellContentClick;
            // 
            // lblInventory
            // 
            lblInventory.AutoSize = true;
            lblInventory.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInventory.Location = new Point(30, 355);
            lblInventory.Name = "lblInventory";
            lblInventory.Size = new Size(149, 21);
            lblInventory.TabIndex = 14;
            lblInventory.Text = "Product Inventory";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(440, 100);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(55, 15);
            lblCategory.TabIndex = 15;
            lblCategory.Text = "Category";
            lblCategory.Click += label1_Click;
            // 
            // lblReorderLevel
            // 
            lblReorderLevel.AutoSize = true;
            lblReorderLevel.Location = new Point(440, 145);
            lblReorderLevel.Name = "lblReorderLevel";
            lblReorderLevel.Size = new Size(78, 15);
            lblReorderLevel.TabIndex = 16;
            lblReorderLevel.Text = "Reorder Level";
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(25, 35, 65);
            pnlSidebar.Controls.Add(btnReports);
            pnlSidebar.Controls.Add(btnSales);
            pnlSidebar.Controls.Add(btnStock);
            pnlSidebar.Controls.Add(btnCategories);
            pnlSidebar.Controls.Add(btnProducts);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(lblSidebarTitle);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(210, 661);
            pnlSidebar.TabIndex = 20;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.FromArgb(35, 50, 85);
            btnReports.Cursor = Cursors.Hand;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 65, 105);
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReports.ForeColor = Color.White;
            btnReports.Location = new Point(15, 375);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(180, 45);
            btnReports.TabIndex = 26;
            btnReports.Text = "Reports";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseVisualStyleBackColor = false;
            btnReports.Click += btnReports_Click;
            // 
            // btnSales
            // 
            btnSales.BackColor = Color.FromArgb(35, 50, 85);
            btnSales.Cursor = Cursors.Hand;
            btnSales.FlatAppearance.BorderSize = 0;
            btnSales.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 65, 105);
            btnSales.FlatStyle = FlatStyle.Flat;
            btnSales.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSales.ForeColor = Color.White;
            btnSales.Location = new Point(15, 320);
            btnSales.Name = "btnSales";
            btnSales.Size = new Size(180, 45);
            btnSales.TabIndex = 25;
            btnSales.Text = "Sales";
            btnSales.TextAlign = ContentAlignment.MiddleLeft;
            btnSales.UseVisualStyleBackColor = false;
            btnSales.Click += btnSales_Click;
            // 
            // btnStock
            // 
            btnStock.BackColor = Color.FromArgb(35, 50, 85);
            btnStock.Cursor = Cursors.Hand;
            btnStock.FlatAppearance.BorderSize = 0;
            btnStock.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 65, 105);
            btnStock.FlatStyle = FlatStyle.Flat;
            btnStock.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStock.ForeColor = Color.White;
            btnStock.Location = new Point(15, 265);
            btnStock.Name = "btnStock";
            btnStock.Size = new Size(180, 45);
            btnStock.TabIndex = 24;
            btnStock.Text = "Stock Management";
            btnStock.TextAlign = ContentAlignment.MiddleLeft;
            btnStock.UseVisualStyleBackColor = false;
            btnStock.Click += btnStock_Click;
            // 
            // btnCategories
            // 
            btnCategories.BackColor = Color.FromArgb(35, 50, 85);
            btnCategories.Cursor = Cursors.Hand;
            btnCategories.FlatAppearance.BorderSize = 0;
            btnCategories.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 65, 105);
            btnCategories.FlatStyle = FlatStyle.Flat;
            btnCategories.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCategories.ForeColor = Color.White;
            btnCategories.Location = new Point(15, 210);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(180, 45);
            btnCategories.TabIndex = 23;
            btnCategories.Text = "Categories";
            btnCategories.TextAlign = ContentAlignment.MiddleLeft;
            btnCategories.UseVisualStyleBackColor = false;
            btnCategories.Click += btnCategories_Click;
            // 
            // btnProducts
            // 
            btnProducts.BackColor = Color.FromArgb(35, 50, 85);
            btnProducts.Cursor = Cursors.Hand;
            btnProducts.FlatAppearance.BorderSize = 0;
            btnProducts.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 65, 105);
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProducts.ForeColor = Color.White;
            btnProducts.Location = new Point(15, 155);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(180, 45);
            btnProducts.TabIndex = 22;
            btnProducts.Text = "Products";
            btnProducts.TextAlign = ContentAlignment.MiddleLeft;
            btnProducts.UseVisualStyleBackColor = false;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.FromArgb(35, 50, 85);
            btnDashboard.Cursor = Cursors.Hand;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 65, 105);
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(15, 100);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(180, 45);
            btnDashboard.TabIndex = 21;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // lblSidebarTitle
            // 
            lblSidebarTitle.AutoSize = true;
            lblSidebarTitle.BackColor = Color.Transparent;
            lblSidebarTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSidebarTitle.ForeColor = Color.White;
            lblSidebarTitle.Location = new Point(20, 25);
            lblSidebarTitle.Name = "lblSidebarTitle";
            lblSidebarTitle.Size = new Size(148, 37);
            lblSidebarTitle.TabIndex = 0;
            lblSidebarTitle.Text = "StockFlow";
            // 
            // pnlMainContent
            // 
            pnlMainContent.Controls.Add(pnlReports);
            pnlMainContent.Controls.Add(pnlSales);
            pnlMainContent.Controls.Add(pnlStock);
            pnlMainContent.Controls.Add(pnlCategories);
            pnlMainContent.Controls.Add(pnlDashboard);
            pnlMainContent.Controls.Add(txtReorderLevel);
            pnlMainContent.Controls.Add(lblReorderLevel);
            pnlMainContent.Controls.Add(lblInventory);
            pnlMainContent.Controls.Add(lblCategory);
            pnlMainContent.Controls.Add(txtPrice);
            pnlMainContent.Controls.Add(lblName);
            pnlMainContent.Controls.Add(lblPrice);
            pnlMainContent.Controls.Add(txtBrand);
            pnlMainContent.Controls.Add(txtName);
            pnlMainContent.Controls.Add(lblBrand);
            pnlMainContent.Controls.Add(txtCode);
            pnlMainContent.Controls.Add(lblCode);
            pnlMainContent.Controls.Add(btnDelete);
            pnlMainContent.Controls.Add(lblTitle);
            pnlMainContent.Controls.Add(btnAdd);
            pnlMainContent.Controls.Add(btnUpdate);
            pnlMainContent.Controls.Add(btnClear);
            pnlMainContent.Controls.Add(dgvItems);
            pnlMainContent.Controls.Add(cmbCategory);
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(210, 0);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Padding = new Padding(20);
            pnlMainContent.Size = new Size(874, 661);
            pnlMainContent.TabIndex = 27;
            // 
            // pnlReports
            // 
            pnlReports.AutoScroll = true;
            pnlReports.Controls.Add(dgvReports);
            pnlReports.Controls.Add(lblReportResults);
            pnlReports.Controls.Add(btnReportExport);
            pnlReports.Controls.Add(btnReportRefresh);
            pnlReports.Controls.Add(cmbReportType);
            pnlReports.Controls.Add(lblReportType);
            pnlReports.Controls.Add(lblReportsSubtitle);
            pnlReports.Controls.Add(lblReportsTitle);
            pnlReports.Dock = DockStyle.Fill;
            pnlReports.Location = new Point(20, 20);
            pnlReports.Name = "pnlReports";
            pnlReports.Size = new Size(834, 621);
            pnlReports.TabIndex = 30;
            // 
            // dgvReports
            // 
            dgvReports.AllowUserToAddRows = false;
            dgvReports.AllowUserToDeleteRows = false;
            dgvReports.AllowUserToResizeColumns = false;
            dgvReports.AllowUserToResizeRows = false;
            dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReports.Location = new Point(30, 250);
            dgvReports.Name = "dgvReports";
            dgvReports.ReadOnly = true;
            dgvReports.Size = new Size(700, 310);
            dgvReports.TabIndex = 7;
            // 
            // lblReportResults
            // 
            lblReportResults.AutoSize = true;
            lblReportResults.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReportResults.Location = new Point(30, 210);
            lblReportResults.Name = "lblReportResults";
            lblReportResults.Size = new Size(119, 21);
            lblReportResults.TabIndex = 6;
            lblReportResults.Text = "Report Results";
            // 
            // btnReportExport
            // 
            btnReportExport.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReportExport.Location = new Point(565, 143);
            btnReportExport.Name = "btnReportExport";
            btnReportExport.Size = new Size(150, 35);
            btnReportExport.TabIndex = 5;
            btnReportExport.Text = "Export CSV";
            btnReportExport.UseVisualStyleBackColor = true;
            btnReportExport.Click += btnReportExport_Click;
            // 
            // btnReportRefresh
            // 
            btnReportRefresh.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReportRefresh.Location = new Point(400, 143);
            btnReportRefresh.Name = "btnReportRefresh";
            btnReportRefresh.Size = new Size(150, 35);
            btnReportRefresh.TabIndex = 4;
            btnReportRefresh.Text = "Refresh Report";
            btnReportRefresh.UseVisualStyleBackColor = true;
            btnReportRefresh.Click += btnReportRefresh_Click;
            // 
            // cmbReportType
            // 
            cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportType.FormattingEnabled = true;
            cmbReportType.Items.AddRange(new object[] { "Inventory Report", "Sales Report", "Stock Movement Report", "Low-Stock Report" });
            cmbReportType.Location = new Point(30, 145);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new Size(350, 23);
            cmbReportType.TabIndex = 3;
            cmbReportType.SelectedIndexChanged += cmbReportType_SelectedIndexChanged;
            // 
            // lblReportType
            // 
            lblReportType.AutoSize = true;
            lblReportType.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReportType.Location = new Point(30, 115);
            lblReportType.Name = "lblReportType";
            lblReportType.Size = new Size(89, 17);
            lblReportType.TabIndex = 2;
            lblReportType.Text = "Select Report";
            // 
            // lblReportsSubtitle
            // 
            lblReportsSubtitle.AutoSize = true;
            lblReportsSubtitle.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReportsSubtitle.ForeColor = Color.DimGray;
            lblReportsSubtitle.Location = new Point(30, 65);
            lblReportsSubtitle.Name = "lblReportsSubtitle";
            lblReportsSubtitle.Size = new Size(238, 17);
            lblReportsSubtitle.TabIndex = 1;
            lblReportsSubtitle.Text = "View inventory, sales, and stock reports";
            // 
            // lblReportsTitle
            // 
            lblReportsTitle.AutoSize = true;
            lblReportsTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReportsTitle.ForeColor = Color.FromArgb(25, 35, 65);
            lblReportsTitle.Location = new Point(30, 25);
            lblReportsTitle.Name = "lblReportsTitle";
            lblReportsTitle.Size = new Size(261, 32);
            lblReportsTitle.TabIndex = 0;
            lblReportsTitle.Text = "Reports Management";
            // 
            // pnlSales
            // 
            pnlSales.AutoScroll = true;
            pnlSales.Controls.Add(dgvSalesHistory);
            pnlSales.Controls.Add(lblSalesHistory);
            pnlSales.Controls.Add(dgvSaleItems);
            pnlSales.Controls.Add(btnSalesClear);
            pnlSales.Controls.Add(btnSalesComplete);
            pnlSales.Controls.Add(btnSalesRemoveItem);
            pnlSales.Controls.Add(btnSalesAddItem);
            pnlSales.Controls.Add(txtSalesUnitPrice);
            pnlSales.Controls.Add(numSalesQuantity);
            pnlSales.Controls.Add(cmbSalesProduct);
            pnlSales.Controls.Add(lblSalesTotalValue);
            pnlSales.Controls.Add(lblSalesTotalTitle);
            pnlSales.Controls.Add(lblCurrentSale);
            pnlSales.Controls.Add(lblSalesUnitPrice);
            pnlSales.Controls.Add(lblSalesQuantity);
            pnlSales.Controls.Add(lblSalesProduct);
            pnlSales.Controls.Add(lblSalesSubtitle);
            pnlSales.Controls.Add(lblSalesTitle);
            pnlSales.Dock = DockStyle.Fill;
            pnlSales.Location = new Point(20, 20);
            pnlSales.Name = "pnlSales";
            pnlSales.Size = new Size(834, 621);
            pnlSales.TabIndex = 29;
            // 
            // dgvSalesHistory
            // 
            dgvSalesHistory.AllowUserToAddRows = false;
            dgvSalesHistory.AllowUserToDeleteRows = false;
            dgvSalesHistory.AllowUserToResizeColumns = false;
            dgvSalesHistory.AllowUserToResizeRows = false;
            dgvSalesHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSalesHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalesHistory.Location = new Point(30, 587);
            dgvSalesHistory.MultiSelect = false;
            dgvSalesHistory.Name = "dgvSalesHistory";
            dgvSalesHistory.ReadOnly = true;
            dgvSalesHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSalesHistory.Size = new Size(700, 150);
            dgvSalesHistory.TabIndex = 17;
            // 
            // lblSalesHistory
            // 
            lblSalesHistory.AutoSize = true;
            lblSalesHistory.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSalesHistory.Location = new Point(30, 555);
            lblSalesHistory.Name = "lblSalesHistory";
            lblSalesHistory.Size = new Size(109, 21);
            lblSalesHistory.TabIndex = 16;
            lblSalesHistory.Text = "Sales History";
            // 
            // dgvSaleItems
            // 
            dgvSaleItems.AllowUserToAddRows = false;
            dgvSaleItems.AllowUserToDeleteRows = false;
            dgvSaleItems.AllowUserToResizeColumns = false;
            dgvSaleItems.AllowUserToResizeRows = false;
            dgvSaleItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSaleItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSaleItems.Location = new Point(30, 300);
            dgvSaleItems.MultiSelect = false;
            dgvSaleItems.Name = "dgvSaleItems";
            dgvSaleItems.ReadOnly = true;
            dgvSaleItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSaleItems.Size = new Size(700, 135);
            dgvSaleItems.TabIndex = 15;
            // 
            // btnSalesClear
            // 
            btnSalesClear.Location = new Point(205, 495);
            btnSalesClear.Name = "btnSalesClear";
            btnSalesClear.Size = new Size(130, 40);
            btnSalesClear.TabIndex = 14;
            btnSalesClear.Text = "Clear Sale";
            btnSalesClear.UseVisualStyleBackColor = true;
            btnSalesClear.Click += btnSalesClear_Click;
            // 
            // btnSalesComplete
            // 
            btnSalesComplete.Location = new Point(30, 495);
            btnSalesComplete.Name = "btnSalesComplete";
            btnSalesComplete.Size = new Size(160, 40);
            btnSalesComplete.TabIndex = 13;
            btnSalesComplete.Text = "Complete Sale";
            btnSalesComplete.UseVisualStyleBackColor = true;
            btnSalesComplete.Click += btnSalesComplete_Click;
            // 
            // btnSalesRemoveItem
            // 
            btnSalesRemoveItem.Location = new Point(325, 205);
            btnSalesRemoveItem.Name = "btnSalesRemoveItem";
            btnSalesRemoveItem.Size = new Size(140, 40);
            btnSalesRemoveItem.TabIndex = 12;
            btnSalesRemoveItem.Text = "Remove Item";
            btnSalesRemoveItem.UseVisualStyleBackColor = true;
            btnSalesRemoveItem.Click += btnSalesRemoveItem_Click;
            // 
            // btnSalesAddItem
            // 
            btnSalesAddItem.Location = new Point(170, 205);
            btnSalesAddItem.Name = "btnSalesAddItem";
            btnSalesAddItem.Size = new Size(140, 40);
            btnSalesAddItem.TabIndex = 11;
            btnSalesAddItem.Text = "Add to Sale";
            btnSalesAddItem.UseVisualStyleBackColor = true;
            btnSalesAddItem.Click += btnSalesAddItem_Click;
            // 
            // txtSalesUnitPrice
            // 
            txtSalesUnitPrice.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSalesUnitPrice.Location = new Point(470, 155);
            txtSalesUnitPrice.Name = "txtSalesUnitPrice";
            txtSalesUnitPrice.ReadOnly = true;
            txtSalesUnitPrice.Size = new Size(170, 25);
            txtSalesUnitPrice.TabIndex = 10;
            // 
            // numSalesQuantity
            // 
            numSalesQuantity.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numSalesQuantity.Location = new Point(170, 155);
            numSalesQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numSalesQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSalesQuantity.Name = "numSalesQuantity";
            numSalesQuantity.Size = new Size(160, 25);
            numSalesQuantity.TabIndex = 9;
            numSalesQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cmbSalesProduct
            // 
            cmbSalesProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSalesProduct.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbSalesProduct.FormattingEnabled = true;
            cmbSalesProduct.Location = new Point(170, 105);
            cmbSalesProduct.Name = "cmbSalesProduct";
            cmbSalesProduct.Size = new Size(470, 25);
            cmbSalesProduct.TabIndex = 8;
            cmbSalesProduct.SelectedIndexChanged += cmbSalesProduct_SelectedIndexChanged;
            // 
            // lblSalesTotalValue
            // 
            lblSalesTotalValue.AutoSize = true;
            lblSalesTotalValue.Location = new Point(560, 445);
            lblSalesTotalValue.Name = "lblSalesTotalValue";
            lblSalesTotalValue.Size = new Size(35, 15);
            lblSalesTotalValue.TabIndex = 7;
            lblSalesTotalValue.Text = "₱0.00";
            // 
            // lblSalesTotalTitle
            // 
            lblSalesTotalTitle.AutoSize = true;
            lblSalesTotalTitle.Location = new Point(420, 450);
            lblSalesTotalTitle.Name = "lblSalesTotalTitle";
            lblSalesTotalTitle.Size = new Size(82, 15);
            lblSalesTotalTitle.TabIndex = 6;
            lblSalesTotalTitle.Text = "Total Amount:";
            // 
            // lblCurrentSale
            // 
            lblCurrentSale.AutoSize = true;
            lblCurrentSale.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCurrentSale.Location = new Point(30, 265);
            lblCurrentSale.Name = "lblCurrentSale";
            lblCurrentSale.Size = new Size(149, 21);
            lblCurrentSale.TabIndex = 5;
            lblCurrentSale.Text = "Current Sale Items";
            // 
            // lblSalesUnitPrice
            // 
            lblSalesUnitPrice.AutoSize = true;
            lblSalesUnitPrice.Location = new Point(370, 160);
            lblSalesUnitPrice.Name = "lblSalesUnitPrice";
            lblSalesUnitPrice.Size = new Size(58, 15);
            lblSalesUnitPrice.TabIndex = 4;
            lblSalesUnitPrice.Text = "Unit Price";
            // 
            // lblSalesQuantity
            // 
            lblSalesQuantity.AutoSize = true;
            lblSalesQuantity.Location = new Point(30, 160);
            lblSalesQuantity.Name = "lblSalesQuantity";
            lblSalesQuantity.Size = new Size(53, 15);
            lblSalesQuantity.TabIndex = 3;
            lblSalesQuantity.Text = "Quantity";
            // 
            // lblSalesProduct
            // 
            lblSalesProduct.AutoSize = true;
            lblSalesProduct.Location = new Point(30, 110);
            lblSalesProduct.Name = "lblSalesProduct";
            lblSalesProduct.Size = new Size(49, 15);
            lblSalesProduct.TabIndex = 2;
            lblSalesProduct.Text = "Product";
            // 
            // lblSalesSubtitle
            // 
            lblSalesSubtitle.AutoSize = true;
            lblSalesSubtitle.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSalesSubtitle.ForeColor = Color.DimGray;
            lblSalesSubtitle.Location = new Point(32, 70);
            lblSalesSubtitle.Name = "lblSalesSubtitle";
            lblSalesSubtitle.Size = new Size(230, 17);
            lblSalesSubtitle.TabIndex = 1;
            lblSalesSubtitle.Text = "Create sales and manage transactions";
            // 
            // lblSalesTitle
            // 
            lblSalesTitle.AutoSize = true;
            lblSalesTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSalesTitle.ForeColor = Color.FromArgb(25, 35, 65);
            lblSalesTitle.Location = new Point(30, 25);
            lblSalesTitle.Name = "lblSalesTitle";
            lblSalesTitle.Size = new Size(260, 37);
            lblSalesTitle.TabIndex = 0;
            lblSalesTitle.Text = "Sales Management";
            // 
            // pnlStock
            // 
            pnlStock.Controls.Add(dgvStockHistory);
            pnlStock.Controls.Add(btnStockClear);
            pnlStock.Controls.Add(btnStockSave);
            pnlStock.Controls.Add(txtStockReason);
            pnlStock.Controls.Add(numStockQuantity);
            pnlStock.Controls.Add(cmbStockType);
            pnlStock.Controls.Add(cmbStockProduct);
            pnlStock.Controls.Add(lblStockHistory);
            pnlStock.Controls.Add(lblStockReason);
            pnlStock.Controls.Add(lblStockQuantity);
            pnlStock.Controls.Add(lblStockType);
            pnlStock.Controls.Add(lblStockProduct);
            pnlStock.Controls.Add(lblStockSubtitle);
            pnlStock.Controls.Add(lblStockTitle);
            pnlStock.Dock = DockStyle.Fill;
            pnlStock.Location = new Point(20, 20);
            pnlStock.Name = "pnlStock";
            pnlStock.Size = new Size(834, 621);
            pnlStock.TabIndex = 11;
            // 
            // dgvStockHistory
            // 
            dgvStockHistory.AllowUserToAddRows = false;
            dgvStockHistory.AllowUserToDeleteRows = false;
            dgvStockHistory.AllowUserToResizeColumns = false;
            dgvStockHistory.AllowUserToResizeRows = false;
            dgvStockHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStockHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStockHistory.Location = new Point(30, 365);
            dgvStockHistory.MultiSelect = false;
            dgvStockHistory.Name = "dgvStockHistory";
            dgvStockHistory.ReadOnly = true;
            dgvStockHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStockHistory.Size = new Size(700, 175);
            dgvStockHistory.TabIndex = 13;
            // 
            // btnStockClear
            // 
            btnStockClear.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStockClear.Location = new Point(345, 260);
            btnStockClear.Name = "btnStockClear";
            btnStockClear.Size = new Size(110, 40);
            btnStockClear.TabIndex = 12;
            btnStockClear.Text = "Clear";
            btnStockClear.UseVisualStyleBackColor = true;
            btnStockClear.Click += btnStockClear_Click;
            // 
            // btnStockSave
            // 
            btnStockSave.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStockSave.Location = new Point(180, 260);
            btnStockSave.Name = "btnStockSave";
            btnStockSave.Size = new Size(150, 40);
            btnStockSave.TabIndex = 11;
            btnStockSave.Text = "Save Movement";
            btnStockSave.UseVisualStyleBackColor = true;
            btnStockSave.Click += btnStockSave_Click;
            // 
            // txtStockReason
            // 
            txtStockReason.Location = new Point(180, 205);
            txtStockReason.Name = "txtStockReason";
            txtStockReason.Size = new Size(470, 23);
            txtStockReason.TabIndex = 10;
            // 
            // numStockQuantity
            // 
            numStockQuantity.Location = new Point(490, 155);
            numStockQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numStockQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numStockQuantity.Name = "numStockQuantity";
            numStockQuantity.Size = new Size(120, 23);
            numStockQuantity.TabIndex = 9;
            numStockQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cmbStockType
            // 
            cmbStockType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStockType.FormattingEnabled = true;
            cmbStockType.Items.AddRange(new object[] { "IN", "OUT" });
            cmbStockType.Location = new Point(180, 155);
            cmbStockType.Name = "cmbStockType";
            cmbStockType.Size = new Size(180, 23);
            cmbStockType.TabIndex = 8;
            // 
            // cmbStockProduct
            // 
            cmbStockProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStockProduct.FormattingEnabled = true;
            cmbStockProduct.Location = new Point(180, 105);
            cmbStockProduct.Name = "cmbStockProduct";
            cmbStockProduct.Size = new Size(470, 23);
            cmbStockProduct.TabIndex = 7;
            // 
            // lblStockHistory
            // 
            lblStockHistory.AutoSize = true;
            lblStockHistory.Location = new Point(30, 325);
            lblStockHistory.Name = "lblStockHistory";
            lblStockHistory.Size = new Size(138, 15);
            lblStockHistory.TabIndex = 6;
            lblStockHistory.Text = "Stock Movement History";
            // 
            // lblStockReason
            // 
            lblStockReason.AutoSize = true;
            lblStockReason.Location = new Point(30, 210);
            lblStockReason.Name = "lblStockReason";
            lblStockReason.Size = new Size(45, 15);
            lblStockReason.TabIndex = 5;
            lblStockReason.Text = "Reason";
            // 
            // lblStockQuantity
            // 
            lblStockQuantity.AutoSize = true;
            lblStockQuantity.Location = new Point(390, 160);
            lblStockQuantity.Name = "lblStockQuantity";
            lblStockQuantity.Size = new Size(53, 15);
            lblStockQuantity.TabIndex = 4;
            lblStockQuantity.Text = "Quantity";
            // 
            // lblStockType
            // 
            lblStockType.AutoSize = true;
            lblStockType.Location = new Point(30, 160);
            lblStockType.Name = "lblStockType";
            lblStockType.Size = new Size(92, 15);
            lblStockType.TabIndex = 3;
            lblStockType.Text = "Movement Type";
            // 
            // lblStockProduct
            // 
            lblStockProduct.AutoSize = true;
            lblStockProduct.Location = new Point(30, 110);
            lblStockProduct.Name = "lblStockProduct";
            lblStockProduct.Size = new Size(49, 15);
            lblStockProduct.TabIndex = 2;
            lblStockProduct.Text = "Product";
            // 
            // lblStockSubtitle
            // 
            lblStockSubtitle.AutoSize = true;
            lblStockSubtitle.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStockSubtitle.ForeColor = Color.DimGray;
            lblStockSubtitle.Location = new Point(32, 70);
            lblStockSubtitle.Name = "lblStockSubtitle";
            lblStockSubtitle.Size = new Size(253, 17);
            lblStockSubtitle.TabIndex = 1;
            lblStockSubtitle.Text = "Manage incoming and outgoing inventory";
            // 
            // lblStockTitle
            // 
            lblStockTitle.AutoSize = true;
            lblStockTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStockTitle.ForeColor = Color.FromArgb(25, 35, 65);
            lblStockTitle.Location = new Point(30, 25);
            lblStockTitle.Name = "lblStockTitle";
            lblStockTitle.Size = new Size(265, 37);
            lblStockTitle.TabIndex = 0;
            lblStockTitle.Text = "Stock Management";
            // 
            // pnlCategories
            // 
            pnlCategories.BackColor = Color.WhiteSmoke;
            pnlCategories.Controls.Add(dgvCategories);
            pnlCategories.Controls.Add(btnCategoryClear);
            pnlCategories.Controls.Add(btnCategoryDelete);
            pnlCategories.Controls.Add(btnCategoryUpdate);
            pnlCategories.Controls.Add(btnCategoryAdd);
            pnlCategories.Controls.Add(txtCategoryDescription);
            pnlCategories.Controls.Add(txtCategoryName);
            pnlCategories.Controls.Add(lblCategoryList);
            pnlCategories.Controls.Add(lblCategoryDescription);
            pnlCategories.Controls.Add(lblCategoryName);
            pnlCategories.Controls.Add(lblCategoriesTitle);
            pnlCategories.Dock = DockStyle.Fill;
            pnlCategories.Location = new Point(20, 20);
            pnlCategories.Name = "pnlCategories";
            pnlCategories.Size = new Size(834, 621);
            pnlCategories.TabIndex = 5;
            // 
            // dgvCategories
            // 
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.AllowUserToDeleteRows = false;
            dgvCategories.AllowUserToResizeColumns = false;
            dgvCategories.AllowUserToResizeRows = false;
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategories.Location = new Point(30, 355);
            dgvCategories.MultiSelect = false;
            dgvCategories.Name = "dgvCategories";
            dgvCategories.ReadOnly = true;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.Size = new Size(750, 200);
            dgvCategories.TabIndex = 10;
            dgvCategories.CellClick += dgvCategories_CellClick;
            // 
            // btnCategoryClear
            // 
            btnCategoryClear.Location = new Point(425, 240);
            btnCategoryClear.Name = "btnCategoryClear";
            btnCategoryClear.Size = new Size(110, 40);
            btnCategoryClear.TabIndex = 9;
            btnCategoryClear.Text = "Clear";
            btnCategoryClear.UseVisualStyleBackColor = true;
            btnCategoryClear.Click += btnCategoryClear_Click;
            // 
            // btnCategoryDelete
            // 
            btnCategoryDelete.Location = new Point(300, 240);
            btnCategoryDelete.Name = "btnCategoryDelete";
            btnCategoryDelete.Size = new Size(110, 40);
            btnCategoryDelete.TabIndex = 8;
            btnCategoryDelete.Text = "Delete";
            btnCategoryDelete.UseVisualStyleBackColor = true;
            btnCategoryDelete.Click += btnCategoryDelete_Click;
            // 
            // btnCategoryUpdate
            // 
            btnCategoryUpdate.Location = new Point(175, 240);
            btnCategoryUpdate.Name = "btnCategoryUpdate";
            btnCategoryUpdate.Size = new Size(110, 40);
            btnCategoryUpdate.TabIndex = 7;
            btnCategoryUpdate.Text = "Update";
            btnCategoryUpdate.UseVisualStyleBackColor = true;
            btnCategoryUpdate.Click += btnCategoryUpdate_Click;
            // 
            // btnCategoryAdd
            // 
            btnCategoryAdd.Location = new Point(30, 240);
            btnCategoryAdd.Name = "btnCategoryAdd";
            btnCategoryAdd.Size = new Size(130, 40);
            btnCategoryAdd.TabIndex = 6;
            btnCategoryAdd.Text = "Add Category";
            btnCategoryAdd.UseVisualStyleBackColor = true;
            btnCategoryAdd.Click += btnCategoryAdd_Click;
            // 
            // txtCategoryDescription
            // 
            txtCategoryDescription.Location = new Point(200, 165);
            txtCategoryDescription.Name = "txtCategoryDescription";
            txtCategoryDescription.Size = new Size(450, 23);
            txtCategoryDescription.TabIndex = 5;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(200, 95);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(300, 23);
            txtCategoryName.TabIndex = 4;
            // 
            // lblCategoryList
            // 
            lblCategoryList.AutoSize = true;
            lblCategoryList.Location = new Point(30, 315);
            lblCategoryList.Name = "lblCategoryList";
            lblCategoryList.Size = new Size(76, 15);
            lblCategoryList.TabIndex = 3;
            lblCategoryList.Text = "Category List";
            // 
            // lblCategoryDescription
            // 
            lblCategoryDescription.AutoSize = true;
            lblCategoryDescription.Location = new Point(30, 170);
            lblCategoryDescription.Name = "lblCategoryDescription";
            lblCategoryDescription.Size = new Size(67, 15);
            lblCategoryDescription.TabIndex = 2;
            lblCategoryDescription.Text = "Description";
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(30, 100);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(90, 15);
            lblCategoryName.TabIndex = 1;
            lblCategoryName.Text = "Category Name";
            // 
            // lblCategoriesTitle
            // 
            lblCategoriesTitle.AutoSize = true;
            lblCategoriesTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCategoriesTitle.ForeColor = Color.FromArgb(25, 35, 65);
            lblCategoriesTitle.Location = new Point(30, 25);
            lblCategoriesTitle.Name = "lblCategoriesTitle";
            lblCategoriesTitle.Size = new Size(314, 37);
            lblCategoriesTitle.TabIndex = 0;
            lblCategoriesTitle.Text = "Category Management";
            // 
            // pnlDashboard
            // 
            pnlDashboard.BackColor = Color.White;
            pnlDashboard.Controls.Add(pnlTotalStockUnits);
            pnlDashboard.Controls.Add(panel3);
            pnlDashboard.Controls.Add(panel2);
            pnlDashboard.Controls.Add(panel1);
            pnlDashboard.Controls.Add(pnlTotalProducts);
            pnlDashboard.Controls.Add(lblDashboardSubtitle);
            pnlDashboard.Controls.Add(lblDashboardTitle);
            pnlDashboard.Dock = DockStyle.Fill;
            pnlDashboard.Location = new Point(20, 20);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Padding = new Padding(20);
            pnlDashboard.Size = new Size(834, 621);
            pnlDashboard.TabIndex = 28;
            pnlDashboard.Visible = false;
            // 
            // pnlTotalStockUnits
            // 
            pnlTotalStockUnits.BackColor = Color.White;
            pnlTotalStockUnits.BorderStyle = BorderStyle.FixedSingle;
            pnlTotalStockUnits.Controls.Add(lblTotalStockUnitsValue);
            pnlTotalStockUnits.Controls.Add(lblTotalStockUnitsTitle);
            pnlTotalStockUnits.Location = new Point(30, 430);
            pnlTotalStockUnits.Name = "pnlTotalStockUnits";
            pnlTotalStockUnits.Size = new Size(330, 130);
            pnlTotalStockUnits.TabIndex = 4;
            // 
            // lblTotalStockUnitsValue
            // 
            lblTotalStockUnitsValue.AutoSize = true;
            lblTotalStockUnitsValue.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalStockUnitsValue.ForeColor = Color.FromArgb(25, 35, 65);
            lblTotalStockUnitsValue.Location = new Point(49, 62);
            lblTotalStockUnitsValue.Name = "lblTotalStockUnitsValue";
            lblTotalStockUnitsValue.Size = new Size(40, 47);
            lblTotalStockUnitsValue.TabIndex = 1;
            lblTotalStockUnitsValue.Text = "0";
            // 
            // lblTotalStockUnitsTitle
            // 
            lblTotalStockUnitsTitle.AutoSize = true;
            lblTotalStockUnitsTitle.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalStockUnitsTitle.ForeColor = Color.FromArgb(100, 110, 125);
            lblTotalStockUnitsTitle.Location = new Point(20, 18);
            lblTotalStockUnitsTitle.Name = "lblTotalStockUnitsTitle";
            lblTotalStockUnitsTitle.Size = new Size(127, 20);
            lblTotalStockUnitsTitle.TabIndex = 0;
            lblTotalStockUnitsTitle.Text = "Total Stock Units";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblLowStockValue);
            panel3.Controls.Add(lblLowStockTitle);
            panel3.Location = new Point(390, 275);
            panel3.Name = "panel3";
            panel3.Size = new Size(330, 130);
            panel3.TabIndex = 3;
            // 
            // lblLowStockValue
            // 
            lblLowStockValue.AutoSize = true;
            lblLowStockValue.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLowStockValue.ForeColor = Color.FromArgb(25, 35, 65);
            lblLowStockValue.Location = new Point(49, 62);
            lblLowStockValue.Name = "lblLowStockValue";
            lblLowStockValue.Size = new Size(40, 47);
            lblLowStockValue.TabIndex = 1;
            lblLowStockValue.Text = "0";
            // 
            // lblLowStockTitle
            // 
            lblLowStockTitle.AutoSize = true;
            lblLowStockTitle.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLowStockTitle.ForeColor = Color.FromArgb(100, 110, 125);
            lblLowStockTitle.Location = new Point(20, 18);
            lblLowStockTitle.Name = "lblLowStockTitle";
            lblLowStockTitle.Size = new Size(148, 20);
            lblLowStockTitle.TabIndex = 0;
            lblLowStockTitle.Text = "Low-Stock Products";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblSalesRevenueValue);
            panel2.Controls.Add(lblSalesRevenueTitle);
            panel2.Location = new Point(30, 275);
            panel2.Name = "panel2";
            panel2.Size = new Size(330, 130);
            panel2.TabIndex = 3;
            // 
            // lblSalesRevenueValue
            // 
            lblSalesRevenueValue.AutoSize = true;
            lblSalesRevenueValue.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSalesRevenueValue.ForeColor = Color.FromArgb(25, 35, 65);
            lblSalesRevenueValue.Location = new Point(49, 62);
            lblSalesRevenueValue.Name = "lblSalesRevenueValue";
            lblSalesRevenueValue.Size = new Size(111, 47);
            lblSalesRevenueValue.TabIndex = 1;
            lblSalesRevenueValue.Text = "₱0.00";
            // 
            // lblSalesRevenueTitle
            // 
            lblSalesRevenueTitle.AutoSize = true;
            lblSalesRevenueTitle.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSalesRevenueTitle.ForeColor = Color.FromArgb(100, 110, 125);
            lblSalesRevenueTitle.Location = new Point(20, 18);
            lblSalesRevenueTitle.Name = "lblSalesRevenueTitle";
            lblSalesRevenueTitle.Size = new Size(108, 20);
            lblSalesRevenueTitle.TabIndex = 0;
            lblSalesRevenueTitle.Text = "Sales Revenue";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblInventoryValueValue);
            panel1.Controls.Add(lblInventoryValueTitle);
            panel1.Location = new Point(390, 120);
            panel1.Name = "panel1";
            panel1.Size = new Size(330, 130);
            panel1.TabIndex = 3;
            // 
            // lblInventoryValueValue
            // 
            lblInventoryValueValue.AutoSize = true;
            lblInventoryValueValue.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInventoryValueValue.ForeColor = Color.FromArgb(25, 35, 65);
            lblInventoryValueValue.Location = new Point(49, 62);
            lblInventoryValueValue.Name = "lblInventoryValueValue";
            lblInventoryValueValue.Size = new Size(111, 47);
            lblInventoryValueValue.TabIndex = 1;
            lblInventoryValueValue.Text = "₱0.00";
            // 
            // lblInventoryValueTitle
            // 
            lblInventoryValueTitle.AutoSize = true;
            lblInventoryValueTitle.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInventoryValueTitle.ForeColor = Color.FromArgb(100, 110, 125);
            lblInventoryValueTitle.Location = new Point(20, 18);
            lblInventoryValueTitle.Name = "lblInventoryValueTitle";
            lblInventoryValueTitle.Size = new Size(120, 20);
            lblInventoryValueTitle.TabIndex = 0;
            lblInventoryValueTitle.Text = "Inventory Value";
            // 
            // pnlTotalProducts
            // 
            pnlTotalProducts.BackColor = Color.White;
            pnlTotalProducts.BorderStyle = BorderStyle.FixedSingle;
            pnlTotalProducts.Controls.Add(lblTotalProductsValue);
            pnlTotalProducts.Controls.Add(lblTotalProductsTitle);
            pnlTotalProducts.Location = new Point(30, 120);
            pnlTotalProducts.Name = "pnlTotalProducts";
            pnlTotalProducts.Size = new Size(330, 130);
            pnlTotalProducts.TabIndex = 2;
            // 
            // lblTotalProductsValue
            // 
            lblTotalProductsValue.AutoSize = true;
            lblTotalProductsValue.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalProductsValue.ForeColor = Color.FromArgb(25, 35, 65);
            lblTotalProductsValue.Location = new Point(49, 62);
            lblTotalProductsValue.Name = "lblTotalProductsValue";
            lblTotalProductsValue.Size = new Size(40, 47);
            lblTotalProductsValue.TabIndex = 1;
            lblTotalProductsValue.Text = "0";
            // 
            // lblTotalProductsTitle
            // 
            lblTotalProductsTitle.AutoSize = true;
            lblTotalProductsTitle.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalProductsTitle.ForeColor = Color.FromArgb(100, 110, 125);
            lblTotalProductsTitle.Location = new Point(20, 18);
            lblTotalProductsTitle.Name = "lblTotalProductsTitle";
            lblTotalProductsTitle.Size = new Size(110, 20);
            lblTotalProductsTitle.TabIndex = 0;
            lblTotalProductsTitle.Text = "Total Products";
            // 
            // lblDashboardSubtitle
            // 
            lblDashboardSubtitle.AutoSize = true;
            lblDashboardSubtitle.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDashboardSubtitle.ForeColor = Color.FromArgb(100, 110, 125);
            lblDashboardSubtitle.Location = new Point(32, 70);
            lblDashboardSubtitle.Name = "lblDashboardSubtitle";
            lblDashboardSubtitle.Size = new Size(156, 17);
            lblDashboardSubtitle.TabIndex = 1;
            lblDashboardSubtitle.Text = "Inventory & Sales Overview";
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.AutoSize = true;
            lblDashboardTitle.BackColor = Color.Transparent;
            lblDashboardTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDashboardTitle.ForeColor = Color.FromArgb(25, 35, 65);
            lblDashboardTitle.Location = new Point(30, 25);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(157, 37);
            lblDashboardTitle.TabIndex = 0;
            lblDashboardTitle.Text = "Dashboard";
            // 
            // txtReorderLevel
            // 
            txtReorderLevel.Location = new Point(550, 142);
            txtReorderLevel.Name = "txtReorderLevel";
            txtReorderLevel.Size = new Size(100, 23);
            txtReorderLevel.TabIndex = 18;
            txtReorderLevel.Text = "5";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(550, 97);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(121, 23);
            cmbCategory.TabIndex = 19;
            // 
            // InventoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1084, 661);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlSidebar);
            MaximumSize = new Size(1100, 700);
            Name = "InventoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StockFlow - Inventory & Sales Management";
            Load += InventoryForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            pnlMainContent.ResumeLayout(false);
            pnlMainContent.PerformLayout();
            pnlReports.ResumeLayout(false);
            pnlReports.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReports).EndInit();
            pnlSales.ResumeLayout(false);
            pnlSales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSalesHistory).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSaleItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSalesQuantity).EndInit();
            pnlStock.ResumeLayout(false);
            pnlStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStockHistory).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockQuantity).EndInit();
            pnlCategories.ResumeLayout(false);
            pnlCategories.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
            pnlDashboard.ResumeLayout(false);
            pnlDashboard.PerformLayout();
            pnlTotalStockUnits.ResumeLayout(false);
            pnlTotalStockUnits.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlTotalProducts.ResumeLayout(false);
            pnlTotalProducts.PerformLayout();
            ResumeLayout(false);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
        private Label lblCategory;
        private Label lblReorderLevel;
        private Panel pnlSidebar;
        private Label lblSidebarTitle;
        private Button btnDashboard;
        private Button btnReports;
        private Button btnSales;
        private Button btnStock;
        private Button btnCategories;
        private Button btnProducts;
        private Panel pnlMainContent;
        private TextBox txtReorderLevel;
        private ComboBox cmbCategory;
        private Panel pnlDashboard;
        private Label lblDashboardTitle;
        private Label lblDashboardSubtitle;
        private Panel pnlTotalProducts;
        private Label lblTotalProductsValue;
        private Label lblTotalProductsTitle;
        private Panel panel3;
        private Label lblLowStockValue;
        private Label lblLowStockTitle;
        private Panel panel2;
        private Label lblSalesRevenueValue;
        private Label lblSalesRevenueTitle;
        private Panel panel1;
        private Label lblInventoryValueValue;
        private Label lblInventoryValueTitle;
        private Panel pnlTotalStockUnits;
        private Label lblTotalStockUnitsValue;
        private Label lblTotalStockUnitsTitle;
        private Panel pnlCategories;
        private Label lblCategoriesTitle;
        private Label lblCategoryList;
        private Label lblCategoryDescription;
        private Label lblCategoryName;
        private TextBox txtCategoryDescription;
        private TextBox txtCategoryName;
        private DataGridView dgvCategories;
        private Button btnCategoryClear;
        private Button btnCategoryDelete;
        private Button btnCategoryUpdate;
        private Button btnCategoryAdd;
        private Panel pnlStock;
        private Label lblStockTitle;
        private NumericUpDown numStockQuantity;
        private ComboBox cmbStockType;
        private ComboBox cmbStockProduct;
        private Label lblStockHistory;
        private Label lblStockReason;
        private Label lblStockQuantity;
        private Label lblStockType;
        private Label lblStockProduct;
        private Label lblStockSubtitle;
        private TextBox txtStockReason;
        private DataGridView dgvStockHistory;
        private Button btnStockClear;
        private Button btnStockSave;
        private Panel pnlSales;
        private Label lblSalesSubtitle;
        private Label lblSalesTitle;
        private TextBox txtSalesUnitPrice;
        private NumericUpDown numSalesQuantity;
        private ComboBox cmbSalesProduct;
        private Label lblSalesTotalValue;
        private Label lblSalesTotalTitle;
        private Label lblCurrentSale;
        private Label lblSalesUnitPrice;
        private Label lblSalesQuantity;
        private Label lblSalesProduct;
        private DataGridView dgvSaleItems;
        private Button btnSalesClear;
        private Button btnSalesComplete;
        private Button btnSalesRemoveItem;
        private Button btnSalesAddItem;
        private DataGridView dgvSalesHistory;
        private Label lblSalesHistory;
        private Panel pnlReports;
        private Label lblReportType;
        private Label lblReportsSubtitle;
        private Label lblReportsTitle;
        private DataGridView dgvReports;
        private Label lblReportResults;
        private Button btnReportExport;
        private Button btnReportRefresh;
        private ComboBox cmbReportType;
    }
}
