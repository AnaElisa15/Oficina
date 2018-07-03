using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OficinaMecanica.Models
{
    public class OrdemServico
    {
        [Key]
        public int OrdemServicoID { get; set; }

        [Required(ErrorMessage = "Informe a placa do veiculo", AllowEmptyStrings = false)]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Informe o modelo do veiculo", AllowEmptyStrings = false)]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Informe o ano do veiculo", AllowEmptyStrings = false)]
        public int Ano { get; set; }

        public int SituacaoID { get; set; }
        public virtual Situacao _Situacao { get; set; }
        
    }
}