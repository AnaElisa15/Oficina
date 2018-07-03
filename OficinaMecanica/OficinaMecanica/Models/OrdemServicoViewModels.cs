using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OficinaMecanica.Models
{
    public class OrdemServicoViewModels
    {
        public OrdemServicoViewModels(List<OrdemServico> ordemServicos, List<Situacao> situacaos)
        {
            this.OrdemServicos = ordemServicos;
            this.Situacaos = situacaos;
           
        }

        public List<OrdemServico> OrdemServicos { get; private set; }
        public List<Situacao> Situacaos { get; private set; }
        
    }
}