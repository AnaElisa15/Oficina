using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OficinaMecanica.Models
{
    public class Empresa
    {
        [Key]
        public int EmpresaID { get; set; }

        [Required(ErrorMessage = "O nome da empresa é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o seu CNPJ", AllowEmptyStrings = false)]
        [RegularExpression(@"^(\d{14})$", ErrorMessage = "O CNPJ deve conter 14 dígitos")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Informe o seu e-mail", AllowEmptyStrings = false)]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido !")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe um Telefone", AllowEmptyStrings = false)]
        public string Telefone { get; set; }

        [ForeignKey("_Endereco")]
        public int EnderecoID { get; set; }

        public virtual Endereco _Endereco { get; set; }
    }
}