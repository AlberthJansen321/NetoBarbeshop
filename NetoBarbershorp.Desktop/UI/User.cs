using iTextSharp.text;
using NetoBarbershorp.Desktop.BLL;
using NetoBarbershorp.Desktop.BLL.DTO;
using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetoBarbershorp.Desktop.UI
{
    public partial class User : Form
    {
        public string Token { get; }
        public UsuarioDTO Usuario { get; }

        double? soma = 0;
        bool finalizado = true, cancelado = false;

        DateTime dt_inicial = DateTime.Now, dt_final = DateTime.Now;

        public User(string token, UsuarioDTO usuario)
        {
            InitializeComponent();
            Token = token;
            Usuario = usuario;
            this.FormClosed += User_FormClosed;
            carregargrid(token, null);
            comboBox_cancelado.Text = comboBox_cancelado.Items[1].ToString();
            comboBox_finalizado.Text = comboBox_finalizado.Items[0].ToString();

            if (!string.IsNullOrWhiteSpace(dateTimePicker_inicial.Text) && !string.IsNullOrWhiteSpace(dateTimePicker_inicial.Text))
            {
                DataInicial(DateTime.Now.ToString());
                DataFinal(DateTime.Now.ToString());
            }
        }
        private void DataFinal(string v)
        {

            try
            {
                var data = Convert.ToDateTime(v);

                System.Globalization.CultureInfo customCulture = new System.Globalization.CultureInfo("en-US", true);

                customCulture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";

                System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
                System.Threading.Thread.CurrentThread.CurrentUICulture = customCulture;

                dt_final = System.Convert.ToDateTime(data.ToString("yyyy-MM-dd"));

                var resultado = DateTime.Compare(data, DateTime.Now);

                if (resultado == 1)
                {
                    dateTimePicker_final.Value = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void DataInicial(string v)
        {
            try
            {
                var data = Convert.ToDateTime(v);

                System.Globalization.CultureInfo customCulture = new System.Globalization.CultureInfo("en-US", true);

                customCulture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";

                System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
                System.Threading.Thread.CurrentThread.CurrentUICulture = customCulture;

                dt_inicial = System.Convert.ToDateTime(data.ToString("yyyy-MM-dd"));

                var resultado = DateTime.Compare(data, DateTime.Now);

                if (resultado == 1)
                {
                    dateTimePicker_inicial.Value = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async void carregargrid(string token, ServiceDoneDTO[]? dados)
        {
            try
            {
                soma = 0;

                var usuario_novo = await Library.GetUsuario(token, Usuario.Email);

                if (usuario_novo != null)
                {
                    label_bemvindo.Text = $"Seja bem-vindo(a) " + usuario_novo.Nome;
                }

                DataTable table = new DataTable();
                table.Columns.Add("ClienteNome", typeof(string));
                table.Columns.Add("Data", typeof(DateTime));
                table.Columns.Add("Valor", typeof(string));
                table.Columns.Add("Finalizado", typeof(string));
                table.Columns.Add("Cancelado", typeof(string));

                var servicos = await carregarServices(token);

                if (servicos != null)
                {
                    if (dados == null)
                    {
                        dados = await Library.GetServiçosFeitos(token,string.Empty);
                    }

                    if (dados != null && servicos != null)
                    {
                        foreach (var s in dados)
                        {
                            var finalizado = s.Finalizado == true ? "Sim" : "Não";

                            if (s.Finalizado == true)
                            {
                                soma = soma + s?.ValorTotal;
                            }

                            var cancelado = s.Cancelado == true ? "Sim" : "Não";

                            table.Rows.Add(s.ClienteNome, s.Data,
                                finalizado, cancelado);

                        }

                        if (table != null)
                        {
                            label6.Text = $"Valor Total dos Serviços finalizadoss: R$ {soma}";
                            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            dataGridView1.RowHeadersVisible = false;
                            dataGridView1.EnableHeadersVisualStyles = false;
                            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dataGridView1.AllowUserToResizeRows = false;
                            dataGridView1.AllowUserToResizeColumns = false;
                            dataGridView1.AllowUserToOrderColumns = false;
                            dataGridView1.AllowUserToAddRows = false;
                            dataGridView1.MultiSelect = false;
                            //ExtensionMethods.DoubleBuffered(dataGridView1, false);
                            dataGridView1.DataSource = table;
                            //ExtensionMethods.DoubleBuffered(dataGridView1, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void dateTimePicker_inicial_ValueChanged(object sender, EventArgs e)
        {
            DataInicial(dateTimePicker_inicial.Text);
        }
        private void dateTimePicker_final_ValueChanged(object sender, EventArgs e)
        {
            DataFinal(dateTimePicker_final.Text);
        }
        private void comboBox_finalizado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_finalizado.Text == comboBox_finalizado.Items[0].ToString())
                {
                    finalizado = true;
                    //cancelado = false;
                    //comboBox_cancelado.Text = comboBox_cancelado.Items[1].ToString();
                }
                if (comboBox_finalizado.Text == comboBox_finalizado.Items[1].ToString())
                {
                    finalizado = false;
                    //cancelado = true;
                    //comboBox_cancelado.Text = comboBox_cancelado.Items[0].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void comboBox_cancelado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_cancelado.Text == comboBox_finalizado.Items[0].ToString())
                {
                    finalizado = false;
                    //cancelado = true;
                    //comboBox_finalizado.Text = comboBox_cancelado.Items[1].ToString();
                }
                if (comboBox_cancelado.Text == comboBox_finalizado.Items[1].ToString())
                {
                    cancelado = false;
                    //finalizado = true;
                    //comboBox_finalizado.Text = comboBox_cancelado.Items[0].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void cadastrarServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool _found = false;

            foreach (Form _openForm in Application.OpenForms)
            {
                if (_openForm is CadastrarServicesDone)
                {
                    _openForm.Focus();
                    _found = true;
                }
            }
            if (!_found)
            {
                var form = new CadastrarServicesDone(Token, Usuario, null);
                form.Owner = this;
                form.Show();
            }
        }
        private void auToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool _found = false;

            foreach (Form _openForm in Application.OpenForms)
            {
                if (_openForm is AtualizarUser)
                {
                    _openForm.Focus();
                    _found = true;
                }
            }
            if (!_found)
            {
                var form = new AtualizarUser(Token, Usuario);
                form.Owner = this;
                form.Show();
            }
        }
        private async void button_pesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                var resultado = await Library.GetFiltro(textBox_cliente.Text, dt_inicial, dt_final, cancelado, finalizado, Token);
                carregargrid(Token, resultado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private async Task<ServiceDTO[]?> carregarServices(string token)
        {
            return await Library.GetServiços(token);
        }
        private void User_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Thread t = new Thread(delegate ()
            {
                var form = new Login();
                form.ShowDialog();
            });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            this.Close();
        }
    }
}
