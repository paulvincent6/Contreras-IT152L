
using System.Net.Http;
using System.Net.Http.Json;

namespace StockFlowDesktop
{
    public partial class InventoryForm : Form
    {
        // 
        // 1. HTTP CLIENT AND CONSTRUCTOR
        // 

        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7031/")
        };

        private readonly List<SaleCartItem> _saleCart = new();


        public InventoryForm()
        {
            InitializeComponent();

            txtCode.ReadOnly = true;

            // Dashboard is the default page.
            ShowPage(pnlDashboard);
        }


        // 
        // 2. FORM LOAD
        // 

        private async void InventoryForm_Load(object sender, EventArgs e)
        {
            await LoadCategoriesAsync();
            await LoadItemsAsync();
            await LoadDashboardAsync();
        }


        // 
        // 3. PAGE NAVIGATION
        //

        private void ShowPage(Panel? page)
        {
            pnlDashboard.Visible = false;
            pnlCategories.Visible = false;
            pnlStock.Visible = false;
            pnlSales.Visible = false;
            pnlReports.Visible = false;

            if (page != null)
            {
                page.Visible = true;
                page.BringToFront();
            }
        }


        private async void btnReports_Click(object sender, EventArgs e)
        {
            ShowPage(pnlReports);

            if (cmbReportType.SelectedIndex == -1)
            {
                cmbReportType.SelectedIndex = 0;
            }
            else
            {
                await LoadReportAsync();
            }
        }



        private async void btnSales_Click(object sender, EventArgs e)
        {
            ShowPage(pnlSales);

            await LoadSalesProductsAsync();
            await LoadSalesHistoryAsync();
        }




        private async void btnStock_Click(object sender, EventArgs e)
        {
            ShowPage(pnlStock);

            await LoadStockProductsAsync();
            await LoadStockHistoryAsync();
        }




        // DASHBOARD BUTTON
        private async void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowPage(pnlDashboard);
            await LoadDashboardAsync();
            await LoadSalesHistoryAsync();
        }

        // PRODUCTS BUTTON
        private void btnProducts_Click(object sender, EventArgs e)
        {
            ShowPage(null);
        }

        // CATEGORIES BUTTON

        private async void btnCategories_Click(object sender, EventArgs e)
        {
            ShowPage(pnlCategories);

            await LoadCategoryTableAsync();
        }


        // 
        // CATEGORY CRUD OPERATIONS
        // 

        // ADD CATEGORY

        private async void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text.Trim();
            string description = txtCategoryDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a category name.");
                return;
            }

            try
            {
                var category = new
                {
                    CategoryName = name,
                    Description = description
                };

                var response = await _httpClient
                    .PostAsJsonAsync("api/categories", category);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Category added successfully!");

                    // Refresh category table immediately
                    await LoadCategoryTableAsync();

                    // Update category dropdown in Product Management
                    await LoadCategoriesAsync();

                    // Clear the input fields
                    ClearCategoryFields();
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Failed to add category: " + error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // UPDATE CATEGORY
        private async void btnCategoryUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow?.DataBoundItem is not Category selected)
            {
                MessageBox.Show("Please select a category to update.");
                return;
            }

            string name = txtCategoryName.Text.Trim();
            string description = txtCategoryDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a category name.");
                return;
            }

            try
            {
                var category = new
                {
                    CategoryName = name,
                    Description = description
                };

                var response = await _httpClient.PutAsJsonAsync(
                    $"api/categories/{selected.CategoryId}", category);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Category updated successfully!");

                    await LoadCategoryTableAsync();
                    await LoadCategoriesAsync();
                    ClearCategoryFields();
                    await LoadItemsAsync();
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Failed to update category: " + error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // DELETE CATEGORY
        private async void btnCategoryDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow?.DataBoundItem is not Category selected)
            {
                MessageBox.Show("Please select a category to delete.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete '{selected.CategoryName}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var response = await _httpClient.DeleteAsync(
                    $"api/categories/{selected.CategoryId}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Category deleted successfully!");

                    await LoadCategoryTableAsync();
                    await LoadCategoriesAsync();
                    ClearCategoryFields();
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Failed to delete category: " + error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // CLEAR CATEGORY BUTTON
        private void btnCategoryClear_Click(object sender, EventArgs e)
        {
            ClearCategoryFields();
        }

        // SELECT CATEGORY FROM TABLE
        private void dgvCategories_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvCategories.Rows[e.RowIndex].DataBoundItem is not Category category)
                return;

            txtCategoryName.Text = category.CategoryName;
            txtCategoryDescription.Text = category.Description ?? "";
        }

        // RESET CATEGORY INPUT FIELDS
        private void ClearCategoryFields()
        {
            txtCategoryName.Clear();
            txtCategoryDescription.Clear();

            dgvCategories.ClearSelection();
            dgvCategories.CurrentCell = null;

            txtCategoryName.Focus();
        }




        // 
        // 4. API DATA LOADING
        // 

        // LOAD DASHBOARD STATISTICS
        private async Task LoadDashboardAsync()
        {
            try
            {
                var stats = await _httpClient
                    .GetFromJsonAsync<DashboardStats>("api/dashboard");

                if (stats == null)
                {
                    MessageBox.Show("No dashboard data was returned.");
                    return;
                }

                lblTotalProductsValue.Text =
                    stats.TotalProducts.ToString();

                lblTotalStockUnitsValue.Text =
                    stats.TotalStockUnits.ToString();

                lblInventoryValueValue.Text =
                    $"₱{stats.InventoryValue:N2}";

                lblSalesRevenueValue.Text =
                    $"₱{stats.TotalRevenue:N2}";

                lblLowStockValue.Text =
                    stats.LowStockProducts.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load dashboard: " + ex.Message,
                    "Dashboard Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // LOAD PRODUCTS
        private async Task LoadItemsAsync()
        {
            try
            {
                var items = await _httpClient
                    .GetFromJsonAsync<List<Item>>("api/items");

                dgvItems.DataSource = null;
                dgvItems.DataSource = items ?? new List<Item>();

                dgvItems.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvItems.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load inventory: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // LOAD CATEGORIES INTO PRODUCT COMBOBOX
        private async Task LoadCategoriesAsync()
        {
            try
            {
                var categories = await _httpClient
                    .GetFromJsonAsync<List<Category>>("api/categories");

                cmbCategory.DataSource = null;
                cmbCategory.DataSource =
                    categories ?? new List<Category>();

                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryName";
                cmbCategory.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load categories: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // 
        // 5. PRODUCT VALIDATION
        // 

        private bool TryGetProductInput(out Item item)
        {
            item = new Item();

            // Validate required fields.
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtBrand.Text) ||
                cmbCategory.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Please enter the product name, brand, and category.");
                return false;
            }

            // Validate unit price.
            if (!decimal.TryParse(txtPrice.Text, out decimal price) ||
                price < 0)
            {
                MessageBox.Show(
                    "Please enter a valid unit price.");
                return false;
            }

            // Validate reorder level.
            if (!int.TryParse(txtReorderLevel.Text, out int reorderLevel) ||
                reorderLevel < 0)
            {
                MessageBox.Show(
                    "Reorder level must be zero or greater.");
                return false;
            }

            item = new Item
            {
                Code = txtCode.Text.Trim(),
                Name = txtName.Text.Trim(),
                Brand = txtBrand.Text.Trim(),
                Category = cmbCategory.SelectedValue?.ToString() ?? "",
                UnitPrice = price,
                ReorderLevel = reorderLevel
            };

            return true;
        }


        // 
        // 6. PRODUCT CRUD OPERATIONS
        // 

        // ADD PRODUCT
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!TryGetProductInput(out Item item))
                return;

            try
            {
                // The API generates the Item Code.
                var response = await _httpClient
                    .PostAsJsonAsync("api/items", item);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Product added successfully!");

                    await LoadItemsAsync();
                    ClearFields();
                }
                else
                {
                    string error = await response.Content
                        .ReadAsStringAsync();

                    MessageBox.Show(
                        "Failed to add product: " + error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // UPDATE PRODUCT
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show(
                    "Please select a product to update.");
                return;
            }

            if (!TryGetProductInput(out Item item))
                return;

            try
            {
                string code =
                    Uri.EscapeDataString(item.Code);

                var response = await _httpClient
                    .PutAsJsonAsync($"api/items/{code}", item);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Product updated successfully!");

                    await LoadItemsAsync();
                    ClearFields();
                }
                else
                {
                    string error = await response.Content
                        .ReadAsStringAsync();

                    MessageBox.Show(
                        "Failed to update product: " + error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // DELETE PRODUCT
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show(
                    "Please select a product to delete.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this product?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                string code = Uri.EscapeDataString(
                    txtCode.Text.Trim());

                var response = await _httpClient
                    .DeleteAsync($"api/items/{code}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Product deleted successfully!");

                    await LoadItemsAsync();
                    ClearFields();
                }
                else
                {
                    string error = await response.Content
                        .ReadAsStringAsync();

                    MessageBox.Show(
                        "Failed to delete product: " + error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // CLEAR PRODUCT BUTTON
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }


        // 
        // 7. PRODUCT TABLE EVENTS
        // 

        // SELECT PRODUCT FROM TABLE
        private void dgvItems_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgvItems.Rows[e.RowIndex];

            txtCode.Text =
                row.Cells["Code"].Value?.ToString();

            txtName.Text =
                row.Cells["Name"].Value?.ToString();

            txtBrand.Text =
                row.Cells["Brand"].Value?.ToString();

            cmbCategory.SelectedValue =
                row.Cells["Category"].Value?.ToString();

            txtPrice.Text =
                row.Cells["UnitPrice"].Value?.ToString();

            txtReorderLevel.Text =
                row.Cells["ReorderLevel"].Value?.ToString();
        }

        // UNUSED DATAGRIDVIEW EVENT
        private void dgvItems_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {
        }


        // 
        // 8. HELPER METHODS
        // 

        // RESET PRODUCT INPUT FIELDS
        private void ClearFields()
        {
            txtCode.Clear();
            txtName.Clear();
            txtBrand.Clear();
            cmbCategory.SelectedIndex = -1;
            txtPrice.Clear();

            txtReorderLevel.Text = "5";

            dgvItems.ClearSelection();
            txtName.Focus();
        }


        // 
        // 9. CATEGORY MANAGEMENT
        // 

        // LOAD CATEGORIES INTO DATAGRIDVIEW
        private async Task LoadCategoryTableAsync()
        {
            try
            {
                var categories = await _httpClient
                    .GetFromJsonAsync<List<Category>>("api/categories");

                dgvCategories.DataSource = null;
                dgvCategories.DataSource =
                    categories ?? new List<Category>();

                dgvCategories.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvCategories.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load category list: " + ex.Message,
                    "Category Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // 
        // 10. STOCK MANAGEMENT
        // 

        // LOAD PRODUCTS INTO STOCK DROPDOWN
        private async Task LoadStockProductsAsync()
        {
            try
            {
                var products = await _httpClient
                    .GetFromJsonAsync<List<Item>>("api/items");

                cmbStockProduct.DataSource = null;
                cmbStockProduct.DataSource =
                    products ?? new List<Item>();

                cmbStockProduct.DisplayMember = "Name";
                cmbStockProduct.ValueMember = "Code";
                cmbStockProduct.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load stock products: " + ex.Message,
                    "Stock Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // LOAD STOCK MOVEMENT HISTORY
        private async Task LoadStockHistoryAsync()
        {
            try
            {
                var movements = await _httpClient
                    .GetFromJsonAsync<List<StockMovement>>(
                        "api/stockmovements");

                dgvStockHistory.DataSource = null;
                dgvStockHistory.DataSource =
                    movements ?? new List<StockMovement>();

                dgvStockHistory.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvStockHistory.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load stock history: " + ex.Message,
                    "Stock Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // 
        // STOCK MOVEMENT OPERATIONS
        // 

        // SAVE STOCK IN / STOCK OUT
        private async void btnStockSave_Click(object sender, EventArgs e)
        {
            if (cmbStockProduct.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a product.");
                return;
            }

            if (cmbStockType.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a movement type.");
                return;
            }

            string itemCode =
                cmbStockProduct.SelectedValue?.ToString() ?? "";

            string movementType =
                cmbStockType.SelectedItem?.ToString() ?? "";

            int quantity = (int)numStockQuantity.Value;
            string reason = txtStockReason.Text.Trim();

            if (string.IsNullOrWhiteSpace(itemCode))
            {
                MessageBox.Show("Please select a valid product.");
                return;
            }

            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than zero.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Product: {cmbStockProduct.Text}\n" +
                $"Movement: {movementType}\n" +
                $"Quantity: {quantity}\n\n" +
                "Do you want to save this stock movement?",
                "Confirm Stock Movement",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var movement = new
                {
                    ItemCode = itemCode,
                    MovementType = movementType,
                    Quantity = quantity,
                    Reason = reason
                };

                btnStockSave.Enabled = false;

                var response = await _httpClient
                    .PostAsJsonAsync("api/stockmovements", movement);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Stock movement saved successfully!");

                    // Refresh stock history and product quantities.
                    await LoadStockHistoryAsync();
                    await LoadItemsAsync();

                    ClearStockFields();
                }
                else
                {
                    string error = await response.Content
                        .ReadAsStringAsync();

                    MessageBox.Show(
                        "Failed to save stock movement: " + error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Stock movement error: " + ex.Message);
            }
            finally
            {
                btnStockSave.Enabled = true;
            }
        }

        // CLEAR STOCK BUTTON
        private void btnStockClear_Click(object sender, EventArgs e)
        {
            ClearStockFields();
        }

        // RESET STOCK INPUT FIELDS
        private void ClearStockFields()
        {
            cmbStockProduct.SelectedIndex = -1;
            cmbStockType.SelectedIndex = -1;
            numStockQuantity.Value = 1;
            txtStockReason.Clear();

            cmbStockProduct.Focus();
        }

        // 
        // 11. SALES MANAGEMENT
        // 

        // LOAD PRODUCTS INTO SALES DROPDOWN
        private async Task LoadSalesProductsAsync()
        {
            try
            {
                var products = await _httpClient
                    .GetFromJsonAsync<List<Item>>("api/items");

                cmbSalesProduct.DataSource = null;
                cmbSalesProduct.DisplayMember = "Name";
                cmbSalesProduct.ValueMember = "Code";
                cmbSalesProduct.DataSource =
                    products ?? new List<Item>();

                cmbSalesProduct.SelectedIndex = -1;
                txtSalesUnitPrice.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load sales products: " + ex.Message,
                    "Sales Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // DISPLAY THE SELECTED PRODUCT'S PRICE
        private void cmbSalesProduct_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (cmbSalesProduct.SelectedItem is Item product)
            {
                txtSalesUnitPrice.Text =
                    $"₱{product.UnitPrice:N2}";
            }
            else
            {
                txtSalesUnitPrice.Clear();
            }
        }


        // ==========================================
        // SALES SHOPPING CART
        // ==========================================

        // ADD PRODUCT TO CART
        private void btnSalesAddItem_Click(object sender, EventArgs e)
        {
            if (cmbSalesProduct.SelectedItem is not Item product)
            {
                MessageBox.Show("Please select a product.");
                return;
            }

            int quantity = (int)numSalesQuantity.Value;

            // Check how many units are already in the cart.
            var existingItem = _saleCart.FirstOrDefault(
                x => x.ItemCode == product.Code);

            int quantityInCart = existingItem?.Quantity ?? 0;

            // Prevent adding more than available stock.
            if (quantity + quantityInCart > product.Quantity)
            {
                MessageBox.Show(
                    $"Insufficient stock!\n\n" +
                    $"Product: {product.Name}\n" +
                    $"Available Stock: {product.Quantity}\n" +
                    $"Already in Cart: {quantityInCart}",
                    "Stock Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // If product already exists, increase its quantity.
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _saleCart.Add(new SaleCartItem
                {
                    ItemCode = product.Code,
                    ProductName = product.Name,
                    Quantity = quantity,
                    UnitPrice = product.UnitPrice
                });
            }

            RefreshSaleCart();

            cmbSalesProduct.SelectedIndex = -1;
            numSalesQuantity.Value = 1;
            txtSalesUnitPrice.Clear();
        }


        // REMOVE SELECTED ITEM FROM CART
        private void btnSalesRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvSaleItems.CurrentRow?.DataBoundItem
                is not SaleCartItem selectedItem)
            {
                MessageBox.Show("Please select an item to remove.");
                return;
            }

            _saleCart.Remove(selectedItem);

            RefreshSaleCart();
        }


        // CLEAR ENTIRE SALE
        private void btnSalesClear_Click(object sender, EventArgs e)
        {
            if (_saleCart.Count == 0)
                return;

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to clear the entire sale?",
                "Clear Sale",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            _saleCart.Clear();

            RefreshSaleCart();

            cmbSalesProduct.SelectedIndex = -1;
            numSalesQuantity.Value = 1;
            txtSalesUnitPrice.Clear();
        }


        // REFRESH CART TABLE AND TOTAL
        private void RefreshSaleCart()
        {
            dgvSaleItems.DataSource = null;

            dgvSaleItems.DataSource = _saleCart.ToList();

            dgvSaleItems.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvSaleItems.ClearSelection();
            dgvSaleItems.CurrentCell = null;

            decimal total = _saleCart.Sum(x => x.Subtotal);

            lblSalesTotalValue.Text = $"₱{total:N2}";
        }


        // ==========================================
        // COMPLETE SALES TRANSACTION
        // ==========================================

        private async void btnSalesComplete_Click(
            object sender, EventArgs e)
        {
            if (_saleCart.Count == 0)
            {
                MessageBox.Show(
                    "Please add at least one product to the sale.");
                return;
            }

            decimal total = _saleCart.Sum(x => x.Subtotal);

            DialogResult confirm = MessageBox.Show(
                $"Total Amount: ₱{total:N2}\n\n" +
                "Are you sure you want to complete this sale?",
                "Confirm Sale",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                btnSalesComplete.Enabled = false;

                var saleRequest = new
                {
                    Items = _saleCart.Select(item => new
                    {
                        ItemCode = item.ItemCode,
                        Quantity = item.Quantity
                    }).ToList()
                };

                var response = await _httpClient
                    .PostAsJsonAsync("api/sales", saleRequest);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Sale completed successfully!",
                        "Sales Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Clear the cart after successful sale.
                    _saleCart.Clear();
                    RefreshSaleCart();

                    // Refresh inventory and dashboard data.
                    await LoadItemsAsync();
                    await LoadSalesProductsAsync();
                    await LoadDashboardAsync();

                    await LoadSalesHistoryAsync();
                }
                else
                {
                    string error = await response.Content
                        .ReadAsStringAsync();

                    MessageBox.Show(
                        "Failed to complete sale: " + error,
                        "Sales Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Sales transaction error: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnSalesComplete.Enabled = true;
            }
        }


        // 
        // LOAD SALES HISTORY
        // 

        private async Task LoadSalesHistoryAsync()
        {
            try
            {
                var sales = await _httpClient
                    .GetFromJsonAsync<List<SaleHistory>>("api/sales");

                dgvSalesHistory.DataSource = null;
                dgvSalesHistory.DataSource =
                    sales ?? new List<SaleHistory>();

                dgvSalesHistory.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvSalesHistory.Columns["SaleId"].HeaderText =
                    "Sale ID";

                dgvSalesHistory.Columns["SaleDate"].HeaderText =
                    "Date & Time";

                dgvSalesHistory.Columns["TotalAmount"].HeaderText =
                    "Total Amount";

                dgvSalesHistory.Columns["TotalAmount"]
                    .DefaultCellStyle.Format = "₱#,##0.00";

                dgvSalesHistory.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load sales history: " + ex.Message,
                    "Sales Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // 
        // 12. REPORTS MANAGEMENT
        // 

        private async Task LoadReportAsync()
        {
            string? reportType =
                cmbReportType.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(reportType))
                return;

            try
            {
                btnReportRefresh.Enabled = false;

                string endpoint = reportType switch
                {
                    "Inventory Report" => "api/items",
                    "Sales Report" => "api/sales",
                    "Stock Movement Report" => "api/stockmovements",
                    "Low-Stock Report" => "api/lowstock",
                    _ => ""
                };

                if (string.IsNullOrEmpty(endpoint))
                    return;

                // Retrieve report data from the API.
                var response = await _httpClient.GetAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Failed to load report: " +
                        await response.Content.ReadAsStringAsync());
                    return;
                }

                string json = await response.Content.ReadAsStringAsync();

                // Convert the JSON array into a table.
                var records = System.Text.Json.JsonSerializer
                    .Deserialize<List<Dictionary<string,
                        System.Text.Json.JsonElement>>>(json);

                var table = new System.Data.DataTable();

                if (records != null && records.Count > 0)
                {
                    // Create columns based on API response.
                    foreach (string key in records[0].Keys)
                    {
                        table.Columns.Add(key);
                    }

                    // Add report rows.
                    foreach (var record in records)
                    {
                        var row = table.NewRow();

                        foreach (var field in record)
                        {
                            row[field.Key] = field.Value.ToString();
                        }

                        table.Rows.Add(row);
                    }
                }

                dgvReports.AutoGenerateColumns = true;
                dgvReports.DataSource = null;
                dgvReports.Columns.Clear();
                dgvReports.DataSource = table;

                dgvReports.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvReports.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Report error: " + ex.Message,
                    "Reports Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnReportRefresh.Enabled = true;
            }
        }


        private async void cmbReportType_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            await LoadReportAsync();
        }


        private async void btnReportRefresh_Click(
            object sender, EventArgs e)
        {
            await LoadReportAsync();
        }




        // ==========================================
        // EXPORT REPORT TO CSV
        // ==========================================

        private void btnReportExport_Click(
            object sender, EventArgs e)
        {
            if (dgvReports.Rows.Count == 0)
            {
                MessageBox.Show(
                    "There is no report data to export.",
                    "Export CSV",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string reportName =
                cmbReportType.SelectedItem?.ToString()
                ?? "Report";

            string fileName =
                reportName.Replace(" ", "_") +
                "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") +
                ".csv";

            using SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Filter = "CSV Files (*.csv)|*.csv";
            saveDialog.FileName = fileName;
            saveDialog.Title = "Export StockFlow Report";

            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using var writer = new StreamWriter(
                    saveDialog.FileName,
                    false,
                    new System.Text.UTF8Encoding(true));

                // Write column headers.
                var headers = dgvReports.Columns
                    .Cast<DataGridViewColumn>()
                    .Where(c => c.Visible)
                    .OrderBy(c => c.DisplayIndex)
                    .Select(c => EscapeCsv(c.HeaderText));

                writer.WriteLine(string.Join(",", headers));

                // Write report rows.
                foreach (DataGridViewRow row in dgvReports.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    var values = dgvReports.Columns
                        .Cast<DataGridViewColumn>()
                        .Where(c => c.Visible)
                        .OrderBy(c => c.DisplayIndex)
                        .Select(c => EscapeCsv(
                            row.Cells[c.Index].Value?.ToString()
                            ?? ""));

                    writer.WriteLine(string.Join(",", values));
                }

                MessageBox.Show(
                    "Report exported successfully!\n\n" +
                    saveDialog.FileName,
                    "Export Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to export report: " + ex.Message,
                    "Export Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Escape special characters for CSV format.
        private string EscapeCsv(string value)
        {
            if (value.Contains(',') ||
                value.Contains('"') ||
                value.Contains('\n') ||
                value.Contains('\r'))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }

            return value;
        }






    }
}
