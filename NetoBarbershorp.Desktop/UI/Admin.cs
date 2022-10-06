using iTextSharp.text;
using iTextSharp.text.pdf;
using NetoBarbershorp.Desktop.BLL;
using NetoBarbershorp.Desktop.BLL.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetoBarbershorp.Desktop.UI
{
    public partial class Admin : Form
    {
        ServiceDoneDTO? _ServiceDoneDTO;
        int servicedone_id;
        public string Token { get; }
        public static Admin Instance = null;
        public UsuarioDTO Usuario { get; }
        string? id_usuarioselecionado;
        double? soma = 0;
        bool finalizado = true, cancelado = false;
        DataTable table1 = new DataTable();
        DateTime dt_inicial = DateTime.Now, dt_final = DateTime.Now;

        public Admin(string token, UsuarioDTO usuario)
        {
            InitializeComponent();
            Instance = this;
            Usuario = usuario;
            Token = token;
            label_bemvindo.Text = usuario.Nome;
            this.FormClosed += Admin_FormClosed;
            usuarios(token);
            carregargrid(token, null);
            comboBox_cancelado.Text = comboBox_cancelado.Items[1].ToString();
            comboBox_finalizado.Text = comboBox_finalizado.Items[1].ToString();
            this.dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            if (!string.IsNullOrWhiteSpace(dateTimePicker_inicial.Text) && !string.IsNullOrWhiteSpace(dateTimePicker_inicial.Text))
            {
                DataInicial(DateTime.Now.ToString());
                DataFinal(DateTime.Now.ToString());
            }

        }

        private void DataGridView1_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridView1?.Rows?.Count > 0)
            {
                var linhaAtual = dataGridView1.CurrentRow;
                int indice = linhaAtual.Index;

                button_excluir.Enabled = true;
                button_imprimir.Enabled = true;

                _ServiceDoneDTO = new ServiceDoneDTO();
                servicedone_id = (int)dataGridView1.Rows[indice].Cells["Id"].Value;
                _ServiceDoneDTO.ClienteNome = (string)dataGridView1.Rows[indice].Cells["ClienteNome"].Value;
                _ServiceDoneDTO.Data = (DateTime)dataGridView1.Rows[indice].Cells["Data"].Value;
                _ServiceDoneDTO.ValorTotal = Convert.ToDouble(dataGridView1?.Rows[indice]?.Cells["ValorTotal"]?.Value?.ToString()?.Replace("R$", " ").Trim());
                _ServiceDoneDTO.UsuarioID = id_usuarioselecionado;
                var finalizado = (string)dataGridView1.Rows[indice].Cells["Finalizado"].Value;
                var Cancelado = (string)dataGridView1.Rows[indice].Cells["Cancelado"].Value;
                relatorioToolStripMenuItem.Visible = false;
                if (finalizado == "Sim")
                {
                    button_finalizar.Enabled = false;
                }
                else
                {
                    button_finalizar.Enabled = true;
                }

                if (Cancelado == "Sim")
                {
                    button_cancelar.Enabled = false;
                }
                else
                {
                    button_cancelar.Enabled = true;
                }
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
        private void Admin_FormClosed(object? sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        public async void usuarios(string token)
        {
            var dados = await Library.GetUsuarios(token);

            if (dados != null)
            {
                dados = dados?.Where(id => id.Id != Usuario.Id).ToArray();
                comboBox_usuario.Invoke(new Action(() =>
                {
                    comboBox_usuario.DataSource = dados;
                    comboBox_usuario.DisplayMember = "Email";
                }));
            }
        }
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool _found = false;
            
            foreach (Form _openForm in Application.OpenForms)
            {
                if (_openForm is Usuarios)
                {
                    _openForm.Focus();
                    _found = true;
                }
            }
            if (!_found)
            {
                var form = new Usuarios(Token, Usuario);
                form.Show();
            }
        }
        private void relatorioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void comboBox_usuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            var minhaClasseSelecionado = comboBox_usuario.SelectedItem as UsuarioDTO;

            if (minhaClasseSelecionado != null)
            {
                id_usuarioselecionado = minhaClasseSelecionado.Id;
                carregargrid(Token, null);
            }
            else
            {
                dataGridView1.DataSource = null;
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
        private async void button_pesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                var resultado = await Library.GetServiçosFeitosByUser(Token, comboBox_usuario.Text, textBox_cliente.Text, dt_inicial, dt_final, cancelado, finalizado);
                carregargrid(Token, resultado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
                    //finalizado = false;
                    cancelado = true;
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
        private void button_imprimir_Click(object sender, EventArgs e)
        {
            if (table1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = $"relatorio_{comboBox_usuario.Text}_{DateTime.Now.ToString("yy-MM-dd_HH_mm_ss_tt")}.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(table1.Columns.Count - 2);

                            for (int k = 0; k < table1.Columns.Count; k++)
                            {
                                if (table1.Columns[k].ColumnName != "Id" && table1.Columns[k].ColumnName != "Id_service")
                                {
                                    PdfPCell cell = new PdfPCell(new Phrase(table1.Columns[k].ColumnName));

                                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                                    cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                                    cell.BackgroundColor = BaseColor.BLUE;


                                    pdfTable.AddCell(cell);
                                }
                            }

                            for (int i = 0; i < table1.Rows.Count; i++)
                            {
                                for (int j = 0; j < table1.Columns.Count; j++)
                                {
                                    if (table1.Columns[j].ColumnName != "Id" && table1.Columns[j].ColumnName != "Id_service")
                                    {
                                        PdfPCell cell = new PdfPCell(new Phrase(table1.Rows[i][j].ToString()));

                                        //Align the cell in the center
                                        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                                        cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                                        pdfTable.AddCell(cell);
                                    }
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA);
                                Paragraph ph = new Paragraph("Relatório de Serviços Prestados", font);
                                ph.Alignment = Element.ALIGN_CENTER;
                                pdfDoc.Add(ph);
                                ///
                                ph = new Paragraph($"Funcionário: {comboBox_usuario.Text}  ", font);
                                ph.Alignment = Element.ALIGN_CENTER;
                                pdfDoc.Add(ph);
                                ///
                                ph = new Paragraph();
                                ph.Add("\n");
                                pdfDoc.Add(ph);

                                //   iTextSharp.text.pdf.draw.VerticalPositionMark seperator = new iTextSharp.text.pdf.draw.LineSeparator();

                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                        finally
                        {
                            if (sfd?.FileName != null)
                            {
                                var p = new Process();
                                p.StartInfo = new ProcessStartInfo(sfd.FileName)
                                {
                                    UseShellExecute = true
                                };
                                p.Start();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Não existe dados para serem impressos", "Info");

            }

        }
        private void adaToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void button_add_Click(object sender, EventArgs e)
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

                var newuser = Usuario;
                newuser.Email = comboBox_usuario.Text;

                var form = new CadastrarServicesDone(Token, newuser, id_usuarioselecionado);
                form.Owner = this;
                form.ShowDialog();
            }
        }
        private async void button_finalizar_Click(object sender, EventArgs e)
        {
            if (_ServiceDoneDTO != null && dataGridView1?.Rows.Count > 0)
            {
                _ServiceDoneDTO.Finalizado = true;
                _ServiceDoneDTO.Cancelado = false;
                var result = await Library.UpdateServiceDone(servicedone_id, _ServiceDoneDTO, Token);
                if (result != null)
                {
                    carregargrid(Token, null);
                }
            }
        }
        private async void button_cancelar_Click(object sender, EventArgs e)
        {

            if (_ServiceDoneDTO != null && dataGridView1?.Rows.Count > 0)
            {
                _ServiceDoneDTO.Finalizado = false;
                _ServiceDoneDTO.Cancelado = true;
                var result = await Library.UpdateServiceDone(servicedone_id, _ServiceDoneDTO, Token);
                if (result != null)
                {
                    carregargrid(Token, null);
                }
            }
        }
        private async void button_excluir_Click(object sender, EventArgs e)
        {
            try
            {
                var resultado = await Library.DeleteServiceDone(servicedone_id, Token);
                if (!string.IsNullOrWhiteSpace(resultado) && resultado.Contains("Deletado"))
                {
                    carregargrid(Token, null);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao exluir serviço prestado");
            }
        }
        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool _found = false;

            foreach (Form _openForm in Application.OpenForms)
            {
                if (_openForm is Services)
                {
                    _openForm.Focus();
                    _found = true;
                }
            }
            if (!_found)
            {
                var form = new Services(Token, Usuario);
                form.Show();
            }
        }
        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool _found = false;

            foreach (Form _openForm in Application.OpenForms)
            {
                if (_openForm is Produtos)
                {
                    _openForm.Focus();
                    _found = true;
                }
            }
            if (!_found)
            {
                var form = new Produtos(Token, Usuario);
                form.Show();
            }
        }
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mensagem = MessageBox.Show("Deseja realmente sair?", "atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (mensagem == DialogResult.Yes)
            {
                Properties.Settings.Default.dados = String.Empty;
                Properties.Settings.Default.Save();
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
        private async void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1?.Rows?.Count > 0)
            {
                var linhaAtual = dataGridView1.CurrentRow;
                int indice = linhaAtual.Index;

                string? id_servicedone = dataGridView1?.Rows[indice]?.Cells["Id"]?.Value?.ToString();

                var servicedones = await Library.GetServiçosFeitosByUser(Token, comboBox_usuario.Text, textBox_cliente.Text, dt_inicial, dt_final, cancelado, finalizado);

                if (servicedones != null)
                {
                    var clicado = servicedones.FirstOrDefault(id => id.Id == int.Parse(id_servicedone));

                    if (clicado != null)
                    {
                        var form = new UpdateServiceDone(Token, id_servicedone, clicado);
                        form.Owner = this;
                        form.ShowDialog();
                    }

                }
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
                    label_bemvindo.Invoke(new Action(() =>
                    {
                        label_bemvindo.Text = $"Seja bem-vindo(a) " + usuario_novo.Nome;
                    }));
                }

                DataTable table = new DataTable();
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("ClienteNome", typeof(string));
                table.Columns.Add("Data", typeof(DateTime));
                table.Columns.Add("Desconto", typeof(string));
                table.Columns.Add("ValorTotal", typeof(string));
                table.Columns.Add("Gojeta", typeof(string));
                table.Columns.Add("Finalizado", typeof(string));
                table.Columns.Add("Cancelado", typeof(string));

                if (dados == null)
                {
                    if (usuario_novo != null)
                    {
                        dados = await Library.GetServiçosFeitosByUser(token, comboBox_usuario.Text, textBox_cliente.Text, dt_inicial, dt_final, cancelado, finalizado);
                    }
                }
                if (dados != null)
                {
                    int contadora = 0;
                    foreach (var s in dados)
                    {
                        var finalizado = s.Finalizado == true ? "Sim" : "Não";

                        if (s.Finalizado == true)
                        {
                            soma = soma + s?.ValorTotal;
                        }

                        contadora++;
                        var cancelado = s.Cancelado == true ? "Sim" : "Não";

                        table.Rows.Add(s.Id, s.ClienteNome, s.Data, s?.Desconto + " R$", s?.ValorTotal + " R$", s?.Gojeta + " R$",
                            finalizado, cancelado);
                    }
                    if (table?.Rows?.Count > 0)
                    {
                        table1 = new DataTable();
                        table1 = table;
                        button_excluir.Enabled = true;
                        label6.Text = $"Valor Total dos Serviços finalizados: R$ {soma}";

                        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dataGridView1.RowHeadersVisible = false;
                        dataGridView1.EnableHeadersVisualStyles = false;
                        dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView1.AllowUserToResizeRows = false;
                        dataGridView1.AllowUserToResizeColumns = false;
                        dataGridView1.AllowUserToOrderColumns = false;
                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.MultiSelect = false;
                        //ExtensionMethods.DoubleBuffered(dataGridView1, false);
                        dataGridView1.DataSource = table;
                        this.dataGridView1.Columns["Id"].Visible = false;
                        //ExtensionMethods.DoubleBuffered(dataGridView1, true);
                    }
                    else
                    {
                        dataGridView1.DataSource = null;
                        button_cancelar.Enabled = false;
                        button_excluir.Enabled = false;
                        button_finalizar.Enabled = false;
                        button_imprimir.Enabled = false;
                    }
                }
                else
                {
                    dataGridView1.DataSource = null;
                    button_cancelar.Enabled = false;
                    button_excluir.Enabled = false;
                    button_finalizar.Enabled = false;
                    button_imprimir.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
