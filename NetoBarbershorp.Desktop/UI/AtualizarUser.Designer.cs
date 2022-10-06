namespace NetoBarbershorp.Desktop.UI
{
    partial class AtualizarUser
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
            this.textBox_confirsenha = new System.Windows.Forms.TextBox();
            this.label_confirsenha = new System.Windows.Forms.Label();
            this.textBox_senha = new System.Windows.Forms.TextBox();
            this.label_senha = new System.Windows.Forms.Label();
            this.textBox_nome = new System.Windows.Forms.TextBox();
            this.label_nome = new System.Windows.Forms.Label();
            this.button_atualizar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_confirsenha
            // 
            this.textBox_confirsenha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_confirsenha.Location = new System.Drawing.Point(30, 258);
            this.textBox_confirsenha.Name = "textBox_confirsenha";
            this.textBox_confirsenha.Size = new System.Drawing.Size(332, 35);
            this.textBox_confirsenha.TabIndex = 15;
            // 
            // label_confirsenha
            // 
            this.label_confirsenha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_confirsenha.AutoSize = true;
            this.label_confirsenha.Location = new System.Drawing.Point(30, 226);
            this.label_confirsenha.Name = "label_confirsenha";
            this.label_confirsenha.Size = new System.Drawing.Size(202, 29);
            this.label_confirsenha.TabIndex = 14;
            this.label_confirsenha.Text = "Confirme a Senha";
            // 
            // textBox_senha
            // 
            this.textBox_senha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_senha.Location = new System.Drawing.Point(30, 175);
            this.textBox_senha.Name = "textBox_senha";
            this.textBox_senha.Size = new System.Drawing.Size(332, 35);
            this.textBox_senha.TabIndex = 13;
            // 
            // label_senha
            // 
            this.label_senha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_senha.AutoSize = true;
            this.label_senha.Location = new System.Drawing.Point(30, 143);
            this.label_senha.Name = "label_senha";
            this.label_senha.Size = new System.Drawing.Size(139, 29);
            this.label_senha.TabIndex = 12;
            this.label_senha.Text = "Nova Senha";
            // 
            // textBox_nome
            // 
            this.textBox_nome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_nome.Location = new System.Drawing.Point(30, 92);
            this.textBox_nome.Name = "textBox_nome";
            this.textBox_nome.Size = new System.Drawing.Size(408, 35);
            this.textBox_nome.TabIndex = 9;
            // 
            // label_nome
            // 
            this.label_nome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_nome.AutoSize = true;
            this.label_nome.Location = new System.Drawing.Point(30, 49);
            this.label_nome.Name = "label_nome";
            this.label_nome.Size = new System.Drawing.Size(77, 29);
            this.label_nome.TabIndex = 8;
            this.label_nome.Text = "Nome";
            // 
            // button_atualizar
            // 
            this.button_atualizar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_atualizar.Location = new System.Drawing.Point(275, 329);
            this.button_atualizar.Name = "button_atualizar";
            this.button_atualizar.Size = new System.Drawing.Size(163, 55);
            this.button_atualizar.TabIndex = 17;
            this.button_atualizar.Text = "Atualizar";
            this.button_atualizar.UseVisualStyleBackColor = true;
            this.button_atualizar.Click += new System.EventHandler(this.button_atualizar_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_cancelar.Location = new System.Drawing.Point(30, 329);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(163, 55);
            this.button_cancelar.TabIndex = 16;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // AtualizarUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(463, 437);
            this.Controls.Add(this.button_atualizar);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.textBox_confirsenha);
            this.Controls.Add(this.label_confirsenha);
            this.Controls.Add(this.textBox_senha);
            this.Controls.Add(this.label_senha);
            this.Controls.Add(this.textBox_nome);
            this.Controls.Add(this.label_nome);
            this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AtualizarUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atualizar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_confirsenha;
        private System.Windows.Forms.Label label_confirsenha;
        private System.Windows.Forms.TextBox textBox_senha;
        private System.Windows.Forms.Label label_senha;
        private System.Windows.Forms.TextBox textBox_nome;
        private System.Windows.Forms.Label label_nome;
        private System.Windows.Forms.Button button_atualizar;
        private System.Windows.Forms.Button button_cancelar;
    }
}