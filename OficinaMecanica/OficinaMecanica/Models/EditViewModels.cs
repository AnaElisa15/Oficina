using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OficinaMecanica.Models
{
    public class EditViewModels
    {
        public EditViewModels (OrdemServico ordemServico, List<Situacao> situacao)
        {
            this.OrdemServico = ordemServico;
            this.Situacaos = Situacaos;
            
        }

        public OrdemServico OrdemServico { get; set; }

        [Required(ErrorMessage = "Selecione a situação da OS")]
        public List<Situacao> Situacaos { get; set; }
       
    }
}