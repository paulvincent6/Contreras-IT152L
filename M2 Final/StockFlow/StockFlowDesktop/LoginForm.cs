using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StockFlowDesktop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Please enter your username and password.",
                    "Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (username == "admin" && password == "admin123")
            {
                // Login successful
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Invalid username or password.",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtPassword.Clear();
                txtPassword.Focus();
            }
        }
    }
}
