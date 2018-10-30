using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAcessoDados.ModelView;
using APIRegrasNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/Produto")]
    public class ProdutoController : Controller
    {
        ProdutoBll _produtoBll = new ProdutoBll();

        /// <summary>
        /// Adiciona Produto
        /// </summary>
        /// <param name="temperatura">Temperatura em Fahrenheit</param>
        /// <returns>Objeto contendo valores para uma temperatura
        /// nas escalas Fahrenheit, Celsius e Kelvin.</returns>
        [Route("~/api/Produto/Adicionar")]
        [Authorize("Bearer")]
        [HttpPost]
        public IActionResult Post([FromBody] ProdutoModelView produtoModelView)
        {
            try
            {
                _produtoBll.Inserir(produtoModelView);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        [Route("~/api/Produto/BuscarPorId/{idProduto}")]
        [Authorize("Bearer")]
        [HttpGet]
        public IActionResult ObterPorId(int idProduto)
        {
            try
            {
                var produto = _produtoBll.ObterPorId(idProduto);
                return Json(produto);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        [Route("~/api/Produto/BuscarTodos")]
        [Authorize("Bearer")]
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            try
            {
                var produtos = _produtoBll.ObterTodos();
                return Json(produtos);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        [Route("~/api/Produto/AlterarPorId/{idProduto}")]
        [Authorize("Bearer")]
        [HttpPut]
        public IActionResult AlterarPorId(int idProduto, [FromBody] ProdutoModelView produtoModelView)
        {
            try
            {
                _produtoBll.Atualizar(idProduto, produtoModelView);
                return NoContent();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        [Route("~/api/Produto/DeletarPorId/{idProduto}")]
        [Authorize("Bearer")]
        [HttpDelete]
        public IActionResult DeletarPorId(int idProduto)
        {
            try
            {
                _produtoBll.Deletar(idProduto);
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }
    }
}