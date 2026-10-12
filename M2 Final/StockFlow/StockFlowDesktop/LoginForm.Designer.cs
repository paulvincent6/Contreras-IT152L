namespace StockFlowDesktop
{
    partial class LoginForm
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
            lblLoginTitle = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // lblLoginTitle
            // 
            lblLoginTitle.AutoSize = true;
            lblLoginTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLoginTitle.Location = new Point(97, 24);
            lblLoginTitle.Name = "lblLoginTitle";
            lblLoginTitle.Size = new Size(176, 30);
            lblLoginTitle.TabIndex = 0;
            lblLoginTitle.Text = "StockFlow Login";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(50, 72);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(84, 21);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(50, 147);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(79, 21);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(50, 110);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(280, 23);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(50, 180);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(280, 23);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(50, 230);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(280, 38);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(384, 291);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblLoginTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StockFlow - Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLoginTitle;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
    }
}