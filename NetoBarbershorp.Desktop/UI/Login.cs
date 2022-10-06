using NetoBarbershorp.Desktop.BLL;
using System;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace NetoBarbershorp.Desktop.UI
{
    public partial class Login : Form
    {
        string? token_user;

        public Login()
        {
            InitializeComponent();

            textBox_email.Text = Properties.Settings.Default.ultimo;
            logado();

        }

        private void logado()
        {
            var config = Configuration.AppSettings();
            pictureBox1.Visible = true;
            if (!string.IsNullOrWhiteSpace(config))
            {
                
                string[]? dados = config?.Split(",");
                LoginUser(dados[2], dados[0], dados[1]);
            }
            else
            {
                pictureBox1.Visible = false;
            }
        }
        private async void button_entrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox_email.Text) && !Library.ValidarEmail(textBox_email.Text))
                    MessageBox.Show("Email Inválido");
                else
                {
                    if (!string.IsNullOrEmpty(textBox_email.Text) && !string.IsNullOrEmpty(textBox_senha.Text))
                    {
                        pictureBox1.Visible = true;
                        button_entrar.Enabled = false;

                        await VerificarDados(textBox_email.Text, textBox_senha.Text);
                    }
                    else MessageBox.Show("Email e senha devem ser informados");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task VerificarDados(string email, string senha)
        {

            var resultado = await Library.Login(email, senha);

            if (resultado != null)
            {
                var values = email + "," + senha + "," + resultado.Token;
                Properties.Settings.Default.dados = values;
                Properties.Settings.Default.Save();
                token_user = resultado.Token;
                LoginUser(token_user, email, senha);
            }
            else
            {
                MessageBox.Show("Não foi possivél fazer o login");
                pictureBox1.Visible = false;
                button_entrar.Enabled = true;
            }

        }

        private async void LoginUser(string token, string email, string senha)
        {
            if (token != null)
            {
                var usuario = await Library.GetUsuario(token, email, senha);

                if (usuario != null)
                {
                    var role = await Library.GetRole(token);

                    pictureBox1.Visible =false;
                    button_entrar.Enabled = true;

                    Properties.Settings.Default.ultimo = email;
                    Properties.Settings.Default.Save();

                    if (role?.Contains("ADMIN") == true)
                    {
                        usuario.Senha = senha;

                        Thread t = new Thread(delegate ()
                        {
                            var form = new Admin(token, usuario);
                            form.ShowDialog();
                        });
                        t.SetApartmentState(ApartmentState.STA);
                        t.Start();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sistema disponivel apenas para o adminitrador");
                        //Thread t = new Thread(delegate ()
                        //{
                        //    var form = new User(token, usuario);
                        //    form.ShowDialog();
                        //});
                        //t.SetApartmentState(ApartmentState.STA);
                        //t.Start();
                        //this.Close();
                    }
                }
                else pictureBox1.Visible = false; button_entrar.Enabled = true;
            }
            else pictureBox1.Visible = false; button_entrar.Enabled = true;
        }
    }
}
