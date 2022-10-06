using NetoBarbershorp.Desktop.BLL;
using NetoBarbershorp.Desktop.BLL.DTO;
using NetoBarbershorp.Desktop.UI.Control;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetoBarbershorp.Desktop.UI
{
    public partial class UpdateServiceDone : Form
    {
        public string Token { get; }
        public ServiceDoneDTO _serviceDoneDTO { get; }
        public string? Id_servicedone { get; }
        public ServiceDoneDTO Clicado { get; }
        List<ListProdutos> _ListProdutos = new List<ListProdutos>();
        List<ServiceDoneServiceDTO> ServiceDoneService = new List<ServiceDoneServiceDTO>();
        List<ServiceDoneProductDTO> ServiceDoneProduct = new List<ServiceDoneProductDTO>();
        public UpdateServiceDone(string token, string? id_servicedone, ServiceDoneDTO serviceDoneDTO)
        {
            Token = token;
            _serviceDoneDTO = serviceDoneDTO;
            Id_servicedone = id_servicedone;
            InitializeComponent();

            textBox_nomecliente.Text = serviceDoneDTO.ClienteNome;
            textBox_desconto.Text = serviceDoneDTO.Desconto.ToString();
            textBox_gojeta.Text = serviceDoneDTO.Gojeta.ToString();
            textBox_valortotal.Text = serviceDoneDTO.ValorTotal.ToString();
            checkedListBox_services.ItemCheck -= new ItemCheckEventHandler(checkedListBox_services_ItemCheck);
            textBox_quantidade.Text = "1";
            desconto = string.IsNullOrWhiteSpace(textBox_desconto.Text) ? 0 : double.Parse(textBox_desconto.Text);

            if (!string.IsNullOrWhiteSpace(dateTimePicker_data.Text))
            {
                DataValue(DateTime.Now.ToString());
            }
            dateTimePicker_data.Text = serviceDoneDTO.Data.ToString();

            if (serviceDoneDTO.Finalizado == true)
            {
                MessageBox.Show("Já está finalizado, não pode ser editado");
                textBox_desconto.Enabled = false;
                textBox_gojeta.Enabled = false;
                textBox_nomecliente.Enabled = false;
                checkedListBox_services.Enabled = false;
                panel1.Enabled = false;
                button_add.Enabled = false;
                button_delete.Enabled = false;
                button_update.Enabled = false;
                button_cadastrar.Enabled = false;
                comboBox_produtos.Enabled = false;
                dateTimePicker_data.Enabled = false;
                textBox_quantidade.Enabled = false;

            }

            if (serviceDoneDTO.Cancelado == true)
            {
                MessageBox.Show("Já está cancelado, não pode ser editado");
                textBox_desconto.Enabled = false;
                textBox_gojeta.Enabled = false;
                textBox_nomecliente.Enabled = false;
                checkedListBox_services.Enabled = false;
                panel1.Enabled = false;
                button_add.Enabled = false;
                button_delete.Enabled = false;
                button_update.Enabled = false;
                button_cadastrar.Enabled = false;
                comboBox_produtos.Enabled = false;
                dateTimePicker_data.Enabled = false;
                textBox_quantidade.Enabled = false;
            }
        }
        public async Task<double> SomaServices()
        {
            var dados = await Library.GetServiços(Token);

            if (dados?.Count() > 0)
            {
                var query = from services in dados
                            join servicedoneservice in ServiceDoneService on services.Id equals servicedoneservice.ServiceID
                            select new { precos = services.Valor };

                return query.Sum(a => a.precos);
            }

            return 0;
        }
        public async Task<double> SomaProducts()
        {
            var dados = await Library.GetProdutos(Token);
            if (dados?.Count() > 0)
            {
                var query = from produtos in dados
                            join servicedoneproduct in ServiceDoneProduct on produtos.Id equals servicedoneproduct.ProdutoID
                            select new { precos = produtos.Valor * servicedoneproduct.Quantidade };

                return query.Sum(a => a.precos);
            }
            return 0;
        }
        private void DataValue(string v)
        {
            try
            {
                var data = Convert.ToDateTime(v);

                System.Globalization.CultureInfo customCulture = new System.Globalization.CultureInfo("en-US", true);

                customCulture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";

                System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
                System.Threading.Thread.CurrentThread.CurrentUICulture = customCulture;

                var newdata = System.Convert.ToDateTime(data.ToString("yyyy-MM-dd"));

                var resultado = DateTime.Compare(data, DateTime.Now);

                if (resultado == 1)
                {
                    dateTimePicker_data.Value = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private async void UpdateServiceDone_Load(object sender, EventArgs e)
        {
            await carregarproduts();
            await carregarservices();
            checkedListBox_services.ItemCheck += new ItemCheckEventHandler(checkedListBox_services_ItemCheck);

            var soma = (await SomaServices() + await SomaProducts()) - desconto;
            textBox_valortotal.Text = soma.ToString();

        }
        private async Task carregarservices()
        {
            var dados = await Library.GetServiços(Token);

            if (dados != null)
            {
                foreach (var service in dados)
                {
                    if (service.Habilitado == true)
                    {
                        var result = _serviceDoneDTO.ServiceDoneServices.FirstOrDefault(id_service => id_service.ServiceID == service.Id);
                        if (result == null)
                        {
                            checkedListBox_services.Items.Add(new ServiceDTO() { Nome = service.Nome, Id = service.Id, Valor = service.Valor }, false);
                        }
                        else
                        {
                            checkedListBox_services.Items.Add(new ServiceDTO() { Nome = service.Nome, Id = service.Id, Valor = service.Valor }, true);
                            var existe = ServiceDoneService.FirstOrDefault(sv => sv.ServiceID == service.Id);
                            if (existe == null)
                            {
                                ServiceDoneService.Add(new ServiceDoneServiceDTO { ServiceID = service.Id });
                            }
                        }
                    }
                }
            }  
        }
        private async Task carregarproduts()
        {
            var dados = await Library.GetProdutos(Token);
            _ListProdutos = new List<ListProdutos>();
            if (dados != null)
            {

                var habilitados = dados.Where(h => h.Habilitado == true).ToArray();


                comboBox_produtos.Invoke(new Action(() =>
                {
                    comboBox_produtos.DataSource = habilitados;
                }));


                foreach (var produto in dados)
                {
                    var result = _serviceDoneDTO.ServiceDoneProducts.FirstOrDefault(id_produto => id_produto.ProdutoID == produto.Id);

                    if (result != null)
                    {
                        ServiceDoneProduct.Add(new ServiceDoneProductDTO { ProdutoID = result.ProdutoID, Quantidade = result.Quantidade });

                        var listprodutos = new ListProdutos();
                        listprodutos.Name = produto.Id.ToString();
                        listprodutos.Dock = DockStyle.Top;
                        listprodutos.label_nome.Text = produto.Nome;
                        listprodutos.label_valor.Text = produto.Valor.ToString() + " R$";
                        listprodutos.MouseClick += Listprodutos_MouseClick; ;
                        listprodutos.Padding = new Padding(3, 3, 3, 3);
                        _ListProdutos.Add(listprodutos);
                        this.panel1.Controls.Add(listprodutos);

                    }
                }
            }
        }
        int id_produtoselecionado;
        ListProdutos listProduto_selecionado;
        private void Listprodutos_MouseClick(object? sender, MouseEventArgs e)
        {

            ListProdutos? control = null;

            if (sender != null)
            {
                if (sender is ListProdutos)
                {
                    control = (ListProdutos)sender;
                }
                if (sender is Label)
                {
                    var label = (Label)sender;

                    if (label.Parent != null && _ListProdutos != null)
                    {
                        control = _ListProdutos.FirstOrDefault(nome => nome.Name == label.Parent.Name);
                    }
                }
                if (sender is PictureBox)
                {
                    var pictureBox = (PictureBox)sender;

                    if (pictureBox.Parent != null && _ListProdutos != null)
                    {
                        control = _ListProdutos.FirstOrDefault(nome => nome.Name == pictureBox.Parent.Name);
                    }
                }

                if (control != null && _ListProdutos != null)
                {
                    foreach (var controles in _ListProdutos)
                    {
                        controles.BorderStyle = BorderStyle.None;
                        controles.BackColor = Color.White;
                    }
                    listProduto_selecionado = control;
                    id_produtoselecionado = int.Parse(control.Name);
                    var resultado = ServiceDoneProduct.FirstOrDefault(id => id.ProdutoID == id_produtoselecionado);
                    if (resultado != null)
                    {
                        textBox_quantidade.Text = resultado.Quantidade.ToString();
                    }
                    control.BorderStyle = BorderStyle.Fixed3D;
                    control.BackColor = Color.Green;
                }
                //  comboBox1.Text = control.label_valor.Text;
            }
        }
        private async void button_cadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox_nomecliente.Text))
                {
                    var data = Convert.ToDateTime(dateTimePicker_data.Value);

                    var servicedoneDTO = new ServiceDoneDTO();
                    servicedoneDTO.ClienteNome = textBox_nomecliente.Text;
                    servicedoneDTO.Data = data;
                    servicedoneDTO.ValorTotal = double.Parse(textBox_valortotal.Text);
                    servicedoneDTO.Desconto = desconto;
                    servicedoneDTO.Gojeta = string.IsNullOrWhiteSpace(textBox_gojeta.Text) ? 0 : double.Parse(textBox_gojeta.Text);
                    servicedoneDTO.UsuarioID = _serviceDoneDTO.UsuarioID;
                    servicedoneDTO.Finalizado = _serviceDoneDTO.Finalizado;
                    servicedoneDTO.Cancelado = _serviceDoneDTO.Cancelado;
                    servicedoneDTO.Observacao = _serviceDoneDTO.Observacao;

                    if (ServiceDoneProduct.Count <= 0)
                    {
                        servicedoneDTO.ServiceDoneProducts = null;
                    }
                    else
                    {
                        servicedoneDTO.ServiceDoneProducts = ServiceDoneProduct;
                    }
                    if (ServiceDoneService.Count <= 0)
                    {
                        servicedoneDTO.ServiceDoneServices = null;
                    }
                    else
                    {
                        servicedoneDTO.ServiceDoneServices = ServiceDoneService;
                    }



                    var result = await Library.UpdateServiceDone(int.Parse(Id_servicedone), servicedoneDTO, Token);

                    if (result != null)
                    {
                        MessageBox.Show("Salvo com sucesso");

                        foreach (Form f in Application.OpenForms)
                        {
                            if (f is Admin)
                            {
                                Admin.Instance.carregargrid(Token, null);
                            }
                        }
                    }
                }
                else MessageBox.Show("Digite o nome do cliente", "atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {

            }
        }
        private async void checkedListBox_services_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ServiceDTO? serviceDTO = checkedListBox_services.Items[e.Index] as ServiceDTO;

            if (serviceDTO != null)
            {
                var result = ServiceDoneService.FirstOrDefault(r => r.ServiceID == serviceDTO.Id);

                if (e.NewValue == CheckState.Checked)
                {
                    if (result == null)
                    {
                        ServiceDoneService.Add(new ServiceDoneServiceDTO { ServiceID = serviceDTO.Id });
                    }
                }
                if (e.NewValue == CheckState.Unchecked)
                {
                    if (result != null)
                    {
                        ServiceDoneService.Remove(result);
                    }
                }
            }

           var soma = (await SomaServices() + await SomaProducts()) - desconto;
           textBox_valortotal.Text = soma.ToString();
    
        }
        double desconto;
        private async void textBox_desconto_TextChanged(object sender, EventArgs e)
        {
            desconto = string.IsNullOrWhiteSpace(textBox_desconto.Text) ? 0 : double.Parse(textBox_desconto.Text.Replace(",", "."));
            if (string.IsNullOrWhiteSpace(textBox_desconto.Text)) textBox_desconto.Text = "0";

            var soma = (await SomaServices() + await SomaProducts()) - desconto;   
            textBox_valortotal.Text = soma.ToString();    
        }

        private void dateTimePicker_data_ValueChanged(object sender, EventArgs e)
        {
            DataValue(dateTimePicker_data.Value.ToString());
        }
        int quantidade_selecionada = 1;
        ProdutoDTO produto_selecionado;
        private void comboBox_produtos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var minhaClasseSelecionado = comboBox_produtos.SelectedItem as ProdutoDTO;

            if (minhaClasseSelecionado != null)
            {
                produto_selecionado = minhaClasseSelecionado;
            }
        }
        private async void button_add_Click(object sender, EventArgs e)
        {
            if (produto_selecionado != null)
            {
                var result = ServiceDoneProduct.FirstOrDefault(r => r.ProdutoID == produto_selecionado.Id);

                if (result == null)
                {
                    ServiceDoneProduct.Add(new ServiceDoneProductDTO { ProdutoID = produto_selecionado.Id, Quantidade = quantidade_selecionada });

                    var listprodutos = new ListProdutos();
                    listprodutos.Name = produto_selecionado.Id.ToString();
                    listprodutos.Dock = DockStyle.Top;
                    listprodutos.label_nome.Text = produto_selecionado.Nome;
                    listprodutos.label_valor.Text = produto_selecionado.Valor.ToString() + " R$";
                    listprodutos.MouseClick += Listprodutos_MouseClick;
                    listprodutos.label1.MouseClick += Listprodutos_MouseClick;
                    listprodutos.label3.MouseClick += Listprodutos_MouseClick;
                    listprodutos.label_nome.MouseClick += Listprodutos_MouseClick;
                    listprodutos.label_valor.MouseClick += Listprodutos_MouseClick;
                    listprodutos.pictureBox1.MouseClick += Listprodutos_MouseClick;
                    listprodutos.Padding = new Padding(3, 3, 3, 3);
                    _ListProdutos.Add(listprodutos);
                    this.panel1.Controls.Add(listprodutos);


                    var soma = (await SomaServices() + await SomaProducts()) - desconto;
                    textBox_valortotal.Text = soma.ToString();
                }
                else MessageBox.Show("Produto já está adicionado no pedidos do cliente");
            }
            else MessageBox.Show("Nenhum produto selecionado");
        }

        private async void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                var result = ServiceDoneProduct.FirstOrDefault(r => r.ProdutoID == id_produtoselecionado);

                if (result != null && listProduto_selecionado != null)
                {
                    bool deletar = ServiceDoneProduct.Remove(result);

                    if (deletar == true)
                    {
                        panel1.Controls.Remove(listProduto_selecionado);

                        var soma = (await SomaServices() + await SomaProducts()) - desconto;
                        textBox_valortotal.Text = soma.ToString();
                    }
                }
                else MessageBox.Show("Nenhum produto selecionado na lista abaixo");
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_desconto_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (!String.IsNullOrWhiteSpace(textBox_desconto.Text))
                {
                    //troca o . pela virgula
                    e.KeyChar = ',';
                }

                //Verifica se já existe alguma vírgula na string
                if (textBox_desconto.Text.Contains(","))
                {
                    e.Handled = true; // Caso exista, aborte 
                }
            }

            //aceita apenas números, tecla backspace.
            else if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void textBox_gojeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                //troca o . pela virgula
                e.KeyChar = ',';

                //Verifica se já existe alguma vírgula na string
                if (textBox_gojeta.Text.Contains(","))
                {
                    e.Handled = true; // Caso exista, aborte 
                }
            }

            //aceita apenas números, tecla backspace.
            else if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void textBox_quantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            //aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
        private void textBox_quantidade_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox_quantidade.Text))
            {
                int qtd = int.Parse(textBox_quantidade.Text);

                if (qtd <= 0)
                {
                    qtd = 1;
                }

                quantidade_selecionada = qtd;
            }
            else
            {
                textBox_quantidade.Text = "1";
                quantidade_selecionada = 1;
            }
        }

        private void textBox_gojeta_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_gojeta.Text))
            {
                textBox_gojeta.Text = "0";
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {

        }
    }
}
