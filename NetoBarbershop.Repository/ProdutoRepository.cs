using Microsoft.EntityFrameworkCore;
using NetoBarbershop.Domain.Models;
using NetoBarbershop.Repository.Contextos;
using NetoBarbershop.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NetoBarbershop.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly NetoBarbershopContext _context;

        public ProdutoRepository(NetoBarbershopContext context)
        {
            _context = context;
        }

        public async Task<Produto[]> GetallProdutos()
        {
            IQueryable<Produto> query = _context.Produtos;

            query = query.OrderBy(o => o.Id);

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Produto> GetByIdProduto(int idproduto)
        {
            IQueryable<Produto> query = _context.Produtos;

            query = query.OrderBy(o => o.Id).Where(id=>id.Id == idproduto);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Produto> GetByNomeProduto(string nome)
        {
            IQueryable<Produto> query = _context.Produtos;

            query = query.OrderBy(o => o.Id).Where(id => id.Nome == nome);

            return await query.FirstOrDefaultAsync();
        }
    }
}
