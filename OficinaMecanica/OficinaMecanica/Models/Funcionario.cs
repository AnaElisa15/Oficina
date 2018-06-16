using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OficinaMecanica.Models
{
    public class Funcionario
    {
        [Key]
        public int FuncionarioID { get; set; }

        [Required(ErrorMessage = "O nome do funcionario é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o seu CPF", AllowEmptyStrings = false)]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Informe CPF com 11 dígitos válido !")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Informe seu cargo", AllowEmptyStrings = false)]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "Informe o seu Telefone", AllowEmptyStrings = false)]
        public string Telefone { get; set; }

        [ForeignKey("_Endereco")]
        public int EnderecoID { get; set; }

        public virtual Endereco _Endereco { get; set; }

    }
}