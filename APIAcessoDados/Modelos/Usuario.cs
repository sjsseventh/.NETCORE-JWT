using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace APIAcessoDados.Modelos
{
    public class Usuario
    {
        [Key]
        public string UserID { get; set; }

        [Required(ErrorMessage = "Digite a senha para acessar!")]
        public string AccessKey { get; set; }
    }
}
