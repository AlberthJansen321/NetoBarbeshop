using NetoBarbershop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetoBarbershop.Repository.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto[]> GetallProdutos();
        Task<Produto> GetByIdProduto(int idproduto);
        Task<Produto> GetByNomeProduto(string nome);
    }
}
