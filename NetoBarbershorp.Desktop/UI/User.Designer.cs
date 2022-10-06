namespace NetoBarbershorp.Desktop.UI
{
    partial class User
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
            this.cadastrarServiçosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.PerfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_bemvindo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_pesquisar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker_final = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker_inicial = new System.Windows.Forms.DateTimePicker();
            this.comboBox_cancelado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_finalizado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_cliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cadastrarServiçosToolStripMenuItem
            // 
            this.cadastrarServiçosToolStripMenuItem.Name = "cadastrarServiçosToolStripMenuItem";
            this.cadastrarServiçosToolStripMenuItem.Size = new System.Drawing.Size(226, 33);
            this.cadastrarServiçosToolStripMenuItem.Text = "Cadastrar Serviços";
            this.cadastrarServiçosToolStripMenuItem.Click += new System.EventHandler(this.cadastrarServiçosToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarServiçosToolStripMenuItem,
            this.PerfilToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1277, 37);
            this.menuStrip1.TabIndex = 31;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // PerfilToolStripMenuItem
            // 
            this.PerfilToolStripMenuItem.Name = "PerfilToolStripMenuItem";
            this.PerfilToolStripMenuItem.Size = new System.Drawing.Size(150, 33);
            this.PerfilToolStripMenuItem.Text = "Meu Dados";
            this.PerfilToolStripMenuItem.Click += new System.EventHandler(this.auToolStripMenuItem_Click);
            // 
            // label_bemvindo
            // 
            this.label_bemvindo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_bemvindo.AutoSize = true;
            this.label_bemvindo.Location = new System.Drawing.Point(421, 13);
            this.label_bemvindo.Name = "label_bemvindo";
            this.label_bemvindo.Size = new System.Drawing.Size(0, 29);
            this.label_bemvindo.TabIndex = 58;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(410, 29);
            this.label6.TabIndex = 57;
            this.label6.Text = "Valor Total dos Serviços Finalizados: ";
            // 
            // button_pesquisar
            // 
            this.button_pesquisar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_pesquisar.Location = new System.Drawing.Point(1040, 104);
            this.button_pesquisar.Name = "button_pesquisar";
            this.button_pesquisar.Size = new System.Drawing.Size(149, 55);
            this.button_pesquisar.TabIndex = 56;
            this.button_pesquisar.Text = "Pesquisar";
            this.button_pesquisar.UseVisualStyleBackColor = true;
            this.button_pesquisar.Click += new System.EventHandler(this.button_pesquisar_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(846, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 29);
            this.label5.TabIndex = 55;
            this.label5.Text = "Data Final  ";
            // 
            // dateTimePicker_final
            // 
            this.dateTimePicker_final.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker_final.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker_final.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_final.Location = new System.Drawing.Point(850, 116);
            this.dateTimePicker_final.Name = "dateTimePicker_final";
            this.dateTimePicker_final.Size = new System.Drawing.Size(174, 35);
            this.dateTimePicker_final.TabIndex = 54;
            this.dateTimePicker_final.ValueChanged += new System.EventHandler(this.dateTimePicker_final_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(651, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 29);
            this.label4.TabIndex = 53;
            this.label4.Text = "Data Inicial";
            // 
            // dateTimePicker_inicial
            // 
            this.dateTimePicker_inicial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker_inicial.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker_inicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_inicial.Location = new System.Drawing.Point(655, 116);
            this.dateTimePicker_inicial.Name = "dateTimePicker_inicial";
            this.dateTimePicker_inicial.Size = new System.Drawing.Size(174, 35);
            this.dateTimePicker_inicial.TabIndex = 52;
            this.dateTimePicker_inicial.ValueChanged += new System.EventHandler(this.dateTimePicker_inicial_ValueChanged);
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
            this.comboBox_cancelado.Location = new System.Drawing.Point(520, 114);
            this.comboBox_cancelado.Name = "comboBox_cancelado";
            this.comboBox_cancelado.Size = new System.Drawing.Size(117, 37);
            this.comboBox_cancelado.TabIndex = 51;
            this.comboBox_cancelado.SelectedIndexChanged += new System.EventHandler(this.comboBox_cancelado_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(520, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 29);
            this.label3.TabIndex = 50;
            this.label3.Text = "Cancelado";
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
            this.comboBox_finalizado.Location = new System.Drawing.Point(383, 114);
            this.comboBox_finalizado.Name = "comboBox_finalizado";
            this.comboBox_finalizado.Size = new System.Drawing.Size(117, 37);
            this.comboBox_finalizado.TabIndex = 49;
            this.comboBox_finalizado.SelectedIndexChanged += new System.EventHandler(this.comboBox_finalizado_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 29);
            this.label2.TabIndex = 48;
            this.label2.Text = "Finalizado";
            // 
            // textBox_cliente
            // 
            this.textBox_cliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_cliente.Location = new System.Drawing.Point(84, 114);
            this.textBox_cliente.Name = "textBox_cliente";
            this.textBox_cliente.Size = new System.Drawing.Size(272, 35);
            this.textBox_cliente.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 29);
            this.label1.TabIndex = 46;
            this.label1.Text = "Cliente";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DimGray;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1277, 580);
            this.dataGridView1.TabIndex = 45;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button_pesquisar);
            this.panel1.Controls.Add(this.label_bemvindo);
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
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1277, 186);
            this.panel1.TabIndex = 59;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(0, 223);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1277, 4);
            this.splitter1.TabIndex = 60;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 227);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1277, 580);
            this.panel2.TabIndex = 61;
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1277, 807);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "User";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem cadastrarServiçosToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem PerfilToolStripMenuItem;
        private System.Windows.Forms.Label label_bemvindo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_pesquisar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker_final;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker_inicial;
        private System.Windows.Forms.ComboBox comboBox_cancelado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_finalizado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_cliente;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
    }
}