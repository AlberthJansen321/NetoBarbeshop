using NetoBarbershorp.Desktop.BLL.DTO;
using NetoBarbershorp.Desktop.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NetoBarbershorp.Desktop.BLL
{
    public static class Library
    {
        private static string _urlBase = "https://localhost:44356/api/v1.0/";
        //  private static string _urlBase = "http://alberthdasilva-001-site1.htempurl.com/api/v1.0/";

        #region helpers
        public static bool ValidarEmail(string strEmail)
        {
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(strEmail, strModelo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static async void return_login(string? mensagem = null)
        {

            if (!string.IsNullOrWhiteSpace(mensagem))
            {
                MessageBox.Show(mensagem);
            }
            Properties.Settings.Default.dados = string.Empty;
            Properties.Settings.Default.Save();


            foreach (Form _openForm in Application.OpenForms)
            {
                if (_openForm is Login)
                {
                    _openForm.Focus();
                }
                else
                {
                    _openForm.Close();
                }
            }
        }
        private static async Task<string> ClientAsync(string? token = null, string? urlbase = null, string? comando = null, object? dados = null)
        {

            try
            {
                using (var client = new HttpClient())
                {
                    string conteudo = string.Empty;

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (!string.IsNullOrWhiteSpace(token))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }

                    HttpResponseMessage? httpResponse = null;

                    if (comando == "Get")
                    {
                        httpResponse = await client.GetAsync(urlbase);
                    }
                    if (comando == "Delete")
                    {
                        httpResponse = await client.DeleteAsync(urlbase);
                    }
                    if (comando == "Put" && dados != null)
                    {
                        httpResponse = await client.PutAsync(urlbase, new StringContent(
                        JsonConvert.SerializeObject(dados), Encoding.UTF8, "application/json"));
                    }
                    if (comando == "Post" && dados != null)
                    {
                        httpResponse = await client.PostAsync(urlbase, new StringContent(
                        JsonConvert.SerializeObject(dados), Encoding.UTF8, "application/json"));
                    }

                    if (httpResponse != null)
                    {
                        conteudo = await httpResponse.Content.ReadAsStringAsync();

                        if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                        {
                            MessageBox.Show(conteudo.Replace('"', ' ').Trim());
                            conteudo = string.Empty;
                        }

                        if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            if (conteudo.Contains("Unauthorized"))
                            {
                                return_login(conteudo + " ,Faça login novamente");
                            }
                            else
                            {
                                MessageBox.Show(conteudo);
                            }

                            conteudo = string.Empty;
                        }

                        if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
                        {
                            MessageBox.Show("Erro no servidor, entre em contato com o programador");
                            conteudo = string.Empty;
                        }


                        if (httpResponse.StatusCode == HttpStatusCode.UnprocessableEntity)
                        {
                            if (dados != null && conteudo != String.Empty)
                            {
                                var mensagem = JsonConvert.DeserializeObject<object?>(conteudo)?.ToString()?.Replace('"', ' ')
                                .Replace('[', ' ').Replace(']', ' ').Replace('{', ' ').Replace('}', ' ').Trim();

                                MessageBox.Show(mensagem);
                            }

                            conteudo = string.Empty;
                        }
                        if (httpResponse.StatusCode == HttpStatusCode.NoContent)
                        {
                            conteudo = String.Empty;
                        }

                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                        {
                            return conteudo;
                        }
                    }
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Accoount
        public static async Task<UsuarioDTO[]?> GetUsuarios(string token)
        {
            try
            {
                var urlbase = _urlBase + "account/usuarios";

                var conteudo = await ClientAsync(token, urlbase, "Get");

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    UsuarioDTO[]? retorno = JsonConvert.DeserializeObject<UsuarioDTO[]>(conteudo);
                    return retorno;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static async Task<UpdateUserDTO?> UpdateUser(UpdateUserDTO updateUserDTO, string token)
        {
            var urlbase = _urlBase + "account/update";

            try
            {
                var conteudo = await ClientAsync(token, urlbase, "Put", updateUserDTO);

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    UpdateUserDTO? retorno = JsonConvert.DeserializeObject<UpdateUserDTO>(conteudo);
                    return retorno;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        public static async Task<TokenDTO?> Login(string Email, string Senha)
        {
            var urlbase = _urlBase + "account/login";

            try
            {
                LoginDTO login = new LoginDTO();
                login.Email = Email;
                login.Senha = Senha;
                object dados = login;
                var conteudo = await ClientAsync(null, urlbase, "Post", dados);

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    TokenDTO? retorno = JsonConvert.DeserializeObject<TokenDTO>(conteudo);
                    return retorno;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        public static async Task<TokenDTO?> AddUsuario(UsuarioDTO usuarioDTO, string token)
        {
            var urlbase = _urlBase + "account/cadastrar";

            try
            {
                var conteudo = await ClientAsync(token, urlbase, "Post", usuarioDTO);

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    TokenDTO? retorno = JsonConvert.DeserializeObject<TokenDTO>(conteudo);
                    return retorno;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        public static async Task<bool> DeleteUser(string id, string token)
        {
            var urlbase = _urlBase + $"account/deletar/{id}";

            try
            {
                var conteudo = await ClientAsync(token, urlbase, "Delete", null);

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        public static async Task<bool> ResetPasswordUser(string id, string senha, string token)
        {
            var urlbase = _urlBase + $"account/resetpassword/{id}/{senha}";

            try
            {
                var conteudo = await ClientAsync(token, urlbase, "Get", null);

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        public static async Task<UsuarioDTO?> GetUsuario(string token, string email, string? senha = null)
        {
            var urlbase = _urlBase + "account/id";

            try
            {
                var conteudo = await ClientAsync(token, urlbase, "Get", null);

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    UsuarioDTO? dados = JsonConvert.DeserializeObject<UsuarioDTO>(conteudo);
                    return dados;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        public static async Task<string?> GetRole(string token)
        {
            var urlbase = _urlBase + "account/role";

            try
            {
                var conteudo = await ClientAsync(token, urlbase, "Get", null);

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    return conteudo;
                }

                return String.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        #endregion

        #region Produtos
        public static async Task<ProdutoDTO[]?> GetProdutos(string token)
        {
            var urlbase = _urlBase + "Produto/todos";

            try
            {
                var conteudo = await ClientAsync(token, urlbase, "Get", null);

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    return JsonConvert.DeserializeObject<ProdutoDTO[]>(conteudo);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        public static async Task<ProdutoDTO?> AddProduto(ProdutoDTO produtoDTO, string token)
        {
            var urlbase = _urlBase + "Produto/cadastrar";

            try
            {
                var conteudo = await ClientAsync(token, urlbase, "Post", produtoDTO);

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    return JsonConvert.DeserializeObject<ProdutoDTO>(conteudo);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        public static async Task<ProdutoDTO?> UpdateProduto(int id, ProdutoDTO produtoDTO, string token)
        {
            var urlbase = _urlBase + $"Produto/update/{id}";

            try
            {
                var conteudo = await ClientAsync(token, urlbase, "Put", produtoDTO);

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    return JsonConvert.DeserializeObject<ProdutoDTO>(conteudo);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        public static async Task<string?> DeleteProduto(int id, string token)
        {
            var urlbase = _urlBase + $"Produto/delete/{id}";

            try
            {
                var conteudo = await ClientAsync(token, urlbase, "Delete", null);

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    return conteudo;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        #endregion

        #region Services
        public static async Task<ServiceDTO?> GetServiceID(string token, int id)
        {
            var urlbase = _urlBase + "Service/id/" + id;

            try
            {
                var conteudo = await ClientAsync(token, urlbase, "Get", null);

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    return JsonConvert.DeserializeObject<ServiceDTO?>(conteudo);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        public static async Task<ServiceDTO[]?> GetServiços(string token)
        {
            var urlbase = _urlBase + "Service/todos";

            try
            {
                var conteudo = await ClientAsync(token, urlbase, "Get", null);

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    return JsonConvert.DeserializeObject<ServiceDTO[]?>(conteudo);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        public static async Task<ServiceDTO?> AddService(ServiceDTO serviceDTO, string token)
        {
            var urlbase = _urlBase + "Service/cadastrar";


            try
            {
                var conteudo = await ClientAsync(token, urlbase, "Post", serviceDTO);

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    return JsonConvert.DeserializeObject<ServiceDTO?>(conteudo);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        public static async Task<ServiceDTO?> UpdateService(int id, ServiceDTO serviceDTO, string token)
        {
            var urlbase = _urlBase + $"Service/atualizar/{id}";

            try
            {
                var conteudo = await ClientAsync(token, urlbase, "Put", serviceDTO);

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    return JsonConvert.DeserializeObject<ServiceDTO?>(conteudo);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        public static async Task<string?> DeleteService(int id, string token)
        {
            var urlbase = _urlBase + $"Service/deletar/{id}";

            try
            {
                var conteudo = await ClientAsync(token, urlbase, "Delete", null);

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    return conteudo;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        #endregion

        #region User
        public static async Task<ServiceDoneDTO[]?> GetFiltro(string nome, DateTime inicial, DateTime final, bool cancelado, bool finalizado, string token)
        {
            var urlbase = _urlBase + $"ServiceDone/todos";

            try
            {
                var conteudo = await ClientAsync(token, urlbase, "Get", null);

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    ServiceDoneDTO[]? serviceDoneDTO = JsonConvert.DeserializeObject<ServiceDoneDTO[]>(conteudo);

                    if (serviceDoneDTO != null)
                    {
                        ServiceDoneDTO[] query = serviceDoneDTO;

                        query = query.Where(f => f.ClienteNome.ToLower().Contains(nome.ToLower()) && f.Cancelado == cancelado && f.Finalizado == finalizado &&
                        f.Data.Date >= inicial.Date && f.Data.Date <= final.Date).OrderByDescending(id => id.Id).ToArray();

                        return query;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }

        }
        #endregion

        #region ServiceDone
        public static async Task<ServiceDoneDTO[]?> GetServiçosFeitosByUser(string token, string username, string nome, DateTime inicial, DateTime final, bool cancelado, bool finalizado)
        {

            var urlbase = _urlBase + $"ServiceDone/usuario/{username}";

            try
            {
                var conteudo = await ClientAsync(token, urlbase, "Get", null);

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    ServiceDoneDTO[]? serviceDoneDTO = JsonConvert.DeserializeObject<ServiceDoneDTO[]>(conteudo);

                    if (serviceDoneDTO != null)
                    {
                        ServiceDoneDTO[] query = serviceDoneDTO;

                        query = query.Where(f => f.ClienteNome.ToLower().Contains(nome.ToLower()) && f.Cancelado == cancelado && f.Finalizado == finalizado &&
                            f.Data.Date >= inicial.Date && f.Data.Date <= final.Date).OrderByDescending(id => id.Id).ToArray();

                        return query;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        public static async Task<ServiceDoneDTO[]?> GetServiçosFeitos(string token,string role)
        {

            var urlbase = _urlBase + $"ServiceDone/todos/{role}";

            try
            {
                var conteudo = await ClientAsync(token, urlbase, "Get", null);

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    return JsonConvert.DeserializeObject<ServiceDoneDTO[]>(conteudo);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        public static async Task<ServiceDoneDTO?> AddServiceDone(ServiceDoneDTO serviceDoneDTO, string token)
        {
            var urlbase = _urlBase + "ServiceDone/cadastrar";

            try
            {
                var conteudo = await ClientAsync(token, urlbase, "Post", serviceDoneDTO);

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    return JsonConvert.DeserializeObject<ServiceDoneDTO>(conteudo);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        public static async Task<ServiceDoneDTO?> UpdateServiceDone(int id, ServiceDoneDTO serviceDoneDTO, string token)
        {
            var urlbase = _urlBase + $"ServiceDone/atualizar/{id}";

            try
            {
                var conteudo = await ClientAsync(token, urlbase, "Put", serviceDoneDTO);

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    return JsonConvert.DeserializeObject<ServiceDoneDTO>(conteudo);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        public static async Task<string?> DeleteServiceDone(int id, string token)
        {
            var urlbase = _urlBase + $"ServiceDone/deletar/{id}";

            try
            {
                var conteudo = await ClientAsync(token, urlbase, "Delete", null);

                if (!string.IsNullOrWhiteSpace(conteudo))
                {
                    return conteudo;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        #endregion
    }
}
