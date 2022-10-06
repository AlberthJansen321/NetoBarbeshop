namespace NetoBarbershorp.Desktop.UI
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.label_email = new System.Windows.Forms.Label();
            this.button_entrar = new System.Windows.Forms.Button();
            this.label_senha = new System.Windows.Forms.Label();
            this.textBox_senha = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_email
            // 
            this.textBox_email.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_email.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_email.Location = new System.Drawing.Point(59, 72);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(334, 39);
            this.textBox_email.TabIndex = 0;
            // 
            // label_email
            // 
            this.label_email.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_email.AutoSize = true;
            this.label_email.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_email.Location = new System.Drawing.Point(59, 29);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(87, 32);
            this.label_email.TabIndex = 1;
            this.label_email.Text = "Email";
            // 
            // button_entrar
            // 
            this.button_entrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_entrar.BackColor = System.Drawing.Color.Gainsboro;
            this.button_entrar.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.button_entrar.FlatAppearance.BorderSize = 0;
            this.button_entrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.button_entrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.button_entrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_entrar.Location = new System.Drawing.Point(411, 72);
            this.button_entrar.Name = "button_entrar";
            this.button_entrar.Size = new System.Drawing.Size(144, 136);
            this.button_entrar.TabIndex = 2;
            this.button_entrar.Text = "Entrar";
            this.button_entrar.UseVisualStyleBackColor = false;
            this.button_entrar.Click += new System.EventHandler(this.button_entrar_Click);
            // 
            // label_senha
            // 
            this.label_senha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_senha.AutoSize = true;
            this.label_senha.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_senha.Location = new System.Drawing.Point(59, 126);
            this.label_senha.Name = "label_senha";
            this.label_senha.Size = new System.Drawing.Size(92, 32);
            this.label_senha.TabIndex = 4;
            this.label_senha.Text = "Senha";
            // 
            // textBox_senha
            // 
            this.textBox_senha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_senha.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_senha.Location = new System.Drawing.Point(59, 169);
            this.textBox_senha.Name = "textBox_senha";
            this.textBox_senha.PasswordChar = '*';
            this.textBox_senha.Size = new System.Drawing.Size(334, 39);
            this.textBox_senha.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(435, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(664, 264);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label_senha);
            this.Controls.Add(this.textBox_senha);
            this.Controls.Add(this.button_entrar);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.textBox_email);
            this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.Button button_entrar;
        private System.Windows.Forms.Label label_senha;
        private System.Windows.Forms.TextBox textBox_senha;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}