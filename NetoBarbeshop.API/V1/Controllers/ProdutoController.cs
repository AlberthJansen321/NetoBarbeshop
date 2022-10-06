using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using NetoBarbershop.Application.Interfaces;
using NetoBarbershop.Application.DTO;

namespace NetoBarbershop.API.V1.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoApplication _produtoApplication;
        public ProdutoController(IProdutoApplication produtoApplication)
        {
            _produtoApplication = produtoApplication;
        }

        [HttpGet("todos")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var produtos = await _produtoApplication.GetAllProdutos();
                if (produtos == null) return NoContent();

                return Ok(produtos);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel retornar os usuarios. Erro {ex.Message}");
            }
        }
        [HttpPost("cadastrar")]
        public async Task<ActionResult> Post(ProdutoDTO model)
        {
            try
            {
                var produto = await _produtoApplication.GetByNomeProduto(model.Nome);
                if (produto != null) return NoContent();

                var result = await _produtoApplication.Add(model);
                if (result == null) return NoContent();

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel retornar os usuarios. Erro {ex.Message}");
            }
        }
        [HttpPut("update/{idproduto}")]
        public async Task<ActionResult> Put(ProdutoDTO model, int idproduto)
        {
            try
            {
                var produto = await _produtoApplication.GetByIdProduto(idproduto);
                if (produto == null) return NoContent(); 

                var result = await _produtoApplication.Update(model,idproduto);
                if (result == null) return BadRequest("Erro ao cadastrar o produto");

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel retornar os usuarios. Erro {ex.Message}");
            }
        }
        [HttpDelete("delete/{idproduto}")]
        public async Task<ActionResult> Delete(int idproduto)
        {
            try
            {
                var produto = await _produtoApplication.GetByIdProduto(idproduto);
                if (produto == null) return NoContent();

                return await _produtoApplication.Delete(idproduto) ? Ok("Deletado") :
                throw new Exception("Ocorreu um problema não especifico ao tentar deletar o produto");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel retornar os usuarios. Erro {ex.Message}");
            }
        }
    }
}
