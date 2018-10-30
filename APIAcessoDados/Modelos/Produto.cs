using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace APIAcessoDados.Modelos
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "A data é de preenchimento obrigatório!")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O nome é de preenchimento obrigatório!")]
        [MinLength(1, ErrorMessage = "O tamanho mínimo do Nome são 1 caracteres.")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo do Nome são 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O valor é de preenchimento obrigatório!")]
        public decimal Valor { get; set; }

    }
}
