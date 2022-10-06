namespace NetoBarbeshop.APP.Models
{
    public class ServiceDoneDTO
    {
        public int Id { get; set; }
        public string ClienteNome { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public bool Finalizado { get; set; }
        public bool Cancelado { get; set; }
        public string UsuarioID { get; set; }
        public int? ServiceID { get; set; }
        public string ServiceNome { get; set; }
        public double Valor { get; set; }
    }
}
