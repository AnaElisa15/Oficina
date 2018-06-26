using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OficinaMecanica.Models
{
    public class OrdemServicoViewModels
    {
        public OrdemServicoViewModels(List<OrdemServico> ordemServicos, List<Cliente> clientes, List<Funcionario> funcionarios, List<Servico> servicos)
        {
            this.OrdemServicos = ordemServicos;
            this.Clientes = clientes;
            this.Funcionarios = funcionarios;
            this.Servicos = servicos;
        }

        public List<OrdemServico> OrdemServicos { get; private set; }
        public List<Cliente> Clientes { get; private set; }
        public List<Funcionario> Funcionarios { get; private set; }
        public List<Servico> Servicos { get; private set; }
    }
}