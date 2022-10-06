using NetoBarbershorp.Desktop.BLL;
using NetoBarbershorp.Desktop.BLL.DTO;
using NetoBarbershorp.Desktop.UI.Control;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NetoBarbershorp.Desktop.UI
{
    public partial class Usuarios : Form
    {
        public static Usuarios Instance = null;
        public Usuarios(string token, UsuarioDTO usuario)
        {
            Instance = this;
            Token = token;
            Usuario = usuario;
            InitializeComponent();
            carregarusuarios();        
        }
        public async void carregarusuarios()
        {
            try
            {
                panel1.Controls.Clear();
                var resultado = await Library.GetUsuarios(Token);
                _ListUsuarios = new List<ListUsuarios>();
                if (resultado?.Count() > 0)
                {
                    foreach (var user in resultado)
                    {
                        if (user.Id != Usuario.Id)
                        {
                            var list = new ListUsuarios();
                            list.Name = user?.Id?.ToString();
                            list.Dock = DockStyle.Top;
                            list.MouseClick += List_MouseClick;
                            list.label_email.MouseClick += List_MouseClick;
                            list.label_nome.MouseClick += List_MouseClick;
                            list.pictureBox1.MouseClick += List_MouseClick;
                            list.Padding = new Padding(3, 3, 3, 3);
                            list.label_nome.Text = "Nome: " + user.Nome;
                            list.label_email.Text = "Email: " + user.Email;
                            
                            _ListUsuarios.Add(list);
                            panel1.Controls.Add(list);
                        }
                    }
                }
            }
            catch
            {

            }
        }
        string id_selecionado;
        List<ListUsuarios> _ListUsuarios = new List<ListUsuarios>();
        private void List_MouseClick(object? sender, MouseEventArgs e)
        {
            ListUsuarios? control = null;

            if (sender != null)
            {
                if (sender is ListUsuarios)
                {
                    control = (ListUsuarios)sender;
                }
                if (sender is Label)
                {
                    var label = (Label)sender;

                    if (label.Parent != null && _ListUsuarios != null)
                    {
                        control = _ListUsuarios.FirstOrDefault(nome => nome.Name == label.Parent.Name);
                    }
                }
                if (sender is PictureBox)
                {
                    var pictureBox = (PictureBox)sender;

                    if (pictureBox.Parent != null && _ListUsuarios != null)
                    {
                        control = _ListUsuarios.FirstOrDefault(nome => nome.Name == pictureBox.Parent.Name);
                    }
                }       

                if (control != null && _ListUsuarios != null)
                {
                    foreach (var controles in _ListUsuarios)
                    {
                        controles.BorderStyle = BorderStyle.None;
                        controles.BackColor = Color.White;
                    }

                    id_selecionado = control.Name;

                    button_alterar.Enabled = true;            

                    control.BorderStyle = BorderStyle.Fixed3D;
                    control.BackColor = Color.Green;
                }
            }
        }

        public string Token { get; }
        public UsuarioDTO Usuario { get; }

        private void Usuarios_Load(object sender, System.EventArgs e)
        {

        }
        private void button_pesquisa_Click(object sender, EventArgs e)
        {
            id_selecionado = String.Empty;
        }
        private void button_cadastrar_Click(object sender, EventArgs e)
        {
            bool _found = false;
            
            foreach (Form _openForm in Application.OpenForms)
            {
                if (_openForm is CadastrarUser)
                {
                    _openForm.Focus();
                    _found = true;
                }
            }
            if (!_found)
            {
                var form = new CadastrarUser(Token);
                form.Show();
            }
        }

        private async void button_exluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(id_selecionado))
                {
                    var deletar = await Library.DeleteUser(id_selecionado,Token);

                    if(deletar == true)
                    {
                        MessageBox.Show("Usuario deletado com sucesso");
                        Admin.Instance.usuarios(Token);
                        carregarusuarios();
                    }
                }
                else MessageBox.Show("Nenhum usuario selecionado");
            }
            catch
            {

            }
        }

        private async void button_alterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(id_selecionado))
                {
                    var resetar = await Library.ResetPasswordUser(id_selecionado,"12345",Token);
                    
                    if(resetar == true)
                    {
                        MessageBox.Show("Senha alterada para 12345 com sucesso");
                    }
                }
            }
            catch
            {

            }
        }
    }
}
