using iTextSharp.text;
using NetoBarbershorp.Desktop.BLL;
using NetoBarbershorp.Desktop.BLL.DTO;
using NetoBarbershorp.Desktop.UI.Control;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NetoBarbershorp.Desktop.UI
{
    public partial class Produtos : Form
    {
        List<ListProdutos> _ListProdutos = new List<ListProdutos>();
        List<ProdutoDTO> produtoDTOs = new List<ProdutoDTO>();
        int id_selecionado = 0;
        public Produtos(string token, UsuarioDTO usuario)
        {
            InitializeComponent();
            Token = token;
            Usuario = usuario;       
        }
        public string Token { get; }
        public UsuarioDTO Usuario { get; }

        private async void Services_Load(object sender, EventArgs e)
        {
            comboBox_habilitado.Text = comboBox_habilitado.Items[0].ToString();
            await CarregarProdutos();
        }

        private async Task CarregarProdutos()
        {
            panel1.Controls.Clear();
            _ListProdutos = new List<ListProdutos>();
            var services = await Library.GetProdutos(Token);

            if (services != null)
            {     
                if (comboBox_habilitado.Text == "Sim")
                {
                    services = services.Where(h => h.Habilitado == true && h.Nome.Contains(textBox_pesquisa.Text)).ToArray();
                }
                if (comboBox_habilitado.Text == "Não")
                {
                    services = services.Where(h => h.Habilitado == false && h.Nome.Contains(textBox_pesquisa.Text)).ToArray();
                }

                var services_ordem = services.OrderByDescending(id => id.Id);

                produtoDTOs = services_ordem.ToList();

                foreach (var dados in services_ordem)
                {
                    var listprodutos = new ListProdutos();
                    listprodutos.Name = "control"+dados.Id.ToString();
                    listprodutos.Dock = DockStyle.Top;
                    listprodutos.label_nome.Text = dados.Nome;
                    listprodutos.label_valor.Text = dados.Valor.ToString() + " R$";
                    listprodutos.MouseClick += ListServices_MouseClick1;
                    listprodutos.label1.MouseClick += ListServices_MouseClick1;
                    listprodutos.label3.MouseClick += ListServices_MouseClick1;
                    listprodutos.label_nome.MouseClick += ListServices_MouseClick1;
                    listprodutos.label_valor.MouseClick += ListServices_MouseClick1;
                    listprodutos.pictureBox1.MouseClick += ListServices_MouseClick1;
                    
                    listprodutos.Padding = new Padding(3, 3, 3, 3);
                    _ListProdutos.Add(listprodutos);
                    this.panel1.Controls.Add(listprodutos);
                }
            }
        }
        private void ListServices_MouseClick1(object? sender, MouseEventArgs e)
        {
            ListProdutos? control = null;
            if (sender != null)
            {
                if(sender is ListProdutos)
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

                    var habilitado = produtoDTOs?.FirstOrDefault(id => id.Id == int.Parse(control.Name.Replace("control", " ")))?.Habilitado;

                    if (habilitado == true)
                    {
                        checkBox_des_hab.Checked = true;
                    }
                    else
                    {
                        checkBox_des_hab.Checked = false;
                    }

                    id_selecionado = int.Parse(control.Name.Replace("control", " "));

                    button_alterar.Enabled = true;

                    textBox_nome.Text = control.label_nome.Text;
                    textBox_valor.Text = control.label_valor.Text.Replace("R$", " ").Trim();


                    control.BorderStyle = BorderStyle.Fixed3D;
                    control.BackColor = Color.Green;
                }
            }
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_nome.Text) && !string.IsNullOrEmpty(textBox_valor.Text))
            {
                ProdutoDTO service = new ProdutoDTO();
                service.Nome = textBox_nome.Text;
                service.Valor = Convert.ToDouble(textBox_valor.Text);
                service.Habilitado = checkBox_des_hab.Checked;

                var resultado = await Library.AddProduto(service, Token);

                if (resultado != null)
                {
                    MessageBox.Show("Cadastrado com sucesso");

                    await CarregarProdutos();
                }
            }
            else MessageBox.Show("Digite os campos corretamente");
        }

        private void textBox_valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                //troca o . pela virgula
                e.KeyChar = ',';

                //Verifica se já existe alguma vírgula na string
                if (textBox_valor.Text.Contains(","))
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

        private async void button_alterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_selecionado != 0)
                {
                    var sdto = new ProdutoDTO();
                    sdto.Nome = textBox_nome.Text;
                    sdto.Valor = double.Parse(textBox_valor.Text);
                    sdto.Habilitado = checkBox_des_hab.Checked;

                    bool _found = false;
                    var role = await Library.GetRole(Token);
                    if (role != null)
                    {
                        var servicedones = await Library.GetServiçosFeitos(Token, role);
                        var servicedoneproducts = servicedones?.Where(sdp => sdp.ServiceDoneProducts?.Count() > 0);

                        if (servicedoneproducts != null)
                        {
                            foreach (var products in servicedoneproducts)
                            {
                                var product = products.ServiceDoneProducts.FirstOrDefault(id => id.ProdutoID == id_selecionado);
                                if (product != null)
                                {
                                    _found = true;
                                    break;
                                }
                            }
                        }

                        if (_found == false)
                        {
                            var deletar = await Library.DeleteProduto(id_selecionado, Token);

                            MessageBox.Show(deletar);

                            await CarregarProdutos();
                        }
                        else MessageBox.Show("Produto está atrelado a serviços concluidos, não poder ser alterado");

                        var alterar = await Library.UpdateProduto(id_selecionado, sdto, Token);

                        if (alterar != null)
                        {
                            MessageBox.Show("Alterado com sucesso");

                            await CarregarProdutos();
                        }
                    }
                    else MessageBox.Show("Selecione um produto");
                }
            }
            catch
            {

            }
        }

        private async void button_pesquisa_Click(object sender, EventArgs e)
        {
            id_selecionado = 0;
            textBox_nome.Text = String.Empty;
            textBox_valor.Text = String.Empty;
            checkBox_des_hab.Checked = true;

            await CarregarProdutos();
        }

        private async void button_excluir_Click(object sender, EventArgs e)
        {
            try
            {
                bool _found = false;
                if (id_selecionado != 0)
                {
                    var role = await Library.GetRole(Token);
                    if (role != null)
                    {
                        var servicedones = await Library.GetServiçosFeitos(Token, role);
                        var servicedoneproducts = servicedones?.Where(sdp => sdp.ServiceDoneProducts?.Count() > 0);

                        if (servicedoneproducts != null)
                        {
                            foreach (var products in servicedoneproducts)
                            {
                                var product = products.ServiceDoneProducts.FirstOrDefault(id => id.ProdutoID == id_selecionado);
                                if (product != null)
                                {
                                    _found = true;
                                    break;
                                }
                            }
                        }

                        if (_found == false)
                        {
                            var deletar = await Library.DeleteProduto(id_selecionado, Token);

                            MessageBox.Show(deletar);

                            await CarregarProdutos();
                        }
                        else MessageBox.Show("Produto está atrelado a serviços concluidos, não poder ser excluido");
                    }

                }else MessageBox.Show("Nenhum produto selecionado");
            }
            catch
            {

            }
        }
    }
}
