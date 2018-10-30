using APIAcessoDados.Modelos;
using APIAcessoDados.ModelView;
using APIAcessoDados.ObjetosAcesso;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIRegrasNegocio
{
    public class ProdutoBll
    {
        ProdutoDAO _produtoDAO = new ProdutoDAO();

        public void Inserir(ProdutoModelView produtoModelView)
        {
            var produto = new Produto();

            produto.Nome = produtoModelView.Nome;
            produto.Data = produtoModelView.Data;
            produto.Valor = produtoModelView.Valor;

            _produtoDAO.Inserir(produto);
        }

        public Produto ObterPorId(int idProduto)
        {
            return _produtoDAO.ObterPorId(idProduto);
        }

        public void Deletar(int idProduto)
        {
            _produtoDAO.Deletar(idProduto);
        }

        public void Atualizar(int idProduto, ProdutoModelView produtoModelView)
        {
            var produto = ObterPorId(idProduto);

            produto.Data = produtoModelView.Data;
            produto.Nome = produtoModelView.Nome;
            produto.Valor = produtoModelView.Valor;

            _produtoDAO.Atualizar(produto);
        }

        public List<Produto> ObterTodos()
        {
            return _produtoDAO.ObterTodos();
        }

    }
}
