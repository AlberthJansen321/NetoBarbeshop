namespace NetoBarbershorp.Desktop.UI
{
    partial class UpdateServiceDone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateServiceDone));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_nomecliente = new System.Windows.Forms.TextBox();
            this.dateTimePicker_data = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_desconto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_gojeta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_valortotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_cadastrar = new System.Windows.Forms.Button();
            this.checkedListBox_services = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_produtos = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.button_update = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.textBox_quantidade = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome do Cliente";
            // 
            // textBox_nomecliente
            // 
            this.textBox_nomecliente.Location = new System.Drawing.Point(12, 47);
            this.textBox_nomecliente.Name = "textBox_nomecliente";
            this.textBox_nomecliente.Size = new System.Drawing.Size(262, 35);
            this.textBox_nomecliente.TabIndex = 1;
            // 
            // dateTimePicker_data
            // 
            this.dateTimePicker_data.CustomFormat = "dd/MM/yyyy, HH:mm";
            this.dateTimePicker_data.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_data.Location = new System.Drawing.Point(285, 47);
            this.dateTimePicker_data.Name = "dateTimePicker_data";
            this.dateTimePicker_data.Size = new System.Drawing.Size(287, 35);
            this.dateTimePicker_data.TabIndex = 5;
            this.dateTimePicker_data.Value = new System.DateTime(2022, 9, 25, 16, 44, 0, 0);
            this.dateTimePicker_data.ValueChanged += new System.EventHandler(this.dateTimePicker_data_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Data";
            // 
            // textBox_desconto
            // 
            this.textBox_desconto.Location = new System.Drawing.Point(766, 47);
            this.textBox_desconto.Name = "textBox_desconto";
            this.textBox_desconto.Size = new System.Drawing.Size(201, 35);
            this.textBox_desconto.TabIndex = 26;
            this.textBox_desconto.TextChanged += new System.EventHandler(this.textBox_desconto_TextChanged);
            this.textBox_desconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_desconto_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(776, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 29);
            this.label7.TabIndex = 25;
            this.label7.Text = "Desconto";
            // 
            // textBox_gojeta
            // 
            this.textBox_gojeta.Location = new System.Drawing.Point(973, 47);
            this.textBox_gojeta.Name = "textBox_gojeta";
            this.textBox_gojeta.Size = new System.Drawing.Size(132, 35);
            this.textBox_gojeta.TabIndex = 24;
            this.textBox_gojeta.TextChanged += new System.EventHandler(this.textBox_gojeta_TextChanged);
            this.textBox_gojeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_gojeta_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(973, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 29);
            this.label6.TabIndex = 23;
            this.label6.Text = "Gojeta";
            // 
            // textBox_valortotal
            // 
            this.textBox_valortotal.Enabled = false;
            this.textBox_valortotal.Location = new System.Drawing.Point(578, 47);
            this.textBox_valortotal.Name = "textBox_valortotal";
            this.textBox_valortotal.Size = new System.Drawing.Size(182, 35);
            this.textBox_valortotal.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(578, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 29);
            this.label5.TabIndex = 21;
            this.label5.Text = "Valor Total";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 528);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 46);
            this.button1.TabIndex = 28;
            this.button1.Text = "Voltar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_cadastrar
            // 
            this.button_cadastrar.Location = new System.Drawing.Point(163, 528);
            this.button_cadastrar.Name = "button_cadastrar";
            this.button_cadastrar.Size = new System.Drawing.Size(202, 46);
            this.button_cadastrar.TabIndex = 27;
            this.button_cadastrar.Text = "Salvar";
            this.button_cadastrar.UseVisualStyleBackColor = true;
            this.button_cadastrar.Click += new System.EventHandler(this.button_cadastrar_Click);
            // 
            // checkedListBox_services
            // 
            this.checkedListBox_services.BackColor = System.Drawing.Color.Gray;
            this.checkedListBox_services.FormattingEnabled = true;
            this.checkedListBox_services.Location = new System.Drawing.Point(12, 122);
            this.checkedListBox_services.Name = "checkedListBox_services";
            this.checkedListBox_services.Size = new System.Drawing.Size(493, 388);
            this.checkedListBox_services.TabIndex = 29;
            this.checkedListBox_services.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox_services_ItemCheck);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 29);
            this.label3.TabIndex = 30;
            this.label3.Text = "Serviços";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(514, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 29);
            this.label4.TabIndex = 32;
            this.label4.Text = "Produtos";
            // 
            // comboBox_produtos
            // 
            this.comboBox_produtos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_produtos.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox_produtos.FormattingEnabled = true;
            this.comboBox_produtos.Location = new System.Drawing.Point(514, 125);
            this.comboBox_produtos.Name = "comboBox_produtos";
            this.comboBox_produtos.Size = new System.Drawing.Size(293, 32);
            this.comboBox_produtos.TabIndex = 33;
            this.comboBox_produtos.SelectedIndexChanged += new System.EventHandler(this.comboBox_produtos_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(514, 165);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 345);
            this.panel1.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(813, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 29);
            this.label8.TabIndex = 37;
            this.label8.Text = "Qtd";
            // 
            // button_update
            // 
            this.button_update.BackColor = System.Drawing.Color.White;
            this.button_update.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_update.BackgroundImage")));
            this.button_update.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_update.Location = new System.Drawing.Point(1001, 115);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(48, 46);
            this.button_update.TabIndex = 39;
            this.button_update.UseVisualStyleBackColor = false;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // button_add
            // 
            this.button_add.BackColor = System.Drawing.Color.White;
            this.button_add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_add.BackgroundImage")));
            this.button_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_add.Location = new System.Drawing.Point(947, 115);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(48, 46);
            this.button_add.TabIndex = 41;
            this.button_add.UseVisualStyleBackColor = false;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.White;
            this.button_delete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_delete.BackgroundImage")));
            this.button_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_delete.Location = new System.Drawing.Point(1055, 115);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(48, 46);
            this.button_delete.TabIndex = 42;
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // textBox_quantidade
            // 
            this.textBox_quantidade.Location = new System.Drawing.Point(813, 124);
            this.textBox_quantidade.Name = "textBox_quantidade";
            this.textBox_quantidade.Size = new System.Drawing.Size(128, 35);
            this.textBox_quantidade.TabIndex = 43;
            this.textBox_quantidade.TextChanged += new System.EventHandler(this.textBox_quantidade_TextChanged);
            this.textBox_quantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_quantidade_KeyPress);
            // 
            // UpdateServiceDone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1117, 586);
            this.Controls.Add(this.textBox_quantidade);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBox_produtos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkedListBox_services);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_cadastrar);
            this.Controls.Add(this.textBox_desconto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_gojeta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_valortotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker_data);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_nomecliente);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateServiceDone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alterar";
            this.Load += new System.EventHandler(this.UpdateServiceDone_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_nomecliente;
        private System.Windows.Forms.DateTimePicker dateTimePicker_data;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_desconto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_gojeta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_valortotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_cadastrar;
        private System.Windows.Forms.CheckedListBox checkedListBox_services;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_produtos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.TextBox textBox_quantidade;
    }
}