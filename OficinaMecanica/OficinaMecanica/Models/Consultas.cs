using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OficinaMecanica.Models
{
    public class Consultas
    {
        [Key]
        public int ConsultasID { get; set; }

        [ForeignKey("_Cliente")]
        public int ClienteID { get; set; }

        [ForeignKey("_OrdemServico")]
        public int OrdemServicoID { get; set; }

        public virtual OrdemServico _OrdemServico { get; set; }
    }
}