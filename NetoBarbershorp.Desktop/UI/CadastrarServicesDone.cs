using NetoBarbershorp.Desktop.BLL;
using NetoBarbershorp.Desktop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NetoBarbershorp.Desktop.UI
{
    public partial class CadastrarServicesDone : Form
    {
        public string Token;
        public string? Id;
        public UsuarioDTO? Usuario;
        public List<ServiceDoneServiceDTO> ServiceDoneService = new List<ServiceDoneServiceDTO>();
        double soma = 0;
        public CadastrarServicesDone(string token, UsuarioDTO? usuario, string? id)
        {
            InitializeComponent();
            textBox_usuario.Text = usuario?.Email;
            Token = token;
            Id = id;
            CarregarServiços();
            Usuario = usuario;
        }
        private async void CarregarServiços()
        {
            var dados = await Library.GetServiços(Token);

            if (dados != null)
            {
                foreach (var service in dados)
                {
                    if (service.Habilitado == true)
                    {
                        checkedListBox_services.Items.Add(new ServiceDTO() { Nome = service.Nome, Id = service.Id, Valor = service.Valor }, false);
                    }
                }
            }
        }
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            ServiceDTO? serviceDTO = checkedListBox_services.Items[e.Index] as ServiceDTO;
            if (serviceDTO != null)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    ServiceDoneService.Add(new ServiceDoneServiceDTO { ServiceID = serviceDTO.Id });
                    soma = soma + serviceDTO.Valor;
                }
                if (e.NewValue == CheckState.Unchecked)
                {
                    var result = ServiceDoneService.FirstOrDefault(r => r.ServiceID == serviceDTO.Id);

                    if (result != null)
                    {
                        soma = soma - serviceDTO.Valor;
                        ServiceDoneService.Remove(result);
                    }
                }
            }

            textBox_valor.Text = soma.ToString();
        }
        private async void button_cadastrar_Click(object sender, EventArgs e)
        {
            if (ServiceDoneService.Count > 0)
            {
                if (!string.IsNullOrEmpty(textBox_cliente.Text))
                {
                    var desconto = string.IsNullOrWhiteSpace(textBox_desconto.Text) ? 0 : double.Parse(textBox_desconto.Text);

                    ServiceDoneDTO serviceDoneDTO = new ServiceDoneDTO();

#pragma warning disable CS8601 // Possível atribuição de referência nula.
                    serviceDoneDTO.UsuarioID = string.IsNullOrWhiteSpace(Id) ? Usuario?.Id : Id;
#pragma warning restore CS8601 // Possível atribuição de referência nula.
                    serviceDoneDTO.ClienteNome = textBox_cliente.Text;
                    serviceDoneDTO.Data = DateTime.Now;
                    serviceDoneDTO.ServiceDoneServices = ServiceDoneService;
                    serviceDoneDTO.Cancelado = false;
                    serviceDoneDTO.Finalizado = false;
                    serviceDoneDTO.Desconto = desconto;
                    serviceDoneDTO.Gojeta = string.IsNullOrWhiteSpace(textBox_gojeta.Text) ? 0 : double.Parse(textBox_gojeta.Text);
                    serviceDoneDTO.Observacao = string.Empty;
                    serviceDoneDTO.ValorTotal = string.IsNullOrWhiteSpace(textBox_valor.Text) ? 0 : double.Parse(textBox_valor.Text) - desconto;

                   var result = await Library.AddServiceDone(serviceDoneDTO, Token);

                    if (result != null)
                    {
                        MessageBox.Show("Cadastrado com sucesso");

                        foreach (Form f in Application.OpenForms)
                        {
                            //if (f is User)
                            //{
                            //    ((User)this.Owner).carregargrid(Token, null);
                            //}
                            if (f is Admin)
                            {
                                Admin.Instance.carregargrid(Token, null);
                            }
                        }
                    }
                }
                else MessageBox.Show("Digite o nome do cliente");
            }
            else MessageBox.Show("Nenhum serviço selecionado");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dateTimePicker_data_ValueChanged(object sender, EventArgs e)
        {
            var data = Convert.ToDateTime(dateTimePicker_data.Text.Replace(",", ""));

            var resultado = DateTime.Compare(data, DateTime.Now);

            if (resultado == 1)
            {
                dateTimePicker_data.Value = DateTime.Now;
            }
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

        private void textBox_gojeta_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox_desconto_TextChanged(object sender, EventArgs e)
        {
            var desconto = string.IsNullOrWhiteSpace(textBox_desconto.Text) ? 0 : double.Parse(textBox_desconto.Text);
            if (string.IsNullOrWhiteSpace(textBox_desconto.Text)) textBox_desconto.Text = "0";

            var valortotal = double.Parse(textBox_valor.Text) - desconto;
            textBox_valor.Text = valortotal.ToString();
        }

        private void textBox_gojeta_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_gojeta.Text))
            {
                textBox_gojeta.Text = "0";
            }
        }
    }
}
