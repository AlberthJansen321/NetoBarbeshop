using NetoBarbershop.Application.DTO;
using NetoBarbershop.Domain.Models;
using System.Threading.Tasks;

namespace NetoBarbershop.Application.Interfaces
{
    public interface IProdutoApplication
    {
        Task<ProdutoDTO> Add(ProdutoDTO model);
        Task<ProdutoDTO> Update(ProdutoDTO model,int id);
        Task<bool> Delete(int id);
        Task<ProdutoDTO[]> GetAllProdutos();
        Task<ProdutoDTO> GetByIdProduto(int idproduto);
        Task<ProdutoDTO> GetByNomeProduto(string nome);
    }
}
