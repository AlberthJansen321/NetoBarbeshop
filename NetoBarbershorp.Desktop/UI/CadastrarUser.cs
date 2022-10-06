using NetoBarbershorp.Desktop.BLL;
using NetoBarbershorp.Desktop.BLL.DTO;
using System;
using System.Threading;
using System.Windows.Forms;

namespace NetoBarbershorp.Desktop.UI
{
    public partial class CadastrarUser : Form
    {
        public string Token { get; }

        public CadastrarUser(string token)
        {
            Token = token;
            InitializeComponent();
        }
        private async void button_cadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioDTO usuarioDTO = new UsuarioDTO();
                usuarioDTO.Nome = textBox_nome.Text;
                usuarioDTO.Email = textBox_email.Text;
                usuarioDTO.Senha = textBox_senha.Text;
                usuarioDTO.ConfimacaoSenha = textBox_confirsenha.Text;

                var resultado = await Library.AddUsuario(usuarioDTO, Token);
                if (resultado != null)
                {
                    MessageBox.Show("Usuario cadastrado com sucesso", "sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    foreach (Form f in Application.OpenForms)
                    {
                        if (f is Admin)
                        {
                            Admin.Instance.usuarios(Token);
                            Usuarios.Instance.carregarusuarios();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
