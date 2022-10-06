using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetoBarbershop.Application.DTO;
using NetoBarbershop.Application.Interfaces;
using NetoBarbershop.Domain.Models;
using NetoBarbershop.Repository.Interfaces;
using System;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace NetoBarbershop.Application
{
    public class ProdutoApplication : IProdutoApplication
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IGeralRepository _geralRepository;
        private readonly IMapper _mapper;
        public ProdutoApplication(IProdutoRepository produtoRepository, IGeralRepository geralRepository,IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _geralRepository = geralRepository;
            _mapper = mapper;
        }
        public async Task<ProdutoDTO[]> GetAllProdutos()
        {
            try
            {
                var produtos = await _produtoRepository.GetallProdutos();

                if (produtos == null) return null;

                var resultado = _mapper.Map<ProdutoDTO[]>(produtos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ProdutoDTO> GetByIdProduto(int idproduto)
        {
            try
            {
                var produto = await _produtoRepository.GetByIdProduto(idproduto);

                if (produto == null) return null;

                return _mapper.Map<ProdutoDTO>(produto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ProdutoDTO> Add(ProdutoDTO model)
        {
            try
            {
                var produto = _mapper.Map<Produto>(model);

                _geralRepository.Add(produto);


                if(await _geralRepository.SaveChangesAsync())
                {
                    var produto_retorno = await _produtoRepository.GetByIdProduto(produto.Id);

                    return _mapper.Map<ProdutoDTO>(produto_retorno);                    
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var produto = await _produtoRepository.GetByIdProduto(id);

                if (produto == null) return false;

                _geralRepository.Delete(produto);

                return await _geralRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ProdutoDTO> Update(ProdutoDTO model, int id)
        {
            try
            {
                var produto = await _produtoRepository.GetByIdProduto(id);

                if (produto == null) return null;

                _mapper.Map(model,produto);
                produto.Id = id;
                _geralRepository.Update(produto);

                if(await _geralRepository.SaveChangesAsync())
                {
                    var produto_retorno = await _produtoRepository.GetByIdProduto(id);

                    return _mapper.Map<ProdutoDTO>(produto_retorno);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDTO> GetByNomeProduto(string nome)
        {
            try
            {
                var produto = await _produtoRepository.GetByNomeProduto(nome);

                if (produto == null) return null;

                return _mapper.Map<ProdutoDTO>(produto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
