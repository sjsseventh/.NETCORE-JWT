using APIAcessoDados.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIAcessoDados.ObjetosAcesso
{
    public class ProdutoDAO
    {
        BancoDeDados _bancoDeDados = new BancoDeDados();

        public void Inserir(Produto produto)
        {
            _bancoDeDados.Produtos.Add(produto);
            _bancoDeDados.SaveChanges();
        }

        public Produto ObterPorId(int id)
        {
            return _bancoDeDados.Produtos
                .Where(p => p.IdProduto == id)
                .FirstOrDefault();
        }

        public void Deletar(int idProduto)
        {
            var produto = ObterPorId(idProduto);
            _bancoDeDados.Produtos.Remove(produto);
            _bancoDeDados.SaveChanges();
        }

        public void Atualizar(Produto produto)
        {
            _bancoDeDados.Produtos.Update(produto);
            _bancoDeDados.SaveChanges();
        }

        public List<Produto> ObterTodos()
        {
            return _bancoDeDados.Produtos.ToList();
        }

    }
}
