using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NetoBarbeshop.APP.Models;
using NetoBarbeshop.APP.Service.Interface;
using System.Collections.ObjectModel;

namespace NetoBarbeshop.APP.ViewModels
{
    public partial class HomePageViewModel : BaseViewModel
    {
        [ObservableProperty]
        Services selectedservice;
        //cadastro variaveis
        [ObservableProperty]
        public string clienteNomecadastro;
        [ObservableProperty]
        public string valorcadastro;
        [ObservableProperty]
        public string servicecadastro;
        [ObservableProperty]
        public DateTime datacadastro;
        //fimcadasro

        [ObservableProperty]
        public double valor;
        [ObservableProperty]
        public string status;
        IConnectivity connectivity;
        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        DateTime dataInicial;
        [ObservableProperty]
        DateTime dataFinal;

        [ObservableProperty]
        DateTime maxDate;
        public ObservableCollection<ServiceDoneDTO> ServiceDones { get; } = new();
        public ObservableCollection<Services> Services { get; } = new();
        public RelayCommand<ServiceDoneDTO> DeleteServiceDoneCommand { get; private set; }
        public RelayCommand<string> SearchServiceDoneCommand { get; private set; }

        private IHomeService _homeService;

        public HomePageViewModel(IHomeService homeService, IConnectivity connectivity)
        {
            MaxDate = DateTime.UtcNow;
            DataInicial = DateTime.UtcNow.AddDays(-30);
            DataFinal = DateTime.UtcNow;
            Datacadastro = DateTime.UtcNow;
            _homeService = homeService;
            this.connectivity = connectivity;

            GetserviceDonesPendentes();
            GetServices();

            DeleteServiceDoneCommand = new RelayCommand<ServiceDoneDTO>((param) => Delete(param));
            SearchServiceDoneCommand = new RelayCommand<string>((param) => SearchServiceDone(param));           
        }
        public async void SearchServiceDone(string param)
        {
            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Atenção", "Verifique sua conexão com a internet", "Ok");
                    return;
                }

                if (status == "pendente")
                {
                    ServiceDones.Clear();
                    await GetserviceDonesPendentes();
                }
                if (status == "cancelado")
                {
                    ServiceDones.Clear();
                    await GetserviceDonesCancelados();
                }
                if (status == "finalizado")
                {
                    ServiceDones.Clear();
                    await GetserviceDonesFinalizados();
                }

                var newlist = ServiceDones.ToList();

                if (!string.IsNullOrWhiteSpace(param))
                {
                    ServiceDones.Clear();

                    var dados = newlist.Where(w => w.ClienteNome.ToLower().StartsWith(param) || w.ServiceNome.ToLower().StartsWith(param) ||
                    w.ClienteNome.StartsWith(param) || w.ServiceNome.StartsWith(param));

                    foreach (var d in dados)
                    {              
                       ServiceDones.Add(d);                     
                    }
                }
                else
                {

                }
            }
            catch
            {

            }
            finally
            {

            }
        }
        public async void Delete(ServiceDoneDTO model)
        {
            try
            {
                if (model.Finalizado == true)
                {
                    await Shell.Current.DisplayAlert("Atenção", "Já está finalizado não pode ser excluido", "Ok");
                    return;
                }

                if (model != null && model.Finalizado == false)
                {
                    var resultado = await _homeService.DeleteServiceDone(model.Id.ToString());

                    if (resultado == true)
                    {
                        if (status == "cancelado")
                        {
                            await GetserviceDonesCancelados();
                        }
                        if (status == "finalizado")
                        {
                            await GetserviceDonesFinalizados();
                        }
                        if (status == "pendente")
                        {
                            await GetserviceDonesPendentes();
                        }

                    }
                }
            }
            catch
            {

            }
            finally
            {

            }
        }
        [RelayCommand]
        public async void GetServices()
        {
            try
            {
                var result = await _homeService.Services();

                if(result != null)
                {
                    if (Services?.Count > 0)
                    {
                        Services.Clear();
                    }
                    foreach (var dados in result)
                    {
                        Services.Add(dados);
                    }
                }
            }
            catch
            {

            }finally
            {

            }
        }
        [RelayCommand]
        public async void AddServiceDone()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Valorcadastro) && !string.IsNullOrWhiteSpace(ClienteNomecadastro) && Services != null)
                {
                    var usuario = await _homeService.Getusuario();
                    
                    var servicedone = new ServiceDone();
                    servicedone.ClienteNome = clienteNomecadastro;
                    servicedone.Valor = Convert.ToDouble(Valorcadastro.Replace(".",","));
                    servicedone.ServiceID = selectedservice.Id;
                    servicedone.Data = Datacadastro;
                    servicedone.Cancelado = false;
                    servicedone.Finalizado = false;
                    servicedone.UsuarioID = usuario.Id;

                   var result = await _homeService.AddServiceDone(servicedone);

                   if(result == true)
                    {
                        ClienteNomecadastro = String.Empty;
                        Valorcadastro = String.Empty;
                        Datacadastro = DateTime.UtcNow;
                        App.updateview = true;
                        await Shell.Current.DisplayAlert("Sucesso", "Dados Cadastrados", "OK");
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Erro", "Não foi possivel realizar o cadastro", "OK");
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Atenção", "Preencha todos os campos corretamente", "OK");
                }
            }
            catch
            {

            }
            finally
            {

            }
        }
        [RelayCommand]
        public async Task GetserviceDonesCancelados()
        {

            if (IsBusy)
                return;

            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Atenção", "Verifique sua conexão com a internet", "Ok");
                    return;
                }

                IsBusy = true;

                Valor = 0;

                var servicesdonebyuser = await _homeService.ServiceDonesByUser();
                var services = await _homeService.Services();


                if (ServiceDones.Count != 0)
                {
                    ServiceDones.Clear();
                }


                Status = "cancelado";

                foreach (var dados in servicesdonebyuser)
                {
                    Valor = Valor + dados.Valor;

                    if (dados.Cancelado == true && dados.Data >= dataInicial && dados.Data <= dataFinal.AddDays(1))
                    {
                        var servicedonedto = new ServiceDoneDTO();
                        servicedonedto.Valor = dados.Valor;
                        servicedonedto.Id = dados.Id;
                        servicedonedto.ServiceNome = services?.FirstOrDefault(IDservice => IDservice.Id == dados.ServiceID).Nome;
                        servicedonedto.Status = Status;
                        servicedonedto.Cancelado = dados.Cancelado;
                        servicedonedto.ClienteNome = dados.ClienteNome;
                        servicedonedto.Data = dados.Data;
                        servicedonedto.Finalizado = dados.Finalizado;

                        ServiceDones.Add(servicedonedto);
                    }
                }

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }
        [RelayCommand]
        public async Task GetserviceDonesFinalizados()
        {
            if (IsBusy)
                return;

            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Atenção", "Verifique sua conexão com a internet", "Ok");
                    return;
                }

                IsBusy = true;

                Valor = 0;

                var servicesdonebyuser = await _homeService.ServiceDonesByUser();
                var services = await _homeService.Services();

                if (ServiceDones.Count != 0)
                {
                    ServiceDones.Clear();
                }

                if (servicesdonebyuser?.Count > 0)
                {
                    Status = "finalizado";

                    foreach (var dados in servicesdonebyuser)
                    {
                        Valor = Valor + dados.Valor;

                        if (dados.Finalizado == true && dados.Data >= dataInicial && dados.Data <= dataFinal.AddDays(1))
                        {

                            var servicedonedto = new ServiceDoneDTO();
                            servicedonedto.Valor = dados.Valor;
                            servicedonedto.Id = dados.Id;
                            servicedonedto.ServiceNome = services?.FirstOrDefault(IDservice => IDservice.Id == dados.ServiceID).Nome;
                            servicedonedto.Status = Status;
                            servicedonedto.Cancelado = dados.Cancelado;
                            servicedonedto.ClienteNome = dados.ClienteNome;
                            servicedonedto.Data = dados.Data;
                            servicedonedto.Finalizado = dados.Finalizado;

                            ServiceDones.Add(servicedonedto);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }
        [RelayCommand]
        public async Task GetserviceDonesPendentes()
        {
            if (IsBusy)
                return;

            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Atenção", "Verifique sua conexão com a internet", "Ok");
                    return;
                }

                IsBusy = true;

                Valor = 0;

                var servicesdonebyuser = await _homeService.ServiceDonesByUser();
                var services = await _homeService.Services();

                if (ServiceDones.Count != 0)
                {
                    ServiceDones.Clear();
                }

                if (servicesdonebyuser?.Count > 0)
                {
                    Status = "pendente";

                    foreach (var dados in servicesdonebyuser)
                    {
                        Valor = Valor + dados.Valor;

                        if (dados.Finalizado == false && dados.Cancelado == false && dados.Data >= dataInicial && dados.Data <= dataFinal.AddDays(1))
                        {

                            var servicedonedto = new ServiceDoneDTO();
                            servicedonedto.Valor = dados.Valor;
                            servicedonedto.Id = dados.Id;
                            servicedonedto.ServiceNome = services?.FirstOrDefault(IDservice => IDservice.Id == dados.ServiceID).Nome;
                            servicedonedto.Status = Status;
                            servicedonedto.Cancelado = dados.Cancelado;
                            servicedonedto.ClienteNome = dados.ClienteNome;
                            servicedonedto.Data = dados.Data;
                            servicedonedto.Finalizado = dados.Finalizado;

                            ServiceDones.Add(servicedonedto);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }
    }
}