using APIAcessoDados.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIAcessoDados.ObjetosAcesso
{
    public class UsuarioDAO
    {
        BancoDeDados _bancoDeDados = new BancoDeDados();

        public void Inserir(Usuario usuario)
        {
            _bancoDeDados.Add(usuario);
            _bancoDeDados.SaveChanges();
        }

        public Usuario ObterPorId(string userID)
        {
            return _bancoDeDados.Usuarios
                .Where(p => p.UserID == userID)
                .FirstOrDefault();
        }
    }
}
