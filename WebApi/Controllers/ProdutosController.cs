using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiWeb.Models;
using WebApi.Contracts.Models.Produtos;

namespace ApiWeb.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ProdutoSimplificado>>> ObterTodos([FromServices] DataContext context)
        {
            try
            {
                var produtos = await context.Produtos.ToListAsync();
                var produtosSimplificados = ProdutoSimplificado.ProdutoParaProdutoSimplificado(produtos);

                return produtosSimplificados;
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro desconhecido");
            }
        }

        [HttpGet("{produtoId}")]
        public async Task<ActionResult<Produto>> ObterDetalhes(
            [FromServices] DataContext context,
            long produtoId
        )
        {
            try
            {
                var produto = await context.Produtos.FindAsync(produtoId);

                if (produto == null)
                    return NotFound();

                return produto;
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro desconhecido");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> Post(
            [FromServices] DataContext context,
            [FromBody] ProdutoSimplificado model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Produtos.Add(model.ProdutoSimplificadoParaProduto());

                    await context.SaveChangesAsync();

                    return Ok("Produto Cadastrado");
                }
                else
                {
                    return StatusCode(412, "Os valores informados não são válidos");
                }
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro desconhecido");
            }
        }
        [HttpDelete("{produtoId}")]
        public async Task<IActionResult> DeleteProduto(
            [FromServices] DataContext context,
            long produtoId)
        {
            var produto = await context.Produtos.FindAsync(produtoId);

            if (produto == null)
            {
                return NotFound();
            }

            context.Produtos.Remove(produto);
            await context.SaveChangesAsync();

            return NoContent();
        }







    }
}
