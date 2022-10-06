namespace NetoBarbershorp.Desktop.UI
{
    partial class Services
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
            this.label1 = new System.Windows.Forms.Label();
            this.button_alterar = new System.Windows.Forms.Button();
            this.button_cadastrar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_nome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_des_hab = new System.Windows.Forms.CheckBox();
            this.textBox_valor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_pesquisa = new System.Windows.Forms.TextBox();
            this.comboBox_habilitado = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_pesquisa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serviços";
            // 
            // button_alterar
            // 
            this.button_alterar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_alterar.Enabled = false;
            this.button_alterar.Location = new System.Drawing.Point(21, 625);
            this.button_alterar.Name = "button_alterar";
            this.button_alterar.Size = new System.Drawing.Size(204, 60);
            this.button_alterar.TabIndex = 3;
            this.button_alterar.Text = "Alterar";
            this.button_alterar.UseVisualStyleBackColor = true;
            this.button_alterar.Click += new System.EventHandler(this.button_alterar_Click);
            // 
            // button_cadastrar
            // 
            this.button_cadastrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_cadastrar.Location = new System.Drawing.Point(420, 625);
            this.button_cadastrar.Name = "button_cadastrar";
            this.button_cadastrar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_cadastrar.Size = new System.Drawing.Size(204, 60);
            this.button_cadastrar.TabIndex = 5;
            this.button_cadastrar.Text = "Adicionar";
            this.button_cadastrar.UseVisualStyleBackColor = true;
            this.button_cadastrar.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(21, 126);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 395);
            this.panel1.TabIndex = 6;
            // 
            // textBox_nome
            // 
            this.textBox_nome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_nome.Location = new System.Drawing.Point(21, 565);
            this.textBox_nome.Name = "textBox_nome";
            this.textBox_nome.PlaceholderText = "Digite o nome ";
            this.textBox_nome.Size = new System.Drawing.Size(204, 35);
            this.textBox_nome.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 524);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nome";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 524);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 29);
            this.label3.TabIndex = 12;
            this.label3.Text = "Valor";
            // 
            // checkBox_des_hab
            // 
            this.checkBox_des_hab.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox_des_hab.AutoSize = true;
            this.checkBox_des_hab.Location = new System.Drawing.Point(462, 567);
            this.checkBox_des_hab.Name = "checkBox_des_hab";
            this.checkBox_des_hab.Size = new System.Drawing.Size(135, 33);
            this.checkBox_des_hab.TabIndex = 13;
            this.checkBox_des_hab.Text = "Habilitar";
            this.checkBox_des_hab.UseVisualStyleBackColor = true;
            // 
            // textBox_valor
            // 
            this.textBox_valor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_valor.Location = new System.Drawing.Point(240, 567);
            this.textBox_valor.Name = "textBox_valor";
            this.textBox_valor.PlaceholderText = "Digite o valor";
            this.textBox_valor.Size = new System.Drawing.Size(204, 35);
            this.textBox_valor.TabIndex = 14;
            this.textBox_valor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_valor_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 29);
            this.label4.TabIndex = 16;
            this.label4.Text = "Nome";
            // 
            // textBox_pesquisa
            // 
            this.textBox_pesquisa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_pesquisa.Location = new System.Drawing.Point(21, 41);
            this.textBox_pesquisa.Name = "textBox_pesquisa";
            this.textBox_pesquisa.PlaceholderText = "Digite o nome ";
            this.textBox_pesquisa.Size = new System.Drawing.Size(204, 35);
            this.textBox_pesquisa.TabIndex = 15;
            // 
            // comboBox_habilitado
            // 
            this.comboBox_habilitado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox_habilitado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_habilitado.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox_habilitado.FormattingEnabled = true;
            this.comboBox_habilitado.Items.AddRange(new object[] {
            "Sim",
            "Não"});
            this.comboBox_habilitado.Location = new System.Drawing.Point(240, 40);
            this.comboBox_habilitado.Name = "comboBox_habilitado";
            this.comboBox_habilitado.Size = new System.Drawing.Size(204, 37);
            this.comboBox_habilitado.TabIndex = 62;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 29);
            this.label5.TabIndex = 63;
            this.label5.Text = "Habilitado";
            // 
            // button_pesquisa
            // 
            this.button_pesquisa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_pesquisa.Location = new System.Drawing.Point(462, 28);
            this.button_pesquisa.Name = "button_pesquisa";
            this.button_pesquisa.Size = new System.Drawing.Size(162, 60);
            this.button_pesquisa.TabIndex = 64;
            this.button_pesquisa.Text = "Pesquisa";
            this.button_pesquisa.UseVisualStyleBackColor = true;
            this.button_pesquisa.Click += new System.EventHandler(this.button_pesquisa_Click);
            // 
            // Services
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(649, 696);
            this.Controls.Add(this.button_pesquisa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_habilitado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_pesquisa);
            this.Controls.Add(this.textBox_valor);
            this.Controls.Add(this.checkBox_des_hab);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_nome);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_cadastrar);
            this.Controls.Add(this.button_alterar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Services";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serviços";
            this.Load += new System.EventHandler(this.Services_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_alterar;
        private System.Windows.Forms.Button button_cadastrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_nome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox_des_hab;
        private System.Windows.Forms.TextBox textBox_valor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_pesquisa;
        private System.Windows.Forms.ComboBox comboBox_habilitado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_pesquisa;
    }
}