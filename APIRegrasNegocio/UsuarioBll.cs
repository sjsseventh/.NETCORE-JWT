using APIAcessoDados.Modelos;
using APIAcessoDados.ModelView;
using APIAcessoDados.ObjetosAcesso;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIRegrasNegocio
{
    public class UsuarioBll
    {
        UsuarioDAO _usuarioDAO = new UsuarioDAO();

        public void Inserir(UsuarioModelView usuarioModelView)
        {
            var usuario = new Usuario();

            usuario.UserID = usuarioModelView.UserID;
            usuario.AccessKey = usuarioModelView.AccessKey;

            _usuarioDAO.Inserir(usuario);
        }

        public Usuario ObterPorId(string userID)
        {
            return _usuarioDAO.ObterPorId(userID);
        }
    }
}
