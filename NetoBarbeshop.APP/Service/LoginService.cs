using NetoBarbeshop.APP.Models;
using NetoBarbeshop.APP.Service.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace NetoBarbeshop.APP.Service
{
    public class LoginService : ILoginService
    {
        public async Task<UserToken> Login(UserLogin userLogin)
        {
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(100);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
             
                var response = await
                            client.PostAsync(App.url_base + "account/login", new StringContent(
                                JsonConvert.SerializeObject(new
                                {
                                    userLogin.Email,
                                    userLogin.Senha,

                                }), Encoding.UTF8, "application/json"));

                var conteudo = await response.Content.ReadAsStringAsync();
    
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<UserToken>(conteudo);
                }
                
                return null;
            }
        }
    }
}
