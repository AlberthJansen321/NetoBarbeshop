using System;
using System.ComponentModel.DataAnnotations;

namespace NetoBarbershorp.Desktop.BLL.DTO
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Required]
        public DateTime DtCadastro { get; set; }
        [Required]
        public double Valor { get; set; }
        public string ImagemURL { get; set; }
        [Required]
        public bool Habilitado { get; set; }
        public override string ToString()
        {
            return Nome + " - " + Valor.ToString() + " R$";
        }
    }
}
