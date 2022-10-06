namespace NetoBarbershorp.Desktop.UI
{
    partial class Usuarios
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
            this.button_pesquisa = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_pesquisa = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_cadastrar = new System.Windows.Forms.Button();
            this.button_alterar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_exluir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_pesquisa
            // 
            this.button_pesquisa.Location = new System.Drawing.Point(321, 37);
            this.button_pesquisa.Name = "button_pesquisa";
            this.button_pesquisa.Size = new System.Drawing.Size(162, 60);
            this.button_pesquisa.TabIndex = 88;
            this.button_pesquisa.Text = "Pesquisa";
            this.button_pesquisa.UseVisualStyleBackColor = true;
            this.button_pesquisa.Click += new System.EventHandler(this.button_pesquisa_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 29);
            this.label4.TabIndex = 85;
            this.label4.Text = "Nome/Email";
            // 
            // textBox_pesquisa
            // 
            this.textBox_pesquisa.Location = new System.Drawing.Point(22, 50);
            this.textBox_pesquisa.Name = "textBox_pesquisa";
            this.textBox_pesquisa.PlaceholderText = "Digite o nome ou email";
            this.textBox_pesquisa.Size = new System.Drawing.Size(283, 35);
            this.textBox_pesquisa.TabIndex = 84;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(22, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 395);
            this.panel1.TabIndex = 82;
            //this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button_cadastrar
            // 
            this.button_cadastrar.Location = new System.Drawing.Point(421, 539);
            this.button_cadastrar.Name = "button_cadastrar";
            this.button_cadastrar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_cadastrar.Size = new System.Drawing.Size(204, 60);
            this.button_cadastrar.TabIndex = 81;
            this.button_cadastrar.Text = "Cadastrar";
            this.button_cadastrar.UseVisualStyleBackColor = true;
            this.button_cadastrar.Click += new System.EventHandler(this.button_cadastrar_Click);
            // 
            // button_alterar
            // 
            this.button_alterar.Enabled = false;
            this.button_alterar.Location = new System.Drawing.Point(22, 539);
            this.button_alterar.Name = "button_alterar";
            this.button_alterar.Size = new System.Drawing.Size(204, 60);
            this.button_alterar.TabIndex = 80;
            this.button_alterar.Text = "Resetar Senha";
            this.button_alterar.UseVisualStyleBackColor = true;
            this.button_alterar.Click += new System.EventHandler(this.button_alterar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 29);
            this.label1.TabIndex = 79;
            this.label1.Text = "Usuarios";
            // 
            // button_exluir
            // 
            this.button_exluir.Location = new System.Drawing.Point(232, 539);
            this.button_exluir.Name = "button_exluir";
            this.button_exluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_exluir.Size = new System.Drawing.Size(183, 60);
            this.button_exluir.TabIndex = 89;
            this.button_exluir.Text = "Excluir";
            this.button_exluir.UseVisualStyleBackColor = true;
            this.button_exluir.Click += new System.EventHandler(this.button_exluir_Click);
            // 
            // Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(649, 627);
            this.Controls.Add(this.button_exluir);
            this.Controls.Add(this.button_pesquisa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_pesquisa);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_cadastrar);
            this.Controls.Add(this.button_alterar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Usuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.Usuarios_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_pesquisa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_pesquisa;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_cadastrar;
        private System.Windows.Forms.Button button_alterar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_exluir;
    }
}