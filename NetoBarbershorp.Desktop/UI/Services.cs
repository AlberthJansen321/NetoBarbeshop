using NetoBarbershorp.Desktop.BLL;
using NetoBarbershorp.Desktop.BLL.DTO;
using NetoBarbershorp.Desktop.UI.Control;
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
    public partial class Services : Form
    {
        List<ListServices> ListServices = new List<ListServices>();
        List<ServiceDTO> serviceDTOs = new List<ServiceDTO>();
        int id_selecionado = 0;
        public Services(string token, UsuarioDTO usuario)
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
            await CarregarServices();
        }
        private async Task CarregarServices()
        {
            var services = await Library.GetServiços(Token);
            ListServices = new List<ListServices>();
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

                serviceDTOs = services_ordem.ToList();

                foreach (var dados in services_ordem)
                {
                    ListServices listServices = new ListServices();
                    listServices.Name = dados.Id.ToString();
                    listServices.Dock = DockStyle.Top;
                    listServices.label_nome.Text = dados.Nome;
                    listServices.label_valor.Text = dados.Valor.ToString() + " R$";
                    listServices.MouseClick += ListServices_MouseClick1;
                    listServices.label3.MouseClick += ListServices_MouseClick1;
                    listServices.label1.MouseClick += ListServices_MouseClick1;
                    listServices.label_nome.MouseClick += ListServices_MouseClick1;
                    listServices.label_valor.MouseClick += ListServices_MouseClick1;
                    listServices.pictureBox1.MouseClick += ListServices_MouseClick1;
                    listServices.Padding = new Padding(3, 3, 3, 3);
                    ListServices.Add(listServices);
                    this.panel1.Controls.Add(listServices);
                }
            }
        }
        private void ListServices_MouseClick1(object? sender, MouseEventArgs e)
        {
            ListServices? control = null;
         
            if (sender != null)
            {
                if (sender is ListServices)
                {
                    control = (ListServices)sender;
                }
                if (sender is Label)
                {
                    var label = (Label)sender;

                    if (label.Parent != null && ListServices != null)
                    {
                        control = ListServices.FirstOrDefault(nome => nome.Name == label.Parent.Name);
                    }
                }
                if (sender is PictureBox)
                {
                    var pictureBox = (PictureBox)sender;

                    if (pictureBox.Parent != null && ListServices != null)
                    {
                        control = ListServices.FirstOrDefault(nome => nome.Name == pictureBox.Parent.Name);
                    }
                }

                if (control != null && ListServices != null)
                {
                    foreach (var controles in ListServices)
                    {
                        controles.BorderStyle = BorderStyle.None;
                        controles.BackColor = Color.White;
                    }

                    var habilitado = serviceDTOs?.FirstOrDefault(id => id.Id == int.Parse(control.Name))?.Habilitado;

                    if (habilitado == true)
                    {
                        checkBox_des_hab.Checked = true;
                    }
                    else
                    {
                        checkBox_des_hab.Checked = false;
                    }

                    id_selecionado = int.Parse(control.Name);

                    button_alterar.Enabled = true;

                    textBox_nome.Text = control.label_nome.Text;
                    textBox_valor.Text = control.label_valor.Text.Trim().Replace("R$", " ");

                    control.BorderStyle = BorderStyle.Fixed3D;
                    control.BackColor = Color.Green;
                }
            }
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_nome.Text) && !string.IsNullOrEmpty(textBox_valor.Text))
            {
                ServiceDTO service = new ServiceDTO();
                service.Nome = textBox_nome.Text;
                service.Valor = Convert.ToDouble(textBox_valor.Text);
                service.Habilitado = checkBox_des_hab.Checked;

                var resultado = await Library.AddService(service, Token);

                if (resultado != null)
                {
                    MessageBox.Show("Cadastrado com sucesso");
                    panel1.Controls.Clear();
                    await CarregarServices();
                }
            }
            else MessageBox.Show("Digite todos os campos corretamente");
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
                    var sdto = new ServiceDTO();
                    sdto.Nome = textBox_nome.Text;
                    sdto.Valor = double.Parse(textBox_valor.Text);
                    sdto.Habilitado = checkBox_des_hab.Checked;


                    var alterar = await Library.UpdateService(id_selecionado,sdto,Token);

                    if(alterar != null)
                    {
                        MessageBox.Show("Alterado com sucesso");
                        panel1.Controls.Clear();
                        await CarregarServices();
                    }
                }
                else MessageBox.Show("Selecione um Serviço"); 
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
            panel1.Controls.Clear();
            await CarregarServices();
        }
    }
}
