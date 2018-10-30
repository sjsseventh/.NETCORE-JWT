using APIAcessoDados.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIAcessoDados
{
    public class BancoDeDados : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql("server=localhost;" +
            "user id=root;" +
            "password=password;database=Apidotnet;"
             );
        }

    }
}
