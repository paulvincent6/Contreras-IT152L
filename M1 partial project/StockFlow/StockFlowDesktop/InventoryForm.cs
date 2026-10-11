using System.Net.Http;
using System.Net.Http.Json;

namespace StockFlowDesktop
{
    public partial class InventoryForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7031/")
        };

        public InventoryForm()
        {
            InitializeComponent();
        }

        private async Task LoadItemsAsync()
        {
            try
            {
                var items = await _httpClient.GetFromJsonAsync<List<Item>>("api/items");

                dgvItems.DataSource = null;
                dgvItems.DataSource = items ?? new List<Item>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load inventory: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private async void InventoryForm_Load(object sender, EventArgs e)
        {
            await LoadItemsAsync();
        }


        private async void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(txtCode.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtBrand.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid unit price.");
                return;
            }

            // Create item object
            var item = new Item
            {
                Code = txtCode.Text.Trim(),
                Name = txtName.Text.Trim(),
                Brand = txtBrand.Text.Trim(),
                UnitPrice = price
            };

            try
            {
                // Send item to API
                var response = await _httpClient.PostAsJsonAsync("api/items", item);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Item added successfully!");

                    // Refresh inventory table
                    await LoadItemsAsync();

                    // Clear input fields
                    txtCode.Clear();
                    txtName.Clear();
                    txtBrand.Clear();
                    txtPrice.Clear();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Failed to add item: " + error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore header clicks
            if (e.RowIndex < 0)
                return;

            // Get the selected row
            DataGridViewRow row = dgvItems.Rows[e.RowIndex];

            // Fill textboxes with selected product
            txtCode.Text = row.Cells["Code"].Value?.ToString();
            txtName.Text = row.Cells["Name"].Value?.ToString();
            txtBrand.Text = row.Cells["Brand"].Value?.ToString();
            txtPrice.Text = row.Cells["UnitPrice"].Value?.ToString();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(txtCode.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtBrand.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Validate unit price
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid unit price.");
                return;
            }

            // Create updated item object
            var item = new Item
            {
                Code = txtCode.Text.Trim(),
                Name = txtName.Text.Trim(),
                Brand = txtBrand.Text.Trim(),
                UnitPrice = price
            };

            try
            {
                // Send PUT request to API
                var response = await _httpClient.PutAsJsonAsync(
                    $"api/items/{Uri.EscapeDataString(item.Code)}", item);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Item updated successfully!");

                    // Refresh inventory
                    await LoadItemsAsync();

                    // Clear input fields
                    txtCode.Clear();
                    txtName.Clear();
                    txtBrand.Clear();
                    txtPrice.Clear();
                }
                else
                {
                    MessageBox.Show(
                        "Failed to update item: " + await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private async void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Please select an item to delete.");
                return;
            }

            // Ask for confirmation
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this item?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                // Send DELETE request to API
                string code = Uri.EscapeDataString(txtCode.Text.Trim());

                var response = await _httpClient.DeleteAsync(
                    $"api/items/{code}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Item deleted successfully!");

                    // Refresh inventory table
                    await LoadItemsAsync();

                    // Clear input fields
                    txtCode.Clear();
                    txtName.Clear();
                    txtBrand.Clear();
                    txtPrice.Clear();
                }
                else
                {
                    MessageBox.Show(
                        "Failed to delete item: " +
                        await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCode.Clear();
            txtName.Clear();
            txtBrand.Clear();
            txtPrice.Clear();

            dgvItems.ClearSelection();
            txtCode.Focus();
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}