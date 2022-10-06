namespace NetoBarbershorp.Desktop.UI
{
    partial class CadastrarServicesDone
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
            this.textBox_cliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_data = new System.Windows.Forms.DateTimePicker();
            this.checkedListBox_services = new System.Windows.Forms.CheckedListBox();
            this.button_cadastrar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_usuario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_valor = new System.Windows.Forms.TextBox();
            this.textBox_gojeta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_desconto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // textBox_cliente
            // 
            this.textBox_cliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_cliente.Location = new System.Drawing.Point(40, 140);
            this.textBox_cliente.Name = "textBox_cliente";
            this.textBox_cliente.Size = new System.Drawing.Size(404, 35);
            this.textBox_cliente.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data";
            // 
            // dateTimePicker_data
            // 
            this.dateTimePicker_data.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker_data.CustomFormat = "dd/MM/yyyy, HH:mm";
            this.dateTimePicker_data.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_data.Location = new System.Drawing.Point(40, 223);
            this.dateTimePicker_data.Name = "dateTimePicker_data";
            this.dateTimePicker_data.Size = new System.Drawing.Size(493, 35);
            this.dateTimePicker_data.TabIndex = 3;
            this.dateTimePicker_data.ValueChanged += new System.EventHandler(this.dateTimePicker_data_ValueChanged);
            // 
            // checkedListBox_services
            // 
            this.checkedListBox_services.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkedListBox_services.BackColor = System.Drawing.Color.Gray;
            this.checkedListBox_services.FormattingEnabled = true;
            this.checkedListBox_services.Location = new System.Drawing.Point(40, 304);
            this.checkedListBox_services.Name = "checkedListBox_services";
            this.checkedListBox_services.Size = new System.Drawing.Size(493, 228);
            this.checkedListBox_services.TabIndex = 8;
            this.checkedListBox_services.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // button_cadastrar
            // 
            this.button_cadastrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_cadastrar.Location = new System.Drawing.Point(331, 648);
            this.button_cadastrar.Name = "button_cadastrar";
            this.button_cadastrar.Size = new System.Drawing.Size(202, 46);
            this.button_cadastrar.TabIndex = 10;
            this.button_cadastrar.Text = "Cadastrar";
            this.button_cadastrar.UseVisualStyleBackColor = true;
            this.button_cadastrar.Click += new System.EventHandler(this.button_cadastrar_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(40, 648);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 46);
            this.button1.TabIndex = 11;
            this.button1.Text = "Voltar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 29);
            this.label3.TabIndex = 12;
            this.label3.Text = "Serviços";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 29);
            this.label4.TabIndex = 13;
            this.label4.Text = "Usuario";
            // 
            // textBox_usuario
            // 
            this.textBox_usuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_usuario.Enabled = false;
            this.textBox_usuario.Location = new System.Drawing.Point(40, 55);
            this.textBox_usuario.Name = "textBox_usuario";
            this.textBox_usuario.Size = new System.Drawing.Size(404, 35);
            this.textBox_usuario.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 565);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 29);
            this.label5.TabIndex = 15;
            this.label5.Text = "Valor Total";
            // 
            // textBox_valor
            // 
            this.textBox_valor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_valor.Enabled = false;
            this.textBox_valor.Location = new System.Drawing.Point(40, 597);
            this.textBox_valor.Name = "textBox_valor";
            this.textBox_valor.Size = new System.Drawing.Size(180, 35);
            this.textBox_valor.TabIndex = 16;
            // 
            // textBox_gojeta
            // 
            this.textBox_gojeta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_gojeta.Location = new System.Drawing.Point(401, 597);
            this.textBox_gojeta.Name = "textBox_gojeta";
            this.textBox_gojeta.Size = new System.Drawing.Size(132, 35);
            this.textBox_gojeta.TabIndex = 18;
            this.textBox_gojeta.TextChanged += new System.EventHandler(this.textBox_gojeta_TextChanged);
            this.textBox_gojeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_gojeta_KeyPress);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(401, 565);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 29);
            this.label6.TabIndex = 17;
            this.label6.Text = "Gojeta";
            // 
            // textBox_desconto
            // 
            this.textBox_desconto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_desconto.Location = new System.Drawing.Point(226, 597);
            this.textBox_desconto.Name = "textBox_desconto";
            this.textBox_desconto.Size = new System.Drawing.Size(169, 35);
            this.textBox_desconto.TabIndex = 20;
            this.textBox_desconto.TextChanged += new System.EventHandler(this.textBox_desconto_TextChanged);
            this.textBox_desconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_desconto_KeyPress);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(226, 565);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 29);
            this.label7.TabIndex = 19;
            this.label7.Text = "Desconto";
            // 
            // CadastrarServicesDone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(574, 706);
            this.Controls.Add(this.textBox_desconto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_gojeta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_valor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_usuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_cadastrar);
            this.Controls.Add(this.checkedListBox_services);
            this.Controls.Add(this.dateTimePicker_data);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_cliente);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CadastrarServicesDone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_cliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_data;
        private System.Windows.Forms.CheckedListBox checkedListBox_services;
        private System.Windows.Forms.Button button_cadastrar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_usuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_valor;
        private System.Windows.Forms.TextBox textBox_gojeta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_desconto;
        private System.Windows.Forms.Label label7;
    }
}