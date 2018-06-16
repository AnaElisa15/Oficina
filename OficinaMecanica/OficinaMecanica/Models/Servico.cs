using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OficinaMecanica.Models
{
    public class Servico
    {
        [Key]
        public int ServicoID { get; set; }

        [Required(ErrorMessage = "O campo nome do serviço é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o valor do serviço", AllowEmptyStrings = false)]
        public Decimal Valor { get; set; }
    }
}