using NetoBarbeshop.APP.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using NetoBarbeshop.APP.Service.Interface;
using System.Text;
using NetoBarbeshop.APP.Models.DTO;
using NetoBarbeshop.APP.Views;

namespace NetoBarbeshop.APP.Service
{
    public class HomeService : IHomeService
    {
        public async Task<List<ServiceDone>> ServiceDonesByUser()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Token);

                var response = await client.GetAsync(App.url_base + "ServiceDone/todos");

                var conteudo = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    verificar(conteudo);
                }

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<List<ServiceDone>>(conteudo);
                }

            }

            return null;
        }
        public async Task<List<Services>> Services()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Token);

                var response = await client.GetAsync(App.url_base + "Service/todos");

                var conteudo = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    verificar(conteudo);
                }

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<List<Services>>(conteudo);
                }
            }

            return null;
        }
        public async Task<bool> DeleteServiceDone(string id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Token);

                var response = await client.DeleteAsync(App.url_base + $"ServiceDone/deletar/{id}");

                var conteudo = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    verificar(conteudo);
                }

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
            }

            return false;
        }
        private async void verificar(string conteudo)
        {
            if (conteudo.Contains("Unauthorized"))
            {
                await Shell.Current.DisplayAlert("Atenção", "Seção expirada, faça login pra continuar", "Ok");
                await Shell.Current.GoToAsync($"//{nameof(Login)}");
            }
        }
        public async Task<bool> AddServiceDone(ServiceDone model)
        {

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Token);

                var response = await
                       client.PostAsync(App.url_base + "ServiceDone/cadastrar", new StringContent(
                           JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

                var conteudo = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    verificar(conteudo);
                }

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
            }
            return false;
        }
        public async Task<UsuarioDTO> Getusuario()
        {

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Token);

                var response = await client.GetAsync(App.url_base + "account/id");

                var conteudo = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    verificar(conteudo);
                }

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<UsuarioDTO>(conteudo);
                }
            }
            return null;
        }
    }
}
