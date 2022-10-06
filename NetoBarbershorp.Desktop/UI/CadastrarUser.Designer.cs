namespace NetoBarbershorp.Desktop.UI
{
    partial class CadastrarUser
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
            this.label_nome = new System.Windows.Forms.Label();
            this.textBox_nome = new System.Windows.Forms.TextBox();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.label_email = new System.Windows.Forms.Label();
            this.textBox_senha = new System.Windows.Forms.TextBox();
            this.label_senha = new System.Windows.Forms.Label();
            this.textBox_confirsenha = new System.Windows.Forms.TextBox();
            this.label_confirsenha = new System.Windows.Forms.Label();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.button_cadastrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_nome
            // 
            this.label_nome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_nome.AutoSize = true;
            this.label_nome.Location = new System.Drawing.Point(43, 35);
            this.label_nome.Name = "label_nome";
            this.label_nome.Size = new System.Drawing.Size(77, 29);
            this.label_nome.TabIndex = 0;
            this.label_nome.Text = "Nome";
            // 
            // textBox_nome
            // 
            this.textBox_nome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_nome.Location = new System.Drawing.Point(43, 78);
            this.textBox_nome.Name = "textBox_nome";
            this.textBox_nome.Size = new System.Drawing.Size(408, 35);
            this.textBox_nome.TabIndex = 1;
            // 
            // textBox_email
            // 
            this.textBox_email.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_email.Location = new System.Drawing.Point(43, 158);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(408, 35);
            this.textBox_email.TabIndex = 3;
            // 
            // label_email
            // 
            this.label_email.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_email.AutoSize = true;
            this.label_email.Location = new System.Drawing.Point(43, 126);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(76, 29);
            this.label_email.TabIndex = 2;
            this.label_email.Text = "Email";
            // 
            // textBox_senha
            // 
            this.textBox_senha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_senha.Location = new System.Drawing.Point(43, 243);
            this.textBox_senha.Name = "textBox_senha";
            this.textBox_senha.Size = new System.Drawing.Size(332, 35);
            this.textBox_senha.TabIndex = 5;
            // 
            // label_senha
            // 
            this.label_senha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_senha.AutoSize = true;
            this.label_senha.Location = new System.Drawing.Point(43, 211);
            this.label_senha.Name = "label_senha";
            this.label_senha.Size = new System.Drawing.Size(78, 29);
            this.label_senha.TabIndex = 4;
            this.label_senha.Text = "Senha";
            // 
            // textBox_confirsenha
            // 
            this.textBox_confirsenha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_confirsenha.Location = new System.Drawing.Point(43, 326);
            this.textBox_confirsenha.Name = "textBox_confirsenha";
            this.textBox_confirsenha.Size = new System.Drawing.Size(332, 35);
            this.textBox_confirsenha.TabIndex = 7;
            // 
            // label_confirsenha
            // 
            this.label_confirsenha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_confirsenha.AutoSize = true;
            this.label_confirsenha.Location = new System.Drawing.Point(43, 294);
            this.label_confirsenha.Name = "label_confirsenha";
            this.label_confirsenha.Size = new System.Drawing.Size(202, 29);
            this.label_confirsenha.TabIndex = 6;
            this.label_confirsenha.Text = "Confirme a Senha";
            // 
            // button_cancelar
            // 
            this.button_cancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_cancelar.Location = new System.Drawing.Point(43, 381);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(163, 55);
            this.button_cancelar.TabIndex = 8;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // button_cadastrar
            // 
            this.button_cadastrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_cadastrar.Location = new System.Drawing.Point(288, 381);
            this.button_cadastrar.Name = "button_cadastrar";
            this.button_cadastrar.Size = new System.Drawing.Size(163, 55);
            this.button_cadastrar.TabIndex = 9;
            this.button_cadastrar.Text = "Cadastrar";
            this.button_cadastrar.UseVisualStyleBackColor = true;
            this.button_cadastrar.Click += new System.EventHandler(this.button_cadastrar_Click);
            // 
            // CadastrarUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(504, 460);
            this.Controls.Add(this.button_cadastrar);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.textBox_confirsenha);
            this.Controls.Add(this.label_confirsenha);
            this.Controls.Add(this.textBox_senha);
            this.Controls.Add(this.label_senha);
            this.Controls.Add(this.textBox_email);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.textBox_nome);
            this.Controls.Add(this.label_nome);
            this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CadastrarUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_nome;
        private System.Windows.Forms.TextBox textBox_nome;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.TextBox textBox_senha;
        private System.Windows.Forms.Label label_senha;
        private System.Windows.Forms.TextBox textBox_confirsenha;
        private System.Windows.Forms.Label label_confirsenha;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.Button button_cadastrar;
    }
}