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
        public char Placa { get; set; }

        [Required(ErrorMessage = "Informe o modelo do veiculo", AllowEmptyStrings = false)]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Informe o ano do veiculo", AllowEmptyStrings = false)]
        public int Ano { get; set; }

        [Required(ErrorMessage = "Informe o prazo para a data de entrega", AllowEmptyStrings = false)]
        public int DataEntrega { get; set; }

        [ForeignKey("_Cliente")]
        public int ClienteID { get; set; }
        public virtual Cliente _Cliente { get; set; }

        [ForeignKey("_Funcionario")]
        public int FuncionarioID { get; set; }
        public virtual Funcionario _Funcionario { get; set; }
        

        [ForeignKey("_Servico")]
        public int ServicoID { get; set; }
        public virtual Servico _Servico { get; set; }
    }
}