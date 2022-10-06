using NetoBarbershorp.Desktop.BLL;
using NetoBarbershorp.Desktop.BLL.DTO;
using System;
using System.Collections.Specialized;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NetoBarbershorp.Desktop.UI
{
    public partial class AtualizarUser : Form
    {
        public string Token { get; }
        public UsuarioDTO Usuario { get; }
        string senha_nova;
        public AtualizarUser(string token, UsuarioDTO usuario)
        {
            InitializeComponent();
            Token = token;
            Usuario = usuario;
            textBox_nome.Text = usuario.Nome;
        }
        private async void button_atualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox_nome.Text) ||
                    !string.IsNullOrWhiteSpace(textBox_senha.Text) || !string.IsNullOrEmpty(textBox_confirsenha.Text))
                {
                    UpdateUserDTO updateUserDTO = new UpdateUserDTO();
                    updateUserDTO.Nome = textBox_nome.Text;
                    updateUserDTO.Email = Usuario.Email;

                    if (!string.IsNullOrWhiteSpace(textBox_senha.Text))
                    {
                        updateUserDTO.Senha = textBox_senha.Text;
                        updateUserDTO.ConfimacaoSenha = textBox_confirsenha.Text;
                        senha_nova = textBox_senha.Text;
                    }
                    else
                    {
                        updateUserDTO.Senha = Usuario.Senha;
                        updateUserDTO.ConfimacaoSenha = Usuario.Senha;
                        senha_nova = Usuario.Senha;
                    }



                    var resultado = await Library.UpdateUser(updateUserDTO, Token);

                    if (resultado != null)
                    {
                        MessageBox.Show("Usuario Alterado com sucesso");


                        var values = Usuario.Email + "," + senha_nova + "," + Token;
                        Properties.Settings.Default.dados = values;
                        Properties.Settings.Default.Save();

                   

                        foreach (Form _openForm in Application.OpenForms)
                        {
                            if (_openForm is Admin)
                            {
                                Admin.Instance.carregargrid(Token,null);
                            }
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
