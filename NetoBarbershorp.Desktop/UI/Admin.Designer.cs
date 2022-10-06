namespace NetoBarbershorp.Desktop.UI
{
    partial class Admin
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatorioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_usuario = new System.Windows.Forms.ComboBox();
            this.button_pesquisar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_cliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_finalizado = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_final = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_cancelado = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_inicial = new System.Windows.Forms.DateTimePicker();
            this.label_bemvindo = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.button_finalizar = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.button_excluir = new System.Windows.Forms.Button();
            this.button_imprimir = new System.Windows.Forms.Button();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adaToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.servicesToolStripMenuItem,
            this.produtosToolStripMenuItem,
            this.relatorioToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1654, 37);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adaToolStripMenuItem
            // 
            this.adaToolStripMenuItem.Name = "adaToolStripMenuItem";
            this.adaToolStripMenuItem.Size = new System.Drawing.Size(160, 33);
            this.adaToolStripMenuItem.Text = "Meus Dados";
            this.adaToolStripMenuItem.Click += new System.EventHandler(this.adaToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(123, 33);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // servicesToolStripMenuItem
            // 
            this.servicesToolStripMenuItem.Name = "servicesToolStripMenuItem";
            this.servicesToolStripMenuItem.Size = new System.Drawing.Size(117, 33);
            this.servicesToolStripMenuItem.Text = "Serviços";
            this.servicesToolStripMenuItem.Click += new System.EventHandler(this.servicesToolStripMenuItem_Click);
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(126, 33);
            this.produtosToolStripMenuItem.Text = "Produtos";
            this.produtosToolStripMenuItem.Click += new System.EventHandler(this.produtosToolStripMenuItem_Click);
            // 
            // relatorioToolStripMenuItem
            // 
            this.relatorioToolStripMenuItem.Name = "relatorioToolStripMenuItem";
            this.relatorioToolStripMenuItem.Size = new System.Drawing.Size(128, 33);
            this.relatorioToolStripMenuItem.Text = "Relatório";
            this.relatorioToolStripMenuItem.Click += new System.EventHandler(this.relatorioToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.comboBox_usuario);
            this.panel1.Controls.Add(this.button_pesquisar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBox_cliente);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBox_finalizado);
            this.panel1.Controls.Add(this.dateTimePicker_final);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBox_cancelado);
            this.panel1.Controls.Add(this.dateTimePicker_inicial);
            this.panel1.Controls.Add(this.label_bemvindo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1654, 210);
            this.panel1.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(85, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 29);
            this.label7.TabIndex = 71;
            this.label7.Text = "Usuario";
            // 
            // comboBox_usuario
            // 
            this.comboBox_usuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox_usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_usuario.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox_usuario.FormattingEnabled = true;
            this.comboBox_usuario.Location = new System.Drawing.Point(85, 117);
            this.comboBox_usuario.Name = "comboBox_usuario";
            this.comboBox_usuario.Size = new System.Drawing.Size(352, 37);
            this.comboBox_usuario.TabIndex = 70;
            this.comboBox_usuario.SelectedIndexChanged += new System.EventHandler(this.comboBox_usuario_SelectedIndexChanged);
            // 
            // button_pesquisar
            // 
            this.button_pesquisar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_pesquisar.Location = new System.Drawing.Point(1415, 109);
            this.button_pesquisar.Name = "button_pesquisar";
            this.button_pesquisar.Size = new System.Drawing.Size(149, 55);
            this.button_pesquisar.TabIndex = 68;
            this.button_pesquisar.Text = "Pesquisar";
            this.button_pesquisar.UseVisualStyleBackColor = true;
            this.button_pesquisar.Click += new System.EventHandler(this.button_pesquisar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(459, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 29);
            this.label1.TabIndex = 58;
            this.label1.Text = "Cliente";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(85, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(410, 29);
            this.label6.TabIndex = 69;
            this.label6.Text = "Valor Total dos Serviços Finalizados: ";
            // 
            // textBox_cliente
            // 
            this.textBox_cliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_cliente.Location = new System.Drawing.Point(459, 119);
            this.textBox_cliente.Name = "textBox_cliente";
            this.textBox_cliente.Size = new System.Drawing.Size(272, 35);
            this.textBox_cliente.TabIndex = 59;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(758, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 29);
            this.label2.TabIndex = 60;
            this.label2.Text = "Finalizado";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1221, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 29);
            this.label5.TabIndex = 67;
            this.label5.Text = "Data Final  ";
            // 
            // comboBox_finalizado
            // 
            this.comboBox_finalizado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox_finalizado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_finalizado.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox_finalizado.FormattingEnabled = true;
            this.comboBox_finalizado.Items.AddRange(new object[] {
            "Sim",
            "Não"});
            this.comboBox_finalizado.Location = new System.Drawing.Point(758, 119);
            this.comboBox_finalizado.Name = "comboBox_finalizado";
            this.comboBox_finalizado.Size = new System.Drawing.Size(117, 37);
            this.comboBox_finalizado.TabIndex = 61;
            this.comboBox_finalizado.SelectedIndexChanged += new System.EventHandler(this.comboBox_finalizado_SelectedIndexChanged);
            // 
            // dateTimePicker_final
            // 
            this.dateTimePicker_final.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker_final.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker_final.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_final.Location = new System.Drawing.Point(1225, 121);
            this.dateTimePicker_final.Name = "dateTimePicker_final";
            this.dateTimePicker_final.Size = new System.Drawing.Size(174, 35);
            this.dateTimePicker_final.TabIndex = 66;
            this.dateTimePicker_final.ValueChanged += new System.EventHandler(this.dateTimePicker_final_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(895, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 29);
            this.label3.TabIndex = 62;
            this.label3.Text = "Cancelado";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1026, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 29);
            this.label4.TabIndex = 65;
            this.label4.Text = "Data Inicial";
            // 
            // comboBox_cancelado
            // 
            this.comboBox_cancelado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox_cancelado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_cancelado.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox_cancelado.FormattingEnabled = true;
            this.comboBox_cancelado.Items.AddRange(new object[] {
            "Sim",
            "Não"});
            this.comboBox_cancelado.Location = new System.Drawing.Point(895, 119);
            this.comboBox_cancelado.Name = "comboBox_cancelado";
            this.comboBox_cancelado.Size = new System.Drawing.Size(117, 37);
            this.comboBox_cancelado.TabIndex = 63;
            this.comboBox_cancelado.SelectedIndexChanged += new System.EventHandler(this.comboBox_cancelado_SelectedIndexChanged);
            // 
            // dateTimePicker_inicial
            // 
            this.dateTimePicker_inicial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker_inicial.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker_inicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_inicial.Location = new System.Drawing.Point(1030, 121);
            this.dateTimePicker_inicial.Name = "dateTimePicker_inicial";
            this.dateTimePicker_inicial.Size = new System.Drawing.Size(174, 35);
            this.dateTimePicker_inicial.TabIndex = 64;
            this.dateTimePicker_inicial.ValueChanged += new System.EventHandler(this.dateTimePicker_inicial_ValueChanged);
            // 
            // label_bemvindo
            // 
            this.label_bemvindo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_bemvindo.AutoSize = true;
            this.label_bemvindo.Location = new System.Drawing.Point(533, 14);
            this.label_bemvindo.Name = "label_bemvindo";
            this.label_bemvindo.Size = new System.Drawing.Size(0, 29);
            this.label_bemvindo.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(0, 247);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1654, 4);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Controls.Add(this.button_cancelar);
            this.panel2.Controls.Add(this.button_finalizar);
            this.panel2.Controls.Add(this.button_add);
            this.panel2.Controls.Add(this.button_excluir);
            this.panel2.Controls.Add(this.button_imprimir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 820);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1654, 80);
            this.panel2.TabIndex = 4;
            // 
            // button_cancelar
            // 
            this.button_cancelar.Enabled = false;
            this.button_cancelar.Location = new System.Drawing.Point(632, 13);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(149, 55);
            this.button_cancelar.TabIndex = 77;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // button_finalizar
            // 
            this.button_finalizar.Enabled = false;
            this.button_finalizar.Location = new System.Drawing.Point(477, 13);
            this.button_finalizar.Name = "button_finalizar";
            this.button_finalizar.Size = new System.Drawing.Size(149, 55);
            this.button_finalizar.TabIndex = 76;
            this.button_finalizar.Text = "Finalizar";
            this.button_finalizar.UseVisualStyleBackColor = true;
            this.button_finalizar.Click += new System.EventHandler(this.button_finalizar_Click);
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(167, 13);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(149, 55);
            this.button_add.TabIndex = 75;
            this.button_add.Text = "Adicionar";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_excluir
            // 
            this.button_excluir.Location = new System.Drawing.Point(322, 13);
            this.button_excluir.Name = "button_excluir";
            this.button_excluir.Size = new System.Drawing.Size(149, 55);
            this.button_excluir.TabIndex = 73;
            this.button_excluir.Text = "Excluir";
            this.button_excluir.UseVisualStyleBackColor = true;
            this.button_excluir.Click += new System.EventHandler(this.button_excluir_Click);
            // 
            // button_imprimir
            // 
            this.button_imprimir.Location = new System.Drawing.Point(12, 13);
            this.button_imprimir.Name = "button_imprimir";
            this.button_imprimir.Size = new System.Drawing.Size(149, 55);
            this.button_imprimir.TabIndex = 72;
            this.button_imprimir.Text = "Imprimir";
            this.button_imprimir.UseVisualStyleBackColor = true;
            this.button_imprimir.Click += new System.EventHandler(this.button_imprimir_Click);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Enabled = false;
            this.splitter2.Location = new System.Drawing.Point(0, 816);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1654, 4);
            this.splitter2.TabIndex = 5;
            this.splitter2.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DimGray;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 251);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1654, 565);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(71, 33);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1654, 900);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatorioToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_bemvindo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_usuario;
        private System.Windows.Forms.Button button_pesquisar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_cliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_finalizado;
        private System.Windows.Forms.DateTimePicker dateTimePicker_final;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_cancelado;
        private System.Windows.Forms.DateTimePicker dateTimePicker_inicial;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_imprimir;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_excluir;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_finalizar;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.ToolStripMenuItem servicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
    }
}