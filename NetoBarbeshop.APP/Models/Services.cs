
namespace NetoBarbeshop.APP.Models
{
    public class Services
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<ServiceDone> ServicesDones { get; set; }
        public string ImagemURL { get; set; }

    }
}
